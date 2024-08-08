namespace TvmSdk.AckiNacki.Modules.Crypto;

public record ResultOfMnemonicFromEntropy
{
    /// <summary>
    /// Phrase.
    /// </summary>
    [JsonPropertyName("phrase")]
    public string Phrase { get; init; }
}