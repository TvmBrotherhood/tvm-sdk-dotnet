namespace TvmSdk.Everscale.Modules.Proofs;

/// <summary>
/// <a href="UNSTABLE.md">UNSTABLE</a><a href="DEPRECATED.md">DEPRECATED</a> Module for proving data, retrieved from TONOS API.
/// </summary>
public interface IProofsModule
{
    /// <remarks>
    /// This function checks block proofs and compares given data with the proven.<para/>
    /// If the given data differs from the proven, the exception will be thrown.<para/>
    /// The input param is a single block's JSON object, which was queried from DApp server using functions such as <c>net.query</c>, <c>net.query_collection</c> or <c>net.wait_for_collection</c>.<para/>
    /// If block's BOC is not provided in the JSON, it will be queried from DApp server (in this case it is required to provide at least <c>id</c> of block).<para/>
    /// Please note, that joins (like <c>signatures</c> in <c>Block</c>) are separated entities and not supported, so function will throw an exception in a case if JSON being checked has such entities in it.<para/>
    /// If <c>cache_in_local_storage</c> in config is set to <c>true</c> (default), downloaded proofs and master-chain BOCs are saved into the persistent local storage (e.g.<para/>
    /// File system for native environments or browser's IndexedDB for the web); otherwise all the data is cached only in memory in current client's context and will be lost after destruction of the client.<para/>
    /// **Why Proofs are needed**  Proofs are needed to ensure that the data downloaded from a DApp server is real blockchain data.<para/>
    /// Checking proofs can protect from the malicious DApp server which can potentially provide fake data, or also from "Man in the Middle" attacks class.<para/>
    /// **What Proofs are**  Simply, proof is a list of signatures of validators', which have signed this particular master- block.<para/>
    /// The very first validator set's public keys are included in the zero-state.<para/>
    /// Whe know a root hash of the zero-state, because it is stored in the network configuration file, it is our authority root.<para/>
    /// For proving zero-state it is enough to calculate and compare its root hash.<para/>
    /// In each new validator cycle the validator set is changed.<para/>
    /// The new one is stored in a key-block, which is signed by the validator set, which we already trust, the next validator set will be stored to the new key-block and signed by the current validator set, and so on.<para/>
    /// In order to prove any block in the master-chain we need to check, that it has been signed by a trusted validator set.<para/>
    /// So we need to check all key-blocks' proofs, started from the zero-state and until the block, which we want to prove.<para/>
    /// But it can take a lot of time and traffic to download and prove all key-blocks on a client.<para/>
    /// For solving this, special trusted blocks are used in Ever-SDK.<para/>
    /// The trusted block is the authority root, as well, as the zero-state.<para/>
    /// Each trusted block is the <c>id</c> (e.g.<para/>
    /// <c>root_hash</c>) of the already proven key-block.<para/>
    /// There can be plenty of trusted blocks, so there can be a lot of authority roots.<para/>
    /// The hashes of trusted blocks for MainNet and DevNet are hardcoded in SDK in a separated binary file (trusted_key_blocks.bin) and is being updated for each release by using <c>update_trusted_blocks</c> utility.<para/>
    /// See <a href="../../../tools/update_trusted_blocks">update_trusted_blocks</a> directory for more info.<para/>
    /// In future SDK releases, one will also be able to provide their hashes of trusted blocks for other networks, besides for MainNet and DevNet.<para/>
    /// By using trusted key-blocks, in order to prove any block, we can prove chain of key-blocks to the closest previous trusted key-block, not only to the zero-state.<para/>
    /// But shard-blocks don't have proofs on DApp server.<para/>
    /// In this case, in order to prove any shard- block data, we search for a corresponding master-block, which contains the root hash of this shard-block, or some shard block which is linked to that block in shard-chain.<para/>
    /// After proving this master-block, we traverse through each link and calculate and compare hashes with links, one-by-one.<para/>
    /// After that we can ensure that this shard-block has also been proven.
    /// </remarks>
    Task ProofBlockData(ParamsOfProofBlockData @params);

    /// <remarks>
    /// This function requests the corresponding block, checks block proofs, ensures that given transaction exists in the proven block and compares given data with the proven.<para/>
    /// If the given data differs from the proven, the exception will be thrown.<para/>
    /// The input parameter is a single transaction's JSON object (see params description), which was queried from TONOS API using functions such as <c>net.query</c>, <c>net.query_collection</c> or <c>net.wait_for_collection</c>.<para/>
    /// If transaction's BOC and/or <c>block_id</c> are not provided in the JSON, they will be queried from TONOS API.<para/>
    /// Please note, that joins (like <c>account</c>, <c>in_message</c>, <c>out_messages</c>, etc.<para/>
    /// In <c>Transaction</c> entity) are separated entities and not supported, so function will throw an exception in a case if JSON being checked has such entities in it.<para/>
    /// For more information about proofs checking, see description of <c>proof_block_data</c> function.
    /// </remarks>
    Task ProofTransactionData(ParamsOfProofTransactionData @params);

    /// <remarks>
    /// This function first proves the corresponding transaction, ensures that the proven transaction refers to the given message and compares given data with the proven.<para/>
    /// If the given data differs from the proven, the exception will be thrown.<para/>
    /// The input parameter is a single message's JSON object (see params description), which was queried from TONOS API using functions such as <c>net.query</c>, <c>net.query_collection</c> or <c>net.wait_for_collection</c>.<para/>
    /// If message's BOC and/or non-null <c>src_transaction.id</c> or <c>dst_transaction.id</c> are not provided in the JSON, they will be queried from TONOS API.<para/>
    /// Please note, that joins (like <c>block</c>, <c>dst_account</c>, <c>dst_transaction</c>, <c>src_account</c>, <c>src_transaction</c>, etc.<para/>
    /// In <c>Message</c> entity) are separated entities and not supported, so function will throw an exception in a case if JSON being checked has such entities in it.<para/>
    /// For more information about proofs checking, see description of <c>proof_block_data</c> function.
    /// </remarks>
    Task ProofMessageData(ParamsOfProofMessageData @params);
}