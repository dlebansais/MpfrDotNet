#if !NET6_0_OR_GREATER
namespace System.Runtime.InteropServices;

/// <summary>
/// Represents a C <c>unsigned long</c> in native calls, for targets older than .NET 6 that do not define this type.
/// These targets only run on Windows, where a C <c>unsigned long</c> is 32-bit.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal readonly struct CULong
{
    private readonly uint NativeValue;

    /// <summary>
    /// Initializes a new instance of the <see cref="CULong"/> struct.
    /// </summary>
    /// <param name="value">The value.</param>
    public CULong(uint value)
    {
        NativeValue = value;
    }

    /// <summary>
    /// Gets the value.
    /// </summary>
    public uint Value => NativeValue;
}
#endif
