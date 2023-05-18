namespace MpirDotNet;

using System;
using System.Text;
using static Interop.Mpir.NativeMethods;

/// <summary>
/// See http://mpir.org/mpir-3.0.0.pdf.
/// </summary>
public partial class mpf_t : IDisposable, IEquatable<mpf_t>, ICloneable, IConvertible, IComparable, IComparable<mpf_t>
{
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
}
