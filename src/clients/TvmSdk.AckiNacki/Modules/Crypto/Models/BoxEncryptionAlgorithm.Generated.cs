using System.Text.Json.Serialization;

namespace TvmSdk.AckiNacki.Modules.Crypto;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(ChaCha20), typeDiscriminator: "ChaCha20")]
[JsonDerivedType(typeof(NaclBox), typeDiscriminator: "NaclBox")]
[JsonDerivedType(typeof(NaclSecretBox), typeDiscriminator: "NaclSecretBox")]
public abstract record BoxEncryptionAlgorithm
{
    public record ChaCha20 : BoxEncryptionAlgorithm
    {
        [JsonPropertyName("value")]
        public ChaCha20ParamsCB Value { get; init; }
    }

    public record NaclBox : BoxEncryptionAlgorithm
    {
        [JsonPropertyName("value")]
        public NaclBoxParamsCB Value { get; init; }
    }

    public record NaclSecretBox : BoxEncryptionAlgorithm
    {
        [JsonPropertyName("value")]
        public NaclSecretBoxParamsCB Value { get; init; }
    }
}