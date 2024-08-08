namespace TvmSdk.Ton.Modules.Crypto;

public record ResultOfConvertPublicKeyToTonSafeFormat
{
    /// <summary>
    /// Public key represented in TON safe format.
    /// </summary>
    [JsonPropertyName("ton_public_key")]
    public string TonPublicKey { get; init; }
}