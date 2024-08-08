namespace TvmSdk.Everscale.Modules.Crypto;

public record ParamsOfNaclBoxKeyPairFromSecret
{
    /// <summary>
    /// Secret key - unprefixed 0-padded to 64 symbols hex string.
    /// </summary>
    [JsonPropertyName("secret")]
    public string Secret { get; init; }
}