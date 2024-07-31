using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using TvmSdk.Exceptions;
using TvmSdk.Interop;
using TvmSdk.Interop.Enums;
using TvmSdk.Interop.Models;
using TvmSdk.Modules.Abi;
using TvmSdk.Modules.Boc;
using TvmSdk.Modules.Client;
using TvmSdk.Modules.Crypto;
using TvmSdk.Modules.Debot;
using TvmSdk.Modules.Net;
using TvmSdk.Modules.Processing;
using TvmSdk.Modules.Proofs;
using TvmSdk.Modules.Tvm;
using TvmSdk.Modules.Utils;
using ClientError = TvmSdk.Interop.Models.ClientError;

namespace TvmSdk;

public sealed class TvmClient : ITvmClient
{
    private readonly uint _context;

    private uint _requestIndex;

    public const int DefaultAbiVersion = 2;

    public readonly JsonSerializerOptions JsonSerializerOptions;
    public IAbiModule Abi { get; set; }
    public IBocModule Boc { get; set; }
    public IClientModule Client { get; set; }
    public ICryptoModule Crypto { get; set; }
    public IDebotModule Debot { get; set; }
    public INetModule Net { get; set; }
    public IProcessingModule Processing { get; set; }
    public ITvmModule Tvm { get; set; }
    public IUtilsModule Utils { get; set; }
    public IProofsModule Proofs { get; set; }

    public TvmClient(
        ClientConfig? clientConfig = null,
        IAbiModule? abiModule = null,
        IBocModule? bocModule = null,
        IClientModule? clientModule = null,
        ICryptoModule? cryptoModule = null,
        IDebotModule? debotModule = null,
        INetModule? netModule = null,
        IProcessingModule? processingModule = null,
        ITvmModule? tvmModule = null,
        IUtilsModule? utilsModule = null,
        IProofsModule? proofsModule = null)
    {
        JsonSerializerOptions = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            MaxDepth = 1000,
        };
        _context = CreateContext(clientConfig);

        Abi = abiModule ?? new AbiModule(this);
        Boc = bocModule ?? new BocModule(this);
        Client = clientModule ?? new ClientModule(this);
        Crypto = cryptoModule ?? new CryptoModule(this);
        Debot = debotModule ?? new DebotModule(this);
        Net = netModule ?? new NetModule(this);
        Processing = processingModule ?? new ProcessingModule(this);
        Tvm = tvmModule ?? new TvmModule(this);
        Utils = utilsModule ?? new UtilsModule(this);
        Proofs = proofsModule ?? new ProofsModule(this);
    }

    public Task CallFunction(string name, object? @params = null)
    {
        return CallFunction<string>(name, @params);
    }

    public Task<T> CallFunction<T>(string name, object? @params = null)
    {
        return CallFunction<T, object>(name, @params);
    }

    /// <summary>
    /// Makes 'tc_request' call to Free TON Sdk library and gets async response of it.
    /// </summary>
    public Task<T> CallFunction<T, TCallback>(
        string name,
        object? @params = null,
        Action<TCallback, FunctionExecutionStatus> callback = null,
        Func<string, Task> func = null)
    {
        var result = new TaskCompletionSource<T>();
        var callbackHandle = default(GCHandle);
        var responeHandler = new TonAdapter.ResponseHandler((requestId, resultJsonData, responseType, isFinished) =>
            {
                try
                {
                    switch (responseType)
                    {
                        case FunctionExecutionStatus.Success:
                            result.SetResult(DeserializeOrThrow<T>(resultJsonData));
                            break;
                        case FunctionExecutionStatus.Custom:
                            if (callback != null)
                            {
                                callback.Invoke(DeserializeOrThrow<TCallback>(resultJsonData), responseType);
                            }
                            break;
                        case FunctionExecutionStatus.NoOperation:
                            break;
                        case FunctionExecutionStatus.Error:
                        default:
                            var error = DeserializeOrThrow<ClientError>(resultJsonData);
                            result.SetException(new InvalidFunctionCallException(error.Message, error.Code, error.Data));
                            break;
                    }
                }
                catch (Exception exception)
                {
                    result.SetException(exception);
                }
                finally
                {
                    if (isFinished && callbackHandle.IsAllocated)
                    {
                        callbackHandle.Free();
                    }
                }
            });
        callbackHandle = GCHandle.Alloc(responeHandler);

        var serializedParams = Serialize(@params) ?? "";
        Console.WriteLine($"Got request: {serializedParams}");
        using var methodNameInteropString = InteropString.Create(name);
        using var paramsJsonInteropString = InteropString.Create(serializedParams);
        var tcs = new TaskCompletionSource<string>();
        var handler = TonAdapter.tc_request(
            _context,
            methodNameInteropString,
            paramsJsonInteropString,
            ++_requestIndex,
            responeHandler
        );

        return result.Task;
    }

    public ResultOfFunctionCall<T> CallFunctionSync<T>(string name, object? paramsJson = null)
    {
        using var methodNameInteropString = InteropString.Create(name);
        using var paramsJsonInteropString = InteropString.Create(Serialize(paramsJson) ?? "");
        var resultPtr =
            TonAdapter.tc_request_sync(_context, methodNameInteropString, paramsJsonInteropString);
        var jsonResult = TonAdapter.tc_read_json_response(resultPtr);
        var resultJson = jsonResult.ResultJson.ToString();
        var errorJson = jsonResult.ErrorJson.ToString();
        TonAdapter.tc_destroy_json_response(resultPtr);

        return new ResultOfFunctionCall<T>
        {
            Result = JsonSerializer.Deserialize<T>(resultJson),
            Error = JsonSerializer.Deserialize<ClientError>(errorJson)
        };
    }

    public void Dispose()
    {
        TonAdapter.tc_destroy_context(_context);
    }

    private T DeserializeOrThrow<T>(InteropString interopString)
    {
        var responseJson = interopString.ToString();
        
        Console.WriteLine($"Got response: {responseJson}");

        if (responseJson == "null")
            return default(T);

        var responseResult = JsonSerializer.Deserialize<T>(responseJson, JsonSerializerOptions);

        if (responseResult == null)
            throw new SerializationException(responseJson);

        return responseResult;
    }

    private string? Serialize(object? obj = null)
    {
        if (obj == null)
            return null;

        var result = JsonSerializer.Serialize(obj, JsonSerializerOptions);
        return result;
    }

    private uint CreateContext(ClientConfig? clientConfig = null)
    {
        var jsonClientConfig = "{}";

        if (clientConfig != null)
        {
            jsonClientConfig = JsonSerializer.Serialize(clientConfig, JsonSerializerOptions);
        }

        using var clientConfigInteropString = InteropString.Create(jsonClientConfig);
        var contextPointer = TonAdapter.tc_create_context(clientConfigInteropString);

        if (contextPointer == IntPtr.Zero)
            throw new Exception($"Could not create context, {nameof(TonAdapter.tc_create_context)} returned null.");

        var contextData = TonAdapter.tc_read_string(contextPointer);
        var contextJson = contextData.ToString();
        var context = JsonSerializer.Deserialize<ResultOfFunctionCall<uint?>>(contextJson, JsonSerializerOptions);

        if (context.Error != null)
        {
            var error = context.Error;
            throw new InvalidFunctionCallException(error.Message, error.Code, error.Data);
        }

        if (context.Result == null || context.Result == 0)
        {
            throw new TvmClientException($"Context result is {context.Result}");
        }

        TonAdapter.tc_destroy_string(contextPointer);

        return context.Result.Value;
    }
}
