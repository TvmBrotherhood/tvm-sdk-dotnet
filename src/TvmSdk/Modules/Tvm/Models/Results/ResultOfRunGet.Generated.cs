namespace TvmSdk.Modules.Tvm;

public record ResultOfRunGet
{
    /// <summary>
    /// Values returned by get-method on stack.
    /// </summary>
    [JsonPropertyName("output")]
    public JsonElement Output { get; init; }
}