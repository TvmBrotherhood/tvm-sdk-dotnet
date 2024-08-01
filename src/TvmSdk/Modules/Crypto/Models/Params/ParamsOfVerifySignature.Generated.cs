namespace TvmSdk.Modules.Crypto;

public record ParamsOfVerifySignature
{
    /// <summary>
    /// Signed data that must be verified encoded in <c>base64</c>.
    /// </summary>
    [JsonPropertyName("signed")]
    public string Signed { get; init; }

    /// <summary>
    /// Signer's public key - 64 symbols hex string.
    /// </summary>
    [JsonPropertyName("public")]
    public string Public { get; init; }
}