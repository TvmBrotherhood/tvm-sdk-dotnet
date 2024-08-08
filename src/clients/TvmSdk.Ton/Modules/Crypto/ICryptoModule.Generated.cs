namespace TvmSdk.Ton.Modules.Crypto;

/// <summary>
/// Crypto functions.
/// </summary>
public interface ICryptoModule
{
    /// <remarks>
    /// Performs prime factorization – decomposition of a composite number into a product of smaller prime integers (factors).<para/>
    /// See [https://en.wikipedia.org/wiki/Integer_factorization].
    /// </remarks>
    Task<ResultOfFactorize> Factorize(ParamsOfFactorize @params);

    /// <remarks>
    /// Performs modular exponentiation for big integers (<c>base</c><c>exponent</c> mod <c>modulus</c>).<para/>
    /// See [https://en.wikipedia.org/wiki/Modular_exponentiation].
    /// </remarks>
    Task<ResultOfModularPower> ModularPower(ParamsOfModularPower @params);

    /// <summary>
    /// Calculates CRC16 using TON algorithm.
    /// </summary>
    Task<ResultOfTonCrc16> TonCrc16(ParamsOfTonCrc16 @params);

    /// <summary>
    /// Generates random byte array of the specified length and returns it in <c>base64</c> format.
    /// </summary>
    Task<ResultOfGenerateRandomBytes> GenerateRandomBytes(ParamsOfGenerateRandomBytes @params);

    /// <summary>
    /// Converts public key to ton safe_format.
    /// </summary>
    Task<ResultOfConvertPublicKeyToTonSafeFormat> ConvertPublicKeyToTonSafeFormat(ParamsOfConvertPublicKeyToTonSafeFormat @params);

    /// <summary>
    /// Generates random ed25519 key pair.
    /// </summary>
    Task<KeyPair> GenerateRandomSignKeys();

    /// <summary>
    /// Signs a data using the provided keys.
    /// </summary>
    Task<ResultOfSign> Sign(ParamsOfSign @params);

    /// <summary>
    /// Verifies signed data using the provided public key.<para/>
    /// Raises error if verification is failed.
    /// </summary>
    Task<ResultOfVerifySignature> VerifySignature(ParamsOfVerifySignature @params);

    /// <summary>
    /// Calculates SHA256 hash of the specified data.
    /// </summary>
    Task<ResultOfHash> Sha256(ParamsOfHash @params);

    /// <summary>
    /// Calculates SHA512 hash of the specified data.
    /// </summary>
    Task<ResultOfHash> Sha512(ParamsOfHash @params);

    /// <remarks>
    /// Derives key from <c>password</c> and <c>key</c> using <c>scrypt</c> algorithm.<para/>
    /// See [https://en.wikipedia.org/wiki/Scrypt].<para/>
    /// # Arguments - <c>log_n</c> - The log2 of the Scrypt parameter <c>N</c> - <c>r</c> - The Scrypt parameter <c>r</c> - <c>p</c> - The Scrypt parameter <c>p</c> # Conditions - <c>log_n</c> must be less than <c>64</c> - <c>r</c> must be greater than <c>0</c> and less than or equal to <c>4294967295</c> - <c>p</c> must be greater than <c>0</c> and less than <c>4294967295</c> # Recommended values sufficient for most use-cases - <c>log_n = 15</c> (<c>n = 32768</c>) - <c>r = 8</c> - <c>p = 1</c>.
    /// </remarks>
    Task<ResultOfScrypt> Scrypt(ParamsOfScrypt @params);

    /// <remarks>
    /// **NOTE:** In the result the secret key is actually the concatenation of secret and public keys (128 symbols hex string) by design of <a href="http://nacl.cr.yp.to/sign.html">NaCL</a>.<para/>
    /// See also <a href="https://crypto.stackexchange.com/questions/54353/">the stackexchange question</a>.
    /// </remarks>
    Task<KeyPair> NaclSignKeypairFromSecretKey(ParamsOfNaclSignKeyPairFromSecret @params);

    /// <summary>
    /// Signs data using the signer's secret key.
    /// </summary>
    Task<ResultOfNaclSign> NaclSign(ParamsOfNaclSign @params);

    /// <remarks>
    /// Verifies the signature in <c>signed</c> using the signer's public key <c>public</c> and returns the message <c>unsigned</c>.<para/>
    /// If the signature fails verification, crypto_sign_open raises an exception.
    /// </remarks>
    Task<ResultOfNaclSignOpen> NaclSignOpen(ParamsOfNaclSignOpen @params);

    /// <remarks>
    /// Signs the message <c>unsigned</c> using the secret key <c>secret</c> and returns a signature <c>signature</c>.
    /// </remarks>
    Task<ResultOfNaclSignDetached> NaclSignDetached(ParamsOfNaclSign @params);

    /// <summary>
    /// Verifies the signature with public key and <c>unsigned</c> data.
    /// </summary>
    Task<ResultOfNaclSignDetachedVerify> NaclSignDetachedVerify(ParamsOfNaclSignDetachedVerify @params);

    /// <summary>
    /// Generates a random NaCl key pair.
    /// </summary>
    Task<KeyPair> NaclBoxKeypair();

    /// <summary>
    /// Generates key pair from a secret key.
    /// </summary>
    Task<KeyPair> NaclBoxKeypairFromSecretKey(ParamsOfNaclBoxKeyPairFromSecret @params);

    /// <remarks>
    /// Encrypt and authenticate a message using the senders secret key, the receivers public key, and a nonce.
    /// </remarks>
    Task<ResultOfNaclBox> NaclBox(ParamsOfNaclBox @params);

    /// <summary>
    /// Decrypt and verify the cipher text using the receivers secret key, the senders public key, and the nonce.
    /// </summary>
    Task<ResultOfNaclBoxOpen> NaclBoxOpen(ParamsOfNaclBoxOpen @params);

    /// <summary>
    /// Encrypt and authenticate message using nonce and secret key.
    /// </summary>
    Task<ResultOfNaclBox> NaclSecretBox(ParamsOfNaclSecretBox @params);

    /// <summary>
    /// Decrypts and verifies cipher text using <c>nonce</c> and secret <c>key</c>.
    /// </summary>
    Task<ResultOfNaclBoxOpen> NaclSecretBoxOpen(ParamsOfNaclSecretBoxOpen @params);

    /// <summary>
    /// Prints the list of words from the specified dictionary.
    /// </summary>
    Task<ResultOfMnemonicWords> MnemonicWords(ParamsOfMnemonicWords @params);

    /// <remarks>
    /// Generates a random mnemonic from the specified dictionary and word count.
    /// </remarks>
    Task<ResultOfMnemonicFromRandom> MnemonicFromRandom(ParamsOfMnemonicFromRandom @params);

    /// <summary>
    /// Generates mnemonic from pre-generated entropy.
    /// </summary>
    Task<ResultOfMnemonicFromEntropy> MnemonicFromEntropy(ParamsOfMnemonicFromEntropy @params);

    /// <remarks>
    /// The phrase supplied will be checked for word length and validated according to the checksum specified in BIP0039.
    /// </remarks>
    Task<ResultOfMnemonicVerify> MnemonicVerify(ParamsOfMnemonicVerify @params);

    /// <remarks>
    /// Validates the seed phrase, generates master key and then derives the key pair from the master key and the specified path.
    /// </remarks>
    Task<KeyPair> MnemonicDeriveSignKeys(ParamsOfMnemonicDeriveSignKeys @params);

    /// <summary>
    /// Generates an extended master private key that will be the root for all the derived keys.
    /// </summary>
    Task<ResultOfHDKeyXPrvFromMnemonic> HdkeyXprvFromMnemonic(ParamsOfHDKeyXPrvFromMnemonic @params);

    /// <summary>
    /// Returns extended private key derived from the specified extended private key and child index.
    /// </summary>
    Task<ResultOfHDKeyDeriveFromXPrv> HdkeyDeriveFromXprv(ParamsOfHDKeyDeriveFromXPrv @params);

    /// <summary>
    /// Derives the extended private key from the specified key and path.
    /// </summary>
    Task<ResultOfHDKeyDeriveFromXPrvPath> HdkeyDeriveFromXprvPath(ParamsOfHDKeyDeriveFromXPrvPath @params);

    /// <summary>
    /// Extracts the private key from the serialized extended private key.
    /// </summary>
    Task<ResultOfHDKeySecretFromXPrv> HdkeySecretFromXprv(ParamsOfHDKeySecretFromXPrv @params);

    /// <summary>
    /// Extracts the public key from the serialized extended private key.
    /// </summary>
    Task<ResultOfHDKeyPublicFromXPrv> HdkeyPublicFromXprv(ParamsOfHDKeyPublicFromXPrv @params);

    /// <summary>
    /// Performs symmetric <c>chacha20</c> encryption.
    /// </summary>
    Task<ResultOfChaCha20> Chacha20(ParamsOfChaCha20 @params);

    /// <remarks>
    /// Crypto Box is a root crypto object, that encapsulates some secret (seed phrase usually) in encrypted form and acts as a factory for all crypto primitives used in SDK: keys for signing and encryption, derived from this secret.<para/>
    /// Crypto Box encrypts original Seed Phrase with salt and password that is retrieved from <c>password_provider</c> callback, implemented on Application side.<para/>
    /// When used, decrypted secret shows up in core library's memory for a very short period of time and then is immediately overwritten with zeroes.
    /// </remarks>
    Task<RegisteredCryptoBox> CreateCryptoBox(ParamsOfCreateCryptoBox @params);

    /// <summary>
    /// Removes Crypto Box.<para/>
    /// Clears all secret data.
    /// </summary>
    Task RemoveCryptoBox(RegisteredCryptoBox @params);

    /// <summary>
    /// Get Crypto Box Info.<para/>
    /// Used to get <c>encrypted_secret</c> that should be used for all the cryptobox initializations except the first one.
    /// </summary>
    Task<ResultOfGetCryptoBoxInfo> GetCryptoBoxInfo(RegisteredCryptoBox @params);

    /// <remarks>
    /// Attention! Store this data in your application for a very short period of time and overwrite it with zeroes ASAP.
    /// </remarks>
    Task<ResultOfGetCryptoBoxSeedPhrase> GetCryptoBoxSeedPhrase(RegisteredCryptoBox @params);

    /// <summary>
    /// Get handle of Signing Box derived from Crypto Box.
    /// </summary>
    Task<RegisteredSigningBox> GetSigningBoxFromCryptoBox(ParamsOfGetSigningBoxFromCryptoBox @params);

    /// <remarks>
    /// Derives encryption keypair from cryptobox secret and hdpath and stores it in cache for <c>secret_lifetime</c> or until explicitly cleared by <c>clear_crypto_box_secret_cache</c> method.<para/>
    /// If <c>secret_lifetime</c> is not specified - overwrites encryption secret with zeroes immediately after encryption operation.
    /// </remarks>
    Task<RegisteredEncryptionBox> GetEncryptionBoxFromCryptoBox(ParamsOfGetEncryptionBoxFromCryptoBox @params);

    /// <summary>
    /// Removes cached secrets (overwrites with zeroes) from all signing and encryption boxes, derived from crypto box.
    /// </summary>
    Task ClearCryptoBoxSecretCache(RegisteredCryptoBox @params);

    /// <summary>
    /// Register an application implemented signing box.
    /// </summary>
    Task<RegisteredSigningBox> RegisterSigningBox();

    /// <summary>
    /// Creates a default signing box implementation.
    /// </summary>
    Task<RegisteredSigningBox> GetSigningBox(KeyPair @params);

    /// <summary>
    /// Returns public key of signing key pair.
    /// </summary>
    Task<ResultOfSigningBoxGetPublicKey> SigningBoxGetPublicKey(RegisteredSigningBox @params);

    /// <summary>
    /// Returns signed user data.
    /// </summary>
    Task<ResultOfSigningBoxSign> SigningBoxSign(ParamsOfSigningBoxSign @params);

    /// <summary>
    /// Removes signing box from SDK.
    /// </summary>
    Task RemoveSigningBox(RegisteredSigningBox @params);

    /// <summary>
    /// Register an application implemented encryption box.
    /// </summary>
    Task<RegisteredEncryptionBox> RegisterEncryptionBox();

    /// <summary>
    /// Removes encryption box from SDK.
    /// </summary>
    Task RemoveEncryptionBox(RegisteredEncryptionBox @params);

    /// <summary>
    /// Queries info from the given encryption box.
    /// </summary>
    Task<ResultOfEncryptionBoxGetInfo> EncryptionBoxGetInfo(ParamsOfEncryptionBoxGetInfo @params);

    /// <remarks>
    /// Block cipher algorithms pad data to cipher block size so encrypted data can be longer then original data.<para/>
    /// Client should store the original data size after encryption and use it after decryption to retrieve the original data from decrypted data.
    /// </remarks>
    Task<ResultOfEncryptionBoxEncrypt> EncryptionBoxEncrypt(ParamsOfEncryptionBoxEncrypt @params);

    /// <remarks>
    /// Block cipher algorithms pad data to cipher block size so encrypted data can be longer then original data.<para/>
    /// Client should store the original data size after encryption and use it after decryption to retrieve the original data from decrypted data.
    /// </remarks>
    Task<ResultOfEncryptionBoxDecrypt> EncryptionBoxDecrypt(ParamsOfEncryptionBoxDecrypt @params);

    /// <summary>
    /// Creates encryption box with specified algorithm.
    /// </summary>
    Task<RegisteredEncryptionBox> CreateEncryptionBox(ParamsOfCreateEncryptionBox @params);
}