namespace TvmSdk.AckiNacki.Modules.Crypto;

public record ParamsOfNaclSign
{
    /// <summary>
    /// Data that must be signed encoded in <c>base64</c>.
    /// </summary>
    [JsonPropertyName("unsigned")]
    public string Unsigned { get; init; }

    /// <summary>
    /// Signer's secret key - unprefixed 0-padded to 128 symbols hex string (concatenation of 64 symbols secret and 64 symbols public keys).<para/>
    /// See <c>nacl_sign_keypair_from_secret_key</c>.
    /// </summary>
    [JsonPropertyName("secret")]
    public string Secret { get; init; }
}