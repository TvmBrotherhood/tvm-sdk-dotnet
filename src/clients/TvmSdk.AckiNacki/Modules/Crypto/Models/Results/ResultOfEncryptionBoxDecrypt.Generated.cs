namespace TvmSdk.AckiNacki.Modules.Crypto;

public record ResultOfEncryptionBoxDecrypt
{
    /// <summary>
    /// Decrypted data, encoded in Base64.
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; init; }
}