namespace TvmSdk.Everscale.Modules.Boc;

public record ResultOfDecodeStateInit
{
    /// <summary>
    /// Contract code BOC encoded as base64 or BOC handle.
    /// </summary>
    [JsonPropertyName("code")]
    public string? Code { get; init; }

    /// <summary>
    /// Contract code hash.
    /// </summary>
    [JsonPropertyName("code_hash")]
    public string? CodeHash { get; init; }

    /// <summary>
    /// Contract code depth.
    /// </summary>
    [JsonPropertyName("code_depth")]
    public uint? CodeDepth { get; init; }

    /// <summary>
    /// Contract data BOC encoded as base64 or BOC handle.
    /// </summary>
    [JsonPropertyName("data")]
    public string? Data { get; init; }

    /// <summary>
    /// Contract data hash.
    /// </summary>
    [JsonPropertyName("data_hash")]
    public string? DataHash { get; init; }

    /// <summary>
    /// Contract data depth.
    /// </summary>
    [JsonPropertyName("data_depth")]
    public uint? DataDepth { get; init; }

    /// <summary>
    /// Contract library BOC encoded as base64 or BOC handle.
    /// </summary>
    [JsonPropertyName("library")]
    public string? Library { get; init; }

    /// <remarks>
    /// Specifies the contract ability to handle tick transactions.
    /// </remarks>
    [JsonPropertyName("tick")]
    public bool? Tick { get; init; }

    /// <remarks>
    /// Specifies the contract ability to handle tock transactions.
    /// </remarks>
    [JsonPropertyName("tock")]
    public bool? Tock { get; init; }

    /// <summary>
    /// Is present and non-zero only in instances of large smart contracts.
    /// </summary>
    [JsonPropertyName("split_depth")]
    public uint? SplitDepth { get; init; }

    /// <summary>
    /// Compiler version, for example 'sol 0.49.0'.
    /// </summary>
    [JsonPropertyName("compiler_version")]
    public string? CompilerVersion { get; init; }
}