namespace TvmSdk.AckiNacki.Modules.Proofs;

public record ParamsOfProofBlockData
{
    /// <summary>
    /// Single block's data, retrieved from TONOS API, that needs proof.<para/>
    /// Required fields are <c>id</c> and/or top-level <c>boc</c> (for block identification), others are optional.
    /// </summary>
    [JsonPropertyName("block")]
    public JsonElement Block { get; init; }
}