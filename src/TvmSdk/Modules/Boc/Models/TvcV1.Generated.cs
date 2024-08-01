namespace TvmSdk.Modules.Boc;

public record TvcV1
{
    [JsonPropertyName("code")]
    public string? Code { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }
}