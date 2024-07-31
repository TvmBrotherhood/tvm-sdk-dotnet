using System.Text.Json.Serialization;

namespace TvmSdk.ApiModels;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(Number), nameof(Number))]
[JsonDerivedType(typeof(None), nameof(None))]
public abstract record ApiEnumConst : ApiBaseTypeInfo
{
    public record Number(long Value) : ApiEnumConst;

    public record None : ApiEnumConst;
}