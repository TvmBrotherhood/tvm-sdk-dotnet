namespace TvmSdk.Ton.Modules.Boc;

public record ParamsOfBocCacheGet
{
    /// <summary>
    /// Reference to the cached BOC.
    /// </summary>
    [JsonPropertyName("boc_ref")]
    public string BocRef { get; init; }
}