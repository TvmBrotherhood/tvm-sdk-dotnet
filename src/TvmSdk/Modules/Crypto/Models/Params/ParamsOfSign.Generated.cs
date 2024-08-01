namespace TvmSdk.Modules.Crypto;

public record ParamsOfSign
{
    /// <summary>
    /// Data that must be signed encoded in <c>base64</c>.
    /// </summary>
    [JsonPropertyName("unsigned")]
    public string Unsigned { get; init; }

    /// <summary>
    /// Sign keys.
    /// </summary>
    [JsonPropertyName("keys")]
    public KeyPair Keys { get; init; }
}