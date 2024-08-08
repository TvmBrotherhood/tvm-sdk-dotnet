namespace TvmSdk.AckiNacki.Modules.Net;

public record TransactionNode
{
    /// <summary>
    /// Transaction id.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; init; }

    /// <summary>
    /// In message id.
    /// </summary>
    [JsonPropertyName("in_msg")]
    public string InMsg { get; init; }

    /// <summary>
    /// Out message ids.
    /// </summary>
    [JsonPropertyName("out_msgs")]
    public string[] OutMsgs { get; init; }

    /// <summary>
    /// Account address.
    /// </summary>
    [JsonPropertyName("account_addr")]
    public string AccountAddr { get; init; }

    /// <summary>
    /// Transactions total fees.
    /// </summary>
    [JsonPropertyName("total_fees")]
    public string TotalFees { get; init; }

    /// <summary>
    /// Aborted flag.
    /// </summary>
    [JsonPropertyName("aborted")]
    public bool Aborted { get; init; }

    /// <summary>
    /// Compute phase exit code.
    /// </summary>
    [JsonPropertyName("exit_code")]
    public uint? ExitCode { get; init; }
}