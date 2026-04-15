namespace ChurchLiveScheduler.sdk.Models;

public sealed record GetAllResponse
{
    public required IEnumerable<SeriesDto> Series { get; init; }
    public required IEnumerable<SpecialDto> Specials { get; init; }
}
