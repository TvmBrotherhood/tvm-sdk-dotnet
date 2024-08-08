namespace TvmSdk.AckiNacki.Modules.Abi;

public record ParamsOfAbiEncodeBoc
{
    /// <summary>
    /// Parameters to encode into BOC.
    /// </summary>
    [JsonPropertyName("params")]
    public AbiParam[] Params { get; init; }

    /// <summary>
    /// Parameters and values as a JSON structure.
    /// </summary>
    [JsonPropertyName("data")]
    public JsonElement Data { get; init; }

    /// <remarks>
    /// The BOC itself returned if no cache type provided.
    /// </remarks>
    [JsonPropertyName("boc_cache")]
    public Boc.BocCacheType? BocCache { get; init; }
}