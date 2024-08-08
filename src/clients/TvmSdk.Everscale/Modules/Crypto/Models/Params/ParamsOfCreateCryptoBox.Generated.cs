namespace TvmSdk.Everscale.Modules.Crypto;

public record ParamsOfCreateCryptoBox
{
    /// <summary>
    /// Salt used for secret encryption.<para/>
    /// For example, a mobile device can use device ID as salt.
    /// </summary>
    [JsonPropertyName("secret_encryption_salt")]
    public string SecretEncryptionSalt { get; init; }

    /// <summary>
    /// Cryptobox secret.
    /// </summary>
    [JsonPropertyName("secret")]
    public CryptoBoxSecret Secret { get; init; }
}