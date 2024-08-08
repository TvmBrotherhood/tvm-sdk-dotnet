namespace TvmSdk.Everscale.Modules.Abi;

public record ResultOfAttachSignatureToMessageBody
{
    [JsonPropertyName("body")]
    public string Body { get; init; }
}