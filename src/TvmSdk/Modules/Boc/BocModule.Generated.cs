namespace TvmSdk.Modules.Boc;

/// <summary>
/// BOC manipulation module.
/// </summary>
public class BocModule(ITvmClient client) : IBocModule
{
    /// <summary>
    /// Decodes tvc according to the tvc spec.<para/>
    /// Read more about tvc structure here https://github.com/everx-labs/ever-struct/blob/main/src/scheme/mod.rs#L30.
    /// </summary>
    public Task<ResultOfDecodeTvc> DecodeTvc(ParamsOfDecodeTvc @params)
    {
        return client.CallFunction<ResultOfDecodeTvc>("boc.decode_tvc", @params);
    }

    /// <remarks>
    /// JSON structure is compatible with GraphQL API message object.
    /// </remarks>
    public Task<ResultOfParse> ParseMessage(ParamsOfParse @params)
    {
        return client.CallFunction<ResultOfParse>("boc.parse_message", @params);
    }

    /// <remarks>
    /// JSON structure is compatible with GraphQL API transaction object.
    /// </remarks>
    public Task<ResultOfParse> ParseTransaction(ParamsOfParse @params)
    {
        return client.CallFunction<ResultOfParse>("boc.parse_transaction", @params);
    }

    /// <remarks>
    /// JSON structure is compatible with GraphQL API account object.
    /// </remarks>
    public Task<ResultOfParse> ParseAccount(ParamsOfParse @params)
    {
        return client.CallFunction<ResultOfParse>("boc.parse_account", @params);
    }

    /// <remarks>
    /// JSON structure is compatible with GraphQL API block object.
    /// </remarks>
    public Task<ResultOfParse> ParseBlock(ParamsOfParse @params)
    {
        return client.CallFunction<ResultOfParse>("boc.parse_block", @params);
    }

    /// <remarks>
    /// JSON structure is compatible with GraphQL API shardstate object.
    /// </remarks>
    public Task<ResultOfParse> ParseShardstate(ParamsOfParseShardstate @params)
    {
        return client.CallFunction<ResultOfParse>("boc.parse_shardstate", @params);
    }

    /// <summary>
    /// Extract blockchain configuration from key block and also from zerostate.
    /// </summary>
    public Task<ResultOfGetBlockchainConfig> GetBlockchainConfig(ParamsOfGetBlockchainConfig @params)
    {
        return client.CallFunction<ResultOfGetBlockchainConfig>("boc.get_blockchain_config", @params);
    }

    /// <summary>
    /// Calculates BOC root hash.
    /// </summary>
    public Task<ResultOfGetBocHash> GetBocHash(ParamsOfGetBocHash @params)
    {
        return client.CallFunction<ResultOfGetBocHash>("boc.get_boc_hash", @params);
    }

    /// <summary>
    /// Calculates BOC depth.
    /// </summary>
    public Task<ResultOfGetBocDepth> GetBocDepth(ParamsOfGetBocDepth @params)
    {
        return client.CallFunction<ResultOfGetBocDepth>("boc.get_boc_depth", @params);
    }

    /// <summary>
    /// Extracts code from TVC contract image.
    /// </summary>
    public Task<ResultOfGetCodeFromTvc> GetCodeFromTvc(ParamsOfGetCodeFromTvc @params)
    {
        return client.CallFunction<ResultOfGetCodeFromTvc>("boc.get_code_from_tvc", @params);
    }

    /// <summary>
    /// Get BOC from cache.
    /// </summary>
    public Task<ResultOfBocCacheGet> CacheGet(ParamsOfBocCacheGet @params)
    {
        return client.CallFunction<ResultOfBocCacheGet>("boc.cache_get", @params);
    }

    /// <summary>
    /// Save BOC into cache or increase pin counter for existing pinned BOC.
    /// </summary>
    public Task<ResultOfBocCacheSet> CacheSet(ParamsOfBocCacheSet @params)
    {
        return client.CallFunction<ResultOfBocCacheSet>("boc.cache_set", @params);
    }

    /// <summary>
    /// Unpin BOCs with specified pin defined in the <c>cache_set</c>.<para/>
    /// Decrease pin reference counter for BOCs with specified pin defined in the <c>cache_set</c>.<para/>
    /// BOCs which have only 1 pin and its reference counter become 0 will be removed from cache.
    /// </summary>
    public Task CacheUnpin(ParamsOfBocCacheUnpin @params)
    {
        return client.CallFunction("boc.cache_unpin", @params);
    }

    /// <summary>
    /// Encodes bag of cells (BOC) with builder operations.<para/>
    /// This method provides the same functionality as Solidity TvmBuilder.<para/>
    /// Resulting BOC of this method can be passed into Solidity and C++ contracts as TvmCell type.
    /// </summary>
    public Task<ResultOfEncodeBoc> EncodeBoc(ParamsOfEncodeBoc @params)
    {
        return client.CallFunction<ResultOfEncodeBoc>("boc.encode_boc", @params);
    }

    /// <summary>
    /// Returns the contract code's salt if it is present.
    /// </summary>
    public Task<ResultOfGetCodeSalt> GetCodeSalt(ParamsOfGetCodeSalt @params)
    {
        return client.CallFunction<ResultOfGetCodeSalt>("boc.get_code_salt", @params);
    }

    /// <remarks>
    /// Returns the new contract code with salt.
    /// </remarks>
    public Task<ResultOfSetCodeSalt> SetCodeSalt(ParamsOfSetCodeSalt @params)
    {
        return client.CallFunction<ResultOfSetCodeSalt>("boc.set_code_salt", @params);
    }

    /// <summary>
    /// Decodes contract's initial state into code, data, libraries and special options.
    /// </summary>
    public Task<ResultOfDecodeStateInit> DecodeStateInit(ParamsOfDecodeStateInit @params)
    {
        return client.CallFunction<ResultOfDecodeStateInit>("boc.decode_state_init", @params);
    }

    /// <summary>
    /// Encodes initial contract state from code, data, libraries ans special options (see input params).
    /// </summary>
    public Task<ResultOfEncodeStateInit> EncodeStateInit(ParamsOfEncodeStateInit @params)
    {
        return client.CallFunction<ResultOfEncodeStateInit>("boc.encode_state_init", @params);
    }

    /// <remarks>
    /// Allows to encode any external inbound message.
    /// </remarks>
    public Task<ResultOfEncodeExternalInMessage> EncodeExternalInMessage(ParamsOfEncodeExternalInMessage @params)
    {
        return client.CallFunction<ResultOfEncodeExternalInMessage>("boc.encode_external_in_message", @params);
    }

    /// <summary>
    /// Returns the compiler version used to compile the code.
    /// </summary>
    public Task<ResultOfGetCompilerVersion> GetCompilerVersion(ParamsOfGetCompilerVersion @params)
    {
        return client.CallFunction<ResultOfGetCompilerVersion>("boc.get_compiler_version", @params);
    }
}