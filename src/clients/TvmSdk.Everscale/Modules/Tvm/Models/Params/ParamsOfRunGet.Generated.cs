namespace TvmSdk.Everscale.Modules.Tvm;

public record ParamsOfRunGet
{
    /// <summary>
    /// Account BOC in <c>base64</c>.
    /// </summary>
    [JsonPropertyName("account")]
    public string Account { get; init; }

    /// <summary>
    /// Function name.
    /// </summary>
    [JsonPropertyName("function_name")]
    public string FunctionName { get; init; }

    /// <summary>
    /// Input parameters.
    /// </summary>
    [JsonPropertyName("input")]
    public JsonElement? Input { get; init; }

    /// <summary>
    /// Execution options.
    /// </summary>
    [JsonPropertyName("execution_options")]
    public ExecutionOptions? ExecutionOptions { get; init; }

    /// <remarks>
    /// Default is <c>false</c>.<para/>
    /// Input parameters may use any of lists representations If you receive this error on Web: "Runtime error.<para/>
    /// Unreachable code should not be executed...", set this flag to true.<para/>
    /// This may happen, for example, when elector contract contains too many participants.
    /// </remarks>
    [JsonPropertyName("tuple_list_as_array")]
    public bool? TupleListAsArray { get; init; }
}