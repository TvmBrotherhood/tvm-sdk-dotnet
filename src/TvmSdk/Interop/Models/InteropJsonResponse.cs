using System.Runtime.InteropServices;

namespace TvmSdk.Interop.Models;

[StructLayout(LayoutKind.Sequential)]
internal struct InteropJsonResponse
{
    public InteropString ResultJson { get; init; }
    public InteropString ErrorJson { get; init; }
}