using System.Collections.ObjectModel;
using System.Reflection;
using System.Text.Json.Serialization;
using CbjSdk;
using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CbjStudio.Services;

namespace CbjStudio.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly ComicImportService importService = new();

    [ObservableProperty] private ComicBoojJson comic = new();
    [ObservableProperty] private string status = "Pronto para importar um comic book.";
    [ObservableProperty] private string sourceName = string.Empty;
    [ObservableProperty] private bool hasComicInfo;
    [ObservableProperty] private int currentPageIndex = -1;

    public ObservableCollection<MetadataFieldViewModel> Metadata { get; } = [];
    public ObservableCollection<ComicPageEditorViewModel> Pages { get; } = [];
    public IReadOnlyList<string> CurrentPageTypeOptions { get; } = Enum.GetNames<TypeElement>();

    public ComicPageEditorViewModel? CurrentPage =>
        CurrentPageIndex >= 0 && CurrentPageIndex < Pages.Count ? Pages[CurrentPageIndex] : null;

    public MainViewModel()
    {
        Title = "Comic Book Json Studio";
        CreateEmptyComic();
    }

    [RelayCommand]
    private async Task ImportComicAsync()
    {
        try
        {
            var file = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Selecione um comic book",
                FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    [DevicePlatform.WinUI] = [".cbz", ".cbr", ".zip", ".rar"],
                    [DevicePlatform.Android] = ["application/zip", "application/x-rar-compressed"],
                    [DevicePlatform.iOS] = ["public.zip-archive", "com.rarlab.rar-archive"],
                    [DevicePlatform.MacCatalyst] = ["public.zip-archive", "com.rarlab.rar-archive"]
                })
            });

            if (file is null) return;

            Status = "Importando comic book...";
            var result = await importService.ImportAsync(file);

            Comic = result.Comic;
            SourceName = result.SourceName;
            HasComicInfo = result.HasComicInfo;

            Metadata.Clear();
            BuildMetadata();

            Pages.Clear();
            for (var i = 0; i < result.Pages.Count; i++)
            {
                var page = result.Comic.Pages![i];
                var image = ImageSource.FromStream(() => new MemoryStream(result.Pages[i].Data, writable: false));
                Pages.Add(new ComicPageEditorViewModel(page, result.Pages[i].Name, image, i));
            }

            CurrentPageIndex = Pages.Count > 0 ? 0 : -1;
            Status = result.HasComicInfo
                ? $"Importado: {Pages.Count} páginas. ComicInfo.xml encontrado e aplicado."
                : $"Importado: {Pages.Count} páginas. ComicInfo.xml não encontrado; valores padrão aplicados.";
        }
        catch (Exception ex)
        {
            Status = $"Falha ao importar: {ex.Message}";
            await Shell.Current.DisplayAlert("Importação", ex.Message, "OK");
        }
    }

    [RelayCommand]
    private void CreateNewComic() => CreateEmptyComic();

    [RelayCommand]
    private async Task ExportComicAsync()
    {
        try
        {
            ApplyMetadata();
            Comic.PageCount = Pages.Count;
            Comic.Pages = Pages.Select(p => p.Model).ToArray();

            var bytes = await importService.CreateCbjAsync(Comic);
            using var stream = new MemoryStream(bytes, writable: false);
            var result = await FileSaver.Default.SaveAsync("comic.cbj", stream);

            if (!result.IsSuccessful)
                throw result.Exception ?? new IOException("Não foi possível salvar o arquivo CBJ.");

            Status = $"CBJ salvo em {result.FilePath}";
            await Shell.Current.DisplayAlert("Exportação", "Arquivo CBJ criado com sucesso.", "OK");
        }
        catch (Exception ex)
        {
            Status = $"Falha ao exportar: {ex.Message}";
            await Shell.Current.DisplayAlert("Exportação", ex.Message, "OK");
        }
    }

    [RelayCommand]
    private void PreviousPage()
    {
        if (Pages.Count == 0) return;
        CurrentPageIndex = Math.Max(0, CurrentPageIndex - 1);
    }

    [RelayCommand]
    private void NextPage()
    {
        if (Pages.Count == 0) return;
        CurrentPageIndex = Math.Min(Pages.Count - 1, CurrentPageIndex + 1);
    }

    partial void OnCurrentPageIndexChanged(int value) => OnPropertyChanged(nameof(CurrentPage));

    private void CreateEmptyComic()
    {
        Comic = new ComicBoojJson
        {
            Count = -1,
            Volume = -1,
            AlternateCount = -1,
            Year = -1,
            Month = -1,
            Day = -1,
            PageCount = 0,
            BlackAndWhite = BlackAndWhite.Unknown,
            Manga = Manga.Unknown,
            AgeRating = AgeRating.Unknown,
            Pages = []
        };

        SourceName = string.Empty;
        HasComicInfo = false;
        Pages.Clear();
        Metadata.Clear();
        BuildMetadata();
        CurrentPageIndex = -1;
        Status = "Novo comic criado com valores padrão.";
    }

    private void BuildMetadata()
    {
        foreach (var property in typeof(ComicBoojJson).GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (!property.CanWrite || property.Name is nameof(ComicBoojJson.Pages) or nameof(ComicBoojJson.PageCount))
                continue;

            var jsonName = property.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? property.Name;
            var value = property.GetValue(Comic);
            var display = value switch
            {
                null => string.Empty,
                Enum e => EnumDisplay(e),
                _ => Convert.ToString(value, System.Globalization.CultureInfo.InvariantCulture) ?? string.Empty
            };

            var type = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
            var options = type.IsEnum
                ? Enum.GetValues(type).Cast<Enum>().Select(EnumDisplay).ToArray()
                : null;

            Metadata.Add(new MetadataFieldViewModel(jsonName, display, options));
        }
    }

    private void ApplyMetadata()
    {
        foreach (var field in Metadata)
        {
            var property = typeof(ComicBoojJson).GetProperties().FirstOrDefault(p =>
                string.Equals(p.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? p.Name, field.Name, StringComparison.OrdinalIgnoreCase));
            if (property is null || !property.CanWrite) continue;

            try
            {
                var target = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                if (target == typeof(string))
                    property.SetValue(Comic, field.Value);
                else if (target == typeof(long))
                    property.SetValue(Comic, long.TryParse(field.Value, out var l) ? l : -1);
                else if (target == typeof(double))
                    property.SetValue(Comic, double.TryParse(field.Value, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var d) ? d : 0);
                else if (target.IsEnum)
                    property.SetValue(Comic, ParseEnum(target, field.Value));
            }
            catch { }
        }
    }

    private static object ParseEnum(Type type, string value)
    {
        var aliases = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["Adults Only 18+"] = "AdultsOnly18", ["Everyone 10+"] = "Everyone10",
            ["Kids to Adults"] = "KidsToAdults", ["MA15+"] = "Ma15",
            ["Mature 17+"] = "Mature17", ["R18+"] = "R18",
            ["Rating Pending"] = "RatingPending", ["X18+"] = "X18"
        };
        return Enum.Parse(type, aliases.TryGetValue(value, out var name) ? name : value, true);
    }

    private static string EnumDisplay(Enum value) => value switch
    {
        AgeRating.AdultsOnly18 => "Adults Only 18+",
        AgeRating.Everyone10 => "Everyone 10+",
        AgeRating.KidsToAdults => "Kids to Adults",
        AgeRating.Ma15 => "MA15+",
        AgeRating.Mature17 => "Mature 17+",
        AgeRating.R18 => "R18+",
        AgeRating.RatingPending => "Rating Pending",
        AgeRating.X18 => "X18+",
        _ => value.ToString()
    };
}
