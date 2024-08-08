using System.Text.Json.Serialization;

namespace TvmSdk.AckiNacki.Modules.Crypto;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(RandomSeedPhrase), typeDiscriminator: "RandomSeedPhrase")]
[JsonDerivedType(typeof(PredefinedSeedPhrase), typeDiscriminator: "PredefinedSeedPhrase")]
[JsonDerivedType(typeof(EncryptedSecret), typeDiscriminator: "EncryptedSecret")]
/// <summary>
/// Crypto Box Secret.
/// </summary>
public abstract record CryptoBoxSecret
{
    /// <remarks>
    /// This type should be used upon the first wallet initialization, all further initializations should use <c>EncryptedSecret</c> type instead.<para/>
    /// Get <c>encrypted_secret</c> with <c>get_crypto_box_info</c> function and store it on your side.
    /// </remarks>
    public record RandomSeedPhrase : CryptoBoxSecret
    {
        [JsonPropertyName("dictionary")]
        public MnemonicDictionary Dictionary { get; init; }

        [JsonPropertyName("wordcount")]
        public byte Wordcount { get; init; }
    }

    /// <remarks>
    /// This type should be used only upon the first wallet initialization, all further initializations should use <c>EncryptedSecret</c> type instead.<para/>
    /// Get <c>encrypted_secret</c> with <c>get_crypto_box_info</c> function and store it on your side.
    /// </remarks>
    public record PredefinedSeedPhrase : CryptoBoxSecret
    {
        [JsonPropertyName("phrase")]
        public string Phrase { get; init; }

        [JsonPropertyName("dictionary")]
        public MnemonicDictionary Dictionary { get; init; }

        [JsonPropertyName("wordcount")]
        public byte Wordcount { get; init; }
    }

    /// <remarks>
    /// It is an object, containing seed phrase or private key, encrypted with <c>secret_encryption_salt</c> and password from <c>password_provider</c>.<para/>
    /// Note that if you want to change salt or password provider, then you need to reinitialize the wallet with <c>PredefinedSeedPhrase</c>, then get <c>EncryptedSecret</c> via <c>get_crypto_box_info</c>, store it somewhere, and only after that initialize the wallet with <c>EncryptedSecret</c> type.
    /// </remarks>
    public record EncryptedSecret : CryptoBoxSecret
    {
        /// <summary>
        /// It is an object, containing encrypted seed phrase or private key (now we support only seed phrase).
        /// </summary>
        [JsonPropertyName("encrypted_secret")]
        public string EncryptedSecretValue { get; init; }
    }
}