using System.Text.Json.Serialization;

namespace TvmSdk.Ton.Modules.Abi;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(Contract), typeDiscriminator: "Contract")]
[JsonDerivedType(typeof(Json), typeDiscriminator: "Json")]
[JsonDerivedType(typeof(Handle), typeDiscriminator: "Handle")]
[JsonDerivedType(typeof(Serialized), typeDiscriminator: "Serialized")]
public abstract record Abi
{
    public record Contract : Abi
    {
        [JsonPropertyName("value")]
        public AbiContract Value { get; init; }
    }

    public record Json : Abi
    {
        [JsonPropertyName("value")]
        public string Value { get; init; }
    }

    public record Handle : Abi
    {
        [JsonPropertyName("value")]
        public uint Value { get; init; }
    }

    public record Serialized : Abi
    {
        [JsonPropertyName("value")]
        public AbiContract Value { get; init; }
    }
}