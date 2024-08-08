namespace TvmSdk.Ton.Modules.Crypto;

public record ResultOfHDKeyDeriveFromXPrvPath
{
    /// <summary>
    /// Derived serialized extended private key.
    /// </summary>
    [JsonPropertyName("xprv")]
    public string Xprv { get; init; }
}