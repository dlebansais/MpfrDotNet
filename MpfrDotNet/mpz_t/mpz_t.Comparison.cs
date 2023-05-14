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
            return mpz_cmp(ref Value, ref other.Value);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    public int CompareTo(long other)
    {
        return mpz_cmp_si(ref Value, (mpir_si)other);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    public int CompareTo(ulong other)
    {
        return mpz_cmp_ui(ref Value, (mpir_ui)other);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    public int CompareTo(float other)
    {
        return mpz_cmp_d(ref Value, other);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    public int CompareTo(double other)
    {
        return mpz_cmp_d(ref Value, other);
    }
}
