namespace TvmSdk.Ton.Modules.Net;

public record ParamsOfQuery
{
    /// <summary>
    /// GraphQL query text.
    /// </summary>
    [JsonPropertyName("query")]
    public string Query { get; init; }

    /// <remarks>
    /// Must be a map with named values that can be used in query.
    /// </remarks>
    [JsonPropertyName("variables")]
    public JsonElement? Variables { get; init; }
}