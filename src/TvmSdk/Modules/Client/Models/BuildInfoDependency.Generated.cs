namespace TvmSdk.Modules.Client;

public record BuildInfoDependency
{
    /// <remarks>
    /// Usually it is a crate name.
    /// </remarks>
    [JsonPropertyName("name")]
    public string Name { get; init; }

    /// <summary>
    /// Git commit hash of the related repository.
    /// </summary>
    [JsonPropertyName("git_commit")]
    public string GitCommit { get; init; }
}