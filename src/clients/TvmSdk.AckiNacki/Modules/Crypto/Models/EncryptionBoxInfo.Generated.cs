namespace TvmSdk.AckiNacki.Modules.Crypto;

/// <summary>
/// Encryption box information.
/// </summary>
public record EncryptionBoxInfo
{
    /// <summary>
    /// Derivation path, for instance "m/44'/396'/0'/0/0".
    /// </summary>
    [JsonPropertyName("hdpath")]
    public string? Hdpath { get; init; }

    /// <summary>
    /// Cryptographic algorithm, used by this encryption box.
    /// </summary>
    [JsonPropertyName("algorithm")]
    public string? Algorithm { get; init; }

    /// <summary>
    /// Options, depends on algorithm and specific encryption box implementation.
    /// </summary>
    [JsonPropertyName("options")]
    public JsonElement? Options { get; init; }

    /// <summary>
    /// Public information, depends on algorithm.
    /// </summary>
    [JsonPropertyName("public")]
    public JsonElement? Public { get; init; }
}