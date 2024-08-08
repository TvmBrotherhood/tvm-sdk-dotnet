namespace TvmSdk.AckiNacki.Modules.Boc;

public record ParamsOfEncodeExternalInMessage
{
    /// <summary>
    /// Source address.
    /// </summary>
    [JsonPropertyName("src")]
    public string? Src { get; init; }

    /// <summary>
    /// Destination address.
    /// </summary>
    [JsonPropertyName("dst")]
    public string Dst { get; init; }

    /// <summary>
    /// Bag of cells with state init (used in deploy messages).
    /// </summary>
    [JsonPropertyName("init")]
    public string? Init { get; init; }

    /// <summary>
    /// Bag of cells with the message body encoded as base64.
    /// </summary>
    [JsonPropertyName("body")]
    public string? Body { get; init; }

    /// <remarks>
    /// The BOC itself returned if no cache type provided.
    /// </remarks>
    [JsonPropertyName("boc_cache")]
    public BocCacheType? BocCache { get; init; }
}