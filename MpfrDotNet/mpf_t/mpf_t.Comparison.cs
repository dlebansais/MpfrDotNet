namespace MpirDotNet;

using System;
using System.Text;
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
    public int CompareTo(mpf_t? other)
    {
        if (ReferenceEquals(other, null))
            throw new ArgumentNullException(nameof(other));
        else
            return mpf_cmp(ref Value, ref other.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="other">The compared value.</param>
    public int CompareTo(long other)
    {
        return mpf_cmp_si(ref Value, (mpir_si)other);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="other">The compared value.</param>
    public int CompareTo(ulong other)
    {
        return mpf_cmp_ui(ref Value, (mpir_ui)other);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="other">The compared value.</param>
    public int CompareTo(float other)
    {
        return mpf_cmp_d(ref Value, (double)other);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="other">The compared value.</param>
    public int CompareTo(double other)
    {
        return mpf_cmp_d(ref Value, other);
    }
}
