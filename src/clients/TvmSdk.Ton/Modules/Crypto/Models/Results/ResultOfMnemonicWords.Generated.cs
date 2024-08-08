namespace TvmSdk.Ton.Modules.Crypto;

public record ResultOfMnemonicWords
{
    /// <summary>
    /// The list of mnemonic words.
    /// </summary>
    [JsonPropertyName("words")]
    public string Words { get; init; }
}