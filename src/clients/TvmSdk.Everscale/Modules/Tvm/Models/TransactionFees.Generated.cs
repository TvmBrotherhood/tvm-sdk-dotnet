namespace TvmSdk.Everscale.Modules.Tvm;

public record TransactionFees
{
    /// <remarks>
    /// Contains the same data as ext_in_msg_fee field.
    /// </remarks>
    [JsonPropertyName("in_msg_fwd_fee")]
    public ulong InMsgFwdFee { get; init; }

    /// <summary>
    /// Fee for account storage.
    /// </summary>
    [JsonPropertyName("storage_fee")]
    public ulong StorageFee { get; init; }

    /// <summary>
    /// Fee for processing.
    /// </summary>
    [JsonPropertyName("gas_fee")]
    public ulong GasFee { get; init; }

    /// <remarks>
    /// Contains the same data as total_fwd_fees field.<para/>
    /// Deprecated because of its confusing name, that is not the same with GraphQL API Transaction type's field.
    /// </remarks>
    [JsonPropertyName("out_msgs_fwd_fee")]
    public ulong OutMsgsFwdFee { get; init; }

    /// <remarks>
    /// Contains the same data as account_fees field.
    /// </remarks>
    [JsonPropertyName("total_account_fees")]
    public ulong TotalAccountFees { get; init; }

    /// <summary>
    /// Deprecated because it means total value sent in the transaction, which does not relate to any fees.
    /// </summary>
    [JsonPropertyName("total_output")]
    public ulong TotalOutput { get; init; }

    /// <summary>
    /// Fee for inbound external message import.
    /// </summary>
    [JsonPropertyName("ext_in_msg_fee")]
    public ulong ExtInMsgFee { get; init; }

    /// <summary>
    /// Total fees the account pays for message forwarding.
    /// </summary>
    [JsonPropertyName("total_fwd_fees")]
    public ulong TotalFwdFees { get; init; }

    /// <summary>
    /// Total account fees for the transaction execution.<para/>
    /// Compounds of storage_fee + gas_fee + ext_in_msg_fee + total_fwd_fees.
    /// </summary>
    [JsonPropertyName("account_fees")]
    public ulong AccountFees { get; init; }
}