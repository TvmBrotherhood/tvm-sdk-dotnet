namespace TvmSdk.AckiNacki.Modules.Abi;

/// <remarks>
/// Includes several hidden function parameters that contract uses for security, message delivery monitoring and replay protection reasons.<para/>
/// The actual set of header fields depends on the contract's ABI.<para/>
/// If a contract's ABI does not include some headers, then they are not filled.
/// </remarks>
public record FunctionHeader
{
    /// <remarks>
    /// If not specified - calculated automatically from message_expiration_timeout(), try_index and message_expiration_timeout_grow_factor() (if ABI includes <c>expire</c> header).
    /// </remarks>
    [JsonPropertyName("expire")]
    public uint? Expire { get; init; }

    /// <remarks>
    /// If not specified, <c>now</c> is used (if ABI includes <c>time</c> header).
    /// </remarks>
    [JsonPropertyName("time")]
    public ulong? Time { get; init; }

    /// <remarks>
    /// Encoded in <c>hex</c>.<para/>
    /// If not specified, method fails with exception (if ABI includes <c>pubkey</c> header)..
    /// </remarks>
    [JsonPropertyName("pubkey")]
    public string? Pubkey { get; init; }
}