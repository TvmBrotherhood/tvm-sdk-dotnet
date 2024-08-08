namespace TvmSdk.Everscale.Modules.Abi;

public record ParamsOfUpdateInitialData
{
    /// <summary>
    /// Contract ABI.
    /// </summary>
    [JsonPropertyName("abi")]
    public Abi Abi { get; init; }

    /// <summary>
    /// Data BOC or BOC handle.
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; init; }

    /// <remarks>
    /// <c>abi</c> parameter should be provided to set initial data.
    /// </remarks>
    [JsonPropertyName("initial_data")]
    public JsonElement? InitialData { get; init; }

    /// <summary>
    /// Initial account owner's public key to set into account data.
    /// </summary>
    [JsonPropertyName("initial_pubkey")]
    public string? InitialPubkey { get; init; }

    /// <summary>
    /// Cache type to put the result.<para/>
    /// The BOC itself returned if no cache type provided.
    /// </summary>
    [JsonPropertyName("boc_cache")]
    public Boc.BocCacheType? BocCache { get; init; }
}