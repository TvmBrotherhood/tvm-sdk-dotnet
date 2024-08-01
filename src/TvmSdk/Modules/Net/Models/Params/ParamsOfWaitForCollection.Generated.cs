namespace TvmSdk.Modules.Net;

public record ParamsOfWaitForCollection
{
    /// <summary>
    /// Collection name (accounts, blocks, transactions, messages, block_signatures).
    /// </summary>
    [JsonPropertyName("collection")]
    public string Collection { get; init; }

    /// <summary>
    /// Collection filter.
    /// </summary>
    [JsonPropertyName("filter")]
    public JsonElement? Filter { get; init; }

    /// <summary>
    /// Projection (result) string.
    /// </summary>
    [JsonPropertyName("result")]
    public string Result { get; init; }

    /// <summary>
    /// Query timeout.
    /// </summary>
    [JsonPropertyName("timeout")]
    public uint? Timeout { get; init; }
}