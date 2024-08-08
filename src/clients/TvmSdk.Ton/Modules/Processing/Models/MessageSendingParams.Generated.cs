namespace TvmSdk.Ton.Modules.Processing;

public record MessageSendingParams
{
    /// <summary>
    /// BOC of the message, that must be sent to the blockchain.
    /// </summary>
    [JsonPropertyName("boc")]
    public string Boc { get; init; }

    /// <summary>
    /// Expiration time of the message.<para/>
    /// Must be specified as a UNIX timestamp in seconds.
    /// </summary>
    [JsonPropertyName("wait_until")]
    public uint WaitUntil { get; init; }

    /// <summary>
    /// User defined data associated with this message.<para/>
    /// Helps to identify this message when user received <c>MessageMonitoringResult</c>.
    /// </summary>
    [JsonPropertyName("user_data")]
    public JsonElement? UserData { get; init; }
}