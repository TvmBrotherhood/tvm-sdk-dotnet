namespace TvmSdk.Modules.Client;

/// <summary>
/// Crypto config.
/// </summary>
public record CryptoConfig
{
    /// <summary>
    /// Mnemonic dictionary that will be used by default in crypto functions.<para/>
    /// If not specified, <c>English</c> dictionary will be used.
    /// </summary>
    [JsonPropertyName("mnemonic_dictionary")]
    public Crypto.MnemonicDictionary? MnemonicDictionary { get; init; }

    /// <summary>
    /// Mnemonic word count that will be used by default in crypto functions.<para/>
    /// If not specified the default value will be 12.
    /// </summary>
    [JsonPropertyName("mnemonic_word_count")]
    public byte? MnemonicWordCount { get; init; }

    /// <summary>
    /// Derivation path that will be used by default in crypto functions.<para/>
    /// If not specified <c>m/44'/396'/0'/0/0</c> will be used.
    /// </summary>
    [JsonPropertyName("hdkey_derivation_path")]
    public string? HdkeyDerivationPath { get; init; }
}