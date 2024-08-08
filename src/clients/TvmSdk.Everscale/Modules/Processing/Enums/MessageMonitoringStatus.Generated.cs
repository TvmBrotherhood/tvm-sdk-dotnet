namespace TvmSdk.Everscale.Modules.Processing;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MessageMonitoringStatus : byte
{
    /// <summary>
    /// Returned when the messages was processed and included into finalized block before <c>wait_until</c> block time.
    /// </summary>
    Finalized,
    /// <summary>
    /// Returned when the message was not processed until <c>wait_until</c> block time.
    /// </summary>
    Timeout,
    /// <remarks>
    /// Is never returned.<para/>
    /// Application should wait for one of the <c>Finalized</c> or <c>Timeout</c> statuses.<para/>
    /// All other statuses are intermediate.
    /// </remarks>
    Reserved
}