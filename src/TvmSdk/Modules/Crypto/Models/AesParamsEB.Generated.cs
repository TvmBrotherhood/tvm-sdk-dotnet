namespace TvmSdk.Modules.Crypto;

public record AesParamsEB
{
    [JsonPropertyName("mode")]
    public CipherMode Mode { get; init; }

    [JsonPropertyName("key")]
    public string Key { get; init; }

    [JsonPropertyName("iv")]
    public string? Iv { get; init; }
}