namespace TvmSdk.AckiNacki.Modules.Net;

public record ParamsOfFindLastShardBlock
{
    /// <summary>
    /// Account address.
    /// </summary>
    [JsonPropertyName("address")]
    public string Address { get; init; }
}