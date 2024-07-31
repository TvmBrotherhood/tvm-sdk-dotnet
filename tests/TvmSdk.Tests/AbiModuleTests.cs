using System.Text.Json;
using System.Text.Json.Serialization;
using TvmSdk.Modules.Abi;
using TvmSdk.Modules.Crypto;

namespace TvmSdk.Tests;

public class AbiModuleTests
{
    private readonly IAbiModule _sut = new TvmClient().Abi;

    [Fact]
    public async Task AttachSignature_SignUnsignedMessage_MessageIsSigned()
    {
        // Arrange
        var @params = new ParamsOfAttachSignature
        {
            Abi = TestData.Contracts.Events.Abi,
            PublicKey = TestData.Keys.Public,
            Message = TestData.UnsignedMessage,
            Signature = TestData.Signature
        };

        // Act
        var result = await _sut.AttachSignature(@params);

        // Assert
        Assert.Equal(TestData.MessageWithSignature, result.Message);
    }

    [Fact]
    public async Task DecodeMessage_EventsAbiContract_True()
    {
        // Arrange
        var @params = new ParamsOfDecodeMessage
        {
            Abi = TestData.Contracts.Events.Abi,
            Message = TestData.SignedMessage
        };

        // Act
        var result = await _sut.DecodeMessage(@params);

        // Assert
        Assert.Equal(TestData.DecodedMessageBody.BodyType, result.BodyType);
        Assert.Equal(TestData.DecodedMessageBody.Header, result.Header);
        Assert.Equal(TestData.DecodedMessageBody.Name, result.Name);
        Assert.Equal(TestData.DecodedMessageBody.Value?.GetRawText(), result.Value?.GetRawText());
    }

    [Fact]
    public async Task DecodeMessageBody_EventsAbiContract_True()
    {
        // Arrange
        var @params = new ParamsOfDecodeMessageBody
        {
            Abi = TestData.Contracts.Events.Abi,
            Body =
                "te6ccgEBAgEAlgAB4a3f2/jCeWWvgMoAXOakv3VSD56sQrDPT76n1cbrSvpZ0BCs0KEUy2Duvo3zPExePONW3TYy0MCA1i+FFRXcSIXTHxAj/Hd67jWQF7peccWoU/dbMCBJBB6YdPCVZcJlJkAAAF0ZyXLg19VzGQVviwSgAQBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA="
        };

        // Act
        var result = await _sut.DecodeMessageBody(@params);

        // Assert
        Assert.Equal(TestData.DecodedMessageBody.BodyType, result.BodyType);
        Assert.Equal(TestData.DecodedMessageBody.Header, result.Header);
        Assert.Equal(TestData.DecodedMessageBody.Name, result.Name);
        Assert.Equal(TestData.DecodedMessageBody.Value?.GetRawText(), result.Value?.GetRawText());
    }

    [Fact]
    public async Task EncodeMessage_SignerExternal_UnsignedMessageIsEqualToResultMessage()
    {
        // Arrange
        var @params = DeployParams(new Signer.External
        {
            PublicKey = TestData.Keys.Public
        });

        // Act
        var result = await _sut.EncodeMessage(@params);

        // Assert
        Assert.Equal(TestData.UnsignedMessage, result.Message);
    }

    [Fact]
    public async Task EncodeMessage_DeploySignerKeys_True()
    {
        // Arrange
        var @params = DeployParams(new Signer.Keys()
        {
            KeysValue = TestData.Keys
        });

        // Act
        var result = await _sut.EncodeMessage(@params);

        // Assert
        Assert.Equal(
            "te6ccgECGAEAA6wAA0eIAAt9aqvShfTon7Lei1PVOhUEkEEZQkhDKPgNyzeTL6YSEbAHAgEA4bE5Gr3mWwDtlcEOWHr6slWoyQlpIWeYyw/00eKFGFkbAJMMFLWnu0mq4HSrPmktmzeeAboa4kxkFymCsRVt44dTHxAj/Hd67jWQF7peccWoU/dbMCBJBB6YdPCVZcJlJkAAAF0ZyXLg19VzGRotV8/gAQHAAwIDzyAGBAEB3gUAA9AgAEHaY+IEf47vXcayAvdLzji1Cn7rZgQJIIPTDp4SrLhMpMwCJv8A9KQgIsABkvSg4YrtU1gw9KEKCAEK9KQg9KEJAAACASANCwHI/38h7UTQINdJwgGOENP/0z/TANF/+GH4Zvhj+GKOGPQFcAGAQPQO8r3XC//4YnD4Y3D4Zn/4YeLTAAGOHYECANcYIPkBAdMAAZTT/wMBkwL4QuIg+GX5EPKoldMAAfJ64tM/AQwAao4e+EMhuSCfMCD4I4ED6KiCCBt3QKC53pL4Y+CANPI02NMfAfgjvPK50x8B8AH4R26S8jzeAgEgEw4CASAQDwC9uotV8/+EFujjXtRNAg10nCAY4Q0//TP9MA0X/4Yfhm+GP4Yo4Y9AVwAYBA9A7yvdcL//hicPhjcPhmf/hh4t74RvJzcfhm0fgA+ELIy//4Q88LP/hGzwsAye1Uf/hngCASASEQDluIAGtb8ILdHCfaiaGn/6Z/pgGi//DD8M3wx/DFvfSDK6mjofSBv6PwikDdJGDhvfCFdeXAyfABkZP2CEGRnwoRnRoIEB9AAAAAAAAAAAAAAAAAAIGeLZMCAQH2AGHwhZGX//CHnhZ/8I2eFgGT2qj/8M8ADFuZPCot8ILdHCfaiaGn/6Z/pgGi//DD8M3wx/DFva4b/yupo6Gn/7+j8AGRF7gAAAAAAAAAAAAAAAAhni2fA58jjyxi9EOeF/+S4/YAYfCFkZf/8IeeFn/wjZ4WAZPaqP/wzwAgFIFxQBCbi3xYJQFQH8+EFujhPtRNDT/9M/0wDRf/hh+Gb4Y/hi3tcN/5XU0dDT/9/R+ADIi9wAAAAAAAAAAAAAAAAQzxbPgc+Rx5YxeiHPC//JcfsAyIvcAAAAAAAAAAAAAAAAEM8Wz4HPklb4sEohzwv/yXH7ADD4QsjL//hDzws/+EbPCwDJ7VR/FgAE+GcActxwItDWAjHSADDcIccAkvI74CHXDR+S8jzhUxGS8jvhwQQighD////9vLGS8jzgAfAB+EdukvI83g==",
            result.Message);
    }

    [Fact]
    public async Task EncodeMessage_RunSignerExternal_True()
    {
        // Arrange
        var @params = RunParams(new Signer.External
        {
            PublicKey = TestData.Keys.Public
        });

        // Act
        var result = await _sut.EncodeMessage(@params);

        // Assert
        Assert.Equal(
            "te6ccgEBAgEAeAABpYgAC31qq9KF9Oifst6LU9U6FQSQQRlCSEMo+A3LN5MvphIFMfECP8d3ruNZAXul5xxahT91swIEkEHph08JVlwmUmQAAAXRnJcuDX1XMZBW+LBKAQBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=",
            result.Message);
    }

    [Fact]
    public async Task EncodeMessage_RunSignerKeys_True()
    {
        // Arrange
        var @params = RunParams(new Signer.Keys
        {
            KeysValue = TestData.Keys
        });

        // Act
        var result = await _sut.EncodeMessage(@params);

        // Assert
        Assert.Equal(
            "te6ccgEBAwEAvAABRYgAC31qq9KF9Oifst6LU9U6FQSQQRlCSEMo+A3LN5MvphIMAQHhrd/b+MJ5Za+AygBc5qS/dVIPnqxCsM9PvqfVxutK+lnQEKzQoRTLYO6+jfM8TF4841bdNjLQwIDWL4UVFdxIhdMfECP8d3ruNZAXul5xxahT91swIEkEHph08JVlwmUmQAAAXRnJcuDX1XMZBW+LBKACAEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==",
            result.Message);
    }

    [Fact]
    public async Task EncodeMessage_RunExternalSigner_True()
    {
        // Arrange
        var @params = RunParams(new Signer.None());

        // Act
        var result = await _sut.EncodeMessage(@params);

        // Assert
        Assert.Equal(
            "te6ccgEBAQEAVQAApYgAC31qq9KF9Oifst6LU9U6FQSQQRlCSEMo+A3LN5MvphIAAAAC6M5Llwa+q5jIK3xYJAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB",
            result.Message);
    }

    private ParamsOfEncodeMessage DeployParams(Signer signer)
    {
        return new ParamsOfEncodeMessage
        {
            Abi = TestData.Contracts.Events.Abi,
            Address = null,
            DeploySet = new DeploySet
            {
                InitialData = null,
                Tvc = TestData.Contracts.Events.TvcBase64,
                WorkchainId = null
            },
            CallSet = new CallSet
            {
                FunctionName = "constructor",
                Header = new FunctionHeader
                {
                    Expire = TestData.Expire,
                    Time = TestData.Time,
                    Pubkey = null
                },
                Input = null
            },
            Signer = signer,
            ProcessingTryIndex = null
        };
    }

    private ParamsOfEncodeMessage RunParams(Signer signer)
    {
        return new ParamsOfEncodeMessage
        {
            Abi = TestData.Contracts.Events.Abi,
            Address = "0:05beb555e942fa744fd96f45a9ea9d0a8248208ca12421947c06e59bc997d309",
            DeploySet = null,
            CallSet = new CallSet
            {
                FunctionName = "returnValue",
                Header = new FunctionHeader
                {
                    Expire = TestData.Expire,
                    Time = TestData.Time,
                    Pubkey = null
                },
                Input = TestData.MessageBody
            },
            Signer = signer,
            ProcessingTryIndex = null
        };
    }

    private static class TestData
    {
        internal const long Time = 1599458364291;
        internal const uint Expire = 1599458404;

        internal static readonly string UnsignedMessage =
            "te6ccgECFwEAA2gAAqeIAAt9aqvShfTon7Lei1PVOhUEkEEZQkhDKPgNyzeTL6YSEZTHxAj/Hd67jWQF7peccWoU/" +
            "dbMCBJBB6YdPCVZcJlJkAAAF0ZyXLg19VzGRotV8/gGAQEBwAICA88gBQMBAd4EAAPQIABB2mPiBH+O713GsgL3S8" +
            "44tQp+62YECSCD0w6eEqy4TKTMAib/APSkICLAAZL0oOGK7VNYMPShCQcBCvSkIPShCAAAAgEgDAoByP9/Ie1E0CD" +
            "XScIBjhDT/9M/0wDRf/hh+Gb4Y/hijhj0BXABgED0DvK91wv/+GJw+GNw+GZ/+GHi0wABjh2BAgDXGCD5AQHTAAGU" +
            "0/8DAZMC+ELiIPhl+RDyqJXTAAHyeuLTPwELAGqOHvhDIbkgnzAg+COBA+iogggbd0Cgud6S+GPggDTyNNjTHwH4I" +
            "7zyudMfAfAB+EdukvI83gIBIBINAgEgDw4AvbqLVfP/hBbo417UTQINdJwgGOENP/0z/TANF/+GH4Zvhj+GKOGPQF" +
            "cAGAQPQO8r3XC//4YnD4Y3D4Zn/4YeLe+Ebyc3H4ZtH4APhCyMv/+EPPCz/4Rs8LAMntVH/4Z4AgEgERAA5biABrW" +
            "/CC3Rwn2omhp/+mf6YBov/ww/DN8Mfwxb30gyupo6H0gb+j8IpA3SRg4b3whXXlwMnwAZGT9ghBkZ8KEZ0aCBAfQA" +
            "AAAAAAAAAAAAAAAACBni2TAgEB9gBh8IWRl//wh54Wf/CNnhYBk9qo//DPAAxbmTwqLfCC3Rwn2omhp/+mf6YBov/" +
            "ww/DN8Mfwxb2uG/8rqaOhp/+/o/ABkRe4AAAAAAAAAAAAAAAAIZ4tnwOfI48sYvRDnhf/kuP2AGHwhZGX//CHnhZ/" +
            "8I2eFgGT2qj/8M8AIBSBYTAQm4t8WCUBQB/PhBbo4T7UTQ0//TP9MA0X/4Yfhm+GP4Yt7XDf+V1NHQ0//f0fgAyIv" +
            "cAAAAAAAAAAAAAAAAEM8Wz4HPkceWMXohzwv/yXH7AMiL3AAAAAAAAAAAAAAAABDPFs+Bz5JW+LBKIc8L/8lx+wAw" +
            "+ELIy//4Q88LP/hGzwsAye1UfxUABPhnAHLccCLQ1gIx0gAw3CHHAJLyO+Ah1w0fkvI84VMRkvI74cEEIoIQ/////" +
            "byxkvI84AHwAfhHbpLyPN4=";

        internal static readonly string Signature =
            "6272357bccb601db2b821cb0f5f564ab519212d242cf31961fe9a3c50a30b236012618296b4f769355c0e9567cd25b366f3c037435c498c82e5305622adbc70e";

        internal static readonly string MessageWithSignature =
            "te6ccgECGAEAA6wAA0eIAAt9aqvShfTon7Lei1PVOhUEkEEZQkhDKPgNyzeTL6YSEbAHAgEA4bE5Gr3mWwDtlcEOWH" +
            "r6slWoyQlpIWeYyw/00eKFGFkbAJMMFLWnu0mq4HSrPmktmzeeAboa4kxkFymCsRVt44dTHxAj/Hd67jWQF7peccWo" +
            "U/dbMCBJBB6YdPCVZcJlJkAAAF0ZyXLg19VzGRotV8/gAQHAAwIDzyAGBAEB3gUAA9AgAEHaY+IEf47vXcayAvdLzj" +
            "i1Cn7rZgQJIIPTDp4SrLhMpMwCJv8A9KQgIsABkvSg4YrtU1gw9KEKCAEK9KQg9KEJAAACASANCwHI/38h7UTQINdJ" +
            "wgGOENP/0z/TANF/+GH4Zvhj+GKOGPQFcAGAQPQO8r3XC//4YnD4Y3D4Zn/4YeLTAAGOHYECANcYIPkBAdMAAZTT/w" +
            "MBkwL4QuIg+GX5EPKoldMAAfJ64tM/AQwAao4e+EMhuSCfMCD4I4ED6KiCCBt3QKC53pL4Y+CANPI02NMfAfgjvPK5" +
            "0x8B8AH4R26S8jzeAgEgEw4CASAQDwC9uotV8/+EFujjXtRNAg10nCAY4Q0//TP9MA0X/4Yfhm+GP4Yo4Y9AVwAYBA" +
            "9A7yvdcL//hicPhjcPhmf/hh4t74RvJzcfhm0fgA+ELIy//4Q88LP/hGzwsAye1Uf/hngCASASEQDluIAGtb8ILdHC" +
            "faiaGn/6Z/pgGi//DD8M3wx/DFvfSDK6mjofSBv6PwikDdJGDhvfCFdeXAyfABkZP2CEGRnwoRnRoIEB9AAAAAAAAA" +
            "AAAAAAAAAIGeLZMCAQH2AGHwhZGX//CHnhZ/8I2eFgGT2qj/8M8ADFuZPCot8ILdHCfaiaGn/6Z/pgGi//DD8M3wx/" +
            "DFva4b/yupo6Gn/7+j8AGRF7gAAAAAAAAAAAAAAAAhni2fA58jjyxi9EOeF/+S4/YAYfCFkZf/8IeeFn/wjZ4WAZPa" +
            "qP/wzwAgFIFxQBCbi3xYJQFQH8+EFujhPtRNDT/9M/0wDRf/hh+Gb4Y/hi3tcN/5XU0dDT/9/R+ADIi9wAAAAAAAAA" +
            "AAAAAAAQzxbPgc+Rx5YxeiHPC//JcfsAyIvcAAAAAAAAAAAAAAAAEM8Wz4HPklb4sEohzwv/yXH7ADD4QsjL//hDzw" +
            "s/+EbPCwDJ7VR/FgAE+GcActxwItDWAjHSADDcIccAkvI74CHXDR+S8jzhUxGS8jvhwQQighD////9vLGS8jzgAfAB" +
            "+EdukvI83g==";

        internal static readonly string SignedMessage = "te6ccgEBAwEAvAABRYgAC31qq9KF9Oifst6LU9U6FQSQQR" +
                                                        "lCSEMo+A3LN5MvphIMAQHhrd/b+MJ5Za+AygBc5qS/dVIPnqxCsM9PvqfVxutK+lnQEKzQoRTLYO6+jfM8TF4841bd" +
                                                        "NjLQwIDWL4UVFdxIhdMfECP8d3ruNZAXul5xxahT91swIEkEHph08JVlwmUmQAAAXRnJcuDX1XMZBW+LBKACAEAAAA" +
                                                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==";

        internal static readonly KeyPair Keys = new KeyPair
        {
            Public = "4c7c408ff1ddebb8d6405ee979c716a14fdd6cc08124107a61d3c25597099499",
            Secret = "cc8929d635719612a9478b9cd17675a39cfad52d8959e8a177389b8c0b9122a7"
        };

        internal static readonly JsonElement MessageBody = JsonDocument
            .Parse(@"{""id"":""0x0000000000000000000000000000000000000000000000000000000000000000""}").RootElement;

        internal static readonly DecodedMessageBody DecodedMessageBody = new()
        {
            BodyType = MessageBodyType.Input,
            Name = "returnValue",
            Header = new FunctionHeader
            {
                Expire = Expire,
                Time = Time,
                Pubkey = Keys.Public
            },
            Value = MessageBody
        };

        internal static class Contracts
        {
            internal static class Events
            {
                internal static readonly Abi.Contract Abi2 = new()
                {
                    Value = JsonSerializer.Deserialize<AbiContract>(
                        File.ReadAllText("test-data/contracts/v2/Events.abi.json"),
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                        }
                    ) // ?? throw new Exception("Could not initialize Events contracts")
                };

                internal static readonly Abi.Serialized Abi = new()
                {
                    Value = JsonSerializer.Deserialize<AbiContract>(
                        File.ReadAllText("test-data/contracts/v2/Events.abi.json"),
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                        }
                    ) // ?? throw new Exception("Could not initialize Events contracts")
                };

                internal static readonly string TvcBase64 =
                    Convert.ToBase64String(File.ReadAllBytes("test-data/contracts/v2/Events.tvc"));
            }
        }
    }
}