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
    /// <exception cref="OverflowException">The numerator or the denominator of <paramref name="op"/> has more bits than the widest exponent range of MPFR, which only happens on Windows.</exception>
    public static int set_q(mpfr_t rop, mpq_t op, mpfr_rnd_t rnd)
    {
        CheckRationalOperand(op);

        return mpfr_set_q(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    /// <exception cref="OverflowException"><paramref name="op"/> has 2^25 limbs or more, and the precision of <paramref name="rop"/> is about 2^31 bits or more.</exception>
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

        // mpfr_set_f also computes the precision of op in bits, which wraps for 2^25 limbs or more: only the top limbs
        // are passed then.
        using mpf_t? Reduced = ReduceFloatOperand(op, get_prec(rop));

        return mpfr_set_f(ref rop.Value, ref (Reduced ?? op).Value, NativeRounding);
    }

    /// <summary>
    /// Gets a copy of a float operand with fewer limbs, when MPFR cannot compute its precision.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="precision">The precision of the MPFR number it is converted to or compared with.</param>
    /// <returns>The copy, or <see langword="null"/> if <paramref name="op"/> can be passed to MPFR.</returns>
    internal static mpf_t? ReduceFloatOperand(mpf_t op, ulong precision)
    {
        // mpfr_set_f computes the precision of op in an mpfr_prec_t, which is 32-bit on Windows, and mpfr_cmp_f computes
        // it in an int on every platform: both wrap for 2^25 limbs or more.
        ulong LimbCount = (ulong)Math.Abs(op.Value.Size);
        ulong Limit = Math.Min(PrecisionMax, int.MaxValue);
        if ((LimbCount + 1UL) * LimbBits <= Limit)
            return null;

        // The top limbs keep enough bits to round to the precision, and the lowest kept bit is set if a dropped limb
        // is not zero. This sticky bit is below the precision, so the result rounds and compares like op. The copy keeps
        // up to the limbs of its precision, plus two, which must also fit.
        ulong ReducedPrecision = precision + (3UL * LimbBits);
        if ((((ReducedPrecision + LimbBits - 1UL) / LimbBits) + 3UL) * LimbBits > Limit)
            throw new OverflowException("The float operand has too many limbs for the precision of the number.");

        mpf_t Reduced = new(ReducedPrecision);
        mpf.set(Reduced, op);

        int KeptCount = Math.Abs(Reduced.Value.Size);
        if (HasNonZeroLimb(op.Value.Limbs, (int)LimbCount - KeptCount))
        {
            long LowestLimb = Marshal.ReadInt64(Reduced.Value.Limbs);
            Marshal.WriteInt64(Reduced.Value.Limbs, LowestLimb | 1L);
        }

        GC.KeepAlive(op);

        return Reduced;
    }

    private static bool HasNonZeroLimb(IntPtr limbs, int count)
    {
        for (int i = 0; i < count; i++)
            if (Marshal.ReadInt64(NativeNumberArray.Offset(limbs, (long)i * sizeof(long))) != 0)
                return true;

        return false;
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
    /// <returns><see langword="true"/> if the number is below half the smallest positive number of the range; otherwise, <see langword="false"/>.</returns>
    internal static bool IsFarBelowExponentRange(long limbExponent, long minExponent)
    {
        // The product in bits overflows below long.MinValue / 64, which is far below any range. A magnitude below
        // 2^(emin - 1), the smallest positive number, still rounds up to it in some modes: the number must be below
        // 2^(emin - 2), half of it, to underflow like +1 or -1 scaled by the smallest native power of two.
        return limbExponent < long.MinValue / (long)LimbBits || (limbExponent * (long)LimbBits) + 1 < minExponent;
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
    /// <exception cref="ArgumentNullException"><paramref name="str"/> is <see langword="null"/>.</exception>
    public static bool set_str(mpfr_t rop, string str, uint strbase, mpfr_rnd_t rnd)
    {
        // The native function would dereference a null string.
        if (str is null)
            throw new ArgumentNullException(nameof(str));

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
