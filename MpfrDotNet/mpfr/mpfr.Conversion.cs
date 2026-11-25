namespace MpfrDotNet;

using System;
using System.Runtime.InteropServices;
using System.Text;
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
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static float get_flt(mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_get_flt(ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static double get_d(mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_get_d(ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static long get_si(mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_get_si(ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static ulong get_ui(mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_get_ui(ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static long get_sj(mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_get_sj(ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static ulong get_uj(mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_get_uj(ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="exp">The exponent.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static double get_d_2exp(out int exp, mpfr_t op, mpfr_rnd_t rnd)
    {
        double Result = mpfr_get_d_2exp(out CLong NativeExponent, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
        exp = ToClampedInt(NativeExponent);

        return Result;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="exp">The exponent.</param>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int frexp(out int exp, mpfr_t x, mpfr_t y, mpfr_rnd_t rnd)
    {
        int Result = mpfr_frexp(out CLong NativeExponent, ref x.Value, ref y.Value, ToNativeRounding(rnd, nameof(rnd)));
        exp = ToClampedInt(NativeExponent);

        return Result;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static int get_z_2exp(mpz_t rop, mpfr_t op)
    {
        return ToClampedInt(mpfr_get_z_2exp(ref rop.Value, ref op.Value));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int get_z(mpz_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_get_z(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void get_q(mpq_t rop, mpfr_t op)
    {
        mpfr_get_q(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int get_f(mpf_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_get_f(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="b">The b.</param>
    /// <param name="p">The p.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="b"/> is not between 2 and 62, or <paramref name="p"/> is lesser than <see cref="mpfr.PrecisionMin"/> or greater than <see cref="mpfr.PrecisionMax"/>.</exception>
    public static ulong get_str_ndigits(int b, ulong p)
    {
        // MPFR aborts the process for another base.
        if (b is < 2 or > 62)
            throw new ArgumentOutOfRangeException(nameof(b), b, "The base must be between 2 and 62.");

        return mpfr_get_str_ndigits(b, ToNativePrecision(p, nameof(p)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="str">The string.</param>
    /// <param name="expptr">The exponent.</param>
    /// <param name="strbase">The base.</param>
    /// <param name="n">The n.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <remarks>The capacity of <paramref name="str"/> is increased to the size of the result, if needed.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="str"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="strbase"/> is not between 2 and 62, or between -36 and -2, or <paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static void get_str(StringBuilder str, out int expptr, int strbase, ulong n, mpfr_t op, mpfr_rnd_t rnd)
    {
        // The native function writes as many characters as the value needs into the buffer allocated for the capacity,
        // and allocates a string that would leak when the buffer is null.
        if (str is null)
            throw new ArgumentNullException(nameof(str));

        uint DigitCountBase = MpirDotNet.DigitBase.ToDigitCountBase(strbase, nameof(strbase));
        ulong Digits = n == 0 ? get_str_ndigits((int)DigitCountBase, get_prec(op)) : n;

        // MPFR requires max(n + 2, 7) characters: the digits, a minus sign and the terminating null character, and 7 for
        // "-@Inf@" whatever the precision.
        _ = str.EnsureCapacity(checked((int)Math.Max(Digits + 2, 7)));

        mpfr_get_str(str, out CLong NativeExponent, strbase, n, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
        expptr = ToClampedInt(NativeExponent);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static bool fits_ulong_p(mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_fits_ulong_p(ref op.Value, ToNativeRounding(rnd, nameof(rnd))) != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static bool fits_slong_p(mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_fits_slong_p(ref op.Value, ToNativeRounding(rnd, nameof(rnd))) != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static bool fits_uint_p(mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_fits_uint_p(ref op.Value, ToNativeRounding(rnd, nameof(rnd))) != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static bool fits_sint_p(mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_fits_sint_p(ref op.Value, ToNativeRounding(rnd, nameof(rnd))) != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static bool fits_ushort_p(mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_fits_ushort_p(ref op.Value, ToNativeRounding(rnd, nameof(rnd))) != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static bool fits_sshort_p(mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_fits_sshort_p(ref op.Value, ToNativeRounding(rnd, nameof(rnd))) != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool integer_p(mpfr_t op)
    {
        return mpfr_integer_p(ref op.Value) != 0;
    }
}
