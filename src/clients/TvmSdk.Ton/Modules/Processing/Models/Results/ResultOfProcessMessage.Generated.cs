namespace TvmSdk.Ton.Modules.Processing;

public record ResultOfProcessMessage
{
    /// <remarks>
    /// In addition to the regular transaction fields there is a <c>boc</c> field encoded with <c>base64</c> which contains source transaction BOC.
    /// </remarks>
    [JsonPropertyName("transaction")]
    public JsonElement Transaction { get; init; }

    /// <remarks>
    /// Encoded as <c>base64</c>.
    /// </remarks>
    [JsonPropertyName("out_messages")]
    public string[] OutMessages { get; init; }

    /// <summary>
    /// Optional decoded message bodies according to the optional <c>abi</c> parameter.
    /// </summary>
    [JsonPropertyName("decoded")]
    public DecodedOutput? Decoded { get; init; }

    /// <summary>
    /// Transaction fees.
    /// </summary>
    [JsonPropertyName("fees")]
    public Tvm.TransactionFees Fees { get; init; }
}