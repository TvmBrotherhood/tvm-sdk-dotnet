namespace TvmSdk.Modules.Net;

public record ResultOfBatchQuery
{
    /// <remarks>
    /// Returns an array of values.<para/>
    /// Each value corresponds to <c>queries</c> item.
    /// </remarks>
    [JsonPropertyName("results")]
    public JsonElement[] Results { get; init; }
}