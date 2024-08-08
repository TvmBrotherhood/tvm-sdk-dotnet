namespace TvmSdk.Ton.Modules.Abi;

public record ResultOfDecodeInitialData
{
    /// <remarks>
    /// Initial data is decoded if <c>abi</c> input parameter is provided.
    /// </remarks>
    [JsonPropertyName("initial_data")]
    public JsonElement InitialData { get; init; }

    /// <summary>
    /// Initial account owner's public key.
    /// </summary>
    [JsonPropertyName("initial_pubkey")]
    public string InitialPubkey { get; init; }
}