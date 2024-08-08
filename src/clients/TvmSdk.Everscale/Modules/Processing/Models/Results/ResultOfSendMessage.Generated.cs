namespace TvmSdk.Everscale.Modules.Processing;

public record ResultOfSendMessage
{
    /// <remarks>
    /// This block id must be used as a parameter of the <c>wait_for_transaction</c>.
    /// </remarks>
    [JsonPropertyName("shard_block_id")]
    public string ShardBlockId { get; init; }

    /// <remarks>
    /// This list id must be used as a parameter of the <c>wait_for_transaction</c>.
    /// </remarks>
    [JsonPropertyName("sending_endpoints")]
    public string[] SendingEndpoints { get; init; }
}