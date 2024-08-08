namespace TvmSdk.AckiNacki.Modules.Utils;

public record ParamsOfCompressZstd
{
    /// <remarks>
    /// Must be encoded as base64.
    /// </remarks>
    [JsonPropertyName("uncompressed")]
    public string Uncompressed { get; init; }

    /// <summary>
    /// Compression level, from 1 to 21.<para/>
    /// Where: 1 - lowest compression level (fastest compression); 21 - highest compression level (slowest compression).<para/>
    /// If level is omitted, the default compression level is used (currently <c>3</c>).
    /// </summary>
    [JsonPropertyName("level")]
    public int? Level { get; init; }
}