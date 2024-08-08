namespace TvmSdk.Everscale.Modules.Debot;

/// <summary>
/// <a href="UNSTABLE.md">UNSTABLE</a><a href="DEPRECATED.md">DEPRECATED</a>.
/// </summary>
public record ParamsOfRemove
{
    /// <summary>
    /// Debot handle which references an instance of debot engine.
    /// </summary>
    [JsonPropertyName("debot_handle")]
    public uint DebotHandle { get; init; }
}