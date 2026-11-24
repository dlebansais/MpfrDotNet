namespace MpirDotNet;

using System;
using System.Text;
using static Interop.Mpir.NativeMethods;

/// <summary>
/// Arbitrary precision rational number.
/// </summary>
public partial class mpq_t : IDisposable, IEquatable<mpq_t>, ICloneable, IConvertible, IComparable, IComparable<mpq_t>
{
    private const int MaxArrayLength = 32;
    private const string ObsoleteCanonicalizeMessage = "Rational numbers are always canonicalized: remove the canonicalize argument.";

    /// <summary>
    /// Initializes a new instance of the <see cref="mpq_t"/> class.
    /// </summary>
    public mpq_t()
    {
        mpq.init(this);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpq_t"/> class.
    /// </summary>
    /// <param name="other">The other instance.</param>
    public mpq_t(mpq_t other)
    {
        mpq.init(this);
        mpq.set(this, other);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpq_t"/> class.
    /// </summary>
    /// <param name="source">The source instance.</param>
    public mpq_t(mpf_t source)
    {
        mpq.init(this);
        mpq.set_f(this, source);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpq_t"/> class.
    /// </summary>
    /// <param name="source">The source instance.</param>
    public mpq_t(mpz_t source)
    {
        mpq.init(this);
        mpq.set_z(this, source);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpq_t"/> class, in canonical form.
    /// </summary>
    /// <param name="numerator">The numerator.</param>
    /// <param name="denominator">The denominator.</param>
    /// <exception cref="DivideByZeroException"><paramref name="denominator"/> is zero.</exception>
    public mpq_t(ulong numerator, ulong denominator)
    {
        if (denominator == 0)
            throw new DivideByZeroException("The denominator cannot be zero.");

        mpq.init(this);
        mpq.set_ui(this, numerator, denominator);
        mpq.canonicalize(this);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpq_t"/> class, in canonical form.
    /// </summary>
    /// <param name="numerator">The numerator.</param>
    /// <param name="denominator">The denominator.</param>
    /// <param name="canonicalize">Ignored: the number is always canonicalized.</param>
    /// <exception cref="DivideByZeroException"><paramref name="denominator"/> is zero.</exception>
    [Obsolete(ObsoleteCanonicalizeMessage)]
    public mpq_t(ulong numerator, ulong denominator, bool canonicalize)
        : this(numerator, denominator)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpq_t"/> class, in canonical form.
    /// </summary>
    /// <param name="numerator">The numerator.</param>
    /// <param name="denominator">The denominator.</param>
    /// <exception cref="DivideByZeroException"><paramref name="denominator"/> is zero.</exception>
    public mpq_t(long numerator, ulong denominator)
    {
        if (denominator == 0)
            throw new DivideByZeroException("The denominator cannot be zero.");

        mpq.init(this);
        mpq.set_si(this, numerator, denominator);
        mpq.canonicalize(this);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpq_t"/> class, in canonical form.
    /// </summary>
    /// <param name="numerator">The numerator.</param>
    /// <param name="denominator">The denominator.</param>
    /// <param name="canonicalize">Ignored: the number is always canonicalized.</param>
    /// <exception cref="DivideByZeroException"><paramref name="denominator"/> is zero.</exception>
    [Obsolete(ObsoleteCanonicalizeMessage)]
    public mpq_t(long numerator, ulong denominator, bool canonicalize)
        : this(numerator, denominator)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpq_t"/> class.
    /// </summary>
    /// <param name="op">The value.</param>
    /// <exception cref="OverflowException"><paramref name="op"/> is NaN or an infinity.</exception>
    public mpq_t(double op)
    {
        DoubleArgument.CheckFinite(op);

        mpq.init(this);
        mpq.set_d(this, op);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpq_t"/> class, in canonical form.
    /// </summary>
    /// <param name="numerator">The numerator.</param>
    /// <param name="denominator">The denominator.</param>
    /// <exception cref="DivideByZeroException"><paramref name="denominator"/> is zero.</exception>
    public mpq_t(mpz_t numerator, mpz_t denominator)
    {
        if (mpz.sgn(denominator) == 0)
            throw new DivideByZeroException("The denominator cannot be zero.");

        mpq.init(this);
        mpq.set_num(this, numerator);
        mpq.set_den(this, denominator);
        mpq.canonicalize(this);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpq_t"/> class, in canonical form.
    /// </summary>
    /// <param name="numerator">The numerator.</param>
    /// <param name="denominator">The denominator.</param>
    /// <param name="canonicalize">Ignored: the number is always canonicalized.</param>
    /// <exception cref="DivideByZeroException"><paramref name="denominator"/> is zero.</exception>
    [Obsolete(ObsoleteCanonicalizeMessage)]
    public mpq_t(mpz_t numerator, mpz_t denominator, bool canonicalize)
        : this(numerator, denominator)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpq_t"/> class, in canonical form.
    /// </summary>
    /// <param name="text">The value text.</param>
    /// <exception cref="ArgumentException"><paramref name="text"/> is not a valid number.</exception>
    /// <exception cref="DivideByZeroException">The denominator in <paramref name="text"/> is zero.</exception>
    public mpq_t(string text)
        : this(text, mpz_t.DefaultBase)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpq_t"/> class, in canonical form.
    /// </summary>
    /// <param name="text">The value text.</param>
    /// <param name="canonicalize">Ignored: the number is always canonicalized.</param>
    /// <exception cref="ArgumentException"><paramref name="text"/> is not a valid number.</exception>
    /// <exception cref="DivideByZeroException">The denominator in <paramref name="text"/> is zero.</exception>
    [Obsolete(ObsoleteCanonicalizeMessage)]
    public mpq_t(string text, bool canonicalize)
        : this(text, mpz_t.DefaultBase)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpq_t"/> class, in canonical form.
    /// </summary>
    /// <param name="text">The value text.</param>
    /// <param name="strBase">The digit base.</param>
    /// <exception cref="ArgumentException">The combination of <paramref name="text"/> and <paramref name="strBase"/> is invalid.</exception>
    /// <exception cref="DivideByZeroException">The denominator in <paramref name="text"/> is zero.</exception>
    public mpq_t(string text, int strBase)
    {
        mpq.init(this);

        bool Success = mpq.set_str(this, text, strBase);
        if (!Success)
        {
            Dispose();
            throw new ArgumentException($"The combination of '{nameof(text)}' and '{nameof(strBase)}' is invalid.");
        }

        mpq.canonicalize(this);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpq_t"/> class, in canonical form.
    /// </summary>
    /// <param name="text">The value text.</param>
    /// <param name="strBase">The digit base.</param>
    /// <param name="canonicalize">Ignored: the number is always canonicalized.</param>
    /// <exception cref="ArgumentException">The combination of <paramref name="text"/> and <paramref name="strBase"/> is invalid.</exception>
    /// <exception cref="DivideByZeroException">The denominator in <paramref name="text"/> is zero.</exception>
    [Obsolete(ObsoleteCanonicalizeMessage)]
    public mpq_t(string text, int strBase, bool canonicalize)
        : this(text, strBase)
    {
    }

    /// <summary>
    /// Creates an array of new instances of the <see cref="mpq_t"/> class.
    /// </summary>
    /// <param name="length">The array length.</param>
    /// <exception cref="ArgumentException"><paramref name="length"/> is 32 or more.</exception>
    public static mpq_t[] CreateArray(int length)
    {
        if (length >= MaxArrayLength)
            throw new ArgumentException($"The length must be lesser than {MaxArrayLength}.", nameof(length));

        mpq_t[] Result = new mpq_t[length];
        for (int i = 0; i < Result.Length; i++)
            Result[i] = new mpq_t();

        return Result;
    }

    /// <summary>
    /// Clear an array of numbers.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <exception cref="ArgumentNullException"><paramref name="array"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="array"/> has 32 elements or more.</exception>
    public static void ClearArray(mpq_t[] array)
    {
        if (array is null)
            throw new ArgumentNullException(nameof(array));

        if (array.Length >= MaxArrayLength)
            throw new ArgumentException(nameof(array.Length));

        // Dispose does nothing for an element that is already disposed or listed twice.
        foreach (mpq_t Item in array)
            Item.Dispose();
    }

#pragma warning disable SA1401 // Fields should be private
#pragma warning disable SA1600 // Elements should be documented
    internal __mpq_t Value;
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore SA1600 // Elements should be documented
}
