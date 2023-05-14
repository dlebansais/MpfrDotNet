﻿namespace MpirDotNet;

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

        size_t countp;
        mpz_export(Result, out countp, -1, (size_t)sizeof(byte), -1, (size_t)0UL, ref Value);

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
    public string ToString(int resultbase)
    {
        ulong SizeInDigits = (ulong)mpz_sizeinbase(ref Value, (uint)resultbase);

        StringBuilder Data = new StringBuilder((int)(SizeInDigits + 2));
        mpz_get_str(Data, resultbase, ref Value);

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
    public static explicit operator byte(mpz_t value)
    {
        return (byte)(uint)value;
    }

    /// <summary>
    /// Converts to a <see cref="int"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static explicit operator int(mpz_t value)
    {
        return (int)(long)mpz_get_si(ref value.Value);
    }

    /// <summary>
    /// Converts to a <see cref="uint"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static explicit operator uint(mpz_t value)
    {
        return (uint)(ulong)mpz_get_ui(ref value.Value);
    }

    /// <summary>
    /// Converts to a <see cref="short"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static explicit operator short(mpz_t value)
    {
        return (short)(int)value;
    }

    /// <summary>
    /// Converts to a <see cref="ushort"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static explicit operator ushort(mpz_t value)
    {
        return (ushort)(uint)value;
    }

    /// <summary>
    /// Converts to a <see cref="long"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static explicit operator long(mpz_t value)
    {
        byte[] Bytes = new byte[8];

        mpz_import(ref value.Value, (size_t)(ulong)Bytes.LongLength, -1, (size_t)sizeof(byte), -1, (size_t)0UL, Bytes);
        long Int64Result = BitConverter.ToInt64(Bytes, 0);

        return Int64Result;
    }

    /// <summary>
    /// Converts to a <see cref="ulong"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static explicit operator ulong(mpz_t value)
    {
        byte[] Bytes = new byte[8];

        mpz_import(ref value.Value, (size_t)(ulong)Bytes.LongLength, -1, (size_t)sizeof(byte), -1, (size_t)0UL, Bytes);
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
        return mpz_get_d(ref value.Value);
    }

    /// <summary>
    /// Converts to a <see cref="BigInteger"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static explicit operator BigInteger(mpz_t value)
    {
        byte[] Bytes = value.ToByteArray();

        BigInteger Result = new BigInteger(Bytes);
        return Result;
    }
}
