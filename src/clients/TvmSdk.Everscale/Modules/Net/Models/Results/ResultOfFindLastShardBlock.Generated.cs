namespace TvmSdk.Everscale.Modules.Net;

public record ResultOfFindLastShardBlock
{
    /// <summary>
    /// Account shard last block ID.
    /// </summary>
    [JsonPropertyName("block_id")]
    public string BlockId { get; init; }
}