namespace TvmSdk.Modules.Client;

public record AbiConfig
{
    /// <summary>
    /// Workchain id that is used by default in DeploySet.
    /// </summary>
    [JsonPropertyName("workchain")]
    public int? Workchain { get; init; }

    /// <remarks>
    /// Must be specified in milliseconds.<para/>
    /// Default is 40000 (40 sec).
    /// </remarks>
    [JsonPropertyName("message_expiration_timeout")]
    public uint? MessageExpirationTimeout { get; init; }

    /// <remarks>
    /// Default is 1.5.
    /// </remarks>
    [JsonPropertyName("message_expiration_timeout_grow_factor")]
    public float? MessageExpirationTimeoutGrowFactor { get; init; }
}