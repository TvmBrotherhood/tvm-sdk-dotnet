namespace TvmSdk.Ton.Modules.Boc;

public record ParamsOfDecodeTvc
{
    /// <summary>
    /// Contract TVC BOC encoded as base64 or BOC handle.
    /// </summary>
    [JsonPropertyName("tvc")]
    public string Tvc { get; init; }
}