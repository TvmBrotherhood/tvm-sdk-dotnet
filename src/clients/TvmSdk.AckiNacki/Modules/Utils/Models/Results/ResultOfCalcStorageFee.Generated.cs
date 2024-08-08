namespace TvmSdk.AckiNacki.Modules.Utils;

public record ResultOfCalcStorageFee
{
    [JsonPropertyName("fee")]
    public string Fee { get; init; }
}