namespace TvmSdk.AckiNacki.Modules.Utils;

public record ParamsOfGetAddressType
{
    /// <summary>
    /// Account address in any TON format.
    /// </summary>
    [JsonPropertyName("address")]
    public string Address { get; init; }
}