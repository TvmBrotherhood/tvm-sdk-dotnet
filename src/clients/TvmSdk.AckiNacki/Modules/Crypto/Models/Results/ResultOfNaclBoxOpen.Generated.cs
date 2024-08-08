namespace TvmSdk.AckiNacki.Modules.Crypto;

public record ResultOfNaclBoxOpen
{
    /// <summary>
    /// Decrypted data encoded in <c>base64</c>.
    /// </summary>
    [JsonPropertyName("decrypted")]
    public string Decrypted { get; init; }
}