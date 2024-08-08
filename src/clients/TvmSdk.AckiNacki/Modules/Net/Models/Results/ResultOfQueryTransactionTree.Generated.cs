namespace TvmSdk.AckiNacki.Modules.Net;

public record ResultOfQueryTransactionTree
{
    /// <summary>
    /// Messages.
    /// </summary>
    [JsonPropertyName("messages")]
    public MessageNode[] Messages { get; init; }

    /// <summary>
    /// Transactions.
    /// </summary>
    [JsonPropertyName("transactions")]
    public TransactionNode[] Transactions { get; init; }
}