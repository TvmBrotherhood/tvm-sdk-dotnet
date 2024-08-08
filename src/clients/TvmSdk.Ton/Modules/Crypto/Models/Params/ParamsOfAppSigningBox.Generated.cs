using System.Text.Json.Serialization;

namespace TvmSdk.Ton.Modules.Crypto;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(GetPublicKey), typeDiscriminator: "GetPublicKey")]
[JsonDerivedType(typeof(Sign), typeDiscriminator: "Sign")]
/// <summary>
/// Signing box callbacks.
/// </summary>
public abstract record ParamsOfAppSigningBox
{
    /// <summary>
    /// Get signing box public key.
    /// </summary>
    public record GetPublicKey : ParamsOfAppSigningBox
    {
    }

    /// <summary>
    /// Sign data.
    /// </summary>
    public record Sign : ParamsOfAppSigningBox
    {
        /// <summary>
        /// Data to sign encoded as base64.
        /// </summary>
        [JsonPropertyName("unsigned")]
        public string Unsigned { get; init; }
    }
}