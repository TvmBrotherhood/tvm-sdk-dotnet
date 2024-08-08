namespace TvmSdk.Ton.Modules.Abi;

public record ResultOfEncodeInternalMessage
{
    /// <summary>
    /// Message BOC encoded with <c>base64</c>.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; init; }

    /// <summary>
    /// Destination address.
    /// </summary>
    [JsonPropertyName("address")]
    public string Address { get; init; }

    /// <summary>
    /// Message id.
    /// </summary>
    [JsonPropertyName("message_id")]
    public string MessageId { get; init; }
}