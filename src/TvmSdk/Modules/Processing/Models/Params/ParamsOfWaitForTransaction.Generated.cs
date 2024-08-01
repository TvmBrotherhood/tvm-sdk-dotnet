namespace TvmSdk.Modules.Processing;

public record ParamsOfWaitForTransaction
{
    /// <remarks>
    /// If it is specified, then the output messages' bodies will be decoded according to this ABI.<para/>
    /// The <c>abi_decoded</c> result field will be filled out.
    /// </remarks>
    [JsonPropertyName("abi")]
    public Abi.Abi? Abi { get; init; }

    /// <remarks>
    /// Encoded with <c>base64</c>.
    /// </remarks>
    [JsonPropertyName("message")]
    public string Message { get; init; }

    /// <remarks>
    /// You must provide the same value as the <c>send_message</c> has returned.
    /// </remarks>
    [JsonPropertyName("shard_block_id")]
    public string ShardBlockId { get; init; }

    /// <summary>
    /// Flag that enables/disables intermediate events.<para/>
    /// Default is <c>false</c>.
    /// </summary>
    [JsonPropertyName("send_events")]
    public bool? SendEvents { get; init; }

    /// <remarks>
    /// Use this field to get more informative errors.<para/>
    /// Provide the same value as the <c>send_message</c> has returned.<para/>
    /// If the message was not delivered (expired), SDK will log the endpoint URLs, used for its sending.
    /// </remarks>
    [JsonPropertyName("sending_endpoints")]
    public string[]? SendingEndpoints { get; init; }
}