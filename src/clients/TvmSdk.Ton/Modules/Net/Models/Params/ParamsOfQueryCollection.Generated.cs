namespace TvmSdk.Ton.Modules.Net;

public record ParamsOfQueryCollection
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
    /// Sorting order.
    /// </summary>
    [JsonPropertyName("order")]
    public OrderBy[]? Order { get; init; }

    /// <summary>
    /// Number of documents to return.
    /// </summary>
    [JsonPropertyName("limit")]
    public uint? Limit { get; init; }
}