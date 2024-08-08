namespace TvmSdk.Everscale.Modules.Abi;

public record ParamsOfEncodeAccount
{
    /// <summary>
    /// Account state init.
    /// </summary>
    [JsonPropertyName("state_init")]
    public string StateInit { get; init; }

    /// <summary>
    /// Initial balance.
    /// </summary>
    [JsonPropertyName("balance")]
    public ulong? Balance { get; init; }

    /// <summary>
    /// Initial value for the <c>last_trans_lt</c>.
    /// </summary>
    [JsonPropertyName("last_trans_lt")]
    public ulong? LastTransLt { get; init; }

    /// <summary>
    /// Initial value for the <c>last_paid</c>.
    /// </summary>
    [JsonPropertyName("last_paid")]
    public uint? LastPaid { get; init; }

    /// <remarks>
    /// The BOC itself returned if no cache type provided.
    /// </remarks>
    [JsonPropertyName("boc_cache")]
    public Boc.BocCacheType? BocCache { get; init; }
}