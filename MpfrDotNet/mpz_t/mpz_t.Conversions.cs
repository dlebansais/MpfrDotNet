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
    /// <remarks>The value is rounded to the nearest <see cref="float"/>, ties to even, like the conversion from <see cref="long"/>.</remarks>
    public static explicit operator float(mpz_t value)
    {
        // The rounded value has 24 significant bits, so the conversion to float is exact, or overflows to infinity.
        return (float)RoundToNearest(value, FloatSignificandBits);
    }

    /// <summary>
    /// Converts to a <see cref="double"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <remarks>The value is rounded to the nearest <see cref="double"/>, ties to even, like the conversion from <see cref="long"/>. <see cref="mpz.get_d(mpz_t)"/> truncates instead.</remarks>
    public static explicit operator double(mpz_t value)
    {
        return RoundToNearest(value, DoubleSignificandBits);
    }

    private const int FloatSignificandBits = 24;
    private const int DoubleSignificandBits = 53;

    private static double RoundToNearest(mpz_t value, int significandBits)
    {
        ulong BitCount = mpz.sizeinbase(value, 2);

        // mpz_get_d truncates, which is exact when the value fits.
        if (BitCount <= (ulong)significandBits)
            return mpz.get_d(value);

        ulong Shift = BitCount - (ulong)significandBits;
        using mpz_t Magnitude = new();
        mpz.abs(Magnitude, value);

        using mpz_t Significand = new();
        mpz.tdiv_q_2exp(Significand, Magnitude, Shift);

        // Round to nearest, ties to even, from the first discarded bit and the bits below it.
        bool IsHalfOrMore = mpz.tstbit(Magnitude, Shift - 1);
        bool IsMoreThanHalf = IsHalfOrMore && mpz.scan1(Magnitude, 0) < Shift - 1;

        if (IsHalfOrMore && (IsMoreThanHalf || mpz.tstbit(Significand, 0)))
            mpz.add_ui(Significand, Significand, 1);

        // The significand has at most significandBits + 1 bits, so it converts exactly. The power of two is exact up to
        // 2^1023, and beyond that the result overflows to infinity, as it should.
        double Result = mpz.get_d(Significand) * Math.Pow(2, Shift);

        return mpz.sgn(value) < 0 ? -Result : Result;
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
