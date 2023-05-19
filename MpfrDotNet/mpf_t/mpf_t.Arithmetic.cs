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
    /// Gets the absolute value of the number.
    /// </summary>
    public mpf_t Abs()
    {
        mpf_t z = new mpf_t();

        mpf.abs(z, this);

        return z;
    }

    /// <summary>
    /// Gets the value sign.
    /// </summary>
    public int Sign
    {
        get { return mpf.sgn(this); }
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    public mpf_t Sqrt()
    {
        mpf_t Result = new mpf_t();

        mpf.sqrt(Result, this);

        return Result;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="exp">The power.</param>
    public mpf_t Pow(ulong exp)
    {
        mpf_t Result = new mpf_t();

        mpf.pow_ui(Result, this, exp);

        return Result;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="value">The value.</param>
    public static mpf_t Sqrt(ulong value)
    {
        mpf_t Result = new mpf_t();

        mpf.sqrt_ui(Result, value);

        return Result;
    }
}
