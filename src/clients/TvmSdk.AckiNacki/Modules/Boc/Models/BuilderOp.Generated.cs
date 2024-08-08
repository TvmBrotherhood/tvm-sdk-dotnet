using System.Text.Json.Serialization;

namespace TvmSdk.AckiNacki.Modules.Boc;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(Integer), typeDiscriminator: "Integer")]
[JsonDerivedType(typeof(BitString), typeDiscriminator: "BitString")]
[JsonDerivedType(typeof(Cell), typeDiscriminator: "Cell")]
[JsonDerivedType(typeof(CellBoc), typeDiscriminator: "CellBoc")]
[JsonDerivedType(typeof(Address), typeDiscriminator: "Address")]
/// <summary>
/// Cell builder operation.
/// </summary>
public abstract record BuilderOp
{
    /// <summary>
    /// Append integer to cell data.
    /// </summary>
    public record Integer : BuilderOp
    {
        /// <summary>
        /// Bit size of the value.
        /// </summary>
        [JsonPropertyName("size")]
        public uint Size { get; init; }

        /// <remarks>
        /// E.g.<para/>
        /// <c>123</c>, <c>-123</c>.<para/>
        /// - Decimal string.<para/>
        /// E.g.<para/>
        /// <c>"123"</c>, <c>"-123"</c>.<para/>
        /// - <c>0x</c> prefixed hexadecimal string.<para/>
        /// e.g <c>0x123</c>, <c>0X123</c>, <c>-0x123</c>.
        /// </remarks>
        [JsonPropertyName("value")]
        public JsonElement Value { get; init; }
    }

    /// <summary>
    /// Append bit string to cell data.
    /// </summary>
    public record BitString : BuilderOp
    {
        /// <remarks>
        /// Contains hexadecimal string representation: - Can end with <c>_</c> tag.<para/>
        /// - Can be prefixed with <c>x</c> or <c>X</c>.<para/>
        /// - Can be prefixed with <c>x{</c> or <c>X{</c> and ended with <c>}</c>.<para/>
        /// Contains binary string represented as a sequence of <c>0</c> and <c>1</c> prefixed with <c>n</c> or <c>N</c>.<para/>
        /// Examples: <c>1AB</c>, <c>x1ab</c>, <c>X1AB</c>, <c>x{1abc}</c>, <c>X{1ABC}</c><c>2D9_</c>, <c>x2D9_</c>, <c>X2D9_</c>, <c>x{2D9_}</c>, <c>X{2D9_}</c><c>n00101101100</c>, <c>N00101101100</c>.
        /// </remarks>
        [JsonPropertyName("value")]
        public string Value { get; init; }
    }

    /// <summary>
    /// Append ref to nested cells.
    /// </summary>
    public record Cell : BuilderOp
    {
        /// <summary>
        /// Nested cell builder.
        /// </summary>
        [JsonPropertyName("builder")]
        public BuilderOp[] Builder { get; init; }
    }

    /// <summary>
    /// Append ref to nested cell.
    /// </summary>
    public record CellBoc : BuilderOp
    {
        /// <summary>
        /// Nested cell BOC encoded with <c>base64</c> or BOC cache key.
        /// </summary>
        [JsonPropertyName("boc")]
        public string Boc { get; init; }
    }

    /// <summary>
    /// Address.
    /// </summary>
    public record Address : BuilderOp
    {
        /// <summary>
        /// Address in a common <c>workchain:account</c> or base64 format.
        /// </summary>
        [JsonPropertyName("address")]
        public string AddressValue { get; init; }
    }
}