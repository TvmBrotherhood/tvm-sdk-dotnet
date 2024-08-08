namespace TvmSdk.Everscale.Modules.Abi;

/// <summary>
/// Provides message encoding and decoding according to the ABI specification.
/// </summary>
public interface IAbiModule
{
    /// <summary>
    /// Encodes message body according to ABI function call.
    /// </summary>
    Task<ResultOfEncodeMessageBody> EncodeMessageBody(ParamsOfEncodeMessageBody @params);

    Task<ResultOfAttachSignatureToMessageBody> AttachSignatureToMessageBody(ParamsOfAttachSignatureToMessageBody @params);

    /// <remarks>
    /// Allows to encode deploy and function call messages, both signed and unsigned.<para/>
    /// Use cases include messages of any possible type: - deploy with initial function call (i.e.<para/>
    /// <c>constructor</c> or any other function that is used for some kind of initialization); - deploy without initial function call; - signed/unsigned + data for signing.<para/>
    /// <c>Signer</c> defines how the message should or shouldn't be signed:  <c>Signer::None</c> creates an unsigned message.<para/>
    /// This may be needed in case of some public methods, that do not require authorization by pubkey.<para/>
    /// <c>Signer::External</c> takes public key and returns <c>data_to_sign</c> for later signing.<para/>
    /// Use <c>attach_signature</c> method with the result signature to get the signed message.<para/>
    /// <c>Signer::Keys</c> creates a signed message with provided key pair.<para/>
    /// [SOON] <c>Signer::SigningBox</c> Allows using a special interface to implement signing without private key disclosure to SDK.<para/>
    /// For instance, in case of using a cold wallet or HSM, when application calls some API to sign data.<para/>
    /// There is an optional public key can be provided in deploy set in order to substitute one in TVM file.<para/>
    /// Public key resolving priority: 1.<para/>
    /// Public key from deploy set.<para/>
    /// 2.<para/>
    /// Public key, specified in TVM file.<para/>
    /// 3.<para/>
    /// Public key, provided by signer.
    /// </remarks>
    Task<ResultOfEncodeMessage> EncodeMessage(ParamsOfEncodeMessage @params);

    /// <remarks>
    /// Allows to encode deploy and function call messages.<para/>
    /// Use cases include messages of any possible type: - deploy with initial function call (i.e.<para/>
    /// <c>constructor</c> or any other function that is used for some kind of initialization); - deploy without initial function call; - simple function call  There is an optional public key can be provided in deploy set in order to substitute one in TVM file.<para/>
    /// Public key resolving priority: 1.<para/>
    /// Public key from deploy set.<para/>
    /// 2.<para/>
    /// Public key, specified in TVM file.
    /// </remarks>
    Task<ResultOfEncodeInternalMessage> EncodeInternalMessage(ParamsOfEncodeInternalMessage @params);

    /// <summary>
    /// Combines <c>hex</c>-encoded <c>signature</c> with <c>base64</c>-encoded <c>unsigned_message</c>.<para/>
    /// Returns signed message encoded in <c>base64</c>.
    /// </summary>
    Task<ResultOfAttachSignature> AttachSignature(ParamsOfAttachSignature @params);

    /// <summary>
    /// Decodes message body using provided message BOC and ABI.
    /// </summary>
    Task<DecodedMessageBody> DecodeMessage(ParamsOfDecodeMessage @params);

    /// <summary>
    /// Decodes message body using provided body BOC and ABI.
    /// </summary>
    Task<DecodedMessageBody> DecodeMessageBody(ParamsOfDecodeMessageBody @params);

    /// <summary>
    /// Creates account state BOC.
    /// </summary>
    Task<ResultOfEncodeAccount> EncodeAccount(ParamsOfEncodeAccount @params);

    /// <remarks>
    /// Note: this feature requires ABI 2.1 or higher.
    /// </remarks>
    Task<ResultOfDecodeAccountData> DecodeAccountData(ParamsOfDecodeAccountData @params);

    /// <remarks>
    /// Doesn't support ABI version &amp;gt;= 2.4.<para/>
    /// Use <c>encode_initial_data</c> instead.
    /// </remarks>
    Task<ResultOfUpdateInitialData> UpdateInitialData(ParamsOfUpdateInitialData @params);

    /// <remarks>
    /// This function is analogue of <c>tvm.buildDataInit</c> function in Solidity.
    /// </remarks>
    Task<ResultOfEncodeInitialData> EncodeInitialData(ParamsOfEncodeInitialData @params);

    /// <remarks>
    /// Doesn't support ABI version &amp;gt;= 2.4.<para/>
    /// Use <c>decode_account_data</c> instead.
    /// </remarks>
    Task<ResultOfDecodeInitialData> DecodeInitialData(ParamsOfDecodeInitialData @params);

    /// <remarks>
    /// Solidity functions use ABI types for <a href="https://github.com/tonlabs/TON-Solidity-Compiler/blob/master/API.md#tvmbuilderstore">builder encoding</a>.<para/>
    /// The simplest way to decode such a BOC is to use ABI decoding.<para/>
    /// ABI has it own rules for fields layout in cells so manually encoded BOC can not be described in terms of ABI rules.<para/>
    /// To solve this problem we introduce a new ABI type <c>Ref(&lt;ParamType&gt;)</c> which allows to store <c>ParamType</c> ABI parameter in cell reference and, thus, decode manually encoded BOCs.<para/>
    /// This type is available only in <c>decode_boc</c> function and will not be available in ABI messages encoding until it is included into some ABI revision.<para/>
    /// Such BOC descriptions covers most users needs.<para/>
    /// If someone wants to decode some BOC which can not be described by these rules (i.e.<para/>
    /// BOC with TLB containing constructors of flags defining some parsing conditions) then they can decode the fields up to fork condition, check the parsed data manually, expand the parsing schema and then decode the whole BOC with the full schema.
    /// </remarks>
    Task<ResultOfDecodeBoc> DecodeBoc(ParamsOfDecodeBoc @params);

    /// <summary>
    /// Encodes given parameters in JSON into a BOC using param types from ABI.
    /// </summary>
    Task<ResultOfAbiEncodeBoc> EncodeBoc(ParamsOfAbiEncodeBoc @params);

    /// <summary>
    /// Calculates contract function ID by contract ABI.
    /// </summary>
    Task<ResultOfCalcFunctionId> CalcFunctionId(ParamsOfCalcFunctionId @params);

    /// <summary>
    /// Extracts signature from message body and calculates hash to verify the signature.
    /// </summary>
    Task<ResultOfGetSignatureData> GetSignatureData(ParamsOfGetSignatureData @params);
}