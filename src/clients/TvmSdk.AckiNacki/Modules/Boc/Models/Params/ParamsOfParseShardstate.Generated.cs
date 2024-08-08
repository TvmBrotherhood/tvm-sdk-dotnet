namespace TvmSdk.AckiNacki.Modules.Boc;

public record ParamsOfParseShardstate
{
    /// <summary>
    /// BOC encoded as base64.
    /// </summary>
    [JsonPropertyName("boc")]
    public string Boc { get; init; }

    /// <summary>
    /// Shardstate identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; init; }

    /// <summary>
    /// Workchain shardstate belongs to.
    /// </summary>
    [JsonPropertyName("workchain_id")]
    public int WorkchainId { get; init; }
}