namespace TvmSdk.Everscale.Modules.Net;

public record OrderBy
{
    [JsonPropertyName("path")]
    public string Path { get; init; }

    [JsonPropertyName("direction")]
    public SortDirection Direction { get; init; }
}