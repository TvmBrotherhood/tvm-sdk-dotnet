namespace TvmSdk.Ton.Modules.Abi;

public record ResultOfEncodeInitialData
{
    /// <summary>
    /// Updated data BOC or BOC handle.
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; init; }
}