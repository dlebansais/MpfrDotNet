namespace MpirDotNet;

using System;
using System.Text;
using static Interop.Mpir.NativeMethods;

/// <summary>
/// Arbitrary precision rational number.
/// </summary>
public partial class mpq_t : IDisposable, IEquatable<mpq_t>, ICloneable, IConvertible, IComparable, IComparable<mpq_t>
{
    /// <summary>
    /// Adds two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpq_t operator +(mpq_t x, mpq_t y)
    {
        mpq_t z = new mpq_t();

        mpq_add(ref z.Value, ref x.Value, ref y.Value);

        return z;
    }

    /// <summary>
    /// Subtracts two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpq_t operator -(mpq_t x, mpq_t y)
    {
        mpq_t z = new mpq_t();

        mpq_sub(ref z.Value, ref x.Value, ref y.Value);

        return z;
    }

    /// <summary>
    /// Multiplies two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpq_t operator *(mpq_t x, mpq_t y)
    {
        mpq_t z = new mpq_t();

        mpq_mul(ref z.Value, ref x.Value, ref y.Value);

        return z;
    }

    /// <summary>
    /// Shifts a number to the left.
    /// </summary>
    /// <param name="x">The operand.</param>
    /// <param name="count">The number of bits to shift.</param>
    public static mpq_t operator <<(mpq_t x, int count)
    {
        mpq_t z = new mpq_t();

        if (count >= 0)
            mpq_mul_2exp(ref z.Value, ref x.Value, (mp_bitcnt_t)(ulong)count);

        return z;
    }

    /// <summary>
    /// Shifts a number to the right.
    /// </summary>
    /// <param name="x">The operand.</param>
    /// <param name="count">The number of bits to shift.</param>
    public static mpq_t operator >>(mpq_t x, int count)
    {
        mpq_t z = new mpq_t();

        if (count >= 0)
            mpq_div_2exp(ref z.Value, ref x.Value, (mp_bitcnt_t)(ulong)count);

        return z;
    }

    /// <summary>
    /// Negates a number.
    /// </summary>
    /// <param name="x">The number.</param>
    public static mpq_t operator -(mpq_t x)
    {
        mpq_t z = new mpq_t();

        mpq_neg(ref z.Value, ref x.Value);

        return z;
    }

    /// <summary>
    /// Divides two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpq_t operator /(mpq_t x, mpq_t y)
    {
        mpq_t z = new mpq_t();

        mpq_div(ref z.Value, ref x.Value, ref y.Value);

        return z;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <(mpq_t x, mpq_t y)
    {
        return x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <=(mpq_t x, mpq_t y)
    {
        return x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >(mpq_t x, mpq_t y)
    {
        return x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >=(mpq_t x, mpq_t y)
    {
        return x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator ==(mpq_t x, mpq_t y)
    {
        return x.IsEqualTo(y);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator !=(mpq_t x, mpq_t y)
    {
        return !x.IsEqualTo(y);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <(mpq_t x, mpz_t y)
    {
        return x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <=(mpq_t x, mpz_t y)
    {
        return x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >(mpq_t x, mpz_t y)
    {
        return x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >=(mpq_t x, mpz_t y)
    {
        return x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator ==(mpq_t x, mpz_t y)
    {
        return x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator !=(mpq_t x, mpz_t y)
    {
        return x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object..</param>
    public override bool Equals(object? obj)
    {
        if (obj is mpq_t other)
            return IsEqualTo(other);
        else
            return false;
    }

    /// <summary>
    /// Gets the hash of the object.
    /// </summary>
    public override int GetHashCode()
    {
        using mpz_t Numerator = new();
        mpq_get_num(ref Numerator.Value, ref Value);

        using mpz_t Denominator = new();
        mpq_get_den(ref Denominator.Value, ref Value);

        return Numerator.GetHashCode() ^ Denominator.GetHashCode();
    }
}
