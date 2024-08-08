namespace TvmSdk.Everscale.Modules.Crypto;

public record ResultOfGetCryptoBoxSeedPhrase
{
    [JsonPropertyName("phrase")]
    public string Phrase { get; init; }

    [JsonPropertyName("dictionary")]
    public MnemonicDictionary Dictionary { get; init; }

    [JsonPropertyName("wordcount")]
    public byte Wordcount { get; init; }
}