namespace TvmSdk.Everscale.Modules.Abi;

public record AbiFunction
{
    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("inputs")]
    public AbiParam[] Inputs { get; init; }

    [JsonPropertyName("outputs")]
    public AbiParam[] Outputs { get; init; }

    [JsonPropertyName("id")]
    public string? Id { get; init; }
}