namespace TvmSdk.Ton.Modules.Proofs;

public record ParamsOfProofTransactionData
{
    /// <summary>
    /// Single transaction's data as queried from DApp server, without modifications.<para/>
    /// The required fields are <c>id</c> and/or top-level <c>boc</c>, others are optional.<para/>
    /// In order to reduce network requests count, it is recommended to provide <c>block_id</c> and <c>boc</c> of transaction.
    /// </summary>
    [JsonPropertyName("transaction")]
    public JsonElement Transaction { get; init; }
}