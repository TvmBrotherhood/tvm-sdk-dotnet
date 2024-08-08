namespace TvmSdk.Ton.Modules.Client;

public record NetworkConfig
{
    /// <summary>
    /// **This field is deprecated, but left for backward-compatibility.** Evernode endpoint.
    /// </summary>
    [JsonPropertyName("server_address")]
    public string? ServerAddress { get; init; }

    /// <remarks>
    /// Any correct URL format can be specified, including IP addresses.<para/>
    /// This parameter is prevailing over <c>server_address</c>.<para/>
    /// Check the full list of <a href="https://docs.evercloud.dev/products/evercloud/networks-endpoints">supported network endpoints</a>.
    /// </remarks>
    [JsonPropertyName("endpoints")]
    public string[]? Endpoints { get; init; }

    /// <remarks>
    /// You must use <c>network.max_reconnect_timeout</c> that allows to specify maximum network resolving timeout.
    /// </remarks>
    [JsonPropertyName("network_retries_count")]
    public sbyte? NetworkRetriesCount { get; init; }

    /// <remarks>
    /// Must be specified in milliseconds.<para/>
    /// Default is 120000 (2 min).
    /// </remarks>
    [JsonPropertyName("max_reconnect_timeout")]
    public uint? MaxReconnectTimeout { get; init; }

    /// <summary>
    /// Deprecated.
    /// </summary>
    [JsonPropertyName("reconnect_timeout")]
    public uint? ReconnectTimeout { get; init; }

    /// <remarks>
    /// Default is 5.
    /// </remarks>
    [JsonPropertyName("message_retries_count")]
    public sbyte? MessageRetriesCount { get; init; }

    /// <remarks>
    /// Must be specified in milliseconds.<para/>
    /// Default is 40000 (40 sec).
    /// </remarks>
    [JsonPropertyName("message_processing_timeout")]
    public uint? MessageProcessingTimeout { get; init; }

    /// <remarks>
    /// Must be specified in milliseconds.<para/>
    /// Default is 40000 (40 sec).
    /// </remarks>
    [JsonPropertyName("wait_for_timeout")]
    public uint? WaitForTimeout { get; init; }

    /// <summary>
    /// **DEPRECATED**: This parameter was deprecated.
    /// </summary>
    [JsonPropertyName("out_of_sync_threshold")]
    public uint? OutOfSyncThreshold { get; init; }

    /// <remarks>
    /// Default is 1.
    /// </remarks>
    [JsonPropertyName("sending_endpoint_count")]
    public byte? SendingEndpointCount { get; init; }

    /// <remarks>
    /// Library periodically checks the current endpoint for blockchain data synchronization latency.<para/>
    /// If the latency (time-lag) is less then <c>NetworkConfig.max_latency</c> then library selects another endpoint.<para/>
    /// Must be specified in milliseconds.<para/>
    /// Default is 60000 (1 min).
    /// </remarks>
    [JsonPropertyName("latency_detection_interval")]
    public uint? LatencyDetectionInterval { get; init; }

    /// <remarks>
    /// Must be specified in milliseconds.<para/>
    /// Default is 60000 (1 min).
    /// </remarks>
    [JsonPropertyName("max_latency")]
    public uint? MaxLatency { get; init; }

    /// <remarks>
    /// Is is used when no timeout specified for the request to limit the answer waiting time.<para/>
    /// If no answer received during the timeout requests ends with error.<para/>
    /// Must be specified in milliseconds.<para/>
    /// Default is 60000 (1 min).
    /// </remarks>
    [JsonPropertyName("query_timeout")]
    public uint? QueryTimeout { get; init; }

    /// <remarks>
    /// <c>HTTP</c> or <c>WS</c>.<para/>
    /// Default is <c>HTTP</c>.
    /// </remarks>
    [JsonPropertyName("queries_protocol")]
    public NetworkQueriesProtocol? QueriesProtocol { get; init; }

    /// <remarks>
    /// First REMP status awaiting timeout.<para/>
    /// If no status received during the timeout than fallback transaction scenario is activated.<para/>
    /// Must be specified in milliseconds.<para/>
    /// Default is 1 (1 ms) in order to start fallback scenario together with REMP statuses processing while REMP is not properly tuned yet.
    /// </remarks>
    [JsonPropertyName("first_remp_status_timeout")]
    public uint? FirstRempStatusTimeout { get; init; }

    /// <remarks>
    /// Subsequent REMP status awaiting timeout.<para/>
    /// If no status received during the timeout than fallback transaction scenario is activated.<para/>
    /// Must be specified in milliseconds.<para/>
    /// Default is 5000 (5 sec).
    /// </remarks>
    [JsonPropertyName("next_remp_status_timeout")]
    public uint? NextRempStatusTimeout { get; init; }

    /// <remarks>
    /// This parameter should be set to <c>global_id</c> field from any blockchain block if network can not be reachable at the moment of message encoding and the message is aimed to be sent into network with <c>CapSignatureWithId</c> enabled.<para/>
    /// Otherwise signature ID is detected automatically inside message encoding functions.
    /// </remarks>
    [JsonPropertyName("signature_id")]
    public int? SignatureId { get; init; }

    /// <summary>
    /// Access key to GraphQL API (Project secret).
    /// </summary>
    [JsonPropertyName("access_key")]
    public string? AccessKey { get; init; }
}