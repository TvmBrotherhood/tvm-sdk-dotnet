namespace TvmSdk.Everscale.Modules.Client;

public record BocConfig
{
    /// <remarks>
    /// Default is 10 MB.
    /// </remarks>
    [JsonPropertyName("cache_max_size")]
    public uint? CacheMaxSize { get; init; }
}