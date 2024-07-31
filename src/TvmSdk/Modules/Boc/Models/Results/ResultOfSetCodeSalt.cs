namespace TvmSdk.Modules.Boc;

public record ResultOfSetCodeSalt
{
    /// <remarks>
    /// BOC encoded as base64 or BOC handle.
    /// </remarks>
    [JsonPropertyName("code")]
    public string Code { get; init; }
}