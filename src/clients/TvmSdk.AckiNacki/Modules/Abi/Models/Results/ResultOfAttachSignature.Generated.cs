namespace TvmSdk.AckiNacki.Modules.Abi;

public record ResultOfAttachSignature
{
    /// <summary>
    /// Signed message BOC.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; init; }

    /// <summary>
    /// Message ID.
    /// </summary>
    [JsonPropertyName("message_id")]
    public string MessageId { get; init; }
}