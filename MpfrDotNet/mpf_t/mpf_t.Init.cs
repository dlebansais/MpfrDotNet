namespace MpirDotNet;

using System;
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
            mpf.init(this);
        else
            mpf.init2(this, precision);
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
            mpf.init_set_ui(this, n);
        else
        {
            mpf.init2(this, precision);
            mpf.set_ui(this, n);
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
            mpf.init_set_si(this, n);
        else
        {
            mpf.init2(this, precision);
            mpf.set_si(this, n);
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
            mpf.init_set_d(this, d);
        else
        {
            mpf.init2(this, precision);
            mpf.set_d(this, d);
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpf_t"/> class.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="s">The value.</param>
    /// <param name="precision">The precision.</param>
    /// <exception cref="ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="s"/> is not a valid number.</exception>
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
    /// <exception cref="ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">The combination of <paramref name="s"/> and <paramref name="strBase"/> is invalid.</exception>
    /// <exception cref="OverflowException">The exponent in <paramref name="s"/> is beyond the range of a native long, which MPIR does not check: 2^31 - 1 on Windows.</exception>
    public mpf_t(string s, uint strBase, ulong precision = ulong.MaxValue)
    {
        // The native code would dereference a null string.
        if (s is null)
            throw new ArgumentNullException(nameof(s));

        if (!MpirArgument.IsParsableText(s))
            throw new ArgumentException($"The combination of '{nameof(s)}' and '{nameof(strBase)}' is invalid.");

        mpf.CheckStringExponent(s, strBase);

        int Success;

        if (precision == ulong.MaxValue)
            Success = mpf.init_set_str(this, s, strBase);
        else
        {
            mpf.init2(this, precision);
            Success = mpf.set_str(this, s, strBase);
        }

        if (Success != 0)
        {
            // MPIR initializes the number even when the text is invalid.
            Dispose();
            throw new ArgumentException($"The combination of '{nameof(s)}' and '{nameof(strBase)}' is invalid.");
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpf_t"/> class.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="other">The value.</param>
    /// <param name="useDefaultPrecision">True to use the default precision.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="other"/> is disposed.</exception>
    public mpf_t(mpf_t other, bool useDefaultPrecision = false)
    {
        ThrowIfDisposed(other);

        if (useDefaultPrecision)
        {
            mpf.init_set(this, other);
        }
        else
        {
            mpf.init2(this, mpf.get_prec(other));
            mpf.set(this, other);
        }
    }

    /// <summary>
    /// Sets the exact precision.
    /// </summary>
    /// <param name="value">The precision.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is greater than the precision allocated by the constructor or by the last change of <see cref="Precision"/>.</exception>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public void SetPrecisionRaw(ulong value)
    {
        ThrowIfDisposed(this);

        mpf.set_prec_raw(this, value);
    }

    /// <summary>
    /// Sets the value from an integer.
    /// </summary>
    /// <param name="value">The integer.</param>
    /// <exception cref="ObjectDisposedException">This number or <paramref name="value"/> is disposed.</exception>
    public void Set(mpz_t value)
    {
        ThrowIfDisposed(this);
        mpz_t.ThrowIfDisposed(value);

        mpf.set_z(this, value);
    }

    /// <summary>
    /// Sets the value from a rational.
    /// </summary>
    /// <param name="value">The rational.</param>
    /// <exception cref="ObjectDisposedException">This number or <paramref name="value"/> is disposed.</exception>
    public void Set(mpq_t value)
    {
        ThrowIfDisposed(this);
        mpq_t.ThrowIfDisposed(value);

        mpf.set_q(this, value);
    }

    /// <summary>
    /// Swaps two numbers.
    /// </summary>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static void Swap(mpf_t x, mpf_t y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpf.swap(x, y);
    }

#pragma warning disable SA1401 // Fields should be private
#pragma warning disable SA1600 // Elements should be documented
    internal __mpf_t Value;

    // The precision in limbs allocated by the last initialization or mpf_set_prec, the largest that mpf_set_prec_raw accepts.
    internal int AllocatedPrecision;
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore SA1600 // Elements should be documented
}
