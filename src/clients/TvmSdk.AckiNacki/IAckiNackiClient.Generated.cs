using TvmSdk.AckiNacki.Modules.Client;
using TvmSdk.AckiNacki.Modules.Crypto;
using TvmSdk.AckiNacki.Modules.Abi;
using TvmSdk.AckiNacki.Modules.Boc;
using TvmSdk.AckiNacki.Modules.Processing;
using TvmSdk.AckiNacki.Modules.Utils;
using TvmSdk.AckiNacki.Modules.Tvm;
using TvmSdk.AckiNacki.Modules.Net;
using TvmSdk.AckiNacki.Modules.Debot;
using TvmSdk.AckiNacki.Modules.Proofs;

namespace TvmSdk.AckiNacki;

public interface IAckiNackiClient
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