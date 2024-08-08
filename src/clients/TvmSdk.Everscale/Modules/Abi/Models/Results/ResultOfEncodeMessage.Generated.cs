namespace TvmSdk.Everscale.Modules.Abi;

public record ResultOfEncodeMessage
{
    /// <summary>
    /// Message BOC encoded with <c>base64</c>.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; init; }

    /// <remarks>
    /// Returned in case of <c>Signer::External</c>.<para/>
    /// Can be used for external message signing.<para/>
    /// Is this case you need to use this data to create signature and then produce signed message using <c>abi.attach_signature</c>.
    /// </remarks>
    [JsonPropertyName("data_to_sign")]
    public string? DataToSign { get; init; }

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