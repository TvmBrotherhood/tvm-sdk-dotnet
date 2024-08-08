namespace TvmSdk.Everscale.Modules.Crypto;

public record ResultOfChaCha20
{
    /// <remarks>
    /// Encoded with <c>base64</c>.
    /// </remarks>
    [JsonPropertyName("data")]
    public string Data { get; init; }
}