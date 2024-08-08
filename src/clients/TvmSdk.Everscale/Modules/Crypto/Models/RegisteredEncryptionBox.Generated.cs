namespace TvmSdk.Everscale.Modules.Crypto;

public record RegisteredEncryptionBox
{
    /// <summary>
    /// Handle of the encryption box.
    /// </summary>
    [JsonPropertyName("handle")]
    public uint Handle { get; init; }
}