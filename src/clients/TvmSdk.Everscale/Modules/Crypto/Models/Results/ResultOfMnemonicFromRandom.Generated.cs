namespace TvmSdk.Everscale.Modules.Crypto;

public record ResultOfMnemonicFromRandom
{
    /// <summary>
    /// String of mnemonic words.
    /// </summary>
    [JsonPropertyName("phrase")]
    public string Phrase { get; init; }
}