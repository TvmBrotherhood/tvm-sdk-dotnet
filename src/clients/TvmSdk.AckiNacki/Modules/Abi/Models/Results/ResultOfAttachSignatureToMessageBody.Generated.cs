namespace TvmSdk.AckiNacki.Modules.Abi;

public record ResultOfAttachSignatureToMessageBody
{
    [JsonPropertyName("body")]
    public string Body { get; init; }
}