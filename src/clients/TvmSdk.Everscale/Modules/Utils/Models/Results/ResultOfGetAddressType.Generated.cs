namespace TvmSdk.Everscale.Modules.Utils;

public record ResultOfGetAddressType
{
    /// <summary>
    /// Account address type.
    /// </summary>
    [JsonPropertyName("address_type")]
    public AccountAddressType AddressType { get; init; }
}