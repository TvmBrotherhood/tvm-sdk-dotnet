namespace TvmSdk.Modules.Boc;

public record ParamsOfGetCodeSalt
{
    /// <summary>
    /// Contract code BOC encoded as base64 or code BOC handle.
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; init; }

    /// <summary>
    /// Cache type to put the result.<para/>
    /// The BOC itself returned if no cache type provided.
    /// </summary>
    [JsonPropertyName("boc_cache")]
    public BocCacheType? BocCache { get; init; }
}