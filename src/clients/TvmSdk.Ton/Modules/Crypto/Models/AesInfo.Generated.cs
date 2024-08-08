namespace TvmSdk.Ton.Modules.Crypto;

public record AesInfo
{
    [JsonPropertyName("mode")]
    public CipherMode Mode { get; init; }

    [JsonPropertyName("iv")]
    public string? Iv { get; init; }
}