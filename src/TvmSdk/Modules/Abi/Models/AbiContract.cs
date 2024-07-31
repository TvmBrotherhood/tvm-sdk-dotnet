namespace TvmSdk.Modules.Abi;

public record AbiContract
{
    [JsonPropertyName("ABI version")]
    public uint? ABIversion { get; init; }

    [JsonPropertyName("abi_version")]
    public uint? AbiVersion { get; init; }

    [JsonPropertyName("version")]
    public string? Version { get; init; }

    [JsonPropertyName("header")]
    public string[]? Header { get; init; }

    [JsonPropertyName("functions")]
    public AbiFunction[]? Functions { get; init; }

    [JsonPropertyName("events")]
    public AbiEvent[]? Events { get; init; }

    [JsonPropertyName("data")]
    public AbiData[]? Data { get; init; }

    [JsonPropertyName("fields")]
    public AbiParam[]? Fields { get; init; }
}