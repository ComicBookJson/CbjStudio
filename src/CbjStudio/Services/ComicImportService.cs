using System.IO.Compression;
using System.Text;
using System.Xml.Linq;
using CbjSdk;
using SharpCompress.Archives;

namespace CbjStudio.Services;

public sealed record ComicPageSource(string Name, byte[] Data);

public sealed class ComicImportResult
{
    public ComicBoojJson Comic { get; init; } = new();
    public List<ComicPageSource> Pages { get; init; } = [];
    public bool HasComicInfo { get; init; }
    public string SourceName { get; init; } = string.Empty;
}

public sealed class ComicImportService
{
    private static readonly HashSet<string> ImageExtensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".jpg", ".jpeg", ".png", ".webp", ".gif", ".bmp"
    };

    public async Task<ComicImportResult> ImportAsync(FileResult file, CancellationToken cancellationToken = default)
    {
        await using var input = await file.OpenReadAsync();
        var bytes = await ReadAllAsync(input, cancellationToken);

        var entries = new List<(string Name, byte[] Data)>();
        using var archiveStream = new MemoryStream(bytes, writable: false);
        using var archive = ArchiveFactory.Open(archiveStream);

        foreach (var entry in archive.Entries.Where(e => !e.IsDirectory))
        {
            cancellationToken.ThrowIfCancellationRequested();
            await using var entryStream = new MemoryStream();
            entry.WriteTo(entryStream);
            entries.Add((entry.Key, entryStream.ToArray()));
        }

        var comicInfoEntry = entries.FirstOrDefault(e =>
            string.Equals(Path.GetFileName(e.Name), "ComicInfo.xml", StringComparison.OrdinalIgnoreCase));

        var comic = comicInfoEntry.Data is { Length: > 0 }
            ? ParseComicInfo(comicInfoEntry.Data)
            : CreateDefaultComic();

        var pages = entries
            .Where(e => ImageExtensions.Contains(Path.GetExtension(e.Name)))
            .OrderBy(e => e.Name, NaturalStringComparer.Instance)
            .Select(e => new ComicPageSource(Path.GetFileName(e.Name), e.Data))
            .ToList();

        comic.PageCount = pages.Count;
        comic.Pages = pages.Select((p, index) => new PageElement
        {
            Image = index,
            ImageBase64 = Convert.ToBase64String(p.Data),
            ImageSize = p.Data.LongLength,
            DoublePage = false,
            Type = [TypeElement.Story]
        }).ToArray();

        return new ComicImportResult
        {
            Comic = comic,
            Pages = pages,
            HasComicInfo = comicInfoEntry.Data is { Length: > 0 },
            SourceName = file.FileName
        };
    }

    public async Task<byte[]> CreateCbjAsync(ComicBoojJson comic, CancellationToken cancellationToken = default)
    {
        await using var output = new MemoryStream();
        using (var zip = new ZipArchive(output, ZipArchiveMode.Create, leaveOpen: true))
        {
            var entry = zip.CreateEntry("data.json", CompressionLevel.Optimal);
            await using var entryStream = entry.Open();
            var jsonBytes = Encoding.UTF8.GetBytes(comic.ToJson());
            await entryStream.WriteAsync(jsonBytes, cancellationToken);
        }
        return output.ToArray();
    }

    private static ComicBoojJson CreateDefaultComic() => new()
    {
        Count = -1, Volume = -1, AlternateCount = -1,
        Year = -1, Month = -1, Day = -1, PageCount = 0,
        BlackAndWhite = BlackAndWhite.Unknown,
        Manga = Manga.Unknown,
        AgeRating = AgeRating.Unknown
    };

    private static ComicBoojJson ParseComicInfo(byte[] data)
    {
        var comic = CreateDefaultComic();
        var document = XDocument.Parse(Encoding.UTF8.GetString(data));
        var root = document.Root ?? throw new InvalidDataException("ComicInfo.xml não possui um elemento raiz.");

        foreach (var property in typeof(ComicBoojJson).GetProperties())
        {
            if (!property.CanWrite || property.Name is nameof(ComicBoojJson.Pages) or nameof(ComicBoojJson.PageCount))
                continue;

            var jsonName = property.GetCustomAttributes(typeof(System.Text.Json.Serialization.JsonPropertyNameAttribute), false)
                .OfType<System.Text.Json.Serialization.JsonPropertyNameAttribute>()
                .FirstOrDefault()?.Name ?? property.Name;
            var element = root.Elements().FirstOrDefault(e =>
                string.Equals(e.Name.LocalName, jsonName, StringComparison.OrdinalIgnoreCase));
            if (element is null || string.IsNullOrWhiteSpace(element.Value)) continue;

            try { property.SetValue(comic, ConvertValue(element.Value.Trim(), property.PropertyType)); }
            catch { /* Preserve defaults when an optional ComicInfo field cannot be converted. */ }
        }
        return comic;
    }

    private static object? ConvertValue(string value, Type targetType)
    {
        var type = Nullable.GetUnderlyingType(targetType) ?? targetType;
        if (type == typeof(string)) return value;
        if (type == typeof(long)) return long.TryParse(value, out var l) ? l : null;
        if (type == typeof(double)) return double.TryParse(value, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var d) ? d : null;

        if (type.IsEnum)
        {
            var aliases = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["Adults Only 18+"] = "AdultsOnly18", ["Everyone 10+"] = "Everyone10",
                ["Kids to Adults"] = "KidsToAdults", ["MA15+"] = "Ma15",
                ["Mature 17+"] = "Mature17", ["R18+"] = "R18",
                ["Rating Pending"] = "RatingPending", ["X18+"] = "X18"
            };
            var name = aliases.TryGetValue(value, out var alias) ? alias : value;
            return Enum.Parse(type, name.Replace(" ", string.Empty), true);
        }

        return Convert.ChangeType(value, type, System.Globalization.CultureInfo.InvariantCulture);
    }

    private static async Task<byte[]> ReadAllAsync(Stream stream, CancellationToken cancellationToken)
    {
        using var memory = new MemoryStream();
        await stream.CopyToAsync(memory, cancellationToken);
        return memory.ToArray();
    }

    private sealed class NaturalStringComparer : IComparer<string>
    {
        public static readonly NaturalStringComparer Instance = new();

        public int Compare(string? x, string? y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (x is null) return -1;
            if (y is null) return 1;

            var ix = 0; var iy = 0;
            while (ix < x.Length && iy < y.Length)
            {
                if (char.IsDigit(x[ix]) && char.IsDigit(y[iy]))
                {
                    long nx = 0, ny = 0;
                    while (ix < x.Length && char.IsDigit(x[ix])) nx = nx * 10 + x[ix++] - '0';
                    while (iy < y.Length && char.IsDigit(y[iy])) ny = ny * 10 + y[iy++] - '0';
                    var n = nx.CompareTo(ny);
                    if (n != 0) return n;
                }
                else
                {
                    var c = char.ToUpperInvariant(x[ix++]).CompareTo(char.ToUpperInvariant(y[iy++]));
                    if (c != 0) return c;
                }
            }
            return (x.Length - ix).CompareTo(y.Length - iy);
        }
    }
}
