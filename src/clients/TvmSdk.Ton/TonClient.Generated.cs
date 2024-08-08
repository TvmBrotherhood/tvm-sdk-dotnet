using TvmSdk.DllAdapter;
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

public class TonClient : ITonClient
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

    public TonClient(ITvmSdkDllAdapter adapter, IClientModule? clientModule = null, ICryptoModule? cryptoModule = null, IAbiModule? abiModule = null, IBocModule? bocModule = null, IProcessingModule? processingModule = null, IUtilsModule? utilsModule = null, ITvmModule? tvmModule = null, INetModule? netModule = null, IDebotModule? debotModule = null, IProofsModule? proofsModule = null)
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