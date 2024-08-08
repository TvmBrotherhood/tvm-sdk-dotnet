using TvmSdk.DllAdapter;

namespace TvmSdk.AckiNacki.Modules.Crypto;

/// <summary>
/// Crypto functions.
/// </summary>
public class CryptoModule(ITvmSdkDllAdapter adapter) : ICryptoModule
{
    /// <remarks>
    /// Performs prime factorization – decomposition of a composite number into a product of smaller prime integers (factors).<para/>
    /// See [https://en.wikipedia.org/wiki/Integer_factorization].
    /// </remarks>
    public Task<ResultOfFactorize> Factorize(ParamsOfFactorize @params)
    {
        return adapter.CallMethod<ParamsOfFactorize, ResultOfFactorize>("crypto.factorize", @params);
    }

    /// <remarks>
    /// Performs modular exponentiation for big integers (<c>base</c><c>exponent</c> mod <c>modulus</c>).<para/>
    /// See [https://en.wikipedia.org/wiki/Modular_exponentiation].
    /// </remarks>
    public Task<ResultOfModularPower> ModularPower(ParamsOfModularPower @params)
    {
        return adapter.CallMethod<ParamsOfModularPower, ResultOfModularPower>("crypto.modular_power", @params);
    }

    /// <summary>
    /// Calculates CRC16 using TON algorithm.
    /// </summary>
    public Task<ResultOfTonCrc16> TonCrc16(ParamsOfTonCrc16 @params)
    {
        return adapter.CallMethod<ParamsOfTonCrc16, ResultOfTonCrc16>("crypto.ton_crc16", @params);
    }

    /// <summary>
    /// Generates random byte array of the specified length and returns it in <c>base64</c> format.
    /// </summary>
    public Task<ResultOfGenerateRandomBytes> GenerateRandomBytes(ParamsOfGenerateRandomBytes @params)
    {
        return adapter.CallMethod<ParamsOfGenerateRandomBytes, ResultOfGenerateRandomBytes>("crypto.generate_random_bytes", @params);
    }

    /// <summary>
    /// Converts public key to ton safe_format.
    /// </summary>
    public Task<ResultOfConvertPublicKeyToTonSafeFormat> ConvertPublicKeyToTonSafeFormat(ParamsOfConvertPublicKeyToTonSafeFormat @params)
    {
        return adapter.CallMethod<ParamsOfConvertPublicKeyToTonSafeFormat, ResultOfConvertPublicKeyToTonSafeFormat>("crypto.convert_public_key_to_ton_safe_format", @params);
    }

    /// <summary>
    /// Generates random ed25519 key pair.
    /// </summary>
    public Task<KeyPair> GenerateRandomSignKeys()
    {
        return adapter.CallMethod<KeyPair>("crypto.generate_random_sign_keys");
    }

    /// <summary>
    /// Signs a data using the provided keys.
    /// </summary>
    public Task<ResultOfSign> Sign(ParamsOfSign @params)
    {
        return adapter.CallMethod<ParamsOfSign, ResultOfSign>("crypto.sign", @params);
    }

    /// <summary>
    /// Verifies signed data using the provided public key.<para/>
    /// Raises error if verification is failed.
    /// </summary>
    public Task<ResultOfVerifySignature> VerifySignature(ParamsOfVerifySignature @params)
    {
        return adapter.CallMethod<ParamsOfVerifySignature, ResultOfVerifySignature>("crypto.verify_signature", @params);
    }

    /// <summary>
    /// Calculates SHA256 hash of the specified data.
    /// </summary>
    public Task<ResultOfHash> Sha256(ParamsOfHash @params)
    {
        return adapter.CallMethod<ParamsOfHash, ResultOfHash>("crypto.sha256", @params);
    }

    /// <summary>
    /// Calculates SHA512 hash of the specified data.
    /// </summary>
    public Task<ResultOfHash> Sha512(ParamsOfHash @params)
    {
        return adapter.CallMethod<ParamsOfHash, ResultOfHash>("crypto.sha512", @params);
    }

    /// <remarks>
    /// Derives key from <c>password</c> and <c>key</c> using <c>scrypt</c> algorithm.<para/>
    /// See [https://en.wikipedia.org/wiki/Scrypt].<para/>
    /// # Arguments - <c>log_n</c> - The log2 of the Scrypt parameter <c>N</c> - <c>r</c> - The Scrypt parameter <c>r</c> - <c>p</c> - The Scrypt parameter <c>p</c> # Conditions - <c>log_n</c> must be less than <c>64</c> - <c>r</c> must be greater than <c>0</c> and less than or equal to <c>4294967295</c> - <c>p</c> must be greater than <c>0</c> and less than <c>4294967295</c> # Recommended values sufficient for most use-cases - <c>log_n = 15</c> (<c>n = 32768</c>) - <c>r = 8</c> - <c>p = 1</c>.
    /// </remarks>
    public Task<ResultOfScrypt> Scrypt(ParamsOfScrypt @params)
    {
        return adapter.CallMethod<ParamsOfScrypt, ResultOfScrypt>("crypto.scrypt", @params);
    }

    /// <remarks>
    /// **NOTE:** In the result the secret key is actually the concatenation of secret and public keys (128 symbols hex string) by design of <a href="http://nacl.cr.yp.to/sign.html">NaCL</a>.<para/>
    /// See also <a href="https://crypto.stackexchange.com/questions/54353/">the stackexchange question</a>.
    /// </remarks>
    public Task<KeyPair> NaclSignKeypairFromSecretKey(ParamsOfNaclSignKeyPairFromSecret @params)
    {
        return adapter.CallMethod<ParamsOfNaclSignKeyPairFromSecret, KeyPair>("crypto.nacl_sign_keypair_from_secret_key", @params);
    }

    /// <summary>
    /// Signs data using the signer's secret key.
    /// </summary>
    public Task<ResultOfNaclSign> NaclSign(ParamsOfNaclSign @params)
    {
        return adapter.CallMethod<ParamsOfNaclSign, ResultOfNaclSign>("crypto.nacl_sign", @params);
    }

    /// <remarks>
    /// Verifies the signature in <c>signed</c> using the signer's public key <c>public</c> and returns the message <c>unsigned</c>.<para/>
    /// If the signature fails verification, crypto_sign_open raises an exception.
    /// </remarks>
    public Task<ResultOfNaclSignOpen> NaclSignOpen(ParamsOfNaclSignOpen @params)
    {
        return adapter.CallMethod<ParamsOfNaclSignOpen, ResultOfNaclSignOpen>("crypto.nacl_sign_open", @params);
    }

    /// <remarks>
    /// Signs the message <c>unsigned</c> using the secret key <c>secret</c> and returns a signature <c>signature</c>.
    /// </remarks>
    public Task<ResultOfNaclSignDetached> NaclSignDetached(ParamsOfNaclSign @params)
    {
        return adapter.CallMethod<ParamsOfNaclSign, ResultOfNaclSignDetached>("crypto.nacl_sign_detached", @params);
    }

    /// <summary>
    /// Verifies the signature with public key and <c>unsigned</c> data.
    /// </summary>
    public Task<ResultOfNaclSignDetachedVerify> NaclSignDetachedVerify(ParamsOfNaclSignDetachedVerify @params)
    {
        return adapter.CallMethod<ParamsOfNaclSignDetachedVerify, ResultOfNaclSignDetachedVerify>("crypto.nacl_sign_detached_verify", @params);
    }

    /// <summary>
    /// Generates a random NaCl key pair.
    /// </summary>
    public Task<KeyPair> NaclBoxKeypair()
    {
        return adapter.CallMethod<KeyPair>("crypto.nacl_box_keypair");
    }

    /// <summary>
    /// Generates key pair from a secret key.
    /// </summary>
    public Task<KeyPair> NaclBoxKeypairFromSecretKey(ParamsOfNaclBoxKeyPairFromSecret @params)
    {
        return adapter.CallMethod<ParamsOfNaclBoxKeyPairFromSecret, KeyPair>("crypto.nacl_box_keypair_from_secret_key", @params);
    }

    /// <remarks>
    /// Encrypt and authenticate a message using the senders secret key, the receivers public key, and a nonce.
    /// </remarks>
    public Task<ResultOfNaclBox> NaclBox(ParamsOfNaclBox @params)
    {
        return adapter.CallMethod<ParamsOfNaclBox, ResultOfNaclBox>("crypto.nacl_box", @params);
    }

    /// <summary>
    /// Decrypt and verify the cipher text using the receivers secret key, the senders public key, and the nonce.
    /// </summary>
    public Task<ResultOfNaclBoxOpen> NaclBoxOpen(ParamsOfNaclBoxOpen @params)
    {
        return adapter.CallMethod<ParamsOfNaclBoxOpen, ResultOfNaclBoxOpen>("crypto.nacl_box_open", @params);
    }

    /// <summary>
    /// Encrypt and authenticate message using nonce and secret key.
    /// </summary>
    public Task<ResultOfNaclBox> NaclSecretBox(ParamsOfNaclSecretBox @params)
    {
        return adapter.CallMethod<ParamsOfNaclSecretBox, ResultOfNaclBox>("crypto.nacl_secret_box", @params);
    }

    /// <summary>
    /// Decrypts and verifies cipher text using <c>nonce</c> and secret <c>key</c>.
    /// </summary>
    public Task<ResultOfNaclBoxOpen> NaclSecretBoxOpen(ParamsOfNaclSecretBoxOpen @params)
    {
        return adapter.CallMethod<ParamsOfNaclSecretBoxOpen, ResultOfNaclBoxOpen>("crypto.nacl_secret_box_open", @params);
    }

    /// <summary>
    /// Prints the list of words from the specified dictionary.
    /// </summary>
    public Task<ResultOfMnemonicWords> MnemonicWords(ParamsOfMnemonicWords @params)
    {
        return adapter.CallMethod<ParamsOfMnemonicWords, ResultOfMnemonicWords>("crypto.mnemonic_words", @params);
    }

    /// <remarks>
    /// Generates a random mnemonic from the specified dictionary and word count.
    /// </remarks>
    public Task<ResultOfMnemonicFromRandom> MnemonicFromRandom(ParamsOfMnemonicFromRandom @params)
    {
        return adapter.CallMethod<ParamsOfMnemonicFromRandom, ResultOfMnemonicFromRandom>("crypto.mnemonic_from_random", @params);
    }

    /// <summary>
    /// Generates mnemonic from pre-generated entropy.
    /// </summary>
    public Task<ResultOfMnemonicFromEntropy> MnemonicFromEntropy(ParamsOfMnemonicFromEntropy @params)
    {
        return adapter.CallMethod<ParamsOfMnemonicFromEntropy, ResultOfMnemonicFromEntropy>("crypto.mnemonic_from_entropy", @params);
    }

    /// <remarks>
    /// The phrase supplied will be checked for word length and validated according to the checksum specified in BIP0039.
    /// </remarks>
    public Task<ResultOfMnemonicVerify> MnemonicVerify(ParamsOfMnemonicVerify @params)
    {
        return adapter.CallMethod<ParamsOfMnemonicVerify, ResultOfMnemonicVerify>("crypto.mnemonic_verify", @params);
    }

    /// <remarks>
    /// Validates the seed phrase, generates master key and then derives the key pair from the master key and the specified path.
    /// </remarks>
    public Task<KeyPair> MnemonicDeriveSignKeys(ParamsOfMnemonicDeriveSignKeys @params)
    {
        return adapter.CallMethod<ParamsOfMnemonicDeriveSignKeys, KeyPair>("crypto.mnemonic_derive_sign_keys", @params);
    }

    /// <summary>
    /// Generates an extended master private key that will be the root for all the derived keys.
    /// </summary>
    public Task<ResultOfHDKeyXPrvFromMnemonic> HdkeyXprvFromMnemonic(ParamsOfHDKeyXPrvFromMnemonic @params)
    {
        return adapter.CallMethod<ParamsOfHDKeyXPrvFromMnemonic, ResultOfHDKeyXPrvFromMnemonic>("crypto.hdkey_xprv_from_mnemonic", @params);
    }

    /// <summary>
    /// Returns extended private key derived from the specified extended private key and child index.
    /// </summary>
    public Task<ResultOfHDKeyDeriveFromXPrv> HdkeyDeriveFromXprv(ParamsOfHDKeyDeriveFromXPrv @params)
    {
        return adapter.CallMethod<ParamsOfHDKeyDeriveFromXPrv, ResultOfHDKeyDeriveFromXPrv>("crypto.hdkey_derive_from_xprv", @params);
    }

    /// <summary>
    /// Derives the extended private key from the specified key and path.
    /// </summary>
    public Task<ResultOfHDKeyDeriveFromXPrvPath> HdkeyDeriveFromXprvPath(ParamsOfHDKeyDeriveFromXPrvPath @params)
    {
        return adapter.CallMethod<ParamsOfHDKeyDeriveFromXPrvPath, ResultOfHDKeyDeriveFromXPrvPath>("crypto.hdkey_derive_from_xprv_path", @params);
    }

    /// <summary>
    /// Extracts the private key from the serialized extended private key.
    /// </summary>
    public Task<ResultOfHDKeySecretFromXPrv> HdkeySecretFromXprv(ParamsOfHDKeySecretFromXPrv @params)
    {
        return adapter.CallMethod<ParamsOfHDKeySecretFromXPrv, ResultOfHDKeySecretFromXPrv>("crypto.hdkey_secret_from_xprv", @params);
    }

    /// <summary>
    /// Extracts the public key from the serialized extended private key.
    /// </summary>
    public Task<ResultOfHDKeyPublicFromXPrv> HdkeyPublicFromXprv(ParamsOfHDKeyPublicFromXPrv @params)
    {
        return adapter.CallMethod<ParamsOfHDKeyPublicFromXPrv, ResultOfHDKeyPublicFromXPrv>("crypto.hdkey_public_from_xprv", @params);
    }

    /// <summary>
    /// Performs symmetric <c>chacha20</c> encryption.
    /// </summary>
    public Task<ResultOfChaCha20> Chacha20(ParamsOfChaCha20 @params)
    {
        return adapter.CallMethod<ParamsOfChaCha20, ResultOfChaCha20>("crypto.chacha20", @params);
    }

    /// <remarks>
    /// Crypto Box is a root crypto object, that encapsulates some secret (seed phrase usually) in encrypted form and acts as a factory for all crypto primitives used in SDK: keys for signing and encryption, derived from this secret.<para/>
    /// Crypto Box encrypts original Seed Phrase with salt and password that is retrieved from <c>password_provider</c> callback, implemented on Application side.<para/>
    /// When used, decrypted secret shows up in core library's memory for a very short period of time and then is immediately overwritten with zeroes.
    /// </remarks>
    public Task<RegisteredCryptoBox> CreateCryptoBox(ParamsOfCreateCryptoBox @params)
    {
        return adapter.CallMethod<ParamsOfCreateCryptoBox, RegisteredCryptoBox>("crypto.create_crypto_box", @params);
    }

    /// <summary>
    /// Removes Crypto Box.<para/>
    /// Clears all secret data.
    /// </summary>
    public Task RemoveCryptoBox(RegisteredCryptoBox @params)
    {
        return adapter.CallMethod("crypto.remove_crypto_box", @params);
    }

    /// <summary>
    /// Get Crypto Box Info.<para/>
    /// Used to get <c>encrypted_secret</c> that should be used for all the cryptobox initializations except the first one.
    /// </summary>
    public Task<ResultOfGetCryptoBoxInfo> GetCryptoBoxInfo(RegisteredCryptoBox @params)
    {
        return adapter.CallMethod<RegisteredCryptoBox, ResultOfGetCryptoBoxInfo>("crypto.get_crypto_box_info", @params);
    }

    /// <remarks>
    /// Attention! Store this data in your application for a very short period of time and overwrite it with zeroes ASAP.
    /// </remarks>
    public Task<ResultOfGetCryptoBoxSeedPhrase> GetCryptoBoxSeedPhrase(RegisteredCryptoBox @params)
    {
        return adapter.CallMethod<RegisteredCryptoBox, ResultOfGetCryptoBoxSeedPhrase>("crypto.get_crypto_box_seed_phrase", @params);
    }

    /// <summary>
    /// Get handle of Signing Box derived from Crypto Box.
    /// </summary>
    public Task<RegisteredSigningBox> GetSigningBoxFromCryptoBox(ParamsOfGetSigningBoxFromCryptoBox @params)
    {
        return adapter.CallMethod<ParamsOfGetSigningBoxFromCryptoBox, RegisteredSigningBox>("crypto.get_signing_box_from_crypto_box", @params);
    }

    /// <remarks>
    /// Derives encryption keypair from cryptobox secret and hdpath and stores it in cache for <c>secret_lifetime</c> or until explicitly cleared by <c>clear_crypto_box_secret_cache</c> method.<para/>
    /// If <c>secret_lifetime</c> is not specified - overwrites encryption secret with zeroes immediately after encryption operation.
    /// </remarks>
    public Task<RegisteredEncryptionBox> GetEncryptionBoxFromCryptoBox(ParamsOfGetEncryptionBoxFromCryptoBox @params)
    {
        return adapter.CallMethod<ParamsOfGetEncryptionBoxFromCryptoBox, RegisteredEncryptionBox>("crypto.get_encryption_box_from_crypto_box", @params);
    }

    /// <summary>
    /// Removes cached secrets (overwrites with zeroes) from all signing and encryption boxes, derived from crypto box.
    /// </summary>
    public Task ClearCryptoBoxSecretCache(RegisteredCryptoBox @params)
    {
        return adapter.CallMethod("crypto.clear_crypto_box_secret_cache", @params);
    }

    /// <summary>
    /// Register an application implemented signing box.
    /// </summary>
    public Task<RegisteredSigningBox> RegisterSigningBox()
    {
        return adapter.CallMethod<RegisteredSigningBox>("crypto.register_signing_box");
    }

    /// <summary>
    /// Creates a default signing box implementation.
    /// </summary>
    public Task<RegisteredSigningBox> GetSigningBox(KeyPair @params)
    {
        return adapter.CallMethod<KeyPair, RegisteredSigningBox>("crypto.get_signing_box", @params);
    }

    /// <summary>
    /// Returns public key of signing key pair.
    /// </summary>
    public Task<ResultOfSigningBoxGetPublicKey> SigningBoxGetPublicKey(RegisteredSigningBox @params)
    {
        return adapter.CallMethod<RegisteredSigningBox, ResultOfSigningBoxGetPublicKey>("crypto.signing_box_get_public_key", @params);
    }

    /// <summary>
    /// Returns signed user data.
    /// </summary>
    public Task<ResultOfSigningBoxSign> SigningBoxSign(ParamsOfSigningBoxSign @params)
    {
        return adapter.CallMethod<ParamsOfSigningBoxSign, ResultOfSigningBoxSign>("crypto.signing_box_sign", @params);
    }

    /// <summary>
    /// Removes signing box from SDK.
    /// </summary>
    public Task RemoveSigningBox(RegisteredSigningBox @params)
    {
        return adapter.CallMethod("crypto.remove_signing_box", @params);
    }

    /// <summary>
    /// Register an application implemented encryption box.
    /// </summary>
    public Task<RegisteredEncryptionBox> RegisterEncryptionBox()
    {
        return adapter.CallMethod<RegisteredEncryptionBox>("crypto.register_encryption_box");
    }

    /// <summary>
    /// Removes encryption box from SDK.
    /// </summary>
    public Task RemoveEncryptionBox(RegisteredEncryptionBox @params)
    {
        return adapter.CallMethod("crypto.remove_encryption_box", @params);
    }

    /// <summary>
    /// Queries info from the given encryption box.
    /// </summary>
    public Task<ResultOfEncryptionBoxGetInfo> EncryptionBoxGetInfo(ParamsOfEncryptionBoxGetInfo @params)
    {
        return adapter.CallMethod<ParamsOfEncryptionBoxGetInfo, ResultOfEncryptionBoxGetInfo>("crypto.encryption_box_get_info", @params);
    }

    /// <remarks>
    /// Block cipher algorithms pad data to cipher block size so encrypted data can be longer then original data.<para/>
    /// Client should store the original data size after encryption and use it after decryption to retrieve the original data from decrypted data.
    /// </remarks>
    public Task<ResultOfEncryptionBoxEncrypt> EncryptionBoxEncrypt(ParamsOfEncryptionBoxEncrypt @params)
    {
        return adapter.CallMethod<ParamsOfEncryptionBoxEncrypt, ResultOfEncryptionBoxEncrypt>("crypto.encryption_box_encrypt", @params);
    }

    /// <remarks>
    /// Block cipher algorithms pad data to cipher block size so encrypted data can be longer then original data.<para/>
    /// Client should store the original data size after encryption and use it after decryption to retrieve the original data from decrypted data.
    /// </remarks>
    public Task<ResultOfEncryptionBoxDecrypt> EncryptionBoxDecrypt(ParamsOfEncryptionBoxDecrypt @params)
    {
        return adapter.CallMethod<ParamsOfEncryptionBoxDecrypt, ResultOfEncryptionBoxDecrypt>("crypto.encryption_box_decrypt", @params);
    }

    /// <summary>
    /// Creates encryption box with specified algorithm.
    /// </summary>
    public Task<RegisteredEncryptionBox> CreateEncryptionBox(ParamsOfCreateEncryptionBox @params)
    {
        return adapter.CallMethod<ParamsOfCreateEncryptionBox, RegisteredEncryptionBox>("crypto.create_encryption_box", @params);
    }
}