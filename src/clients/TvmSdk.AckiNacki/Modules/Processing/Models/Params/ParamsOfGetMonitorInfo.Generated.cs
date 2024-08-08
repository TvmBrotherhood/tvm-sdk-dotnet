namespace TvmSdk.AckiNacki.Modules.Processing;

public record ParamsOfGetMonitorInfo
{
    /// <summary>
    /// Name of the monitoring queue.
    /// </summary>
    [JsonPropertyName("queue")]
    public string Queue { get; init; }
}