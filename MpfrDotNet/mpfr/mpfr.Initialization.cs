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
    /// <param name="x">The value.</param>
    /// <param name="prec">The precision.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="prec"/> is lesser than <see cref="mpfr.PrecisionMin"/> or greater than <see cref="mpfr.PrecisionMax"/>.</exception>
    public static void init2(mpfr_t x, ulong prec)
    {
        mpfr_init2(ref x.Value, ToNativePrecision(prec, nameof(prec)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="prec">The precision.</param>
    /// <param name="x">The values.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="prec"/> is lesser than <see cref="mpfr.PrecisionMin"/> or greater than <see cref="mpfr.PrecisionMax"/>.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="x"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="x"/> contains a <see langword="null"/> item.</exception>
    public static void inits2(ulong prec, params mpfr_t[] x)
    {
        CLong NativePrecision = ToNativePrecision(prec, nameof(prec));
        ArrayArgument.CheckItems(x, nameof(x));

        foreach (mpfr_t Item in x)
            mpfr_init2(ref Item.Value, NativePrecision);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="x">The value.</param>
    public static void clear(mpfr_t x)
    {
        mpfr_clear(ref x.Value);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="x">The values.</param>
    /// <exception cref="ArgumentNullException"><paramref name="x"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="x"/> contains a <see langword="null"/> item.</exception>
    public static void clears(params mpfr_t[] x)
    {
        ArrayArgument.CheckItems(x, nameof(x));

        foreach (mpfr_t Item in x)
            mpfr_clear(ref Item.Value);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="x">The value.</param>
    public static void init(mpfr_t x)
    {
        mpfr_init(ref x.Value);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="x">The values.</param>
    /// <exception cref="ArgumentNullException"><paramref name="x"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="x"/> contains a <see langword="null"/> item.</exception>
    public static void inits(params mpfr_t[] x)
    {
        ArrayArgument.CheckItems(x, nameof(x));

        foreach (mpfr_t Item in x)
            mpfr_init(ref Item.Value);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="prec">The precision.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="prec"/> is lesser than <see cref="mpfr.PrecisionMin"/> or greater than <see cref="mpfr.PrecisionMax"/>.</exception>
    public static void set_default_prec(ulong prec)
    {
        mpfr_set_default_prec(ToNativePrecision(prec, nameof(prec)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static ulong get_default_prec()
    {
        return (ulong)mpfr_get_default_prec().Value;
    }

    /// <summary>
    /// Gets the minimum precision.
    /// </summary>
    public static ulong PrecisionMin { get { return NativeMinPrecision; } }

    /// <summary>
    /// Gets the maximum precision.
    /// </summary>
    public static ulong PrecisionMax { get { return NativeMaxPrecision; } }

    /// <summary>
    /// Gets the default precision.
    /// </summary>
    public static ulong PrecisionDefault { get { return NativeDefaultPrecision; } }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="x">The value.</param>
    /// <param name="prec">The precision.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="prec"/> is lesser than <see cref="mpfr.PrecisionMin"/> or greater than <see cref="mpfr.PrecisionMax"/>.</exception>
    public static void set_prec(mpfr_t x, ulong prec)
    {
        mpfr_set_prec(ref x.Value, ToNativePrecision(prec, nameof(prec)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="x">The value.</param>
    public static ulong get_prec(mpfr_t x)
    {
        return (ulong)mpfr_get_prec(ref x.Value).Value;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="x">The value.</param>
    /// <param name="prec">The precision.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="prec"/> is lesser than <see cref="mpfr.PrecisionMin"/> or greater than <see cref="mpfr.PrecisionMax"/>.</exception>
    public static void set_prec_raw(mpfr_t x, ulong prec)
    {
        mpfr_set_prec_raw(ref x.Value, ToNativePrecision(prec, nameof(prec)));
    }
}
