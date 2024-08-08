namespace TvmSdk.AckiNacki.Modules.Abi;

public record ResultOfUpdateInitialData
{
    /// <summary>
    /// Updated data BOC or BOC handle.
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; init; }
}