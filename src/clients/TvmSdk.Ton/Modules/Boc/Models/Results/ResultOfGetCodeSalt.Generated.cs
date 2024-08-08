namespace TvmSdk.Ton.Modules.Boc;

public record ResultOfGetCodeSalt
{
    /// <remarks>
    /// BOC encoded as base64 or BOC handle.
    /// </remarks>
    [JsonPropertyName("salt")]
    public string? Salt { get; init; }
}