using TvmSdk.Exceptions;
using TvmSdk.Interop.Enums;
using TvmSdk.Modules.Utils;

namespace TvmSdk.Tests;

public class UtilsModuleTests
{
    private readonly IUtilsModule _sut = new TvmClient().Utils;

    [Theory]
    [InlineData(Accounts.AccountId)]
    [InlineData(Accounts.Base64)]
    [InlineData(Accounts.Base64Url)]
    [InlineData(Accounts.Hex)]
    [InlineData(Accounts.HexWorkchain0)]
    public async Task ConvertAddressToAccountId_ValidAccountConversion_IsAccountIdAddress(string inputAddress)
    {
        // Act
        // var convertedAddress = await _sut
        //     .ConvertAddressToAccountId(inputAddress);
        var result = await _sut
            .ConvertAddress(new()
            {
                Address = inputAddress,
                OutputFormat = new AddressStringFormat.AccountId()
            });

        // Assert
        Assert.Equal(Accounts.AccountId, result.Address);
    }

    [Theory]
    [InlineData(Accounts.Base64)]
    [InlineData(Accounts.Base64Url)]
    [InlineData(Accounts.Hex)]
    public async Task ConvertAddressToHex_ValidAccountConversion_IsHexAddress(string inputAddress)
    {
        // Act
        var result = await _sut
            .ConvertAddress(new()
            {
                Address = inputAddress,
                OutputFormat = new AddressStringFormat.Hex()
            });

        // Assert
        Assert.Equal(Accounts.Hex, result.Address);
    }

    [Theory]
    [InlineData(Accounts.Base64)]
    [InlineData(Accounts.Base64Url)]
    [InlineData(Accounts.Hex)]
    public async Task ConvertAddressToBase64_DefaultOptionsAndValidAccountConversion_IsBase64Address(
        string inputAddress)
    {
        // Act
        var result = await _sut
            .ConvertAddress(new()
            {
                Address = inputAddress,
                OutputFormat = new AddressStringFormat.Base64()
            });

        // Assert
        Assert.Equal(Accounts.Base64, result.Address);
    }

    [Theory]
    [InlineData(Accounts.Base64)]
    [InlineData(Accounts.Base64Url)]
    [InlineData(Accounts.Hex)]
    public async Task ConvertAddressToBase64_NotDefaultOptionsAndValidAccountConversion_IsBase64Address(
        string inputAddress)
    {
        // Act
        var result = await _sut
            .ConvertAddress(new()
            {
                Address = inputAddress,
                OutputFormat = new AddressStringFormat.Base64
                {
                    Url = true,
                    Test = true,
                    Bounce = true,
                }
            });

        // Assert
        Assert.Equal(Accounts.Base64Url, result.Address);
    }

    [Theory]
    [InlineData(null, ErrorCode.InvalidParams)]
    [InlineData("", ErrorCode.InvalidAddress)]
    [InlineData(" ", ErrorCode.InvalidAddress)]
    [InlineData("asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasda", ErrorCode.InvalidAddress)]
    [InlineData("ㅂㅈㄷㄱ쇼ㅕㅑㅐㅔㅁㄴㅇㄹ호ㅓㅏㅣㅋㅌㅊ퓨ㅜㅡ", ErrorCode.InvalidAddress)]
    public async Task ConvertAddressToAccountId_InvalidAccountConversion_ExceptionIsThrown(
        string inputAddress,
        ErrorCode errorCode)
    {
        var exception = await Assert.ThrowsAsync<InvalidFunctionCallException>(
            async () => await _sut
                .ConvertAddress(new()
                {
                    Address = inputAddress,
                    OutputFormat = new AddressStringFormat.AccountId()
                }));
        Assert.Equal(errorCode, exception.Code);
    }

    public class Accounts
    {
        public const string AccountId = "fcb91a3a3816d0f7b8c2c76108b8a9bc5a6b7a55bd79f8ab101c52db29232260";
        public const string Hex = "-1:fcb91a3a3816d0f7b8c2c76108b8a9bc5a6b7a55bd79f8ab101c52db29232260";
        public const string HexWorkchain0 = "0:fcb91a3a3816d0f7b8c2c76108b8a9bc5a6b7a55bd79f8ab101c52db29232260";
        public const string Base64 = "Uf/8uRo6OBbQ97jCx2EIuKm8Wmt6Vb15+KsQHFLbKSMiYG+9";
        public const string Base64Url = "kf_8uRo6OBbQ97jCx2EIuKm8Wmt6Vb15-KsQHFLbKSMiYIny";
    }
}