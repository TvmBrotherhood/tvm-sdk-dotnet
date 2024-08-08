namespace TvmSdk.AckiNacki.Modules.Boc;

public record ParamsOfDecodeStateInit
{
    /// <summary>
    /// Contract StateInit image BOC encoded as base64 or BOC handle.
    /// </summary>
    [JsonPropertyName("state_init")]
    public string StateInit { get; init; }

    /// <summary>
    /// Cache type to put the result.<para/>
    /// The BOC itself returned if no cache type provided.
    /// </summary>
    [JsonPropertyName("boc_cache")]
    public BocCacheType? BocCache { get; init; }
}