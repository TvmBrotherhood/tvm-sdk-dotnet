namespace TvmSdk.AckiNacki.Modules.Crypto;

public record ResultOfEncryptionBoxEncrypt
{
    /// <remarks>
    /// Padded to cipher block size.
    /// </remarks>
    [JsonPropertyName("data")]
    public string Data { get; init; }
}