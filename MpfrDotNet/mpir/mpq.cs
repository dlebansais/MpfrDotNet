﻿namespace MpirDotNet
{
    using System;
    using System.Text;
    using Interop.Mpir;

    public static class mpq
    {
        #region Initialization Functions
        public static void init(mpq_t dest_rational)
        {
            NativeMethods.mpq_init(ref dest_rational.Value);
        }

        public static void inits(params mpq_t[] rationals)
        {
            throw new NotImplementedException();
        }

        public static void clear(mpq_t rational_number)
        {
            NativeMethods.mpq_clear(ref rational_number.Value);
        }

        public static void clears(params mpq_t[] rationals)
        {
            throw new NotImplementedException();
        }

        public static void set(mpq_t rop, mpq_t op)
        {
            NativeMethods.mpq_set(ref rop.Value, ref op.Value);
        }

        public static void set_z(mpq_t rop, mpz_t op)
        {
            NativeMethods.mpq_set_z(ref rop.Value, ref op.Value);
        }

        public static void set_ui(mpq_t rop, ulong op1, ulong op2)
        {
            NativeMethods.mpq_set_ui(ref rop.Value, (NativeMethods.mpir_ui)op1, (NativeMethods.mpir_ui)op2);
        }

        public static void set_si(mpq_t rop, long op1, ulong op2)
        {
            NativeMethods.mpq_set_si(ref rop.Value, (NativeMethods.mpir_si)op1, (NativeMethods.mpir_ui)op2);
        }

        public static bool set_str(mpq_t rop, string str, int strBase)
        {
            return NativeMethods.mpq_set_str(ref rop.Value, str, strBase) == 0;
        }

        public static void swap(mpq_t rop1, mpq_t rop2)
        {
            NativeMethods.mpq_swap(ref rop1.Value, ref rop2.Value);
        }
        #endregion

        #region Conversion Functions
        public static double get_d(mpq_t op)
        {
            return NativeMethods.mpq_get_d(ref op.Value);
        }

        public static void set_d(mpq_t rop, double op)
        {
            NativeMethods.mpq_set_d(ref rop.Value, op);
        }

        public static void set_f(mpq_t rop, mpf_t op)
        {
            NativeMethods.mpq_set_f(ref rop.Value, ref op.Value);
        }

        public static void get_str(StringBuilder str, int strBase, mpq_t op)
        {
            NativeMethods.mpq_get_str(str, strBase, ref op.Value);
        }
        #endregion

        #region Arithmetic Functions
        public static void add(mpq_t rop, mpq_t op1, mpq_t op2)
        {
            NativeMethods.mpq_add(ref rop.Value, ref op1.Value, ref op2.Value);
        }

        public static void sub(mpq_t rop, mpq_t op1, mpq_t op2)
        {
            NativeMethods.mpq_sub(ref rop.Value, ref op1.Value, ref op2.Value);
        }

        public static void mul(mpq_t rop, mpq_t op1, mpq_t op2)
        {
            NativeMethods.mpq_mul(ref rop.Value, ref op1.Value, ref op2.Value);
        }

        public static void mul_2exp(mpq_t rop, mpq_t op1, ulong op2)
        {
            NativeMethods.mpq_mul_2exp(ref rop.Value, ref op1.Value, (NativeMethods.mp_bitcnt_t)op2);
        }

        public static void div(mpq_t rop, mpq_t op1, mpq_t op2)
        {
            NativeMethods.mpq_div(ref rop.Value, ref op1.Value, ref op2.Value);
        }

        public static void div_2exp(mpq_t rop, mpq_t op1, ulong op2)
        {
            NativeMethods.mpq_div_2exp(ref rop.Value, ref op1.Value, (NativeMethods.mp_bitcnt_t)op2);
        }

        public static void neg(mpq_t rop, mpq_t op)
        {
            NativeMethods.mpq_neg(ref rop.Value, ref op.Value);
        }

        public static void abs(mpq_t rop, mpq_t op)
        {
            NativeMethods.mpq_abs(ref rop.Value, ref op.Value);
        }

        public static void inv(mpq_t rop, mpq_t op)
        {
            NativeMethods.mpq_inv(ref rop.Value, ref op.Value);
        }
        #endregion

        #region Comparison Functions
        public static int cmp(mpq_t op1, mpq_t op2)
        {
            return NativeMethods.mpq_cmp(ref op1.Value, ref op2.Value);
        }

        public static int cmp_z(mpq_t op1, mpz_t op2)
        {
            return NativeMethods.mpq_cmp_z(ref op1.Value, ref op2.Value);
        }

        public static int cmp_ui(mpq_t op1, ulong num2, ulong den2)
        {
            return NativeMethods.mpq_cmp_ui(ref op1.Value, (NativeMethods.mpir_ui)num2, (NativeMethods.mpir_ui)den2);
        }

        public static int cmp_si(mpq_t op1, long num2, ulong den2)
        {
            return NativeMethods.mpq_cmp_si(ref op1.Value, (NativeMethods.mpir_si)num2, (NativeMethods.mpir_ui)den2);
        }

        public static int sgn(mpq_t op)
        {
            return NativeMethods.mpq_sgn(ref op.Value);
        }

        public static bool equal(mpq_t op1, mpq_t op2)
        {
            return NativeMethods.mpq_equal(ref op1.Value, ref op2.Value) != 0;
        }
        #endregion

        #region Applying Integer Functions to Rationals
        public static void get_num(mpz_t numerator, mpq_t rational)
        {
            NativeMethods.mpq_get_num(ref numerator.Value, ref rational.Value);
        }

        public static void get_den(mpz_t denominator, mpq_t rational)
        {
            NativeMethods.mpq_get_den(ref denominator.Value, ref rational.Value);
        }

        public static void set_num(mpq_t rational, mpz_t numerator)
        {
            NativeMethods.mpq_set_num(ref rational.Value, ref numerator.Value);
        }

        public static void set_den(mpq_t rational, mpz_t denominator)
        {
            NativeMethods.mpq_set_den(ref rational.Value, ref denominator.Value);
        }
        #endregion
    }
}
