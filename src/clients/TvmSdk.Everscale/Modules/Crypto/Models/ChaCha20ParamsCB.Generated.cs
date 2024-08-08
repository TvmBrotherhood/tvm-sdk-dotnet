namespace TvmSdk.Everscale.Modules.Crypto;

public record ChaCha20ParamsCB
{
    /// <remarks>
    /// Must be encoded with <c>hex</c>.
    /// </remarks>
    [JsonPropertyName("nonce")]
    public string Nonce { get; init; }
}