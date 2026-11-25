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
    public override string ToString()
    {
        return ToString(mpz_t.DefaultBase);
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <param name="resultbase">The digit base.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="resultbase"/> is not between 2 and 62, or between -36 and -2.</exception>
    public string ToString(int resultbase)
    {
        uint DigitCountBase = DigitBase.ToDigitCountBase(resultbase, nameof(resultbase));

        using mpz_t Numerator = new();
        mpq.get_num(Numerator, this);

        using mpz_t Denominator = new();
        mpq.get_den(Denominator, this);

        ulong SizeInDigits = (ulong)mpz_sizeinbase(ref Numerator.Value, DigitCountBase) + (ulong)mpz_sizeinbase(ref Denominator.Value, DigitCountBase);

        StringBuilder Data = new((int)(SizeInDigits + 3));
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
    /// <remarks>The value is rounded once, to the nearest <see cref="float"/>, except in the subnormal range of <see cref="float"/>.</remarks>
    public static explicit operator float(mpq_t value)
    {
        // Converting through double would round twice. A 24-bit MPFR number is rounded once, and converts exactly.
        using MpfrDotNet.mpfr_t Rounded = MpfrDotNet.mpfr_t.Create(FloatSignificandBits);
        _ = MpfrDotNet.mpfr.set_q(Rounded, value, MpfrDotNet.mpfr_rnd_t.MPFR_RNDN);

        return (float)MpfrDotNet.mpfr.get_d(Rounded, MpfrDotNet.mpfr_rnd_t.MPFR_RNDN);
    }

    private const ulong FloatSignificandBits = 24;

    /// <summary>
    /// Converts to a <see cref="double"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static explicit operator double(mpq_t value)
    {
        return mpq.get_d(value);
    }
}
