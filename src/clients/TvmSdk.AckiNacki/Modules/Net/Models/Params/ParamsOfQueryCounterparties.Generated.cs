namespace TvmSdk.AckiNacki.Modules.Net;

public record ParamsOfQueryCounterparties
{
    /// <summary>
    /// Account address.
    /// </summary>
    [JsonPropertyName("account")]
    public string Account { get; init; }

    /// <summary>
    /// Projection (result) string.
    /// </summary>
    [JsonPropertyName("result")]
    public string Result { get; init; }

    /// <summary>
    /// Number of counterparties to return.
    /// </summary>
    [JsonPropertyName("first")]
    public uint? First { get; init; }

    /// <summary>
    /// <c>cursor</c> field of the last received result.
    /// </summary>
    [JsonPropertyName("after")]
    public string? After { get; init; }
}