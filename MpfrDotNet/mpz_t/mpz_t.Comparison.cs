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
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    public int CompareTo(mpz_t? other)
    {
        if (ReferenceEquals(other, null))
            throw new ArgumentNullException(nameof(other));
        else
            return mpz.cmp(this, other);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    public int CompareTo(long other)
    {
        return mpz.cmp_si(this, other);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    public int CompareTo(ulong other)
    {
        return mpz.cmp_ui(this, other);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    public int CompareTo(float other)
    {
        return mpz.cmp_d(this, other);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    public int CompareTo(double other)
    {
        return mpz.cmp_d(this, other);
    }
}
