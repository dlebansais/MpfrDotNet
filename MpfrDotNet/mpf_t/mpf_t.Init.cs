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
    /// Initializes a new instance of the <see cref="mpf_t"/> class.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="precision">The precision.</param>
    public mpf_t(ulong precision = ulong.MaxValue)
    {
        if (precision == ulong.MaxValue)
            mpf_init(ref Value);
        else
            mpf_init2(ref Value, (mp_bitcnt_t)precision);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpf_t"/> class.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The value.</param>
    /// <param name="precision">The precision.</param>
    public mpf_t(ulong n, ulong precision)
    {
        if (precision == ulong.MaxValue)
            mpf_init_set_ui(ref Value, (mpir_ui)n);
        else
        {
            mpf_init2(ref Value, (mp_bitcnt_t)precision);
            mpf_set_ui(ref Value, (mpir_ui)n);
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpf_t"/> class.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The value.</param>
    /// <param name="precision">The precision.</param>
    public mpf_t(long n, ulong precision = ulong.MaxValue)
    {
        if (precision == ulong.MaxValue)
            mpf_init_set_si(ref Value, (mpir_si)n);
        else
        {
            mpf_init2(ref Value, (mp_bitcnt_t)precision);
            mpf_set_si(ref Value, (mpir_si)n);
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpf_t"/> class.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="d">The value.</param>
    /// <param name="precision">The precision.</param>
    public mpf_t(double d, ulong precision = ulong.MaxValue)
    {
        if (precision == ulong.MaxValue)
            mpf_init_set_d(ref Value, d);
        else
        {
            mpf_init2(ref Value, (mp_bitcnt_t)precision);
            mpf_set_d(ref Value, d);
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpf_t"/> class.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="s">The value.</param>
    /// <param name="precision">The precision.</param>
    public mpf_t(string s, ulong precision = ulong.MaxValue)
        : this(s, mpz_t.DefaultBase, precision)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpf_t"/> class.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="s">The value.</param>
    /// <param name="strBase">The base.</param>
    /// <param name="precision">The precision.</param>
    public mpf_t(string s, uint strBase, ulong precision = ulong.MaxValue)
    {
        int Success;

        if (precision == ulong.MaxValue)
            Success = mpf_init_set_str(ref Value, s, strBase);
        else
        {
            mpf_init2(ref Value, (mp_bitcnt_t)precision);
            Success = mpf_set_str(ref Value, s, strBase);
        }

        if (Success != 0)
            throw new ArgumentException();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpf_t"/> class.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="other">The value.</param>
    /// <param name="useDefaultPrecision">True to use the default precision.</param>
    public mpf_t(mpf_t other, bool useDefaultPrecision = false)
    {
        if (useDefaultPrecision)
        {
            mpf_init_set(ref Value, ref other.Value);
        }
        else
        {
            mpf_init2(ref Value, mpf_get_prec(ref other.Value));
            mpf_set(ref Value, ref other.Value);
        }
    }

#pragma warning disable SA1401 // Fields should be private
#pragma warning disable SA1600 // Elements should be documented
    internal __mpf_t Value;
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore SA1600 // Elements should be documented
}
