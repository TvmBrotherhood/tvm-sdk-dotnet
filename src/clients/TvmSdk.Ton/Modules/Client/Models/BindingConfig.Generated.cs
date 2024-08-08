namespace TvmSdk.Ton.Modules.Client;

public record BindingConfig
{
    [JsonPropertyName("library")]
    public string? Library { get; init; }

    [JsonPropertyName("version")]
    public string? Version { get; init; }
}