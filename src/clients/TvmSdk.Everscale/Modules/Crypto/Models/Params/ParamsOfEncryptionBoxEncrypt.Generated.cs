namespace TvmSdk.Everscale.Modules.Crypto;

public record ParamsOfEncryptionBoxEncrypt
{
    /// <summary>
    /// Encryption box handle.
    /// </summary>
    [JsonPropertyName("encryption_box")]
    public uint EncryptionBox { get; init; }

    /// <summary>
    /// Data to be encrypted, encoded in Base64.
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; init; }
}