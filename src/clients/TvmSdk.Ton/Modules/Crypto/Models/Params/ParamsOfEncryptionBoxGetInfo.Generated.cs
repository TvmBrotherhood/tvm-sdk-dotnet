namespace TvmSdk.Ton.Modules.Crypto;

public record ParamsOfEncryptionBoxGetInfo
{
    /// <summary>
    /// Encryption box handle.
    /// </summary>
    [JsonPropertyName("encryption_box")]
    public uint EncryptionBox { get; init; }
}