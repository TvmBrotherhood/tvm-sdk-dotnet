namespace TvmSdk.Ton.Modules.Processing;

public record MessageMonitoringResult
{
    /// <summary>
    /// Hash of the message.
    /// </summary>
    [JsonPropertyName("hash")]
    public string Hash { get; init; }

    /// <summary>
    /// Processing status.
    /// </summary>
    [JsonPropertyName("status")]
    public MessageMonitoringStatus Status { get; init; }

    /// <summary>
    /// In case of <c>Finalized</c> the transaction is extracted from the block.<para/>
    /// In case of <c>Timeout</c> the transaction is emulated using the last known account state.
    /// </summary>
    [JsonPropertyName("transaction")]
    public MessageMonitoringTransaction? Transaction { get; init; }

    /// <summary>
    /// In case of <c>Timeout</c> contains possible error reason.
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; init; }

    /// <summary>
    /// User defined data related to this message.<para/>
    /// This is the same value as passed before with <c>MessageMonitoringParams</c> or <c>SendMessageParams</c>.
    /// </summary>
    [JsonPropertyName("user_data")]
    public JsonElement? UserData { get; init; }
}