namespace TvmSdk.Everscale.Modules.Processing;

public record MonitoringQueueInfo
{
    /// <summary>
    /// Count of the unresolved messages.
    /// </summary>
    [JsonPropertyName("unresolved")]
    public uint Unresolved { get; init; }

    /// <summary>
    /// Count of resolved results.
    /// </summary>
    [JsonPropertyName("resolved")]
    public uint Resolved { get; init; }
}