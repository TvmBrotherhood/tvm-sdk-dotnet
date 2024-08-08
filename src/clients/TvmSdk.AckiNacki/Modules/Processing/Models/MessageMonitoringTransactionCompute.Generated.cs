namespace TvmSdk.AckiNacki.Modules.Processing;

public record MessageMonitoringTransactionCompute
{
    /// <summary>
    /// Compute phase exit code.
    /// </summary>
    [JsonPropertyName("exit_code")]
    public int ExitCode { get; init; }
}