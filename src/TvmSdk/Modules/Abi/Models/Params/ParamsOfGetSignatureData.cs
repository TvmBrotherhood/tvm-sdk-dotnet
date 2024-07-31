namespace TvmSdk.Modules.Abi;

public record ParamsOfGetSignatureData
{
    /// <summary>
    /// Contract ABI used to decode.
    /// </summary>
    [JsonPropertyName("abi")]
    public Abi Abi { get; init; }

    /// <summary>
    /// Message BOC encoded in <c>base64</c>.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; init; }

    /// <summary>
    /// Signature ID to be used in unsigned data preparing when CapSignatureWithId capability is enabled.
    /// </summary>
    [JsonPropertyName("signature_id")]
    public int? SignatureId { get; init; }
}