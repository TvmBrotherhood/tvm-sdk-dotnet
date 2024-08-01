namespace TvmSdk.Modules.Crypto;

public record ResultOfGetCryptoBoxInfo
{
    /// <summary>
    /// Secret (seed phrase) encrypted with salt and password.
    /// </summary>
    [JsonPropertyName("encrypted_secret")]
    public string EncryptedSecret { get; init; }
}