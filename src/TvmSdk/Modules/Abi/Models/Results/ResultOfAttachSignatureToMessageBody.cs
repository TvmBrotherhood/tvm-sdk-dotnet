namespace TvmSdk.Modules.Abi;

public record ResultOfAttachSignatureToMessageBody
{
    [JsonPropertyName("body")]
    public string Body { get; init; }
}