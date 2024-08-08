namespace TvmSdk.Everscale.Modules.Boc;

/// <summary>
/// BOC manipulation module.
/// </summary>
public interface IBocModule
{
    /// <summary>
    /// Decodes tvc according to the tvc spec.<para/>
    /// Read more about tvc structure here https://github.com/tonlabs/ever-struct/blob/main/src/scheme/mod.rs#L30.
    /// </summary>
    Task<ResultOfDecodeTvc> DecodeTvc(ParamsOfDecodeTvc @params);

    /// <remarks>
    /// JSON structure is compatible with GraphQL API message object.
    /// </remarks>
    Task<ResultOfParse> ParseMessage(ParamsOfParse @params);

    /// <remarks>
    /// JSON structure is compatible with GraphQL API transaction object.
    /// </remarks>
    Task<ResultOfParse> ParseTransaction(ParamsOfParse @params);

    /// <remarks>
    /// JSON structure is compatible with GraphQL API account object.
    /// </remarks>
    Task<ResultOfParse> ParseAccount(ParamsOfParse @params);

    /// <remarks>
    /// JSON structure is compatible with GraphQL API block object.
    /// </remarks>
    Task<ResultOfParse> ParseBlock(ParamsOfParse @params);

    /// <remarks>
    /// JSON structure is compatible with GraphQL API shardstate object.
    /// </remarks>
    Task<ResultOfParse> ParseShardstate(ParamsOfParseShardstate @params);

    /// <summary>
    /// Extract blockchain configuration from key block and also from zerostate.
    /// </summary>
    Task<ResultOfGetBlockchainConfig> GetBlockchainConfig(ParamsOfGetBlockchainConfig @params);

    /// <summary>
    /// Calculates BOC root hash.
    /// </summary>
    Task<ResultOfGetBocHash> GetBocHash(ParamsOfGetBocHash @params);

    /// <summary>
    /// Calculates BOC depth.
    /// </summary>
    Task<ResultOfGetBocDepth> GetBocDepth(ParamsOfGetBocDepth @params);

    /// <summary>
    /// Extracts code from TVC contract image.
    /// </summary>
    Task<ResultOfGetCodeFromTvc> GetCodeFromTvc(ParamsOfGetCodeFromTvc @params);

    /// <summary>
    /// Get BOC from cache.
    /// </summary>
    Task<ResultOfBocCacheGet> CacheGet(ParamsOfBocCacheGet @params);

    /// <summary>
    /// Save BOC into cache or increase pin counter for existing pinned BOC.
    /// </summary>
    Task<ResultOfBocCacheSet> CacheSet(ParamsOfBocCacheSet @params);

    /// <summary>
    /// Unpin BOCs with specified pin defined in the <c>cache_set</c>.<para/>
    /// Decrease pin reference counter for BOCs with specified pin defined in the <c>cache_set</c>.<para/>
    /// BOCs which have only 1 pin and its reference counter become 0 will be removed from cache.
    /// </summary>
    Task CacheUnpin(ParamsOfBocCacheUnpin @params);

    /// <summary>
    /// Encodes bag of cells (BOC) with builder operations.<para/>
    /// This method provides the same functionality as Solidity TvmBuilder.<para/>
    /// Resulting BOC of this method can be passed into Solidity and C++ contracts as TvmCell type.
    /// </summary>
    Task<ResultOfEncodeBoc> EncodeBoc(ParamsOfEncodeBoc @params);

    /// <summary>
    /// Returns the contract code's salt if it is present.
    /// </summary>
    Task<ResultOfGetCodeSalt> GetCodeSalt(ParamsOfGetCodeSalt @params);

    /// <remarks>
    /// Returns the new contract code with salt.
    /// </remarks>
    Task<ResultOfSetCodeSalt> SetCodeSalt(ParamsOfSetCodeSalt @params);

    /// <summary>
    /// Decodes contract's initial state into code, data, libraries and special options.
    /// </summary>
    Task<ResultOfDecodeStateInit> DecodeStateInit(ParamsOfDecodeStateInit @params);

    /// <summary>
    /// Encodes initial contract state from code, data, libraries ans special options (see input params).
    /// </summary>
    Task<ResultOfEncodeStateInit> EncodeStateInit(ParamsOfEncodeStateInit @params);

    /// <remarks>
    /// Allows to encode any external inbound message.
    /// </remarks>
    Task<ResultOfEncodeExternalInMessage> EncodeExternalInMessage(ParamsOfEncodeExternalInMessage @params);

    /// <summary>
    /// Returns the compiler version used to compile the code.
    /// </summary>
    Task<ResultOfGetCompilerVersion> GetCompilerVersion(ParamsOfGetCompilerVersion @params);
}