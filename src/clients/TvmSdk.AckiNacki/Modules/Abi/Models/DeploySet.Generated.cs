namespace TvmSdk.AckiNacki.Modules.Abi;

public record DeploySet
{
    /// <summary>
    /// Content of TVC file encoded in <c>base64</c>.<para/>
    /// For compatibility reason this field can contain an encoded  <c>StateInit</c>.
    /// </summary>
    [JsonPropertyName("tvc")]
    public string? Tvc { get; init; }

    /// <summary>
    /// Contract code BOC encoded with base64.
    /// </summary>
    [JsonPropertyName("code")]
    public string? Code { get; init; }

    /// <summary>
    /// State init BOC encoded with base64.
    /// </summary>
    [JsonPropertyName("state_init")]
    public string? StateInit { get; init; }

    /// <remarks>
    /// Default is <c>0</c>.
    /// </remarks>
    [JsonPropertyName("workchain_id")]
    public int? WorkchainId { get; init; }

    /// <summary>
    /// List of initial values for contract's public variables.
    /// </summary>
    [JsonPropertyName("initial_data")]
    public JsonElement? InitialData { get; init; }

    /// <remarks>
    /// Public key resolving priority: 1.<para/>
    /// Public key from deploy set.<para/>
    /// 2.<para/>
    /// Public key, specified in TVM file.<para/>
    /// 3.<para/>
    /// Public key, provided by Signer.<para/>
    /// Applicable only for contracts with ABI version &amp;lt; 2.4.<para/>
    /// Contract initial public key should be explicitly provided inside <c>initial_data</c> since ABI 2.4.
    /// </remarks>
    [JsonPropertyName("initial_pubkey")]
    public string? InitialPubkey { get; init; }
}