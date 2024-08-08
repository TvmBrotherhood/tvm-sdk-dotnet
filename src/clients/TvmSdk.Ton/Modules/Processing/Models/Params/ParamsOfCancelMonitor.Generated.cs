namespace TvmSdk.Ton.Modules.Processing;

public record ParamsOfCancelMonitor
{
    /// <summary>
    /// Name of the monitoring queue.
    /// </summary>
    [JsonPropertyName("queue")]
    public string Queue { get; init; }
}