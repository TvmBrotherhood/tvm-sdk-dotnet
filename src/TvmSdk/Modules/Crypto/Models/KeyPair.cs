namespace TvmSdk.Modules.Crypto;

public record KeyPair
{
    /// <summary>
    /// Public key - 64 symbols hex string.
    /// </summary>
    [JsonPropertyName("public")]
    public string Public { get; init; }

    /// <summary>
    /// Private key - u64 symbols hex string.
    /// </summary>
    [JsonPropertyName("secret")]
    public string Secret { get; init; }
}