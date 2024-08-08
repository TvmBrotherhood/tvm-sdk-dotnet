namespace TvmSdk.Everscale.Modules.Net;

public record ParamsOfFindLastShardBlock
{
    /// <summary>
    /// Account address.
    /// </summary>
    [JsonPropertyName("address")]
    public string Address { get; init; }
}