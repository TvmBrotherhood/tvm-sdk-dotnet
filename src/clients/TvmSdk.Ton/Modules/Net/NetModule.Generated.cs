using TvmSdk.DllAdapter;

namespace TvmSdk.Ton.Modules.Net;

/// <summary>
/// Network access.
/// </summary>
public class NetModule(ITvmSdkDllAdapter adapter) : INetModule
{
    /// <summary>
    /// Performs DAppServer GraphQL query.
    /// </summary>
    public Task<ResultOfQuery> Query(ParamsOfQuery @params)
    {
        return adapter.CallMethod<ParamsOfQuery, ResultOfQuery>("net.query", @params);
    }

    /// <summary>
    /// Performs multiple queries per single fetch.
    /// </summary>
    public Task<ResultOfBatchQuery> BatchQuery(ParamsOfBatchQuery @params)
    {
        return adapter.CallMethod<ParamsOfBatchQuery, ResultOfBatchQuery>("net.batch_query", @params);
    }

    /// <remarks>
    /// Queries data that satisfies the <c>filter</c> conditions, limits the number of returned records and orders them.<para/>
    /// The projection fields are limited to <c>result</c> fields.
    /// </remarks>
    public Task<ResultOfQueryCollection> QueryCollection(ParamsOfQueryCollection @params)
    {
        return adapter.CallMethod<ParamsOfQueryCollection, ResultOfQueryCollection>("net.query_collection", @params);
    }

    /// <remarks>
    /// Aggregates values from the specified <c>fields</c> for records that satisfies the <c>filter</c> conditions,.
    /// </remarks>
    public Task<ResultOfAggregateCollection> AggregateCollection(ParamsOfAggregateCollection @params)
    {
        return adapter.CallMethod<ParamsOfAggregateCollection, ResultOfAggregateCollection>("net.aggregate_collection", @params);
    }

    /// <remarks>
    /// Triggers only once.<para/>
    /// If object that satisfies the <c>filter</c> conditions already exists - returns it immediately.<para/>
    /// If not - waits for insert/update of data within the specified <c>timeout</c>, and returns it.<para/>
    /// The projection fields are limited to <c>result</c> fields.
    /// </remarks>
    public Task<ResultOfWaitForCollection> WaitForCollection(ParamsOfWaitForCollection @params)
    {
        return adapter.CallMethod<ParamsOfWaitForCollection, ResultOfWaitForCollection>("net.wait_for_collection", @params);
    }

    /// <remarks>
    /// Cancels a subscription specified by its handle.
    /// </remarks>
    public Task Unsubscribe(ResultOfSubscribeCollection @params)
    {
        return adapter.CallMethod("net.unsubscribe", @params);
    }

    /// <remarks>
    /// Triggers for each insert/update of data that satisfies the <c>filter</c> conditions.<para/>
    /// The projection fields are limited to <c>result</c> fields.<para/>
    /// The subscription is a persistent communication channel between client and Free TON Network.<para/>
    /// All changes in the blockchain will be reflected in realtime.<para/>
    /// Changes means inserts and updates of the blockchain entities.<para/>
    /// ### Important Notes on Subscriptions  Unfortunately sometimes the connection with the network brakes down.<para/>
    /// In this situation the library attempts to reconnect to the network.<para/>
    /// This reconnection sequence can take significant time.<para/>
    /// All of this time the client is disconnected from the network.<para/>
    /// Bad news is that all blockchain changes that happened while the client was disconnected are lost.<para/>
    /// Good news is that the client report errors to the callback when it loses and resumes connection.<para/>
    /// So, if the lost changes are important to the application then the application must handle these error reports.<para/>
    /// Library reports errors with <c>responseType</c> == 101 and the error object passed via <c>params</c>.<para/>
    /// When the library has successfully reconnected the application receives callback with <c>responseType</c> == 101 and <c>params.code</c> == 614 (NetworkModuleResumed).<para/>
    /// Application can use several ways to handle this situation: - If application monitors changes for the single blockchain object (for example specific account):  application can perform a query for this object and handle actual data as a regular data from the subscription.<para/>
    /// - If application monitors sequence of some blockchain objects (for example transactions of the specific account): application must refresh all cached (or visible to user) lists where this sequences presents.
    /// </remarks>
    public Task<ResultOfSubscribeCollection> SubscribeCollection(ParamsOfSubscribeCollection @params)
    {
        return adapter.CallMethod<ParamsOfSubscribeCollection, ResultOfSubscribeCollection>("net.subscribe_collection", @params);
    }

    /// <remarks>
    /// The subscription is a persistent communication channel between client and Everscale Network.<para/>
    /// ### Important Notes on Subscriptions  Unfortunately sometimes the connection with the network breaks down.<para/>
    /// In this situation the library attempts to reconnect to the network.<para/>
    /// This reconnection sequence can take significant time.<para/>
    /// All of this time the client is disconnected from the network.<para/>
    /// Bad news is that all changes that happened while the client was disconnected are lost.<para/>
    /// Good news is that the client report errors to the callback when it loses and resumes connection.<para/>
    /// So, if the lost changes are important to the application then the application must handle these error reports.<para/>
    /// Library reports errors with <c>responseType</c> == 101 and the error object passed via <c>params</c>.<para/>
    /// When the library has successfully reconnected the application receives callback with <c>responseType</c> == 101 and <c>params.code</c> == 614 (NetworkModuleResumed).<para/>
    /// Application can use several ways to handle this situation: - If application monitors changes for the single object (for example specific account):  application can perform a query for this object and handle actual data as a regular data from the subscription.<para/>
    /// - If application monitors sequence of some objects (for example transactions of the specific account): application must refresh all cached (or visible to user) lists where this sequences presents.
    /// </remarks>
    public Task<ResultOfSubscribeCollection> Subscribe(ParamsOfSubscribe @params)
    {
        return adapter.CallMethod<ParamsOfSubscribe, ResultOfSubscribeCollection>("net.subscribe", @params);
    }

    /// <summary>
    /// Suspends network module to stop any network activity.
    /// </summary>
    public Task Suspend()
    {
        return adapter.CallMethod("net.suspend");
    }

    /// <summary>
    /// Resumes network module to enable network activity.
    /// </summary>
    public Task Resume()
    {
        return adapter.CallMethod("net.resume");
    }

    /// <summary>
    /// Returns ID of the last block in a specified account shard.
    /// </summary>
    public Task<ResultOfFindLastShardBlock> FindLastShardBlock(ParamsOfFindLastShardBlock @params)
    {
        return adapter.CallMethod<ParamsOfFindLastShardBlock, ResultOfFindLastShardBlock>("net.find_last_shard_block", @params);
    }

    /// <summary>
    /// Requests the list of alternative endpoints from server.
    /// </summary>
    public Task<EndpointsSet> FetchEndpoints()
    {
        return adapter.CallMethod<EndpointsSet>("net.fetch_endpoints");
    }

    /// <summary>
    /// Sets the list of endpoints to use on reinit.
    /// </summary>
    public Task SetEndpoints(EndpointsSet @params)
    {
        return adapter.CallMethod("net.set_endpoints", @params);
    }

    /// <summary>
    /// Requests the list of alternative endpoints from server.
    /// </summary>
    public Task<ResultOfGetEndpoints> GetEndpoints()
    {
        return adapter.CallMethod<ResultOfGetEndpoints>("net.get_endpoints");
    }

    /// <remarks>
    /// *Attention* this query retrieves data from 'Counterparties' service which is not supported in the opensource version of DApp Server (and will not be supported) as well as in Evernode SE (will be supported in SE in future), but is always accessible via <a href="../ton-os-api/networks.md">EVER OS Clouds</a>.
    /// </remarks>
    public Task<ResultOfQueryCollection> QueryCounterparties(ParamsOfQueryCounterparties @params)
    {
        return adapter.CallMethod<ParamsOfQueryCounterparties, ResultOfQueryCollection>("net.query_counterparties", @params);
    }

    /// <remarks>
    /// Performs recursive retrieval of a transactions tree produced by a specific message: in_msg -&amp;gt; dst_transaction -&amp;gt; out_messages -&amp;gt; dst_transaction -&amp;gt; ..<para/>
    /// If the chain of transactions execution is in progress while the function is running, it will wait for the next transactions to appear until the full tree or more than 50 transactions are received.<para/>
    /// All the retrieved messages and transactions are included into <c>result.messages</c> and <c>result.transactions</c> respectively.<para/>
    /// Function reads transactions layer by layer, by pages of 20 transactions.<para/>
    /// The retrieval process goes like this: Let's assume we have an infinite chain of transactions and each transaction generates 5 messages.<para/>
    /// 1.<para/>
    /// Retrieve 1st message (input parameter) and corresponding transaction - put it into result.<para/>
    /// It is the first level of the tree of transactions - its root.<para/>
    /// Retrieve 5 out message ids from the transaction for next steps.<para/>
    /// 2.<para/>
    /// Retrieve 5 messages and corresponding transactions on the 2nd layer.<para/>
    /// Put them into result.<para/>
    /// Retrieve 5*5 out message ids from these transactions for next steps 3.<para/>
    /// Retrieve 20 (size of the page) messages and transactions (3rd layer) and 20*5=100 message ids (4th layer).<para/>
    /// 4.<para/>
    /// Retrieve the last 5 messages and 5 transactions on the 3rd layer + 15 messages and transactions (of 100) from the 4th layer + 25 message ids of the 4th layer + 75 message ids of the 5th layer.<para/>
    /// 5.<para/>
    /// Retrieve 20 more messages and 20 more transactions of the 4th layer + 100 more message ids of the 5th layer.<para/>
    /// 6.<para/>
    /// Now we have 1+5+20+20+20 = 66 transactions, which is more than 50.<para/>
    /// Function exits with the tree of 1m-&amp;gt;1t-&amp;gt;5m-&amp;gt;5t-&amp;gt;25m-&amp;gt;25t-&amp;gt;35m-&amp;gt;35t.<para/>
    /// If we see any message ids in the last transactions out_msgs, which don't have corresponding messages in the function result, it means that the full tree was not received and we need to continue iteration.<para/>
    /// To summarize, it is guaranteed that each message in <c>result.messages</c> has the corresponding transaction in the <c>result.transactions</c>.<para/>
    /// But there is no guarantee that all messages from transactions <c>out_msgs</c> are presented in <c>result.messages</c>.<para/>
    /// So the application has to continue retrieval for missing messages if it requires.
    /// </remarks>
    public Task<ResultOfQueryTransactionTree> QueryTransactionTree(ParamsOfQueryTransactionTree @params)
    {
        return adapter.CallMethod<ParamsOfQueryTransactionTree, ResultOfQueryTransactionTree>("net.query_transaction_tree", @params);
    }

    /// <remarks>
    /// Block iterator uses robust iteration methods that guaranties that every block in the specified range isn't missed or iterated twice.<para/>
    /// Iterated range can be reduced with some filters: - <c>start_time</c> – the bottom time range.<para/>
    /// Only blocks with <c>gen_utime</c> more or equal to this value is iterated.<para/>
    /// If this parameter is omitted then there is no bottom time edge, so all blocks since zero state is iterated.<para/>
    /// - <c>end_time</c> – the upper time range.<para/>
    /// Only blocks with <c>gen_utime</c> less then this value is iterated.<para/>
    /// If this parameter is omitted then there is no upper time edge, so iterator never finishes.<para/>
    /// - <c>shard_filter</c> – workchains and shard prefixes that reduce the set of interesting blocks.<para/>
    /// Block conforms to the shard filter if it belongs to the filter workchain and the first bits of block's <c>shard</c> fields matches to the shard prefix.<para/>
    /// Only blocks with suitable shard are iterated.<para/>
    /// Items iterated is a JSON objects with block data.<para/>
    /// The minimal set of returned fields is: <c>`</c>text id gen_utime workchain_id shard after_split after_merge prev_ref {     root_hash } prev_alt_ref {     root_hash } <c>`</c> Application can request additional fields in the <c>result</c> parameter.<para/>
    /// Application should call the <c>remove_iterator</c> when iterator is no longer required.
    /// </remarks>
    public Task<RegisteredIterator> CreateBlockIterator(ParamsOfCreateBlockIterator @params)
    {
        return adapter.CallMethod<ParamsOfCreateBlockIterator, RegisteredIterator>("net.create_block_iterator", @params);
    }

    /// <remarks>
    /// The iterator stays exactly at the same position where the <c>resume_state</c> was caught.<para/>
    /// Application should call the <c>remove_iterator</c> when iterator is no longer required.
    /// </remarks>
    public Task<RegisteredIterator> ResumeBlockIterator(ParamsOfResumeBlockIterator @params)
    {
        return adapter.CallMethod<ParamsOfResumeBlockIterator, RegisteredIterator>("net.resume_block_iterator", @params);
    }

    /// <remarks>
    /// Transaction iterator uses robust iteration methods that guaranty that every transaction in the specified range isn't missed or iterated twice.<para/>
    /// Iterated range can be reduced with some filters: - <c>start_time</c> – the bottom time range.<para/>
    /// Only transactions with <c>now</c> more or equal to this value are iterated.<para/>
    /// If this parameter is omitted then there is no bottom time edge, so all the transactions since zero state are iterated.<para/>
    /// - <c>end_time</c> – the upper time range.<para/>
    /// Only transactions with <c>now</c> less then this value are iterated.<para/>
    /// If this parameter is omitted then there is no upper time edge, so iterator never finishes.<para/>
    /// - <c>shard_filter</c> – workchains and shard prefixes that reduce the set of interesting accounts.<para/>
    /// Account address conforms to the shard filter if it belongs to the filter workchain and the first bits of address match to the shard prefix.<para/>
    /// Only transactions with suitable account addresses are iterated.<para/>
    /// - <c>accounts_filter</c> – set of account addresses whose transactions must be iterated.<para/>
    /// Note that accounts filter can conflict with shard filter so application must combine these filters carefully.<para/>
    /// Iterated item is a JSON objects with transaction data.<para/>
    /// The minimal set of returned fields is: <c>`</c>text id account_addr now balance_delta(format:DEC) bounce { bounce_type } in_message {     id     value(format:DEC)     msg_type     src } out_messages {     id     value(format:DEC)     msg_type     dst } <c>`</c> Application can request an additional fields in the <c>result</c> parameter.<para/>
    /// Another parameter that affects on the returned fields is the <c>include_transfers</c>.<para/>
    /// When this parameter is <c>true</c> the iterator computes and adds <c>transfer</c> field containing list of the useful <c>TransactionTransfer</c> objects.<para/>
    /// Each transfer is calculated from the particular message related to the transaction and has the following structure: - message – source message identifier.<para/>
    /// - isBounced – indicates that the transaction is bounced, which means the value will be returned back to the sender.<para/>
    /// - isDeposit – indicates that this transfer is the deposit (true) or withdraw (false).<para/>
    /// - counterparty – account address of the transfer source or destination depending on <c>isDeposit</c>.<para/>
    /// - value – amount of nano tokens transferred.<para/>
    /// The value is represented as a decimal string because the actual value can be more precise than the JSON number can represent.<para/>
    /// Application must use this string carefully – conversion to number can follow to loose of precision.<para/>
    /// Application should call the <c>remove_iterator</c> when iterator is no longer required.
    /// </remarks>
    public Task<RegisteredIterator> CreateTransactionIterator(ParamsOfCreateTransactionIterator @params)
    {
        return adapter.CallMethod<ParamsOfCreateTransactionIterator, RegisteredIterator>("net.create_transaction_iterator", @params);
    }

    /// <remarks>
    /// The iterator stays exactly at the same position where the <c>resume_state</c> was caught.<para/>
    /// Note that <c>resume_state</c> doesn't store the account filter.<para/>
    /// If the application requires to use the same account filter as it was when the iterator was created then the application must pass the account filter again in <c>accounts_filter</c> parameter.<para/>
    /// Application should call the <c>remove_iterator</c> when iterator is no longer required.
    /// </remarks>
    public Task<RegisteredIterator> ResumeTransactionIterator(ParamsOfResumeTransactionIterator @params)
    {
        return adapter.CallMethod<ParamsOfResumeTransactionIterator, RegisteredIterator>("net.resume_transaction_iterator", @params);
    }

    /// <remarks>
    /// In addition to available items this function returns the <c>has_more</c> flag indicating that the iterator isn't reach the end of the iterated range yet.<para/>
    /// This function can return the empty list of available items but indicates that there are more items is available.<para/>
    /// This situation appears when the iterator doesn't reach iterated range but database doesn't contains available items yet.<para/>
    /// If application requests resume state in <c>return_resume_state</c> parameter then this function returns <c>resume_state</c> that can be used later to resume the iteration from the position after returned items.<para/>
    /// The structure of the items returned depends on the iterator used.<para/>
    /// See the description to the appropriated iterator creation function.
    /// </remarks>
    public Task<ResultOfIteratorNext> IteratorNext(ParamsOfIteratorNext @params)
    {
        return adapter.CallMethod<ParamsOfIteratorNext, ResultOfIteratorNext>("net.iterator_next", @params);
    }

    /// <remarks>
    /// Frees all resources allocated in library to serve iterator.<para/>
    /// Application always should call the <c>remove_iterator</c> when iterator is no longer required.
    /// </remarks>
    public Task RemoveIterator(RegisteredIterator @params)
    {
        return adapter.CallMethod("net.remove_iterator", @params);
    }

    /// <summary>
    /// Returns signature ID for configured network if it should be used in messages signature.
    /// </summary>
    public Task<ResultOfGetSignatureId> GetSignatureId()
    {
        return adapter.CallMethod<ResultOfGetSignatureId>("net.get_signature_id");
    }
}