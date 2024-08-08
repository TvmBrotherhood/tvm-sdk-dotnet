namespace TvmSdk.Everscale.Modules.Client;

public record ClientConfig
{
    [JsonPropertyName("binding")]
    public BindingConfig? Binding { get; init; }

    [JsonPropertyName("network")]
    public NetworkConfig? Network { get; init; }

    [JsonPropertyName("crypto")]
    public CryptoConfig? Crypto { get; init; }

    [JsonPropertyName("abi")]
    public AbiConfig? Abi { get; init; }

    [JsonPropertyName("boc")]
    public BocConfig? Boc { get; init; }

    [JsonPropertyName("proofs")]
    public ProofsConfig? Proofs { get; init; }

    /// <summary>
    /// For file based storage is a folder name where SDK will store its data.<para/>
    /// For browser based is a browser async storage key prefix.<para/>
    /// Default (recommended) value is "~/.tonclient" for native environments and ".tonclient" for web-browser.
    /// </summary>
    [JsonPropertyName("local_storage_path")]
    public string? LocalStoragePath { get; init; }
}