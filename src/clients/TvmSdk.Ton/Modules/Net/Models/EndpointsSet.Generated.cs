namespace TvmSdk.Ton.Modules.Net;

public record EndpointsSet
{
    /// <summary>
    /// List of endpoints provided by server.
    /// </summary>
    [JsonPropertyName("endpoints")]
    public string[] Endpoints { get; init; }
}