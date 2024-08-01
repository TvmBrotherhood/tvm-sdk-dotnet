namespace TvmSdk.Modules.Abi;

public record DecodedMessageBody
{
    /// <summary>
    /// Type of the message body content.
    /// </summary>
    [JsonPropertyName("body_type")]
    public MessageBodyType BodyType { get; init; }

    /// <summary>
    /// Function or event name.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; }

    /// <summary>
    /// Parameters or result value.
    /// </summary>
    [JsonPropertyName("value")]
    public JsonElement? Value { get; init; }

    /// <summary>
    /// Function header.
    /// </summary>
    [JsonPropertyName("header")]
    public FunctionHeader? Header { get; init; }
}