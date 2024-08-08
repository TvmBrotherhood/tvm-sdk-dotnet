namespace TvmSdk.Ton.Modules.Boc;

public record ParamsOfGetBocHash
{
    /// <summary>
    /// BOC encoded as base64 or BOC handle.
    /// </summary>
    [JsonPropertyName("boc")]
    public string Boc { get; init; }
}