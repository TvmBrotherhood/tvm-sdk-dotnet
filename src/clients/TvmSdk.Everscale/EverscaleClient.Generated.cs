using TvmSdk.DllAdapter;
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

public class EverscaleClient : IEverscaleClient
{
    public IClientModule Client { get; init; }
    public ICryptoModule Crypto { get; init; }
    public IAbiModule Abi { get; init; }
    public IBocModule Boc { get; init; }
    public IProcessingModule Processing { get; init; }
    public IUtilsModule Utils { get; init; }
    public ITvmModule Tvm { get; init; }
    public INetModule Net { get; init; }
    public IDebotModule Debot { get; init; }
    public IProofsModule Proofs { get; init; }

    public EverscaleClient(ITvmSdkDllAdapter adapter, IClientModule? clientModule = null, ICryptoModule? cryptoModule = null, IAbiModule? abiModule = null, IBocModule? bocModule = null, IProcessingModule? processingModule = null, IUtilsModule? utilsModule = null, ITvmModule? tvmModule = null, INetModule? netModule = null, IDebotModule? debotModule = null, IProofsModule? proofsModule = null)
    {
        Client = clientModule ?? new ClientModule(adapter);
        Crypto = cryptoModule ?? new CryptoModule(adapter);
        Abi = abiModule ?? new AbiModule(adapter);
        Boc = bocModule ?? new BocModule(adapter);
        Processing = processingModule ?? new ProcessingModule(adapter);
        Utils = utilsModule ?? new UtilsModule(adapter);
        Tvm = tvmModule ?? new TvmModule(adapter);
        Net = netModule ?? new NetModule(adapter);
        Debot = debotModule ?? new DebotModule(adapter);
        Proofs = proofsModule ?? new ProofsModule(adapter);
    }
}