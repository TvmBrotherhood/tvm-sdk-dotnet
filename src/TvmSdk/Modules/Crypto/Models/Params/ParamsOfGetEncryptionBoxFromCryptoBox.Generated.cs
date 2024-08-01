namespace TvmSdk.Modules.Crypto;

public record ParamsOfGetEncryptionBoxFromCryptoBox
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
    /// Encryption algorithm.
    /// </summary>
    [JsonPropertyName("algorithm")]
    public BoxEncryptionAlgorithm Algorithm { get; init; }

    /// <summary>
    /// Store derived secret for encryption algorithm for this lifetime (in ms).<para/>
    /// The timer starts after each encryption box operation.<para/>
    /// Secrets will be deleted (overwritten with zeroes) after each encryption operation, if this value is not set.
    /// </summary>
    [JsonPropertyName("secret_lifetime")]
    public uint? SecretLifetime { get; init; }
}