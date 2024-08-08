namespace TvmSdk.Everscale.Modules.Crypto;

public record ResultOfNaclSignDetachedVerify
{
    /// <summary>
    /// <c>true</c> if verification succeeded or <c>false</c> if it failed.
    /// </summary>
    [JsonPropertyName("succeeded")]
    public bool Succeeded { get; init; }
}