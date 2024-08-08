namespace TvmSdk.Ton.Modules.Net;

public record ResultOfAggregateCollection
{
    /// <remarks>
    /// Returns an array of strings.<para/>
    /// Each string refers to the corresponding <c>fields</c> item.<para/>
    /// Numeric value is returned as a decimal string representations.
    /// </remarks>
    [JsonPropertyName("values")]
    public JsonElement Values { get; init; }
}