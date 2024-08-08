namespace TvmSdk.AckiNacki.Modules.Crypto;

public record ResultOfHDKeySecretFromXPrv
{
    /// <summary>
    /// Private key - 64 symbols hex string.
    /// </summary>
    [JsonPropertyName("secret")]
    public string Secret { get; init; }
}