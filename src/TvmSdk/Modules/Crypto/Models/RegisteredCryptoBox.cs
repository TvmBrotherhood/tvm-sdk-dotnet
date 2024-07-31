namespace TvmSdk.Modules.Crypto;

public record RegisteredCryptoBox
{
    [JsonPropertyName("handle")]
    public uint Handle { get; init; }
}