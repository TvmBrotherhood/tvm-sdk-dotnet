namespace TvmSdk.Modules.Client;

public record ParamsOfAppRequest
{
    /// <remarks>
    /// Should be used in <c>resolve_app_request</c> call.
    /// </remarks>
    [JsonPropertyName("app_request_id")]
    public uint AppRequestId { get; init; }

    /// <summary>
    /// Request describing data.
    /// </summary>
    [JsonPropertyName("request_data")]
    public JsonElement RequestData { get; init; }
}