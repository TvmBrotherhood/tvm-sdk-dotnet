namespace TvmSdk.AckiNacki.Modules.Net;

public record ParamsOfBatchQuery
{
    /// <summary>
    /// List of query operations that must be performed per single fetch.
    /// </summary>
    [JsonPropertyName("operations")]
    public ParamsOfQueryOperation[] Operations { get; init; }
}