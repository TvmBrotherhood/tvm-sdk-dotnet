using System.Text.Json.Serialization;

namespace TvmSdk.Modules.Tvm;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(None), typeDiscriminator: "None")]
[JsonDerivedType(typeof(Uninit), typeDiscriminator: "Uninit")]
[JsonDerivedType(typeof(Account), typeDiscriminator: "Account")]
public abstract record AccountForExecutor
{
    /// <summary>
    /// Non-existing account to run a creation internal message.<para/>
    /// Should be used with <c>skip_transaction_check = true</c> if the message has no deploy data since transactions on the uninitialized account are always aborted.
    /// </summary>
    public record None : AccountForExecutor
    {
    }

    /// <summary>
    /// Emulate uninitialized account to run deploy message.
    /// </summary>
    public record Uninit : AccountForExecutor
    {
    }

    /// <summary>
    /// Account state to run message.
    /// </summary>
    public record Account : AccountForExecutor
    {
        /// <remarks>
        /// Encoded as base64.
        /// </remarks>
        [JsonPropertyName("boc")]
        public string Boc { get; init; }

        /// <remarks>
        /// Can be used to calculate transaction fees without balance check.
        /// </remarks>
        [JsonPropertyName("unlimited_balance")]
        public bool? UnlimitedBalance { get; init; }
    }
}