namespace TvmSdk.Everscale.Modules.Crypto;

public record ParamsOfNaclBoxOpen
{
    /// <remarks>
    /// Encoded with <c>base64</c>.
    /// </remarks>
    [JsonPropertyName("encrypted")]
    public string Encrypted { get; init; }

    /// <summary>
    /// Nonce.
    /// </summary>
    [JsonPropertyName("nonce")]
    public string Nonce { get; init; }

    /// <summary>
    /// Sender's public key - unprefixed 0-padded to 64 symbols hex string.
    /// </summary>
    [JsonPropertyName("their_public")]
    public string TheirPublic { get; init; }

    /// <summary>
    /// Receiver's private key - unprefixed 0-padded to 64 symbols hex string.
    /// </summary>
    [JsonPropertyName("secret")]
    public string Secret { get; init; }
}