namespace TvmSdk.Everscale.Modules.Boc;

public record ResultOfGetCompilerVersion
{
    /// <summary>
    /// Compiler version, for example 'sol 0.49.0'.
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; init; }
}