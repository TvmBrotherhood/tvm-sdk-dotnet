namespace TvmSdk.AckiNacki.Modules.Crypto;

public record ParamsOfGenerateRandomBytes
{
    /// <summary>
    /// Size of random byte array.
    /// </summary>
    [JsonPropertyName("length")]
    public uint Length { get; init; }
}