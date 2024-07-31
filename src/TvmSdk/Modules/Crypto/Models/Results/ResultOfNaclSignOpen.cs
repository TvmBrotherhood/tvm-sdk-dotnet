namespace TvmSdk.Modules.Crypto;

public record ResultOfNaclSignOpen
{
    /// <summary>
    /// Unsigned data, encoded in <c>base64</c>.
    /// </summary>
    [JsonPropertyName("unsigned")]
    public string Unsigned { get; init; }
}