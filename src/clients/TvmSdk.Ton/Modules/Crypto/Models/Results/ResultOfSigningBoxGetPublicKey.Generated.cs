namespace TvmSdk.Ton.Modules.Crypto;

public record ResultOfSigningBoxGetPublicKey
{
    /// <remarks>
    /// Encoded with hex.
    /// </remarks>
    [JsonPropertyName("pubkey")]
    public string Pubkey { get; init; }
}