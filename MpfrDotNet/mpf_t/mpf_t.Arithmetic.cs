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

        mpf_abs(ref z.Value, ref Value);

        return z;
    }

    /// <summary>
    /// Gets the value sign.
    /// </summary>
    public int Sign
    {
        get { return mpf_sgn(ref Value); }
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    public mpf_t Sqrt()
    {
        mpf_t Result = new mpf_t();

        mpf_sqrt(ref Result.Value, ref Value);

        return Result;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="exp">The power.</param>
    public mpf_t Pow(ulong exp)
    {
        mpf_t Result = new mpf_t();

        mpf_pow_ui(ref Result.Value, ref Value, (mpir_ui)exp);

        return Result;
    }
}
