using TvmSdk.Ton.Modules.Client;
using TvmSdk.Ton.Modules.Crypto;
using TvmSdk.Ton.Modules.Abi;
using TvmSdk.Ton.Modules.Boc;
using TvmSdk.Ton.Modules.Processing;
using TvmSdk.Ton.Modules.Utils;
using TvmSdk.Ton.Modules.Tvm;
using TvmSdk.Ton.Modules.Net;
using TvmSdk.Ton.Modules.Debot;
using TvmSdk.Ton.Modules.Proofs;

namespace TvmSdk.Ton;

public interface ITonClient
{
    IClientModule Client { get; init; }
    ICryptoModule Crypto { get; init; }
    IAbiModule Abi { get; init; }
    IBocModule Boc { get; init; }
    IProcessingModule Processing { get; init; }
    IUtilsModule Utils { get; init; }
    ITvmModule Tvm { get; init; }
    INetModule Net { get; init; }
    IDebotModule Debot { get; init; }
    IProofsModule Proofs { get; init; }
}