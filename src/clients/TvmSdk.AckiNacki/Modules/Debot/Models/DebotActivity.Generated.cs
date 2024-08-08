using System.Text.Json.Serialization;

namespace TvmSdk.AckiNacki.Modules.Debot;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(Transaction), typeDiscriminator: "Transaction")]
/// <summary>
/// <a href="UNSTABLE.md">UNSTABLE</a><a href="DEPRECATED.md">DEPRECATED</a> Describes the operation that the DeBot wants to perform.
/// </summary>
public abstract record DebotActivity
{
    /// <summary>
    /// DeBot wants to create new transaction in blockchain.
    /// </summary>
    public record Transaction : DebotActivity
    {
        /// <summary>
        /// External inbound message BOC.
        /// </summary>
        [JsonPropertyName("msg")]
        public string Msg { get; init; }

        /// <summary>
        /// Target smart contract address.
        /// </summary>
        [JsonPropertyName("dst")]
        public string Dst { get; init; }

        /// <summary>
        /// List of spendings as a result of transaction.
        /// </summary>
        [JsonPropertyName("out")]
        public Spending[] Out { get; init; }

        /// <summary>
        /// Transaction total fee.
        /// </summary>
        [JsonPropertyName("fee")]
        public ulong Fee { get; init; }

        /// <summary>
        /// Indicates if target smart contract updates its code.
        /// </summary>
        [JsonPropertyName("setcode")]
        public bool Setcode { get; init; }

        /// <summary>
        /// Public key from keypair that was used to sign external message.
        /// </summary>
        [JsonPropertyName("signkey")]
        public string Signkey { get; init; }

        /// <summary>
        /// Signing box handle used to sign external message.
        /// </summary>
        [JsonPropertyName("signing_box_handle")]
        public uint SigningBoxHandle { get; init; }
    }
}