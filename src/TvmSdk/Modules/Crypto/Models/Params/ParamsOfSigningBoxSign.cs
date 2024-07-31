namespace TvmSdk.Modules.Crypto;

public record ParamsOfSigningBoxSign
{
    /// <summary>
    /// Signing Box handle.
    /// </summary>
    [JsonPropertyName("signing_box")]
    public uint SigningBox { get; init; }

    /// <remarks>
    /// Must be encoded with <c>base64</c>.
    /// </remarks>
    [JsonPropertyName("unsigned")]
    public string Unsigned { get; init; }
}