namespace TvmSdk.Interop.Models;

public record ResultOfFunctionCall<T>
{
    [JsonPropertyName("result")]
    public T? Result { get; init; }
    
    [JsonPropertyName("error")]
    public ClientError? Error { get; init; }
}