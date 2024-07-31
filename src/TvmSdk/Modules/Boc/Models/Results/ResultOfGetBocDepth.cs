namespace TvmSdk.Modules.Boc;

public record ResultOfGetBocDepth
{
    /// <summary>
    /// BOC root cell depth.
    /// </summary>
    [JsonPropertyName("depth")]
    public uint Depth { get; init; }
}