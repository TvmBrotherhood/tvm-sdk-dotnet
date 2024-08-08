namespace TvmSdk.AckiNacki.Modules.Net;

public record ParamsOfCreateBlockIterator
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
    /// If the application specifies this parameter and it is not the empty array then the iteration will include items related to accounts that belongs to the specified shard prefixes.<para/>
    /// Shard prefix must be represented as a string "workchain:prefix".<para/>
    /// Where <c>workchain</c> is a signed integer and the <c>prefix</c> if a hexadecimal representation if the 64-bit unsigned integer with tagged shard prefix.<para/>
    /// For example: "0:3800000000000000".
    /// </remarks>
    [JsonPropertyName("shard_filter")]
    public string[]? ShardFilter { get; init; }

    /// <remarks>
    /// List of the fields that must be returned for iterated items.<para/>
    /// This field is the same as the <c>result</c> parameter of the <c>query_collection</c> function.<para/>
    /// Note that iterated items can contains additional fields that are not requested in the <c>result</c>.
    /// </remarks>
    [JsonPropertyName("result")]
    public string? Result { get; init; }
}