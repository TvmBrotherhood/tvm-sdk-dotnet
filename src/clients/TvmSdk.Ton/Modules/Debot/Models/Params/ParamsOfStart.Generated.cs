namespace TvmSdk.Ton.Modules.Debot;

/// <summary>
/// <a href="UNSTABLE.md">UNSTABLE</a><a href="DEPRECATED.md">DEPRECATED</a> Parameters to start DeBot.<para/>
/// DeBot must be already initialized with init() function.
/// </summary>
public record ParamsOfStart
{
    /// <summary>
    /// Debot handle which references an instance of debot engine.
    /// </summary>
    [JsonPropertyName("debot_handle")]
    public uint DebotHandle { get; init; }
}