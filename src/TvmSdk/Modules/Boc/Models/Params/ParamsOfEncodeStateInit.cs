namespace TvmSdk.Modules.Boc;

public record ParamsOfEncodeStateInit
{
    /// <summary>
    /// Contract code BOC encoded as base64 or BOC handle.
    /// </summary>
    [JsonPropertyName("code")]
    public string? Code { get; init; }

    /// <summary>
    /// Contract data BOC encoded as base64 or BOC handle.
    /// </summary>
    [JsonPropertyName("data")]
    public string? Data { get; init; }

    /// <summary>
    /// Contract library BOC encoded as base64 or BOC handle.
    /// </summary>
    [JsonPropertyName("library")]
    public string? Library { get; init; }

    /// <remarks>
    /// Specifies the contract ability to handle tick transactions.
    /// </remarks>
    [JsonPropertyName("tick")]
    public bool? Tick { get; init; }

    /// <remarks>
    /// Specifies the contract ability to handle tock transactions.
    /// </remarks>
    [JsonPropertyName("tock")]
    public bool? Tock { get; init; }

    /// <summary>
    /// Is present and non-zero only in instances of large smart contracts.
    /// </summary>
    [JsonPropertyName("split_depth")]
    public uint? SplitDepth { get; init; }

    /// <summary>
    /// Cache type to put the result.<para/>
    /// The BOC itself returned if no cache type provided.
    /// </summary>
    [JsonPropertyName("boc_cache")]
    public BocCacheType? BocCache { get; init; }
}