namespace MpfrDotNet
{
    using System;
    using MpirDotNet;

    public static partial class mpfr
    {
        #region Add
        public static int add(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_add(ref rop.Value, ref op1.Value, ref op2.Value, rnd);
        }

        public static int add_ui(mpfr_t rop, mpfr_t op1, ulong op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_add_ui(ref rop.Value, ref op1.Value, op2, rnd);
        }

        public static int add_si(mpfr_t rop, mpfr_t op1, long op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_add_si(ref rop.Value, ref op1.Value, op2, rnd);
        }

        public static int add_d(mpfr_t rop, mpfr_t op1, double op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_add_d(ref rop.Value, ref op1.Value, op2, rnd);
        }

        public static int add_z(mpfr_t rop, mpfr_t op1, mpz_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_add_z(ref rop.Value, ref op1.Value, ref op2.Value, rnd);
        }

        public static int add_q(mpfr_t rop, mpfr_t op1, mpq_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_add_q(ref rop.Value, ref op1.Value, ref op2.Value, rnd);
        }
        #endregion

        #region Sub
        public static int sub(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_sub(ref rop.Value, ref op1.Value, ref op2.Value, rnd);
        }

        public static int ui_sub(mpfr_t rop, ulong op1, mpfr_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_ui_sub(ref rop.Value, op1, ref op2.Value, rnd);
        }

        public static int sub_ui(mpfr_t rop, mpfr_t op1, ulong op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_sub_ui(ref rop.Value, ref op1.Value, op2, rnd);
        }

        public static int si_sub(mpfr_t rop, long op1, mpfr_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_si_sub(ref rop.Value, op1, ref op2.Value, rnd);
        }

        public static int sub_si(mpfr_t rop, mpfr_t op1, long op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_sub_si(ref rop.Value, ref op1.Value, op2, rnd);
        }

        public static int d_sub(mpfr_t rop, double op1, mpfr_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_d_sub(ref rop.Value, op1, ref op2.Value, rnd);
        }

        public static int sub_d(mpfr_t rop, mpfr_t op1, double op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_sub_d(ref rop.Value, ref op1.Value, op2, rnd);
        }

        public static int z_sub(mpfr_t rop, mpz_t op1, mpfr_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_z_sub(ref rop.Value, ref op1.Value, ref op2.Value, rnd);
        }

        public static int sub_z(mpfr_t rop, mpfr_t op1, mpz_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_sub_z(ref rop.Value, ref op1.Value, ref op2.Value, rnd);
        }

        public static int sub_q(mpfr_t rop, mpfr_t op1, mpq_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_sub_q(ref rop.Value, ref op1.Value, ref op2.Value, rnd);
        }
        #endregion

        #region Mul
        public static int mul(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_mul(ref rop.Value, ref op1.Value, ref op2.Value, rnd);
        }

        public static int mul_ui(mpfr_t rop, mpfr_t op1, ulong op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_mul_ui(ref rop.Value, ref op1.Value, op2, rnd);
        }

        public static int mul_2ui(mpfr_t rop, mpfr_t op1, ulong op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_mul_2ui(ref rop.Value, ref op1.Value, op2, rnd);
        }

        public static int mul_2si(mpfr_t rop, mpfr_t op1, long op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_mul_2si(ref rop.Value, ref op1.Value, op2, rnd);
        }

        public static int mul_si(mpfr_t rop, mpfr_t op1, long op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_mul_si(ref rop.Value, ref op1.Value, op2, rnd);
        }

        public static int mul_d(mpfr_t rop, mpfr_t op1, double op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_mul_d(ref rop.Value, ref op1.Value, op2, rnd);
        }

        public static int mul_z(mpfr_t rop, mpfr_t op1, mpz_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_mul_z(ref rop.Value, ref op1.Value, ref op2.Value, rnd);
        }

        public static int mul_q(mpfr_t rop, mpfr_t op1, mpq_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_mul_q(ref rop.Value, ref op1.Value, ref op2.Value, rnd);
        }
        #endregion

        #region Div
        public static int div(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_div(ref rop.Value, ref op1.Value, ref op2.Value, rnd);
        }

        public static int ui_div(mpfr_t rop, ulong op1, mpfr_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_ui_div(ref rop.Value, op1, ref op2.Value, rnd);
        }

        public static int div_ui(mpfr_t rop, mpfr_t op1, ulong op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_div_ui(ref rop.Value, ref op1.Value, op2, rnd);
        }

        public static int div_2ui(mpfr_t rop, mpfr_t op1, ulong op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_div_2ui(ref rop.Value, ref op1.Value, op2, rnd);
        }

        public static int div_2si(mpfr_t rop, mpfr_t op1, long op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_div_2si(ref rop.Value, ref op1.Value, op2, rnd);
        }

        public static int si_div(mpfr_t rop, long op1, mpfr_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_si_div(ref rop.Value, op1, ref op2.Value, rnd);
        }

        public static int div_si(mpfr_t rop, mpfr_t op1, long op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_div_si(ref rop.Value, ref op1.Value, op2, rnd);
        }

        public static int d_div(mpfr_t rop, double op1, mpfr_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_d_div(ref rop.Value, op1, ref op2.Value, rnd);
        }

        public static int div_d(mpfr_t rop, mpfr_t op1, double op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_div_d(ref rop.Value, ref op1.Value, op2, rnd);
        }

        public static int div_z(mpfr_t rop, mpfr_t op1, mpz_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_div_z(ref rop.Value, ref op1.Value, ref op2.Value, rnd);
        }

        public static int div_q(mpfr_t rop, mpfr_t op1, mpq_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_div_q(ref rop.Value, ref op1.Value, ref op2.Value, rnd);
        }
        #endregion

        #region Pow
        public static int sqr(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_sqr(ref rop.Value, ref op.Value, rnd);
        }

        public static int sqrt(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_sqrt(ref rop.Value, ref op.Value, rnd);
        }

        public static int sqrt_ui(mpfr_t rop, ulong op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_sqrt_ui(ref rop.Value, op, rnd);
        }

        public static int rec_sqrt(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_rec_sqrt(ref rop.Value, ref op.Value, rnd);
        }

        public static int cbrt(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_cbrt(ref rop.Value, ref op.Value, rnd);
        }

        public static int rootn_ui(mpfr_t rop, mpfr_t op, ulong n, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_rootn_ui(ref rop.Value, ref op.Value, n, rnd);
        }
        #endregion

        #region Misc
        public static int neg(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_neg(ref rop.Value, ref op.Value, rnd);
        }

        public static int abs(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_abs(ref rop.Value, ref op.Value, rnd);
        }

        public static int dim(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_dim(ref rop.Value, ref op1.Value, ref op2.Value, rnd);
        }

        public static int fac_ui(mpfr_t rop, ulong op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_fac_ui(ref rop.Value, op, rnd);
        }

        public static int fma(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_t op3, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_fma(ref rop.Value, ref op1.Value, ref op2.Value, ref op3.Value, rnd);
        }

        public static int fms(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_t op3, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_fms(ref rop.Value, ref op1.Value, ref op2.Value, ref op3.Value, rnd);
        }

        public static int fmma(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_t op3, mpfr_t op4, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_fmma(ref rop.Value, ref op1.Value, ref op2.Value, ref op3.Value, ref op4.Value, rnd);
        }

        public static int fmms(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_t op3, mpfr_t op4, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_fmms(ref rop.Value, ref op1.Value, ref op2.Value, ref op3.Value, ref op4.Value, rnd);
        }

        public static int hypot(mpfr_t rop, mpfr_t x, mpfr_t y, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_hypot(ref rop.Value, ref x.Value, ref y.Value, rnd);
        }

        public static int sum(mpfr_t rop, mpfr_t[] tab, mpfr_rnd_t rnd)
        {
            throw new NotImplementedException();
        }

        public static int dot(mpfr_t rop, mpfr_t[] tab, mpfr_t[] b, mpfr_rnd_t rnd)
        {
            throw new NotImplementedException();
        }

        public static int mul_2exp(mpfr_t rop, mpfr_t op1, ulong op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_mul_2exp(ref rop.Value, ref op1.Value, op2, rnd);
        }

        public static int div_2exp(mpfr_t rop, mpfr_t op1, ulong op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_div_2exp(ref rop.Value, ref op1.Value, op2, rnd);
        }
        #endregion
    }
}
