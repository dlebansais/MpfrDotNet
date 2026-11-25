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
    /// Returns a string that represents the current object.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public override string ToString()
    {
        return ToString(mpz_t.DefaultBase);
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <param name="resultbase">The digit base.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="resultbase"/> is not between 2 and 62, or between -36 and -2.</exception>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public string ToString(int resultbase)
    {
        ThrowIfDisposed(this);

        _ = DigitBase.ToDigitCountBase(resultbase, nameof(resultbase));

        StringBuilder Data = new();
        mpq.get_str(Data, resultbase, this);

        string Result = Data.ToString();
        return Result;
    }

    /// <summary>
    /// Converts from a <see cref="float"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpq_t(float value)
    {
        return new mpq_t((double)value);
    }

    /// <summary>
    /// Converts from a <see cref="double"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpq_t(double value)
    {
        return new mpq_t(value);
    }

    /// <summary>
    /// Converts to a <see cref="float"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="value"/> is disposed.</exception>
    /// <remarks>The value is rounded once, to the nearest <see cref="float"/>, ties to even.</remarks>
    public static explicit operator float(mpq_t value)
    {
        ThrowIfDisposed(value);

        // Converting through double would round twice: the value is rounded once, to a float, which converts exactly.
        return (float)MpfrDotNet.mpfr_t.RoundToBinaryFormat(x => MpfrDotNet.mpfr.set_q(x, value, MpfrDotNet.mpfr_rnd_t.MPFR_RNDN), isSingle: true);
    }

    /// <summary>
    /// Converts to a <see cref="double"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="value"/> is disposed.</exception>
    /// <remarks>The value is rounded once, to the nearest <see cref="double"/>, ties to even, like the conversion from <see cref="decimal"/>. <see cref="mpq.get_d(mpq_t)"/> truncates instead.</remarks>
    public static explicit operator double(mpq_t value)
    {
        ThrowIfDisposed(value);

        // mpq.get_d truncates: the value is rounded once, to the nearest double.
        return MpfrDotNet.mpfr_t.RoundToBinaryFormat(x => MpfrDotNet.mpfr.set_q(x, value, MpfrDotNet.mpfr_rnd_t.MPFR_RNDN), isSingle: false);
    }
}
