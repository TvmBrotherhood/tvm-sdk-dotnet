namespace TvmSdk.Ton.Modules.Crypto;

public record ParamsOfHDKeyXPrvFromMnemonic
{
    /// <summary>
    /// String with seed phrase.
    /// </summary>
    [JsonPropertyName("phrase")]
    public string Phrase { get; init; }

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