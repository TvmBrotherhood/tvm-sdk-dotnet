namespace TvmSdk.Modules.Abi;

public record ResultOfEncodeMessageBody
{
    /// <summary>
    /// Message body BOC encoded with <c>base64</c>.
    /// </summary>
    [JsonPropertyName("body")]
    public string Body { get; init; }

    /// <remarks>
    /// Encoded with <c>base64</c>.<para/>
    /// Presents when <c>message</c> is unsigned.<para/>
    /// Can be used for external message signing.<para/>
    /// Is this case you need to sing this data and produce signed message using <c>abi.attach_signature</c>.
    /// </remarks>
    [JsonPropertyName("data_to_sign")]
    public string? DataToSign { get; init; }
}