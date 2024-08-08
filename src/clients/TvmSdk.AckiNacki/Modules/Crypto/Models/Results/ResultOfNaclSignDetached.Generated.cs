namespace TvmSdk.AckiNacki.Modules.Crypto;

public record ResultOfNaclSignDetached
{
    /// <summary>
    /// Signature encoded in <c>hex</c>.
    /// </summary>
    [JsonPropertyName("signature")]
    public string Signature { get; init; }
}