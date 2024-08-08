namespace TvmSdk.Everscale.Modules.Abi;

public record ResultOfCalcFunctionId
{
    /// <summary>
    /// Contract function ID.
    /// </summary>
    [JsonPropertyName("function_id")]
    public uint FunctionId { get; init; }
}