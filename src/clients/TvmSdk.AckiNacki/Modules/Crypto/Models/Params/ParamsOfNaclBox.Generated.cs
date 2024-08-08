namespace TvmSdk.AckiNacki.Modules.Crypto;

public record ParamsOfNaclBox
{
    /// <summary>
    /// Data that must be encrypted encoded in <c>base64</c>.
    /// </summary>
    [JsonPropertyName("decrypted")]
    public string Decrypted { get; init; }

    /// <summary>
    /// Nonce, encoded in <c>hex</c>.
    /// </summary>
    [JsonPropertyName("nonce")]
    public string Nonce { get; init; }

    /// <summary>
    /// Receiver's public key - unprefixed 0-padded to 64 symbols hex string.
    /// </summary>
    [JsonPropertyName("their_public")]
    public string TheirPublic { get; init; }

    /// <summary>
    /// Sender's private key - unprefixed 0-padded to 64 symbols hex string.
    /// </summary>
    [JsonPropertyName("secret")]
    public string Secret { get; init; }
}