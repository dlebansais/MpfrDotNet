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
    /// Initializes a new instance of the <see cref="mpz_t"/> class.
    /// </summary>
    public mpz_t()
    {
        mpz_init(ref Value);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpz_t"/> class.
    /// </summary>
    /// <param name="other">The other number.</param>
    public mpz_t(mpz_t other)
    {
        mpz_init_set(ref Value, ref other.Value);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpz_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    public mpz_t(uint op)
    {
        mpz_init_set_ui(ref Value, (mpir_ui)op);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpz_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    public mpz_t(int op)
    {
        mpz_init_set_si(ref Value, (mpir_si)op);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpz_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    public mpz_t(ulong op)
    {
        mpz_init_set_ux(ref Value, (uintmax_t)op);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpz_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    public mpz_t(long op)
    {
        mpz_init_set_sx(ref Value, (intmax_t)op);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpz_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    public mpz_t(double op)
    {
        mpz_init_set_d(ref Value, op);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpz_t"/> class.
    /// </summary>
    /// <param name="text">The number text.</param>
    public mpz_t(string text)
        : this(text, DefaultBase)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpz_t"/> class.
    /// </summary>
    /// <param name="text">The number text.</param>
    /// <param name="strBase">The digit base.</param>
    public mpz_t(string text, uint strBase)
    {
        int Success = mpz_init_set_str(ref Value, text, strBase);
        if (Success != 0)
            throw new ArgumentException();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpz_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    public mpz_t(BigInteger op)
        : this(op.ToByteArray())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpz_t"/> class.
    /// </summary>
    /// <param name="size">The count of bits.</param>
    public mpz_t(bitcount_t size)
    {
        mpz_init2(ref Value, (mp_bitcnt_t)size.Count);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpz_t"/> class.
    /// </summary>
    /// <param name="bytes">The number raw bytes.</param>
    public mpz_t(byte[] bytes)
        : this()
    {
        mpz_import(ref Value, (size_t)(ulong)bytes.LongLength, -1, (size_t)sizeof(byte), -1, (size_t)0UL, bytes);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpz_t"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    internal mpz_t(__mpz_t value)
    {
        mpz_init_set(ref Value, ref value);
    }

    /// <summary>
    /// Creates an array of new instances of the <see cref="mpz_t"/> class.
    /// </summary>
    /// <param name="length">The array length.</param>
    public static mpz_t[] CreateArray(int length)
    {
        if (length >= MaxArrayLength)
            throw new ArgumentException(nameof(length));

        mpz_t[] Result = new mpz_t[length];
        for (int i = 0; i < Result.Length; i++)
            Result[i] = new mpz_t();

        ProcessArray(Result, (IntPtr[] args) =>
        {
            int Index = 0;
            mpz_inits(args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++],
                      args[Index++]);
        });

        return Result;
    }

#pragma warning disable SA1401 // Fields should be private
#pragma warning disable SA1600 // Elements should be documented
    internal __mpz_t Value;
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore SA1600 // Elements should be documented
}
