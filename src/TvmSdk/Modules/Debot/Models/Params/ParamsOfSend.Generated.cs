namespace TvmSdk.Modules.Debot;

/// <summary>
/// <a href="UNSTABLE.md">UNSTABLE</a><a href="DEPRECATED.md">DEPRECATED</a> Parameters of <c>send</c> function.
/// </summary>
public record ParamsOfSend
{
    /// <summary>
    /// Debot handle which references an instance of debot engine.
    /// </summary>
    [JsonPropertyName("debot_handle")]
    public uint DebotHandle { get; init; }

    /// <summary>
    /// BOC of internal message to debot encoded in base64 format.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; init; }
}