using System.Text.Json.Serialization;

namespace TvmSdk.Modules.Crypto;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(GetPassword), typeDiscriminator: "GetPassword")]
/// <remarks>
/// To secure the password while passing it from application to the library, the library generates a temporary key pair, passes the pubkey to the passwordProvider, decrypts the received password with private key, and deletes the key pair right away.<para/>
/// Application should generate a temporary nacl_box_keypair and encrypt the password with naclbox function using nacl_box_keypair.secret and encryption_public_key keys + nonce = 24-byte prefix of encryption_public_key.
/// </remarks>
public abstract record ParamsOfAppPasswordProvider
{
    public record GetPassword : ParamsOfAppPasswordProvider
    {
        /// <summary>
        /// Temporary library pubkey, that is used on application side for password encryption, along with application temporary private key and nonce.<para/>
        /// Used for password decryption on library side.
        /// </summary>
        [JsonPropertyName("encryption_public_key")]
        public string EncryptionPublicKey { get; init; }
    }
}