namespace TvmSdk.AckiNacki.Modules.Boc;

public record ResultOfEncodeExternalInMessage
{
    /// <summary>
    /// Message BOC encoded with <c>base64</c>.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; init; }

    /// <summary>
    /// Message id.
    /// </summary>
    [JsonPropertyName("message_id")]
    public string MessageId { get; init; }
}