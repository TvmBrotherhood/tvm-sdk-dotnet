namespace TvmSdk.Ton.Modules.Crypto;

public record NaclSecretBoxParamsEB
{
    /// <summary>
    /// Secret key - unprefixed 0-padded to 64 symbols hex string.
    /// </summary>
    [JsonPropertyName("key")]
    public string Key { get; init; }

    /// <summary>
    /// Nonce in <c>hex</c>.
    /// </summary>
    [JsonPropertyName("nonce")]
    public string Nonce { get; init; }
}