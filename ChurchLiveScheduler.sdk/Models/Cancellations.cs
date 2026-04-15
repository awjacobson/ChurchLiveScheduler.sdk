using System.Diagnostics;

namespace ChurchLiveScheduler.sdk.Models;

[DebuggerDisplay("Id={Id}, Reason={Reason}")]
public sealed record CancellationDto
{
    public int Id { get; init; }
    public int SeriesId { get; init; }
    public DateOnly Date { get; init; }
    public string? Reason { get; init; }
}

#region Update

public sealed record UpdateCancellationRequest
{
    public DateOnly Date { get; init; }
    public string? Reason { get; init; }
}

public sealed record UpdateCancellationResponse
{
    public int Id { get; init; }
    public int SeriesId { get; init; }
    public DateOnly Date { get; init; }
    public string? Reason { get; init; }
}

#endregion

#region Delete

[DebuggerDisplay("SeriesId={SeriesId}, CancellationId={CancellationId}")]
public sealed record DeleteCancellationRequest
{
    public int SeriesId { get; init; }
    public int CancellationId { get; init; }
}

[DebuggerDisplay("Id={Id}, Reason={Reason}")]
public sealed record DeleteCancellationResponse
{
    public int Id { get; init; }
    public int SeriesId { get; init; }
    public DateOnly Date { get; init; }
    public string? Reason { get; init; }
}

#endregion
