using System.Text.Json.Serialization;

namespace TvmSdk.ApiModels;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(Boolean), nameof(Boolean))]
[JsonDerivedType(typeof(Number), nameof(Number))]
[JsonDerivedType(typeof(BigInt), nameof(BigInt))]
[JsonDerivedType(typeof(String), nameof(String))]
[JsonDerivedType(typeof(Ref), nameof(Ref))]
[JsonDerivedType(typeof(Optional), nameof(Optional))]
[JsonDerivedType(typeof(Array), nameof(Array))]
[JsonDerivedType(typeof(None), nameof(None))]
[JsonDerivedType(typeof(Generic), nameof(Generic))]
public abstract record ApiModelProperty : ApiBaseTypeInfo // TODO: Rename to ApiProperty
{
    public record Boolean : ApiModelProperty;

    public record Number(byte NumberSize, ApiNumberType NumberType) : ApiModelProperty, IApiNumber;

    public record BigInt(byte NumberSize, ApiNumberType NumberType) : ApiModelProperty, IApiNumber;

    public record String : ApiModelProperty;

    public record Ref(string RefName) : ApiModelProperty;

    public record Optional(ApiModelProperty OptionalInner) : ApiModelProperty;

    public record Array(ApiModelProperty ArrayItem) : ApiModelProperty;

    public record None : ApiModelProperty;

    public record Generic(ApiGenericName GenericName, ApiModelProperty[] GenericArgs)
        : ApiModelProperty, IApiGeneric;
}