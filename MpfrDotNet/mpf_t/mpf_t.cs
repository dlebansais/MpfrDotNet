namespace MpirDotNet;

using System;
using System.Text;
using static Interop.Mpir.NativeMethods;

/// <summary>
/// See http://mpir.org/mpir-3.0.0.pdf.
/// </summary>
public class mpf_t : IDisposable, IEquatable<mpf_t>, ICloneable, IConvertible, IComparable, IComparable<mpf_t>
{
    #region Init
    /// <summary>
    /// Initializes a new instance of the <see cref="mpf_t"/> class.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="precision">The precision.</param>
    public mpf_t(ulong precision = ulong.MaxValue)
    {
        if (precision == ulong.MaxValue)
            mpf_init(ref Value);
        else
            mpf_init2(ref Value, (mp_bitcnt_t)precision);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpf_t"/> class.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The value.</param>
    /// <param name="precision">The precision.</param>
    public mpf_t(ulong n, ulong precision)
    {
        if (precision == ulong.MaxValue)
            mpf_init_set_ui(ref Value, (mpir_ui)n);
        else
        {
            mpf_init2(ref Value, (mp_bitcnt_t)precision);
            mpf_set_ui(ref Value, (mpir_ui)n);
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpf_t"/> class.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The value.</param>
    /// <param name="precision">The precision.</param>
    public mpf_t(long n, ulong precision = ulong.MaxValue)
    {
        if (precision == ulong.MaxValue)
            mpf_init_set_si(ref Value, (mpir_si)n);
        else
        {
            mpf_init2(ref Value, (mp_bitcnt_t)precision);
            mpf_set_si(ref Value, (mpir_si)n);
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpf_t"/> class.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="d">The value.</param>
    /// <param name="precision">The precision.</param>
    public mpf_t(double d, ulong precision = ulong.MaxValue)
    {
        if (precision == ulong.MaxValue)
            mpf_init_set_d(ref Value, d);
        else
        {
            mpf_init2(ref Value, (mp_bitcnt_t)precision);
            mpf_set_d(ref Value, d);
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpf_t"/> class.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="s">The value.</param>
    /// <param name="precision">The precision.</param>
    public mpf_t(string s, ulong precision = ulong.MaxValue)
        : this(s, mpz_t.DefaultBase, precision)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpf_t"/> class.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="s">The value.</param>
    /// <param name="strBase">The base.</param>
    /// <param name="precision">The precision.</param>
    public mpf_t(string s, uint strBase, ulong precision = ulong.MaxValue)
    {
        int Success;

        if (precision == ulong.MaxValue)
            Success = mpf_init_set_str(ref Value, s, strBase);
        else
        {
            mpf_init2(ref Value, (mp_bitcnt_t)precision);
            Success = mpf_set_str(ref Value, s, strBase);
        }

        if (Success != 0)
            throw new ArgumentException();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpf_t"/> class.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="other">The value.</param>
    /// <param name="useDefaultPrecision">True to use the default precision.</param>
    public mpf_t(mpf_t other, bool useDefaultPrecision = false)
    {
        if (useDefaultPrecision)
        {
            mpf_init_set(ref Value, ref other.Value);
        }
        else
        {
            mpf_init2(ref Value, mpf_get_prec(ref other.Value));
            mpf_set(ref Value, ref other.Value);
        }
    }

#pragma warning disable SA1401 // Fields should be private
#pragma warning disable SA1600 // Elements should be documented
    internal __mpf_t Value;
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore SA1600 // Elements should be documented
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the default precision.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    public static ulong DefaultPrecision
    {
        get
        {
            return (ulong)mpf_get_default_prec();
        }
        set
        {
            mpf_set_default_prec((mp_bitcnt_t)value);
        }
    }

    /// <summary>
    /// Gets or sets the precision.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    public ulong Precision
    {
        get
        {
            return (ulong)mpf_get_prec(ref Value);
        }
        set
        {
            mpf_set_prec(ref Value, (mp_bitcnt_t)value);
        }
    }

    /// <summary>
    /// Gets a value indicating whether the number is an integer.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    public bool IsInteger
    {
        get
        {
            return mpf_integer_p(ref Value) != 0;
        }
    }
    #endregion

    #region Conversions
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

        mp_exp_t ExponentStruct;
        mpf_get_str(Data, out ExponentStruct, resultbase, (size_t)SizeInDigits, ref Value);
        int Exponent = (int)ExponentStruct;

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
    /// Converts to a <see cref="uint"/> value.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static explicit operator uint(mpf_t value)
    {
        return (uint)mpf_get_ui(ref value.Value);
    }

    /// <summary>
    /// Converts to an <see cref="int"/> value.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static explicit operator int(mpf_t value)
    {
        return (int)mpf_get_si(ref value.Value);
    }

    /// <summary>
    /// Converts to a <see cref="ulong"/> value.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static explicit operator ulong(mpf_t value)
    {
        return (ulong)mpf_get_ui(ref value.Value);
    }

    /// <summary>
    /// Converts to a <see cref="long"/> value.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static explicit operator long(mpf_t value)
    {
        return (long)mpf_get_si(ref value.Value);
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
        return mpf_get_d(ref value.Value);
    }
    #endregion

    #region Operators
    /// <summary>
    /// Adds two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpf_t operator +(mpf_t x, mpf_t y)
    {
        mpf_t z = new();

        mpf_add(ref z.Value, ref x.Value, ref y.Value);

        return z;
    }

    /// <summary>
    /// Adds two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpf_t operator +(mpf_t x, long y)
    {
        mpf_t z = new();

        if (y >= 0)
            mpf_add_ui(ref z.Value, ref x.Value, (mpir_ui)(ulong)y);
        else
            mpf_sub_ui(ref z.Value, ref x.Value, (mpir_ui)(ulong)-y);

        return z;
    }

    /// <summary>
    /// Adds two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpf_t operator +(long x, mpf_t y)
    {
        mpf_t z = new();

        if (x >= 0)
            mpf_add_ui(ref z.Value, ref y.Value, (mpir_ui)(ulong)x);
        else
            mpf_sub_ui(ref z.Value, ref y.Value, (mpir_ui)(ulong)-x);

        return z;
    }

    /// <summary>
    /// Adds two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpf_t operator +(mpf_t x, ulong y)
    {
        mpf_t z = new mpf_t();

        mpf_add_ui(ref z.Value, ref x.Value, (mpir_ui)y);

        return z;
    }

    /// <summary>
    /// Adds two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpf_t operator +(ulong x, mpf_t y)
    {
        mpf_t z = new mpf_t();

        mpf_add_ui(ref z.Value, ref y.Value, (mpir_ui)x);

        return z;
    }

    /// <summary>
    /// Subtracts two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpf_t operator -(mpf_t x, mpf_t y)
    {
        mpf_t z = new mpf_t();

        mpf_sub(ref z.Value, ref x.Value, ref y.Value);

        return z;
    }

    /// <summary>
    /// Subtracts two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpf_t operator -(long x, mpf_t y)
    {
        if (x >= 0)
        {
            mpf_t z = new mpf_t();

            mpf_ui_sub(ref z.Value, (mpir_ui)(ulong)x, ref y.Value);

            return z;
        }
        else
        {
            mpf_t z = new mpf_t();

            mpf_add_ui(ref z.Value, ref y.Value, (mpir_ui)(ulong)-x);
            mpf_neg(ref z.Value, ref z.Value);

            return z;
        }
    }

    /// <summary>
    /// Subtracts two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpf_t operator -(mpf_t x, long y)
    {
        mpf_t z = new mpf_t();

        if (y >= 0)
            mpf_sub_ui(ref z.Value, ref x.Value, (mpir_ui)(ulong)y);
        else
            mpf_add_ui(ref z.Value, ref x.Value, (mpir_ui)(ulong)-y);

        return z;
    }

    /// <summary>
    /// Subtracts two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpf_t operator -(ulong x, mpf_t y)
    {
        mpf_t z = new mpf_t();

        mpf_ui_sub(ref z.Value, (mpir_ui)x, ref y.Value);

        return z;
    }

    /// <summary>
    /// Subtracts two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpf_t operator -(mpf_t x, ulong y)
    {
        mpf_t z = new mpf_t();

        mpf_sub_ui(ref z.Value, ref x.Value, (mpir_ui)y);

        return z;
    }

    /// <summary>
    /// Subtracts two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpf_t operator *(mpf_t x, mpf_t y)
    {
        mpf_t z = new mpf_t();

        mpf_mul(ref z.Value, ref x.Value, ref y.Value);

        return z;
    }

    /// <summary>
    /// Multiplies two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpf_t operator *(ulong x, mpf_t y)
    {
        mpf_t z = new mpf_t();

        mpf_mul_ui(ref z.Value, ref y.Value, (mpir_ui)x);

        return z;
    }

    /// <summary>
    /// Multiplies two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpf_t operator *(mpf_t x, ulong y)
    {
        mpf_t z = new mpf_t();

        mpf_mul_ui(ref z.Value, ref x.Value, (mpir_ui)y);

        return z;
    }

    /// <summary>
    /// Shifts an operand to the left.
    /// </summary>
    /// <param name="x">The value.</param>
    /// <param name="count">The shift.</param>
    public static mpf_t operator <<(mpf_t x, int count)
    {
        mpf_t z = new mpf_t();

        if (count >= 0)
            mpf_mul_2exp(ref z.Value, ref x.Value, (mp_bitcnt_t)(ulong)count);

        return z;
    }

    /// <summary>
    /// Shifts an operand to the right.
    /// </summary>
    /// <param name="x">The value.</param>
    /// <param name="count">The shift.</param>
    public static mpf_t operator >>(mpf_t x, int count)
    {
        mpf_t z = new mpf_t();

        if (count >= 0)
            mpf_div_2exp(ref z.Value, ref x.Value, (mp_bitcnt_t)(ulong)count);

        return z;
    }

    /// <summary>
    /// Negates an operand.
    /// </summary>
    /// <param name="x">The value.</param>
    public static mpf_t operator -(mpf_t x)
    {
        mpf_t z = new mpf_t();

        mpf_neg(ref z.Value, ref x.Value);

        return z;
    }

    /// <summary>
    /// Divides two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpf_t operator /(mpf_t x, mpf_t y)
    {
        mpf_t quotient = new mpf_t();

        mpf_div(ref quotient.Value, ref x.Value, ref y.Value);

        return quotient;
    }

    /// <summary>
    /// Divides two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpf_t operator /(mpf_t x, ulong y)
    {
        mpf_t quotient = new mpf_t();

        mpf_div_ui(ref quotient.Value, ref x.Value, (mpir_ui)y);

        return quotient;
    }

    /// <summary>
    /// Divides two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpf_t operator /(ulong x, mpf_t y)
    {
        mpf_t quotient = new mpf_t();

        mpf_ui_div(ref quotient.Value, (mpir_ui)x, ref y.Value);

        return quotient;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <(mpf_t x, mpf_t y)
    {
        return x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <(long x, mpf_t y)
    {
        return y.CompareTo(x) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <(mpf_t x, long y)
    {
        return x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <(ulong x, mpf_t y)
    {
        return y.CompareTo(x) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <(mpf_t x, ulong y)
    {
        return x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <(float x, mpf_t y)
    {
        return y.CompareTo(x) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <(mpf_t x, float y)
    {
        return x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <(double x, mpf_t y)
    {
        return y.CompareTo(x) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <(mpf_t x, double y)
    {
        return x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <=(mpf_t x, mpf_t y)
    {
        return x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <=(long x, mpf_t y)
    {
        return y.CompareTo(x) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <=(mpf_t x, long y)
    {
        return x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <=(ulong x, mpf_t y)
    {
        return y.CompareTo(x) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <=(mpf_t x, ulong y)
    {
        return x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <=(float x, mpf_t y)
    {
        return y.CompareTo(x) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <=(mpf_t x, float y)
    {
        return x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <=(double x, mpf_t y)
    {
        return y.CompareTo(x) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <=(mpf_t x, double y)
    {
        return x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >(mpf_t x, mpf_t y)
    {
        return x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >(long x, mpf_t y)
    {
        return y.CompareTo(x) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >(mpf_t x, long y)
    {
        return x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >(ulong x, mpf_t y)
    {
        return y.CompareTo(x) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >(mpf_t x, ulong y)
    {
        return x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >(float x, mpf_t y)
    {
        return y.CompareTo(x) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >(mpf_t x, float y)
    {
        return x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >(double x, mpf_t y)
    {
        return y.CompareTo(x) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >(mpf_t x, double y)
    {
        return x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >=(mpf_t x, mpf_t y)
    {
        return x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >=(long x, mpf_t y)
    {
        return y.CompareTo(x) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >=(mpf_t x, long y)
    {
        return x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >=(ulong x, mpf_t y)
    {
        return y.CompareTo(x) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >=(mpf_t x, ulong y)
    {
        return x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >=(float x, mpf_t y)
    {
        return y.CompareTo(x) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >=(mpf_t x, float y)
    {
        return x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >=(double x, mpf_t y)
    {
        return y.CompareTo(x) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >=(mpf_t x, double y)
    {
        return x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator ==(mpf_t x, mpf_t y)
    {
        return x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator ==(long x, mpf_t y)
    {
        return y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator ==(mpf_t x, long y)
    {
        return x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator ==(ulong x, mpf_t y)
    {
        return y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator ==(mpf_t x, ulong y)
    {
        return x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator ==(float x, mpf_t y)
    {
        return y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator ==(mpf_t x, float y)
    {
        return x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator ==(double x, mpf_t y)
    {
        return y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator ==(mpf_t x, double y)
    {
        return x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator !=(mpf_t x, mpf_t y)
    {
        return x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator !=(long x, mpf_t y)
    {
        return y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator !=(mpf_t x, long y)
    {
        return x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator !=(ulong x, mpf_t y)
    {
        return y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator !=(mpf_t x, ulong y)
    {
        return x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator !=(float x, mpf_t y)
    {
        return y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator !=(mpf_t x, float y)
    {
        return x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator !=(double x, mpf_t y)
    {
        return y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator !=(mpf_t x, double y)
    {
        return x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object..</param>
    public override bool Equals(object? obj)
    {
        if (obj is mpf_t other)
            return CompareTo(other) != 0;
        else
            return false;
    }

    /// <summary>
    /// Gets a hash of the value.
    /// </summary>
    public override int GetHashCode()
    {
        ulong SizeInDigits = 5;
        StringBuilder Data = new StringBuilder((int)(SizeInDigits + 2));

        mp_exp_t ExponentStruct;
        mpf_get_str(Data, out ExponentStruct, mpz_t.DefaultBase, (size_t)SizeInDigits, ref Value);

        return Data.ToString().GetHashCode();
    }
    #endregion

    #region Basic Arithmetic
    /// <summary>
    /// Gets the absolute value of the number.
    /// </summary>
    public mpf_t Abs()
    {
        mpf_t z = new mpf_t();

        mpf_abs(ref z.Value, ref Value);

        return z;
    }

    /// <summary>
    /// Gets the value sign.
    /// </summary>
    public int Sign
    {
        get { return mpf_sgn(ref Value); }
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    public mpf_t Sqrt()
    {
        mpf_t Result = new mpf_t();

        mpf_sqrt(ref Result.Value, ref Value);

        return Result;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="exp">The power.</param>
    public mpf_t Pow(ulong exp)
    {
        mpf_t Result = new mpf_t();

        mpf_pow_ui(ref Result.Value, ref Value, (mpir_ui)exp);

        return Result;
    }
    #endregion

    #region Comparison
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="other">The compared value.</param>
    public int CompareTo(mpf_t? other)
    {
        if (ReferenceEquals(other, null))
            throw new ArgumentNullException(nameof(other));
        else
            return mpf_cmp(ref Value, ref other.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="other">The compared value.</param>
    public int CompareTo(long other)
    {
        return mpf_cmp_si(ref Value, (mpir_si)other);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="other">The compared value.</param>
    public int CompareTo(ulong other)
    {
        return mpf_cmp_ui(ref Value, (mpir_ui)other);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="other">The compared value.</param>
    public int CompareTo(float other)
    {
        return mpf_cmp_d(ref Value, (double)other);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="other">The compared value.</param>
    public int CompareTo(double other)
    {
        return mpf_cmp_d(ref Value, other);
    }
    #endregion

    #region Rounding
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    public mpf_t Ceil()
    {
        mpf_t z = new mpf_t(Precision);

        mpf_ceil(ref z.Value, ref Value);

        return z;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    public mpf_t Floor()
    {
        mpf_t z = new mpf_t(Precision);

        mpf_floor(ref z.Value, ref Value);

        return z;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    public mpf_t Trunc()
    {
        mpf_t z = new mpf_t(Precision);

        mpf_trunc(ref z.Value, ref Value);

        return z;
    }
    #endregion

    #region Implementation of IDisposable
    /// <summary>
    /// Called when an object should release its resources.
    /// </summary>
    /// <param name="isDisposing">Indicates if resources must be disposed now.</param>
    protected virtual void Dispose(bool isDisposing)
    {
        if (!IsDisposed)
        {
            IsDisposed = true;

            if (isDisposing)
                DisposeNow();
        }
    }

    /// <summary>
    /// Called when an object should release its resources.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Finalizes an instance of the <see cref="mpf_t"/> class.
    /// </summary>
    ~mpf_t()
    {
        Dispose(false);
    }

    /// <summary>
    /// True after <see cref="Dispose(bool)"/> has been invoked.
    /// </summary>
    private bool IsDisposed;

    /// <summary>
    /// Disposes of every reference that must be cleaned up.
    /// </summary>
    private void DisposeNow()
    {
        mpf_clear(ref Value);
    }
    #endregion

    #region Implementation of IEquatable<mpf_t>
    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    public bool Equals(mpf_t? other)
    {
        if (ReferenceEquals(other, null))
            throw new ArgumentNullException(nameof(other));
        else
            return mpf_cmp(ref Value, ref other.Value) == 0;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    bool IEquatable<mpf_t>.Equals(mpf_t? other)
    {
        return this.Equals(other);
    }
    #endregion

    #region Implementation of ICloneable
    /// <summary>
    /// Creates a copy of the object.
    /// </summary>
    public object Clone()
    {
        return new mpf_t(this);
    }

    /// <summary>
    /// Creates a copy of the object.
    /// </summary>
    object ICloneable.Clone()
    {
        return this.Clone();
    }
    #endregion

    #region Implementation of IConvertible
    /// <summary>
    /// Returns the <see cref="TypeCode"/> for this instance.
    /// </summary>
    TypeCode IConvertible.GetTypeCode()
    {
        return TypeCode.Object;
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="bool"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    public bool ToBoolean(IFormatProvider? provider)
    {
        throw new InvalidCastException();
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="bool"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    bool IConvertible.ToBoolean(IFormatProvider? provider)
    {
        return this.ToBoolean(provider);
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="byte"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    public byte ToByte(IFormatProvider? provider)
    {
        return (byte)(int)this;
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="byte"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    byte IConvertible.ToByte(IFormatProvider? provider)
    {
        return this.ToByte(provider);
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="char"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    public char ToChar(IFormatProvider? provider)
    {
        throw new InvalidCastException();
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="char"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    char IConvertible.ToChar(IFormatProvider? provider)
    {
        return this.ToChar(provider);
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="DateTime"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    public DateTime ToDateTime(IFormatProvider? provider)
    {
        throw new InvalidCastException();
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="DateTime"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    DateTime IConvertible.ToDateTime(IFormatProvider? provider)
    {
        return this.ToDateTime(provider);
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="decimal"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    public decimal ToDecimal(IFormatProvider? provider)
    {
        throw new InvalidCastException();
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="decimal"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    decimal IConvertible.ToDecimal(IFormatProvider? provider)
    {
        return this.ToDecimal(provider);
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="double"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    public double ToDouble(IFormatProvider? provider)
    {
        return (double)this;
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="double"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    double IConvertible.ToDouble(IFormatProvider? provider)
    {
        return this.ToDouble(provider);
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="short"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    public short ToInt16(IFormatProvider? provider)
    {
        return (short)(int)this;
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="short"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    short IConvertible.ToInt16(IFormatProvider? provider)
    {
        return this.ToInt16(provider);
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="int"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    public int ToInt32(IFormatProvider? provider)
    {
        return (int)this;
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="int"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    int IConvertible.ToInt32(IFormatProvider? provider)
    {
        return this.ToInt32(provider);
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="long"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    public long ToInt64(IFormatProvider? provider)
    {
        return (long)this;
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="long"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    long IConvertible.ToInt64(IFormatProvider? provider)
    {
        return this.ToInt64(provider);
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="sbyte"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    public sbyte ToSByte(IFormatProvider? provider)
    {
        return (sbyte)this;
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="sbyte"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    sbyte IConvertible.ToSByte(IFormatProvider? provider)
    {
        return this.ToSByte(provider);
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="float"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    public float ToSingle(IFormatProvider? provider)
    {
        return (float)this;
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="float"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    float IConvertible.ToSingle(IFormatProvider? provider)
    {
        return this.ToSingle(provider);
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="string"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    public string ToString(IFormatProvider? provider)
    {
        return this.ToString();
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="string"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    string IConvertible.ToString(IFormatProvider? provider)
    {
        return this.ToString(provider);
    }

    /// <summary>
    /// Converts the value of this instance to an object of the specified type.
    /// </summary>
    /// <param name="targetType">The type to which the value of this instance is converted.</param>
    /// <param name="provider">Culture-specific formatting information.</param>
    public object ToType(Type targetType, IFormatProvider? provider)
    {
        if (targetType == typeof(mpf_t))
            return this;

        IConvertible value = this;

        if (targetType == typeof(sbyte))
            return value.ToSByte(provider);
        else if (targetType == typeof(byte))
            return value.ToByte(provider);
        else if (targetType == typeof(short))
            return value.ToInt16(provider);
        else if (targetType == typeof(ushort))
            return value.ToUInt16(provider);
        else if (targetType == typeof(int))
            return value.ToInt32(provider);
        else if (targetType == typeof(uint))
            return value.ToUInt32(provider);
        else if (targetType == typeof(long))
            return value.ToInt64(provider);
        else if (targetType == typeof(ulong))
            return value.ToUInt64(provider);
        else if (targetType == typeof(float))
            return value.ToSingle(provider);
        else if (targetType == typeof(double))
            return value.ToDouble(provider);
        else if (targetType == typeof(decimal))
            return value.ToDecimal(provider);
        else if (targetType == typeof(string))
            return value.ToString(provider);
        else if (targetType == typeof(object))
            return value;
        else
            throw new InvalidCastException();
    }

    /// <summary>
    /// Converts the value of this instance to an object of the specified type.
    /// </summary>
    /// <param name="targetType">The type to which the value of this instance is converted.</param>
    /// <param name="provider">Culture-specific formatting information.</param>
    object IConvertible.ToType(Type targetType, IFormatProvider? provider)
    {
        return this.ToType(targetType, provider);
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="ushort"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    public ushort ToUInt16(IFormatProvider? provider)
    {
        return this.ToUInt16(provider);
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="ushort"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    ushort IConvertible.ToUInt16(IFormatProvider? provider)
    {
        return (ushort)(uint)this;
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="uint"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    public uint ToUInt32(IFormatProvider? provider)
    {
        return (uint)this;
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="uint"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    uint IConvertible.ToUInt32(IFormatProvider? provider)
    {
        return this.ToUInt32(provider);
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="ulong"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    public ulong ToUInt64(IFormatProvider? provider)
    {
        return (ulong)this;
    }

    /// <summary>
    /// Converts the value of this instance to an equivalent <see cref="ulong"/> value.
    /// </summary>
    /// <param name="provider">Culture-specific formatting information.</param>
    ulong IConvertible.ToUInt64(IFormatProvider? provider)
    {
        return this.ToUInt64(provider);
    }
    #endregion

    #region Implementation of IComparable
    /// <summary>
    /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
    /// </summary>
    /// <param name="obj">An object to compare with this instance.</param>
    public int CompareTo(object? obj)
    {
        if (obj is mpf_t other)
            return CompareTo(other);
        else
            throw new ArgumentException();
    }

    /// <summary>
    /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
    /// </summary>
    /// <param name="obj">An object to compare with this instance.</param>
    int IComparable.CompareTo(object? obj)
    {
        return this.CompareTo(obj);
    }
    #endregion
}
