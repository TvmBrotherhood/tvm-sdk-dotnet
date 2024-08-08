namespace TvmSdk.Ton.Modules.Crypto;

public record ParamsOfHDKeySecretFromXPrv
{
    /// <summary>
    /// Serialized extended private key.
    /// </summary>
    [JsonPropertyName("xprv")]
    public string Xprv { get; init; }
}