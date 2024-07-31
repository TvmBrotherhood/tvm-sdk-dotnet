namespace TvmSdk.Modules.Net;

public record MessageNode
{
    /// <summary>
    /// Message id.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; init; }

    /// <remarks>
    /// This field is missing for an external inbound messages.
    /// </remarks>
    [JsonPropertyName("src_transaction_id")]
    public string? SrcTransactionId { get; init; }

    /// <remarks>
    /// This field is missing for an external outbound messages.
    /// </remarks>
    [JsonPropertyName("dst_transaction_id")]
    public string? DstTransactionId { get; init; }

    /// <summary>
    /// Source address.
    /// </summary>
    [JsonPropertyName("src")]
    public string? Src { get; init; }

    /// <summary>
    /// Destination address.
    /// </summary>
    [JsonPropertyName("dst")]
    public string? Dst { get; init; }

    /// <summary>
    /// Transferred tokens value.
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value { get; init; }

    /// <summary>
    /// Bounce flag.
    /// </summary>
    [JsonPropertyName("bounce")]
    public bool Bounce { get; init; }

    /// <remarks>
    /// Library tries to decode message body using provided <c>params.abi_registry</c>.<para/>
    /// This field will be missing if none of the provided abi can be used to decode.
    /// </remarks>
    [JsonPropertyName("decoded_body")]
    public Abi.DecodedMessageBody? DecodedBody { get; init; }
}