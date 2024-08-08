namespace TvmSdk.Ton.Modules.Boc;

public record ResultOfGetBocHash
{
    /// <summary>
    /// BOC root hash encoded with hex.
    /// </summary>
    [JsonPropertyName("hash")]
    public string Hash { get; init; }
}