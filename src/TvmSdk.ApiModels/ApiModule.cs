namespace TvmSdk.ApiModels;

public record ApiModule : ApiBaseTypeInfo
{
    public required ApiModel[] Types { get; init; }

    public required ApiFunction[] Functions { get; init; }
}