using System.Text.Json.Serialization;

namespace TvmSdk.Everscale.Modules.Crypto;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(GetPublicKey), typeDiscriminator: "GetPublicKey")]
[JsonDerivedType(typeof(Sign), typeDiscriminator: "Sign")]
/// <summary>
/// Returning values from signing box callbacks.
/// </summary>
public abstract record ResultOfAppSigningBox
{
    /// <summary>
    /// Result of getting public key.
    /// </summary>
    public record GetPublicKey : ResultOfAppSigningBox
    {
        /// <summary>
        /// Signing box public key.
        /// </summary>
        [JsonPropertyName("public_key")]
        public string PublicKey { get; init; }
    }

    /// <summary>
    /// Result of signing data.
    /// </summary>
    public record Sign : ResultOfAppSigningBox
    {
        /// <summary>
        /// Data signature encoded as hex.
        /// </summary>
        [JsonPropertyName("signature")]
        public string Signature { get; init; }
    }
}