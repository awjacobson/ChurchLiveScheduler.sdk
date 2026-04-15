using System.Diagnostics;
using System.Text.Json.Serialization;

namespace ChurchLiveScheduler.sdk.Models;

[DebuggerDisplay("Date={Date}, Reason={Reason}")]
public sealed record CreateCancellationRequest
{
    [JsonPropertyName("date")]
    public required string Date { get; init; }

    [JsonPropertyName("reason")]
    public string? Reason { get; init; }
}
