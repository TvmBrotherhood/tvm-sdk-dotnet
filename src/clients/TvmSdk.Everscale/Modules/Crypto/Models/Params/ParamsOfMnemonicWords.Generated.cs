namespace TvmSdk.Everscale.Modules.Crypto;

public record ParamsOfMnemonicWords
{
    /// <summary>
    /// Dictionary identifier.
    /// </summary>
    [JsonPropertyName("dictionary")]
    public MnemonicDictionary? Dictionary { get; init; }
}