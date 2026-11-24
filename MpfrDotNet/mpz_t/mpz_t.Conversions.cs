namespace MpirDotNet;

using System;
using System.Numerics;
using System.Text;
using static Interop.Mpir.NativeMethods;

/// <summary>
/// Arbitrary precision integer.
/// </summary>
public partial class mpz_t : IDisposable, IEquatable<mpz_t>, ICloneable, IConvertible, IComparable, IComparable<mpz_t>
{
    /// <summary>
    /// Gets the number bytes.
    /// </summary>
    public byte[] ToByteArray()
    {
        ulong SizeInBits = (ulong)mpz_sizeinbase(ref Value, 2);
        byte[] Result = new byte[(SizeInBits + 7) / 8];

        mpz.export(Result, out _, -1, sizeof(byte), -1, 0UL, this);

        return Result;
    }

    /// <summary>
    /// Returns a string that represents the number value.
    /// </summary>
    /// <returns>The number value.</returns>
    public override string ToString()
    {
        return ToString(DefaultBase);
    }

    /// <summary>
    /// Returns a string that represents the number value.
    /// </summary>
    /// <param name="resultbase">The digit base used in the result.</param>
    /// <returns>The number value.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="resultbase"/> is not between 2 and 62, or between -36 and -2.</exception>
    public string ToString(int resultbase)
    {
        ulong SizeInDigits = mpz.sizeinbase(this, DigitBase.ToDigitCountBase(resultbase, nameof(resultbase)));

        StringBuilder Data = new((int)(SizeInDigits + 2));
        mpz.get_str(Data, resultbase, this);

        string Result = Data.ToString();
        return Result;
    }

    /// <summary>
    /// Converts from a <see cref="byte"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpz_t(byte value)
    {
        return new mpz_t((uint)value);
    }

    /// <summary>
    /// Converts from a <see cref="int"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpz_t(int value)
    {
        return new mpz_t(value);
    }

    /// <summary>
    /// Converts from a <see cref="uint"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpz_t(uint value)
    {
        return new mpz_t(value);
    }

    /// <summary>
    /// Converts from a <see cref="short"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpz_t(short value)
    {
        return new mpz_t(value);
    }

    /// <summary>
    /// Converts from a <see cref="ushort"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpz_t(ushort value)
    {
        return new mpz_t(value);
    }

    /// <summary>
    /// Converts from a <see cref="long"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpz_t(long value)
    {
        return new mpz_t(value);
    }

    /// <summary>
    /// Converts from a <see cref="ulong"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpz_t(ulong value)
    {
        return new mpz_t(value);
    }

    /// <summary>
    /// Converts from a <see cref="float"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpz_t(float value)
    {
        return new mpz_t((double)value);
    }

    /// <summary>
    /// Converts from a <see cref="double"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpz_t(double value)
    {
        return new mpz_t(value);
    }

    /// <summary>
    /// Converts from a <see cref="BigInteger"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator mpz_t(BigInteger value)
    {
        return new mpz_t(value);
    }

    /// <summary>
    /// Converts to a <see cref="byte"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="OverflowException">The value is outside the range of the target type.</exception>
    public static explicit operator byte(mpz_t value)
    {
        return checked((byte)(ulong)value);
    }

    /// <summary>
    /// Converts to a <see cref="int"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="OverflowException">The value is outside the range of the target type.</exception>
    public static explicit operator int(mpz_t value)
    {
        return checked((int)(long)value);
    }

    /// <summary>
    /// Converts to a <see cref="uint"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="OverflowException">The value is outside the range of the target type.</exception>
    public static explicit operator uint(mpz_t value)
    {
        return checked((uint)(ulong)value);
    }

    /// <summary>
    /// Converts to a <see cref="short"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="OverflowException">The value is outside the range of the target type.</exception>
    public static explicit operator short(mpz_t value)
    {
        return checked((short)(long)value);
    }

    /// <summary>
    /// Converts to a <see cref="ushort"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="OverflowException">The value is outside the range of the target type.</exception>
    public static explicit operator ushort(mpz_t value)
    {
        return checked((ushort)(ulong)value);
    }

    /// <summary>
    /// Converts to a <see cref="long"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="OverflowException">The value is outside the range of the target type.</exception>
    public static explicit operator long(mpz_t value)
    {
        if (mpz.cmp_si(value, long.MinValue) < 0 || mpz.cmp_si(value, long.MaxValue) > 0)
            throw new OverflowException("The value is outside the range of the target type.");

        byte[] Bytes = new byte[8];
        mpz.export(Bytes, out _, -1, sizeof(byte), -1, 0, value);

        long Int64Result = BitConverter.ToInt64(Bytes, 0);
        if (mpz.cmp_si(value, 0) < 0)
            Int64Result = -Int64Result;

        return Int64Result;
    }

    /// <summary>
    /// Converts to a <see cref="ulong"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="OverflowException">The value is outside the range of the target type.</exception>
    public static explicit operator ulong(mpz_t value)
    {
        if (mpz.cmp_ui(value, 0) < 0 || mpz.cmp_ui(value, ulong.MaxValue) > 0)
            throw new OverflowException("The value is outside the range of the target type.");

        byte[] Bytes = new byte[8];
        mpz.export(Bytes, out _, -1, sizeof(byte), -1, 0, value);

        ulong UInt64Result = BitConverter.ToUInt64(Bytes, 0);

        return UInt64Result;
    }

    /// <summary>
    /// Converts to a <see cref="float"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static explicit operator float(mpz_t value)
    {
        return (float)(double)value;
    }

    /// <summary>
    /// Converts to a <see cref="double"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static explicit operator double(mpz_t value)
    {
        return mpz.get_d(value);
    }

    /// <summary>
    /// Converts to a <see cref="BigInteger"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static explicit operator BigInteger(mpz_t value)
    {
        byte[] Bytes = value.ToByteArray();

        // ToByteArray returns the magnitude, least significant byte first. BigInteger reads two's complement,
        // so an extra zero byte keeps the magnitude positive, and the sign is applied afterwards.
        byte[] UnsignedBytes = new byte[Bytes.Length + 1];
        Array.Copy(Bytes, UnsignedBytes, Bytes.Length);

        BigInteger Magnitude = new(UnsignedBytes);
        return mpz.sgn(value) < 0 ? -Magnitude : Magnitude;
    }
}
