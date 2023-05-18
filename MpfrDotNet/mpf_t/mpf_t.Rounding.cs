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

        mpf.ceil(z, this);

        return z;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    public mpf_t Floor()
    {
        mpf_t z = new mpf_t(Precision);

        mpf.floor(z, this);

        return z;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    public mpf_t Trunc()
    {
        mpf_t z = new mpf_t(Precision);

        mpf.trunc(z, this);

        return z;
    }
}
