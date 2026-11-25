namespace MpirDotNet;

using System;
using static Interop.Mpir.NativeMethods;

/// <summary>
/// See http://mpir.org/mpir-3.0.0.pdf.
/// </summary>
public partial class mpf_t : IDisposable, IEquatable<mpf_t>, ICloneable, IConvertible, IComparable, IComparable<mpf_t>
{
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="other">The compared value.</param>
    /// <returns>A positive value if <paramref name="other"/> is <see langword="null"/>, as with other .NET types.</returns>
    public int CompareTo(mpf_t? other)
    {
        return other is null ? 1 : mpf.cmp(this, other);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="other">The compared value.</param>
    public int CompareTo(long other)
    {
        return mpf.cmp_si(this, other);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="other">The compared value.</param>
    public int CompareTo(ulong other)
    {
        return mpf.cmp_ui(this, other);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="other">The compared value.</param>
    /// <returns>A positive value if <paramref name="other"/> is NaN, as with <see cref="double.CompareTo(double)"/>.</returns>
    public int CompareTo(float other)
    {
        return CompareTo((double)other);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="other">The compared value.</param>
    /// <returns>A positive value if <paramref name="other"/> is NaN, as with <see cref="double.CompareTo(double)"/>.</returns>
    public int CompareTo(double other)
    {
        return double.IsNaN(other) ? 1 : mpf.cmp_d(this, other);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <param name="bitcount">The number of bits.</param>
    public static bool EqualBits(mpf_t x, mpf_t y, ulong bitcount)
    {
        return mpf.eq(x, y, bitcount) != 0;
    }

    /// <summary>
    /// Returns the relative difference between two numbers.
    /// </summary>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    public static mpf_t RelativeDifference(mpf_t x, mpf_t y)
    {
        mpf_t z = CreateResult(x, y);

        mpf.reldiff(z, x, y);

        return z;
    }
}
