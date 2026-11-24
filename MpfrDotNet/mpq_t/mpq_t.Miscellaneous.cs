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
    public void Canonicalize()
    {
        mpq.canonicalize(this);
    }

    /// <summary>
    /// Gets the number sign.
    /// </summary>
    public int Sign
    {
        get { return mpq.sgn(this); }
    }

    /// <summary>
    /// Gets the number numerator.
    /// </summary>
    public mpz_t GetNumerator()
    {
        return new mpz_t(Value.Numerator);
    }

    /// <summary>
    /// Sets the number numerator.
    /// </summary>
    /// <param name="numerator">The numerator.</param>
    public void SetNumerator(mpz_t numerator)
    {
        mpq.set_num(this, numerator);
        mpq.canonicalize(this);
    }

    /// <summary>
    /// Gets the number denominator.
    /// </summary>
    public mpz_t GetDenominator()
    {
        return new mpz_t(Value.Denominator);
    }

    /// <summary>
    /// Sets the number denominator.
    /// </summary>
    /// <param name="denominator">The denominator.</param>
    /// <exception cref="DivideByZeroException"><paramref name="denominator"/> is zero.</exception>
    public void SetDenominator(mpz_t denominator)
    {
        mpq.set_den(this, denominator);
        mpq.canonicalize(this);
    }

    /// <summary>
    /// Swaps two numbers.
    /// </summary>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    public static void Swap(mpq_t x, mpq_t y)
    {
        mpq.swap(x, y);
    }
}
