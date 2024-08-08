namespace TvmSdk.AckiNacki.Modules.Client;

/// <summary>
/// Provides information about library.
/// </summary>
public interface IClientModule
{
    /// <summary>
    /// Returns Core Library API reference.
    /// </summary>
    Task<ResultOfGetApiReference> GetApiReference();

    /// <summary>
    /// Returns Core Library version.
    /// </summary>
    Task<ResultOfVersion> Version();

    /// <summary>
    /// Returns Core Library API reference.
    /// </summary>
    Task<ClientConfig> Config();

    /// <summary>
    /// Returns detailed information about this build.
    /// </summary>
    Task<ResultOfBuildInfo> BuildInfo();

    /// <summary>
    /// Resolves application request processing result.
    /// </summary>
    Task ResolveAppRequest(ParamsOfResolveAppRequest @params);
}