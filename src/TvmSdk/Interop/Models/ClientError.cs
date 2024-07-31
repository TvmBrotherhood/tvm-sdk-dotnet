using TvmSdk.Interop.Enums;

namespace TvmSdk.Interop.Models;

public record ClientError
{
    [JsonPropertyName("code")]
    public ErrorCode Code { get; init; }
    
    [JsonPropertyName("message")]
    public required string Message { get; init; }
    
    [JsonPropertyName("Data")]
    public JsonElement Data { get; init; }
}