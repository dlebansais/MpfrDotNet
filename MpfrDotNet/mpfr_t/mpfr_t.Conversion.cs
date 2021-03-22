namespace MpfrDotNet
{
    using System;
    using System.Numerics;
    using MpirDotNet;
    using static NativeMethods;

    public partial class mpfr_t : IDisposable
    {
        public static implicit operator mpfr_t(byte value)
        {
            return new mpfr_t((uint)value);
        }

        public static implicit operator mpfr_t(int value)
        {
            return new mpfr_t(value);
        }

        public static implicit operator mpfr_t(uint value)
        {
            return new mpfr_t(value);
        }

        public static implicit operator mpfr_t(short value)
        {
            return new mpfr_t(value);
        }

        public static implicit operator mpfr_t(ushort value)
        {
            return new mpfr_t(value);
        }

        public static implicit operator mpfr_t(long value)
        {
            return new mpfr_t(value);
        }

        public static implicit operator mpfr_t(ulong value)
        {
            return new mpfr_t(value);
        }

        public static implicit operator mpfr_t(float value)
        {
            return new mpfr_t((double)value);
        }

        public static implicit operator mpfr_t(double value)
        {
            return new mpfr_t(value);
        }

        public static implicit operator mpfr_t(BigInteger value)
        {
            using mpz_t Temporary = new mpz_t(value);
            return new mpfr_t(Temporary);
        }

        public static explicit operator byte(mpfr_t value)
        {
            return (byte)(uint)value;
        }

        public static explicit operator int(mpfr_t value)
        {
            return mpfr_get_sj(ref value.Value, value.Rounding);
        }

        public static explicit operator uint(mpfr_t value)
        {
            return mpfr_get_uj(ref value.Value, value.Rounding);
        }

        public static explicit operator short(mpfr_t value)
        {
            return (short)(int)value;
        }

        public static explicit operator ushort(mpfr_t value)
        {
            return (ushort)(uint)value;
        }

        public static explicit operator long(mpfr_t value)
        {
            return mpfr_get_si(ref value.Value, value.Rounding);
        }

        public static explicit operator ulong(mpfr_t value)
        {
            return mpfr_get_ui(ref value.Value, value.Rounding);
        }

        public static explicit operator float(mpfr_t value)
        {
            return mpfr_get_flt(ref value.Value, value.Rounding);
        }

        public static explicit operator double(mpfr_t value)
        {
            return mpfr_get_d(ref value.Value, value.Rounding);
        }

        public static explicit operator BigInteger(mpfr_t value)
        {
            using mpz_t Temporary = new mpz_t();

            mpfr_get_z(ref Temporary.Value, ref value.Value, value.Rounding);

            return (BigInteger)Temporary;
        }
    }
}
