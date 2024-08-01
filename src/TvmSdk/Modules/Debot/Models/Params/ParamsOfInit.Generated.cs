namespace TvmSdk.Modules.Debot;

/// <summary>
/// <a href="UNSTABLE.md">UNSTABLE</a><a href="DEPRECATED.md">DEPRECATED</a> Parameters to init DeBot.
/// </summary>
public record ParamsOfInit
{
    /// <summary>
    /// Debot smart contract address.
    /// </summary>
    [JsonPropertyName("address")]
    public string Address { get; init; }
}