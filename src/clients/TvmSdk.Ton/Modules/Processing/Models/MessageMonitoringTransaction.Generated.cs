namespace TvmSdk.Ton.Modules.Processing;

public record MessageMonitoringTransaction
{
    /// <summary>
    /// Hash of the transaction.<para/>
    /// Present if transaction was included into the blocks.<para/>
    /// When then transaction was emulated this field will be missing.
    /// </summary>
    [JsonPropertyName("hash")]
    public string? Hash { get; init; }

    /// <summary>
    /// Aborted field of the transaction.
    /// </summary>
    [JsonPropertyName("aborted")]
    public bool Aborted { get; init; }

    /// <summary>
    /// Optional information about the compute phase of the transaction.
    /// </summary>
    [JsonPropertyName("compute")]
    public MessageMonitoringTransactionCompute? Compute { get; init; }
}