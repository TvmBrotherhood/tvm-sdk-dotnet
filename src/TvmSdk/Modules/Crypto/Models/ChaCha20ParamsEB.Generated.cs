namespace TvmSdk.Modules.Crypto;

public record ChaCha20ParamsEB
{
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