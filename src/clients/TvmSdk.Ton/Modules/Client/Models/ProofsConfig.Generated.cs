namespace TvmSdk.Ton.Modules.Client;

public record ProofsConfig
{
    /// <remarks>
    /// Default is <c>true</c>.<para/>
    /// If this value is set to <c>true</c>, downloaded proofs and master-chain BOCs are saved into the persistent local storage (e.g.<para/>
    /// File system for native environments or browser's IndexedDB for the web); otherwise all the data is cached only in memory in current client's context and will be lost after destruction of the client.
    /// </remarks>
    [JsonPropertyName("cache_in_local_storage")]
    public bool? CacheInLocalStorage { get; init; }
}