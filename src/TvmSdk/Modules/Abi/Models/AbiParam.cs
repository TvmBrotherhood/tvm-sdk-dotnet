namespace TvmSdk.Modules.Abi;

public record AbiParam
{
    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("type")]
    public string Type { get; init; }

    [JsonPropertyName("components")]
    public AbiParam[]? Components { get; init; }

    [JsonPropertyName("init")]
    public bool? Init { get; init; }
}