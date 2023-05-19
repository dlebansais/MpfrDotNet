﻿namespace MpirDotNet;

using System;
using System.Text;

/// <summary>
/// See http://mpir.org/mpir-3.0.0.pdf.
/// </summary>
public partial class mpf_t : IDisposable, IEquatable<mpf_t>, ICloneable, IConvertible, IComparable, IComparable<mpf_t>
{
    /// <summary>
    /// Returns a string that represents the number value.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <returns>The number value.</returns>
    public override string ToString()
    {
        return ToString(mpz_t.DefaultBase);
    }

    /// <summary>
    /// Returns a string that represents the number value.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="resultbase">The base to use for the result.</param>
    /// <returns>The number value.</returns>
    public string ToString(int resultbase)
    {
        ulong SizeInDigits = Precision;

        StringBuilder Data = new StringBuilder((int)(SizeInDigits + 2));

        mpf.get_str(Data, out int Exponent, resultbase, SizeInDigits, this);

        string Result = Data.ToString();

        if (Result.Length == 0)
            return "0";

        int FractionalIndex = Result[0] == '-' ? 2 : 1;
        string IntegerPart = Result.Substring(0, FractionalIndex);

        string FractionalPart = Result.Substring(FractionalIndex);
        if (FractionalPart.Length > 0)
            FractionalPart = "." + FractionalPart;

        string ExponentPart = (Exponent - 1).ToString();
        if (Exponent > 0)
            ExponentPart = "+" + ExponentPart;

        Result = $"{IntegerPart}{FractionalPart}E{ExponentPart}";

        return Result;
    }

    /// <summary>
    /// Converts a <see cref="uint"/> value.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpf_t(uint value)
    {
        return new mpf_t(value);
    }

    /// <summary>
    /// Converts an <see cref="int"/> value.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpf_t(int value)
    {
        return new mpf_t(value);
    }

    /// <summary>
    /// Converts a <see cref="float"/> value.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpf_t(float value)
    {
        return new mpf_t((double)value);
    }

    /// <summary>
    /// Converts a <see cref="double"/> value.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpf_t(double value)
    {
        return new mpf_t(value);
    }

    /// <summary>
    /// Converts to a <see cref="byte"/> value.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static explicit operator byte(mpf_t value)
    {
        return (byte)mpf.get_ui(value);
    }

    /// <summary>
    /// Converts to an <see cref="sbyte"/> value.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static explicit operator sbyte(mpf_t value)
    {
        return (sbyte)mpf.get_si(value);
    }

    /// <summary>
    /// Converts to a <see cref="ushort"/> value.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static explicit operator ushort(mpf_t value)
    {
        return (ushort)mpf.get_ui(value);
    }

    /// <summary>
    /// Converts to an <see cref="short"/> value.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static explicit operator short(mpf_t value)
    {
        return (short)mpf.get_si(value);
    }

    /// <summary>
    /// Converts to a <see cref="uint"/> value.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static explicit operator uint(mpf_t value)
    {
        return (uint)mpf.get_ui(value);
    }

    /// <summary>
    /// Converts to an <see cref="int"/> value.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static explicit operator int(mpf_t value)
    {
        return (int)mpf.get_si(value);
    }

    /// <summary>
    /// Converts to a <see cref="ulong"/> value.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static explicit operator ulong(mpf_t value)
    {
        return (ulong)mpf.get_ui(value);
    }

    /// <summary>
    /// Converts to a <see cref="long"/> value.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static explicit operator long(mpf_t value)
    {
        return (long)mpf.get_si(value);
    }

    /// <summary>
    /// Converts to a <see cref="float"/> value.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static explicit operator float(mpf_t value)
    {
        return (float)(double)value;
    }

    /// <summary>
    /// Converts to a <see cref="double"/> value.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static explicit operator double(mpf_t value)
    {
        return mpf.get_d(value);
    }

    /// <summary>
    /// Converts to a double with an exponent returned separately.
    /// </summary>
    /// <param name="d">The double upon return.</param>
    /// <param name="exp">The exponent upon return.</param>
    public void GetDoubleWithExponent(out double d, out long exp)
    {
        mpf.get_d_2exp(this, out d, out exp);
    }

    /// <summary>
    /// Gets a value indicating whether the number can be converted to a <see cref="ulong"/>.
    /// </summary>
    public bool FitsUnsignedLong
    {
        get { return mpf.fits_ulong_p(this); }
    }

    /// <summary>
    /// Gets a value indicating whether a number can be converted to a <see cref="long"/>.
    /// </summary>
    public bool FitsSignedLong
    {
        get { return mpf.fits_slong_p(this); }
    }

    /// <summary>
    /// Gets a value indicating whether a number can be converted to a <see cref="uint"/>.
    /// </summary>
    public bool FitsUnsignedInt
    {
        get { return mpf.fits_uint_p(this); }
    }

    /// <summary>
    /// Gets a value indicating whether a number can be converted to a <see cref="int"/>.
    /// </summary>
    public bool FitsSignedInt
    {
        get { return mpf.fits_sint_p(this); }
    }

    /// <summary>
    /// Gets a value indicating whether a number can be converted to a <see cref="ushort"/>.
    /// </summary>
    public bool FitsUnsignedShort
    {
        get { return mpf.fits_ushort_p(this); }
    }

    /// <summary>
    /// Gets a value indicating whether a number can be converted to a <see cref="short"/>.
    /// </summary>
    public bool FitsSignedShort
    {
        get { return mpf.fits_sshort_p(this); }
    }
}
