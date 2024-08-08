namespace TvmSdk.Ton.Modules.Utils;

/// <summary>
/// Misc utility Functions.
/// </summary>
public interface IUtilsModule
{
    /// <summary>
    /// Converts address from any TON format to any TON format.
    /// </summary>
    Task<ResultOfConvertAddress> ConvertAddress(ParamsOfConvertAddress @params);

    /// <remarks>
    /// Address types are the following  <c>0:919db8e740d50bf349df2eea03fa30c385d846b991ff5542e67098ee833fc7f7</c> - standard TON address most commonly used in all cases.<para/>
    /// Also called as hex address <c>919db8e740d50bf349df2eea03fa30c385d846b991ff5542e67098ee833fc7f7</c> - account ID.<para/>
    /// A part of full address.<para/>
    /// Identifies account inside particular workchain <c>EQCRnbjnQNUL80nfLuoD+jDDhdhGuZH/VULmcJjugz/H9wam</c> - base64 address.<para/>
    /// Also called "user-friendly".<para/>
    /// Was used at the beginning of TON.<para/>
    /// Now it is supported for compatibility.
    /// </remarks>
    Task<ResultOfGetAddressType> GetAddressType(ParamsOfGetAddressType @params);

    /// <summary>
    /// Calculates storage fee for an account over a specified time period.
    /// </summary>
    Task<ResultOfCalcStorageFee> CalcStorageFee(ParamsOfCalcStorageFee @params);

    /// <summary>
    /// Compresses data using Zstandard algorithm.
    /// </summary>
    Task<ResultOfCompressZstd> CompressZstd(ParamsOfCompressZstd @params);

    /// <summary>
    /// Decompresses data using Zstandard algorithm.
    /// </summary>
    Task<ResultOfDecompressZstd> DecompressZstd(ParamsOfDecompressZstd @params);
}