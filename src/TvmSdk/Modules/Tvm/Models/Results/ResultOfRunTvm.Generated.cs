namespace TvmSdk.Modules.Tvm;

public record ResultOfRunTvm
{
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
    /// Encoded as <c>base64</c>.<para/>
    /// Attention! Only <c>account_state.storage.state.data</c> part of the BOC is updated.
    /// </remarks>
    [JsonPropertyName("account")]
    public string Account { get; init; }
}