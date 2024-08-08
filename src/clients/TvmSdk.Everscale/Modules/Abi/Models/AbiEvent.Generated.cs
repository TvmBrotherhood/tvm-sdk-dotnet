namespace TvmSdk.Everscale.Modules.Abi;

public record AbiEvent
{
    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("inputs")]
    public AbiParam[] Inputs { get; init; }

    [JsonPropertyName("id")]
    public string? Id { get; init; }
}