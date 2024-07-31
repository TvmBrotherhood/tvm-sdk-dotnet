namespace TvmSdk.ApiModels;

public abstract record ApiBaseTypeInfo
{
    public string Name { get; init; } = string.Empty;

    public string? Summary { get; init; }

    public string? Description { get; init; }
}