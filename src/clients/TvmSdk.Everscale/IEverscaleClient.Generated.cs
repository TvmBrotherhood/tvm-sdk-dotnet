using TvmSdk.Everscale.Modules.Client;
using TvmSdk.Everscale.Modules.Crypto;
using TvmSdk.Everscale.Modules.Abi;
using TvmSdk.Everscale.Modules.Boc;
using TvmSdk.Everscale.Modules.Processing;
using TvmSdk.Everscale.Modules.Utils;
using TvmSdk.Everscale.Modules.Tvm;
using TvmSdk.Everscale.Modules.Net;
using TvmSdk.Everscale.Modules.Debot;
using TvmSdk.Everscale.Modules.Proofs;

namespace TvmSdk.Everscale;

public interface IEverscaleClient
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