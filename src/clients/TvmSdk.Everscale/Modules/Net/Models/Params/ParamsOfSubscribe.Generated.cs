namespace TvmSdk.Everscale.Modules.Net;

public record ParamsOfSubscribe
{
    /// <summary>
    /// GraphQL subscription text.
    /// </summary>
    [JsonPropertyName("subscription")]
    public string Subscription { get; init; }

    /// <remarks>
    /// Must be a map with named values that can be used in query.
    /// </remarks>
    [JsonPropertyName("variables")]
    public JsonElement? Variables { get; init; }
}