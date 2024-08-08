namespace TvmSdk.Ton.Modules.Abi;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DataLayout : byte
{
    /// <summary>
    /// Decode message body as function input parameters.
    /// </summary>
    Input,
    /// <summary>
    /// Decode message body as function output.
    /// </summary>
    Output
}