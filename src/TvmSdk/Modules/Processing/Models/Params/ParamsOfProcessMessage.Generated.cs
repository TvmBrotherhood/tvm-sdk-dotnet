namespace TvmSdk.Modules.Processing;

public record ParamsOfProcessMessage
{
    /// <summary>
    /// Message encode parameters.
    /// </summary>
    [JsonPropertyName("message_encode_params")]
    public Abi.ParamsOfEncodeMessage MessageEncodeParams { get; init; }

    /// <summary>
    /// Flag for requesting events sending.<para/>
    /// Default is <c>false</c>.
    /// </summary>
    [JsonPropertyName("send_events")]
    public bool? SendEvents { get; init; }
}