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
    /// <exception cref="ObjectDisposedException">This number or <paramref name="other"/> is disposed.</exception>
    public int CompareTo(mpq_t? other)
    {
        ThrowIfDisposed(this);
        ThrowIfDisposed(other);

        return other is null ? 1 : mpq.cmp(this, other);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    /// <returns>A negative value, zero or a positive value if this number is less than, equal to or greater than <paramref name="other"/>, and a positive value if <paramref name="other"/> is <see langword="null"/>.</returns>
    /// <exception cref="ObjectDisposedException">This number or <paramref name="other"/> is disposed.</exception>
    public int CompareTo(mpz_t? other)
    {
        ThrowIfDisposed(this);
        mpz_t.ThrowIfDisposed(other);

        return other is null ? 1 : mpq.cmp_z(this, other);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public int CompareTo(long other)
    {
        ThrowIfDisposed(this);

        return mpq.cmp_si(this, other, 1UL);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public int CompareTo(ulong other)
    {
        ThrowIfDisposed(this);

        return mpq.cmp_ui(this, other, 1UL);
    }

    /// <summary>
    /// Compares with another number, exactly.
    /// </summary>
    /// <param name="other">The other number.</param>
    /// <returns>A negative value, zero or a positive value if this number is less than, equal to or greater than <paramref name="other"/>, and a positive value if <paramref name="other"/> is NaN.</returns>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public int CompareTo(double other)
    {
        ThrowIfDisposed(this);

        if (double.IsNaN(other) || double.IsNegativeInfinity(other))
            return 1;

        if (double.IsPositiveInfinity(other))
            return -1;

        // A finite double is a rational number: mpq_set_d converts it exactly.
        using mpq_t Other = new();
        mpq.set_d(Other, other);

        return mpq.cmp(this, Other);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    /// <exception cref="ObjectDisposedException">This number or <paramref name="other"/> is disposed.</exception>
    public bool IsEqualTo(mpq_t other)
    {
        ThrowIfDisposed(this);
        ThrowIfDisposed(other);

        return mpq.equal(this, other);
    }
}
