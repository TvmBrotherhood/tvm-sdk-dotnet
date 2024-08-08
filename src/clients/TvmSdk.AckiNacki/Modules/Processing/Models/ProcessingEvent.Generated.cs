using System.Text.Json.Serialization;

namespace TvmSdk.AckiNacki.Modules.Processing;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(WillFetchFirstBlock), typeDiscriminator: "WillFetchFirstBlock")]
[JsonDerivedType(typeof(FetchFirstBlockFailed), typeDiscriminator: "FetchFirstBlockFailed")]
[JsonDerivedType(typeof(WillSend), typeDiscriminator: "WillSend")]
[JsonDerivedType(typeof(DidSend), typeDiscriminator: "DidSend")]
[JsonDerivedType(typeof(SendFailed), typeDiscriminator: "SendFailed")]
[JsonDerivedType(typeof(WillFetchNextBlock), typeDiscriminator: "WillFetchNextBlock")]
[JsonDerivedType(typeof(FetchNextBlockFailed), typeDiscriminator: "FetchNextBlockFailed")]
[JsonDerivedType(typeof(MessageExpired), typeDiscriminator: "MessageExpired")]
[JsonDerivedType(typeof(RempSentToValidators), typeDiscriminator: "RempSentToValidators")]
[JsonDerivedType(typeof(RempIncludedIntoBlock), typeDiscriminator: "RempIncludedIntoBlock")]
[JsonDerivedType(typeof(RempIncludedIntoAcceptedBlock), typeDiscriminator: "RempIncludedIntoAcceptedBlock")]
[JsonDerivedType(typeof(RempOther), typeDiscriminator: "RempOther")]
[JsonDerivedType(typeof(RempError), typeDiscriminator: "RempError")]
public abstract record ProcessingEvent
{
    /// <remarks>
    /// Fetched block will be used later in waiting phase.
    /// </remarks>
    public record WillFetchFirstBlock : ProcessingEvent
    {
        [JsonPropertyName("message_id")]
        public string MessageId { get; init; }

        [JsonPropertyName("message_dst")]
        public string MessageDst { get; init; }
    }

    /// <remarks>
    /// This may happen due to the network issues.<para/>
    /// Receiving this event means that message processing will not proceed - message was not sent, and Developer can try to run <c>process_message</c> again, in the hope that the connection is restored.
    /// </remarks>
    public record FetchFirstBlockFailed : ProcessingEvent
    {
        [JsonPropertyName("error")]
        public Client.ClientError Error { get; init; }

        [JsonPropertyName("message_id")]
        public string MessageId { get; init; }

        [JsonPropertyName("message_dst")]
        public string MessageDst { get; init; }
    }

    /// <summary>
    /// Notifies the app that the message will be sent to the network.<para/>
    /// This event means that the account's current shard block was successfully fetched and the message was successfully created (<c>abi.encode_message</c> function was executed successfully).
    /// </summary>
    public record WillSend : ProcessingEvent
    {
        [JsonPropertyName("shard_block_id")]
        public string ShardBlockId { get; init; }

        [JsonPropertyName("message_id")]
        public string MessageId { get; init; }

        [JsonPropertyName("message_dst")]
        public string MessageDst { get; init; }

        [JsonPropertyName("message")]
        public string Message { get; init; }
    }

    /// <remarks>
    /// Do not forget to specify abi of your contract as well, it is crucial for processing.<para/>
    /// See <c>processing.wait_for_transaction</c> documentation.
    /// </remarks>
    public record DidSend : ProcessingEvent
    {
        [JsonPropertyName("shard_block_id")]
        public string ShardBlockId { get; init; }

        [JsonPropertyName("message_id")]
        public string MessageId { get; init; }

        [JsonPropertyName("message_dst")]
        public string MessageDst { get; init; }

        [JsonPropertyName("message")]
        public string Message { get; init; }
    }

    /// <remarks>
    /// Nevertheless the processing will be continued at the waiting phase because the message possibly has been delivered to the node.<para/>
    /// If Application exits at this phase, Developer needs to proceed with processing after the application is restored with <c>wait_for_transaction</c> function, passing shard_block_id and message from this event.<para/>
    /// Do not forget to specify abi of your contract as well, it is crucial for processing.<para/>
    /// See <c>processing.wait_for_transaction</c> documentation.
    /// </remarks>
    public record SendFailed : ProcessingEvent
    {
        [JsonPropertyName("shard_block_id")]
        public string ShardBlockId { get; init; }

        [JsonPropertyName("message_id")]
        public string MessageId { get; init; }

        [JsonPropertyName("message_dst")]
        public string MessageDst { get; init; }

        [JsonPropertyName("message")]
        public string Message { get; init; }

        [JsonPropertyName("error")]
        public Client.ClientError Error { get; init; }
    }

    /// <remarks>
    /// Event can occurs more than one time due to block walking procedure.<para/>
    /// If Application exits at this phase, Developer needs to proceed with processing after the application is restored with <c>wait_for_transaction</c> function, passing shard_block_id and message from this event.<para/>
    /// Do not forget to specify abi of your contract as well, it is crucial for processing.<para/>
    /// See <c>processing.wait_for_transaction</c> documentation.
    /// </remarks>
    public record WillFetchNextBlock : ProcessingEvent
    {
        [JsonPropertyName("shard_block_id")]
        public string ShardBlockId { get; init; }

        [JsonPropertyName("message_id")]
        public string MessageId { get; init; }

        [JsonPropertyName("message_dst")]
        public string MessageDst { get; init; }

        [JsonPropertyName("message")]
        public string Message { get; init; }
    }

    /// <remarks>
    /// If no block was fetched within <c>NetworkConfig.wait_for_timeout</c> then processing stops.<para/>
    /// This may happen when the shard stops, or there are other network issues.<para/>
    /// In this case Developer should resume message processing with <c>wait_for_transaction</c>, passing shard_block_id, message and contract abi to it.<para/>
    /// Note that passing ABI is crucial, because it will influence the processing strategy.<para/>
    /// Another way to tune this is to specify long timeout in <c>NetworkConfig.wait_for_timeout</c>.
    /// </remarks>
    public record FetchNextBlockFailed : ProcessingEvent
    {
        [JsonPropertyName("shard_block_id")]
        public string ShardBlockId { get; init; }

        [JsonPropertyName("message_id")]
        public string MessageId { get; init; }

        [JsonPropertyName("message_dst")]
        public string MessageDst { get; init; }

        [JsonPropertyName("message")]
        public string Message { get; init; }

        [JsonPropertyName("error")]
        public Client.ClientError Error { get; init; }
    }

    /// <remarks>
    /// This event occurs only for the contracts which ABI includes "expire" header.<para/>
    /// If Application specifies <c>NetworkConfig.message_retries_count</c> &amp;gt; 0, then <c>process_message</c> will perform retries: will create a new message and send it again and repeat it until it reaches the maximum retries count or receives a successful result.<para/>
    /// All the processing events will be repeated.
    /// </remarks>
    public record MessageExpired : ProcessingEvent
    {
        [JsonPropertyName("message_id")]
        public string MessageId { get; init; }

        [JsonPropertyName("message_dst")]
        public string MessageDst { get; init; }

        [JsonPropertyName("message")]
        public string Message { get; init; }

        [JsonPropertyName("error")]
        public Client.ClientError Error { get; init; }
    }

    /// <summary>
    /// Notifies the app that the message has been delivered to the thread's validators.
    /// </summary>
    public record RempSentToValidators : ProcessingEvent
    {
        [JsonPropertyName("message_id")]
        public string MessageId { get; init; }

        [JsonPropertyName("message_dst")]
        public string MessageDst { get; init; }

        [JsonPropertyName("timestamp")]
        public ulong Timestamp { get; init; }

        [JsonPropertyName("json")]
        public JsonElement Json { get; init; }
    }

    /// <summary>
    /// Notifies the app that the message has been successfully included into a block candidate by the thread's collator.
    /// </summary>
    public record RempIncludedIntoBlock : ProcessingEvent
    {
        [JsonPropertyName("message_id")]
        public string MessageId { get; init; }

        [JsonPropertyName("message_dst")]
        public string MessageDst { get; init; }

        [JsonPropertyName("timestamp")]
        public ulong Timestamp { get; init; }

        [JsonPropertyName("json")]
        public JsonElement Json { get; init; }
    }

    /// <summary>
    /// Notifies the app that the block candidate with the message has been accepted by the thread's validators.
    /// </summary>
    public record RempIncludedIntoAcceptedBlock : ProcessingEvent
    {
        [JsonPropertyName("message_id")]
        public string MessageId { get; init; }

        [JsonPropertyName("message_dst")]
        public string MessageDst { get; init; }

        [JsonPropertyName("timestamp")]
        public ulong Timestamp { get; init; }

        [JsonPropertyName("json")]
        public JsonElement Json { get; init; }
    }

    /// <summary>
    /// Notifies the app about some other minor REMP statuses occurring during message processing.
    /// </summary>
    public record RempOther : ProcessingEvent
    {
        [JsonPropertyName("message_id")]
        public string MessageId { get; init; }

        [JsonPropertyName("message_dst")]
        public string MessageDst { get; init; }

        [JsonPropertyName("timestamp")]
        public ulong Timestamp { get; init; }

        [JsonPropertyName("json")]
        public JsonElement Json { get; init; }
    }

    /// <summary>
    /// Notifies the app about any problem that has occurred in REMP processing - in this case library switches to the fallback transaction awaiting scenario (sequential block reading).
    /// </summary>
    public record RempError : ProcessingEvent
    {
        [JsonPropertyName("message_id")]
        public string MessageId { get; init; }

        [JsonPropertyName("message_dst")]
        public string MessageDst { get; init; }

        [JsonPropertyName("error")]
        public Client.ClientError Error { get; init; }
    }
}