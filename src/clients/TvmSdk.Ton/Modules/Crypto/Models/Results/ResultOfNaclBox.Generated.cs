namespace TvmSdk.Ton.Modules.Crypto;

public record ResultOfNaclBox
{
    /// <summary>
    /// Encrypted data encoded in <c>base64</c>.
    /// </summary>
    [JsonPropertyName("encrypted")]
    public string Encrypted { get; init; }
}