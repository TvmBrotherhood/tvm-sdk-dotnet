namespace TvmSdk.Ton.Modules.Crypto;

public record ParamsOfMnemonicDeriveSignKeys
{
    /// <summary>
    /// Phrase.
    /// </summary>
    [JsonPropertyName("phrase")]
    public string Phrase { get; init; }

    /// <summary>
    /// Derivation path, for instance "m/44'/396'/0'/0/0".
    /// </summary>
    [JsonPropertyName("path")]
    public string? Path { get; init; }

    /// <summary>
    /// Dictionary identifier.
    /// </summary>
    [JsonPropertyName("dictionary")]
    public MnemonicDictionary? Dictionary { get; init; }

    /// <summary>
    /// Word count.
    /// </summary>
    [JsonPropertyName("word_count")]
    public byte? WordCount { get; init; }
}