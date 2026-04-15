using System.Diagnostics;

namespace ChurchLiveScheduler.sdk.Models;

[DebuggerDisplay("Id={Id}, Name={Name}")]
public sealed record SeriesDto
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public DayOfWeek Day { get; init; }
    public int Hours { get; init; }
    public int Minutes { get; init; }
    public IEnumerable<CancellationDto>? Cancellations { get; init; }
}

[DebuggerDisplay("Name={Name}")]
public sealed record UpdateSeriesRequest
{
    public required string Name { get; init; }
    public required DayOfWeek Day { get; init; }
    public required int Hours { get; init; }
    public required int Minutes { get; init; }
}

[DebuggerDisplay("Name={Name}")]
public sealed record UpdateSeriesResponse
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required DayOfWeek Day { get; init; }
    public required int Hours { get; init; }
    public required int Minutes { get; init; }
}