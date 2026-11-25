namespace MpfrDotNet;

using System;
using System.Numerics;
using System.Runtime.InteropServices;
using MpirDotNet;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public partial class mpfr_t : IDisposable
{
    /// <summary>
    /// Converts from a <see cref="byte"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpfr_t(byte value)
    {
        return new mpfr_t((uint)value);
    }

    /// <summary>
    /// Converts from a <see cref="int"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpfr_t(int value)
    {
        return new mpfr_t(value);
    }

    /// <summary>
    /// Converts from a <see cref="uint"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpfr_t(uint value)
    {
        return new mpfr_t(value);
    }

    /// <summary>
    /// Converts from a <see cref="short"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpfr_t(short value)
    {
        return new mpfr_t(value);
    }

    /// <summary>
    /// Converts from a <see cref="ushort"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpfr_t(ushort value)
    {
        return new mpfr_t(value);
    }

    /// <summary>
    /// Converts from a <see cref="long"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpfr_t(long value)
    {
        return new mpfr_t(value);
    }

    /// <summary>
    /// Converts from a <see cref="ulong"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpfr_t(ulong value)
    {
        return new mpfr_t(value);
    }

    /// <summary>
    /// Converts from a <see cref="float"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpfr_t(float value)
    {
        return new mpfr_t((double)value);
    }

    /// <summary>
    /// Converts from a <see cref="double"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpfr_t(double value)
    {
        return new mpfr_t(value);
    }

    /// <summary>
    /// Converts from a <see cref="BigInteger"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpfr_t(BigInteger value)
    {
        using mpz_t Temporary = new(value);
        return new mpfr_t(Temporary);
    }

    /// <summary>
    /// Converts to a <see cref="byte"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="OverflowException">The value is NaN, an infinity, or outside the range of the target type after rounding.</exception>
    /// <exception cref="ObjectDisposedException"><paramref name="value"/> is disposed.</exception>
    public static explicit operator byte(mpfr_t value)
    {
        using mpz_t Integer = value.ToRoundedInteger();
        return (byte)Integer;
    }

    /// <summary>
    /// Converts to a <see cref="int"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="OverflowException">The value is NaN, an infinity, or outside the range of the target type after rounding.</exception>
    /// <exception cref="ObjectDisposedException"><paramref name="value"/> is disposed.</exception>
    public static explicit operator int(mpfr_t value)
    {
        using mpz_t Integer = value.ToRoundedInteger();
        return (int)Integer;
    }

    /// <summary>
    /// Converts to a <see cref="uint"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="OverflowException">The value is NaN, an infinity, or outside the range of the target type after rounding.</exception>
    /// <exception cref="ObjectDisposedException"><paramref name="value"/> is disposed.</exception>
    public static explicit operator uint(mpfr_t value)
    {
        using mpz_t Integer = value.ToRoundedInteger();
        return (uint)Integer;
    }

    /// <summary>
    /// Converts to a <see cref="short"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="OverflowException">The value is NaN, an infinity, or outside the range of the target type after rounding.</exception>
    /// <exception cref="ObjectDisposedException"><paramref name="value"/> is disposed.</exception>
    public static explicit operator short(mpfr_t value)
    {
        using mpz_t Integer = value.ToRoundedInteger();
        return (short)Integer;
    }

    /// <summary>
    /// Converts to a <see cref="ushort"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="OverflowException">The value is NaN, an infinity, or outside the range of the target type after rounding.</exception>
    /// <exception cref="ObjectDisposedException"><paramref name="value"/> is disposed.</exception>
    public static explicit operator ushort(mpfr_t value)
    {
        using mpz_t Integer = value.ToRoundedInteger();
        return (ushort)Integer;
    }

    /// <summary>
    /// Converts to a <see cref="long"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="OverflowException">The value is NaN, an infinity, or outside the range of the target type after rounding.</exception>
    /// <exception cref="ObjectDisposedException"><paramref name="value"/> is disposed.</exception>
    public static explicit operator long(mpfr_t value)
    {
        using mpz_t Integer = value.ToRoundedInteger();
        return (long)Integer;
    }

    /// <summary>
    /// Converts to a <see cref="ulong"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="OverflowException">The value is NaN, an infinity, or outside the range of the target type after rounding.</exception>
    /// <exception cref="ObjectDisposedException"><paramref name="value"/> is disposed.</exception>
    public static explicit operator ulong(mpfr_t value)
    {
        using mpz_t Integer = value.ToRoundedInteger();
        return (ulong)Integer;
    }

    /// <summary>
    /// Converts to a <see cref="float"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="value"/> is disposed.</exception>
    public static explicit operator float(mpfr_t value)
    {
        ThrowIfDisposed(value);

        return mpfr.get_flt(value, value.Rounding);
    }

    /// <summary>
    /// Converts to a <see cref="double"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="value"/> is disposed.</exception>
    public static explicit operator double(mpfr_t value)
    {
        ThrowIfDisposed(value);

        return mpfr.get_d(value, value.Rounding);
    }

    /// <summary>
    /// Converts to a <see cref="BigInteger"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="OverflowException"><paramref name="value"/> is NaN or an infinity.</exception>
    /// <exception cref="ObjectDisposedException"><paramref name="value"/> is disposed.</exception>
    public static explicit operator BigInteger(mpfr_t value)
    {
        using mpz_t Integer = value.ToRoundedInteger();

        return (BigInteger)Integer;
    }

    /// <summary>
    /// Converts to a <see cref="double"/> value and exponent.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="d">The double upon return.</param>
    /// <param name="e">The exponent upon return.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="value"/> is disposed.</exception>
    public static void ToDoubleAndExponent(mpfr_t value, out double d, out int e)
    {
        ThrowIfDisposed(value);

        d = mpfr.get_d_2exp(out e, value, value.Rounding);
    }

    /// <summary>
    /// Convert to integral and fractional parts.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="e">The exponent upon return.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="value"/> is disposed.</exception>
    public static mpfr_t ToIntegralFractional(mpfr_t value, out int e)
    {
        ThrowIfDisposed(value);

        mpfr_t y = CreateResult(value);

        y.LastTernaryResult = mpfr.frexp(out e, y, value, value.Rounding);

        return y;
    }

    /// <summary>
    /// Converts to an integer value and exponent.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="e">The exponent upon return.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="value"/> is disposed.</exception>
    /// <exception cref="OverflowException"><paramref name="value"/> is NaN or an infinity.</exception>
    public static mpz_t ToIntegerAndExponent(mpfr_t value, out int e)
    {
        ThrowIfSingular(value, "an integer");

        mpz_t Result = new();

        e = mpfr.get_z_2exp(Result, value);

        return Result;
    }

    /// <summary>
    /// Converts to a rational.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="value"/> is disposed.</exception>
    /// <exception cref="OverflowException"><paramref name="value"/> is NaN or an infinity.</exception>
    public static mpq_t ToRational(mpfr_t value)
    {
        ThrowIfSingular(value, "a rational number");

        mpq_t Result = new();

        mpfr.get_q(Result, value);

        return Result;
    }

    /// <summary>
    /// Converts to a <see cref="mpf_t"/> floating-point value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="value"/> is disposed.</exception>
    /// <exception cref="OverflowException"><paramref name="value"/> is NaN or an infinity.</exception>
    public static mpf_t ToFloatingPoint(mpfr_t value)
    {
        ThrowIfSingular(value, "an mpf_t");

        mpf_t Result = new();

        mpfr.get_f(Result, value, value.Rounding);

        return Result;
    }

    /// <summary>
    /// Gets a value indicating whether the number can be converted to a <see cref="ulong"/>.
    /// </summary>
    /// <exception cref="ObjectDisposedException">The number is disposed.</exception>
    public bool FitsUnsignedLong
    {
        get
        {
            ThrowIfDisposed(this);

            return mpfr.fits_ulong_p(this, Rounding);
        }
    }

    /// <summary>
    /// Gets a value indicating whether a number can be converted to a <see cref="long"/>.
    /// </summary>
    /// <exception cref="ObjectDisposedException">The number is disposed.</exception>
    public bool FitsSignedLong
    {
        get
        {
            ThrowIfDisposed(this);

            return mpfr.fits_slong_p(this, Rounding);
        }
    }

    /// <summary>
    /// Gets a value indicating whether a number can be converted to a <see cref="uint"/>.
    /// </summary>
    /// <exception cref="ObjectDisposedException">The number is disposed.</exception>
    public bool FitsUnsignedInt
    {
        get
        {
            ThrowIfDisposed(this);

            return mpfr.fits_uint_p(this, Rounding);
        }
    }

    /// <summary>
    /// Gets a value indicating whether a number can be converted to a <see cref="int"/>.
    /// </summary>
    /// <exception cref="ObjectDisposedException">The number is disposed.</exception>
    public bool FitsSignedInt
    {
        get
        {
            ThrowIfDisposed(this);

            return mpfr.fits_sint_p(this, Rounding);
        }
    }

    /// <summary>
    /// Gets a value indicating whether a number can be converted to a <see cref="ushort"/>.
    /// </summary>
    /// <exception cref="ObjectDisposedException">The number is disposed.</exception>
    public bool FitsUnsignedShort
    {
        get
        {
            ThrowIfDisposed(this);

            return mpfr.fits_ushort_p(this, Rounding);
        }
    }

    /// <summary>
    /// Gets a value indicating whether a number can be converted to a <see cref="short"/>.
    /// </summary>
    /// <exception cref="ObjectDisposedException">The number is disposed.</exception>
    public bool FitsSignedShort
    {
        get
        {
            ThrowIfDisposed(this);

            return mpfr.fits_sshort_p(this, Rounding);
        }
    }

    /// <summary>
    /// Gets a value indicating whether the number is an integer.
    /// </summary>
    /// <exception cref="ObjectDisposedException">The number is disposed.</exception>
    public bool IsInteger
    {
        get
        {
            ThrowIfDisposed(this);

            return mpfr.integer_p(this);
        }
    }

    // mpfr_get_z, mpfr_get_z_2exp and mpfr_get_q return 0 for NaN and infinities, and mpfr_get_f returns 0 for NaN and a
    // number with an exponent beyond the range of mpf_t for infinities.
    private static void ThrowIfSingular(mpfr_t value, string target)
    {
        // IsNumber also checks that value is not disposed.
        if (!value.IsNumber)
            throw new OverflowException($"NaN and infinities cannot be converted to {target}.");
    }

    private mpz_t ToRoundedInteger()
    {
        ThrowIfSingular(this, "an integer");

        mpz_t Result = new();
        _ = mpfr.get_z(Result, this, Rounding);

        return Result;
    }

    /// <summary>
    /// Rounds a value once to the nearest <see cref="double"/> or <see cref="float"/>, ties to even, including in their subnormal range.
    /// </summary>
    /// <param name="setValue">Sets a number to the value with round to nearest, and returns the ternary value.</param>
    /// <param name="isSingle">True to round to a <see cref="float"/>, false to round to a <see cref="double"/>.</param>
    /// <returns>The rounded value, which converts exactly to the target type.</returns>
    internal static double RoundToBinaryFormat(Func<mpfr_t, int> setValue, bool isSingle)
    {
        // The recipe of the MPFR manual for IEEE 754 formats: round to the precision of the format within its exponent
        // range, then subnormalize. The exponent range is per thread, and is restored before returning.
        ulong FormatPrecision = isSingle ? 24UL : 53UL;
        long FormatMinExponent = isSingle ? -148L : -1073L;
        long FormatMaxExponent = isSingle ? 128L : 1024L;

        using mpfr_t Result = CreateWithPrecision(FormatPrecision, nameof(isSingle));
        CLong SavedMinExponent = mpfr_get_emin();
        CLong SavedMaxExponent = mpfr_get_emax();

        _ = mpfr_set_emin(mpfr.ToCLong(FormatMinExponent));
        _ = mpfr_set_emax(mpfr.ToCLong(FormatMaxExponent));

        try
        {
            int Ternary = setValue(Result);
            _ = mpfr.subnormalize(Result, Ternary, mpfr_rnd_t.MPFR_RNDN);
        }
        finally
        {
            _ = mpfr_set_emin(SavedMinExponent);
            _ = mpfr_set_emax(SavedMaxExponent);
        }

        return mpfr.get_d(Result, mpfr_rnd_t.MPFR_RNDN);
    }
}
