using System.Text.Json.Serialization;

namespace TvmSdk.Modules.Net;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(QueryCollection), typeDiscriminator: "QueryCollection")]
[JsonDerivedType(typeof(WaitForCollection), typeDiscriminator: "WaitForCollection")]
[JsonDerivedType(typeof(AggregateCollection), typeDiscriminator: "AggregateCollection")]
[JsonDerivedType(typeof(QueryCounterparties), typeDiscriminator: "QueryCounterparties")]
public abstract record ParamsOfQueryOperation
{
    public record QueryCollection : ParamsOfQueryOperation
    {
        [JsonPropertyName("QueryCollection")]
        public ParamsOfQueryCollection QueryCollectionValue { get; init; }
    }

    public record WaitForCollection : ParamsOfQueryOperation
    {
        [JsonPropertyName("WaitForCollection")]
        public ParamsOfWaitForCollection WaitForCollectionValue { get; init; }
    }

    public record AggregateCollection : ParamsOfQueryOperation
    {
        [JsonPropertyName("AggregateCollection")]
        public ParamsOfAggregateCollection AggregateCollectionValue { get; init; }
    }

    public record QueryCounterparties : ParamsOfQueryOperation
    {
        [JsonPropertyName("QueryCounterparties")]
        public ParamsOfQueryCounterparties QueryCounterpartiesValue { get; init; }
    }
}