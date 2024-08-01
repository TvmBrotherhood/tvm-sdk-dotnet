namespace TvmSdk.Modules.Abi;

public record ParamsOfDecodeMessageBody
{
    /// <summary>
    /// Contract ABI used to decode.
    /// </summary>
    [JsonPropertyName("abi")]
    public Abi Abi { get; init; }

    /// <summary>
    /// Message body BOC encoded in <c>base64</c>.
    /// </summary>
    [JsonPropertyName("body")]
    public string Body { get; init; }

    /// <summary>
    /// True if the body belongs to the internal message.
    /// </summary>
    [JsonPropertyName("is_internal")]
    public bool IsInternal { get; init; }

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