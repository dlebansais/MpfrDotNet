namespace MpfrDotNet;

using System;
using System.Runtime.InteropServices;
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
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a rounding mode of <see cref="mpfr_rnd_t"/>.</exception>
    public static int rint(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_rint(ref rop.Value, ref op.Value, ToNativeRoundingOrNearestAway(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static int ceil(mpfr_t rop, mpfr_t op)
    {
        return mpfr_ceil(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static int floor(mpfr_t rop, mpfr_t op)
    {
        return mpfr_floor(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static int round(mpfr_t rop, mpfr_t op)
    {
        return mpfr_round(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static int roundeven(mpfr_t rop, mpfr_t op)
    {
        return mpfr_roundeven(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static int trunc(mpfr_t rop, mpfr_t op)
    {
        return mpfr_trunc(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int rint_ceil(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_rint_ceil(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int rint_floor(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_rint_floor(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int rint_round(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_rint_round(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int rint_roundeven(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_rint_roundeven(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int rint_trunc(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_rint_trunc(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int frac(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_frac(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="iop">The integer result operand.</param>
    /// <param name="fop">The fractional result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    /// <exception cref="ArgumentException"><paramref name="iop"/> and <paramref name="fop"/> are the same number.</exception>
    public static int modf(mpfr_t iop, mpfr_t fop, mpfr_t op, mpfr_rnd_t rnd)
    {
        // MPFR aborts the process when the two results are the same number.
        if (ReferenceEquals(iop, fop))
            throw new ArgumentException("The integer and fractional parts must be different numbers.", nameof(fop));

        return mpfr_modf(ref iop.Value, ref fop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int fmod(mpfr_t r, mpfr_t x, mpfr_t y, mpfr_rnd_t rnd)
    {
        return mpfr_fmod(ref r.Value, ref x.Value, ref y.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int fmod_ui(mpfr_t r, mpfr_t x, ulong y, mpfr_rnd_t rnd)
    {
        return mpfr_fmod_ui(ref r.Value, ref x.Value, y, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="q">The q.</param>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int fmodquo(mpfr_t r, out long q, mpfr_t x, mpfr_t y, mpfr_rnd_t rnd)
    {
        int Result = mpfr_fmodquo(ref r.Value, out CLong NativeQuotient, ref x.Value, ref y.Value, ToNativeRounding(rnd, nameof(rnd)));
        q = NativeQuotient.Value;

        return Result;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int remainder(mpfr_t r, mpfr_t x, mpfr_t y, mpfr_rnd_t rnd)
    {
        return mpfr_remainder(ref r.Value, ref x.Value, ref y.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="q">The q.</param>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int remquo(mpfr_t r, out long q, mpfr_t x, mpfr_t y, mpfr_rnd_t rnd)
    {
        int Result = mpfr_remquo(ref r.Value, out CLong NativeQuotient, ref x.Value, ref y.Value, ToNativeRounding(rnd, nameof(rnd)));
        q = NativeQuotient.Value;

        return Result;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static void set_default_rounding_mode(mpfr_rnd_t rnd)
    {
        mpfr_set_default_rounding_mode(ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static mpfr_rnd_t get_default_rounding_mode()
    {
        return (mpfr_rnd_t)mpfr_get_default_rounding_mode();
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="x">The operand.</param>
    /// <param name="prec">The precision.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="prec"/> is lesser than <see cref="mpfr.PrecisionMin"/> or greater than <see cref="mpfr.PrecisionMax"/>, or <paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int prec_round(mpfr_t x, ulong prec, mpfr_rnd_t rnd)
    {
        return mpfr_prec_round(ref x.Value, ToNativePrecision(prec, nameof(prec)), ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="b">The operand.</param>
    /// <param name="err">The error.</param>
    /// <param name="rnd1">The first rounding mode.</param>
    /// <param name="rnd2">The second rounding mode.</param>
    /// <param name="prec">The precision.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="prec"/> is lesser than <see cref="mpfr.PrecisionMin"/> or greater than <see cref="mpfr.PrecisionMax"/>, or <paramref name="rnd1"/> is not a supported rounding mode, or <paramref name="rnd2"/> is not a supported rounding mode.</exception>
    public static bool can_round(mpfr_t b, int err, mpfr_rnd_t rnd1, mpfr_rnd_t rnd2, ulong prec)
    {
        return mpfr_can_round(ref b.Value, ToCLong(err), ToNativeRounding(rnd1, nameof(rnd1)), ToNativeRounding(rnd2, nameof(rnd2)), ToNativePrecision(prec, nameof(prec))) != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="x">The operand.</param>
    public static int min_prec(mpfr_t x)
    {
        return ToClampedInt(mpfr_min_prec(ref x.Value));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static string print_rnd_mode(mpfr_rnd_t rnd)
    {
        IntPtr Str = mpfr_print_rnd_mode(ToNativeRounding(rnd, nameof(rnd)));
        string Result = Marshal.PtrToStringAnsi(Str)!;

        return Result;
    }
}
