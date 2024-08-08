namespace TvmSdk.AckiNacki.Modules.Abi;

public record ResultOfEncodeAccount
{
    /// <summary>
    /// Account BOC encoded in <c>base64</c>.
    /// </summary>
    [JsonPropertyName("account")]
    public string Account { get; init; }

    /// <summary>
    /// Account ID  encoded in <c>hex</c>.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; init; }
}