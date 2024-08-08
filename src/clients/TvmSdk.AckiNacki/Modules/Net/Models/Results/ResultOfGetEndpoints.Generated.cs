namespace TvmSdk.AckiNacki.Modules.Net;

public record ResultOfGetEndpoints
{
    /// <summary>
    /// Current query endpoint.
    /// </summary>
    [JsonPropertyName("query")]
    public string Query { get; init; }

    /// <summary>
    /// List of all endpoints used by client.
    /// </summary>
    [JsonPropertyName("endpoints")]
    public string[] Endpoints { get; init; }
}