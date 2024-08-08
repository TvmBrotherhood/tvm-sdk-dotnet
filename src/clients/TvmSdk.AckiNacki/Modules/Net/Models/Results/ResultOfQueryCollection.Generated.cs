namespace TvmSdk.AckiNacki.Modules.Net;

public record ResultOfQueryCollection
{
    /// <summary>
    /// Objects that match the provided criteria.
    /// </summary>
    [JsonPropertyName("result")]
    public JsonElement[] Result { get; init; }
}