using System.Runtime.InteropServices;

namespace TvmSdk.DllAdapter;

public class TvmSdkDllAdapter : ITvmSdkDllAdapter
{
    public Task CallMethod(string methodName)
    {
        throw new NotImplementedException();
    }
    
    public Task<TResult> CallMethod<TResult>(string methodName)
    {
        throw new NotImplementedException();
    }

    public Task CallMethod<TParams>(string methodName, TParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<TResult> CallMethod<TParams, TResult>(string methodName, TParams @params)
    {
        throw new NotImplementedException();
    }
}