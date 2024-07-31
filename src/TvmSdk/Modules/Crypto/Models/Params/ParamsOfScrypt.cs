namespace TvmSdk.Modules.Crypto;

public record ParamsOfScrypt
{
    /// <summary>
    /// The password bytes to be hashed.<para/>
    /// Must be encoded with <c>base64</c>.
    /// </summary>
    [JsonPropertyName("password")]
    public string Password { get; init; }

    /// <summary>
    /// Salt bytes that modify the hash to protect against Rainbow table attacks.<para/>
    /// Must be encoded with <c>base64</c>.
    /// </summary>
    [JsonPropertyName("salt")]
    public string Salt { get; init; }

    /// <summary>
    /// CPU/memory cost parameter.
    /// </summary>
    [JsonPropertyName("log_n")]
    public byte LogN { get; init; }

    /// <summary>
    /// The block size parameter, which fine-tunes sequential memory read size and performance.
    /// </summary>
    [JsonPropertyName("r")]
    public uint R { get; init; }

    /// <summary>
    /// Parallelization parameter.
    /// </summary>
    [JsonPropertyName("p")]
    public uint P { get; init; }

    /// <summary>
    /// Intended output length in octets of the derived key.
    /// </summary>
    [JsonPropertyName("dk_len")]
    public uint DkLen { get; init; }
}