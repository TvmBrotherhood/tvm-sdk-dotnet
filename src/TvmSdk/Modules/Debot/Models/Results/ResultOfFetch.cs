namespace TvmSdk.Modules.Debot;

/// <summary>
/// <a href="UNSTABLE.md">UNSTABLE</a><a href="DEPRECATED.md">DEPRECATED</a>.
/// </summary>
public record ResultOfFetch
{
    /// <summary>
    /// Debot metadata.
    /// </summary>
    [JsonPropertyName("info")]
    public DebotInfo Info { get; init; }
}