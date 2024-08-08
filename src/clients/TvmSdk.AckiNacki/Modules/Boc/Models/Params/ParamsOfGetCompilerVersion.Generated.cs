namespace TvmSdk.AckiNacki.Modules.Boc;

public record ParamsOfGetCompilerVersion
{
    /// <summary>
    /// Contract code BOC encoded as base64 or code BOC handle.
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; init; }
}