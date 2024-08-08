namespace TvmSdk.Ton.Modules.Crypto;

public record ResultOfFactorize
{
    /// <summary>
    /// Two factors of composite or empty if composite can't be factorized.
    /// </summary>
    [JsonPropertyName("factors")]
    public string[] Factors { get; init; }
}