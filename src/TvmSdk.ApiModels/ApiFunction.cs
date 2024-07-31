namespace TvmSdk.ApiModels;

public record ApiFunction : ApiBaseTypeInfo
{
    public required ApiModelProperty[] Params { get; init; }

    public required ApiModelProperty Result { get; init; }

    public required string Errors { get; init; } // TODO: type is not string
}