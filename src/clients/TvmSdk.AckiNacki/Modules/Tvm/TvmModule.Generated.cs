using TvmSdk.DllAdapter;

namespace TvmSdk.AckiNacki.Modules.Tvm;

public class TvmModule(ITvmSdkDllAdapter adapter) : ITvmModule
{
    /// <remarks>
    /// Performs all the phases of contract execution on Transaction Executor - the same component that is used on Validator Nodes.<para/>
    /// Can be used for contract debugging, to find out the reason why a message was not delivered successfully.<para/>
    /// Validators throw away the failed external inbound messages (if they failed before <c>ACCEPT</c>) in the real network.<para/>
    /// This is why these messages are impossible to debug in the real network.<para/>
    /// With the help of run_executor you can do that.<para/>
    /// In fact, <c>process_message</c> function performs local check with <c>run_executor</c> if there was no transaction as a result of processing and returns the error, if there is one.<para/>
    /// Another use case to use <c>run_executor</c> is to estimate fees for message execution.<para/>
    /// Set  <c>AccountForExecutor::Account.unlimited_balance</c> to <c>true</c> so that emulation will not depend on the actual balance.<para/>
    /// This may be needed to calculate deploy fees for an account that does not exist yet.<para/>
    /// JSON with fees is in <c>fees</c> field of the result.<para/>
    /// One more use case - you can produce the sequence of operations, thus emulating the sequential contract calls locally.<para/>
    /// And so on.<para/>
    /// Transaction executor requires account BOC (bag of cells) as a parameter.<para/>
    /// To get the account BOC - use <c>net.query</c> method to download it from GraphQL API (field <c>boc</c> of <c>account</c>) or generate it with <c>abi.encode_account</c> method.<para/>
    /// Also it requires message BOC.<para/>
    /// To get the message BOC - use <c>abi.encode_message</c> or <c>abi.encode_internal_message</c>.<para/>
    /// If you need this emulation to be as precise as possible (for instance - emulate transaction with particular lt in particular block or use particular blockchain config, downloaded from a particular key block - then specify <c>execution_options</c> parameter.<para/>
    /// If you need to see the aborted transaction as a result, not as an error, set <c>skip_transaction_check</c> to <c>true</c>.
    /// </remarks>
    public Task<ResultOfRunExecutor> RunExecutor(ParamsOfRunExecutor @params)
    {
        return adapter.CallMethod<ParamsOfRunExecutor, ResultOfRunExecutor>("tvm.run_executor", @params);
    }

    /// <remarks>
    /// Performs only a part of compute phase of transaction execution that is used to run get-methods of ABI-compatible contracts.<para/>
    /// If you try to run get-methods with <c>run_executor</c> you will get an error, because it checks ACCEPT and exits if there is none, which is actually true for get-methods.<para/>
    /// To get the account BOC (bag of cells) - use <c>net.query</c> method to download it from GraphQL API (field <c>boc</c> of <c>account</c>) or generate it with <c>abi.encode_account method</c>.<para/>
    /// To get the message BOC - use <c>abi.encode_message</c> or prepare it any other way, for instance, with FIFT script.<para/>
    /// Attention! Updated account state is produces as well, but only <c>account_state.storage.state.data</c>  part of the BOC is updated.
    /// </remarks>
    public Task<ResultOfRunTvm> RunTvm(ParamsOfRunTvm @params)
    {
        return adapter.CallMethod<ParamsOfRunTvm, ResultOfRunTvm>("tvm.run_tvm", @params);
    }

    /// <remarks>
    /// Executes a get-method of FIFT contract that fulfills the smc-guidelines https://test.ton.org/smc-guidelines.txt and returns the result data from TVM's stack.
    /// </remarks>
    public Task<ResultOfRunGet> RunGet(ParamsOfRunGet @params)
    {
        return adapter.CallMethod<ParamsOfRunGet, ResultOfRunGet>("tvm.run_get", @params);
    }
}