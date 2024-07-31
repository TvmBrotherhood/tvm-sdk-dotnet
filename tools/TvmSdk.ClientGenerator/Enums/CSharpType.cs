namespace TvmSdk.ClientGenerator.Enums;

public enum CSharpType
{
    String,
    // -2,147,483,648 to 2,147,483,647
    Int,
    // -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
    Long,
    // -128 to 127
    SByte,
    // 0 to 255
    Byte,
    // -32,768 to 32,767
    Short,
    // 0 to 65,535
    UShort,
    // 0 to 4,294,967,295
    UInt,
    // 0 to 18,446,744,073,709,551,615
    ULong,
    Float,
    Double,
    Decimal,
    Bool,
    Char,
    Object,
    Dynamic,
}