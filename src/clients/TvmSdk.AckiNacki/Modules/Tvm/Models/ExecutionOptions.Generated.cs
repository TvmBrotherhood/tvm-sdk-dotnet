namespace TvmSdk.AckiNacki.Modules.Tvm;

public record ExecutionOptions
{
    /// <summary>
    /// Boc with config.
    /// </summary>
    [JsonPropertyName("blockchain_config")]
    public string? BlockchainConfig { get; init; }

    /// <summary>
    /// Time that is used as transaction time.
    /// </summary>
    [JsonPropertyName("block_time")]
    public uint? BlockTime { get; init; }

    /// <summary>
    /// Block logical time.
    /// </summary>
    [JsonPropertyName("block_lt")]
    public ulong? BlockLt { get; init; }

    /// <summary>
    /// Transaction logical time.
    /// </summary>
    [JsonPropertyName("transaction_lt")]
    public ulong? TransactionLt { get; init; }

    /// <summary>
    /// Overrides standard TVM behaviour.<para/>
    /// If set to <c>true</c> then CHKSIG always will return <c>true</c>.
    /// </summary>
    [JsonPropertyName("chksig_always_succeed")]
    public bool? ChksigAlwaysSucceed { get; init; }

    /// <summary>
    /// Signature ID to be used in signature verifying instructions when CapSignatureWithId capability is enabled.
    /// </summary>
    [JsonPropertyName("signature_id")]
    public int? SignatureId { get; init; }
}