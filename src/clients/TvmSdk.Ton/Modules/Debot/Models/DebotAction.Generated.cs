namespace TvmSdk.Ton.Modules.Debot;

/// <summary>
/// <a href="UNSTABLE.md">UNSTABLE</a><a href="DEPRECATED.md">DEPRECATED</a> Describes a debot action in a Debot Context.
/// </summary>
public record DebotAction
{
    /// <remarks>
    /// Should be used by Debot Browser as name of menu item.
    /// </remarks>
    [JsonPropertyName("description")]
    public string Description { get; init; }

    /// <remarks>
    /// Can be a debot function name or a print string (for Print Action).
    /// </remarks>
    [JsonPropertyName("name")]
    public string Name { get; init; }

    /// <summary>
    /// Action type.
    /// </summary>
    [JsonPropertyName("action_type")]
    public byte ActionType { get; init; }

    /// <summary>
    /// ID of debot context to switch after action execution.
    /// </summary>
    [JsonPropertyName("to")]
    public byte To { get; init; }

    /// <remarks>
    /// In the form of "param=value,flag".<para/>
    /// Attribute example: instant, args, fargs, sign.
    /// </remarks>
    [JsonPropertyName("attributes")]
    public string Attributes { get; init; }

    /// <remarks>
    /// Used by debot only.
    /// </remarks>
    [JsonPropertyName("misc")]
    public string Misc { get; init; }
}