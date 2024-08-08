namespace TvmSdk.Ton.Modules.Crypto;

public record ResultOfHDKeyPublicFromXPrv
{
    /// <summary>
    /// Public key - 64 symbols hex string.
    /// </summary>
    [JsonPropertyName("public")]
    public string Public { get; init; }
}