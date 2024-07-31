using TvmSdk.Interop.Enums;
using TvmSdk.Interop.Models;

namespace TvmSdk;

public interface ITvmClient : IDisposable
{
    Task CallFunction(string functionName, object? paramsJson = null);
    Task<T> CallFunction<T>(string functionName, object? paramsJson = null);
    Task<T> CallFunction<T, TCallback>(string functionName, object? paramsJson = null, Action<TCallback, FunctionExecutionStatus> callack = null, Func<string, Task> func = null);
    ResultOfFunctionCall<T> CallFunctionSync<T>(string name, object? paramsJson = null);
}
