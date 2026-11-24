#if !NET6_0_OR_GREATER
namespace System.Runtime.InteropServices;

/// <summary>
/// Represents a C <c>long</c> in native calls, for targets older than .NET 6 that do not define this type.
/// These targets only run on Windows, where a C <c>long</c> is 32-bit.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal readonly struct CLong
{
    private readonly int NativeValue;

    /// <summary>
    /// Initializes a new instance of the <see cref="CLong"/> struct.
    /// </summary>
    /// <param name="value">The value.</param>
    public CLong(int value)
    {
        NativeValue = value;
    }

    /// <summary>
    /// Gets the value.
    /// </summary>
    public int Value => NativeValue;
}
#endif
