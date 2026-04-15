using System.Diagnostics;

namespace ChurchLiveScheduler.sdk.Models;

public sealed record SpecialDto
{
    public required int Id { get; init; }
    public required DateTime DateTime { get; init; }
    public required string Name { get; init; }
}

[DebuggerDisplay("DateTime={DateTime}, Name={Name}")]
public sealed record CreateSpecialRequest
{
    public required DateTime DateTime { get; init; }
    public required string Name { get; init; }
}

[DebuggerDisplay("DateTime={DateTime}, Name={Name}")]
public sealed record CreateSpecialResponse
{
    public required int Id { get; init; }
    public required DateTime DateTime { get; init; }
    public required string Name { get; init; }
}

[DebuggerDisplay("DateTime={DateTime}, Name={Name}")]
public sealed record UpdateSpecialRequest
{
    public required DateTime DateTime { get; init; }
    public required string Name { get; init; }
}

[DebuggerDisplay("DateTime={DateTime}, Name={Name}")]
public sealed record UpdateSpecialResponse
{
    public required int Id { get; init; }
    public required DateTime DateTime { get; init; }
    public required string Name { get; init; }
}

public sealed record DeleteSpecialResponse
{
    public required int Id { get; init; }
    public required DateTime DateTime { get; init; }
    public required string Name { get; init; }
}