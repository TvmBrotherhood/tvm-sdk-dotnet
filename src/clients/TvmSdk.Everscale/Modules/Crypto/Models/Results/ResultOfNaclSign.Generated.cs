namespace TvmSdk.Everscale.Modules.Crypto;

public record ResultOfNaclSign
{
    /// <summary>
    /// Signed data, encoded in <c>base64</c>.
    /// </summary>
    [JsonPropertyName("signed")]
    public string Signed { get; init; }
}