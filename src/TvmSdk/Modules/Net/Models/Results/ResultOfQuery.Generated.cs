namespace TvmSdk.Modules.Net;

public record ResultOfQuery
{
    /// <summary>
    /// Result provided by DAppServer.
    /// </summary>
    [JsonPropertyName("result")]
    public JsonElement Result { get; init; }
}