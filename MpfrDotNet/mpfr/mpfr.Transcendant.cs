namespace MpfrDotNet
{
    using MpirDotNet;

    public static partial class mpfr
    {
        #region Log
        public static int log(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_log(ref rop.Value, ref op.Value, rnd);
        }

        public static int log_ui(mpfr_t rop, uint op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_log_ui(ref rop.Value, op, rnd);
        }

        public static int log2(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_log2(ref rop.Value, ref op.Value, rnd);
        }

        public static int log10(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_log10(ref rop.Value, ref op.Value, rnd);
        }

        public static int log1p(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_log1p(ref rop.Value, ref op.Value, rnd);
        }
        #endregion

        #region Exp
        public static int exp(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_exp(ref rop.Value, ref op.Value, rnd);
        }

        public static int exp2(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_exp2(ref rop.Value, ref op.Value, rnd);
        }

        public static int exp10(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_exp10(ref rop.Value, ref op.Value, rnd);
        }

        public static int expm1(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_expm1(ref rop.Value, ref op.Value, rnd);
        }
        #endregion

        #region Pow
        public static int pow(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_pow(ref rop.Value, ref op1.Value, ref op2.Value, rnd);
        }

        public static int pow_ui(mpfr_t rop, mpfr_t op1, ulong op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_pow_ui(ref rop.Value, ref op1.Value, op2, rnd);
        }

        public static int pow_si(mpfr_t rop, mpfr_t op1, long op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_pow_si(ref rop.Value, ref op1.Value, op2, rnd);
        }

        public static int pow_z(mpfr_t rop, mpfr_t op1, mpz_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_pow_z(ref rop.Value, ref op1.Value, ref op2.Value, rnd);
        }

        public static int ui_pow_ui(mpfr_t rop, ulong op1, ulong op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_ui_pow_ui(ref rop.Value, op1, op2, rnd);
        }

        public static int ui_pow(mpfr_t rop, ulong op1, mpfr_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_ui_pow(ref rop.Value, op1, ref op2.Value, rnd);
        }
        #endregion

        #region Trigonometric
        public static int cos(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_cos(ref rop.Value, ref op.Value, rnd);
        }

        public static int sin(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_sin(ref rop.Value, ref op.Value, rnd);
        }

        public static int tan(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_tan(ref rop.Value, ref op.Value, rnd);
        }

        public static int sin_cos(mpfr_t sop, mpfr_t cop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_sin_cos(ref sop.Value, ref cop.Value, ref op.Value, rnd);
        }

        public static int sec(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_sec(ref rop.Value, ref op.Value, rnd);
        }

        public static int csc(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_csc(ref rop.Value, ref op.Value, rnd);
        }

        public static int cot(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_cot(ref rop.Value, ref op.Value, rnd);
        }

        public static int acos(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_acos(ref rop.Value, ref op.Value, rnd);
        }

        public static int asin(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_asin(ref rop.Value, ref op.Value, rnd);
        }

        public static int atan(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_atan(ref rop.Value, ref op.Value, rnd);
        }

        public static int atan2(mpfr_t rop, mpfr_t x, mpfr_t y, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_atan2(ref rop.Value, ref x.Value, ref y.Value, rnd);
        }

        public static int cosh(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_cosh(ref rop.Value, ref op.Value, rnd);
        }

        public static int sinh(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_sinh(ref rop.Value, ref op.Value, rnd);
        }

        public static int tanh(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_tanh(ref rop.Value, ref op.Value, rnd);
        }

        public static int sinh_cosh(mpfr_t sop, mpfr_t cop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_sinh_cosh(ref sop.Value, ref cop.Value, ref op.Value, rnd);
        }

        public static int sech(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_sech(ref rop.Value, ref op.Value, rnd);
        }

        public static int csch(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_csch(ref rop.Value, ref op.Value, rnd);
        }

        public static int coth(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_coth(ref rop.Value, ref op.Value, rnd);
        }

        public static int acosh(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_acosh(ref rop.Value, ref op.Value, rnd);
        }

        public static int asinh(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_asinh(ref rop.Value, ref op.Value, rnd);
        }

        public static int atanh(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_atanh(ref rop.Value, ref op.Value, rnd);
        }
        #endregion

        #region Other
        public static int eint(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_eint(ref rop.Value, ref op.Value, rnd);
        }

        public static int li2(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_li2(ref rop.Value, ref op.Value, rnd);
        }

        public static int gamma(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_gamma(ref rop.Value, ref op.Value, rnd);
        }

        public static int gamma_inc(mpfr_t rop, mpfr_t op, mpfr_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_gamma_inc(ref rop.Value, ref op.Value, ref op2.Value, rnd);
        }

        public static int lngamma(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_lngamma(ref rop.Value, ref op.Value, rnd);
        }

        public static int lgamma(mpfr_t rop, out int sign, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_lgamma(ref rop.Value, out sign, ref op.Value, rnd);
        }

        public static int digamma(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_digamma(ref rop.Value, ref op.Value, rnd);
        }

        public static int beta(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_beta(ref rop.Value, ref op1.Value, ref op2.Value, rnd);
        }

        public static int zeta(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_zeta(ref rop.Value, ref op.Value, rnd);
        }

        public static int zeta_ui(mpfr_t rop, ulong op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_zeta_ui(ref rop.Value, op, rnd);
        }

        public static int erf(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_erf(ref rop.Value, ref op.Value, rnd);
        }

        public static int erfc(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_erfc(ref rop.Value, ref op.Value, rnd);
        }

        public static int j0(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_j0(ref rop.Value, ref op.Value, rnd);
        }

        public static int j1(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_j1(ref rop.Value, ref op.Value, rnd);
        }

        public static int jn(mpfr_t rop, long n, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_jn(ref rop.Value, n, ref op.Value, rnd);
        }

        public static int y0(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_y0(ref rop.Value, ref op.Value, rnd);
        }

        public static int y1(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_y1(ref rop.Value, ref op.Value, rnd);
        }

        public static int yn(mpfr_t rop, long n, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_yn(ref rop.Value, n, ref op.Value, rnd);
        }

        public static int agm(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_agm(ref rop.Value, ref op1.Value, ref op2.Value, rnd);
        }

        public static int ai(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_ai(ref rop.Value, ref op.Value, rnd);
        }

        public static int const_log2(mpfr_t rop, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_const_log2(ref rop.Value, rnd);
        }

        public static int const_pi(mpfr_t rop, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_const_pi(ref rop.Value, rnd);
        }

        public static int const_euler(mpfr_t rop, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_const_euler(ref rop.Value, rnd);
        }

        public static int const_catalan(mpfr_t rop, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_const_catalan(ref rop.Value, rnd);
        }
        #endregion
    }
}
