namespace TvmSdk.Ton.Modules.Boc;

public record ParamsOfBocCacheUnpin
{
    /// <summary>
    /// Pinned name.
    /// </summary>
    [JsonPropertyName("pin")]
    public string Pin { get; init; }

    /// <remarks>
    /// If it is provided then only referenced BOC is unpinned.
    /// </remarks>
    [JsonPropertyName("boc_ref")]
    public string? BocRef { get; init; }
}