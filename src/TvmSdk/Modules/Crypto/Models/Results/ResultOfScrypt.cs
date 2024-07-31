namespace TvmSdk.Modules.Crypto;

public record ResultOfScrypt
{
    /// <remarks>
    /// Encoded with <c>hex</c>.
    /// </remarks>
    [JsonPropertyName("key")]
    public string Key { get; init; }
}