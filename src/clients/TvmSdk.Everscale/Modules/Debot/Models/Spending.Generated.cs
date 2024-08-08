namespace TvmSdk.Everscale.Modules.Debot;

/// <summary>
/// <a href="UNSTABLE.md">UNSTABLE</a><a href="DEPRECATED.md">DEPRECATED</a> Describes how much funds will be debited from the target  contract balance as a result of the transaction.
/// </summary>
public record Spending
{
    /// <summary>
    /// Amount of nanotokens that will be sent to <c>dst</c> address.
    /// </summary>
    [JsonPropertyName("amount")]
    public ulong Amount { get; init; }

    /// <summary>
    /// Destination address of recipient of funds.
    /// </summary>
    [JsonPropertyName("dst")]
    public string Dst { get; init; }
}