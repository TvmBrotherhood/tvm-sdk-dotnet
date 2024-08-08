namespace TvmSdk.AckiNacki.Modules.Utils;

public record ParamsOfCalcStorageFee
{
    [JsonPropertyName("account")]
    public string Account { get; init; }

    [JsonPropertyName("period")]
    public uint Period { get; init; }
}