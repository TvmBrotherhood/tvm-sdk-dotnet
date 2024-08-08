namespace TvmSdk.AckiNacki.Modules.Tvm;

public record ResultOfRunExecutor
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
    public Processing.DecodedOutput? Decoded { get; init; }

    /// <remarks>
    /// Encoded as <c>base64</c>.
    /// </remarks>
    [JsonPropertyName("account")]
    public string Account { get; init; }

    /// <summary>
    /// Transaction fees.
    /// </summary>
    [JsonPropertyName("fees")]
    public TransactionFees Fees { get; init; }
}