namespace TvmSdk.Modules.Crypto;

public record ParamsOfGetSigningBoxFromCryptoBox
{
    /// <summary>
    /// Crypto Box Handle.
    /// </summary>
    [JsonPropertyName("handle")]
    public uint Handle { get; init; }

    /// <remarks>
    /// By default, Everscale HD path is used.
    /// </remarks>
    [JsonPropertyName("hdpath")]
    public string? Hdpath { get; init; }

    /// <summary>
    /// Store derived secret for this lifetime (in ms).<para/>
    /// The timer starts after each signing box operation.<para/>
    /// Secrets will be deleted immediately after each signing box operation, if this value is not set.
    /// </summary>
    [JsonPropertyName("secret_lifetime")]
    public uint? SecretLifetime { get; init; }
}