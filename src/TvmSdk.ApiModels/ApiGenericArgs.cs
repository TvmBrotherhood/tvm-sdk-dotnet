using System.Text.Json.Serialization;

namespace TvmSdk.ApiModels;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(Ref), nameof(Ref))]
[JsonDerivedType(typeof(None), nameof(None))]
public abstract record ApiGenericArgs
{
    public record Ref(string RefName) : ApiGenericArgs;

    public record None : ApiGenericArgs;
}