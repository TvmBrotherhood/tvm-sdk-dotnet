namespace TvmSdk.Everscale.Modules.Processing;

/// <remarks>
/// This module incorporates functions related to complex message processing scenarios.
/// </remarks>
public interface IProcessingModule
{
    /// <remarks>
    /// Message monitor performs background monitoring for a message processing results for the specified set of messages.<para/>
    /// Message monitor can serve several isolated monitoring queues.<para/>
    /// Each monitor queue has a unique application defined identifier (or name) used to separate several queue's.<para/>
    /// There are two important lists inside of the monitoring queue:  - unresolved messages: contains messages requested by the application for monitoring   and not yet resolved;  - resolved results: contains resolved processing results for monitored messages.<para/>
    /// Each monitoring queue tracks own unresolved and resolved lists.<para/>
    /// Application can add more messages to the monitoring queue at any time.<para/>
    /// Message monitor accumulates resolved results.<para/>
    /// Application should fetch this results with <c>fetchNextMonitorResults</c> function.<para/>
    /// When both unresolved and resolved lists becomes empty, monitor stops any background activity and frees all allocated internal memory.<para/>
    /// If monitoring queue with specified name already exists then messages will be added to the unresolved list.<para/>
    /// If monitoring queue with specified name does not exist then monitoring queue will be created with specified unresolved messages.
    /// </remarks>
    Task MonitorMessages(ParamsOfMonitorMessages @params);

    /// <summary>
    /// Returns summary information about current state of the specified monitoring queue.
    /// </summary>
    Task<MonitoringQueueInfo> GetMonitorInfo(ParamsOfGetMonitorInfo @params);

    /// <remarks>
    /// Results and waiting options are depends on the <c>wait</c> parameter.<para/>
    /// All returned results will be removed from the queue's resolved list.
    /// </remarks>
    Task<ResultOfFetchNextMonitorResults> FetchNextMonitorResults(ParamsOfFetchNextMonitorResults @params);

    /// <summary>
    /// Cancels all background activity and releases all allocated system resources for the specified monitoring queue.
    /// </summary>
    Task CancelMonitor(ParamsOfCancelMonitor @params);

    /// <summary>
    /// Sends specified messages to the blockchain.
    /// </summary>
    Task<ResultOfSendMessages> SendMessages(ParamsOfSendMessages @params);

    /// <remarks>
    /// Sends message to the network and returns the last generated shard block of the destination account before the message was sent.<para/>
    /// It will be required later for message processing.
    /// </remarks>
    Task<ResultOfSendMessage> SendMessage(ParamsOfSendMessage @params);

    /// <remarks>
    /// <c>send_events</c> enables intermediate events, such as <c>WillFetchNextBlock</c>, <c>FetchNextBlockFailed</c> that may be useful for logging of new shard blocks creation during message processing.<para/>
    /// Note, that presence of the <c>abi</c> parameter is critical for ABI compliant contracts.<para/>
    /// Message processing uses drastically different strategy for processing message for contracts which ABI includes "expire" header.<para/>
    /// When the ABI header <c>expire</c> is present, the processing uses <c>message expiration</c> strategy: - The maximum block gen time is set to   <c>message_expiration_timeout + transaction_wait_timeout</c>.<para/>
    /// - When maximum block gen time is reached, the processing will   be finished with <c>MessageExpired</c> error.<para/>
    /// When the ABI header <c>expire</c> isn't present or <c>abi</c> parameter isn't specified, the processing uses <c>transaction waiting</c> strategy: - The maximum block gen time is set to   <c>now() + transaction_wait_timeout</c>.<para/>
    /// - If maximum block gen time is reached and no result transaction is found, the processing will exit with an error.
    /// </remarks>
    Task<ResultOfProcessMessage> WaitForTransaction(ParamsOfWaitForTransaction @params);

    /// <remarks>
    /// Creates ABI-compatible message, sends it to the network and monitors for the result transaction.<para/>
    /// Decodes the output messages' bodies.<para/>
    /// If contract's ABI includes "expire" header, then SDK implements retries in case of unsuccessful message delivery within the expiration timeout: SDK recreates the message, sends it and processes it again.<para/>
    /// The intermediate events, such as <c>WillFetchFirstBlock</c>, <c>WillSend</c>, <c>DidSend</c>, <c>WillFetchNextBlock</c>, etc - are switched on/off by <c>send_events</c> flag and logged into the supplied callback function.<para/>
    /// The retry configuration parameters are defined in the client's <c>NetworkConfig</c> and <c>AbiConfig</c>.<para/>
    /// If contract's ABI does not include "expire" header then, if no transaction is found within the network timeout (see config parameter ), exits with error.
    /// </remarks>
    Task<ResultOfProcessMessage> ProcessMessage(ParamsOfProcessMessage @params);
}