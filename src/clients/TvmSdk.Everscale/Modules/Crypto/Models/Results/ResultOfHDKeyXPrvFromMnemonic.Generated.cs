namespace TvmSdk.Everscale.Modules.Crypto;

public record ResultOfHDKeyXPrvFromMnemonic
{
    /// <summary>
    /// Serialized extended master private key.
    /// </summary>
    [JsonPropertyName("xprv")]
    public string Xprv { get; init; }
}