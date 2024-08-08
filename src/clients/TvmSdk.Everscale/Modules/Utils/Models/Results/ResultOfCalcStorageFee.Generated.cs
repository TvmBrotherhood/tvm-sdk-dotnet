namespace TvmSdk.Everscale.Modules.Utils;

public record ResultOfCalcStorageFee
{
    [JsonPropertyName("fee")]
    public string Fee { get; init; }
}