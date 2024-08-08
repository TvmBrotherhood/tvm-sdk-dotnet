using System.Text.Json.Serialization;

namespace TvmSdk.Everscale.Modules.Crypto;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(AES), typeDiscriminator: "AES")]
[JsonDerivedType(typeof(ChaCha20), typeDiscriminator: "ChaCha20")]
[JsonDerivedType(typeof(NaclBox), typeDiscriminator: "NaclBox")]
[JsonDerivedType(typeof(NaclSecretBox), typeDiscriminator: "NaclSecretBox")]
public abstract record EncryptionAlgorithm
{
    public record AES : EncryptionAlgorithm
    {
        [JsonPropertyName("value")]
        public AesParamsEB Value { get; init; }
    }

    public record ChaCha20 : EncryptionAlgorithm
    {
        [JsonPropertyName("value")]
        public ChaCha20ParamsEB Value { get; init; }
    }

    public record NaclBox : EncryptionAlgorithm
    {
        [JsonPropertyName("value")]
        public NaclBoxParamsEB Value { get; init; }
    }

    public record NaclSecretBox : EncryptionAlgorithm
    {
        [JsonPropertyName("value")]
        public NaclSecretBoxParamsEB Value { get; init; }
    }
}