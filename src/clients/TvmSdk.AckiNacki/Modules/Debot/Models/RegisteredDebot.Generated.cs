namespace TvmSdk.AckiNacki.Modules.Debot;

/// <summary>
/// <a href="UNSTABLE.md">UNSTABLE</a><a href="DEPRECATED.md">DEPRECATED</a> Structure for storing debot handle returned from <c>init</c> function.
/// </summary>
public record RegisteredDebot
{
    /// <summary>
    /// Debot handle which references an instance of debot engine.
    /// </summary>
    [JsonPropertyName("debot_handle")]
    public uint DebotHandle { get; init; }

    /// <summary>
    /// Debot abi as json string.
    /// </summary>
    [JsonPropertyName("debot_abi")]
    public string DebotAbi { get; init; }

    /// <summary>
    /// Debot metadata.
    /// </summary>
    [JsonPropertyName("info")]
    public DebotInfo Info { get; init; }
}