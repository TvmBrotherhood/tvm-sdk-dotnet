namespace TvmSdk.AckiNacki.Modules.Crypto;

public record ParamsOfHDKeyPublicFromXPrv
{
    /// <summary>
    /// Serialized extended private key.
    /// </summary>
    [JsonPropertyName("xprv")]
    public string Xprv { get; init; }
}