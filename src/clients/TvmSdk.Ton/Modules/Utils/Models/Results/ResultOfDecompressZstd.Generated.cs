namespace TvmSdk.Ton.Modules.Utils;

public record ResultOfDecompressZstd
{
    /// <remarks>
    /// Must be encoded as base64.
    /// </remarks>
    [JsonPropertyName("decompressed")]
    public string Decompressed { get; init; }
}