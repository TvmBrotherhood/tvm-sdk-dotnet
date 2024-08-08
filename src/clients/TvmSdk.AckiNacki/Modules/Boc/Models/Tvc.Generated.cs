using System.Text.Json.Serialization;

namespace TvmSdk.AckiNacki.Modules.Boc;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(V1), typeDiscriminator: "V1")]
public abstract record Tvc
{
    public record V1 : Tvc
    {
        [JsonPropertyName("value")]
        public TvcV1 Value { get; init; }
    }
}