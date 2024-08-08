namespace TvmSdk.Ton.Modules.Boc;

public record ParamsOfGetCodeFromTvc
{
    /// <summary>
    /// Contract TVC image or image BOC handle.
    /// </summary>
    [JsonPropertyName("tvc")]
    public string Tvc { get; init; }
}