namespace TvmSdk.Everscale.Modules.Abi;

public record ParamsOfEncodeMessageBody
{
    /// <summary>
    /// Contract ABI.
    /// </summary>
    [JsonPropertyName("abi")]
    public Abi Abi { get; init; }

    /// <remarks>
    /// Must be specified in non deploy message.<para/>
    /// In case of deploy message contains parameters of constructor.
    /// </remarks>
    [JsonPropertyName("call_set")]
    public CallSet CallSet { get; init; }

    /// <summary>
    /// True if internal message body must be encoded.
    /// </summary>
    [JsonPropertyName("is_internal")]
    public bool IsInternal { get; init; }

    /// <summary>
    /// Signing parameters.
    /// </summary>
    [JsonPropertyName("signer")]
    public Signer Signer { get; init; }

    /// <remarks>
    /// Used in message processing with retries.<para/>
    /// Encoder uses the provided try index to calculate message expiration time.<para/>
    /// Expiration timeouts will grow with every retry.<para/>
    /// Default value is 0.
    /// </remarks>
    [JsonPropertyName("processing_try_index")]
    public byte? ProcessingTryIndex { get; init; }

    /// <remarks>
    /// Since ABI version 2.3 destination address of external inbound message is used in message body signature calculation.<para/>
    /// Should be provided when signed external inbound message body is created.<para/>
    /// Otherwise can be omitted.
    /// </remarks>
    [JsonPropertyName("address")]
    public string? Address { get; init; }

    /// <summary>
    /// Signature ID to be used in data to sign preparing when CapSignatureWithId capability is enabled.
    /// </summary>
    [JsonPropertyName("signature_id")]
    public int? SignatureId { get; init; }
}