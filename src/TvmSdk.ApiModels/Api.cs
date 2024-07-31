namespace TvmSdk.ApiModels;

// Named all in upper case (API) because in such way it is referenced in schema.
public record API(string Version, ApiModule[] Modules);