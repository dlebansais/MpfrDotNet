namespace MpirDotNet;

using System;
using System.Diagnostics;
using System.Text;
using static Interop.Mpir.NativeMethods;

/// <summary>
/// Arbitrary precision rational number.
/// </summary>
public partial class mpq_t : IDisposable, IEquatable<mpq_t>, ICloneable, IConvertible, IComparable, IComparable<mpq_t>
{
    private const int MaxArrayLength = 32;

    private static void ProcessArray(mpq_t[] numbers, Action<IntPtr[]> action)
    {
        IntPtr[] Args = new IntPtr[MaxArrayLength];

        FillArray(Args, numbers, 0, action);
    }

    private static void FillArray(IntPtr[] args, mpq_t[] numbers, int index, Action<IntPtr[]> action)
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
                fixed (__mpq_t* ValueAddress = &numbers[index].Value)
                {
                    args[index] = (IntPtr)ValueAddress;
                    FillArray(args, numbers, index + 1, action);
                }
            }
        }
    }
}
