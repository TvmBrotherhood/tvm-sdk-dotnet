using System.Text.Json.Serialization;

namespace TvmSdk.ApiModels;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(EnumOfConsts), nameof(EnumOfConsts))]
[JsonDerivedType(typeof(EnumOfTypes), nameof(EnumOfTypes))]
[JsonDerivedType(typeof(Number), nameof(Number))]
[JsonDerivedType(typeof(Struct), nameof(Struct))]
public abstract record ApiModel : ApiBaseTypeInfo
{
    public record EnumOfConsts(ApiEnumConst[] EnumConsts) : ApiModel;

    public record EnumOfTypes(ApiEnumType[] EnumTypes) : ApiModel;

    public record Number(byte NumberSize, ApiNumberType NumberType) : ApiModel, IApiNumber;

    public record Struct(ApiModelProperty[] StructFields) : ApiModel;
}