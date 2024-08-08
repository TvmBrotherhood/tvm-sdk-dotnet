namespace TvmSdk.Ton.Modules.Utils;

public record ResultOfConvertAddress
{
    /// <summary>
    /// Address in the specified format.
    /// </summary>
    [JsonPropertyName("address")]
    public string Address { get; init; }
}