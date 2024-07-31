namespace TvmSdk.Modules.Net;

public record ResultOfIteratorNext
{
    /// <remarks>
    /// Note that <c>iterator_next</c> can return an empty items and <c>has_more</c> equals to <c>true</c>.<para/>
    /// In this case the application have to continue iteration.<para/>
    /// Such situation can take place when there is no data yet but the requested <c>end_time</c> is not reached.
    /// </remarks>
    [JsonPropertyName("items")]
    public JsonElement[] Items { get; init; }

    /// <summary>
    /// Indicates that there are more available items in iterated range.
    /// </summary>
    [JsonPropertyName("has_more")]
    public bool HasMore { get; init; }

    /// <remarks>
    /// This field is returned only if the <c>return_resume_state</c> parameter is specified.<para/>
    /// Note that <c>resume_state</c> corresponds to the iteration position after the returned items.
    /// </remarks>
    [JsonPropertyName("resume_state")]
    public JsonElement? ResumeState { get; init; }
}