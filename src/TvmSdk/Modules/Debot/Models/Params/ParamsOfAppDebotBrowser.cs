using System.Text.Json.Serialization;

namespace TvmSdk.Modules.Debot;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(Log), typeDiscriminator: "Log")]
[JsonDerivedType(typeof(Switch), typeDiscriminator: "Switch")]
[JsonDerivedType(typeof(SwitchCompleted), typeDiscriminator: "SwitchCompleted")]
[JsonDerivedType(typeof(ShowAction), typeDiscriminator: "ShowAction")]
[JsonDerivedType(typeof(Input), typeDiscriminator: "Input")]
[JsonDerivedType(typeof(GetSigningBox), typeDiscriminator: "GetSigningBox")]
[JsonDerivedType(typeof(InvokeDebot), typeDiscriminator: "InvokeDebot")]
[JsonDerivedType(typeof(Send), typeDiscriminator: "Send")]
[JsonDerivedType(typeof(Approve), typeDiscriminator: "Approve")]
/// <remarks>
/// Called by debot engine to communicate with debot browser.
/// </remarks>
public abstract record ParamsOfAppDebotBrowser
{
    /// <summary>
    /// Print message to user.
    /// </summary>
    public record Log : ParamsOfAppDebotBrowser
    {
        /// <summary>
        /// A string that must be printed to user.
        /// </summary>
        [JsonPropertyName("msg")]
        public string Msg { get; init; }
    }

    /// <summary>
    /// Switch debot to another context (menu).
    /// </summary>
    public record Switch : ParamsOfAppDebotBrowser
    {
        /// <summary>
        /// Debot context ID to which debot is switched.
        /// </summary>
        [JsonPropertyName("context_id")]
        public byte ContextId { get; init; }
    }

    /// <summary>
    /// Notify browser that all context actions are shown.
    /// </summary>
    public record SwitchCompleted : ParamsOfAppDebotBrowser
    {
    }

    /// <summary>
    /// Show action to the user.<para/>
    /// Called after <c>switch</c> for each action in context.
    /// </summary>
    public record ShowAction : ParamsOfAppDebotBrowser
    {
        /// <summary>
        /// Debot action that must be shown to user as menu item.<para/>
        /// At least <c>description</c> property must be shown from [DebotAction] structure.
        /// </summary>
        [JsonPropertyName("action")]
        public DebotAction Action { get; init; }
    }

    /// <summary>
    /// Request user input.
    /// </summary>
    public record Input : ParamsOfAppDebotBrowser
    {
        /// <summary>
        /// A prompt string that must be printed to user before input request.
        /// </summary>
        [JsonPropertyName("prompt")]
        public string Prompt { get; init; }
    }

    /// <remarks>
    /// Signing box returned is owned and disposed by debot engine.
    /// </remarks>
    public record GetSigningBox : ParamsOfAppDebotBrowser
    {
    }

    /// <summary>
    /// Execute action of another debot.
    /// </summary>
    public record InvokeDebot : ParamsOfAppDebotBrowser
    {
        /// <summary>
        /// Address of debot in blockchain.
        /// </summary>
        [JsonPropertyName("debot_addr")]
        public string DebotAddr { get; init; }

        /// <summary>
        /// Debot action to execute.
        /// </summary>
        [JsonPropertyName("action")]
        public DebotAction Action { get; init; }
    }

    /// <summary>
    /// Used by Debot to call DInterface implemented by Debot Browser.
    /// </summary>
    public record Send : ParamsOfAppDebotBrowser
    {
        /// <remarks>
        /// Message body contains interface function and parameters.
        /// </remarks>
        [JsonPropertyName("message")]
        public string Message { get; init; }
    }

    /// <summary>
    /// Requests permission from DeBot Browser to execute DeBot operation.
    /// </summary>
    public record Approve : ParamsOfAppDebotBrowser
    {
        /// <summary>
        /// DeBot activity details.
        /// </summary>
        [JsonPropertyName("activity")]
        public DebotActivity Activity { get; init; }
    }
}