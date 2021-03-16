namespace MpirDotNet
{
    using System.Text;

    public static class mpf
    {
        #region Initialization Functions
        public static void set_default_prec(ulong prec)
        {
            NativeMethods.mpf_set_default_prec(prec);
        }

        public static ulong get_default_prec()
        {
            return NativeMethods.mpf_get_default_prec();
        }

        public static void init(mpf_t x)
        {
            NativeMethods.mpf_init(ref x.Value);
        }

        public static void init2(mpf_t x, ulong prec)
        {
            NativeMethods.mpf_init2(ref x.Value, prec);
        }

        public static void inits(params mpf_t[] floatings)
        {
            //TODO
            throw new System.NotImplementedException();
        }

        public static void clear(mpf_t x)
        {
            NativeMethods.mpf_clear(ref x.Value);
        }

        public static void clears(params mpf_t[] floatings)
        {
            //TODO
            throw new System.NotImplementedException();
        }

        public static ulong get_prec(mpf_t op)
        {
            return NativeMethods.mpf_get_prec(ref op.Value);
        }

        public static void set_prec(mpf_t op, ulong prec)
        {
            NativeMethods.mpf_set_prec(ref op.Value, prec);
        }

        public static void set_prec_raw(mpf_t op, ulong prec)
        {
            NativeMethods.mpf_set_prec_raw(ref op.Value, prec);
        }
        #endregion

        #region Assignment Functions
        public static void set(mpf_t rop, mpf_t op)
        {
            NativeMethods.mpf_set(ref rop.Value, ref op.Value);
        }

        public static void set_ui(mpf_t rop, uint op)
        {
            NativeMethods.mpf_set_ui(ref rop.Value, op);
        }

        public static void set_si(mpf_t rop, int op)
        {
            NativeMethods.mpf_set_si(ref rop.Value, op);
        }

        public static void set_d(mpf_t rop, double op)
        {
            NativeMethods.mpf_set_d(ref rop.Value, op);
        }

        public static void set_z(mpf_t rop, mpz_t op)
        {
            NativeMethods.mpf_set_z(ref rop.Value, ref op.Value);
        }

        public static void set_q(mpf_t rop, mpq_t op)
        {
            NativeMethods.mpf_set_q(ref rop.Value, ref op.Value);
        }

        public static int set_str(mpf_t rop, string str, uint strbase)
        {
            return NativeMethods.mpf_set_str(ref rop.Value, str, strbase);
        }

        public static void swap(mpf_t rop1, mpf_t rop2)
        {
            NativeMethods.mpf_swap(ref rop1.Value, ref rop2.Value);
        }
        #endregion

        #region Combined Initialization and Assignment Functions
        public static void init_set(mpf_t rop, mpf_t op)
        {
            NativeMethods.mpf_init_set(ref rop.Value, ref op.Value);
        }

        public static void init_set_ui(mpf_t rop, uint op)
        {
            NativeMethods.mpf_init_set_ui(ref rop.Value, op);
        }

        public static void init_set_si(mpf_t rop, int op)
        {
            NativeMethods.mpf_init_set_si(ref rop.Value, op);
        }

        public static void init_set_d(mpf_t rop, double op)
        {
            NativeMethods.mpf_init_set_d(ref rop.Value, op);
        }

        public static int init_set_str(mpf_t rop, string str, uint strbase)
        {
            return NativeMethods.mpf_init_set_str(ref rop.Value, str, strbase);
        }
        #endregion

        #region Conversion Functions
        public static double get_d(mpf_t op)
        {
            return NativeMethods.mpf_get_d(ref op.Value);
        }

        public static void get_d_2exp(mpf_t op, out double d, out int exp)
        {
            d = NativeMethods.mpf_get_d_2exp(out exp, ref op.Value);
        }

        public static ulong get_ui(mpf_t op)
        {
            return NativeMethods.mpf_get_ui(ref op.Value);
        }

        public static long get_si(mpf_t op)
        {
            return NativeMethods.mpf_get_si(ref op.Value);
        }

        public static void get_str(StringBuilder str, out int expptr, int _base, ulong n_digits, mpf_t op)
        {
            NativeMethods.mpf_get_str(str, out expptr, _base, n_digits, ref op.Value);
        }
        #endregion

        #region Arithmetic Functions
        public static void add(mpf_t rop, mpf_t op1, mpf_t op2)
        {
            NativeMethods.mpf_add(ref rop.Value, ref op1.Value, ref op2.Value);
        }

        public static void add_ui(mpf_t rop, mpf_t op1, uint op2)
        {
            NativeMethods.mpf_add_ui(ref rop.Value, ref op1.Value, op2);
        }

        public static void sub(mpf_t rop, mpf_t op1, mpf_t op2)
        {
            NativeMethods.mpf_sub(ref rop.Value, ref op1.Value, ref op2.Value);
        }

        public static void ui_sub(mpf_t rop, uint op1, mpf_t op2)
        {
            NativeMethods.mpf_ui_sub(ref rop.Value, op1, ref op2.Value);
        }

        public static void sub_ui(mpf_t rop, mpf_t op1, uint op2)
        {
            NativeMethods.mpf_sub_ui(ref rop.Value, ref op1.Value, op2);
        }

        public static void mul(mpf_t rop, mpf_t op1, mpf_t op2)
        {
            NativeMethods.mpf_mul(ref rop.Value, ref op1.Value, ref op2.Value);
        }

        public static void mul_ui(mpf_t rop, mpf_t op1, uint op2)
        {
            NativeMethods.mpf_mul_ui(ref rop.Value, ref op1.Value, op2);
        }

        public static void div(mpf_t rop, mpf_t op1, mpf_t op2)
        {
            NativeMethods.mpf_div(ref rop.Value, ref op1.Value, ref op2.Value);
        }

        public static void ui_div(mpf_t rop, uint op1, mpf_t op2)
        {
            NativeMethods.mpf_ui_div(ref rop.Value, op1, ref op2.Value);
        }

        public static void div_ui(mpf_t rop, mpf_t op1, uint op2)
        {
            NativeMethods.mpf_div_ui(ref rop.Value, ref op1.Value, op2);
        }

        public static void sqrt(mpf_t rop, mpf_t op)
        {
            NativeMethods.mpf_sqrt(ref rop.Value, ref op.Value);
        }

        public static void sqrt_ui(mpf_t rop, uint op)
        {
            NativeMethods.mpf_sqrt_ui(ref rop.Value, op);
        }

        public static void pow_ui(mpf_t rop, mpf_t op1, uint op2)
        {
            NativeMethods.mpf_pow_ui(ref rop.Value, ref op1.Value, op2);
        }

        public static void neg(mpf_t rop, mpf_t op)
        {
            NativeMethods.mpf_neg(ref rop.Value, ref op.Value);
        }

        public static void abs(mpf_t rop, mpf_t op)
        {
            NativeMethods.mpf_abs(ref rop.Value, ref op.Value);
        }

        public static void mul_2exp(mpf_t rop, mpf_t op1, ulong op2)
        {
            NativeMethods.mpf_mul_2exp(ref rop.Value, ref op1.Value, op2);
        }

        public static void div_2exp(mpf_t rop, mpf_t op1, ulong op2)
        {
            NativeMethods.mpf_div_2exp(ref rop.Value, ref op1.Value, op2);
        }
        #endregion

        #region Conversion Functions
        public static int cmp(mpf_t op1, mpf_t op2)
        {
            return NativeMethods.mpf_cmp(ref op1.Value, ref op2.Value);
        }

        public static int cmp_d(mpf_t op1, double op2)
        {
            return NativeMethods.mpf_cmp_d(ref op1.Value, op2);
        }

        public static int cmp_si(mpf_t op1, int op2)
        {
            return NativeMethods.mpf_cmp_si(ref op1.Value, op2);
        }

        public static int cmp_ui(mpf_t op1, uint op2)
        {
            return NativeMethods.mpf_cmp_ui(ref op1.Value, op2);
        }

        public static int eq(mpf_t op1, mpf_t op2, ulong op3)
        {
            return NativeMethods.mpf_eq(ref op1.Value, ref op2.Value, op3);
        }

        public static void reldiff(mpf_t rop, mpf_t op1, mpf_t op2)
        {
            NativeMethods.mpf_reldiff(ref rop.Value, ref op1.Value, ref op2.Value);
        }

        public static int sgn(mpf_t op)
        {
            return NativeMethods.mpf_sgn(ref op.Value);
        }
        #endregion

        #region Miscellaneous Functions
        public static void ceil(mpf_t rop, mpf_t op)
        {
            NativeMethods.mpf_ceil(ref rop.Value, ref op.Value);
        }

        public static void floor(mpf_t rop, mpf_t op)
        {
            NativeMethods.mpf_floor(ref rop.Value, ref op.Value);
        }

        public static void trunc(mpf_t rop, mpf_t op)
        {
            NativeMethods.mpf_trunc(ref rop.Value, ref op.Value);
        }

        public static bool integer_p(mpf_t op)
        {
            return NativeMethods.mpf_integer_p(ref op.Value) != 0;
        }

        public static bool fits_ulong_p(mpf_t op)
        {
            return NativeMethods.mpf_fits_ulong_p(ref op.Value) != 0;
        }

        public static bool fits_slong_p(mpf_t op)
        {
            return NativeMethods.mpf_fits_slong_p(ref op.Value) != 0;
        }

        public static bool fits_uint_p(mpf_t op)
        {
            return NativeMethods.mpf_fits_uint_p(ref op.Value) != 0;
        }

        public static bool fits_sint_p(mpf_t op)
        {
            return NativeMethods.mpf_fits_sint_p(ref op.Value) != 0;
        }

        public static bool fits_ushort_p(mpf_t op)
        {
            return NativeMethods.mpf_fits_ushort_p(ref op.Value) != 0;
        }

        public static bool fits_sshort_p(mpf_t op)
        {
            return NativeMethods.mpf_fits_sshort_p(ref op.Value) != 0;
        }

        public static void urandomb(mpf_t rop, randstate_t state, ulong nbits)
        {
            NativeMethods.mpf_urandomb(ref rop.Value, ref state.Value, nbits);
        }

        public static void rrandomb(mpf_t rop, randstate_t state, ulong max_size, ulong exp)
        {
            NativeMethods.mpf_rrandomb(ref rop.Value, ref state.Value, max_size, exp);
        }
        #endregion
    }
}
