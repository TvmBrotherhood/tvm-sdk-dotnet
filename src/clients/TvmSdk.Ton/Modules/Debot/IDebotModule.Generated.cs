namespace TvmSdk.Ton.Modules.Debot;

/// <summary>
/// <a href="UNSTABLE.md">UNSTABLE</a><a href="DEPRECATED.md">DEPRECATED</a> Module for working with debot.
/// </summary>
public interface IDebotModule
{
    /// <remarks>
    /// Downloads debot smart contract (code and data) from blockchain and creates an instance of Debot Engine for it.<para/>
    /// # Remarks It does not switch debot to context 0.<para/>
    /// Browser Callbacks are not called.
    /// </remarks>
    Task<RegisteredDebot> Init(ParamsOfInit @params);

    /// <remarks>
    /// Downloads debot smart contract from blockchain and switches it to context zero.<para/>
    /// This function must be used by Debot Browser to start a dialog with debot.<para/>
    /// While the function is executing, several Browser Callbacks can be called, since the debot tries to display all actions from the context 0 to the user.<para/>
    /// When the debot starts SDK registers <c>BrowserCallbacks</c> AppObject.<para/>
    /// Therefore when <c>debote.remove</c> is called the debot is being deleted and the callback is called with <c>finish</c><c>true</c> which indicates that it will never be used again.
    /// </remarks>
    Task Start(ParamsOfStart @params);

    /// <remarks>
    /// Downloads DeBot from blockchain and creates and fetches its metadata.
    /// </remarks>
    Task<ResultOfFetch> Fetch(ParamsOfFetch @params);

    /// <remarks>
    /// Calls debot engine referenced by debot handle to execute input action.<para/>
    /// Calls Debot Browser Callbacks if needed.<para/>
    /// # Remarks Chain of actions can be executed if input action generates a list of subactions.
    /// </remarks>
    Task Execute(ParamsOfExecute @params);

    /// <remarks>
    /// Used by Debot Browser to send response on Dinterface call or from other Debots.
    /// </remarks>
    Task Send(ParamsOfSend @params);

    /// <remarks>
    /// Removes handle from Client Context and drops debot engine referenced by that handle.
    /// </remarks>
    Task Remove(ParamsOfRemove @params);
}