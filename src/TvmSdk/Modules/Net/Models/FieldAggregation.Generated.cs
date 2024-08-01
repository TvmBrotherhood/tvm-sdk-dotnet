namespace TvmSdk.Modules.Net;

public record FieldAggregation
{
    /// <summary>
    /// Dot separated path to the field.
    /// </summary>
    [JsonPropertyName("field")]
    public string Field { get; init; }

    /// <summary>
    /// Aggregation function that must be applied to field values.
    /// </summary>
    [JsonPropertyName("fn")]
    public AggregationFn Fn { get; init; }
}