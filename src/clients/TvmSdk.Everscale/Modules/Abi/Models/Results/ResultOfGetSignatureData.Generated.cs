namespace TvmSdk.Everscale.Modules.Abi;

public record ResultOfGetSignatureData
{
    /// <summary>
    /// Signature from the message in <c>hex</c>.
    /// </summary>
    [JsonPropertyName("signature")]
    public string Signature { get; init; }

    /// <summary>
    /// Data to verify the signature in <c>base64</c>.
    /// </summary>
    [JsonPropertyName("unsigned")]
    public string Unsigned { get; init; }
}