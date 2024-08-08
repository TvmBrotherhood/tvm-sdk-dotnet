namespace TvmSdk.AckiNacki.Modules.Client;

public record ClientError
{
    [JsonPropertyName("code")]
    public uint Code { get; init; }

    [JsonPropertyName("message")]
    public string Message { get; init; }

    [JsonPropertyName("data")]
    public JsonElement Data { get; init; }
}