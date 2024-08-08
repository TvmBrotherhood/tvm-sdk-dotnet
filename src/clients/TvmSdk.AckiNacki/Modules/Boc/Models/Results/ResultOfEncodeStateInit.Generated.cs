namespace TvmSdk.AckiNacki.Modules.Boc;

public record ResultOfEncodeStateInit
{
    /// <summary>
    /// Contract StateInit image BOC encoded as base64 or BOC handle of boc_cache parameter was specified.
    /// </summary>
    [JsonPropertyName("state_init")]
    public string StateInit { get; init; }
}