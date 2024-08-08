namespace TvmSdk.Ton.Modules.Crypto;

public record ResultOfSign
{
    /// <summary>
    /// Signed data combined with signature encoded in <c>base64</c>.
    /// </summary>
    [JsonPropertyName("signed")]
    public string Signed { get; init; }

    /// <summary>
    /// Signature encoded in <c>hex</c>.
    /// </summary>
    [JsonPropertyName("signature")]
    public string Signature { get; init; }
}