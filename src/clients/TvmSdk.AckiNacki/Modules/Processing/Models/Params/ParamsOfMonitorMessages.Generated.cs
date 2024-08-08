namespace TvmSdk.AckiNacki.Modules.Processing;

public record ParamsOfMonitorMessages
{
    /// <summary>
    /// Name of the monitoring queue.
    /// </summary>
    [JsonPropertyName("queue")]
    public string Queue { get; init; }

    /// <summary>
    /// Messages to start monitoring for.
    /// </summary>
    [JsonPropertyName("messages")]
    public MessageMonitoringParams[] Messages { get; init; }
}