namespace TvmSdk.Modules.Debot;

/// <summary>
/// <a href="UNSTABLE.md">UNSTABLE</a><a href="DEPRECATED.md">DEPRECATED</a> Describes DeBot metadata.
/// </summary>
public record DebotInfo
{
    /// <summary>
    /// DeBot short name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// DeBot semantic version.
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; init; }

    /// <summary>
    /// The name of DeBot deployer.
    /// </summary>
    [JsonPropertyName("publisher")]
    public string? Publisher { get; init; }

    /// <summary>
    /// Short info about DeBot.
    /// </summary>
    [JsonPropertyName("caption")]
    public string? Caption { get; init; }

    /// <summary>
    /// The name of DeBot developer.
    /// </summary>
    [JsonPropertyName("author")]
    public string? Author { get; init; }

    /// <summary>
    /// TON address of author for questions and donations.
    /// </summary>
    [JsonPropertyName("support")]
    public string? Support { get; init; }

    /// <summary>
    /// String with the first messsage from DeBot.
    /// </summary>
    [JsonPropertyName("hello")]
    public string? Hello { get; init; }

    /// <summary>
    /// String with DeBot interface language (ISO-639).
    /// </summary>
    [JsonPropertyName("language")]
    public string? Language { get; init; }

    /// <summary>
    /// String with DeBot ABI.
    /// </summary>
    [JsonPropertyName("dabi")]
    public string? Dabi { get; init; }

    /// <summary>
    /// DeBot icon.
    /// </summary>
    [JsonPropertyName("icon")]
    public string? Icon { get; init; }

    /// <summary>
    /// Vector with IDs of DInterfaces used by DeBot.
    /// </summary>
    [JsonPropertyName("interfaces")]
    public string[] Interfaces { get; init; }

    /// <summary>
    /// ABI version ("x.y") supported by DeBot.
    /// </summary>
    [JsonPropertyName("dabiVersion")]
    public string DabiVersion { get; init; }
}