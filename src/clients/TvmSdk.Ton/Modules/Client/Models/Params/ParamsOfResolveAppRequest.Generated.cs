namespace TvmSdk.Ton.Modules.Client;

public record ParamsOfResolveAppRequest
{
    /// <summary>
    /// Request ID received from SDK.
    /// </summary>
    [JsonPropertyName("app_request_id")]
    public uint AppRequestId { get; init; }

    /// <summary>
    /// Result of request processing.
    /// </summary>
    [JsonPropertyName("result")]
    public AppRequestResult Result { get; init; }
}