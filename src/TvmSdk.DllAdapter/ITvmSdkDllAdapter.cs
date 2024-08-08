namespace TvmSdk.DllAdapter;

public interface ITvmSdkDllAdapter
{
    Task CallMethod(string methodName);
    Task<TResult> CallMethod<TResult>(string methodName);
    Task CallMethod<TParams>(string methodName, TParams @params);
    Task<TResult> CallMethod<TParams, TResult>(string methodName, TParams @params);
}