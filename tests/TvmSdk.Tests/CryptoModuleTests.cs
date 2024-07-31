using TvmSdk.Modules.Crypto;
using TvmSdk.Tests.Extensions;

namespace TvmSdk.Tests;

public class CryptoModuleTests
{
    private readonly ICryptoModule _sut = new TvmClient().Crypto;

    [Fact]
    public async Task Factorize_IsValid_True()
    {
        // Arrange
        var @params = new ParamsOfFactorize
        {
            Composite = "17ED48941A08F981"
        };

        // Act
        var result = await _sut.Factorize(@params);

        // Assert
        Assert.Equal("494C553B", result.Factors[0]);
        Assert.Equal("53911073", result.Factors[1]);
    }

    [Fact]
    public async Task ModularPower_IsValid_True()
    {
        // Arrange
        var @params = new ParamsOfModularPower
        {
            Base = "0123456789ABCDEF",
            Exponent = "0123",
            Modulus = "01234567"
        };

        // Act
        var result = await _sut.ModularPower(@params);

        // Assert
        Assert.Equal("63bfdf", result.ModularPower);
    }

    [Fact]
    public async Task GenerateRandomBytes_IsValid_True()
    {
        // Arrange
        var @params = new ParamsOfGenerateRandomBytes
        {
            Length = 32
        };

        // Act
        var result = await _sut.GenerateRandomBytes(@params);

        // Assert
        Assert.Equal(44, result.Bytes.Length);
    }

    [Fact]
    public async Task GenerateRandomSignKeys_IsValid_True()
    {
        // Act
        var result = await _sut.GenerateRandomSignKeys();

        // Assert
        Assert.Equal(64, result.Public.Length);
        Assert.Equal(64, result.Secret.Length);
    }

    [Fact]
    public async Task Sign_IsValid_True()
    {
        // Arrange
        var @params = new ParamsOfSign
        {
            Unsigned = "Test Message".ToBase64(),
            Keys = new KeyPair
            {
                Public = "1869b7ef29d58026217e9cf163cbfbd0de889bdf1bf4daebf5433a312f5b8d6e",
                Secret = "56b6a77093d6fdf14e593f36275d872d75de5b341942376b2a08759f3cbae78f"
            }
        };

        // Act
        var result = await _sut.Sign(@params);

        // Assert
        Assert.Equal(
            "+wz+QO6l1slgZS5s65BNqKcu4vz24FCJz4NSAxef9lu0jFfs8x3PzSZRC+pn5k8+aJi3xYMA3BQzglQmjK3hA1Rlc3QgTWVzc2FnZQ==",
            result.Signed);
        Assert.Equal(
            "fb0cfe40eea5d6c960652e6ceb904da8a72ee2fcf6e05089cf835203179ff65bb48c57ecf31dcfcd26510bea67e64f3e6898b7c58300dc14338254268cade103",
            result.Signature);
    }

    [Fact]
    public async Task VerifySignature_IsValid_True()
    {
        // Arrange
        var @params = new ParamsOfVerifySignature
        {
            Signed = "fb0cfe40eea5d6c960652e6ceb904da8a72ee2fcf6e05089cf835203179ff65bb48c57ecf31dcfcd26510bea67e64f3e6898b7c58300dc14338254268cade10354657374204d657373616765".HexToBase64(),
            Public = "1869b7ef29d58026217e9cf163cbfbd0de889bdf1bf4daebf5433a312f5b8d6e"
        };

        // Act
        var result = await _sut.VerifySignature(@params);

        // Assert
        Assert.Equal("Test Message", result.Unsigned.FromBase64());
    }

    [Fact]
    public async Task Sha256_IsValid_True()
    {
        // Arrange
        var @params = new ParamsOfHash
        {
            Data = "Message to hash with sha 256".ToBase64()
        };

        // Act
        var result = await _sut.Sha256(@params);

        // Assert
        Assert.Equal(
            "16fd057308dd358d5a9b3ba2de766b2dfd5e308478fc1f7ba5988db2493852f5",
            result.Hash);
    }

    [Fact]
    public async Task Sha512_IsValid_True()
    {
        // Arrange
        var @params = new ParamsOfHash
        {
            Data = "Message to hash with sha 512".ToBase64()
        };

        // Act
        var result = await _sut.Sha512(@params);

        // Assert
        Assert.Equal(
            "2616a44e0da827f0244e93c2b0b914223737a6129bc938b8edf2780ac9482960baa9b7c7cdb11457c1cebd5ae77e295ed94577f32d4c963dc35482991442daa5",
            result.Hash);
    }

    [Fact]
    public async Task Scrypt_IsValid_True()
    {
        // Arrange
        var @params = new ParamsOfScrypt
        {
            Password = "Test Password".ToBase64(),
            Salt = "Test Salt".ToBase64(),
            LogN = 10,
            R = 8,
            P = 16,
            DkLen = 64
        };

        // Act
        var result = await _sut.Scrypt(@params);

        // Assert
        Assert.Equal(
            "52e7fcf91356eca55fc5d52f16f5d777e3521f54e3c570c9bbb7df58fc15add73994e5db42be368de7ebed93c9d4f21f9be7cc453358d734b04a057d0ed3626d",
            result.Key);
    }

    [Fact]
    public async Task NaclSignKeypairFromSecretKey_IsValid_True()
    {
        // Arrange
        var @params = new ParamsOfNaclSignKeyPairFromSecret
        {
            Secret = "8fb4f2d256e57138fb310b0a6dac5bbc4bee09eb4821223a720e5b8e1f3dd674"
        };

        // Act
        var result = await _sut.NaclSignKeypairFromSecretKey(@params);

        // Assert
        Assert.Equal(
            "aa5533618573860a7e1bf19f34bd292871710ed5b2eafa0dcdbb33405f2231c6",
            result.Public);
    }

    [Fact]
    public async Task NaclSign_IsValid_True()
    {
        // Arrange
        var @params = new ParamsOfNaclSign
        {
            Unsigned = "Test Message".ToBase64(),
            Secret =
                "56b6a77093d6fdf14e593f36275d872d75de5b341942376b2a08759f3cbae78f1869b7ef29d58026217e9cf163cbfbd0de889bdf1bf4daebf5433a312f5b8d6e"
        };

        // Act
        var result = await _sut.NaclSign(@params);

        // Assert
        Assert.Equal(
            "+wz+QO6l1slgZS5s65BNqKcu4vz24FCJz4NSAxef9lu0jFfs8x3PzSZRC+pn5k8+aJi3xYMA3BQzglQmjK3hA1Rlc3QgTWVzc2FnZQ==",
            result.Signed);
    }

    [Fact]
    public async Task NaclSignOpen_IsValid_True()
    {
        // Arrange
        var @params = new ParamsOfNaclSignOpen
        {
            Public = "1869b7ef29d58026217e9cf163cbfbd0de889bdf1bf4daebf5433a312f5b8d6e",
            Signed = 
                "fb0cfe40eea5d6c960652e6ceb904da8a72ee2fcf6e05089cf835203179ff65bb48c57ecf31dcfcd26510bea67e64f3e6898b7c58300dc14338254268cade10354657374204d657373616765".HexToBase64()
        };

        // Act
        var result = await _sut.NaclSignOpen(@params);

        // Assert
        Assert.Equal("Test Message", result.Unsigned.FromBase64());
    }

    [Fact]
    public async Task NaclSignDetached_IsValid_True()
    {
        // Arrange
        var @params = new ParamsOfNaclSign
        {
            Secret =
                "56b6a77093d6fdf14e593f36275d872d75de5b341942376b2a08759f3cbae78f1869b7ef29d58026217e9cf163cbfbd0de889bdf1bf4daebf5433a312f5b8d6e",
            Unsigned = "Test Message".ToBase64()
        };

        // Act
        var result = await _sut.NaclSignDetached(@params);

        // Assert
        Assert.Equal(
            "fb0cfe40eea5d6c960652e6ceb904da8a72ee2fcf6e05089cf835203179ff65bb48c57ecf31dcfcd26510bea67e64f3e6898b7c58300dc14338254268cade103",
            result.Signature);
    }

    [Fact]
    public async Task NaclBoxKeypair_IsValid_True()
    {
        // Act
        var result = await _sut.NaclBoxKeypair();

        // Assert
        Assert.Equal(64, result.Public.Length);
        Assert.Equal(64, result.Secret.Length);
        Assert.NotEqual(result.Public, result.Secret);
    }

    [Fact]
    public async Task NaclBoxKeypairFromSecretKey_IsValid_True()
    {
        // Arrange
        var @params = new ParamsOfNaclBoxKeyPairFromSecret
        {
            Secret = "e207b5966fb2c5be1b71ed94ea813202706ab84253bdf4dc55232f82a1caf0d4"
        };

        // Act
        var result = await _sut.NaclBoxKeypairFromSecretKey(@params);

        // Assert
        Assert.Equal(
            "a53b003d3ffc1e159355cb37332d67fc235a7feb6381e36c803274074dc3933a",
            result.Public);
        Assert.Equal(
            @params.Secret,
            result.Secret);
    }

    [Fact]
    public async Task NaclBox_IsValid_True()
    {
        // Arrange
        var @params = new ParamsOfNaclBox
        {
            Decrypted = "Test Message".ToBase64(),
            Nonce = "cd7f99924bf422544046e83595dd5803f17536f5c9a11746",
            TheirPublic = "c4e2d9fe6a6baf8d1812b799856ef2a306291be7a7024837ad33a8530db79c6b",
            Secret = "d9b9dc5033fb416134e5d2107fdbacab5aadb297cb82dbdcd137d663bac59f7f"
        };

        // Act
        var result = await _sut.NaclBox(@params);

        // Assert
        Assert.Equal("li4XED4kx/pjQ2qdP0eR2d/K30uN94voNADxwA==", result.Encrypted);
    }

    [Fact]
    public async Task NaclBoxOpen_IsValid_True()
    {
        // Arrange
        var @params = new ParamsOfNaclBoxOpen
        {
            Encrypted = "962e17103e24c7fa63436a9d3f4791d9dfcadf4b8df78be83400f1c0".HexToBase64(),
            Nonce = "cd7f99924bf422544046e83595dd5803f17536f5c9a11746",
            TheirPublic = "c4e2d9fe6a6baf8d1812b799856ef2a306291be7a7024837ad33a8530db79c6b",
            Secret = "d9b9dc5033fb416134e5d2107fdbacab5aadb297cb82dbdcd137d663bac59f7f"
        };

        // Act
        var result = await _sut.NaclBoxOpen(@params);

        // Assert
        Assert.Equal("Test Message", result.Decrypted.FromBase64());
    }

    [Fact]
    public async Task NaclSecretBox_IsValid_True()
    {
        // Arrange
        var @params = new ParamsOfNaclSecretBox
        {
            Decrypted = "Test Message".ToBase64(),
            Nonce = "2a33564717595ebe53d91a785b9e068aba625c8453a76e45",
            Key = "8f68445b4e78c000fe4d6b7fc826879c1e63e3118379219a754ae66327764bd8"
        };

        // Act
        var result = await _sut.NaclSecretBox(@params);

        // Assert
        Assert.Equal("JL7ejKWe2KXmrsns41yfXoQF0t/C1Q8RGyzQ2A==", result.Encrypted);
    }

    [Fact]
    public async Task NaclSecretBoxOpen_IsValid_True()
    {
        // Arrange
        var @params = new ParamsOfNaclSecretBoxOpen
        {
            Encrypted = "24bede8ca59ed8a5e6aec9ece35c9f5e8405d2dfc2d50f111b2cd0d8".HexToBase64(),
            Nonce = "2a33564717595ebe53d91a785b9e068aba625c8453a76e45",
            Key = "8f68445b4e78c000fe4d6b7fc826879c1e63e3118379219a754ae66327764bd8"
        };

        // Act
        var result = await _sut.NaclSecretBoxOpen(@params);

        // Assert
        Assert.Equal("Test Message", result.Decrypted.FromBase64());
    }

    [Fact]
    public async Task MnemonicWords_IsValid_True()
    {
        // Arrange
        var @params = new ParamsOfMnemonicWords
        {
            Dictionary = null
        };

        // Act
        var result = await _sut.MnemonicWords(@params);

        // Assert
        Assert.Equal(2048, result.Words.Split(' ').Length);
    }

    [Fact]
    public async Task MnemonicFromRandom_GeneratesRandomMnemonicWords_GeneratedPhraseLengthAsExpected()
    {
        var mnemonicDictionaryValue = Enum.GetValues<MnemonicDictionary>().Cast<MnemonicDictionary?>().Concat([null]);
        
        foreach (var dictionary in mnemonicDictionaryValue)
        foreach (var wordCount in new byte?[] { null, 12, 15, 18, 21, 24 })
        {
            // Arrange
            var @params = new ParamsOfMnemonicFromRandom
            {
                Dictionary = dictionary,
                WordCount = wordCount
            };

            // Act
            var result = await _sut.MnemonicFromRandom(@params);

            // Assert
            Assert.Equal(wordCount ?? 12, result.Phrase.Split(' ').Length);
        }
    }

    [Fact]
    public async Task MnemonicFromEntropy_IsValid_True()
    {
        // Arrange
        var @params = new ParamsOfMnemonicFromEntropy
        {
            Entropy = "00112233445566778899AABBCCDDEEFF",
            Dictionary = MnemonicDictionary.English,
            WordCount = 12
        };

        // Act
        var result = await _sut.MnemonicFromEntropy(@params);

        // Assert
        Assert.Equal(
            "abandon math mimic master filter design carbon crystal rookie group knife young",
            result.Phrase);
    }

    [Theory]
    [InlineData("ridge strategy type basic athlete foster hold girl peasant coin state more", true)]
    [InlineData("one two", false)]
    public async Task MnemonicVerify_IsValid_True(string phrase, bool isValid)
    {
        // Arrange
        var @params = new ParamsOfMnemonicVerify
        {
            Dictionary = null,
            WordCount = null,
            Phrase = phrase
        };

        // Act
        var result = await _sut.MnemonicVerify(@params);

        // Assert
        Assert.True(isValid == result.Valid);
    }

    [Theory]
    [InlineData(
        "unit follow zone decline glare flower crisp vocal adapt magic much mesh cherry teach mechanic rain float vicious solution assume hedgehog rail sort chuckle",
        null,
        MnemonicDictionary.Ton,
        24,
        "13bc2b9ffff617869fb88efdd35d31cbd222bae489b0c46d111ab61cd6c3f71f",
        "a32820391c3fc73ad9d145f9b269f7d93c93dd91ec70f1930b616e63db0ae7ff")]
    [InlineData(
        "unit follow zone decline glare flower crisp vocal adapt magic much mesh cherry teach mechanic rain float vicious solution assume hedgehog rail sort chuckle",
        "m",
        MnemonicDictionary.Ton,
        24,
        "c374990ccacb36a87cb016e54fd6fcf0c344e9b0bc6744d9db89f4c272ef9712",
        "92328f6ff49bb225167ec94f2b146a9560bdc5f3c4ff416624d60ed6e23e0d01")]
    [InlineData(
        "abandon math mimic master filter design carbon crystal rookie group knife young",
        null,
        null,
        null,
        "61c3c5b97a33c9c0a03af112fbb27e3f44d99e1f804853f9842bb7a6e5de3ff9",
        "832410564fbe7b1301cf48dc83cbb8a3008d3cf29e05b7457086d4de041030ea")]
    public async Task MnemonicDeriveSignKeys_IsValid_True(
        string phrase,
        string? path,
        MnemonicDictionary? dictionary,
        int? wordCount,
        string expectPublicKey,
        string expectPrivateKey
    )
    {
        // Arrange
        var @params = new ParamsOfMnemonicDeriveSignKeys
        {
            Dictionary = dictionary,
            Phrase = phrase,
            Path = path,
            WordCount = (byte?)wordCount
        };

        // Act
        var result = await _sut.MnemonicDeriveSignKeys(@params);

        // Assert
        Assert.Equal(expectPublicKey, result.Public);
        Assert.Equal(expectPrivateKey, result.Secret);
    }

    [Fact]
    public async Task HDKeyXPrvFromMnemonic_IsValid_True()
    {
        // Arrange
        var @params = new ParamsOfHDKeyXPrvFromMnemonic
        {
            Dictionary = null,
            Phrase = TestData.HDKey.Mnemonic,
            WordCount = null
        };

        // Act
        var result = await _sut.HdkeyXprvFromMnemonic(@params);

        // Assert
        Assert.Equal(
            TestData.HDKey.Xprv,
            result.Xprv);
    }

    [Fact]
    public async Task HDKeyDeriveFromXPrv_IsValid_True()
    {
        // Arrange
        var @params = new ParamsOfHDKeyDeriveFromXPrv
        {
            ChildIndex = 0,
            Hardened = false,
            Xprv = TestData.HDKey.Xprv
        };

        // Act
        var result = await _sut.HdkeyDeriveFromXprv(@params);

        // Assert
        Assert.Equal(
            TestData.HDKey.DerivedFromXprv,
            result.Xprv);
    }

    [Fact]
    public async Task HDKeyDeriveFromXPrvPath_IsValid_True()
    {
        // Arrange
        var @params = new ParamsOfHDKeyDeriveFromXPrvPath
        {
            Xprv = TestData.HDKey.Xprv,
            Path = "m/44'/60'/0'/0'"
        };

        // Act
        var result = await _sut.HdkeyDeriveFromXprvPath(@params);

        // Assert
        Assert.Equal(TestData.HDKey.DerivedFromXprvPath, result.Xprv);
    }

    [Fact]
    public async Task HDKeySecretFromXPrv_IsValid_True()
    {
        // Arrange
        var @params = new ParamsOfHDKeySecretFromXPrv
        {
            Xprv = TestData.HDKey.Xprv
        };

        // Act
        var result = await _sut.HdkeySecretFromXprv(@params);

        // Assert
        Assert.Equal(TestData.HDKey.SecretFromXprv, result.Secret);
    }

    [Fact]
    public async Task HDKeyPublicFromXPrv_IsValid_True()
    {
        // Arrange
        var @params = new ParamsOfHDKeyPublicFromXPrv
        {
            Xprv = TestData.HDKey.Xprv
        };

        // Act
        var result = await _sut.HdkeyPublicFromXprv(@params);

        // Assert
        Assert.Equal(TestData.HDKey.PublicFromXprv, result.Public);
    }

    private class TestData
    {
        public class HDKey
        {
            public const string Mnemonic = "abuse boss fly battle rubber wasp afraid hamster guide essence vibrant tattoo";

            public const string Xprv = "xprv9s21ZrQH143K25JhKqEwvJW7QAiVvkmi4WRenBZanA6kxHKtKAQQKwZG65kCyW5jWJ8NY9e3GkRoistUjjcpHNsGBUv94istDPXvqGNuWpC";

            public const string DerivedFromXprv = "xprv9uZwtSeoKf1swgAkVVCEUmC2at6t7MCJoHnBbn1MWJZyxQ4cySkVXPyNh7zjf9VjsP4vEHDDD2a6R35cHubg4WpzXRzniYiy8aJh1gNnBKv";

            public const string DerivedFromXprvPath = "xprvA1KNMo63UcGjmDF1bX39Cw2BXGUwrwMjeD5qvQ3tA3qS3mZQkGtpf4DHq8FDLKAvAjXsYGLHDP2dVzLu9ycta8PXLuSYib2T3vzLf3brVgZ";

            public const string SecretFromXprv = "0c91e53128fa4d67589d63a6c44049c1068ec28a63069a55ca3de30c57f8b365";
            public const string PublicFromXprv = "7b70008d0c40992283d488b1046739cf827afeabf647a5f07c4ad1e7e45a6f89";
        }
    }
}