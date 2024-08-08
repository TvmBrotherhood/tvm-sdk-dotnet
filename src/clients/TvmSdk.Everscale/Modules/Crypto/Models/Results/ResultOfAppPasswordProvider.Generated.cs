using System.Text.Json.Serialization;

namespace TvmSdk.Everscale.Modules.Crypto;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(GetPassword), typeDiscriminator: "GetPassword")]
public abstract record ResultOfAppPasswordProvider
{
    public record GetPassword : ResultOfAppPasswordProvider
    {
        /// <summary>
        /// Password, encrypted and encoded to base64.<para/>
        /// Crypto box uses this password to decrypt its secret (seed phrase).
        /// </summary>
        [JsonPropertyName("encrypted_password")]
        public string EncryptedPassword { get; init; }

        /// <remarks>
        /// Used together with <c>encryption_public_key</c> to decode <c>encrypted_password</c>.
        /// </remarks>
        [JsonPropertyName("app_encryption_pubkey")]
        public string AppEncryptionPubkey { get; init; }
    }
}