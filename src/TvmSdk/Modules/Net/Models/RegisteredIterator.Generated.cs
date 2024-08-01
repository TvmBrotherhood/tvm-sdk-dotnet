namespace TvmSdk.Modules.Net;

public record RegisteredIterator
{
    /// <remarks>
    /// Must be removed using <c>remove_iterator</c> when it is no more needed for the application.
    /// </remarks>
    [JsonPropertyName("handle")]
    public uint Handle { get; init; }
}