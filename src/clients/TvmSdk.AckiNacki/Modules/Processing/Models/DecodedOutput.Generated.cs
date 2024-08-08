namespace TvmSdk.AckiNacki.Modules.Processing;

public record DecodedOutput
{
    /// <remarks>
    /// If the message can't be decoded, then <c>None</c> will be stored in the appropriate position.
    /// </remarks>
    [JsonPropertyName("out_messages")]
    public Abi.DecodedMessageBody?[] OutMessages { get; init; }

    /// <summary>
    /// Decoded body of the function output message.
    /// </summary>
    [JsonPropertyName("output")]
    public JsonElement? Output { get; init; }
}