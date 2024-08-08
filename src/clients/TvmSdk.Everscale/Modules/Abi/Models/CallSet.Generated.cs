namespace TvmSdk.Everscale.Modules.Abi;

public record CallSet
{
    /// <summary>
    /// Function name that is being called.<para/>
    /// Or function id encoded as string in hex (starting with 0x).
    /// </summary>
    [JsonPropertyName("function_name")]
    public string FunctionName { get; init; }

    /// <remarks>
    /// If an application omits some header parameters required by the contract's ABI, the library will set the default values for them.
    /// </remarks>
    [JsonPropertyName("header")]
    public FunctionHeader? Header { get; init; }

    /// <summary>
    /// Function input parameters according to ABI.
    /// </summary>
    [JsonPropertyName("input")]
    public JsonElement? Input { get; init; }
}