namespace TvmSdk.Ton.Modules.Boc;

public record ResultOfParse
{
    /// <summary>
    /// JSON containing parsed BOC.
    /// </summary>
    [JsonPropertyName("parsed")]
    public JsonElement Parsed { get; init; }
}