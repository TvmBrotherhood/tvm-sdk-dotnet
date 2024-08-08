namespace TvmSdk.Everscale.Modules.Net;

public record ParamsOfResumeTransactionIterator
{
    /// <remarks>
    /// Same as value returned from <c>iterator_next</c>.
    /// </remarks>
    [JsonPropertyName("resume_state")]
    public JsonElement ResumeState { get; init; }

    /// <remarks>
    /// Application can specify the list of accounts for which it wants to iterate transactions.<para/>
    /// If this parameter is missing or an empty list then the library iterates transactions for all accounts that passes the shard filter.<para/>
    /// Note that the library doesn't detect conflicts between the account filter and the shard filter if both are specified.<para/>
    /// So it is the application's responsibility to specify the correct filter combination.
    /// </remarks>
    [JsonPropertyName("accounts_filter")]
    public string[]? AccountsFilter { get; init; }
}