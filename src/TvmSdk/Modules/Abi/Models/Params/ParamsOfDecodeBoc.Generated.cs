namespace TvmSdk.Modules.Abi;

public record ParamsOfDecodeBoc
{
    /// <summary>
    /// Parameters to decode from BOC.
    /// </summary>
    [JsonPropertyName("params")]
    public AbiParam[] Params { get; init; }

    /// <summary>
    /// Data BOC or BOC handle.
    /// </summary>
    [JsonPropertyName("boc")]
    public string Boc { get; init; }

    [JsonPropertyName("allow_partial")]
    public bool AllowPartial { get; init; }
}