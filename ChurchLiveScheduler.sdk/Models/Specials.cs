using System.Diagnostics;
using System.Text.Json.Serialization;

namespace ChurchLiveScheduler.sdk.Models;

public record SpecialDto
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("date")]
    public string Date { get; init; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;
}

[DebuggerDisplay("Date={Date}, Name={Name}")]
public record CreateSpecialRequest
{
    [JsonPropertyName("date")]
    public string? Date { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }
}

[DebuggerDisplay("Date={Date}, Name={Name}")]
public record CreateSpecialResponse
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("date")]
    public string Date { get; init; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;
}

[DebuggerDisplay("Date={Date}, Name={Name}")]
public record UpdateSpecialRequest
{
    [JsonPropertyName("date")]
    public string? Date { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }
}

[DebuggerDisplay("Date={Date}, Name={Name}")]
public record UpdateSpecialResponse
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("date")]
    public string Date { get; init; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;
}

public record DeleteSpecialResponse
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("date")]
    public string Date { get; init; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;
}