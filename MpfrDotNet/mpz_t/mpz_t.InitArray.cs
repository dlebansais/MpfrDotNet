namespace MpirDotNet;

using System;
using System.Diagnostics;
using static Interop.Mpir.NativeMethods;

/// <summary>
/// Arbitrary precision integer.
/// </summary>
public partial class mpz_t : IDisposable, IEquatable<mpz_t>, ICloneable, IConvertible, IComparable, IComparable<mpz_t>
{
    private const int MaxArrayLength = 32;

    private static void ProcessArray(mpz_t[] numbers, Action<IntPtr[]> action)
    {
        IntPtr[] Args = new IntPtr[MaxArrayLength];

        FillArray(Args, numbers, 0, action);
    }

    private static void FillArray(IntPtr[] args, mpz_t[] numbers, int index, Action<IntPtr[]> action)
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
                fixed (__mpz_t* ValueAddress = &numbers[index].Value)
                {
                    args[index] = (IntPtr)ValueAddress;
                    FillArray(args, numbers, index + 1, action);
                }
            }
        }
    }
}
