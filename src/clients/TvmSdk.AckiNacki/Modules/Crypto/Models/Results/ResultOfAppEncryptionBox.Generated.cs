using System.Text.Json.Serialization;

namespace TvmSdk.AckiNacki.Modules.Crypto;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(GetInfo), typeDiscriminator: "GetInfo")]
[JsonDerivedType(typeof(Encrypt), typeDiscriminator: "Encrypt")]
[JsonDerivedType(typeof(Decrypt), typeDiscriminator: "Decrypt")]
/// <summary>
/// Returning values from signing box callbacks.
/// </summary>
public abstract record ResultOfAppEncryptionBox
{
    /// <summary>
    /// Result of getting encryption box info.
    /// </summary>
    public record GetInfo : ResultOfAppEncryptionBox
    {
        [JsonPropertyName("info")]
        public EncryptionBoxInfo Info { get; init; }
    }

    /// <summary>
    /// Result of encrypting data.
    /// </summary>
    public record Encrypt : ResultOfAppEncryptionBox
    {
        /// <summary>
        /// Encrypted data, encoded in Base64.
        /// </summary>
        [JsonPropertyName("data")]
        public string Data { get; init; }
    }

    /// <summary>
    /// Result of decrypting data.
    /// </summary>
    public record Decrypt : ResultOfAppEncryptionBox
    {
        /// <summary>
        /// Decrypted data, encoded in Base64.
        /// </summary>
        [JsonPropertyName("data")]
        public string Data { get; init; }
    }
}