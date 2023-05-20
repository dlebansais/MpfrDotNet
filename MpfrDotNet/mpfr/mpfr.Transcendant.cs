﻿namespace MpfrDotNet;

using MpirDotNet;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public static partial class mpfr
{
    #region Log
    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int log(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_log(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int log_ui(mpfr_t rop, uint op, mpfr_rnd_t rnd)
    {
        return mpfr_log_ui(ref rop.Value, op, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int log2(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_log2(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int log10(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_log10(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int log1p(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_log1p(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int log2p1(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_log2p1(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int log10p1(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_log10p1(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }
    #endregion

    #region Exp
    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int exp(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_exp(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int exp2(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_exp2(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int exp10(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_exp10(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int expm1(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_expm1(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int exp2m1(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_exp2m1(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int exp10m1(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_exp10m1(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }
    #endregion

    #region Pow
    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int pow(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
    {
        return mpfr_pow(ref rop.Value, ref op1.Value, ref op2.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int pow_ui(mpfr_t rop, mpfr_t op1, ulong op2, mpfr_rnd_t rnd)
    {
        return mpfr_pow_ui(ref rop.Value, ref op1.Value, op2, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int pow_si(mpfr_t rop, mpfr_t op1, long op2, mpfr_rnd_t rnd)
    {
        return mpfr_pow_si(ref rop.Value, ref op1.Value, op2, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int pow_z(mpfr_t rop, mpfr_t op1, mpz_t op2, mpfr_rnd_t rnd)
    {
        return mpfr_pow_z(ref rop.Value, ref op1.Value, ref op2.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int ui_pow_ui(mpfr_t rop, ulong op1, ulong op2, mpfr_rnd_t rnd)
    {
        return mpfr_ui_pow_ui(ref rop.Value, op1, op2, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int ui_pow(mpfr_t rop, ulong op1, mpfr_t op2, mpfr_rnd_t rnd)
    {
        return mpfr_ui_pow(ref rop.Value, op1, ref op2.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int powr(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
    {
        return mpfr_powr(ref rop.Value, ref op1.Value, ref op2.Value, (__mpfr_rnd_t)rnd);
    }
    #endregion

    #region Trigonometric
    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int cos(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_cos(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int sin(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_sin(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int tan(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_tan(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="sop">The sinus result operand.</param>
    /// <param name="cop">The cosinus result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int sin_cos(mpfr_t sop, mpfr_t cop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_sin_cos(ref sop.Value, ref cop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int sec(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_sec(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int csc(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_csc(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int cot(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_cot(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int acos(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_acos(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int asin(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_asin(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int atan(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_atan(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int atan2(mpfr_t rop, mpfr_t x, mpfr_t y, mpfr_rnd_t rnd)
    {
        return mpfr_atan2(ref rop.Value, ref x.Value, ref y.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int cosh(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_cosh(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int sinh(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_sinh(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int tanh(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_tanh(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="sop">The sinus result operand.</param>
    /// <param name="cop">The cosinus result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int sinh_cosh(mpfr_t sop, mpfr_t cop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_sinh_cosh(ref sop.Value, ref cop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int sech(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_sech(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int csch(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_csch(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int coth(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_coth(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int acosh(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_acosh(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int asinh(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_asinh(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int atanh(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_atanh(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The first operand.</param>
    /// <param name="u">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int cosu(mpfr_t rop, mpfr_t op, ulong u, mpfr_rnd_t rnd)
    {
        return mpfr_cosu(ref rop.Value, ref op.Value, u, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The first operand.</param>
    /// <param name="u">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int sinu(mpfr_t rop, mpfr_t op, ulong u, mpfr_rnd_t rnd)
    {
        return mpfr_sinu(ref rop.Value, ref op.Value, u, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The first operand.</param>
    /// <param name="u">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int tanu(mpfr_t rop, mpfr_t op, ulong u, mpfr_rnd_t rnd)
    {
        return mpfr_tanu(ref rop.Value, ref op.Value, u, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The first operand.</param>
    /// <param name="u">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int acosu(mpfr_t rop, mpfr_t op, ulong u, mpfr_rnd_t rnd)
    {
        return mpfr_acosu(ref rop.Value, ref op.Value, u, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The first operand.</param>
    /// <param name="u">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int asinu(mpfr_t rop, mpfr_t op, ulong u, mpfr_rnd_t rnd)
    {
        return mpfr_asinu(ref rop.Value, ref op.Value, u, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The first operand.</param>
    /// <param name="u">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int atanu(mpfr_t rop, mpfr_t op, ulong u, mpfr_rnd_t rnd)
    {
        return mpfr_atanu(ref rop.Value, ref op.Value, u, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <param name="u">The third operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int atan2u(mpfr_t rop, mpfr_t x, mpfr_t y, ulong u, mpfr_rnd_t rnd)
    {
        return mpfr_atan2u(ref rop.Value, ref x.Value, ref y.Value, u, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The first operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int cospi(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_cospi(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The first operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int sinpi(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_sinpi(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The first operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int tanpi(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_tanpi(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The first operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int acospi(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_acospi(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The first operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int asinpi(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_asinpi(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The first operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int atanpi(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_atanpi(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int atan2pi(mpfr_t rop, mpfr_t x, mpfr_t y, mpfr_rnd_t rnd)
    {
        return mpfr_atan2pi(ref rop.Value, ref x.Value, ref y.Value, (__mpfr_rnd_t)rnd);
    }
    #endregion

    #region Other
    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int eint(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_eint(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int li2(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_li2(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int gamma(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_gamma(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int gamma_inc(mpfr_t rop, mpfr_t op, mpfr_t op2, mpfr_rnd_t rnd)
    {
        return mpfr_gamma_inc(ref rop.Value, ref op.Value, ref op2.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int lngamma(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_lngamma(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="sign">The sign.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int lgamma(mpfr_t rop, out int sign, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_lgamma(ref rop.Value, out sign, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int digamma(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_digamma(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int beta(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
    {
        return mpfr_beta(ref rop.Value, ref op1.Value, ref op2.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int zeta(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_zeta(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int zeta_ui(mpfr_t rop, ulong op, mpfr_rnd_t rnd)
    {
        return mpfr_zeta_ui(ref rop.Value, op, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int erf(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_erf(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int erfc(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_erfc(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int j0(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_j0(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int j1(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_j1(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="n">The n.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int jn(mpfr_t rop, long n, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_jn(ref rop.Value, n, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int y0(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_y0(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int y1(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_y1(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="n">The n.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int yn(mpfr_t rop, long n, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_yn(ref rop.Value, n, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int agm(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
    {
        return mpfr_agm(ref rop.Value, ref op1.Value, ref op2.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int ai(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_ai(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int const_log2(mpfr_t rop, mpfr_rnd_t rnd)
    {
        return mpfr_const_log2(ref rop.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int const_pi(mpfr_t rop, mpfr_rnd_t rnd)
    {
        return mpfr_const_pi(ref rop.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int const_euler(mpfr_t rop, mpfr_rnd_t rnd)
    {
        return mpfr_const_euler(ref rop.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int const_catalan(mpfr_t rop, mpfr_rnd_t rnd)
    {
        return mpfr_const_catalan(ref rop.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="n">The n.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int compound_si(mpfr_t rop, mpfr_t op, long n, mpfr_rnd_t rnd)
    {
        return mpfr_compound_si(ref rop.Value, ref op.Value, n, (__mpfr_rnd_t)rnd);
    }
    #endregion
}
