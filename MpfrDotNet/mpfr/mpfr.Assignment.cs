﻿namespace MpfrDotNet;

using MpirDotNet;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public static partial class mpfr
{
    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int set(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_set(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int set_ui(mpfr_t rop, ulong op, mpfr_rnd_t rnd)
    {
        return mpfr_set_ui(ref rop.Value, op, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int set_si(mpfr_t rop, long op, mpfr_rnd_t rnd)
    {
        return mpfr_set_si(ref rop.Value, op, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int set_uj(mpfr_t rop, uint op, mpfr_rnd_t rnd)
    {
        return mpfr_set_uj(ref rop.Value, op, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int set_sj(mpfr_t rop, int op, mpfr_rnd_t rnd)
    {
        return mpfr_set_sj(ref rop.Value, op, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int set_flt(mpfr_t rop, float op, mpfr_rnd_t rnd)
    {
        return mpfr_set_flt(ref rop.Value, op, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int set_d(mpfr_t rop, double op, mpfr_rnd_t rnd)
    {
        return mpfr_set_d(ref rop.Value, op, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int set_z(mpfr_t rop, mpz_t op, mpfr_rnd_t rnd)
    {
        return mpfr_set_z(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int set_q(mpfr_t rop, mpq_t op, mpfr_rnd_t rnd)
    {
        return mpfr_set_q(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int set_f(mpfr_t rop, mpf_t op, mpfr_rnd_t rnd)
    {
        return mpfr_set_f(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="e">The exponent.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int set_ui_2exp(mpfr_t rop, ulong op, long e, mpfr_rnd_t rnd)
    {
        return mpfr_set_ui_2exp(ref rop.Value, op, e, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="e">The exponent.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int set_si_2exp(mpfr_t rop, long op, long e, mpfr_rnd_t rnd)
    {
        return mpfr_set_si_2exp(ref rop.Value, op, e, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="e">The exponent.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int set_uj_2exp(mpfr_t rop, uint op, long e, mpfr_rnd_t rnd)
    {
        return mpfr_set_uj_2exp(ref rop.Value, op, e, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="e">The exponent.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int set_sj_2exp(mpfr_t rop, int op, long e, mpfr_rnd_t rnd)
    {
        return mpfr_set_sj_2exp(ref rop.Value, op, e, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="e">The exponent.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int set_z_2exp(mpfr_t rop, mpz_t op, long e, mpfr_rnd_t rnd)
    {
        return mpfr_set_z_2exp(ref rop.Value, ref op.Value, e, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="str">The string.</param>
    /// <param name="strbase">The string base.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static bool set_str(mpfr_t rop, string str, uint strbase, mpfr_rnd_t rnd)
    {
        return mpfr_set_str(ref rop.Value, str, strbase, (__mpfr_rnd_t)rnd) == 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    public static void set_nan(mpfr_t rop)
    {
        mpfr_set_nan(ref rop.Value);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="sign">The sign.</param>
    public static void set_inf(mpfr_t rop, int sign)
    {
        mpfr_set_inf(ref rop.Value, sign);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="sign">The sign.</param>
    public static void set_zero(mpfr_t rop, int sign)
    {
        mpfr_set_zero(ref rop.Value, sign);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void swap(mpfr_t rop, mpfr_t op)
    {
        mpfr_swap(ref rop.Value, ref op.Value);
    }
}
