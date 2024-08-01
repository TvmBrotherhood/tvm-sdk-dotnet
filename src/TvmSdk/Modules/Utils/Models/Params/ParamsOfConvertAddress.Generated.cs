namespace TvmSdk.Modules.Utils;

public record ParamsOfConvertAddress
{
    /// <summary>
    /// Account address in any TON format.
    /// </summary>
    [JsonPropertyName("address")]
    public string Address { get; init; }

    /// <summary>
    /// Specify the format to convert to.
    /// </summary>
    [JsonPropertyName("output_format")]
    public AddressStringFormat OutputFormat { get; init; }
}