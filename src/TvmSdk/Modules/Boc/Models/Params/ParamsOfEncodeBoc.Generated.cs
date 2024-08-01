namespace TvmSdk.Modules.Boc;

public record ParamsOfEncodeBoc
{
    /// <summary>
    /// Cell builder operations.
    /// </summary>
    [JsonPropertyName("builder")]
    public BuilderOp[] Builder { get; init; }

    /// <summary>
    /// Cache type to put the result.<para/>
    /// The BOC itself returned if no cache type provided.
    /// </summary>
    [JsonPropertyName("boc_cache")]
    public BocCacheType? BocCache { get; init; }
}