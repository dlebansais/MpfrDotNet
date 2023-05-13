namespace MpfrDotNet;

using System;
using System.Diagnostics;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public partial class mpfr_t : IDisposable
{
    private const int MaxArrayLength = 32;

    private static void ProcessArray(mpfr_t[] numbers, Action<IntPtr[]> action)
    {
        IntPtr[] Args = new IntPtr[MaxArrayLength];

        FillArray(Args, numbers, 0, action);
    }

    private static void FillArray(IntPtr[] args, mpfr_t[] numbers, int index, Action<IntPtr[]> action)
    {
        Debug.Assert(index < MaxArrayLength);

        if (index >= numbers.Length)
        {
            for (int i = index; i < MaxArrayLength; i++)
                args[i] = IntPtr.Zero;

            action(args);
        }
        else
        {
            unsafe
            {
                fixed (__mpfr_t* ValueAddress = &numbers[index].Value)
                {
                    args[index] = (IntPtr)ValueAddress;
                    FillArray(args, numbers, index + 1, action);
                }
            }
        }
    }
}
