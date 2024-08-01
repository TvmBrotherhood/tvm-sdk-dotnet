namespace TvmSdk.Modules.Abi;

public record ParamsOfCalcFunctionId
{
    /// <summary>
    /// Contract ABI.
    /// </summary>
    [JsonPropertyName("abi")]
    public Abi Abi { get; init; }

    /// <summary>
    /// Contract function name.
    /// </summary>
    [JsonPropertyName("function_name")]
    public string FunctionName { get; init; }

    /// <summary>
    /// If set to <c>true</c> output function ID will be returned which is used in contract response.<para/>
    /// Default is <c>false</c>.
    /// </summary>
    [JsonPropertyName("output")]
    public bool? Output { get; init; }
}