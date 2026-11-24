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
    internal static long NativeLongMin => IsNativeLong32 ? int.MinValue : long.MinValue;

    /// <summary>
    /// Gets the largest value of a C long.
    /// </summary>
    internal static long NativeLongMax => IsNativeLong32 ? int.MaxValue : long.MaxValue;

    /// <summary>
    /// Gets the largest value of a C unsigned long.
    /// </summary>
    internal static ulong NativeULongMax => IsNativeLong32 ? uint.MaxValue : ulong.MaxValue;

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
    {
        long Value = value.Value;
        return Value > int.MaxValue ? int.MaxValue : Value < int.MinValue ? int.MinValue : (int)Value;
    }

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
