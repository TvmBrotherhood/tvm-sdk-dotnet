namespace TvmSdk.Modules.Abi;

public record ParamsOfAttachSignature
{
    /// <summary>
    /// Contract ABI.
    /// </summary>
    [JsonPropertyName("abi")]
    public Abi Abi { get; init; }

    /// <summary>
    /// Public key encoded in <c>hex</c>.
    /// </summary>
    [JsonPropertyName("public_key")]
    public string PublicKey { get; init; }

    /// <summary>
    /// Unsigned message BOC encoded in <c>base64</c>.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; init; }

    /// <summary>
    /// Signature encoded in <c>hex</c>.
    /// </summary>
    [JsonPropertyName("signature")]
    public string Signature { get; init; }
}