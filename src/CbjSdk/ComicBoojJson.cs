#nullable enable
#pragma warning disable CS8618
#pragma warning disable CS8601
#pragma warning disable CS8602
#pragma warning disable CS8603


using System;
using System.Collections.Generic;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;

namespace CbjSdk;

/// <summary>
/// JSON representation of the ComicInfo 2.1 model, adapted from the ComicInfo 2.1 XSD. Every
/// schema element includes a description suitable for automatic class and attribute
/// documentation. ComicPageInfo additionally requires ImageBase64 to store the page image
/// directly in the JSON document.
/// </summary>
public partial class ComicBoojJson
{
    /// <summary>
    /// The age rating assigned to the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("AgeRating")]
    public AgeRating? AgeRating { get; set; }

    /// <summary>
    /// The total number of issues in the alternate series or collection.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("AlternateCount")]
    public long? AlternateCount { get; set; }

    /// <summary>
    /// The issue number in the alternate series.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("AlternateNumber")]
    public string? AlternateNumber { get; set; }

    /// <summary>
    /// An alternate series name for the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("AlternateSeries")]
    public string? AlternateSeries { get; set; }

    /// <summary>
    /// Indicates whether the comic is black and white.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("BlackAndWhite")]
    public BlackAndWhite? BlackAndWhite { get; set; }

    /// <summary>
    /// The characters appearing in the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Characters")]
    public string? Characters { get; set; }

    /// <summary>
    /// The colorist or colorists of the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Colorist")]
    public string? Colorist { get; set; }

    /// <summary>
    /// The community rating of the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("CommunityRating")]
    [JsonConverter(typeof(MinMaxValueCheckConverter))]
    public double? CommunityRating { get; set; }

    /// <summary>
    /// The total number of issues in the series or collection.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Count")]
    public long? Count { get; set; }

    /// <summary>
    /// The cover artist or cover artists of the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("CoverArtist")]
    public string? CoverArtist { get; set; }

    /// <summary>
    /// The publication day of the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Day")]
    public long? Day { get; set; }

    /// <summary>
    /// The editor or editors of the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Editor")]
    public string? Editor { get; set; }

    /// <summary>
    /// The format or publication format of the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Format")]
    public string? Format { get; set; }

    /// <summary>
    /// The genre or genres of the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Genre")]
    public string? Genre { get; set; }

    /// <summary>
    /// The Global Trade Item Number associated with the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("GTIN")]
    public string? Gtin { get; set; }

    /// <summary>
    /// The imprint under which the comic was published.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Imprint")]
    public string? Imprint { get; set; }

    /// <summary>
    /// The inker or inkers of the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Inker")]
    public string? Inker { get; set; }

    /// <summary>
    /// The ISO language code of the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("LanguageISO")]
    public string? LanguageIso { get; set; }

    /// <summary>
    /// The letterer or letterers of the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Letterer")]
    public string? Letterer { get; set; }

    /// <summary>
    /// The locations appearing in the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Locations")]
    public string? Locations { get; set; }

    /// <summary>
    /// The main character or team featured in the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("MainCharacterOrTeam")]
    public string? MainCharacterOrTeam { get; set; }

    /// <summary>
    /// Indicates whether the comic is manga and, when applicable, whether it should be read
    /// right-to-left.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Manga")]
    public Manga? Manga { get; set; }

    /// <summary>
    /// The publication month of the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Month")]
    public long? Month { get; set; }

    /// <summary>
    /// Additional notes about the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Notes")]
    public string? Notes { get; set; }

    /// <summary>
    /// The issue or volume number within the series.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Number")]
    public string? Number { get; set; }

    /// <summary>
    /// The number of pages in the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("PageCount")]
    public long? PageCount { get; set; }

    /// <summary>
    /// The pages of the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Pages")]
    public PageElement[]? Pages { get; set; }

    /// <summary>
    /// The penciller or pencillers of the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Penciller")]
    public string? Penciller { get; set; }

    /// <summary>
    /// The publisher of the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Publisher")]
    public string? Publisher { get; set; }

    /// <summary>
    /// A review of the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Review")]
    public string? Review { get; set; }

    /// <summary>
    /// Information about the scanning or digital source of the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ScanInformation")]
    public string? ScanInformation { get; set; }

    /// <summary>
    /// The series name to which the comic belongs.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Series")]
    public string? Series { get; set; }

    /// <summary>
    /// The group or collection associated with the series.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("SeriesGroup")]
    public string? SeriesGroup { get; set; }

    /// <summary>
    /// The story arc to which the comic belongs.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("StoryArc")]
    public string? StoryArc { get; set; }

    /// <summary>
    /// The number of the comic within the story arc.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("StoryArcNumber")]
    public string? StoryArcNumber { get; set; }

    /// <summary>
    /// A summary or synopsis of the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Summary")]
    public string? Summary { get; set; }

    /// <summary>
    /// Tags describing the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Tags")]
    public string? Tags { get; set; }

    /// <summary>
    /// The teams appearing in the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Teams")]
    public string? Teams { get; set; }

    /// <summary>
    /// The title of the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Title")]
    public string? Title { get; set; }

    /// <summary>
    /// The translator or translators of the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Translator")]
    public string? Translator { get; set; }

    /// <summary>
    /// The volume number of the series.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Volume")]
    public long? Volume { get; set; }

    /// <summary>
    /// A web URL associated with the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Web")]
    public string? Web { get; set; }

    /// <summary>
    /// The writer or writers of the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Writer")]
    public string? Writer { get; set; }

    /// <summary>
    /// The publication year of the comic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Year")]
    public long? Year { get; set; }
}

/// <summary>
/// The pages of the comic.
///
/// The collection of pages belonging to the comic.
///
/// Information describing a comic page and its embedded image.
/// </summary>
public partial class PageElement
{
    /// <summary>
    /// The bookmark associated with the page.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Bookmark")]
    public string? Bookmark { get; set; }

    /// <summary>
    /// Indicates whether the page represents a double-page spread.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("DoublePage")]
    public bool? DoublePage { get; set; }

    /// <summary>
    /// The zero-based index of the page image.
    /// </summary>
    [JsonPropertyName("Image")]
    public long Image { get; set; }

    /// <summary>
    /// Base64-encoded page image data. This property is required by the ComicBookJson adaptation
    /// of ComicInfo 2.1.
    /// </summary>
    [JsonPropertyName("ImageBase64")]
    public string ImageBase64 { get; set; }

    /// <summary>
    /// The height of the page image in pixels.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ImageHeight")]
    public long? ImageHeight { get; set; }

    /// <summary>
    /// The size of the page image in bytes.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ImageSize")]
    public long? ImageSize { get; set; }

    /// <summary>
    /// The width of the page image in pixels.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ImageWidth")]
    public long? ImageWidth { get; set; }

    /// <summary>
    /// A key identifying the page image.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Key")]
    public string? Key { get; set; }

    /// <summary>
    /// The type or types assigned to the page.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Type")]
    public TypeElement[]? Type { get; set; }
}

/// <summary>
/// The age rating assigned to the comic.
///
/// The age classification assigned to the comic.
/// </summary>
public enum AgeRating { AdultsOnly18, EarlyChildhood, Everyone, Everyone10, G, KidsToAdults, M, Ma15, Mature17, Pg, R18, RatingPending, Teen, Unknown, X18 };

/// <summary>
/// Indicates whether the comic is black and white.
///
/// Indicates whether a property is unknown, false, or true.
/// </summary>
public enum BlackAndWhite { No, Unknown, Yes };

/// <summary>
/// Indicates whether the comic is manga and, when applicable, whether it should be read
/// right-to-left.
///
/// Indicates whether the comic is manga and supports a right-to-left reading mode.
/// </summary>
public enum Manga { No, Unknown, Yes, YesAndRightToLeft };

/// <summary>
/// The type or types assigned to the page.
///
/// The type or types assigned to a comic page.
/// </summary>
public enum TypeElement { Advertisement, BackCover, Deleted, Editorial, FrontCover, InnerCover, Letters, Other, Preview, Roundup, Story };

public partial class ComicBoojJson
{
    public static ComicBoojJson FromJson(string json) => JsonSerializer.Deserialize<ComicBoojJson>(json, CbjSdk.Converter.Settings);
}

public static class Serialize
{
    public static string ToJson(this ComicBoojJson self) => JsonSerializer.Serialize(self, CbjSdk.Converter.Settings);
}

internal static class Converter
{
    public static readonly JsonSerializerOptions Settings = new(JsonSerializerDefaults.General)
    {
        Converters =
        {
            AgeRatingConverter.Singleton,
            BlackAndWhiteConverter.Singleton,
            MangaConverter.Singleton,
            TypeElementConverter.Singleton,
            new DateOnlyConverter(),
            new TimeOnlyConverter(),
            IsoDateTimeOffsetConverter.Singleton
        },
    };
}

internal class AgeRatingConverter : JsonConverter<AgeRating>
{
    public override bool CanConvert(Type t) => t == typeof(AgeRating);

    public override AgeRating Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        switch (value)
        {
            case "Adults Only 18+":
                return AgeRating.AdultsOnly18;
            case "Early Childhood":
                return AgeRating.EarlyChildhood;
            case "Everyone":
                return AgeRating.Everyone;
            case "Everyone 10+":
                return AgeRating.Everyone10;
            case "G":
                return AgeRating.G;
            case "Kids to Adults":
                return AgeRating.KidsToAdults;
            case "M":
                return AgeRating.M;
            case "MA15+":
                return AgeRating.Ma15;
            case "Mature 17+":
                return AgeRating.Mature17;
            case "PG":
                return AgeRating.Pg;
            case "R18+":
                return AgeRating.R18;
            case "Rating Pending":
                return AgeRating.RatingPending;
            case "Teen":
                return AgeRating.Teen;
            case "Unknown":
                return AgeRating.Unknown;
            case "X18+":
                return AgeRating.X18;
        }
        throw new Exception("Cannot unmarshal type AgeRating");
    }

    public override void Write(Utf8JsonWriter writer, AgeRating value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case AgeRating.AdultsOnly18:
                JsonSerializer.Serialize(writer, "Adults Only 18+", options);
                return;
            case AgeRating.EarlyChildhood:
                JsonSerializer.Serialize(writer, "Early Childhood", options);
                return;
            case AgeRating.Everyone:
                JsonSerializer.Serialize(writer, "Everyone", options);
                return;
            case AgeRating.Everyone10:
                JsonSerializer.Serialize(writer, "Everyone 10+", options);
                return;
            case AgeRating.G:
                JsonSerializer.Serialize(writer, "G", options);
                return;
            case AgeRating.KidsToAdults:
                JsonSerializer.Serialize(writer, "Kids to Adults", options);
                return;
            case AgeRating.M:
                JsonSerializer.Serialize(writer, "M", options);
                return;
            case AgeRating.Ma15:
                JsonSerializer.Serialize(writer, "MA15+", options);
                return;
            case AgeRating.Mature17:
                JsonSerializer.Serialize(writer, "Mature 17+", options);
                return;
            case AgeRating.Pg:
                JsonSerializer.Serialize(writer, "PG", options);
                return;
            case AgeRating.R18:
                JsonSerializer.Serialize(writer, "R18+", options);
                return;
            case AgeRating.RatingPending:
                JsonSerializer.Serialize(writer, "Rating Pending", options);
                return;
            case AgeRating.Teen:
                JsonSerializer.Serialize(writer, "Teen", options);
                return;
            case AgeRating.Unknown:
                JsonSerializer.Serialize(writer, "Unknown", options);
                return;
            case AgeRating.X18:
                JsonSerializer.Serialize(writer, "X18+", options);
                return;
        }
        throw new Exception("Cannot marshal type AgeRating");
    }

    public static readonly AgeRatingConverter Singleton = new AgeRatingConverter();
}

internal class BlackAndWhiteConverter : JsonConverter<BlackAndWhite>
{
    public override bool CanConvert(Type t) => t == typeof(BlackAndWhite);

    public override BlackAndWhite Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        switch (value)
        {
            case "No":
                return BlackAndWhite.No;
            case "Unknown":
                return BlackAndWhite.Unknown;
            case "Yes":
                return BlackAndWhite.Yes;
        }
        throw new Exception("Cannot unmarshal type BlackAndWhite");
    }

    public override void Write(Utf8JsonWriter writer, BlackAndWhite value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case BlackAndWhite.No:
                JsonSerializer.Serialize(writer, "No", options);
                return;
            case BlackAndWhite.Unknown:
                JsonSerializer.Serialize(writer, "Unknown", options);
                return;
            case BlackAndWhite.Yes:
                JsonSerializer.Serialize(writer, "Yes", options);
                return;
        }
        throw new Exception("Cannot marshal type BlackAndWhite");
    }

    public static readonly BlackAndWhiteConverter Singleton = new BlackAndWhiteConverter();
}

internal class MinMaxValueCheckConverter : JsonConverter<double>
{
    public override bool CanConvert(Type t) => t == typeof(double);

    public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetDouble();
        if (value >= 0 && value <= 5)
        {
            return value;
        }
        throw new Exception("Cannot unmarshal type double");
    }

    public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
    {
        if (value >= 0 && value <= 5)
        {
            JsonSerializer.Serialize(writer, value, options);
            return;
        }
        throw new Exception("Cannot marshal type double");
    }

    public static readonly MinMaxValueCheckConverter Singleton = new MinMaxValueCheckConverter();
}

internal class MangaConverter : JsonConverter<Manga>
{
    public override bool CanConvert(Type t) => t == typeof(Manga);

    public override Manga Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        switch (value)
        {
            case "No":
                return Manga.No;
            case "Unknown":
                return Manga.Unknown;
            case "Yes":
                return Manga.Yes;
            case "YesAndRightToLeft":
                return Manga.YesAndRightToLeft;
        }
        throw new Exception("Cannot unmarshal type Manga");
    }

    public override void Write(Utf8JsonWriter writer, Manga value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case Manga.No:
                JsonSerializer.Serialize(writer, "No", options);
                return;
            case Manga.Unknown:
                JsonSerializer.Serialize(writer, "Unknown", options);
                return;
            case Manga.Yes:
                JsonSerializer.Serialize(writer, "Yes", options);
                return;
            case Manga.YesAndRightToLeft:
                JsonSerializer.Serialize(writer, "YesAndRightToLeft", options);
                return;
        }
        throw new Exception("Cannot marshal type Manga");
    }

    public static readonly MangaConverter Singleton = new MangaConverter();
}

internal class TypeElementConverter : JsonConverter<TypeElement>
{
    public override bool CanConvert(Type t) => t == typeof(TypeElement);

    public override TypeElement Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        switch (value)
        {
            case "Advertisement":
                return TypeElement.Advertisement;
            case "BackCover":
                return TypeElement.BackCover;
            case "Deleted":
                return TypeElement.Deleted;
            case "Editorial":
                return TypeElement.Editorial;
            case "FrontCover":
                return TypeElement.FrontCover;
            case "InnerCover":
                return TypeElement.InnerCover;
            case "Letters":
                return TypeElement.Letters;
            case "Other":
                return TypeElement.Other;
            case "Preview":
                return TypeElement.Preview;
            case "Roundup":
                return TypeElement.Roundup;
            case "Story":
                return TypeElement.Story;
        }
        throw new Exception("Cannot unmarshal type TypeElement");
    }

    public override void Write(Utf8JsonWriter writer, TypeElement value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case TypeElement.Advertisement:
                JsonSerializer.Serialize(writer, "Advertisement", options);
                return;
            case TypeElement.BackCover:
                JsonSerializer.Serialize(writer, "BackCover", options);
                return;
            case TypeElement.Deleted:
                JsonSerializer.Serialize(writer, "Deleted", options);
                return;
            case TypeElement.Editorial:
                JsonSerializer.Serialize(writer, "Editorial", options);
                return;
            case TypeElement.FrontCover:
                JsonSerializer.Serialize(writer, "FrontCover", options);
                return;
            case TypeElement.InnerCover:
                JsonSerializer.Serialize(writer, "InnerCover", options);
                return;
            case TypeElement.Letters:
                JsonSerializer.Serialize(writer, "Letters", options);
                return;
            case TypeElement.Other:
                JsonSerializer.Serialize(writer, "Other", options);
                return;
            case TypeElement.Preview:
                JsonSerializer.Serialize(writer, "Preview", options);
                return;
            case TypeElement.Roundup:
                JsonSerializer.Serialize(writer, "Roundup", options);
                return;
            case TypeElement.Story:
                JsonSerializer.Serialize(writer, "Story", options);
                return;
        }
        throw new Exception("Cannot marshal type TypeElement");
    }

    public static readonly TypeElementConverter Singleton = new TypeElementConverter();
}

public class DateOnlyConverter : JsonConverter<DateOnly>
{
    private readonly string serializationFormat;
    public DateOnlyConverter() : this(null) { }

    public DateOnlyConverter(string? serializationFormat)
    {
            this.serializationFormat = serializationFormat ?? "yyyy-MM-dd";
    }

    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
            var value = reader.GetString();
            return DateOnly.Parse(value!);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(serializationFormat));
}

public class TimeOnlyConverter : JsonConverter<TimeOnly>
{
    private readonly string serializationFormat;

    public TimeOnlyConverter() : this(null) { }

    public TimeOnlyConverter(string? serializationFormat)
    {
            this.serializationFormat = serializationFormat ?? "HH:mm:ss.fff";
    }

    public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
            var value = reader.GetString();
            return TimeOnly.Parse(value!);
    }

    public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(serializationFormat));
}

internal class IsoDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
    public override bool CanConvert(Type t) => t == typeof(DateTimeOffset);

    private const string DefaultDateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";

    private DateTimeStyles _dateTimeStyles = DateTimeStyles.RoundtripKind;
    private string? _dateTimeFormat;
    private CultureInfo? _culture;

    public DateTimeStyles DateTimeStyles
    {
            get => _dateTimeStyles;
            set => _dateTimeStyles = value;
    }

    public string? DateTimeFormat
    {
            get => _dateTimeFormat ?? string.Empty;
            set => _dateTimeFormat = (string.IsNullOrEmpty(value)) ? null : value;
    }

    public CultureInfo Culture
    {
            get => _culture ?? CultureInfo.CurrentCulture;
            set => _culture = value;
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
            string text;


            if ((_dateTimeStyles & DateTimeStyles.AdjustToUniversal) == DateTimeStyles.AdjustToUniversal
                    || (_dateTimeStyles & DateTimeStyles.AssumeUniversal) == DateTimeStyles.AssumeUniversal)
            {
                    value = value.ToUniversalTime();
            }

            text = value.ToString(_dateTimeFormat ?? DefaultDateTimeFormat, Culture);

            writer.WriteStringValue(text);
    }

    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
            string? dateText = reader.GetString();

            if (string.IsNullOrEmpty(dateText) == false)
            {
                    if (!string.IsNullOrEmpty(_dateTimeFormat))
                    {
                            return DateTimeOffset.ParseExact(dateText, _dateTimeFormat, Culture, _dateTimeStyles);
                    }
                    else
                    {
                            return DateTimeOffset.Parse(dateText, Culture, _dateTimeStyles);
                    }
            }
            else
            {
                    return default(DateTimeOffset);
            }
    }


    public static readonly IsoDateTimeOffsetConverter Singleton = new IsoDateTimeOffsetConverter();
}

#pragma warning restore CS8618
#pragma warning restore CS8601
#pragma warning restore CS8602
#pragma warning restore CS8603