namespace MpirDotNet;

using System;
using System.Numerics;
using System.Text;
using static Interop.Mpir.NativeMethods;

/// <summary>
/// Arbitrary precision integer.
/// </summary>
public partial class mpz_t : IDisposable, IEquatable<mpz_t>, ICloneable, IConvertible, IComparable, IComparable<mpz_t>
{
    /// <summary>
    /// Adds two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static mpz_t operator +(mpz_t x, mpz_t y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpz_t z = new();

        mpz.add(z, x, y);

        return z;
    }

    /// <summary>
    /// Adds two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpz_t operator +(mpz_t x, long y)
    {
        ThrowIfDisposed(x);

        mpz_t z = new();

        if (y >= 0)
            mpz.add_ui(z, x, (ulong)y);
        else
            mpz.sub_ui(z, x, (ulong)-y);

        return z;
    }

    /// <summary>
    /// Adds two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static mpz_t operator +(long x, mpz_t y)
    {
        ThrowIfDisposed(y);

        mpz_t z = new();

        if (x >= 0)
            mpz.add_ui(z, y, (ulong)x);
        else
            mpz.sub_ui(z, y, (ulong)-x);

        return z;
    }

    /// <summary>
    /// Adds two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpz_t operator +(mpz_t x, ulong y)
    {
        ThrowIfDisposed(x);

        mpz_t z = new();

        mpz.add_ui(z, x, y);

        return z;
    }

    /// <summary>
    /// Adds two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static mpz_t operator +(ulong x, mpz_t y)
    {
        ThrowIfDisposed(y);

        mpz_t z = new();

        mpz.add_ui(z, y, x);

        return z;
    }

    /// <summary>
    /// Increments an operand.
    /// </summary>
    /// <param name="x">The operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpz_t operator ++(mpz_t x)
    {
        ThrowIfDisposed(x);

        // The operand is left unchanged: C# assigns the result to the variable, and the operand may be shared.
        mpz_t z = new();

        mpz.add_ui(z, x, 1UL);

        return z;
    }

    /// <summary>
    /// Subtracts two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static mpz_t operator -(mpz_t x, mpz_t y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpz_t z = new();

        mpz.sub(z, x, y);

        return z;
    }

    /// <summary>
    /// Subtracts two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static mpz_t operator -(long x, mpz_t y)
    {
        ThrowIfDisposed(y);

        if (x >= 0)
        {
            mpz_t z = new();

            mpz.ui_sub(z, (ulong)x, y);

            return z;
        }
        else
        {
            mpz_t z = new();

            mpz.add_ui(z, y, (ulong)-x);
            mpz.neg(z, z);

            return z;
        }
    }

    /// <summary>
    /// Subtracts two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpz_t operator -(mpz_t x, long y)
    {
        ThrowIfDisposed(x);

        mpz_t z = new();

        if (y >= 0)
            mpz.sub_ui(z, x, (ulong)y);
        else
            mpz.add_ui(z, x, (ulong)-y);

        return z;
    }

    /// <summary>
    /// Subtracts two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static mpz_t operator -(ulong x, mpz_t y)
    {
        ThrowIfDisposed(y);

        mpz_t z = new();

        mpz.ui_sub(z, x, y);

        return z;
    }

    /// <summary>
    /// Subtracts two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpz_t operator -(mpz_t x, ulong y)
    {
        ThrowIfDisposed(x);

        mpz_t z = new();

        mpz.sub_ui(z, x, y);

        return z;
    }

    /// <summary>
    /// Decrements an operand.
    /// </summary>
    /// <param name="x">The operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpz_t operator --(mpz_t x)
    {
        ThrowIfDisposed(x);

        // The operand is left unchanged: C# assigns the result to the variable, and the operand may be shared.
        mpz_t z = new();

        mpz.sub_ui(z, x, 1UL);

        return z;
    }

    /// <summary>
    /// Multiplies two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static mpz_t operator *(mpz_t x, mpz_t y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpz_t z = new();

        mpz.mul(z, x, y);

        return z;
    }

    /// <summary>
    /// Multiplies two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static mpz_t operator *(long x, mpz_t y)
    {
        ThrowIfDisposed(y);

        mpz_t z = new();

        mpz.mul_si(z, y, x);

        return z;
    }

    /// <summary>
    /// Multiplies two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpz_t operator *(mpz_t x, long y)
    {
        ThrowIfDisposed(x);

        mpz_t z = new();

        mpz.mul_si(z, x, y);

        return z;
    }

    /// <summary>
    /// Multiplies two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static mpz_t operator *(ulong x, mpz_t y)
    {
        ThrowIfDisposed(y);

        mpz_t z = new();

        mpz.mul_ui(z, y, x);

        return z;
    }

    /// <summary>
    /// Multiplies two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpz_t operator *(mpz_t x, ulong y)
    {
        ThrowIfDisposed(x);

        mpz_t z = new();

        mpz.mul_ui(z, x, y);

        return z;
    }

    /// <summary>
    /// Shifts an operand to the left.
    /// </summary>
    /// <param name="x">The operand.</param>
    /// <param name="count">The number of bits to shift. A negative count shifts to the right.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpz_t operator <<(mpz_t x, int count)
    {
        ThrowIfDisposed(x);

        mpz_t z = new();

        if (count >= 0)
            mpz.mul_2exp(z, x, (ulong)count);
        else
            mpz.fdiv_q_2exp(z, x, NegatedCount(count));

        return z;
    }

    /// <summary>
    /// Shifts an operand to the right, rounding toward negative infinity like <see cref="BigInteger"/>.
    /// </summary>
    /// <param name="x">The operand.</param>
    /// <param name="count">The number of bits to shift. A negative count shifts to the left.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpz_t operator >>(mpz_t x, int count)
    {
        ThrowIfDisposed(x);

        mpz_t z = new();

        if (count >= 0)
            mpz.fdiv_q_2exp(z, x, (ulong)count);
        else
            mpz.mul_2exp(z, x, NegatedCount(count));

        return z;
    }

    private static ulong NegatedCount(int count)
        => (ulong)-(long)count;

    /// <summary>
    /// Negates an operand.
    /// </summary>
    /// <param name="x">The operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpz_t operator -(mpz_t x)
    {
        ThrowIfDisposed(x);

        mpz_t z = new();

        mpz.neg(z, x);

        return z;
    }

    /// <summary>
    /// Divides two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static mpz_t operator /(mpz_t x, mpz_t y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpz_t quotient = new();

        mpz.tdiv_q(quotient, x, y);

        return quotient;
    }

    /// <summary>
    /// Divides two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpz_t operator /(mpz_t x, long y)
    {
        ThrowIfDisposed(x);

        if (y >= 0)
        {
            mpz_t quotient = new();

            mpz.tdiv_q_ui(quotient, x, (ulong)y);

            return quotient;
        }
        else
        {
            mpz_t quotient = new();

            mpz.tdiv_q_ui(quotient, x, (ulong)-y);
            mpz.neg(quotient, quotient);

            return quotient;
        }
    }

    /// <summary>
    /// Divides two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpz_t operator /(mpz_t x, ulong y)
    {
        ThrowIfDisposed(x);

        mpz_t quotient = new();

        mpz.tdiv_q_ui(quotient, x, y);

        return quotient;
    }

    /// <summary>
    /// Gets the remainder of the division of two operands. Like <see cref="BigInteger"/>, the remainder has the sign of <paramref name="x"/>, so that x == (x / mod) * mod + x % mod.
    /// For a remainder that is never negative, use <see cref="mpz.mod"/>.
    /// </summary>
    /// <param name="x">The operand.</param>
    /// <param name="mod">The divisor.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="mod"/> is disposed.</exception>
    public static mpz_t operator %(mpz_t x, mpz_t mod)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(mod);

        mpz_t z = new();

        mpz.tdiv_r(z, x, mod);

        return z;
    }

    /// <summary>
    /// Gets the remainder of the division of two operands. Like <see cref="BigInteger"/>, the remainder has the sign of <paramref name="x"/>, so that x == (x / mod) * mod + x % mod.
    /// </summary>
    /// <param name="x">The operand.</param>
    /// <param name="mod">The divisor.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpz_t operator %(mpz_t x, long mod)
    {
        ThrowIfDisposed(x);

        mpz_t z = new();

        // The sign of the divisor does not change the remainder. The negation is unchecked so that long.MinValue gives 2^63.
        ulong AbsoluteMod = mod >= 0 ? (ulong)mod : unchecked((ulong)-mod);
        _ = mpz.tdiv_r_ui(z, x, AbsoluteMod);

        return z;
    }

    /// <summary>
    /// Gets the remainder of the division of two operands. Like <see cref="BigInteger"/>, the remainder has the sign of <paramref name="x"/>, so that x == (x / mod) * mod + x % mod.
    /// </summary>
    /// <param name="x">The operand.</param>
    /// <param name="mod">The divisor.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpz_t operator %(mpz_t x, ulong mod)
    {
        ThrowIfDisposed(x);

        mpz_t z = new();

        _ = mpz.tdiv_r_ui(z, x, mod);

        return z;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator <(mpz_t? x, mpz_t? y)
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
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator <(int x, mpz_t? y)
    {
        return y is not null && y.CompareTo(x) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator <(mpz_t? x, int y)
    {
        return x is null || x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator <(uint x, mpz_t? y)
    {
        return y is not null && y.CompareTo(x) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator <(mpz_t? x, uint y)
    {
        return x is null || x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator <(long x, mpz_t? y)
    {
        return y is not null && y.CompareTo(x) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator <(mpz_t? x, long y)
    {
        return x is null || x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator <(ulong x, mpz_t? y)
    {
        return y is not null && y.CompareTo(x) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator <(mpz_t? x, ulong y)
    {
        return x is null || x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator <(float x, mpz_t? y)
    {
        return y is not null && (!double.IsNaN(x) && y.CompareTo(x) > 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator <(mpz_t? x, float y)
    {
        return x is null || (!double.IsNaN(y) && x.CompareTo(y) < 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator <(double x, mpz_t? y)
    {
        return y is not null && (!double.IsNaN(x) && y.CompareTo(x) > 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator <(mpz_t? x, double y)
    {
        return x is null || (!double.IsNaN(y) && x.CompareTo(y) < 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator <=(mpz_t? x, mpz_t? y)
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
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator <=(int x, mpz_t? y)
    {
        return y is not null && y.CompareTo(x) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator <=(mpz_t? x, int y)
    {
        return x is null || x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator <=(uint x, mpz_t? y)
    {
        return y is not null && y.CompareTo(x) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator <=(mpz_t? x, uint y)
    {
        return x is null || x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator <=(long x, mpz_t? y)
    {
        return y is not null && y.CompareTo(x) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator <=(mpz_t? x, long y)
    {
        return x is null || x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator <=(ulong x, mpz_t? y)
    {
        return y is not null && y.CompareTo(x) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator <=(mpz_t? x, ulong y)
    {
        return x is null || x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator <=(float x, mpz_t? y)
    {
        return y is not null && (!double.IsNaN(x) && y.CompareTo(x) >= 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator <=(mpz_t? x, float y)
    {
        return x is null || (!double.IsNaN(y) && x.CompareTo(y) <= 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator <=(double x, mpz_t? y)
    {
        return y is not null && (!double.IsNaN(x) && y.CompareTo(x) >= 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator <=(mpz_t? x, double y)
    {
        return x is null || (!double.IsNaN(y) && x.CompareTo(y) <= 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator >(mpz_t? x, mpz_t? y)
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
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator >(int x, mpz_t? y)
    {
        return y is null || y.CompareTo(x) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator >(mpz_t? x, int y)
    {
        return x is not null && x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator >(uint x, mpz_t? y)
    {
        return y is null || y.CompareTo(x) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator >(mpz_t? x, uint y)
    {
        return x is not null && x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator >(long x, mpz_t? y)
    {
        return y is null || y.CompareTo(x) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator >(mpz_t? x, long y)
    {
        return x is not null && x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator >(ulong x, mpz_t? y)
    {
        return y is null || y.CompareTo(x) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator >(mpz_t? x, ulong y)
    {
        return x is not null && x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator >(float x, mpz_t? y)
    {
        return y is null || (!double.IsNaN(x) && y.CompareTo(x) < 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator >(mpz_t? x, float y)
    {
        return x is not null && (!double.IsNaN(y) && x.CompareTo(y) > 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator >(double x, mpz_t? y)
    {
        return y is null || (!double.IsNaN(x) && y.CompareTo(x) < 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator >(mpz_t? x, double y)
    {
        return x is not null && (!double.IsNaN(y) && x.CompareTo(y) > 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator >=(mpz_t? x, mpz_t? y)
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
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator >=(int x, mpz_t? y)
    {
        return y is null || y.CompareTo(x) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator >=(mpz_t? x, int y)
    {
        return x is not null && x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator >=(uint x, mpz_t? y)
    {
        return y is null || y.CompareTo(x) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator >=(mpz_t? x, uint y)
    {
        return x is not null && x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator >=(long x, mpz_t? y)
    {
        return y is null || y.CompareTo(x) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator >=(mpz_t? x, long y)
    {
        return x is not null && x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator >=(ulong x, mpz_t? y)
    {
        return y is null || y.CompareTo(x) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator >=(mpz_t? x, ulong y)
    {
        return x is not null && x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator >=(float x, mpz_t? y)
    {
        return y is null || (!double.IsNaN(x) && y.CompareTo(x) <= 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator >=(mpz_t? x, float y)
    {
        return x is not null && (!double.IsNaN(y) && x.CompareTo(y) >= 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator >=(double x, mpz_t? y)
    {
        return y is null || (!double.IsNaN(x) && y.CompareTo(x) <= 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator >=(mpz_t? x, double y)
    {
        return x is not null && (!double.IsNaN(y) && x.CompareTo(y) >= 0);
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator ==(mpz_t? x, mpz_t? y)
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
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator ==(int x, mpz_t? y)
    {
        return y is not null && y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator ==(mpz_t? x, int y)
    {
        return x is not null && x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator ==(uint x, mpz_t? y)
    {
        return y is not null && y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator ==(mpz_t? x, uint y)
    {
        return x is not null && x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator ==(long x, mpz_t? y)
    {
        return y is not null && y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator ==(mpz_t? x, long y)
    {
        return x is not null && x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator ==(ulong x, mpz_t? y)
    {
        return y is not null && y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator ==(mpz_t? x, ulong y)
    {
        return x is not null && x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator ==(float x, mpz_t? y)
    {
        return y is not null && !double.IsNaN(x) && y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator ==(mpz_t? x, float y)
    {
        return x is not null && !double.IsNaN(y) && x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator ==(double x, mpz_t? y)
    {
        return y is not null && !double.IsNaN(x) && y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator ==(mpz_t? x, double y)
    {
        return x is not null && !double.IsNaN(y) && x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator !=(mpz_t? x, mpz_t? y)
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
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator !=(int x, mpz_t? y)
    {
        return y is null || y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator !=(mpz_t? x, int y)
    {
        return x is null || x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator !=(uint x, mpz_t? y)
    {
        return y is null || y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator !=(mpz_t? x, uint y)
    {
        return x is null || x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator !=(long x, mpz_t? y)
    {
        return y is null || y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator !=(mpz_t? x, long y)
    {
        return x is null || x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator !=(ulong x, mpz_t? y)
    {
        return y is null || y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator !=(mpz_t? x, ulong y)
    {
        return x is null || x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator !=(float x, mpz_t? y)
    {
        return y is null || double.IsNaN(x) || y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator !=(mpz_t? x, float y)
    {
        return x is null || double.IsNaN(y) || x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator !=(double x, mpz_t? y)
    {
        return y is null || double.IsNaN(x) || y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator !=(mpz_t? x, double y)
    {
        return x is null || double.IsNaN(y) || x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Gets the bitwise and of two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static mpz_t operator &(mpz_t x, mpz_t y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpz_t z = new();

        mpz.and(z, x, y);

        return z;
    }

    /// <summary>
    /// Gets the bitwise or of two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static mpz_t operator |(mpz_t x, mpz_t y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpz_t z = new();

        mpz.ior(z, x, y);

        return z;
    }

    /// <summary>
    /// Gets the bitwise xor of two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static mpz_t operator ^(mpz_t x, mpz_t y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpz_t z = new();

        mpz.xor(z, x, y);

        return z;
    }

    /// <summary>
    /// Gets the one's complement of an operand, -x - 1, as for the two's complement representation of integers.
    /// </summary>
    /// <param name="x">The operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpz_t operator ~(mpz_t x)
    {
        ThrowIfDisposed(x);

        mpz_t z = new();

        mpz.com(z, x);

        return z;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object..</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public override bool Equals(object? obj)
    {
        ThrowIfDisposed(this);

        return obj is mpz_t other && Equals(other);
    }

    /// <summary>
    /// Gets the hash of the object.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public override int GetHashCode()
    {
        return Convert.ToBase64String(ToByteArray()).GetHashCode();
    }
}
