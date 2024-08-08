namespace TvmSdk.Ton.Modules.Crypto;

public record ParamsOfHash
{
    /// <remarks>
    /// Encoded with <c>base64</c>.
    /// </remarks>
    [JsonPropertyName("data")]
    public string Data { get; init; }
}