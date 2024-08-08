namespace TvmSdk.AckiNacki.Modules.Processing;

public record MessageMonitoringParams
{
    /// <summary>
    /// Monitored message identification.<para/>
    /// Can be provided as a message's BOC or (hash, address) pair.<para/>
    /// BOC is a preferable way because it helps to determine possible error reason (using TVM execution of the message).
    /// </summary>
    [JsonPropertyName("message")]
    public MonitoredMessage Message { get; init; }

    /// <summary>
    /// Block time Must be specified as a UNIX timestamp in seconds.
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