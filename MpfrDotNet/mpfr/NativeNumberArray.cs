namespace MpfrDotNet;

using System;
using System.Runtime.InteropServices;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an array of pointers to the numbers of an array, as mpfr_sum and mpfr_dot take it.
/// </summary>
internal sealed class NativeNumberArray : IDisposable
{
    #region Init
    /// <summary>
    /// Initializes a new instance of the <see cref="NativeNumberArray"/> class.
    /// </summary>
    /// <param name="numbers">The numbers, which are not <see langword="null"/>.</param>
    public NativeNumberArray(mpfr_t[] numbers)
    {
        // The numbers are copied, because a managed object cannot be pinned: the copies share the significands, which
        // MPFR only reads.
        int HeaderSize = Marshal.SizeOf<__mpfr_t>();
        Headers = Marshal.AllocHGlobal(Math.Max(1, numbers.Length) * HeaderSize);
        Pointer = Marshal.AllocHGlobal(Math.Max(1, numbers.Length) * IntPtr.Size);

        for (int i = 0; i < numbers.Length; i++)
        {
            IntPtr Header = Headers + (i * HeaderSize);
            Marshal.StructureToPtr(numbers[i].Value, Header, fDeleteOld: false);
            Marshal.WriteIntPtr(Pointer, i * IntPtr.Size, Header);
        }
    }
    #endregion

    #region Properties
    /// <summary>
    /// Gets the address of the array of pointers.
    /// </summary>
    public IntPtr Pointer { get; }

    /// <summary>
    /// Gets the address of the copies of the numbers.
    /// </summary>
    public IntPtr Headers { get; }
    #endregion

    /// <summary>
    /// Frees the native memory.
    /// </summary>
    public void Dispose()
    {
        Marshal.FreeHGlobal(Pointer);
        Marshal.FreeHGlobal(Headers);
    }
}
