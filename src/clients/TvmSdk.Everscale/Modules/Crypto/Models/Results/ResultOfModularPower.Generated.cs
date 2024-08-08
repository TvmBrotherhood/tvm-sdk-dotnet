namespace TvmSdk.Everscale.Modules.Crypto;

public record ResultOfModularPower
{
    /// <summary>
    /// Result of modular exponentiation.
    /// </summary>
    [JsonPropertyName("modular_power")]
    public string ModularPower { get; init; }
}