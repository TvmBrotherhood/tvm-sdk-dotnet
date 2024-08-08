namespace TvmSdk.Everscale.Modules.Crypto;

public record ResultOfMnemonicVerify
{
    /// <summary>
    /// Flag indicating if the mnemonic is valid or not.
    /// </summary>
    [JsonPropertyName("valid")]
    public bool Valid { get; init; }
}