namespace TvmSdk.Modules.Crypto;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CipherMode : byte
{
    CBC,
    CFB,
    CTR,
    ECB,
    OFB
}