using System.Text.Json.Serialization;

namespace TvmSdk.Modules.Crypto;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(GetInfo), typeDiscriminator: "GetInfo")]
[JsonDerivedType(typeof(Encrypt), typeDiscriminator: "Encrypt")]
[JsonDerivedType(typeof(Decrypt), typeDiscriminator: "Decrypt")]
/// <summary>
/// Interface for data encryption/decryption.
/// </summary>
public abstract record ParamsOfAppEncryptionBox
{
    /// <summary>
    /// Get encryption box info.
    /// </summary>
    public record GetInfo : ParamsOfAppEncryptionBox
    {
    }

    /// <summary>
    /// Encrypt data.
    /// </summary>
    public record Encrypt : ParamsOfAppEncryptionBox
    {
        /// <summary>
        /// Data, encoded in Base64.
        /// </summary>
        [JsonPropertyName("data")]
        public string Data { get; init; }
    }

    /// <summary>
    /// Decrypt data.
    /// </summary>
    public record Decrypt : ParamsOfAppEncryptionBox
    {
        /// <summary>
        /// Data, encoded in Base64.
        /// </summary>
        [JsonPropertyName("data")]
        public string Data { get; init; }
    }
}