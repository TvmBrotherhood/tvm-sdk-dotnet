namespace TvmSdk.Everscale.Modules.Crypto;

public record ParamsOfMnemonicVerify
{
    /// <summary>
    /// Phrase.
    /// </summary>
    [JsonPropertyName("phrase")]
    public string Phrase { get; init; }

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