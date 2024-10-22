namespace TvmSdk.Modules.Client;

public record ResultOfVersion
{
    /// <summary>
    /// Core Library version.
    /// </summary>
    [JsonPropertyName("version")]
    public string Version { get; init; }
}