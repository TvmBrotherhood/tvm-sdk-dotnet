namespace TvmSdk.AckiNacki.Modules.Abi;

public record ParamsOfAttachSignatureToMessageBody
{
    /// <summary>
    /// Contract ABI.
    /// </summary>
    [JsonPropertyName("abi")]
    public Abi Abi { get; init; }

    /// <remarks>
    /// Must be encoded with <c>hex</c>.
    /// </remarks>
    [JsonPropertyName("public_key")]
    public string PublicKey { get; init; }

    /// <remarks>
    /// Must be encoded with <c>base64</c>.
    /// </remarks>
    [JsonPropertyName("message")]
    public string Message { get; init; }

    /// <remarks>
    /// Must be encoded with <c>hex</c>.
    /// </remarks>
    [JsonPropertyName("signature")]
    public string Signature { get; init; }
}