namespace TvmSdk.Everscale.Modules.Net;

public record ParamsOfIteratorNext
{
    /// <summary>
    /// Iterator handle.
    /// </summary>
    [JsonPropertyName("iterator")]
    public uint Iterator { get; init; }

    /// <remarks>
    /// If value is missing or is less than 1 the library uses 1.
    /// </remarks>
    [JsonPropertyName("limit")]
    public uint? Limit { get; init; }

    /// <summary>
    /// Indicates that function must return the iterator state that can be used for resuming iteration.
    /// </summary>
    [JsonPropertyName("return_resume_state")]
    public bool? ReturnResumeState { get; init; }
}