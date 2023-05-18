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
    /// Gets or sets the default precision.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    public static ulong DefaultPrecision
    {
        get
        {
            return (ulong)mpf_get_default_prec();
        }
        set
        {
            mpf_set_default_prec((mp_bitcnt_t)value);
        }
    }

    /// <summary>
    /// Gets or sets the precision.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    public ulong Precision
    {
        get
        {
            return (ulong)mpf_get_prec(ref Value);
        }
        set
        {
            mpf_set_prec(ref Value, (mp_bitcnt_t)value);
        }
    }

    /// <summary>
    /// Gets a value indicating whether the number is an integer.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    public bool IsInteger
    {
        get
        {
            return mpf_integer_p(ref Value) != 0;
        }
    }
}
