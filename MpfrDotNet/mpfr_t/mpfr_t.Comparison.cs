namespace MpfrDotNet
{
    using MpirDotNet;
    using System;
    using static NativeMethods;

    public partial class mpfr_t : IDisposable
    {
        public int CompareTo(mpfr_t other)
        {
            return mpfr_cmp(ref Value, ref other.Value);
        }

        public int CompareTo(ulong other)
        {
            return mpfr_cmp_ui(ref Value, other);
        }

        public int CompareTo(long other)
        {
            return mpfr_cmp_si(ref Value, other);
        }

        public int CompareTo(double other)
        {
            return mpfr_cmp_d(ref Value, other);
        }

        public int CompareTo(mpz_t other)
        {
            return mpfr_cmp_z(ref Value, ref other.Value);
        }

        public int CompareTo(mpq_t other)
        {
            return mpfr_cmp_q(ref Value, ref other.Value);
        }

        public int CompareTo(mpf_t other)
        {
            return mpfr_cmp_f(ref Value, ref other.Value);
        }

        public bool IsNan { get { return mpfr_nan_p(ref Value) != 0; } }
        public bool IsInf { get { return mpfr_inf_p(ref Value) != 0; } }
        public bool IsNumber { get { return mpfr_number_p(ref Value) != 0; } }
        public bool IsZero { get { return mpfr_zero_p(ref Value) != 0; } }
        public bool IsRegular { get { return mpfr_regular_p(ref Value) != 0; } }
        public int Sign { get { return mpfr_sgn(ref Value); } }

        public override bool Equals(object? obj)
        {
            if (obj is mpfr_t other)
                return mpfr_equal_p(ref Value, ref other.Value) == 0;
            else
                return false;
        }

        public override int GetHashCode()
        {
            double d = mpfr_get_d(ref Value, DefaultRounding);
            return d.GetHashCode();
        }
    }
}
