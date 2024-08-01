namespace TvmSdk.Modules.Crypto;

public record ParamsOfHDKeyDeriveFromXPrv
{
    /// <summary>
    /// Serialized extended private key.
    /// </summary>
    [JsonPropertyName("xprv")]
    public string Xprv { get; init; }

    /// <summary>
    /// Child index (see BIP-0032).
    /// </summary>
    [JsonPropertyName("child_index")]
    public uint ChildIndex { get; init; }

    /// <summary>
    /// Indicates the derivation of hardened/not-hardened key (see BIP-0032).
    /// </summary>
    [JsonPropertyName("hardened")]
    public bool Hardened { get; init; }
}