namespace TvmSdk.Modules.Net;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AggregationFn : byte
{
    /// <summary>
    /// Returns count of filtered record.
    /// </summary>
    COUNT,
    /// <summary>
    /// Returns the minimal value for a field in filtered records.
    /// </summary>
    MIN,
    /// <summary>
    /// Returns the maximal value for a field in filtered records.
    /// </summary>
    MAX,
    /// <summary>
    /// Returns a sum of values for a field in filtered records.
    /// </summary>
    SUM,
    /// <summary>
    /// Returns an average value for a field in filtered records.
    /// </summary>
    AVERAGE
}