namespace Interop.Mpfr
{
    using System;
    using System.Runtime.InteropServices;

    internal static partial class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct __mpfr_t
        {
            public long Precision;
            public int Sign;
            public long Exponent;
            public IntPtr Limbs;
        }
    }
}
