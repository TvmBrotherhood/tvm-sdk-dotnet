namespace TvmSdk.Modules.Tvm;

public record ParamsOfRunTvm
{
    /// <remarks>
    /// Must be encoded as base64.
    /// </remarks>
    [JsonPropertyName("message")]
    public string Message { get; init; }

    /// <remarks>
    /// Must be encoded as base64.
    /// </remarks>
    [JsonPropertyName("account")]
    public string Account { get; init; }

    /// <summary>
    /// Execution options.
    /// </summary>
    [JsonPropertyName("execution_options")]
    public ExecutionOptions? ExecutionOptions { get; init; }

    /// <summary>
    /// Contract ABI for decoding output messages.
    /// </summary>
    [JsonPropertyName("abi")]
    public Abi.Abi? Abi { get; init; }

    /// <remarks>
    /// The BOC itself returned if no cache type provided.
    /// </remarks>
    [JsonPropertyName("boc_cache")]
    public Boc.BocCacheType? BocCache { get; init; }

    /// <remarks>
    /// Empty string is returned if the flag is <c>false</c>.
    /// </remarks>
    [JsonPropertyName("return_updated_account")]
    public bool? ReturnUpdatedAccount { get; init; }
}