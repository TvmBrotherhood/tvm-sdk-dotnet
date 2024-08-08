namespace TvmSdk.Everscale.Modules.Crypto;

public record ResultOfTonCrc16
{
    /// <summary>
    /// Calculated CRC for input data.
    /// </summary>
    [JsonPropertyName("crc")]
    public ushort Crc { get; init; }
}