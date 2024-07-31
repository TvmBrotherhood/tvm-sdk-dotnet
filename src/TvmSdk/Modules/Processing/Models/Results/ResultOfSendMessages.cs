namespace TvmSdk.Modules.Processing;

public record ResultOfSendMessages
{
    /// <summary>
    /// Messages that was sent to the blockchain for execution.
    /// </summary>
    [JsonPropertyName("messages")]
    public MessageMonitoringParams[] Messages { get; init; }
}