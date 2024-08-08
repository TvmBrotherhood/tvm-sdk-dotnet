namespace TvmSdk.AckiNacki.Modules.Abi;

public record ParamsOfDecodeAccountData
{
    /// <summary>
    /// Contract ABI.
    /// </summary>
    [JsonPropertyName("abi")]
    public Abi Abi { get; init; }

    /// <summary>
    /// Data BOC or BOC handle.
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; init; }

    /// <summary>
    /// Flag allowing partial BOC decoding when ABI doesn't describe the full body BOC.<para/>
    /// Controls decoder behaviour when after decoding all described in ABI params there are some data left in BOC: <c>true</c> - return decoded values <c>false</c> - return error of incomplete BOC deserialization (default).
    /// </summary>
    [JsonPropertyName("allow_partial")]
    public bool? AllowPartial { get; init; }
}