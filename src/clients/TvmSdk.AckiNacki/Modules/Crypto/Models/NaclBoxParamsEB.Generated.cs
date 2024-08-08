namespace TvmSdk.AckiNacki.Modules.Crypto;

public record NaclBoxParamsEB
{
    /// <remarks>
    /// Must be encoded with <c>hex</c>.
    /// </remarks>
    [JsonPropertyName("their_public")]
    public string TheirPublic { get; init; }

    /// <remarks>
    /// Must be encoded with <c>hex</c>.
    /// </remarks>
    [JsonPropertyName("secret")]
    public string Secret { get; init; }

    /// <remarks>
    /// Must be encoded with <c>hex</c>.
    /// </remarks>
    [JsonPropertyName("nonce")]
    public string Nonce { get; init; }
}