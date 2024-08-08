namespace TvmSdk.Ton.Modules.Abi;

public record ParamsOfDecodeMessage
{
    /// <summary>
    /// Contract ABI.
    /// </summary>
    [JsonPropertyName("abi")]
    public Abi Abi { get; init; }

    /// <summary>
    /// Message BOC.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; init; }

    /// <summary>
    /// Flag allowing partial BOC decoding when ABI doesn't describe the full body BOC.<para/>
    /// Controls decoder behaviour when after decoding all described in ABI params there are some data left in BOC: <c>true</c> - return decoded values <c>false</c> - return error of incomplete BOC deserialization (default).
    /// </summary>
    [JsonPropertyName("allow_partial")]
    public bool? AllowPartial { get; init; }

    /// <summary>
    /// Function name or function id if is known in advance.
    /// </summary>
    [JsonPropertyName("function_name")]
    public string? FunctionName { get; init; }

    [JsonPropertyName("data_layout")]
    public DataLayout? DataLayout { get; init; }
}