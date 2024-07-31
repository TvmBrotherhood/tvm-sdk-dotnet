namespace TvmSdk.Modules.Crypto;

public record NaclSecretBoxParamsCB
{
    /// <summary>
    /// Nonce in <c>hex</c>.
    /// </summary>
    [JsonPropertyName("nonce")]
    public string Nonce { get; init; }
}