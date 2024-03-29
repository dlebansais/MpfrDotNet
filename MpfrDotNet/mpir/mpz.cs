﻿namespace MpirDotNet;

using System;
using System.IO;
using System.Text;
using Interop.Mpir;

/// <summary>
/// See http://mpir.org/mpir-3.0.0.pdf.
/// </summary>
public static class mpz
{
    #region Initialization Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="integer">The value.</param>
    public static void init(mpz_t integer)
    {
        NativeMethods.mpz_init(ref integer.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="integers">The values.</param>
    public static void inits(params mpz_t[] integers)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="integer">The value.</param>
    /// <param name="n">The number of bits.</param>
    public static void init2(mpz_t integer, ulong n)
    {
        NativeMethods.mpz_init2(ref integer.Value, (NativeMethods.mp_bitcnt_t)n);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="integer">The value.</param>
    public static void clear(mpz_t integer)
    {
        NativeMethods.mpz_clear(ref integer.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="x">The values.</param>
    public static void clears(params mpz_t[] x)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="integer">The value.</param>
    /// <param name="n">The number of bits.</param>
    public static void realloc2(mpz_t integer, ulong n)
    {
        NativeMethods.mpz_realloc2(ref integer.Value, (NativeMethods.mp_bitcnt_t)n);
    }
    #endregion

    #region Assignment Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void set(mpz_t rop, mpz_t op)
    {
        NativeMethods.mpz_set(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void set_ui(mpz_t rop, ulong op)
    {
        NativeMethods.mpz_set_ui(ref rop.Value, (NativeMethods.mpir_ui)op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void set_si(mpz_t rop, long op)
    {
        NativeMethods.mpz_set_si(ref rop.Value, (NativeMethods.mpir_si)op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void set_ux(mpz_t rop, ulong op)
    {
        NativeMethods.mpz_set_ux(ref rop.Value, (NativeMethods.uintmax_t)op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void set_sx(mpz_t rop, long op)
    {
        NativeMethods.mpz_set_sx(ref rop.Value, (NativeMethods.intmax_t)op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void set_d(mpz_t rop, double op)
    {
        NativeMethods.mpz_set_d(ref rop.Value, op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void set_q(mpz_t rop, mpq_t op)
    {
        NativeMethods.mpz_set_q(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void set_f(mpz_t rop, mpf_t op)
    {
        NativeMethods.mpz_set_f(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="str">The string.</param>
    /// <param name="strbase">The base.</param>
    public static int set_str(mpz_t rop, string str, uint strbase)
    {
        return NativeMethods.mpz_set_str(ref rop.Value, str, strbase);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop1">The first result operand.</param>
    /// <param name="rop2">The second result operand.</param>
    public static void swap(mpz_t rop1, mpz_t rop2)
    {
        NativeMethods.mpz_swap(ref rop1.Value, ref rop2.Value);
    }
    #endregion

    #region Combined Initialization and Assignment Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void init_set(mpz_t rop, mpz_t op)
    {
        NativeMethods.mpz_init_set(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void init_set_ui(mpz_t rop, ulong op)
    {
        NativeMethods.mpz_init_set_ui(ref rop.Value, (NativeMethods.mpir_ui)op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void init_set_si(mpz_t rop, long op)
    {
        NativeMethods.mpz_init_set_si(ref rop.Value, (NativeMethods.mpir_si)op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void init_set_ux(mpz_t rop, ulong op)
    {
        NativeMethods.mpz_init_set_ux(ref rop.Value, (NativeMethods.uintmax_t)op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void init_set_sx(mpz_t rop, long op)
    {
        NativeMethods.mpz_init_set_sx(ref rop.Value, (NativeMethods.intmax_t)op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void init_set_d(mpz_t rop, double op)
    {
        NativeMethods.mpz_init_set_d(ref rop.Value, op);
    }
    #endregion

    #region Conversion Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static ulong get_ui(mpz_t op)
    {
        return (ulong)NativeMethods.mpz_get_ui(ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static long get_si(mpz_t op)
    {
        return (long)NativeMethods.mpz_get_si(ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static ulong get_ux(mpz_t op)
    {
        return (ulong)NativeMethods.mpz_get_ux(ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static long get_sx(mpz_t op)
    {
        return (long)NativeMethods.mpz_get_sx(ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static double get_d(mpz_t op)
    {
        return NativeMethods.mpz_get_d(ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="d">The double.</param>
    /// <param name="exp">The exponent.</param>
    public static void get_d_2exp(mpz_t op, out double d, out long exp)
    {
        d = NativeMethods.mpz_get_d_2exp(out NativeMethods.mpir_si expStr, ref op.Value);
        exp = (long)expStr;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="str">The string.</param>
    /// <param name="strBase">The base.</param>
    /// <param name="op">The operand.</param>
    public static void get_str(StringBuilder str, int strBase, mpz_t op)
    {
        NativeMethods.mpz_get_str(str, strBase, ref op.Value);
    }
    #endregion

    #region Arithmetic Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void add(mpz_t rop, mpz_t op1, mpz_t op2)
    {
        NativeMethods.mpz_add(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void add_ui(mpz_t rop, mpz_t op1, ulong op2)
    {
        NativeMethods.mpz_add_ui(ref rop.Value, ref op1.Value, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void sub(mpz_t rop, mpz_t op1, mpz_t op2)
    {
        NativeMethods.mpz_sub(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void sub_ui(mpz_t rop, mpz_t op1, ulong op2)
    {
        NativeMethods.mpz_sub_ui(ref rop.Value, ref op1.Value, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void ui_sub(mpz_t rop, ulong op1, mpz_t op2)
    {
        NativeMethods.mpz_ui_sub(ref rop.Value, (NativeMethods.mpir_ui)op1, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void mul(mpz_t rop, mpz_t op1, mpz_t op2)
    {
        NativeMethods.mpz_mul(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void mul_si(mpz_t rop, mpz_t op1, long op2)
    {
        NativeMethods.mpz_mul_si(ref rop.Value, ref op1.Value, (NativeMethods.mpir_si)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void mul_ui(mpz_t rop, mpz_t op1, ulong op2)
    {
        NativeMethods.mpz_mul_ui(ref rop.Value, ref op1.Value, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void addmul(mpz_t rop, mpz_t op1, mpz_t op2)
    {
        NativeMethods.mpz_addmul(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void addmul_ui(mpz_t rop, mpz_t op1, ulong op2)
    {
        NativeMethods.mpz_addmul_ui(ref rop.Value, ref op1.Value, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void submul(mpz_t rop, mpz_t op1, mpz_t op2)
    {
        NativeMethods.mpz_submul(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void submul_ui(mpz_t rop, mpz_t op1, ulong op2)
    {
        NativeMethods.mpz_submul_ui(ref rop.Value, ref op1.Value, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void mul_2exp(mpz_t rop, mpz_t op1, ulong op2)
    {
        NativeMethods.mpz_mul_2exp(ref rop.Value, ref op1.Value, (NativeMethods.mp_bitcnt_t)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void neg(mpz_t rop, mpz_t op)
    {
        NativeMethods.mpz_neg(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void abs(mpz_t rop, mpz_t op)
    {
        NativeMethods.mpz_abs(ref rop.Value, ref op.Value);
    }
    #endregion

    #region Division Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static void cdiv_q(mpz_t q, mpz_t n, mpz_t d)
    {
        NativeMethods.mpz_cdiv_q(ref q.Value, ref n.Value, ref d.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static void cdiv_r(mpz_t r, mpz_t n, mpz_t d)
    {
        NativeMethods.mpz_cdiv_r(ref r.Value, ref n.Value, ref d.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static void cdiv_qr(mpz_t q, mpz_t r, mpz_t n, mpz_t d)
    {
        NativeMethods.mpz_cdiv_qr(ref q.Value, ref r.Value, ref n.Value, ref d.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static ulong cdiv_q_ui(mpz_t q, mpz_t n, ulong d)
    {
        return (ulong)NativeMethods.mpz_cdiv_q_ui(ref q.Value, ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static ulong cdiv_r_ui(mpz_t r, mpz_t n, ulong d)
    {
        return (ulong)NativeMethods.mpz_cdiv_r_ui(ref r.Value, ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static ulong cdiv_qr_ui(mpz_t q, mpz_t r, mpz_t n, ulong d)
    {
        return (ulong)NativeMethods.mpz_cdiv_qr_ui(ref q.Value, ref r.Value, ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static ulong cdiv_ui(mpz_t n, ulong d)
    {
        return (ulong)NativeMethods.mpz_cdiv_ui(ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="n">The n.</param>
    /// <param name="b">The b.</param>
    public static void cdiv_q_2exp(mpz_t q, mpz_t n, ulong b)
    {
        NativeMethods.mpz_cdiv_q_2exp(ref q.Value, ref n.Value, (NativeMethods.mp_bitcnt_t)b);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="b">The b.</param>
    public static void cdiv_r_2exp(mpz_t r, mpz_t n, ulong b)
    {
        NativeMethods.mpz_cdiv_r_2exp(ref r.Value, ref n.Value, (NativeMethods.mp_bitcnt_t)b);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static void fdiv_q(mpz_t q, mpz_t n, mpz_t d)
    {
        NativeMethods.mpz_fdiv_q(ref q.Value, ref n.Value, ref d.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static void fdiv_r(mpz_t r, mpz_t n, mpz_t d)
    {
        NativeMethods.mpz_fdiv_r(ref r.Value, ref n.Value, ref d.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static void fdiv_qr(mpz_t q, mpz_t r, mpz_t n, mpz_t d)
    {
        NativeMethods.mpz_fdiv_qr(ref q.Value, ref r.Value, ref n.Value, ref d.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static ulong fdiv_q_ui(mpz_t q, mpz_t n, ulong d)
    {
        return (ulong)NativeMethods.mpz_fdiv_q_ui(ref q.Value, ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static ulong fdiv_r_ui(mpz_t r, mpz_t n, ulong d)
    {
        return (ulong)NativeMethods.mpz_fdiv_r_ui(ref r.Value, ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static ulong fdiv_qr_ui(mpz_t q, mpz_t r, mpz_t n, ulong d)
    {
        return (ulong)NativeMethods.mpz_fdiv_qr_ui(ref q.Value, ref r.Value, ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static ulong fdiv_ui(mpz_t n, ulong d)
    {
        return (ulong)NativeMethods.mpz_fdiv_ui(ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="n">The n.</param>
    /// <param name="b">The b.</param>
    public static void fdiv_q_2exp(mpz_t q, mpz_t n, ulong b)
    {
        NativeMethods.mpz_fdiv_q_2exp(ref q.Value, ref n.Value, (NativeMethods.mp_bitcnt_t)b);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="b">The b.</param>
    public static void fdiv_r_2exp(mpz_t r, mpz_t n, ulong b)
    {
        NativeMethods.mpz_fdiv_r_2exp(ref r.Value, ref n.Value, (NativeMethods.mp_bitcnt_t)b);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static void tdiv_q(mpz_t q, mpz_t n, mpz_t d)
    {
        NativeMethods.mpz_tdiv_q(ref q.Value, ref n.Value, ref d.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static void tdiv_r(mpz_t r, mpz_t n, mpz_t d)
    {
        NativeMethods.mpz_tdiv_r(ref r.Value, ref n.Value, ref d.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static void tdiv_qr(mpz_t q, mpz_t r, mpz_t n, mpz_t d)
    {
        NativeMethods.mpz_tdiv_qr(ref q.Value, ref r.Value, ref n.Value, ref d.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static ulong tdiv_q_ui(mpz_t q, mpz_t n, ulong d)
    {
        return (ulong)NativeMethods.mpz_tdiv_q_ui(ref q.Value, ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static ulong tdiv_r_ui(mpz_t r, mpz_t n, ulong d)
    {
        return (ulong)NativeMethods.mpz_tdiv_r_ui(ref r.Value, ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static ulong tdiv_qr_ui(mpz_t q, mpz_t r, mpz_t n, ulong d)
    {
        return (ulong)NativeMethods.mpz_tdiv_qr_ui(ref q.Value, ref r.Value, ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static ulong tdiv_ui(mpz_t n, ulong d)
    {
        return (ulong)NativeMethods.mpz_tdiv_ui(ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="n">The n.</param>
    /// <param name="b">The b.</param>
    public static void tdiv_q_2exp(mpz_t q, mpz_t n, ulong b)
    {
        NativeMethods.mpz_tdiv_q_2exp(ref q.Value, ref n.Value, (NativeMethods.mp_bitcnt_t)b);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="b">The b.</param>
    public static void tdiv_r_2exp(mpz_t r, mpz_t n, ulong b)
    {
        NativeMethods.mpz_tdiv_r_2exp(ref r.Value, ref n.Value, (NativeMethods.mp_bitcnt_t)b);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static void mod(mpz_t r, mpz_t n, mpz_t d)
    {
        NativeMethods.mpz_mod(ref r.Value, ref n.Value, ref d.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static void divexact(mpz_t q, mpz_t n, mpz_t d)
    {
        NativeMethods.mpz_divexact(ref q.Value, ref n.Value, ref d.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static void divexact_ui(mpz_t q, mpz_t n, ulong d)
    {
        NativeMethods.mpz_divexact_ui(ref q.Value, ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static bool divisible_p(mpz_t n, mpz_t d)
    {
        return NativeMethods.mpz_divisible_p(ref n.Value, ref d.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static bool divisible_ui_p(mpz_t n, ulong d)
    {
        return NativeMethods.mpz_divisible_ui_p(ref n.Value, (NativeMethods.mpir_ui)d) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The n.</param>
    /// <param name="b">The b.</param>
    public static bool divisible_2exp_p(mpz_t n, ulong b)
    {
        return NativeMethods.mpz_divisible_2exp_p(ref n.Value, (NativeMethods.mp_bitcnt_t)b) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The n.</param>
    /// <param name="c">The c.</param>
    /// <param name="d">The d.</param>
    public static bool congruent_p(mpz_t n, mpz_t c, mpz_t d)
    {
        return NativeMethods.mpz_congruent_p(ref n.Value, ref c.Value, ref d.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The n.</param>
    /// <param name="c">The c.</param>
    /// <param name="d">The d.</param>
    public static bool congruent_ui_p(mpz_t n, ulong c, ulong d)
    {
        return NativeMethods.mpz_congruent_ui_p(ref n.Value, (NativeMethods.mpir_ui)c, (NativeMethods.mpir_ui)d) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The n.</param>
    /// <param name="c">The c.</param>
    /// <param name="b">The b.</param>
    public static bool congruent_2exp_p(mpz_t n, mpz_t c, ulong b)
    {
        return NativeMethods.mpz_congruent_2exp_p(ref n.Value, ref c.Value, (NativeMethods.mp_bitcnt_t)b) != 0;
    }
    #endregion

    #region Exponentiation Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="opBase">The operand base.</param>
    /// <param name="exp">The exponent.</param>
    /// <param name="mod">The mod.</param>
    public static void powm(mpz_t rop, mpz_t opBase, mpz_t exp, mpz_t mod)
    {
        NativeMethods.mpz_powm(ref rop.Value, ref opBase.Value, ref exp.Value, ref mod.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="opBase">The operand base.</param>
    /// <param name="exp">The exponent.</param>
    /// <param name="mod">The mod.</param>
    public static void powm_ui(mpz_t rop, mpz_t opBase, ulong exp, mpz_t mod)
    {
        NativeMethods.mpz_powm_ui(ref rop.Value, ref opBase.Value, (NativeMethods.mpir_ui)exp, ref mod.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="opBase">The operand base.</param>
    /// <param name="exp">The exponent.</param>
    public static void pow_ui(mpz_t rop, mpz_t opBase, ulong exp)
    {
        NativeMethods.mpz_pow_ui(ref rop.Value, ref opBase.Value, (NativeMethods.mpir_ui)exp);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="opBase">The operand base.</param>
    /// <param name="exp">The exponent.</param>
    public static void ui_pow_ui(mpz_t rop, ulong opBase, ulong exp)
    {
        NativeMethods.mpz_ui_pow_ui(ref rop.Value, (NativeMethods.mpir_ui)opBase, (NativeMethods.mpir_ui)exp);
    }
    #endregion

    #region Root Extraction Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="n">The n.</param>
    public static bool root(mpz_t rop, mpz_t op, ulong n)
    {
        return NativeMethods.mpz_root(ref rop.Value, ref op.Value, (NativeMethods.mpir_ui)n) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="n">The n.</param>
    public static void nthroot(mpz_t rop, mpz_t op, ulong n)
    {
        NativeMethods.mpz_nthroot(ref rop.Value, ref op.Value, (NativeMethods.mpir_ui)n);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="root">The root.</param>
    /// <param name="rem">The remainder.</param>
    /// <param name="u">The u.</param>
    /// <param name="n">The n.</param>
    public static void rootrem(mpz_t root, mpz_t rem, mpz_t u, ulong n)
    {
        NativeMethods.mpz_rootrem(ref root.Value, ref rem.Value, ref u.Value, (NativeMethods.mpir_ui)n);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void sqrt(mpz_t rop, mpz_t op)
    {
        NativeMethods.mpz_sqrt(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop1">The first result operand.</param>
    /// <param name="rop2">The second result operand.</param>
    /// <param name="op">The operand.</param>
    public static void sqrtrem(mpz_t rop1, mpz_t rop2, mpz_t op)
    {
        NativeMethods.mpz_sqrtrem(ref rop1.Value, ref rop2.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool perfect_power_p(mpz_t op)
    {
        return NativeMethods.mpz_perfect_power_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool perfect_square_p(mpz_t op)
    {
        return NativeMethods.mpz_perfect_square_p(ref op.Value) != 0;
    }
    #endregion

    #region Number Theoretic Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The value.</param>
    /// <param name="state">The state.</param>
    /// <param name="prob">The probability.</param>
    /// <param name="div">The divider.</param>
    public static bool probable_prime_p(mpz_t n, randstate_t state, int prob, ulong div)
    {
        return NativeMethods.mpz_probable_prime_p(ref n.Value, ref state.Value, prob, (NativeMethods.mpir_ui)div) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The value.</param>
    /// <param name="state">The state.</param>
    /// <param name="div">The divider.</param>
    public static bool likely_prime_p(mpz_t n, randstate_t state, ulong div)
    {
        return NativeMethods.mpz_likely_prime_p(ref n.Value, ref state.Value, (NativeMethods.mpir_ui)div) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="state">The state.</param>
    public static void next_prime_candidate(mpz_t rop, mpz_t op, randstate_t state)
    {
        NativeMethods.mpz_next_prime_candidate(ref rop.Value, ref op.Value, ref state.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void gcd(mpz_t rop, mpz_t op1, mpz_t op2)
    {
        NativeMethods.mpz_gcd(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static ulong gcd_ui(mpz_t rop, mpz_t op1, ulong op2)
    {
        return (ulong)NativeMethods.mpz_gcd_ui(ref rop.Value, ref op1.Value, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="g">The g.</param>
    /// <param name="s">The s.</param>
    /// <param name="t">The t.</param>
    /// <param name="a">The a.</param>
    /// <param name="b">The b.</param>
    public static void gcdext(mpz_t g, mpz_t s, mpz_t t, mpz_t a, mpz_t b)
    {
        NativeMethods.mpz_gcdext(ref g.Value, ref s.Value, ref t.Value, ref a.Value, ref b.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void lcm(mpz_t rop, mpz_t op1, mpz_t op2)
    {
        NativeMethods.mpz_lcm(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void lcm_ui(mpz_t rop, mpz_t op1, ulong op2)
    {
        NativeMethods.mpz_lcm_ui(ref rop.Value, ref op1.Value, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static bool invert(mpz_t rop, mpz_t op1, mpz_t op2)
    {
        return NativeMethods.mpz_invert(ref rop.Value, ref op1.Value, ref op2.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="a">The a.</param>
    /// <param name="b">The b.</param>
    public static int jacobi(mpz_t a, mpz_t b)
    {
        return NativeMethods.mpz_jacobi(ref a.Value, ref b.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="a">The a.</param>
    /// <param name="b">The b.</param>
    public static int legendre(mpz_t a, mpz_t b)
    {
        return NativeMethods.mpz_jacobi(ref a.Value, ref b.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="a">The a.</param>
    /// <param name="b">The b.</param>
    public static int kronecker(mpz_t a, mpz_t b)
    {
        return NativeMethods.mpz_jacobi(ref a.Value, ref b.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="a">The a.</param>
    /// <param name="b">The b.</param>
    public static int kronecker_si(mpz_t a, long b)
    {
        return NativeMethods.mpz_kronecker_si(ref a.Value, (NativeMethods.mpir_si)b);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="a">The a.</param>
    /// <param name="b">The b.</param>
    public static int kronecker_ui(mpz_t a, ulong b)
    {
        return NativeMethods.mpz_kronecker_ui(ref a.Value, (NativeMethods.mpir_ui)b);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="a">The a.</param>
    /// <param name="b">The b.</param>
    public static int si_kronecker(long a, mpz_t b)
    {
        return NativeMethods.mpz_si_kronecker((NativeMethods.mpir_si)a, ref b.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="a">The a.</param>
    /// <param name="b">The b.</param>
    public static int ui_kronecker(ulong a, mpz_t b)
    {
        return NativeMethods.mpz_ui_kronecker((NativeMethods.mpir_ui)a, ref b.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="f">The f.</param>
    public static ulong remove(mpz_t rop, mpz_t op, mpz_t f)
    {
        return (ulong)NativeMethods.mpz_remove(ref rop.Value, ref op.Value, ref f.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="n">The n.</param>
    public static void fac_ui(mpz_t rop, ulong n)
    {
        NativeMethods.mpz_fac_ui(ref rop.Value, (NativeMethods.unsignedlongint)n);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="n">The n.</param>
    public static void fac_ui2(mpz_t rop, ulong n)
    {
        NativeMethods.mpz_2fac_ui(ref rop.Value, (NativeMethods.unsignedlongint)n);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="n">The n.</param>
    /// <param name="m">The m.</param>
    public static void mfac_uiui(mpz_t rop, ulong n, ulong m)
    {
        NativeMethods.mpz_mfac_uiui(ref rop.Value, (NativeMethods.unsignedlongint)n, (NativeMethods.unsignedlongint)m);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="n">The n.</param>
    public static void primorial_ui(mpz_t rop, ulong n)
    {
        NativeMethods.mpz_primorial_ui(ref rop.Value, (NativeMethods.unsignedlongint)n);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="n">The n.</param>
    /// <param name="k">The k.</param>
    public static void bin_ui(mpz_t rop, mpz_t n, ulong k)
    {
        NativeMethods.mpz_bin_ui(ref rop.Value, ref n.Value, (NativeMethods.mpir_ui)k);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="n">The n.</param>
    /// <param name="k">The k.</param>
    public static void bin_uiui(mpz_t rop, ulong n, ulong k)
    {
        NativeMethods.mpz_bin_uiui(ref rop.Value, (NativeMethods.mpir_ui)n, (NativeMethods.mpir_ui)k);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="fn">The fn.</param>
    /// <param name="n">The n.</param>
    public static void fib_ui(mpz_t fn, ulong n)
    {
        NativeMethods.mpz_fib_ui(ref fn.Value, (NativeMethods.mpir_ui)n);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="fn">The fn.</param>
    /// <param name="fnsub1">The fnsub1.</param>
    /// <param name="n">The n.</param>
    public static void fib2_ui(mpz_t fn, mpz_t fnsub1, ulong n)
    {
        NativeMethods.mpz_fib2_ui(ref fn.Value, ref fnsub1.Value, (NativeMethods.mpir_ui)n);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="ln">The ln.</param>
    /// <param name="n">The n.</param>
    public static void lucnum_ui(mpz_t ln, ulong n)
    {
        NativeMethods.mpz_lucnum_ui(ref ln.Value, (NativeMethods.mpir_ui)n);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="ln">The ln.</param>
    /// <param name="lnsub1">The lnsub1.</param>
    /// <param name="n">The n.</param>
    public static void lucnum2_ui(mpz_t ln, mpz_t lnsub1, ulong n)
    {
        NativeMethods.mpz_lucnum2_ui(ref ln.Value, ref lnsub1.Value, (NativeMethods.mpir_ui)n);
    }
    #endregion

    #region Comparison Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static int cmp(mpz_t op1, mpz_t op2)
    {
        return NativeMethods.mpz_cmp(ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static int cmp_d(mpz_t op1, double op2)
    {
        return NativeMethods.mpz_cmp_d(ref op1.Value, op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static int cmp_si(mpz_t op1, long op2)
    {
        return NativeMethods.mpz_cmp_si(ref op1.Value, (NativeMethods.mpir_si)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static int cmp_ui(mpz_t op1, ulong op2)
    {
        return NativeMethods.mpz_cmp_ui(ref op1.Value, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static int cmpabs(mpz_t op1, mpz_t op2)
    {
        return NativeMethods.mpz_cmpabs(ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static int cmpabs_d(mpz_t op1, double op2)
    {
        return NativeMethods.mpz_cmpabs_d(ref op1.Value, op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static int cmpabs_ui(mpz_t op1, ulong op2)
    {
        return NativeMethods.mpz_cmpabs_ui(ref op1.Value, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static int sgn(mpz_t op)
    {
        return NativeMethods.mpz_sgn(ref op.Value);
    }
    #endregion

    #region Logical and Bit Manipulation Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void and(mpz_t rop, mpz_t op1, mpz_t op2)
    {
        NativeMethods.mpz_and(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void ior(mpz_t rop, mpz_t op1, mpz_t op2)
    {
        NativeMethods.mpz_ior(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void xor(mpz_t rop, mpz_t op1, mpz_t op2)
    {
        NativeMethods.mpz_xor(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void com(mpz_t rop, mpz_t op)
    {
        NativeMethods.mpz_com(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static ulong popcount(mpz_t op)
    {
        return (ulong)NativeMethods.mpz_popcount(ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static ulong hamdist(mpz_t op1, mpz_t op2)
    {
        return (ulong)NativeMethods.mpz_hamdist(ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="startingBit">The start bit.</param>
    public static ulong scan0(mpz_t op, ulong startingBit)
    {
        return (ulong)NativeMethods.mpz_scan0(ref op.Value, (NativeMethods.mp_bitcnt_t)startingBit);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="startingBit">The start bit.</param>
    public static ulong scan1(mpz_t op, ulong startingBit)
    {
        return (ulong)NativeMethods.mpz_scan1(ref op.Value, (NativeMethods.mp_bitcnt_t)startingBit);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="bitIndex">The bit index.</param>
    public static void setbit(mpz_t rop, ulong bitIndex)
    {
        NativeMethods.mpz_setbit(ref rop.Value, (NativeMethods.mp_bitcnt_t)bitIndex);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="bitIndex">The bit index.</param>
    public static void clrbit(mpz_t rop, ulong bitIndex)
    {
        NativeMethods.mpz_clrbit(ref rop.Value, (NativeMethods.mp_bitcnt_t)bitIndex);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="bitIndex">The bit index.</param>
    public static void combit(mpz_t rop, ulong bitIndex)
    {
        NativeMethods.mpz_combit(ref rop.Value, (NativeMethods.mp_bitcnt_t)bitIndex);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="bitIndex">The bit index.</param>
    public static bool tstbit(mpz_t op, ulong bitIndex)
    {
        return NativeMethods.mpz_tstbit(ref op.Value, (NativeMethods.mp_bitcnt_t)bitIndex) != 0;
    }
    #endregion

    #region  Input and Output Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="writer">The output stream.</param>
    /// <param name="strBase">The digit base.</param>
    /// <param name="op">The operand.</param>
    public static long out_str(StreamWriter writer, int strBase, mpz_t op)
    {
        if (strBase < 2 || strBase > 62)
            throw new ArgumentOutOfRangeException(nameof(strBase));

        ulong SizeInDigits = sizeinbase(op, (uint)strBase);
        SizeInDigits += 2;

        StringBuilder Data = new StringBuilder((int)SizeInDigits);
        get_str(Data, strBase, op);

        string Content = Data.ToString();
        writer.Write(Content);

        return Content.Length;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="reader">The input stream.</param>
    /// <param name="strBase">The digit base.</param>
    public static long inp_str(mpz_t rop, StreamReader reader, int strBase)
    {
        string Content = reader.ReadToEnd();

        NativeMethods.mpz_init_set_str(ref rop.Value, Content, (uint)strBase);

        return Content.Length;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="content">The input string.</param>
    /// <param name="strBase">The digit base.</param>
    public static bool init_set_str(mpz_t rop, string content, uint strBase)
    {
        return NativeMethods.mpz_init_set_str(ref rop.Value, content, strBase) == 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="writer">The output stream.</param>
    /// <param name="op">The operand.</param>
    public static long out_raw(BinaryWriter writer, mpz_t op)
    {
        ulong SizeInBits = (ulong)NativeMethods.mpz_sizeinbase(ref op.Value, 2);
        byte[] Content = new byte[(SizeInBits + 7) / 8];

        NativeMethods.mpz_export(Content, out NativeMethods.size_t countp, -1, (NativeMethods.size_t)sizeof(byte), -1, (NativeMethods.size_t)0UL, ref op.Value);

        writer.Write(Content);

        return Content.Length;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="reader">The input stream.</param>
    public static long inp_raw(mpz_t rop, BinaryReader reader)
    {
        int ContentLength = (int)reader.BaseStream.Length;
        byte[] Content = reader.ReadBytes(ContentLength);

        NativeMethods.mpz_import(ref rop.Value, (NativeMethods.size_t)(ulong)Content.Length, -1, (NativeMethods.size_t)sizeof(byte), -1, (NativeMethods.size_t)0UL, Content);

        return Content.Length;
    }
    #endregion

    #region Integer Import and Export
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="count">The count.</param>
    /// <param name="order">The order.</param>
    /// <param name="size">The size.</param>
    /// <param name="endian">The endianess.</param>
    /// <param name="nails">The nails count.</param>
    /// <param name="op">The operand.</param>
    public static void import(mpz_t rop, ulong count, int order, ulong size, int endian, ulong nails, byte[] op)
    {
        NativeMethods.mpz_import(ref rop.Value, (NativeMethods.size_t)count, order, (NativeMethods.size_t)size, endian, (NativeMethods.size_t)nails, op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="countp">The result count.</param>
    /// <param name="order">The order.</param>
    /// <param name="size">The size.</param>
    /// <param name="endian">The endianess.</param>
    /// <param name="nails">The nails count.</param>
    /// <param name="op">The operand.</param>
    public static void export(byte[] rop, out ulong countp, int order, ulong size, int endian, ulong nails, mpz_t op)
    {
        NativeMethods.mpz_export(rop, out NativeMethods.size_t countpStruct, order, (NativeMethods.size_t)size, endian, (NativeMethods.size_t)nails, ref op.Value);
        countp = (ulong)countpStruct;
    }
    #endregion

    #region Random Number Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="state">The state.</param>
    /// <param name="n">The n.</param>
    public static void urandomb(mpz_t rop, randstate_t state, ulong n)
    {
        NativeMethods.mpz_urandomb(ref rop.Value, ref state.Value, (NativeMethods.mp_bitcnt_t)n);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="state">The state.</param>
    /// <param name="n">The n.</param>
    public static void urandomm(mpz_t rop, randstate_t state, mpz_t n)
    {
        NativeMethods.mpz_urandomm(ref rop.Value, ref state.Value, ref n.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="state">The state.</param>
    /// <param name="n">The n.</param>
    public static void rrandomb(mpz_t rop, randstate_t state, ulong n)
    {
        NativeMethods.mpz_rrandomb(ref rop.Value, ref state.Value, (NativeMethods.mp_bitcnt_t)n);
    }
    #endregion

    #region Miscellaneous Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool fits_ulong_p(mpz_t op)
    {
        return NativeMethods.mpz_fits_ulong_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool fits_slong_p(mpz_t op)
    {
        return NativeMethods.mpz_fits_slong_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool fits_uint_p(mpz_t op)
    {
        return NativeMethods.mpz_fits_uint_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool fits_sint_p(mpz_t op)
    {
        return NativeMethods.mpz_fits_sint_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool fits_ushort_p(mpz_t op)
    {
        return NativeMethods.mpz_fits_ushort_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool fits_sshort_p(mpz_t op)
    {
        return NativeMethods.mpz_fits_sshort_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool odd_p(mpz_t op)
    {
        bool HasValidLimb = (op.Value.LimbCount != 0) & (op.Value.Limbs != System.IntPtr.Zero);
        if (!HasValidLimb)
            return false;

        return (System.Runtime.InteropServices.Marshal.ReadByte(op.Value.Limbs, 0) & 1) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool even_p(mpz_t op)
    {
        bool HasValidLimb = (op.Value.LimbCount != 0) & (op.Value.Limbs != System.IntPtr.Zero);
        if (!HasValidLimb)
            return false;

        return (System.Runtime.InteropServices.Marshal.ReadByte(op.Value.Limbs, 0) & 1) == 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="resultbase">The result base.</param>
    public static ulong sizeinbase(mpz_t op, uint resultbase)
    {
        return (ulong)NativeMethods.mpz_sizeinbase(ref op.Value, resultbase);
    }
    #endregion
}
