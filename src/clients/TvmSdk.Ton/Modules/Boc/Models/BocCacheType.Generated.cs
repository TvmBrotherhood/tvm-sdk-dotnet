using System.Text.Json.Serialization;

namespace TvmSdk.Ton.Modules.Boc;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(Pinned), typeDiscriminator: "Pinned")]
[JsonDerivedType(typeof(Unpinned), typeDiscriminator: "Unpinned")]
public abstract record BocCacheType
{
    /// <remarks>
    /// Such BOC will not be removed from cache until it is unpinned BOCs can have several pins and each of the pins has reference counter indicating how many times the BOC was pinned with the pin.<para/>
    /// BOC is removed from cache after all references for all pins are unpinned with <c>cache_unpin</c> function calls.
    /// </remarks>
    public record Pinned : BocCacheType
    {
        [JsonPropertyName("pin")]
        public string Pin { get; init; }
    }

    /// <remarks>
    /// BOC resides there until it is replaced with other BOCs if it is not used.
    /// </remarks>
    public record Unpinned : BocCacheType
    {
    }
}