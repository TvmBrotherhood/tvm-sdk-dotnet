using TvmSdk.DllAdapter;

namespace TvmSdk.AckiNacki.Modules.Client;

/// <summary>
/// Provides information about library.
/// </summary>
public class ClientModule(ITvmSdkDllAdapter adapter) : IClientModule
{
    /// <summary>
    /// Returns Core Library API reference.
    /// </summary>
    public Task<ResultOfGetApiReference> GetApiReference()
    {
        return adapter.CallMethod<ResultOfGetApiReference>("client.get_api_reference");
    }

    /// <summary>
    /// Returns Core Library version.
    /// </summary>
    public Task<ResultOfVersion> Version()
    {
        return adapter.CallMethod<ResultOfVersion>("client.version");
    }

    /// <summary>
    /// Returns Core Library API reference.
    /// </summary>
    public Task<ClientConfig> Config()
    {
        return adapter.CallMethod<ClientConfig>("client.config");
    }

    /// <summary>
    /// Returns detailed information about this build.
    /// </summary>
    public Task<ResultOfBuildInfo> BuildInfo()
    {
        return adapter.CallMethod<ResultOfBuildInfo>("client.build_info");
    }

    /// <summary>
    /// Resolves application request processing result.
    /// </summary>
    public Task ResolveAppRequest(ParamsOfResolveAppRequest @params)
    {
        return adapter.CallMethod("client.resolve_app_request", @params);
    }
}