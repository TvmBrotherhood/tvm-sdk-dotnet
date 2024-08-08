using System.Text.Json.Serialization;

namespace TvmSdk.Ton.Modules.Processing;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(Boc), typeDiscriminator: "Boc")]
[JsonDerivedType(typeof(HashAddress), typeDiscriminator: "HashAddress")]
public abstract record MonitoredMessage
{
    /// <summary>
    /// BOC of the message.
    /// </summary>
    public record Boc : MonitoredMessage
    {
        [JsonPropertyName("boc")]
        public string BocValue { get; init; }
    }

    /// <summary>
    /// Message's hash and destination address.
    /// </summary>
    public record HashAddress : MonitoredMessage
    {
        /// <summary>
        /// Hash of the message.
        /// </summary>
        [JsonPropertyName("hash")]
        public string Hash { get; init; }

        /// <summary>
        /// Destination address of the message.
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; init; }
    }
}