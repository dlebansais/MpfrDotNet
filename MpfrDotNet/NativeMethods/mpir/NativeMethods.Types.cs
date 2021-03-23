namespace Interop.Mpir
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

        [StructLayout(LayoutKind.Sequential)]
        public struct mp_bitcnt_t
        {
            public ulong Count;

            public static explicit operator mp_bitcnt_t(ulong count)
            {
                return new mp_bitcnt_t() { Count = count };
            }

            public static explicit operator ulong(mp_bitcnt_t cnt)
            {
                return cnt.Count;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct size_t
        {
            public ulong Size;

            public static explicit operator size_t(ulong size)
            {
                return new size_t() { Size = size };
            }

            public static explicit operator ulong(size_t size)
            {
                return size.Size;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct mpir_si
        {
            public long Value;

            public static explicit operator mpir_si(long value)
            {
                return new mpir_si() { Value = value };
            }

            public static explicit operator long(mpir_si value)
            {
                return value.Value;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct mpir_ui
        {
            public ulong Value;

            public static explicit operator mpir_ui(ulong value)
            {
                return new mpir_ui() { Value = value };
            }

            public static explicit operator ulong(mpir_ui value)
            {
                return value.Value;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct mp_exp_t
        {
            public int Value;

            public static explicit operator mp_exp_t(int value)
            {
                return new mp_exp_t() { Value = value };
            }

            public static explicit operator int(mp_exp_t value)
            {
                return value.Value;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct intmax_t
        {
            public long Size;

            public static explicit operator intmax_t(long size)
            {
                return new intmax_t() { Size = size };
            }

            public static explicit operator long(intmax_t size)
            {
                return size.Size;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct uintmax_t
        {
            public ulong Size;

            public static explicit operator uintmax_t(ulong size)
            {
                return new uintmax_t() { Size = size };
            }

            public static explicit operator ulong(uintmax_t size)
            {
                return size.Size;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct unsignedlongint
        {
            public ulong Value;

            public static explicit operator unsignedlongint(ulong value)
            {
                return new unsignedlongint() { Value = value };
            }

            public static explicit operator ulong(unsignedlongint value)
            {
                return value.Value;
            }
        }
    }
}
