namespace TvmSdk.AckiNacki.Modules.Crypto;

public record ResultOfEncryptionBoxGetInfo
{
    /// <summary>
    /// Encryption box information.
    /// </summary>
    [JsonPropertyName("info")]
    public EncryptionBoxInfo Info { get; init; }
}