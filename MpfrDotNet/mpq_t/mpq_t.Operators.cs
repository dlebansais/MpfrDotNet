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
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static mpq_t operator +(mpq_t x, mpq_t y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpq_t z = new();

        mpq.add(z, x, y);

        return z;
    }

    /// <summary>
    /// Subtracts two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static mpq_t operator -(mpq_t x, mpq_t y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpq_t z = new();

        mpq.sub(z, x, y);

        return z;
    }

    /// <summary>
    /// Multiplies two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static mpq_t operator *(mpq_t x, mpq_t y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpq_t z = new();

        mpq.mul(z, x, y);

        return z;
    }

    /// <summary>
    /// Shifts a number to the left.
    /// </summary>
    /// <param name="x">The operand.</param>
    /// <param name="count">The number of bits to shift. A negative count shifts to the right.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpq_t operator <<(mpq_t x, int count)
    {
        ThrowIfDisposed(x);

        mpq_t z = new();

        if (count >= 0)
            mpq.mul_2exp(z, x, (ulong)count);
        else
            mpq.div_2exp(z, x, (ulong)-(long)count);

        return z;
    }

    /// <summary>
    /// Shifts a number to the right.
    /// </summary>
    /// <param name="x">The operand.</param>
    /// <param name="count">The number of bits to shift. A negative count shifts to the left.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpq_t operator >>(mpq_t x, int count)
    {
        ThrowIfDisposed(x);

        mpq_t z = new();

        if (count >= 0)
            mpq.div_2exp(z, x, (ulong)count);
        else
            mpq.mul_2exp(z, x, (ulong)-(long)count);

        return z;
    }

    /// <summary>
    /// Negates a number.
    /// </summary>
    /// <param name="x">The number.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpq_t operator -(mpq_t x)
    {
        ThrowIfDisposed(x);

        mpq_t z = new();

        mpq.neg(z, x);

        return z;
    }

    /// <summary>
    /// Divides two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static mpq_t operator /(mpq_t x, mpq_t y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpq_t z = new();

        mpq.div(z, x, y);

        return z;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator <(mpq_t? x, mpq_t? y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return y is not null && (x is null || x.CompareTo(y) < 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator <=(mpq_t? x, mpq_t? y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return x is null || (y is not null && x.CompareTo(y) <= 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator >(mpq_t? x, mpq_t? y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return x is not null && (y is null || x.CompareTo(y) > 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator >=(mpq_t? x, mpq_t? y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return y is null || (x is not null && x.CompareTo(y) >= 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator ==(mpq_t? x, mpq_t? y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return x is null ? y is null : x.Equals(y);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator !=(mpq_t? x, mpq_t? y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return !(x == y);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator <(mpq_t? x, mpz_t? y)
    {
        ThrowIfDisposed(x);
        mpz_t.ThrowIfDisposed(y);

        return y is not null && (x is null || x.CompareTo(y) < 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator <=(mpq_t? x, mpz_t? y)
    {
        ThrowIfDisposed(x);
        mpz_t.ThrowIfDisposed(y);

        return x is null || (y is not null && x.CompareTo(y) <= 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator >(mpq_t? x, mpz_t? y)
    {
        ThrowIfDisposed(x);
        mpz_t.ThrowIfDisposed(y);

        return x is not null && (y is null || x.CompareTo(y) > 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator >=(mpq_t? x, mpz_t? y)
    {
        ThrowIfDisposed(x);
        mpz_t.ThrowIfDisposed(y);

        return y is null || (x is not null && x.CompareTo(y) >= 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator ==(mpq_t? x, mpz_t? y)
    {
        ThrowIfDisposed(x);
        mpz_t.ThrowIfDisposed(y);

        return x is null ? y is null : y is not null && x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator !=(mpq_t? x, mpz_t? y)
    {
        ThrowIfDisposed(x);
        mpz_t.ThrowIfDisposed(y);

        return !(x == y);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator <(mpq_t? x, long y)
    {
        return x is null || x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator <(long x, mpq_t? y)
    {
        return y is not null && y.CompareTo(x) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator <=(mpq_t? x, long y)
    {
        return x is null || x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator <=(long x, mpq_t? y)
    {
        return y is not null && y.CompareTo(x) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator >(mpq_t? x, long y)
    {
        return x is not null && x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator >(long x, mpq_t? y)
    {
        return y is null || y.CompareTo(x) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator >=(mpq_t? x, long y)
    {
        return x is not null && x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator >=(long x, mpq_t? y)
    {
        return y is null || y.CompareTo(x) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator ==(mpq_t? x, long y)
    {
        return x is not null && x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator ==(long x, mpq_t? y)
    {
        return y is not null && y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator !=(mpq_t? x, long y)
    {
        return x is null || x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator !=(long x, mpq_t? y)
    {
        return y is null || y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator <(mpq_t? x, ulong y)
    {
        return x is null || x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator <(ulong x, mpq_t? y)
    {
        return y is not null && y.CompareTo(x) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator <=(mpq_t? x, ulong y)
    {
        return x is null || x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator <=(ulong x, mpq_t? y)
    {
        return y is not null && y.CompareTo(x) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator >(mpq_t? x, ulong y)
    {
        return x is not null && x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator >(ulong x, mpq_t? y)
    {
        return y is null || y.CompareTo(x) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator >=(mpq_t? x, ulong y)
    {
        return x is not null && x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator >=(ulong x, mpq_t? y)
    {
        return y is null || y.CompareTo(x) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator ==(mpq_t? x, ulong y)
    {
        return x is not null && x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator ==(ulong x, mpq_t? y)
    {
        return y is not null && y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator !=(mpq_t? x, ulong y)
    {
        return x is null || x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator !=(ulong x, mpq_t? y)
    {
        return y is null || y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator <(mpq_t? x, double y)
    {
        ThrowIfDisposed(x);

        return x is null || (!double.IsNaN(y) && x.CompareTo(y) < 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator <(double x, mpq_t? y)
    {
        ThrowIfDisposed(y);

        return y is not null && !double.IsNaN(x) && y.CompareTo(x) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator <=(mpq_t? x, double y)
    {
        ThrowIfDisposed(x);

        return x is null || (!double.IsNaN(y) && x.CompareTo(y) <= 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator <=(double x, mpq_t? y)
    {
        ThrowIfDisposed(y);

        return y is not null && !double.IsNaN(x) && y.CompareTo(x) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator >(mpq_t? x, double y)
    {
        ThrowIfDisposed(x);

        return x is not null && !double.IsNaN(y) && x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator >(double x, mpq_t? y)
    {
        ThrowIfDisposed(y);

        return y is null || (!double.IsNaN(x) && y.CompareTo(x) < 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator >=(mpq_t? x, double y)
    {
        ThrowIfDisposed(x);

        return x is not null && !double.IsNaN(y) && x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator >=(double x, mpq_t? y)
    {
        ThrowIfDisposed(y);

        return y is null || (!double.IsNaN(x) && y.CompareTo(x) <= 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator ==(mpq_t? x, double y)
    {
        ThrowIfDisposed(x);

        return x is not null && !double.IsNaN(y) && x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator ==(double x, mpq_t? y)
    {
        ThrowIfDisposed(y);

        return y is not null && !double.IsNaN(x) && y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator !=(mpq_t? x, double y)
    {
        ThrowIfDisposed(x);

        return x is null || double.IsNaN(y) || x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator !=(double x, mpq_t? y)
    {
        ThrowIfDisposed(y);

        return y is null || double.IsNaN(x) || y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object..</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public override bool Equals(object? obj)
    {
        ThrowIfDisposed(this);

        return obj is mpq_t other && Equals(other);
    }

    /// <summary>
    /// Gets the hash of the object.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public override int GetHashCode()
    {
        ThrowIfDisposed(this);

        using mpz_t Numerator = new();
        mpq.get_num(Numerator, this);

        using mpz_t Denominator = new();
        mpq.get_den(Denominator, this);

        return Numerator.GetHashCode() ^ Denominator.GetHashCode();
    }
}
