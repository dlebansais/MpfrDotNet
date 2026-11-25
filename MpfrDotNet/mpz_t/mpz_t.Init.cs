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
    private const int MaxArrayLength = 32;

    /// <summary>
    /// Initializes a new instance of the <see cref="mpz_t"/> class.
    /// </summary>
    public mpz_t()
    {
        mpz.init(this);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpz_t"/> class.
    /// </summary>
    /// <param name="other">The other number.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="other"/> is disposed.</exception>
    public mpz_t(mpz_t other)
    {
        ThrowIfDisposed(other);

        mpz.init_set(this, other);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpz_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    public mpz_t(uint op)
    {
        mpz.init_set_ui(this, op);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpz_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    public mpz_t(int op)
    {
        mpz.init_set_si(this, op);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpz_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    public mpz_t(ulong op)
    {
        mpz.init_set_ux(this, op);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpz_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    public mpz_t(long op)
    {
        mpz.init_set_sx(this, op);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpz_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <exception cref="OverflowException">The value is NaN or an infinity.</exception>
    public mpz_t(double op)
    {
        mpz.init_set_d(this, op);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpz_t"/> class.
    /// </summary>
    /// <param name="text">The number text.</param>
    /// <exception cref="ArgumentNullException"><paramref name="text"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="text"/> is not a valid number.</exception>
    public mpz_t(string text)
        : this(text, DefaultBase)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpz_t"/> class.
    /// </summary>
    /// <param name="text">The number text.</param>
    /// <param name="strBase">The digit base.</param>
    /// <exception cref="ArgumentNullException"><paramref name="text"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">The combination of <paramref name="text"/> and <paramref name="strBase"/> is invalid.</exception>
    public mpz_t(string text, uint strBase)
    {
        // The native code would dereference a null string.
        if (text is null)
            throw new ArgumentNullException(nameof(text));

        bool Success = MpirArgument.IsParsableText(text) && mpz.init_set_str(this, text, strBase);
        if (!Success)
        {
            // MPIR initializes the number even when the text is invalid.
            Dispose();
            throw new ArgumentException($"The combination of '{nameof(text)}' and '{nameof(strBase)}' is invalid.");
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpz_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    public mpz_t(BigInteger op)
        : this(BigInteger.Abs(op).ToByteArray())
    {
        // The bytes are imported as a magnitude, so the sign is applied afterwards.
        if (op.Sign < 0)
            mpz.neg(this, this);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpz_t"/> class.
    /// </summary>
    /// <param name="size">The count of bits.</param>
    public mpz_t(bitcount_t size)
    {
        mpz.init2(this, size.Count);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpz_t"/> class.
    /// </summary>
    /// <param name="bytes">The number raw bytes.</param>
    /// <exception cref="ArgumentNullException"><paramref name="bytes"/> is <see langword="null"/>.</exception>
    public mpz_t(byte[] bytes)
    {
        if (bytes is null)
            throw new ArgumentNullException(nameof(bytes));

        mpz.init(this);
        mpz.import(this, (ulong)bytes.LongLength, -1, sizeof(byte), -1, 0UL, bytes);
    }

    /// <summary>
    /// Creates an array of new instances of the <see cref="mpz_t"/> class.
    /// </summary>
    /// <param name="length">The array length.</param>
    /// <exception cref="ArgumentException"><paramref name="length"/> is negative, or 32 or more.</exception>
    public static mpz_t[] CreateArray(int length)
    {
        // A negative length would throw OverflowException when the array is created.
        if (length < 0)
            throw new ArgumentException("The length must not be negative.", nameof(length));

        if (length >= MaxArrayLength)
            throw new ArgumentException($"The length must be lesser than {MaxArrayLength}.", nameof(length));

        mpz_t[] Result = new mpz_t[length];
        for (int i = 0; i < Result.Length; i++)
            Result[i] = new mpz_t();

        return Result;
    }

#pragma warning disable SA1401 // Fields should be private
#pragma warning disable SA1600 // Elements should be documented
    internal __mpz_t Value;
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore SA1600 // Elements should be documented
}
