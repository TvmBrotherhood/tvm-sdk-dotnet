namespace TvmSdk.Modules.Boc;

public record ParamsOfGetBocDepth
{
    /// <summary>
    /// BOC encoded as base64 or BOC handle.
    /// </summary>
    [JsonPropertyName("boc")]
    public string Boc { get; init; }
}