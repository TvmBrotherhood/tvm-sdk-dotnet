namespace TvmSdk.AckiNacki.Modules.Crypto;

public record ParamsOfNaclSignOpen
{
    /// <remarks>
    /// Encoded with <c>base64</c>.
    /// </remarks>
    [JsonPropertyName("signed")]
    public string Signed { get; init; }

    /// <summary>
    /// Signer's public key - unprefixed 0-padded to 64 symbols hex string.
    /// </summary>
    [JsonPropertyName("public")]
    public string Public { get; init; }
}