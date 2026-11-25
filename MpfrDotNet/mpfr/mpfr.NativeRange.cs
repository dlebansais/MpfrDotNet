namespace MpfrDotNet;

using System;
using System.Runtime.InteropServices;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public static partial class mpfr
{
    // mpfr_prec_t, mpfr_exp_t, and the long and unsigned long parameters of some functions are a C long,
    // which is 32-bit on Windows and 64-bit on Linux, while the API exposes 64-bit values.
    private static readonly bool IsNativeLong32 = Marshal.SizeOf<CLong>() == 4;

    /// <summary>
    /// Gets the smallest value of a C long.
    /// </summary>
    internal static long NativeLongMin => GetNativeLongMin(IsNativeLong32);

    /// <summary>
    /// Gets the largest value of a C long.
    /// </summary>
    internal static long NativeLongMax => GetNativeLongMax(IsNativeLong32);

    /// <summary>
    /// Gets the largest value of a C unsigned long.
    /// </summary>
    internal static ulong NativeULongMax => GetNativeULongMax(IsNativeLong32);

    /// <summary>
    /// Gets the smallest value of a C long of the given size.
    /// </summary>
    /// <param name="isNativeLong32">True if a C long is 32-bit, false if it is 64-bit.</param>
    internal static long GetNativeLongMin(bool isNativeLong32)
        => isNativeLong32 ? int.MinValue : long.MinValue;

    /// <summary>
    /// Gets the largest value of a C long of the given size.
    /// </summary>
    /// <param name="isNativeLong32">True if a C long is 32-bit, false if it is 64-bit.</param>
    internal static long GetNativeLongMax(bool isNativeLong32)
        => isNativeLong32 ? int.MaxValue : long.MaxValue;

    /// <summary>
    /// Gets the largest value of a C unsigned long of the given size.
    /// </summary>
    /// <param name="isNativeLong32">True if a C long is 32-bit, false if it is 64-bit.</param>
    internal static ulong GetNativeULongMax(bool isNativeLong32)
        => isNativeLong32 ? uint.MaxValue : ulong.MaxValue;

    /// <summary>
    /// Checks that a rounding mode is supported by the MPFR functions other than mpfr_rint and mpfr_subnormalize.
    /// </summary>
    /// <param name="rnd">The rounding mode.</param>
    /// <param name="paramName">The name of the parameter that holds the rounding mode.</param>
    /// <returns><paramref name="rnd"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is <see cref="mpfr_rnd_t.MPFR_RNDNA"/> or not a value of <see cref="mpfr_rnd_t"/>.</exception>
    internal static mpfr_rnd_t CheckRounding(mpfr_rnd_t rnd, string paramName)
    {
        // MPFR supports MPFR_RNDNA only in mpfr_rint, and aborts the process in other functions, as with an invalid mode.
        if (rnd is < mpfr_rnd_t.MPFR_RNDN or > mpfr_rnd_t.MPFR_RNDF)
            throw new ArgumentOutOfRangeException(paramName, rnd, UnsupportedRoundingMessage);

        return rnd;
    }

    /// <summary>
    /// Converts a rounding mode for the MPFR functions other than mpfr_rint and mpfr_subnormalize.
    /// </summary>
    /// <param name="rnd">The rounding mode.</param>
    /// <param name="paramName">The name of the parameter that holds the rounding mode.</param>
    /// <returns>The native rounding mode.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is <see cref="mpfr_rnd_t.MPFR_RNDNA"/> or not a value of <see cref="mpfr_rnd_t"/>.</exception>
    internal static __mpfr_rnd_t ToNativeRounding(mpfr_rnd_t rnd, string paramName)
        => (__mpfr_rnd_t)CheckRounding(rnd, paramName);

    /// <summary>
    /// Converts a rounding mode for mpfr_rint and mpfr_subnormalize, which also support <see cref="mpfr_rnd_t.MPFR_RNDNA"/>.
    /// </summary>
    /// <param name="rnd">The rounding mode.</param>
    /// <param name="paramName">The name of the parameter that holds the rounding mode.</param>
    /// <returns>The native rounding mode.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a value of <see cref="mpfr_rnd_t"/>.</exception>
    internal static __mpfr_rnd_t ToNativeRoundingOrNearestAway(mpfr_rnd_t rnd, string paramName)
        => rnd == mpfr_rnd_t.MPFR_RNDNA ? __mpfr_rnd_t.MPFR_RNDNA : ToNativeRounding(rnd, paramName);

    /// <summary>
    /// The message of the exception thrown for a rounding mode that MPFR does not support.
    /// </summary>
    internal const string UnsupportedRoundingMessage = "The rounding mode must be MPFR_RNDN, MPFR_RNDZ, MPFR_RNDU, MPFR_RNDD, MPFR_RNDA or MPFR_RNDF.";

    /// <summary>
    /// Converts a value that is in the range of a C long.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The native value.</returns>
    internal static CLong ToCLong(long value)
#if NET6_0_OR_GREATER
        => new((nint)value);
#else
        => new((int)value);
#endif

    /// <summary>
    /// Converts a value that is in the range of a C unsigned long.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The native value.</returns>
    internal static CULong ToCULong(ulong value)
#if NET6_0_OR_GREATER
        => new((nuint)value);
#else
        => new((uint)value);
#endif

    /// <summary>
    /// Converts a native value to an <see cref="int"/>, clamping it to the range of <see cref="int"/>.
    /// </summary>
    /// <param name="value">The native value.</param>
    /// <returns>The clamped value.</returns>
    /// <remarks>
    /// Exponents are 32-bit in this API. On Linux, only limits such as the smallest allowed minimum exponent exceed that range.
    /// </remarks>
    internal static int ToClampedInt(CLong value)
        => ClampToInt((long)value.Value);

    /// <summary>
    /// Converts a value to an <see cref="int"/>, clamping it to the range of <see cref="int"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The clamped value.</returns>
    internal static int ClampToInt(long value)
        => value > int.MaxValue ? int.MaxValue : value < int.MinValue ? int.MinValue : (int)value;

    /// <summary>
    /// Checks that a precision is supported by MPFR and converts it to the native type.
    /// </summary>
    /// <param name="precision">The precision.</param>
    /// <param name="paramName">The name of the parameter that holds the precision.</param>
    /// <returns>The precision as a native value.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="precision"/> is lesser than <see cref="PrecisionMin"/> or greater than <see cref="PrecisionMax"/>.</exception>
    internal static CLong ToNativePrecision(ulong precision, string paramName)
    {
        if (precision < NativeMinPrecision || precision > NativeMaxPrecision)
            throw new ArgumentOutOfRangeException(paramName, precision, $"The precision must be between {NativeMinPrecision} and {NativeMaxPrecision}.");

        return ToCLong((long)precision);
    }

    /// <summary>
    /// Converts an exponent or a signed shift count to the native type, clamping it to the native range.
    /// </summary>
    /// <param name="value">The exponent or shift count.</param>
    /// <returns>The clamped value.</returns>
    /// <remarks>
    /// The exponent range of MPFR is much smaller than the native range, so a value beyond it overflows or underflows exactly as the clamped value does.
    /// </remarks>
    internal static CLong ToNativeExponent(long value)
        => ToCLong(value > NativeLongMax ? NativeLongMax : value < NativeLongMin ? NativeLongMin : value);

    /// <summary>
    /// Clamps an unsigned shift count to the range of a C unsigned long.
    /// </summary>
    /// <param name="value">The shift count.</param>
    /// <returns>The clamped value.</returns>
    /// <remarks>
    /// The exponent range of MPFR is much smaller than the native range, so a shift beyond it overflows exactly as the clamped value does.
    /// </remarks>
    internal static ulong ClampToNativeShift(ulong value)
        => value > NativeULongMax ? NativeULongMax : value;
}
