﻿namespace MpfrDotNet;

using System;
using System.Numerics;
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
        using mpz_t Temporary = new mpz_t(value);
        return new mpfr_t(Temporary);
    }

    /// <summary>
    /// Converts to a <see cref="byte"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static explicit operator byte(mpfr_t value)
    {
        return (byte)(uint)value;
    }

    /// <summary>
    /// Converts to a <see cref="int"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static explicit operator int(mpfr_t value)
    {
        return mpfr_get_sj(ref value.Value, (__mpfr_rnd_t)value.Rounding);
    }

    /// <summary>
    /// Converts to a <see cref="uint"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static explicit operator uint(mpfr_t value)
    {
        return mpfr_get_uj(ref value.Value, (__mpfr_rnd_t)value.Rounding);
    }

    /// <summary>
    /// Converts to a <see cref="short"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static explicit operator short(mpfr_t value)
    {
        return (short)(int)value;
    }

    /// <summary>
    /// Converts to a <see cref="ushort"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static explicit operator ushort(mpfr_t value)
    {
        return (ushort)(uint)value;
    }

    /// <summary>
    /// Converts to a <see cref="long"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static explicit operator long(mpfr_t value)
    {
        return mpfr.get_si(value, value.Rounding);
    }

    /// <summary>
    /// Converts to a <see cref="ulong"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static explicit operator ulong(mpfr_t value)
    {
        return mpfr.get_ui(value, value.Rounding);
    }

    /// <summary>
    /// Converts to a <see cref="float"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static explicit operator float(mpfr_t value)
    {
        return mpfr.get_flt(value, value.Rounding);
    }

    /// <summary>
    /// Converts to a <see cref="double"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static explicit operator double(mpfr_t value)
    {
        return mpfr.get_d(value, value.Rounding);
    }

    /// <summary>
    /// Converts to a <see cref="BigInteger"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static explicit operator BigInteger(mpfr_t value)
    {
        using mpz_t Temporary = new mpz_t();

        mpfr.get_z(Temporary, value, value.Rounding);

        BigInteger Result = (BigInteger)Temporary;
        return Result;
    }

    /// <summary>
    /// Converts to a <see cref="double"/> value and exponent.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="d">The double upon return.</param>
    /// <param name="e">The exponent upon return.</param>
    public static void ToDoubleAndExponent(mpfr_t value, out double d, out int e)
    {
        d = mpfr.get_d_2exp(out e, value, value.Rounding);
    }

    /// <summary>
    /// Convert to integral and fractional parts.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="e">The exponent upon return.</param>
    public static mpfr_t ToIntegralFractional(mpfr_t value, out int e)
    {
        mpfr_t y = new();

        mpfr.frexp(out e, y, value, value.Rounding);

        return y;
    }

    /// <summary>
    /// Converts to an integer value and exponent.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="e">The exponent upon return.</param>
    public static mpz_t ToIntegerAndExponent(mpfr_t value, out int e)
    {
        mpz_t Result = new();

        e = mpfr.get_z_2exp(Result, value);

        return Result;
    }

    /// <summary>
    /// Converts to a rational.
    /// </summary>
    /// <param name="value">The value.</param>
    public static mpq_t ToRational(mpfr_t value)
    {
        mpq_t Result = new();

        mpfr.get_q(Result, value);

        return Result;
    }

    /// <summary>
    /// Converts to a <see cref="mpf_t"/> floating-point value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static mpf_t ToFloatingPoint(mpfr_t value)
    {
        mpf_t Result = new();

        mpfr.get_f(Result, value, value.Rounding);

        return Result;
    }

    /// <summary>
    /// Gets a value indicating whether the number can be converted to a <see cref="ulong"/>.
    /// </summary>
    public bool FitsUnsignedLong
    {
        get { return mpfr.fits_ulong_p(this, Rounding); }
    }

    /// <summary>
    /// Gets a value indicating whether a number can be converted to a <see cref="long"/>.
    /// </summary>
    public bool FitsSignedLong
    {
        get { return mpfr.fits_slong_p(this, Rounding); }
    }

    /// <summary>
    /// Gets a value indicating whether a number can be converted to a <see cref="uint"/>.
    /// </summary>
    public bool FitsUnsignedInt
    {
        get { return mpfr.fits_uint_p(this, Rounding); }
    }

    /// <summary>
    /// Gets a value indicating whether a number can be converted to a <see cref="int"/>.
    /// </summary>
    public bool FitsSignedInt
    {
        get { return mpfr.fits_sint_p(this, Rounding); }
    }

    /// <summary>
    /// Gets a value indicating whether a number can be converted to a <see cref="ushort"/>.
    /// </summary>
    public bool FitsUnsignedShort
    {
        get { return mpfr.fits_ushort_p(this, Rounding); }
    }

    /// <summary>
    /// Gets a value indicating whether a number can be converted to a <see cref="short"/>.
    /// </summary>
    public bool FitsSignedShort
    {
        get { return mpfr.fits_sshort_p(this, Rounding); }
    }

    /// <summary>
    /// Gets a value indicating whether the number is an integer.
    /// </summary>
    public bool IsInteger
    {
        get { return mpfr.integer_p(this); }
    }
}
