namespace TvmSdk.Everscale.Modules.Net;

public record ParamsOfCreateTransactionIterator
{
    /// <remarks>
    /// If the application specifies this parameter then the iteration includes blocks with <c>gen_utime</c> &amp;gt;= <c>start_time</c>.<para/>
    /// Otherwise the iteration starts from zero state.<para/>
    /// Must be specified in seconds.
    /// </remarks>
    [JsonPropertyName("start_time")]
    public uint? StartTime { get; init; }

    /// <remarks>
    /// If the application specifies this parameter then the iteration includes blocks with <c>gen_utime</c> &amp;lt; <c>end_time</c>.<para/>
    /// Otherwise the iteration never stops.<para/>
    /// Must be specified in seconds.
    /// </remarks>
    [JsonPropertyName("end_time")]
    public uint? EndTime { get; init; }

    /// <remarks>
    /// If the application specifies this parameter and it is not an empty array then the iteration will include items related to accounts that belongs to the specified shard prefixes.<para/>
    /// Shard prefix must be represented as a string "workchain:prefix".<para/>
    /// Where <c>workchain</c> is a signed integer and the <c>prefix</c> if a hexadecimal representation if the 64-bit unsigned integer with tagged shard prefix.<para/>
    /// For example: "0:3800000000000000".<para/>
    /// Account address conforms to the shard filter if it belongs to the filter workchain and the first bits of address match to the shard prefix.<para/>
    /// Only transactions with suitable account addresses are iterated.
    /// </remarks>
    [JsonPropertyName("shard_filter")]
    public string[]? ShardFilter { get; init; }

    /// <remarks>
    /// Application can specify the list of accounts for which it wants to iterate transactions.<para/>
    /// If this parameter is missing or an empty list then the library iterates transactions for all accounts that pass the shard filter.<para/>
    /// Note that the library doesn't detect conflicts between the account filter and the shard filter if both are specified.<para/>
    /// So it is an application responsibility to specify the correct filter combination.
    /// </remarks>
    [JsonPropertyName("accounts_filter")]
    public string[]? AccountsFilter { get; init; }

    /// <remarks>
    /// List of the fields that must be returned for iterated items.<para/>
    /// This field is the same as the <c>result</c> parameter of the <c>query_collection</c> function.<para/>
    /// Note that iterated items can contain additional fields that are not requested in the <c>result</c>.
    /// </remarks>
    [JsonPropertyName("result")]
    public string? Result { get; init; }

    /// <remarks>
    /// If this parameter is <c>true</c> then each transaction contains field <c>transfers</c> with list of transfer.<para/>
    /// See more about this structure in function description.
    /// </remarks>
    [JsonPropertyName("include_transfers")]
    public bool? IncludeTransfers { get; init; }
}