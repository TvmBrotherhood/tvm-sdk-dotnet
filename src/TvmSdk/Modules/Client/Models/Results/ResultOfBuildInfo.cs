namespace TvmSdk.Modules.Client;

public record ResultOfBuildInfo
{
    /// <summary>
    /// Build number assigned to this build by the CI.
    /// </summary>
    [JsonPropertyName("build_number")]
    public uint BuildNumber { get; init; }

    /// <summary>
    /// Fingerprint of the most important dependencies.
    /// </summary>
    [JsonPropertyName("dependencies")]
    public BuildInfoDependency[] Dependencies { get; init; }
}