namespace TvmSdk.Everscale.Modules.Debot;

/// <summary>
/// <a href="UNSTABLE.md">UNSTABLE</a><a href="DEPRECATED.md">DEPRECATED</a> Parameters for executing debot action.
/// </summary>
public record ParamsOfExecute
{
    /// <summary>
    /// Debot handle which references an instance of debot engine.
    /// </summary>
    [JsonPropertyName("debot_handle")]
    public uint DebotHandle { get; init; }

    /// <summary>
    /// Debot Action that must be executed.
    /// </summary>
    [JsonPropertyName("action")]
    public DebotAction Action { get; init; }
}