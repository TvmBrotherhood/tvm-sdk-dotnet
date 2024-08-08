namespace TvmSdk.Ton.Modules.Abi;

public record ResultOfDecodeAccountData
{
    /// <summary>
    /// Decoded data as a JSON structure.
    /// </summary>
    [JsonPropertyName("data")]
    public JsonElement Data { get; init; }
}