namespace TvmSdk.Modules.Processing;

public record ParamsOfSendMessage
{
    /// <summary>
    /// Message BOC.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; init; }

    /// <remarks>
    /// If this parameter is specified and the message has the <c>expire</c> header then expiration time will be checked against the current time to prevent unnecessary sending of already expired message.<para/>
    /// The <c>message already expired</c> error will be returned in this case.<para/>
    /// Note, that specifying <c>abi</c> for ABI compliant contracts is strongly recommended, so that proper processing strategy can be chosen.
    /// </remarks>
    [JsonPropertyName("abi")]
    public Abi.Abi? Abi { get; init; }

    /// <summary>
    /// Flag for requesting events sending.<para/>
    /// Default is <c>false</c>.
    /// </summary>
    [JsonPropertyName("send_events")]
    public bool? SendEvents { get; init; }
}