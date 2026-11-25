namespace MpirDotNet;

using System;

/// <summary>
/// Arbitrary precision rational number.
/// </summary>
public partial class mpq_t : IDisposable, IEquatable<mpq_t>, ICloneable, IConvertible, IComparable, IComparable<mpq_t>
{
    /// <summary>
    /// Canonicalize the number.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public void Canonicalize()
    {
        ThrowIfDisposed(this);

        mpq.canonicalize(this);
    }

    /// <summary>
    /// Gets the number sign.
    /// </summary>
    /// <exception cref="ObjectDisposedException">The number is disposed.</exception>
    public int Sign
    {
        get
        {
            ThrowIfDisposed(this);

            return mpq.sgn(this);
        }
    }

    /// <summary>
    /// Gets the number numerator.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpz_t GetNumerator()
    {
        ThrowIfDisposed(this);

        // mpq.get_num reads through a reference to this number, which keeps it alive during the copy: a copy of
        // Value would let a temporary be finalized before its limbs are read.
        mpz_t Result = new();
        mpq.get_num(Result, this);

        return Result;
    }

    /// <summary>
    /// Sets the number numerator.
    /// </summary>
    /// <param name="numerator">The numerator.</param>
    /// <exception cref="ObjectDisposedException">This number or <paramref name="numerator"/> is disposed.</exception>
    public void SetNumerator(mpz_t numerator)
    {
        ThrowIfDisposed(this);
        mpz_t.ThrowIfDisposed(numerator);

        mpq.set_num(this, numerator);
        mpq.canonicalize(this);
    }

    /// <summary>
    /// Gets the number denominator.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpz_t GetDenominator()
    {
        ThrowIfDisposed(this);

        // See GetNumerator.
        mpz_t Result = new();
        mpq.get_den(Result, this);

        return Result;
    }

    /// <summary>
    /// Sets the number denominator.
    /// </summary>
    /// <param name="denominator">The denominator.</param>
    /// <exception cref="DivideByZeroException"><paramref name="denominator"/> is zero.</exception>
    /// <exception cref="ObjectDisposedException">This number or <paramref name="denominator"/> is disposed.</exception>
    public void SetDenominator(mpz_t denominator)
    {
        ThrowIfDisposed(this);
        mpz_t.ThrowIfDisposed(denominator);

        // The check comes first: once a zero denominator is stored, any MPIR call on this number aborts the process.
        if (mpz.sgn(denominator) == 0)
            throw new DivideByZeroException("The denominator cannot be zero.");

        mpq.set_den(this, denominator);
        mpq.canonicalize(this);
    }

    /// <summary>
    /// Swaps two numbers.
    /// </summary>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static void Swap(mpq_t x, mpq_t y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpq.swap(x, y);
    }
}
