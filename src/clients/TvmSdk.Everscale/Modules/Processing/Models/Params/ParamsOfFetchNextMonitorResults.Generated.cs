namespace TvmSdk.Everscale.Modules.Processing;

public record ParamsOfFetchNextMonitorResults
{
    /// <summary>
    /// Name of the monitoring queue.
    /// </summary>
    [JsonPropertyName("queue")]
    public string Queue { get; init; }

    /// <remarks>
    /// Default is <c>NO_WAIT</c>.
    /// </remarks>
    [JsonPropertyName("wait_mode")]
    public MonitorFetchWaitMode? WaitMode { get; init; }
}