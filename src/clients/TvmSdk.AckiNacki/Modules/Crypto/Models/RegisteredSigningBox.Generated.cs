namespace TvmSdk.AckiNacki.Modules.Crypto;

public record RegisteredSigningBox
{
    /// <summary>
    /// Handle of the signing box.
    /// </summary>
    [JsonPropertyName("handle")]
    public uint Handle { get; init; }
}