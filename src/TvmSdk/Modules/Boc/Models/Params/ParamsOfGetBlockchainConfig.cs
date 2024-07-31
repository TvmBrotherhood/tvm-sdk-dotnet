namespace TvmSdk.Modules.Boc;

public record ParamsOfGetBlockchainConfig
{
    /// <summary>
    /// Key block BOC or zerostate BOC encoded as base64.
    /// </summary>
    [JsonPropertyName("block_boc")]
    public string BlockBoc { get; init; }
}