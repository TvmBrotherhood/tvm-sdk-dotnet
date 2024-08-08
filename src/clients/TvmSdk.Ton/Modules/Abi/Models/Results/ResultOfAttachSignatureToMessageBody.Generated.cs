namespace TvmSdk.Ton.Modules.Abi;

public record ResultOfAttachSignatureToMessageBody
{
    [JsonPropertyName("body")]
    public string Body { get; init; }
}