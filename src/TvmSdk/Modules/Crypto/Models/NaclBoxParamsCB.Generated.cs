namespace TvmSdk.Modules.Crypto;

public record NaclBoxParamsCB
{
    /// <remarks>
    /// Must be encoded with <c>hex</c>.
    /// </remarks>
    [JsonPropertyName("their_public")]
    public string TheirPublic { get; init; }

    /// <remarks>
    /// Must be encoded with <c>hex</c>.
    /// </remarks>
    [JsonPropertyName("nonce")]
    public string Nonce { get; init; }
}