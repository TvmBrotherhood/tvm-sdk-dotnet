namespace TvmSdk.Everscale.Modules.Crypto;

public record ParamsOfConvertPublicKeyToTonSafeFormat
{
    /// <summary>
    /// Public key - 64 symbols hex string.
    /// </summary>
    [JsonPropertyName("public_key")]
    public string PublicKey { get; init; }
}