namespace TvmSdk.Modules.Crypto;

public record ParamsOfModularPower
{
    /// <summary>
    /// <c>base</c> argument of calculation.
    /// </summary>
    [JsonPropertyName("base")]
    public string Base { get; init; }

    /// <summary>
    /// <c>exponent</c> argument of calculation.
    /// </summary>
    [JsonPropertyName("exponent")]
    public string Exponent { get; init; }

    /// <summary>
    /// <c>modulus</c> argument of calculation.
    /// </summary>
    [JsonPropertyName("modulus")]
    public string Modulus { get; init; }
}