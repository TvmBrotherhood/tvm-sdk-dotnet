namespace TvmSdk.AckiNacki.Modules.Net;

public record ResultOfGetSignatureId
{
    /// <summary>
    /// Signature ID for configured network if it should be used in messages signature.
    /// </summary>
    [JsonPropertyName("signature_id")]
    public int? SignatureId { get; init; }
}