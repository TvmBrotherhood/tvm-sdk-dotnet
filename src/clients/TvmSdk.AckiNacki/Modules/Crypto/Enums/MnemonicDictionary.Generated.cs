namespace TvmSdk.AckiNacki.Modules.Crypto;

public enum MnemonicDictionary : byte
{
    /// <summary>
    /// TON compatible dictionary.
    /// </summary>
    Ton = 0,
    /// <summary>
    /// English BIP-39 dictionary.
    /// </summary>
    English = 1,
    /// <summary>
    /// Chinese simplified BIP-39 dictionary.
    /// </summary>
    ChineseSimplified = 2,
    /// <summary>
    /// Chinese traditional BIP-39 dictionary.
    /// </summary>
    ChineseTraditional = 3,
    /// <summary>
    /// French BIP-39 dictionary.
    /// </summary>
    French = 4,
    /// <summary>
    /// Italian BIP-39 dictionary.
    /// </summary>
    Italian = 5,
    /// <summary>
    /// Japanese BIP-39 dictionary.
    /// </summary>
    Japanese = 6,
    /// <summary>
    /// Korean BIP-39 dictionary.
    /// </summary>
    Korean = 7,
    /// <summary>
    /// Spanish BIP-39 dictionary.
    /// </summary>
    Spanish = 8
}