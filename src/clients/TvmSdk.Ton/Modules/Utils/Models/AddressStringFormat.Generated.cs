using System.Text.Json.Serialization;

namespace TvmSdk.Ton.Modules.Utils;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(AccountId), typeDiscriminator: "AccountId")]
[JsonDerivedType(typeof(Hex), typeDiscriminator: "Hex")]
[JsonDerivedType(typeof(Base64), typeDiscriminator: "Base64")]
public abstract record AddressStringFormat
{
    public record AccountId : AddressStringFormat
    {
    }

    public record Hex : AddressStringFormat
    {
    }

    public record Base64 : AddressStringFormat
    {
        [JsonPropertyName("url")]
        public bool Url { get; init; }

        [JsonPropertyName("test")]
        public bool Test { get; init; }

        [JsonPropertyName("bounce")]
        public bool Bounce { get; init; }
    }
}