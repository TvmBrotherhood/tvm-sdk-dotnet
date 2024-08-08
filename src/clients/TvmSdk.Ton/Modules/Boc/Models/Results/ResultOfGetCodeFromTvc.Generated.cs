namespace TvmSdk.Ton.Modules.Boc;

public record ResultOfGetCodeFromTvc
{
    /// <summary>
    /// Contract code encoded as base64.
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; init; }
}