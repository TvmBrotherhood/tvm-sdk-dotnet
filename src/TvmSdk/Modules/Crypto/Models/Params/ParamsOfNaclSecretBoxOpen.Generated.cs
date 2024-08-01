namespace TvmSdk.Modules.Crypto;

public record ParamsOfNaclSecretBoxOpen
{
    /// <remarks>
    /// Encoded with <c>base64</c>.
    /// </remarks>
    [JsonPropertyName("encrypted")]
    public string Encrypted { get; init; }

    /// <summary>
    /// Nonce in <c>hex</c>.
    /// </summary>
    [JsonPropertyName("nonce")]
    public string Nonce { get; init; }

    /// <summary>
    /// Secret key - unprefixed 0-padded to 64 symbols hex string.
    /// </summary>
    [JsonPropertyName("key")]
    public string Key { get; init; }
}