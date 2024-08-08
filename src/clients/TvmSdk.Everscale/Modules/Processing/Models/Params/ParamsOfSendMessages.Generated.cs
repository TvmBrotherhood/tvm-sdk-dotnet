namespace TvmSdk.Everscale.Modules.Processing;

public record ParamsOfSendMessages
{
    /// <summary>
    /// Messages that must be sent to the blockchain.
    /// </summary>
    [JsonPropertyName("messages")]
    public MessageSendingParams[] Messages { get; init; }

    /// <summary>
    /// Optional message monitor queue that starts monitoring for the processing results for sent messages.
    /// </summary>
    [JsonPropertyName("monitor_queue")]
    public string? MonitorQueue { get; init; }
}