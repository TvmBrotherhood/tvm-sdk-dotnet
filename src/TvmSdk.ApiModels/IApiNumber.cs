namespace TvmSdk.ApiModels;

public interface IApiNumber
{
    byte NumberSize { get; init; }
    
    ApiNumberType NumberType { get; init; }
}