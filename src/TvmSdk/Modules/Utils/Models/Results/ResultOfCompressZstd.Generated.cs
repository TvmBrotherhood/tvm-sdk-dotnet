namespace TvmSdk.Modules.Utils;

public record ResultOfCompressZstd
{
    /// <remarks>
    /// Must be encoded as base64.
    /// </remarks>
    [JsonPropertyName("compressed")]
    public string Compressed { get; init; }
}