using System.Text.Json.Serialization;

namespace TvmSdk.Modules.Debot;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(Input), typeDiscriminator: "Input")]
[JsonDerivedType(typeof(GetSigningBox), typeDiscriminator: "GetSigningBox")]
[JsonDerivedType(typeof(InvokeDebot), typeDiscriminator: "InvokeDebot")]
[JsonDerivedType(typeof(Approve), typeDiscriminator: "Approve")]
/// <summary>
/// <a href="UNSTABLE.md">UNSTABLE</a><a href="DEPRECATED.md">DEPRECATED</a> Returning values from Debot Browser callbacks.
/// </summary>
public abstract record ResultOfAppDebotBrowser
{
    /// <summary>
    /// Result of user input.
    /// </summary>
    public record Input : ResultOfAppDebotBrowser
    {
        /// <summary>
        /// String entered by user.
        /// </summary>
        [JsonPropertyName("value")]
        public string Value { get; init; }
    }

    /// <summary>
    /// Result of getting signing box.
    /// </summary>
    public record GetSigningBox : ResultOfAppDebotBrowser
    {
        /// <remarks>
        /// Signing box is owned and disposed by debot engine.
        /// </remarks>
        [JsonPropertyName("signing_box")]
        public uint SigningBox { get; init; }
    }

    /// <summary>
    /// Result of debot invoking.
    /// </summary>
    public record InvokeDebot : ResultOfAppDebotBrowser
    {
    }

    /// <summary>
    /// Result of <c>approve</c> callback.
    /// </summary>
    public record Approve : ResultOfAppDebotBrowser
    {
        /// <summary>
        /// Indicates whether the DeBot is allowed to perform the specified operation.
        /// </summary>
        [JsonPropertyName("approved")]
        public bool Approved { get; init; }
    }
}