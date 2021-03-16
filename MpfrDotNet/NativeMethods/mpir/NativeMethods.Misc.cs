namespace MpirDotNet
{
    using System;
    using System.Runtime.InteropServices;

    internal static partial class NativeMethods
    {
        public static IntPtr[] AllocateIntegerArray(mpz_t[] integers)
        {
            IntPtr[] Result = new IntPtr[integers.Length + 1];

            for (int i = 0; i < integers.Length; i++)
            {
                __mpz_t Value = integers[i].Value;

                Result[i] = Marshal.AllocCoTaskMem(Marshal.SizeOf(Value));
                Marshal.StructureToPtr(Value, Result[i], false);
            }

            Result[integers.Length] = IntPtr.Zero;

            return Result;
        }

        public static void FreeIntegerArray(IntPtr[] array)
        {
            for (int i = 0; i + 1 < array.Length; i++)
                Marshal.FreeCoTaskMem(array[i]);
        }
    }
}
