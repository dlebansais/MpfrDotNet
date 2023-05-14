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
    public string ToString(int resultbase)
    {
        using mpz_t Numerator = new();
        mpq_get_num(ref Numerator.Value, ref Value);

        using mpz_t Denominator = new();
        mpq_get_den(ref Denominator.Value, ref Value);

        ulong SizeInDigits = (ulong)mpz_sizeinbase(ref Numerator.Value, (uint)resultbase) + (ulong)mpz_sizeinbase(ref Denominator.Value, (uint)resultbase);

        StringBuilder Data = new StringBuilder((int)(SizeInDigits + 3));
        mpq_get_str(Data, resultbase, ref Value);

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
    public static explicit operator float(mpq_t value)
    {
        return (float)(double)value;
    }

    /// <summary>
    /// Converts to a <see cref="double"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static explicit operator double(mpq_t value)
    {
        return mpq_get_d(ref value.Value);
    }
}
