namespace TvmSdk.Ton.Modules.Abi;

public record AbiData
{
    [JsonPropertyName("key")]
    public uint Key { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("type")]
    public string Type { get; init; }

    [JsonPropertyName("components")]
    public AbiParam[]? Components { get; init; }
}