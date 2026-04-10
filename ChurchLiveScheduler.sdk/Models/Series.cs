using System.Diagnostics;
using System.Text.Json.Serialization;

namespace ChurchLiveScheduler.sdk.Models;

[DebuggerDisplay("Id={Id}, Name={Name}")]
public record SeriesDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("day")]
    public DayOfWeek Day { get; set; }

    [JsonPropertyName("hours")]
    public int Hours { get; set; }

    [JsonPropertyName("minutes")]
    public int Minutes { get; set; }

    [JsonPropertyName("cancellations")]
    public IEnumerable<CancellationDto>? Cancellations { get; set; }
}

[DebuggerDisplay("Name={Name}")]
public class UpdateSeriesRequest
{
    public string Name { get; set; }
    public DayOfWeek Day { get; set; }
    public int Hours { get; set; }
    public int Minutes { get; set; }
}

[DebuggerDisplay("Name={Name}")]
public class UpdateSeriesResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DayOfWeek Day { get; set; }
    public int Hours { get; set; }
    public int Minutes { get; set; }
}