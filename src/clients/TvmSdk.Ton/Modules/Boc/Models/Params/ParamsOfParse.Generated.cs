namespace TvmSdk.Ton.Modules.Boc;

public record ParamsOfParse
{
    /// <summary>
    /// BOC encoded as base64.
    /// </summary>
    [JsonPropertyName("boc")]
    public string Boc { get; init; }
}