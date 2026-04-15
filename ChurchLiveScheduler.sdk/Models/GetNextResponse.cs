namespace ChurchLiveScheduler.sdk.Models;

public sealed record GetNextResponse
{
    public string? Name { get; init; }
    public DateTime Start { get; init; }
}
