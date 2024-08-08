using System.Text.Json.Serialization;

namespace TvmSdk.AckiNacki.Modules.Abi;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(None), typeDiscriminator: "None")]
[JsonDerivedType(typeof(External), typeDiscriminator: "External")]
[JsonDerivedType(typeof(Keys), typeDiscriminator: "Keys")]
[JsonDerivedType(typeof(SigningBox), typeDiscriminator: "SigningBox")]
public abstract record Signer
{
    /// <remarks>
    /// Creates an unsigned message.
    /// </remarks>
    public record None : Signer
    {
    }

    /// <summary>
    /// Only public key is provided in unprefixed hex string format to generate unsigned message and <c>data_to_sign</c> which can be signed later.
    /// </summary>
    public record External : Signer
    {
        [JsonPropertyName("public_key")]
        public string PublicKey { get; init; }
    }

    /// <summary>
    /// Key pair is provided for signing.
    /// </summary>
    public record Keys : Signer
    {
        [JsonPropertyName("keys")]
        public Crypto.KeyPair KeysValue { get; init; }
    }

    /// <summary>
    /// Signing Box interface is provided for signing, allows Dapps to sign messages using external APIs, such as HSM, cold wallet, etc.
    /// </summary>
    public record SigningBox : Signer
    {
        [JsonPropertyName("handle")]
        public uint Handle { get; init; }
    }
}