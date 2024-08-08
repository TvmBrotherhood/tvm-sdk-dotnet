namespace TvmSdk.AckiNacki.Modules.Abi;

public record ParamsOfEncodeMessage
{
    /// <summary>
    /// Contract ABI.
    /// </summary>
    [JsonPropertyName("abi")]
    public Abi Abi { get; init; }

    /// <remarks>
    /// Must be specified in case of non-deploy message.
    /// </remarks>
    [JsonPropertyName("address")]
    public string? Address { get; init; }

    /// <remarks>
    /// Must be specified in case of deploy message.
    /// </remarks>
    [JsonPropertyName("deploy_set")]
    public DeploySet? DeploySet { get; init; }

    /// <remarks>
    /// Must be specified in case of non-deploy message.<para/>
    /// In case of deploy message it is optional and contains parameters of the functions that will to be called upon deploy transaction.
    /// </remarks>
    [JsonPropertyName("call_set")]
    public CallSet? CallSet { get; init; }

    /// <summary>
    /// Signing parameters.
    /// </summary>
    [JsonPropertyName("signer")]
    public Signer Signer { get; init; }

    /// <remarks>
    /// Used in message processing with retries (if contract's ABI includes "expire" header).<para/>
    /// Encoder uses the provided try index to calculate message expiration time.<para/>
    /// The 1st message expiration time is specified in Client config.<para/>
    /// Expiration timeouts will grow with every retry.<para/>
    /// Retry grow factor is set in Client config: &amp;lt;.....add config parameter with default value here&amp;gt;  Default value is 0.
    /// </remarks>
    [JsonPropertyName("processing_try_index")]
    public byte? ProcessingTryIndex { get; init; }

    /// <summary>
    /// Signature ID to be used in data to sign preparing when CapSignatureWithId capability is enabled.
    /// </summary>
    [JsonPropertyName("signature_id")]
    public int? SignatureId { get; init; }
}