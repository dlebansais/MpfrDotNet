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
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    /// <returns>A positive value if <paramref name="other"/> is <see langword="null"/>, as with other .NET types.</returns>
    public int CompareTo(mpq_t? other)
    {
        return other is null ? 1 : mpq.cmp(this, other);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    public int CompareTo(mpz_t other)
    {
        return mpq.cmp_z(this, other);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    public bool IsEqualTo(mpq_t other)
    {
        return mpq.equal(this, other);
    }
}
