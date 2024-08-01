namespace TvmSdk.Modules.Crypto;

public record ParamsOfHDKeyDeriveFromXPrvPath
{
    /// <summary>
    /// Serialized extended private key.
    /// </summary>
    [JsonPropertyName("xprv")]
    public string Xprv { get; init; }

    /// <summary>
    /// Derivation path, for instance "m/44'/396'/0'/0/0".
    /// </summary>
    [JsonPropertyName("path")]
    public string Path { get; init; }
}