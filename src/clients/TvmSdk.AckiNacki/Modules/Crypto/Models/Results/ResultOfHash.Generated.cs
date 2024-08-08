namespace TvmSdk.AckiNacki.Modules.Crypto;

public record ResultOfHash
{
    /// <remarks>
    /// Encoded with 'hex'.
    /// </remarks>
    [JsonPropertyName("hash")]
    public string Hash { get; init; }
}