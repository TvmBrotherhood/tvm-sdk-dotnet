namespace TvmSdk.ApiModels;

public interface IApiGeneric
{
    ApiGenericName GenericName { get; init; }
    
    ApiModelProperty[] GenericArgs { get; init; }
}