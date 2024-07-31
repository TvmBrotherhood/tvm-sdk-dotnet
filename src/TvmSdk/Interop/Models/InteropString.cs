using System.Runtime.InteropServices;
using System.Text;

namespace TvmSdk.Interop.Models;

[StructLayout(LayoutKind.Sequential)]
internal struct InteropString : IDisposable
{
    public IntPtr Content;

    /// <summary>
    /// Size of random byte array.
    /// </summary>
    public uint Length;

    public void Dispose()
    {
        Marshal.FreeHGlobal(Content);
    }

    public override string ToString()
    {
        var bytes = new byte[Length];
        Marshal.Copy(Content, bytes, 0, (int)Length);

        return Encoding.UTF8.GetString(bytes);
    }

    public static InteropString Create(string str)
    {
        var bytes = Encoding.UTF8.GetBytes(str);
        var pointer = Marshal.AllocHGlobal(bytes.Length);
        Marshal.Copy(bytes, 0, pointer, bytes.Length);

        return new InteropString
        {
            Content = pointer,
            Length = (uint)bytes.Length
        };
    }
}