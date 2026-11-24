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
    /// <returns>A positive value if <paramref name="other"/> is <see langword="null"/>, as with other .NET types.</returns>
    public int CompareTo(mpz_t? other)
    {
        return other is null ? 1 : mpz.cmp(this, other);
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
    /// <returns>A positive value if <paramref name="other"/> is NaN, as with <see cref="double.CompareTo(double)"/>.</returns>
    public int CompareTo(float other)
    {
        return CompareTo((double)other);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    /// <returns>A positive value if <paramref name="other"/> is NaN, as with <see cref="double.CompareTo(double)"/>.</returns>
    public int CompareTo(double other)
    {
        return double.IsNaN(other) ? 1 : mpz.cmp_d(this, other);
    }
}
