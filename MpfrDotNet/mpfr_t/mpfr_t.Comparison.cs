namespace MpfrDotNet;

using System;
using MpirDotNet;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public partial class mpfr_t : IDisposable, IEquatable<mpfr_t>, IComparable<mpfr_t>, IComparable
{
    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    /// <returns>A positive value if <paramref name="other"/> is <see langword="null"/> or NaN, and a negative value if only this number is NaN: NaN sorts before any number, as with <see cref="double.CompareTo(double)"/>.</returns>
    /// <exception cref="ObjectDisposedException">This number or <paramref name="other"/> is disposed.</exception>
    public int CompareTo(mpfr_t? other)
    {
        if (other is null)
            return 1;

        bool IsThisNaN = IsNan;
        bool IsOtherNaN = other.IsNan;

        if (IsThisNaN || IsOtherNaN)
            return IsThisNaN ? (IsOtherNaN ? 0 : -1) : 1;

        return mpfr.cmp(this, other);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    /// <returns>A negative value if this number is NaN, which sorts before any number, as with <see cref="double.CompareTo(double)"/>.</returns>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public int CompareTo(ulong other)
    {
        return IsNan ? -1 : mpfr.cmp_ui(this, other);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    /// <returns>A negative value if this number is NaN, which sorts before any number, as with <see cref="double.CompareTo(double)"/>.</returns>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public int CompareTo(long other)
    {
        return IsNan ? -1 : mpfr.cmp_si(this, other);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    /// <returns>A negative value if only this number is NaN, and a positive value if only <paramref name="other"/> is NaN: NaN sorts before any number, as with <see cref="double.CompareTo(double)"/>.</returns>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public int CompareTo(double other)
    {
        bool IsOtherNaN = double.IsNaN(other);

        if (IsNan || IsOtherNaN)
            return IsNan ? (IsOtherNaN ? 0 : -1) : 1;

        return mpfr.cmp_d(this, other);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    /// <returns>A negative value if this number is NaN, which sorts before any number, as with <see cref="double.CompareTo(double)"/>.</returns>
    /// <exception cref="ObjectDisposedException">This number or <paramref name="other"/> is disposed.</exception>
    public int CompareTo(mpz_t other)
    {
        mpz_t.ThrowIfDisposed(other);

        return IsNan ? -1 : mpfr.cmp_z(this, other);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    /// <returns>A negative value if this number is NaN, which sorts before any number, as with <see cref="double.CompareTo(double)"/>.</returns>
    /// <exception cref="ObjectDisposedException">This number or <paramref name="other"/> is disposed.</exception>
    public int CompareTo(mpq_t other)
    {
        mpq_t.ThrowIfDisposed(other);

        return IsNan ? -1 : mpfr.cmp_q(this, other);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    /// <returns>A negative value if this number is NaN, which sorts before any number, as with <see cref="double.CompareTo(double)"/>.</returns>
    /// <exception cref="ObjectDisposedException">This number or <paramref name="other"/> is disposed.</exception>
    public int CompareTo(mpf_t other)
    {
        mpf_t.ThrowIfDisposed(other);

        return IsNan ? -1 : mpfr.cmp_f(this, other);
    }

    /// <summary>
    /// Compares with another number, shifted.
    /// </summary>
    /// <param name="other">The other number.</param>
    /// <param name="e">The shift.</param>
    /// <returns>A negative value if this number is NaN, which sorts before any number, as with <see cref="double.CompareTo(double)"/>.</returns>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public int CompareTo(ulong other, int e)
    {
        return IsNan ? -1 : mpfr.cmp_ui_2exp(this, other, e);
    }

    /// <summary>
    /// Compares with another number, shifted.
    /// </summary>
    /// <param name="other">The other number.</param>
    /// <param name="e">The shift.</param>
    /// <returns>A negative value if this number is NaN, which sorts before any number, as with <see cref="double.CompareTo(double)"/>.</returns>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public int CompareTo(long other, int e)
    {
        return IsNan ? -1 : mpfr.cmp_si_2exp(this, other, e);
    }

    /// <summary>
    /// Compares two numbers.
    /// </summary>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    /// <returns>Zero if <paramref name="x"/> and <paramref name="y"/> are equal, a positive value if <paramref name="x"/> &gt; <paramref name="y"/>, and a negative value if <paramref name="x"/> &lt; <paramref name="y"/>. As with <see cref="CompareTo(mpfr_t)"/>, NaN sorts before any number.</returns>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static int Compare(mpfr_t x, mpfr_t y)
    {
        return x.CompareTo(y);
    }

    /// <summary>
    /// Compares the absolute value of two numbers.
    /// </summary>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    /// <returns>0 if abs(<paramref name="x"/>) and abs(<paramref name="y"/>) are equal, 1 if abs(<paramref name="x"/>) &gt; abs(<paramref name="y"/>), -1 if abs(<paramref name="x"/>) &lt; abs(<paramref name="y"/>). As in <see cref="CompareTo(mpfr_t)"/>, NaN is smaller than any other number and equal to NaN.</returns>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static int CompareAbs(mpfr_t x, mpfr_t y)
    {
        // mpfr_cmpabs returns 0 when an operand is NaN, and sets the erange flag.
        bool IsXNaN = x.IsNan;
        bool IsYNaN = y.IsNan;

        if (IsXNaN || IsYNaN)
            return IsXNaN ? (IsYNaN ? 0 : -1) : 1;

        return mpfr.cmpabs(x, y);
    }

    /// <summary>
    /// Compares two numbers and returns true if one of them is greater than the other, false if one of them is NaN or they are equal.
    /// </summary>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool IsLesserOrGreater(mpfr_t x, mpfr_t y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return mpfr.lessgreater_p(x, y);
    }

    /// <summary>
    /// Compares two numbers and returns true if one of them is unordered (is NaN).
    /// </summary>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool IsUnordered(mpfr_t x, mpfr_t y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return mpfr.unordered_p(x, y);
    }

    /// <summary>
    /// Compares two numbers and returns true if x ≤ y taking signed NaN and signed zero into account.
    /// </summary>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool IsTotalOrdered(mpfr_t x, mpfr_t y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return mpfr.total_order_p(x, y);
    }

    /// <summary>
    /// Compares two numbers and returns true if equal up to n bits.
    /// </summary>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    /// <param name="n">The bit count.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool IsEqualBits(mpfr_t x, mpfr_t y, uint n)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return mpfr.eq(x, y, n);
    }

    /// <summary>
    /// Returns the relative difference between two numbers.
    /// </summary>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static mpfr_t RelativeDifference(mpfr_t x, mpfr_t y, mpfr_rnd_t rounding = DefaultRounding)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(x, y);

        mpfr.reldiff(z, x, y, rounding);

        return z;
    }

    /// <summary>
    /// Gets a value indicating whether the number is NAN.
    /// </summary>
    /// <exception cref="ObjectDisposedException">The number is disposed.</exception>
    public bool IsNan
    {
        get
        {
            ThrowIfDisposed(this);

            return mpfr.nan_p(this);
        }
    }

    /// <summary>
    /// Gets a value indicating whether the number is infinity.
    /// </summary>
    /// <exception cref="ObjectDisposedException">The number is disposed.</exception>
    public bool IsInf
    {
        get
        {
            ThrowIfDisposed(this);

            return mpfr.inf_p(this);
        }
    }

    /// <summary>
    /// Gets a value indicating whether the instance is a number.
    /// </summary>
    /// <exception cref="ObjectDisposedException">The number is disposed.</exception>
    public bool IsNumber
    {
        get
        {
            ThrowIfDisposed(this);

            return mpfr.number_p(this);
        }
    }

    /// <summary>
    /// Gets a value indicating whether the number is zero.
    /// </summary>
    /// <exception cref="ObjectDisposedException">The number is disposed.</exception>
    public bool IsZero
    {
        get
        {
            ThrowIfDisposed(this);

            return mpfr.zero_p(this);
        }
    }

    /// <summary>
    /// Gets a value indicating whether the number is regular.
    /// </summary>
    /// <exception cref="ObjectDisposedException">The number is disposed.</exception>
    public bool IsRegular
    {
        get
        {
            ThrowIfDisposed(this);

            return mpfr.regular_p(this);
        }
    }

    /// <summary>
    /// Gets the sign.
    /// </summary>
    /// <exception cref="ObjectDisposedException">The number is disposed.</exception>
    public int Sign
    {
        get
        {
            ThrowIfDisposed(this);

            return mpfr.sgn(this);
        }
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    /// <remarks>As with <see cref="double.Equals(double)"/>, NaN is equal to NaN, unlike with the == operator.</remarks>
    public override bool Equals(object? obj)
    {
        return obj is mpfr_t other && Equals(other);
    }

    /// <summary>
    /// Determines whether the specified number is equal to the current number.
    /// </summary>
    /// <param name="other">The number to compare with the current number.</param>
    /// <exception cref="ObjectDisposedException">This number or <paramref name="other"/> is disposed.</exception>
    /// <remarks>As with <see cref="double.Equals(double)"/>, NaN is equal to NaN, unlike with the == operator.</remarks>
    public bool Equals(mpfr_t? other)
    {
        if (other is null)
            return false;

        if (IsNan || other.IsNan)
            return IsNan && other.IsNan;

        return mpfr.equal_p(this, other);
    }

    /// <summary>
    /// Compares with another object.
    /// </summary>
    /// <param name="obj">The other object.</param>
    /// <returns>The result of <see cref="CompareTo(mpfr_t)"/> if <paramref name="obj"/> is an <see cref="mpfr_t"/>, and a positive value if it is <see langword="null"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="obj"/> is not an <see cref="mpfr_t"/>.</exception>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public int CompareTo(object? obj)
    {
        if (obj is null)
            return 1;
        else if (obj is mpfr_t other)
            return CompareTo(other);
        else
            throw new ArgumentException("Invalid comparison with an object of a different type.", nameof(obj));
    }

    /// <summary>
    /// Gets a hash of the value.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public override int GetHashCode()
    {
        // Numbers that are equal must have the same hash: +0 and -0 are equal, and so are all NaNs.
        if (IsNan)
            return double.NaN.GetHashCode();

        if (IsZero)
            return 0.0.GetHashCode();

        double d = mpfr.get_d(this, DefaultRounding);
        return d.GetHashCode();
    }
}
