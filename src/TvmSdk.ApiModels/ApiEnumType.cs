using System.Text.Json.Serialization;

namespace TvmSdk.ApiModels;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(Struct), nameof(Struct))]
[JsonDerivedType(typeof(Ref), nameof(Ref))]
public abstract record ApiEnumType : ApiBaseTypeInfo
{
    public record Struct(ApiModelProperty[] StructFields) : ApiEnumType;

    public record Ref(string RefName) : ApiEnumType;
}