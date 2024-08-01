namespace TvmSdk.Modules.Net;

public record ParamsOfQueryTransactionTree
{
    /// <summary>
    /// Input message id.
    /// </summary>
    [JsonPropertyName("in_msg")]
    public string InMsg { get; init; }

    /// <summary>
    /// List of contract ABIs that will be used to decode message bodies.<para/>
    /// Library will try to decode each returned message body using any ABI from the registry.
    /// </summary>
    [JsonPropertyName("abi_registry")]
    public Abi.Abi[]? AbiRegistry { get; init; }

    /// <remarks>
    /// If some of the following messages and transactions are missing yet The maximum waiting time is regulated by this option.<para/>
    /// Default value is 60000 (1 min).<para/>
    /// If <c>timeout</c> is set to 0 then function will wait infinitely until the whole transaction tree is executed.
    /// </remarks>
    [JsonPropertyName("timeout")]
    public uint? Timeout { get; init; }

    /// <remarks>
    /// If transaction tree contains more transaction then this parameter then only first <c>transaction_max_count</c> transaction are awaited and returned.<para/>
    /// Default value is 50.<para/>
    /// If <c>transaction_max_count</c> is set to 0 then no limitation on transaction count is used and all transaction are returned.
    /// </remarks>
    [JsonPropertyName("transaction_max_count")]
    public uint? TransactionMaxCount { get; init; }
}