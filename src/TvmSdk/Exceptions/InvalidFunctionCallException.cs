using TvmSdk.Interop.Enums;

namespace TvmSdk.Exceptions;

public class InvalidFunctionCallException(string message, ErrorCode code, JsonElement errorData) : Exception(message)
{
    public ErrorCode Code { get; } = code;

    public object ErrorData { get; } = errorData;
}