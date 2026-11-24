namespace MpfrDotNet;

using System;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public static partial class mpfr
{
    // In this build of MPFR, mpfr_prec_t, mpfr_exp_t, and the long and unsigned long parameters
    // of some functions are 32-bit, while the API exposes 64-bit values.

    /// <summary>
    /// Checks that a precision is supported by MPFR and converts it to the native type.
    /// </summary>
    /// <param name="precision">The precision.</param>
    /// <param name="paramName">The name of the parameter that holds the precision.</param>
    /// <returns>The precision as a native value.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="precision"/> is lesser than <see cref="PrecisionMin"/> or greater than <see cref="PrecisionMax"/>.</exception>
    internal static int ToNativePrecision(ulong precision, string paramName)
    {
        if (precision < NativeMinPrecision || precision > NativeMaxPrecision)
            throw new ArgumentOutOfRangeException(paramName, precision, $"The precision must be between {NativeMinPrecision} and {NativeMaxPrecision}.");

        return (int)precision;
    }

    /// <summary>
    /// Converts an exponent or a signed shift count to the native type, clamping it to the native range.
    /// </summary>
    /// <param name="value">The exponent or shift count.</param>
    /// <returns>The clamped value.</returns>
    /// <remarks>
    /// The exponent range of MPFR is much smaller than the native range, so a value beyond it overflows or underflows exactly as the clamped value does.
    /// </remarks>
    internal static int ToNativeExponent(long value)
        => value > int.MaxValue ? int.MaxValue : value < int.MinValue ? int.MinValue : (int)value;

    /// <summary>
    /// Converts an unsigned shift count to the native type, clamping it to the native range.
    /// </summary>
    /// <param name="value">The shift count.</param>
    /// <returns>The clamped value.</returns>
    /// <remarks>
    /// The exponent range of MPFR is much smaller than the native range, so a shift beyond it overflows exactly as the clamped value does.
    /// </remarks>
    internal static uint ToNativeShift(ulong value)
        => value > uint.MaxValue ? uint.MaxValue : (uint)value;
}
