namespace MpfrDotNet;

using System;
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
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int set(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_set(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int set_ui(mpfr_t rop, ulong op, mpfr_rnd_t rnd)
    {
        return mpfr_set_ui(ref rop.Value, op, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int set_si(mpfr_t rop, long op, mpfr_rnd_t rnd)
    {
        return mpfr_set_si(ref rop.Value, op, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int set_uj(mpfr_t rop, uint op, mpfr_rnd_t rnd)
    {
        return mpfr_set_uj(ref rop.Value, op, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int set_sj(mpfr_t rop, int op, mpfr_rnd_t rnd)
    {
        return mpfr_set_sj(ref rop.Value, op, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int set_flt(mpfr_t rop, float op, mpfr_rnd_t rnd)
    {
        return mpfr_set_flt(ref rop.Value, op, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int set_d(mpfr_t rop, double op, mpfr_rnd_t rnd)
    {
        return mpfr_set_d(ref rop.Value, op, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int set_z(mpfr_t rop, mpz_t op, mpfr_rnd_t rnd)
    {
        return mpfr_set_z(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int set_q(mpfr_t rop, mpq_t op, mpfr_rnd_t rnd)
    {
        return mpfr_set_q(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int set_f(mpfr_t rop, mpf_t op, mpfr_rnd_t rnd)
    {
        __mpfr_rnd_t NativeRounding = ToNativeRounding(rnd, nameof(rnd));

        // mpfr_set_f computes the exponent in bits as the exponent of op in limbs times 64, which wraps with the 32-bit
        // exponents of Windows for a number far below the exponent range. Such a number underflows in any exponent
        // range, and rounds like +1 or -1 scaled by the smallest native power of two.
        if (IsFarBelowExponentRange(op))
        {
            _ = mpfr_set_si(ref rop.Value, mpf.sgn(op), __mpfr_rnd_t.MPFR_RNDN);
            return mpfr_mul_2si(ref rop.Value, ref rop.Value, ToNativeExponent(long.MinValue), NativeRounding);
        }

        return mpfr_set_f(ref rop.Value, ref op.Value, NativeRounding);
    }

    /// <summary>
    /// Checks whether a number is below the smallest positive number of the widest exponent range of MPFR.
    /// </summary>
    /// <param name="op">The number.</param>
    /// <returns><see langword="true"/> if the number underflows in any exponent range; otherwise, <see langword="false"/>.</returns>
    internal static bool IsFarBelowExponentRange(mpf_t op)
        => mpf.sgn(op) != 0 && IsFarBelowExponentRange((long)op.Value.Exponent.Value, (long)mpfr_get_emin_min().Value);

    /// <summary>
    /// Checks whether a number with an exponent in limbs is below the smallest positive number of an exponent range.
    /// </summary>
    /// <param name="limbExponent">The exponent of the number, in limbs: its magnitude is below 2^(64 * <paramref name="limbExponent"/>).</param>
    /// <param name="minExponent">The smallest exponent of the range, in bits.</param>
    /// <returns><see langword="true"/> if the number underflows in the range; otherwise, <see langword="false"/>.</returns>
    internal static bool IsFarBelowExponentRange(long limbExponent, long minExponent)
    {
        // The product in bits overflows below long.MinValue / 64, which is far below any range.
        return limbExponent < long.MinValue / (long)LimbBits || limbExponent * (long)LimbBits < minExponent;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="e">The exponent.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int set_ui_2exp(mpfr_t rop, ulong op, long e, mpfr_rnd_t rnd)
    {
        return mpfr_set_ui_2exp(ref rop.Value, op, ToNativeExponent(e), ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="e">The exponent.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int set_si_2exp(mpfr_t rop, long op, long e, mpfr_rnd_t rnd)
    {
        return mpfr_set_si_2exp(ref rop.Value, op, ToNativeExponent(e), ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="e">The exponent.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int set_uj_2exp(mpfr_t rop, uint op, long e, mpfr_rnd_t rnd)
    {
        return mpfr_set_uj_2exp(ref rop.Value, op, e, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="e">The exponent.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int set_sj_2exp(mpfr_t rop, int op, long e, mpfr_rnd_t rnd)
    {
        return mpfr_set_sj_2exp(ref rop.Value, op, e, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="e">The exponent.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int set_z_2exp(mpfr_t rop, mpz_t op, long e, mpfr_rnd_t rnd)
    {
        return mpfr_set_z_2exp(ref rop.Value, ref op.Value, ToNativeExponent(e), ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="str">The string.</param>
    /// <param name="strbase">The string base.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="strbase"/> is not 0 or between 2 and 62, or <paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static bool set_str(mpfr_t rop, string str, uint strbase, mpfr_rnd_t rnd)
    {
        // MPFR aborts the process for another base.
        if (strbase is not (0 or (>= 2 and <= 62)))
            throw new ArgumentOutOfRangeException(nameof(strbase), strbase, "The base must be 0 or between 2 and 62.");

        return mpfr_set_str(ref rop.Value, str, strbase, ToNativeRounding(rnd, nameof(rnd))) == 0;
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
