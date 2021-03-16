namespace MpfrDotNet
{
    using System;
    using System.Runtime.InteropServices;

    internal static partial class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct __mpfr_t
        {
            long Precision;
            int Sign;
            long Exponent;
            IntPtr Limbs;
        }
    }
}
