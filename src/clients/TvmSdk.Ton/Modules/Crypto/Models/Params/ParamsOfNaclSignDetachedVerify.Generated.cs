namespace TvmSdk.Ton.Modules.Crypto;

public record ParamsOfNaclSignDetachedVerify
{
    /// <remarks>
    /// Encoded with <c>base64</c>.
    /// </remarks>
    [JsonPropertyName("unsigned")]
    public string Unsigned { get; init; }

    /// <remarks>
    /// Encoded with <c>hex</c>.
    /// </remarks>
    [JsonPropertyName("signature")]
    public string Signature { get; init; }

    /// <summary>
    /// Signer's public key - unprefixed 0-padded to 64 symbols hex string.
    /// </summary>
    [JsonPropertyName("public")]
    public string Public { get; init; }
}