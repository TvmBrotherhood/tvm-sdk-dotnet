namespace TvmSdk.Everscale.Modules.Crypto;

public record ParamsOfChaCha20
{
    /// <remarks>
    /// Must be encoded with <c>base64</c>.
    /// </remarks>
    [JsonPropertyName("data")]
    public string Data { get; init; }

    /// <remarks>
    /// Must be encoded with <c>hex</c>.
    /// </remarks>
    [JsonPropertyName("key")]
    public string Key { get; init; }

    /// <remarks>
    /// Must be encoded with <c>hex</c>.
    /// </remarks>
    [JsonPropertyName("nonce")]
    public string Nonce { get; init; }
}