namespace TvmSdk.AckiNacki.Modules.Abi;

public record ResultOfAbiEncodeBoc
{
    /// <summary>
    /// BOC encoded as base64.
    /// </summary>
    [JsonPropertyName("boc")]
    public string Boc { get; init; }
}