namespace TvmSdk.Modules.Crypto;

public record ParamsOfEncryptionBoxDecrypt
{
    /// <summary>
    /// Encryption box handle.
    /// </summary>
    [JsonPropertyName("encryption_box")]
    public uint EncryptionBox { get; init; }

    /// <summary>
    /// Data to be decrypted, encoded in Base64.
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; init; }
}