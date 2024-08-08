namespace TvmSdk.AckiNacki.Modules.Crypto;

public record ParamsOfCreateEncryptionBox
{
    /// <summary>
    /// Encryption algorithm specifier including cipher parameters (key, IV, etc).
    /// </summary>
    [JsonPropertyName("algorithm")]
    public EncryptionAlgorithm Algorithm { get; init; }
}