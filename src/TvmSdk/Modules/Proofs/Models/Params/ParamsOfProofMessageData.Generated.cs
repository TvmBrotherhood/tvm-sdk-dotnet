namespace TvmSdk.Modules.Proofs;

public record ParamsOfProofMessageData
{
    /// <summary>
    /// Single message's data as queried from DApp server, without modifications.<para/>
    /// The required fields are <c>id</c> and/or top-level <c>boc</c>, others are optional.<para/>
    /// In order to reduce network requests count, it is recommended to provide at least <c>boc</c> of message and non-null <c>src_transaction.id</c> or <c>dst_transaction.id</c>.
    /// </summary>
    [JsonPropertyName("message")]
    public JsonElement Message { get; init; }
}