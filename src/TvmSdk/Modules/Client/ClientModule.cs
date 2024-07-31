namespace TvmSdk.Modules.Client;

/// <summary>
/// Provides information about library.
/// </summary>
public class ClientModule(ITvmClient client) : IClientModule
{
    /// <summary>
    /// Returns Core Library API reference.
    /// </summary>
    public Task<ResultOfGetApiReference> GetApiReference()
    {
        return client.CallFunction<ResultOfGetApiReference>("client.get_api_reference");
    }

    /// <summary>
    /// Returns Core Library version.
    /// </summary>
    public Task<ResultOfVersion> Version()
    {
        return client.CallFunction<ResultOfVersion>("client.version");
    }

    /// <summary>
    /// Returns Core Library API reference.
    /// </summary>
    public Task<ClientConfig> Config()
    {
        return client.CallFunction<ClientConfig>("client.config");
    }

    /// <summary>
    /// Returns detailed information about this build.
    /// </summary>
    public Task<ResultOfBuildInfo> BuildInfo()
    {
        return client.CallFunction<ResultOfBuildInfo>("client.build_info");
    }

    /// <summary>
    /// Resolves application request processing result.
    /// </summary>
    public Task ResolveAppRequest(ParamsOfResolveAppRequest @params)
    {
        return client.CallFunction("client.resolve_app_request", @params);
    }
}