namespace TvmSdk.Everscale.Modules.Client;

[JsonConverter(typeof(JsonStringEnumConverter))]
/// <summary>
/// Network protocol used to perform GraphQL queries.
/// </summary>
public enum NetworkQueriesProtocol : byte
{
    /// <summary>
    /// Each GraphQL query uses separate HTTP request.
    /// </summary>
    HTTP,
    /// <summary>
    /// All GraphQL queries will be served using single web socket connection.<para/>
    /// SDK is tested to reliably handle 5000 parallel network requests (sending and processing messages, quering and awaiting blockchain data).
    /// </summary>
    WS
}