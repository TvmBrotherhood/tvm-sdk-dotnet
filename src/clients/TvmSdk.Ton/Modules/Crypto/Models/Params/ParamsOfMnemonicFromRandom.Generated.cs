namespace TvmSdk.Ton.Modules.Crypto;

public record ParamsOfMnemonicFromRandom
{
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