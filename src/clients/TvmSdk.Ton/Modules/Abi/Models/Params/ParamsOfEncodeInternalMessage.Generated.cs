namespace TvmSdk.Ton.Modules.Abi;

public record ParamsOfEncodeInternalMessage
{
    /// <remarks>
    /// Can be None if both deploy_set and call_set are None.
    /// </remarks>
    [JsonPropertyName("abi")]
    public Abi? Abi { get; init; }

    /// <remarks>
    /// Must be specified in case of non-deploy message.
    /// </remarks>
    [JsonPropertyName("address")]
    public string? Address { get; init; }

    /// <summary>
    /// Source address of the message.
    /// </summary>
    [JsonPropertyName("src_address")]
    public string? SrcAddress { get; init; }

    /// <remarks>
    /// Must be specified in case of deploy message.
    /// </remarks>
    [JsonPropertyName("deploy_set")]
    public DeploySet? DeploySet { get; init; }

    /// <remarks>
    /// Must be specified in case of non-deploy message.<para/>
    /// In case of deploy message it is optional and contains parameters of the functions that will to be called upon deploy transaction.
    /// </remarks>
    [JsonPropertyName("call_set")]
    public CallSet? CallSet { get; init; }

    /// <summary>
    /// Value in nanotokens to be sent with message.
    /// </summary>
    [JsonPropertyName("value")]
    public string Value { get; init; }

    /// <remarks>
    /// Default is true.
    /// </remarks>
    [JsonPropertyName("bounce")]
    public bool? Bounce { get; init; }

    /// <remarks>
    /// Default is false.
    /// </remarks>
    [JsonPropertyName("enable_ihr")]
    public bool? EnableIhr { get; init; }
}