namespace TvmSdk.AckiNacki.Modules.Processing;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MonitorFetchWaitMode : byte
{
    /// <summary>
    /// If there are no resolved results yet, then monitor awaits for the next resolved result.
    /// </summary>
    AtLeastOne,
    /// <summary>
    /// Monitor waits until all unresolved messages will be resolved.<para/>
    /// If there are no unresolved messages then monitor will wait.
    /// </summary>
    All,
    NoWait
}