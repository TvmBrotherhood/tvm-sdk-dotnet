using TvmSdk.DllAdapter;

namespace TvmSdk.Ton.Modules.Abi;

/// <summary>
/// Provides message encoding and decoding according to the ABI specification.
/// </summary>
public class AbiModule(ITvmSdkDllAdapter adapter) : IAbiModule
{
    /// <summary>
    /// Encodes message body according to ABI function call.
    /// </summary>
    public Task<ResultOfEncodeMessageBody> EncodeMessageBody(ParamsOfEncodeMessageBody @params)
    {
        return adapter.CallMethod<ParamsOfEncodeMessageBody, ResultOfEncodeMessageBody>("abi.encode_message_body", @params);
    }

    public Task<ResultOfAttachSignatureToMessageBody> AttachSignatureToMessageBody(ParamsOfAttachSignatureToMessageBody @params)
    {
        return adapter.CallMethod<ParamsOfAttachSignatureToMessageBody, ResultOfAttachSignatureToMessageBody>("abi.attach_signature_to_message_body", @params);
    }

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
    public Task<ResultOfEncodeMessage> EncodeMessage(ParamsOfEncodeMessage @params)
    {
        return adapter.CallMethod<ParamsOfEncodeMessage, ResultOfEncodeMessage>("abi.encode_message", @params);
    }

    /// <remarks>
    /// Allows to encode deploy and function call messages.<para/>
    /// Use cases include messages of any possible type: - deploy with initial function call (i.e.<para/>
    /// <c>constructor</c> or any other function that is used for some kind of initialization); - deploy without initial function call; - simple function call  There is an optional public key can be provided in deploy set in order to substitute one in TVM file.<para/>
    /// Public key resolving priority: 1.<para/>
    /// Public key from deploy set.<para/>
    /// 2.<para/>
    /// Public key, specified in TVM file.
    /// </remarks>
    public Task<ResultOfEncodeInternalMessage> EncodeInternalMessage(ParamsOfEncodeInternalMessage @params)
    {
        return adapter.CallMethod<ParamsOfEncodeInternalMessage, ResultOfEncodeInternalMessage>("abi.encode_internal_message", @params);
    }

    /// <summary>
    /// Combines <c>hex</c>-encoded <c>signature</c> with <c>base64</c>-encoded <c>unsigned_message</c>.<para/>
    /// Returns signed message encoded in <c>base64</c>.
    /// </summary>
    public Task<ResultOfAttachSignature> AttachSignature(ParamsOfAttachSignature @params)
    {
        return adapter.CallMethod<ParamsOfAttachSignature, ResultOfAttachSignature>("abi.attach_signature", @params);
    }

    /// <summary>
    /// Decodes message body using provided message BOC and ABI.
    /// </summary>
    public Task<DecodedMessageBody> DecodeMessage(ParamsOfDecodeMessage @params)
    {
        return adapter.CallMethod<ParamsOfDecodeMessage, DecodedMessageBody>("abi.decode_message", @params);
    }

    /// <summary>
    /// Decodes message body using provided body BOC and ABI.
    /// </summary>
    public Task<DecodedMessageBody> DecodeMessageBody(ParamsOfDecodeMessageBody @params)
    {
        return adapter.CallMethod<ParamsOfDecodeMessageBody, DecodedMessageBody>("abi.decode_message_body", @params);
    }

    /// <summary>
    /// Creates account state BOC.
    /// </summary>
    public Task<ResultOfEncodeAccount> EncodeAccount(ParamsOfEncodeAccount @params)
    {
        return adapter.CallMethod<ParamsOfEncodeAccount, ResultOfEncodeAccount>("abi.encode_account", @params);
    }

    /// <remarks>
    /// Note: this feature requires ABI 2.1 or higher.
    /// </remarks>
    public Task<ResultOfDecodeAccountData> DecodeAccountData(ParamsOfDecodeAccountData @params)
    {
        return adapter.CallMethod<ParamsOfDecodeAccountData, ResultOfDecodeAccountData>("abi.decode_account_data", @params);
    }

    /// <remarks>
    /// Doesn't support ABI version &amp;gt;= 2.4.<para/>
    /// Use <c>encode_initial_data</c> instead.
    /// </remarks>
    public Task<ResultOfUpdateInitialData> UpdateInitialData(ParamsOfUpdateInitialData @params)
    {
        return adapter.CallMethod<ParamsOfUpdateInitialData, ResultOfUpdateInitialData>("abi.update_initial_data", @params);
    }

    /// <remarks>
    /// This function is analogue of <c>tvm.buildDataInit</c> function in Solidity.
    /// </remarks>
    public Task<ResultOfEncodeInitialData> EncodeInitialData(ParamsOfEncodeInitialData @params)
    {
        return adapter.CallMethod<ParamsOfEncodeInitialData, ResultOfEncodeInitialData>("abi.encode_initial_data", @params);
    }

    /// <remarks>
    /// Doesn't support ABI version &amp;gt;= 2.4.<para/>
    /// Use <c>decode_account_data</c> instead.
    /// </remarks>
    public Task<ResultOfDecodeInitialData> DecodeInitialData(ParamsOfDecodeInitialData @params)
    {
        return adapter.CallMethod<ParamsOfDecodeInitialData, ResultOfDecodeInitialData>("abi.decode_initial_data", @params);
    }

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
    public Task<ResultOfDecodeBoc> DecodeBoc(ParamsOfDecodeBoc @params)
    {
        return adapter.CallMethod<ParamsOfDecodeBoc, ResultOfDecodeBoc>("abi.decode_boc", @params);
    }

    /// <summary>
    /// Encodes given parameters in JSON into a BOC using param types from ABI.
    /// </summary>
    public Task<ResultOfAbiEncodeBoc> EncodeBoc(ParamsOfAbiEncodeBoc @params)
    {
        return adapter.CallMethod<ParamsOfAbiEncodeBoc, ResultOfAbiEncodeBoc>("abi.encode_boc", @params);
    }

    /// <summary>
    /// Calculates contract function ID by contract ABI.
    /// </summary>
    public Task<ResultOfCalcFunctionId> CalcFunctionId(ParamsOfCalcFunctionId @params)
    {
        return adapter.CallMethod<ParamsOfCalcFunctionId, ResultOfCalcFunctionId>("abi.calc_function_id", @params);
    }

    /// <summary>
    /// Extracts signature from message body and calculates hash to verify the signature.
    /// </summary>
    public Task<ResultOfGetSignatureData> GetSignatureData(ParamsOfGetSignatureData @params)
    {
        return adapter.CallMethod<ParamsOfGetSignatureData, ResultOfGetSignatureData>("abi.get_signature_data", @params);
    }
}