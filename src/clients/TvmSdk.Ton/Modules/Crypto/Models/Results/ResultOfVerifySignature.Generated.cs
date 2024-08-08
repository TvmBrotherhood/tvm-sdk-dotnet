namespace TvmSdk.Ton.Modules.Crypto;

public record ResultOfVerifySignature
{
    /// <summary>
    /// Unsigned data encoded in <c>base64</c>.
    /// </summary>
    [JsonPropertyName("unsigned")]
    public string Unsigned { get; init; }
}