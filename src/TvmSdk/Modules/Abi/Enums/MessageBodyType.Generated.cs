namespace TvmSdk.Modules.Abi;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MessageBodyType : byte
{
    /// <summary>
    /// Message contains the input of the ABI function.
    /// </summary>
    Input,
    /// <summary>
    /// Message contains the output of the ABI function.
    /// </summary>
    Output,
    /// <remarks>
    /// Occurs when contract sends an internal message to other contract.
    /// </remarks>
    InternalOutput,
    /// <summary>
    /// Message contains the input of the ABI event.
    /// </summary>
    Event
}