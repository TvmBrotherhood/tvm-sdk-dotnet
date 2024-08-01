namespace TvmSdk.Modules.Net;

public record ResultOfWaitForCollection
{
    /// <summary>
    /// First found object that matches the provided criteria.
    /// </summary>
    [JsonPropertyName("result")]
    public JsonElement Result { get; init; }
}