using TvmSdk.DllAdapter;
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

public class AckiNackiClient : IAckiNackiClient
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

    public AckiNackiClient(ITvmSdkDllAdapter adapter, IClientModule? clientModule = null, ICryptoModule? cryptoModule = null, IAbiModule? abiModule = null, IBocModule? bocModule = null, IProcessingModule? processingModule = null, IUtilsModule? utilsModule = null, ITvmModule? tvmModule = null, INetModule? netModule = null, IDebotModule? debotModule = null, IProofsModule? proofsModule = null)
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