namespace TvmSdk.Modules.Processing;

public record ResultOfFetchNextMonitorResults
{
    /// <summary>
    /// List of the resolved results.
    /// </summary>
    [JsonPropertyName("results")]
    public MessageMonitoringResult[] Results { get; init; }
}