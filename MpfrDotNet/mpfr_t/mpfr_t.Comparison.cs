namespace MpfrDotNet;

using System;
using MpirDotNet;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public partial class mpfr_t : IDisposable
{
    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    public int CompareTo(mpfr_t other)
    {
        return mpfr_cmp(ref Value, ref other.Value);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    public int CompareTo(ulong other)
    {
        return mpfr_cmp_ui(ref Value, other);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    public int CompareTo(long other)
    {
        return mpfr_cmp_si(ref Value, other);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    public int CompareTo(double other)
    {
        return mpfr_cmp_d(ref Value, other);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    public int CompareTo(mpz_t other)
    {
        return mpfr_cmp_z(ref Value, ref other.Value);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    public int CompareTo(mpq_t other)
    {
        return mpfr_cmp_q(ref Value, ref other.Value);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    public int CompareTo(mpf_t other)
    {
        return mpfr_cmp_f(ref Value, ref other.Value);
    }

    /// <summary>
    /// Compares with another number, shifted.
    /// </summary>
    /// <param name="other">The other number.</param>
    /// <param name="e">The shift.</param>
    public int CompareTo(ulong other, int e)
    {
        return mpfr_cmp_ui_2exp(ref Value, other, e);
    }

    /// <summary>
    /// Compares with another number, shifted.
    /// </summary>
    /// <param name="other">The other number.</param>
    /// <param name="e">The shift.</param>
    public int CompareTo(long other, int e)
    {
        return mpfr_cmp_si_2exp(ref Value, other, e);
    }

    /// <summary>
    /// Compares two numbers.
    /// </summary>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    /// <returns>0 if <paramref name="x"/> and <paramref name="y"/> are equal, 1 if <paramref name="x"/> &gt; <paramref name="y"/>, -1 if <paramref name="x"/> &lt; <paramref name="y"/>.</returns>
    public static int Compare(mpfr_t x, mpfr_t y)
    {
        return mpfr_cmp(ref x.Value, ref y.Value);
    }

    /// <summary>
    /// Compares the absolute value of two numbers.
    /// </summary>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    /// <returns>0 if abs(<paramref name="x"/>) and abs(<paramref name="y"/>) are equal, 1 if abs(<paramref name="x"/>) &gt; abs(<paramref name="y"/>), -1 if abs(<paramref name="x"/>) &lt; abs(<paramref name="y"/>).</returns>
    public static int CompareAbs(mpfr_t x, mpfr_t y)
    {
        return mpfr_cmpabs(ref x.Value, ref y.Value);
    }

    /// <summary>
    /// Compares two numbers and returns true if one of them is greater than the other, false if one of them is NaN or they are equal.
    /// </summary>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    public static bool IsLesserOrGreater(mpfr_t x, mpfr_t y)
    {
        return mpfr_lessgreater_p(ref x.Value, ref y.Value) != 0;
    }

    /// <summary>
    /// Compares two numbers and returns true if one of them is unordered (is NaN).
    /// </summary>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    public static bool IsUnordered(mpfr_t x, mpfr_t y)
    {
        return mpfr_unordered_p(ref x.Value, ref y.Value) != 0;
    }

    /// <summary>
    /// Compares two numbers and returns true if x ≤ y taking signed NaN and signed zero into account.
    /// </summary>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    public static bool IsTotalOrdered(mpfr_t x, mpfr_t y)
    {
        return mpfr_total_order_p(ref x.Value, ref y.Value) != 0;
    }

    /// <summary>
    /// Compares two numbers and returns true if equal up to n bits.
    /// </summary>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    /// <param name="n">The bit count.</param>
    public static bool IsEqualBits(mpfr_t x, mpfr_t y, uint n)
    {
        return mpfr_eq(ref x.Value, ref y.Value, n) != 0;
    }

    /// <summary>
    /// Returns the relative difference between two numbers.
    /// </summary>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    /// <param name="rounding">The rounding mode.</param>
    public static mpfr_t RelativeDifference(mpfr_t x, mpfr_t y, mpfr_rnd_t rounding = DefaultRounding)
    {
        mpfr_t z = new();

        mpfr_reldiff(ref z.Value, ref x.Value, ref y.Value, (__mpfr_rnd_t)rounding);

        return z;
    }

    /// <summary>
    /// Gets a value indicating whether the number is NAN.
    /// </summary>
    public bool IsNan { get { return mpfr_nan_p(ref Value) != 0; } }

    /// <summary>
    /// Gets a value indicating whether the number is infinity.
    /// </summary>
    public bool IsInf { get { return mpfr_inf_p(ref Value) != 0; } }

    /// <summary>
    /// Gets a value indicating whether the instance is a number.
    /// </summary>
    public bool IsNumber { get { return mpfr_number_p(ref Value) != 0; } }

    /// <summary>
    /// Gets a value indicating whether the number is zero.
    /// </summary>
    public bool IsZero { get { return mpfr_zero_p(ref Value) != 0; } }

    /// <summary>
    /// Gets a value indicating whether the number is regular.
    /// </summary>
    public bool IsRegular { get { return mpfr_regular_p(ref Value) != 0; } }

    /// <summary>
    /// Gets the sign.
    /// </summary>
    public int Sign { get { return mpfr_sgn(ref Value); } }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object..</param>
    public override bool Equals(object? obj)
    {
        if (obj is mpfr_t other)
            return mpfr_equal_p(ref Value, ref other.Value) == 0;
        else
            return false;
    }

    /// <summary>
    /// Gets a hash of the value.
    /// </summary>
    public override int GetHashCode()
    {
        double d = mpfr_get_d(ref Value, (__mpfr_rnd_t)DefaultRounding);
        return d.GetHashCode();
    }
}
