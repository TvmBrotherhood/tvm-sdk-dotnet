namespace TvmSdk.Ton.Modules.Utils;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AccountAddressType : byte
{
    AccountId,
    Hex,
    Base64
}