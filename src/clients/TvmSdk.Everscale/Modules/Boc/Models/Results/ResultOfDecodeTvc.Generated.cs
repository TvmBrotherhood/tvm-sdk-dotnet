namespace TvmSdk.Everscale.Modules.Boc;

public record ResultOfDecodeTvc
{
    /// <summary>
    /// Decoded TVC.
    /// </summary>
    [JsonPropertyName("tvc")]
    public Tvc Tvc { get; init; }
}