namespace TvmSdk.Everscale.Modules.Crypto;

public record ParamsOfMnemonicFromEntropy
{
    /// <remarks>
    /// Hex encoded.
    /// </remarks>
    [JsonPropertyName("entropy")]
    public string Entropy { get; init; }

    /// <summary>
    /// Dictionary identifier.
    /// </summary>
    [JsonPropertyName("dictionary")]
    public MnemonicDictionary? Dictionary { get; init; }

    /// <summary>
    /// Mnemonic word count.
    /// </summary>
    [JsonPropertyName("word_count")]
    public byte? WordCount { get; init; }
}