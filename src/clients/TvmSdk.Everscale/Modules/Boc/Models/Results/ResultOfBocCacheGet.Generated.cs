namespace TvmSdk.Everscale.Modules.Boc;

public record ResultOfBocCacheGet
{
    /// <summary>
    /// BOC encoded as base64.
    /// </summary>
    [JsonPropertyName("boc")]
    public string? Boc { get; init; }
}