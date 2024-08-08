namespace TvmSdk.Ton.Modules.Crypto;

public record ParamsOfFactorize
{
    /// <summary>
    /// Hexadecimal representation of u64 composite number.
    /// </summary>
    [JsonPropertyName("composite")]
    public string Composite { get; init; }
}