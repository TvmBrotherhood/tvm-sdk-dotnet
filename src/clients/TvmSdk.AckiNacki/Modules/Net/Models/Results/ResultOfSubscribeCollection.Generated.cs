namespace TvmSdk.AckiNacki.Modules.Net;

public record ResultOfSubscribeCollection
{
    /// <remarks>
    /// Must be closed with <c>unsubscribe</c>.
    /// </remarks>
    [JsonPropertyName("handle")]
    public uint Handle { get; init; }
}