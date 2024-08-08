namespace TvmSdk.AckiNacki.Modules.Boc;

public record ResultOfEncodeBoc
{
    /// <summary>
    /// Encoded cell BOC or BOC cache key.
    /// </summary>
    [JsonPropertyName("boc")]
    public string Boc { get; init; }
}