namespace TvmSdk.Everscale.Modules.Utils;

public record ParamsOfDecompressZstd
{
    /// <remarks>
    /// Must be encoded as base64.
    /// </remarks>
    [JsonPropertyName("compressed")]
    public string Compressed { get; init; }
}