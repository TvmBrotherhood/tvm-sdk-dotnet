namespace TvmSdk.Interop.Enums;

public enum FunctionExecutionStatus
{
    Success = 0,

    Error = 1,

    /// <summary>
    /// In combination with finished = true signals that the request handling was finished.
    /// </summary>
    NoOperation = 2,

    AppRequest = 3,

    AppNotify = 4,

    Custom = 100
}