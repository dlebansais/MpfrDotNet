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
    public mpf_t Ceil()
    {
        mpf_t z = new mpf_t(Precision);

        mpf_ceil(ref z.Value, ref Value);

        return z;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    public mpf_t Floor()
    {
        mpf_t z = new mpf_t(Precision);

        mpf_floor(ref z.Value, ref Value);

        return z;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    public mpf_t Trunc()
    {
        mpf_t z = new mpf_t(Precision);

        mpf_trunc(ref z.Value, ref Value);

        return z;
    }
}
