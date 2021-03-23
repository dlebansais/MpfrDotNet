namespace MpfrDotNet
{
    using Interop.Mpfr;
    using MpirDotNet;
    using NativeMethods = Interop.Mpfr.NativeMethods;

    public static partial class mpfr
    {
        public static int cmp(mpfr_t op1, mpfr_t op2)
        {
            return NativeMethods.mpfr_cmp(ref op1.Value, ref op2.Value);
        }

        public static int cmp_ui(mpfr_t op1, ulong op2)
        {
            return NativeMethods.mpfr_cmp_ui(ref op1.Value, op2);
        }

        public static int cmp_si(mpfr_t op1, long op2)
        {
            return NativeMethods.mpfr_cmp_si(ref op1.Value, op2);
        }

        public static int cmp_d(mpfr_t op1, double op2)
        {
            return NativeMethods.mpfr_cmp_d(ref op1.Value, op2);
        }

        public static int cmp_z(mpfr_t op1, mpz_t op2)
        {
            return NativeMethods.mpfr_cmp_z(ref op1.Value, ref op2.Value);
        }

        public static int cmp_q(mpfr_t op1, mpq_t op2)
        {
            return NativeMethods.mpfr_cmp_q(ref op1.Value, ref op2.Value);
        }

        public static int cmp_f(mpfr_t op1, mpf_t op2)
        {
            return NativeMethods.mpfr_cmp_f(ref op1.Value, ref op2.Value);
        }

        public static int cmp_ui_2exp(mpfr_t op1, ulong op2, int e)
        {
            return NativeMethods.mpfr_cmp_ui_2exp(ref op1.Value, op2, e);
        }

        public static int cmp_si_2exp(mpfr_t op1, long op2, int e)
        {
            return NativeMethods.mpfr_cmp_si_2exp(ref op1.Value, op2, e);
        }

        public static int cmpabs(mpfr_t op1, mpfr_t op2)
        {
            return NativeMethods.mpfr_cmpabs(ref op1.Value, ref op2.Value);
        }

        public static bool nan_p(mpfr_t op)
        {
            return NativeMethods.mpfr_nan_p(ref op.Value) != 0;
        }

        public static bool inf_p(mpfr_t op)
        {
            return NativeMethods.mpfr_inf_p(ref op.Value) != 0;
        }

        public static bool number_p(mpfr_t op)
        {
            return NativeMethods.mpfr_number_p(ref op.Value) != 0;
        }

        public static bool zero_p(mpfr_t op)
        {
            return NativeMethods.mpfr_zero_p(ref op.Value) != 0;
        }

        public static bool regular_p(mpfr_t op)
        {
            return NativeMethods.mpfr_regular_p(ref op.Value) != 0;
        }

        public static int sgn(mpfr_t op)
        {
            return NativeMethods.mpfr_sgn(ref op.Value);
        }

        public static bool greater_p(mpfr_t op1, mpfr_t op2)
        {
            return NativeMethods.mpfr_greater_p(ref op1.Value, ref op2.Value) != 0;
        }

        public static bool greaterequal_p(mpfr_t op1, mpfr_t op2)
        {
            return NativeMethods.mpfr_greaterequal_p(ref op1.Value, ref op2.Value) != 0;
        }

        public static bool less_p(mpfr_t op1, mpfr_t op2)
        {
            return NativeMethods.mpfr_less_p(ref op1.Value, ref op2.Value) != 0;
        }

        public static bool lessequal_p(mpfr_t op1, mpfr_t op2)
        {
            return NativeMethods.mpfr_lessequal_p(ref op1.Value, ref op2.Value) != 0;
        }

        public static bool equal_p(mpfr_t op1, mpfr_t op2)
        {
            return NativeMethods.mpfr_equal_p(ref op1.Value, ref op2.Value) != 0;
        }

        public static bool lessgreater_p(mpfr_t op1, mpfr_t op2)
        {
            return NativeMethods.mpfr_lessgreater_p(ref op1.Value, ref op2.Value) != 0;
        }

        public static bool unordered_p(mpfr_t op1, mpfr_t op2)
        {
            return NativeMethods.mpfr_unordered_p(ref op1.Value, ref op2.Value) != 0;
        }

        public static int total_order(mpfr_t x, mpfr_t y)
        {
            return NativeMethods.mpfr_total_order(ref x.Value, ref y.Value);
        }

        public static bool eq(mpfr_t op1, mpfr_t op2, ulong op3)
        {
            return NativeMethods.mpfr_eq(ref op1.Value, ref op2.Value, op3) != 0;
        }

        public static void reldiff(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
        {
            NativeMethods.mpfr_reldiff(ref rop.Value, ref op1.Value, ref op2.Value, rnd);
        }
    }
}
