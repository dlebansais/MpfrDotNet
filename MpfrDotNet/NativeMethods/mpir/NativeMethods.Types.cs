namespace MpirDotNet
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;

    internal static partial class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct __mpz_t
        {
            public int AllocCount;
            public int LimbCount;
            public IntPtr Limbs;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct __mpq_t
        {
            public __mpz_t Numerator;
            public __mpz_t Denominator;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct __mpf_t
        {
            public int Precision;
            public int Size;
            public long Exponent;
            public IntPtr Limbs;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct __gmp_randstate_t
        {
            public __mpz_t seed;
            public int Algorithm;
            public IntPtr AlgorithmData;
        }
    }
}
