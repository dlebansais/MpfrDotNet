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
    /// Gets the absolute value of the number.
    /// </summary>
    public mpq_t Abs()
    {
        mpq_t z = new mpq_t();

        mpq.abs(z, this);

        return z;
    }

    /// <summary>
    /// Gets the inverse of the number.
    /// </summary>
    public mpq_t Inverse()
    {
        mpq_t z = new mpq_t();

        mpq.inv(z, this);

        return z;
    }
}
