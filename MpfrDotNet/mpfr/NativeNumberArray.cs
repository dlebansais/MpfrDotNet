namespace MpfrDotNet;

using System;
using System.Runtime.InteropServices;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an array of pointers to the numbers of an array, as mpfr_sum takes it.
/// </summary>
internal sealed class NativeNumberArray : IDisposable
{
    #region Init
    /// <summary>
    /// Initializes a new instance of the <see cref="NativeNumberArray"/> class.
    /// </summary>
    /// <param name="numbers">The numbers.</param>
    /// <exception cref="OverflowException">The array is too large for the native memory.</exception>
    public NativeNumberArray(mpfr_t[] numbers)
    {
        // The numbers are copied, because a managed object cannot be pinned: the copies share the significands, which
        // MPFR only reads. The sizes are computed in 64 bits, and checked.
        long HeaderSize = Marshal.SizeOf<__mpfr_t>();
        long Count = Math.Max(1, numbers.Length);
        IntPtr NewHeaders = Marshal.AllocHGlobal(new IntPtr(checked(Count * HeaderSize)));
        IntPtr NewPointer = IntPtr.Zero;

        try
        {
            NewPointer = Marshal.AllocHGlobal(new IntPtr(checked(Count * IntPtr.Size)));

            for (int i = 0; i < numbers.Length; i++)
            {
                IntPtr Header = Offset(NewHeaders, i * HeaderSize);
                Marshal.StructureToPtr(numbers[i].Value, Header, fDeleteOld: false);
                Marshal.WriteIntPtr(Offset(NewPointer, (long)i * IntPtr.Size), Header);
            }
        }
        catch
        {
            // A null number, or a failed allocation, must not leak the memory already allocated.
            Marshal.FreeHGlobal(NewPointer);
            Marshal.FreeHGlobal(NewHeaders);
            throw;
        }

        Headers = NewHeaders;
        Pointer = NewPointer;
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
    /// Gets an address at a 64-bit offset from another.
    /// </summary>
    /// <param name="address">The address.</param>
    /// <param name="offset">The offset, in bytes.</param>
    /// <returns>The new address.</returns>
    internal static IntPtr Offset(IntPtr address, long offset)
        => new(checked(address.ToInt64() + offset));

    /// <summary>
    /// Frees the native memory.
    /// </summary>
    public void Dispose()
    {
        Marshal.FreeHGlobal(Pointer);
        Marshal.FreeHGlobal(Headers);
    }
}
