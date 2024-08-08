namespace TvmSdk.Everscale.Modules.Boc;

public record ParamsOfBocCacheSet
{
    /// <summary>
    /// BOC encoded as base64 or BOC reference.
    /// </summary>
    [JsonPropertyName("boc")]
    public string Boc { get; init; }

    /// <summary>
    /// Cache type.
    /// </summary>
    [JsonPropertyName("cache_type")]
    public BocCacheType CacheType { get; init; }
}