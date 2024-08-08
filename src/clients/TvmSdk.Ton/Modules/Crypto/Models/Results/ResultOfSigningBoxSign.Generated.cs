namespace TvmSdk.Ton.Modules.Crypto;

public record ResultOfSigningBoxSign
{
    /// <remarks>
    /// Encoded with <c>hex</c>.
    /// </remarks>
    [JsonPropertyName("signature")]
    public string Signature { get; init; }
}