namespace TvmSdk.AckiNacki.Modules.Net;

public record ParamsOfResumeBlockIterator
{
    /// <remarks>
    /// Same as value returned from <c>iterator_next</c>.
    /// </remarks>
    [JsonPropertyName("resume_state")]
    public JsonElement ResumeState { get; init; }
}