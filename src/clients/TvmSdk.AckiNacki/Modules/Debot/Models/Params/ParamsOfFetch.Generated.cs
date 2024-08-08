namespace TvmSdk.AckiNacki.Modules.Debot;

/// <summary>
/// <a href="UNSTABLE.md">UNSTABLE</a><a href="DEPRECATED.md">DEPRECATED</a> Parameters to fetch DeBot metadata.
/// </summary>
public record ParamsOfFetch
{
    /// <summary>
    /// Debot smart contract address.
    /// </summary>
    [JsonPropertyName("address")]
    public string Address { get; init; }
}