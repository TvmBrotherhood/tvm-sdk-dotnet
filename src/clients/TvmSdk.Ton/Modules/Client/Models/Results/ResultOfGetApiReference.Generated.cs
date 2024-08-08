namespace TvmSdk.Ton.Modules.Client;

public record ResultOfGetApiReference
{
    [JsonPropertyName("api")]
    public API Api { get; init; }
}