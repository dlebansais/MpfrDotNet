namespace MpfrDotNet;

using System;
using System.Runtime.InteropServices;
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
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int log(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_log(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int log_ui(mpfr_t rop, uint op, mpfr_rnd_t rnd)
    {
        return mpfr_log_ui(ref rop.Value, ToCULong(op), ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int log2(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_log2(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int log10(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_log10(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int log1p(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_log1p(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int log2p1(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_log2p1(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int log10p1(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_log10p1(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }
    #endregion

    #region Exp
    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int exp(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_exp(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int exp2(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_exp2(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int exp10(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_exp10(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int expm1(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_expm1(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int exp2m1(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_exp2m1(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int exp10m1(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_exp10m1(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
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
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int pow(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
    {
        return mpfr_pow(ref rop.Value, ref op1.Value, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int pow_ui(mpfr_t rop, mpfr_t op1, ulong op2, mpfr_rnd_t rnd)
    {
        return mpfr_pow_ui(ref rop.Value, ref op1.Value, op2, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int pow_si(mpfr_t rop, mpfr_t op1, long op2, mpfr_rnd_t rnd)
    {
        return mpfr_pow_si(ref rop.Value, ref op1.Value, op2, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int pow_z(mpfr_t rop, mpfr_t op1, mpz_t op2, mpfr_rnd_t rnd)
    {
        return mpfr_pow_z(ref rop.Value, ref op1.Value, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int ui_pow_ui(mpfr_t rop, ulong op1, ulong op2, mpfr_rnd_t rnd)
    {
        return mpfr_ui_pow_ui(ref rop.Value, op1, op2, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int ui_pow(mpfr_t rop, ulong op1, mpfr_t op2, mpfr_rnd_t rnd)
    {
        return mpfr_ui_pow(ref rop.Value, op1, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int powr(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
    {
        return mpfr_powr(ref rop.Value, ref op1.Value, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
    }
    #endregion

    #region Trigonometric
    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int cos(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_cos(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int sin(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_sin(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int tan(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_tan(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="sop">The sinus result operand.</param>
    /// <param name="cop">The cosinus result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    /// <exception cref="ArgumentException"><paramref name="sop"/> and <paramref name="cop"/> are the same number.</exception>
    public static int sin_cos(mpfr_t sop, mpfr_t cop, mpfr_t op, mpfr_rnd_t rnd)
    {
        // MPFR aborts the process when the two results are the same number.
        if (ReferenceEquals(sop, cop))
            throw new ArgumentException("The two results must be different numbers.", nameof(cop));

        return mpfr_sin_cos(ref sop.Value, ref cop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int sec(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_sec(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int csc(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_csc(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int cot(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_cot(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int acos(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_acos(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int asin(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_asin(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int atan(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_atan(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="y">The numerator, the y coordinate.</param>
    /// <param name="x">The denominator, the x coordinate.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int atan2(mpfr_t rop, mpfr_t y, mpfr_t x, mpfr_rnd_t rnd)
    {
        return mpfr_atan2(ref rop.Value, ref y.Value, ref x.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int cosh(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_cosh(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int sinh(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_sinh(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int tanh(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_tanh(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="sop">The sinus result operand.</param>
    /// <param name="cop">The cosinus result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    /// <exception cref="ArgumentException"><paramref name="sop"/> and <paramref name="cop"/> are the same number.</exception>
    public static int sinh_cosh(mpfr_t sop, mpfr_t cop, mpfr_t op, mpfr_rnd_t rnd)
    {
        // MPFR aborts the process when the two results are the same number.
        if (ReferenceEquals(sop, cop))
            throw new ArgumentException("The two results must be different numbers.", nameof(cop));

        return mpfr_sinh_cosh(ref sop.Value, ref cop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int sech(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_sech(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int csch(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_csch(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int coth(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_coth(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int acosh(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_acosh(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int asinh(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_asinh(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int atanh(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_atanh(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The first operand.</param>
    /// <param name="u">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int cosu(mpfr_t rop, mpfr_t op, ulong u, mpfr_rnd_t rnd)
    {
        return mpfr_cosu(ref rop.Value, ref op.Value, u, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The first operand.</param>
    /// <param name="u">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int sinu(mpfr_t rop, mpfr_t op, ulong u, mpfr_rnd_t rnd)
    {
        return mpfr_sinu(ref rop.Value, ref op.Value, u, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The first operand.</param>
    /// <param name="u">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int tanu(mpfr_t rop, mpfr_t op, ulong u, mpfr_rnd_t rnd)
    {
        return mpfr_tanu(ref rop.Value, ref op.Value, u, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The first operand.</param>
    /// <param name="u">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int acosu(mpfr_t rop, mpfr_t op, ulong u, mpfr_rnd_t rnd)
    {
        return mpfr_acosu(ref rop.Value, ref op.Value, u, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The first operand.</param>
    /// <param name="u">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int asinu(mpfr_t rop, mpfr_t op, ulong u, mpfr_rnd_t rnd)
    {
        return mpfr_asinu(ref rop.Value, ref op.Value, u, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The first operand.</param>
    /// <param name="u">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int atanu(mpfr_t rop, mpfr_t op, ulong u, mpfr_rnd_t rnd)
    {
        return mpfr_atanu(ref rop.Value, ref op.Value, u, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="y">The numerator, the y coordinate.</param>
    /// <param name="x">The denominator, the x coordinate.</param>
    /// <param name="u">The third operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int atan2u(mpfr_t rop, mpfr_t y, mpfr_t x, ulong u, mpfr_rnd_t rnd)
    {
        return mpfr_atan2u(ref rop.Value, ref y.Value, ref x.Value, u, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The first operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int cospi(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_cospi(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The first operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int sinpi(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_sinpi(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The first operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int tanpi(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_tanpi(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The first operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int acospi(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_acospi(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The first operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int asinpi(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_asinpi(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The first operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int atanpi(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_atanpi(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="y">The numerator, the y coordinate.</param>
    /// <param name="x">The denominator, the x coordinate.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int atan2pi(mpfr_t rop, mpfr_t y, mpfr_t x, mpfr_rnd_t rnd)
    {
        return mpfr_atan2pi(ref rop.Value, ref y.Value, ref x.Value, ToNativeRounding(rnd, nameof(rnd)));
    }
    #endregion

    #region Other
    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int eint(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_eint(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int li2(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_li2(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int gamma(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_gamma(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    /// <exception cref="OverflowException">Gamma(<paramref name="op"/>) is beyond the widest exponent range of MPFR, which mpfr_gamma_inc does not support.</exception>
    public static int gamma_inc(mpfr_t rop, mpfr_t op, mpfr_t op2, mpfr_rnd_t rnd)
    {
        __mpfr_rnd_t NativeRounding = ToNativeRounding(rnd, nameof(rnd));

        // MPFR aborts the process when Gamma(op) overflows, which happens for op beyond about 5e7 with the 32-bit
        // exponents of Windows, and 1e17 elsewhere: Gamma(1e6) is far from overflowing.
        if (mpfr_cmp_ui(ref op.Value, 1000000UL) > 0 && IsGammaBeyondWidestRange(op))
            throw new OverflowException("Gamma of the operand is beyond the exponent range of MPFR.");

        return mpfr_gamma_inc(ref rop.Value, ref op.Value, ref op2.Value, NativeRounding);
    }

    /// <summary>
    /// Checks whether Gamma of a number overflows the widest exponent range.
    /// </summary>
    /// <param name="op">The number.</param>
    /// <returns><see langword="true"/> if Gamma(<paramref name="op"/>) overflows; otherwise, <see langword="false"/>.</returns>
    internal static bool IsGammaBeyondWidestRange(mpfr_t op)
    {
        // The flags and the exponent range of the thread are restored, so that the check leaves no trace.
        uint Flags = mpfr_flags_save();
        CLong MinExponent = mpfr_get_emin();
        CLong MaxExponent = mpfr_get_emax();

        using mpfr_t Gamma = mpfr_t.CreateWithPrecision(PrecisionMin, nameof(op));
        _ = mpfr_set_emin(mpfr_get_emin_min());
        _ = mpfr_set_emax(mpfr_get_emax_max());

        try
        {
            // mpfr_gamma_inc rounds toward zero and asserts that no overflow happened: the result is then finite.
            mpfr_clear_overflow();
            _ = mpfr_gamma(ref Gamma.Value, ref op.Value, __mpfr_rnd_t.MPFR_RNDZ);
            return mpfr_overflow_p() != 0;
        }
        finally
        {
            _ = mpfr_set_emin(MinExponent);
            _ = mpfr_set_emax(MaxExponent);
            mpfr_flags_restore(Flags, AllFlags);
        }
    }

    // MPFR_FLAGS_ALL.
    private const uint AllFlags = 63;

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int lngamma(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_lngamma(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="sign">The sign.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int lgamma(mpfr_t rop, out int sign, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_lgamma(ref rop.Value, out sign, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int digamma(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_digamma(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int beta(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
    {
        return mpfr_beta(ref rop.Value, ref op1.Value, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int zeta(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_zeta(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int zeta_ui(mpfr_t rop, ulong op, mpfr_rnd_t rnd)
    {
        return mpfr_zeta_ui(ref rop.Value, op, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int erf(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_erf(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int erfc(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_erfc(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int j0(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_j0(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int j1(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_j1(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="n">The n.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int jn(mpfr_t rop, long n, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_jn(ref rop.Value, n, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int y0(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_y0(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int y1(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_y1(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="n">The n.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int yn(mpfr_t rop, long n, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_yn(ref rop.Value, n, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int agm(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
    {
        return mpfr_agm(ref rop.Value, ref op1.Value, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    /// <exception cref="OverflowException">The working precision that MPFR needs for <paramref name="op"/> exceeds its maximum precision: for a negative number below about -1.7e6 at usual precisions on Windows, where MPFR would abort.</exception>
    public static int ai(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        __mpfr_rnd_t NativeRounding = ToNativeRounding(rnd, nameof(rnd));

        if (mpfr_regular_p(ref op.Value) == 0)
            return mpfr_ai(ref rop.Value, ref op.Value, NativeRounding);

        // MPFR does not handle the underflow of Ai(x) for large positive x, and sizes its working precision from
        // |x|^(3/2): beyond its maximum precision it aborts the process, and long before it takes a very long time.
        if (IsAiryUnderflow(op))
        {
            // Any positive value below 2^(emin - 2) rounds like this one, with the underflow flag.
            CLong Exponent = new(mpfr_get_emin().Value - 3);
            return mpfr_set_ui_2exp(ref rop.Value, 1UL, Exponent, NativeRounding);
        }

        if (IsAiryPrecisionBeyondMaximum(rop, op))
            throw new OverflowException("The operand is beyond the range where MPFR can compute the Airy function.");

        return mpfr_ai(ref rop.Value, ref op.Value, NativeRounding);
    }

    /// <summary>
    /// Checks whether Ai of a number is positive and below 2^(emin - 2), so that it underflows in every rounding mode.
    /// </summary>
    /// <param name="op">The number, regular.</param>
    /// <returns><see langword="true"/> if Ai(<paramref name="op"/>) underflows; otherwise, <see langword="false"/>.</returns>
    internal static bool IsAiryUnderflow(mpfr_t op)
    {
        if (mpfr_signbit(ref op.Value) != 0)
            return false;

        // For x >= 1, Ai(x) < exp(-2/3 x^(3/2)) = 2^(-c x^(3/2)) with c = 2/3 log2(e), which is above the truncated
        // constant. x is rounded down, so that the bound stays below the true one.
        double X = mpfr_get_d(ref op.Value, __mpfr_rnd_t.MPFR_RNDD);
        if (X < 1.0)
            return false;

        double LostBits = AiryExponentFactorLow * Math.Pow(X, 1.5) * (1.0 - 1e-12);
        double MinExponent = mpfr_get_emin().Value;

        return LostBits >= 2.0 - MinExponent + 1.0;
    }

    /// <summary>
    /// Checks whether the working precision of mpfr_ai for a number exceeds the maximum precision.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The number, regular.</param>
    /// <returns><see langword="true"/> if MPFR would abort; otherwise, <see langword="false"/>.</returns>
    internal static bool IsAiryPrecisionBeyondMaximum(mpfr_t rop, mpfr_t op)
    {
        // mpfr_ai2 adds to the precision of the result c |x|^(3/2) lost bits, plus as much again for a positive x as
        // the expected exponent of Ai(x), plus a few dozen bits. |x| is rounded up, so that the estimate is an upper bound.
        double X = Math.Abs(mpfr_get_d(ref op.Value, mpfr_signbit(ref op.Value) != 0 ? __mpfr_rnd_t.MPFR_RNDD : __mpfr_rnd_t.MPFR_RNDU));
        double LostBits = AiryExponentFactorHigh * Math.Pow(X, 1.5) * (1.0 + 1e-12);
        double Multiplier = mpfr_signbit(ref op.Value) != 0 ? 1.0 : 2.0;
        double WorkingPrecision = get_prec(rop) + (Multiplier * LostBits) + AiryPrecisionMargin;

        return WorkingPrecision >= PrecisionMax;
    }

    // 2/3 log2(e) = 0.961796693925975604..., below and above.
    private const double AiryExponentFactorLow = 0.9617966939;
    private const double AiryExponentFactorHigh = 0.96179669393;

    // The guard bits and the logarithm of the precision that mpfr_ai2 adds, with room to spare.
    private const double AiryPrecisionMargin = 1024.0;

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int const_log2(mpfr_t rop, mpfr_rnd_t rnd)
    {
        return mpfr_const_log2(ref rop.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int const_pi(mpfr_t rop, mpfr_rnd_t rnd)
    {
        return mpfr_const_pi(ref rop.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int const_euler(mpfr_t rop, mpfr_rnd_t rnd)
    {
        return mpfr_const_euler(ref rop.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int const_catalan(mpfr_t rop, mpfr_rnd_t rnd)
    {
        return mpfr_const_catalan(ref rop.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="n">The n.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int compound_si(mpfr_t rop, mpfr_t op, long n, mpfr_rnd_t rnd)
    {
        return mpfr_compound_si(ref rop.Value, ref op.Value, n, ToNativeRounding(rnd, nameof(rnd)));
    }
    #endregion
}
