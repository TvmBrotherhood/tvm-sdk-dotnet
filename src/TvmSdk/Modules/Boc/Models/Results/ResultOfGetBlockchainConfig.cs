namespace TvmSdk.Modules.Boc;

public record ResultOfGetBlockchainConfig
{
    /// <summary>
    /// Blockchain config BOC encoded as base64.
    /// </summary>
    [JsonPropertyName("config_boc")]
    public string ConfigBoc { get; init; }
}