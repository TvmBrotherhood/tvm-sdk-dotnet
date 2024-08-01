using System.Text.Json.Serialization;

namespace TvmSdk.Modules.Client;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(Error), typeDiscriminator: "Error")]
[JsonDerivedType(typeof(Ok), typeDiscriminator: "Ok")]
public abstract record AppRequestResult
{
    /// <summary>
    /// Error occurred during request processing.
    /// </summary>
    public record Error : AppRequestResult
    {
        /// <summary>
        /// Error description.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; init; }
    }

    /// <summary>
    /// Request processed successfully.
    /// </summary>
    public record Ok : AppRequestResult
    {
        /// <summary>
        /// Request processing result.
        /// </summary>
        [JsonPropertyName("result")]
        public JsonElement Result { get; init; }
    }
}