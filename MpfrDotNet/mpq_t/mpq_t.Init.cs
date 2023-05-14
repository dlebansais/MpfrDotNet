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
    /// Initializes a new instance of the <see cref="mpq_t"/> class.
    /// </summary>
    public mpq_t()
    {
        mpq_init(ref Value);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpq_t"/> class.
    /// </summary>
    /// <param name="other">The other instance.</param>
    public mpq_t(mpq_t other)
    {
        mpq_init(ref Value);
        mpq_set(ref Value, ref other.Value);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpq_t"/> class.
    /// </summary>
    /// <param name="source">The source instance.</param>
    public mpq_t(mpf_t source)
    {
        mpq_init(ref Value);
        mpq_set_f(ref Value, ref source.Value);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpq_t"/> class.
    /// </summary>
    /// <param name="source">The source instance.</param>
    public mpq_t(mpz_t source)
    {
        mpq_init(ref Value);
        mpq_set_z(ref Value, ref source.Value);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpq_t"/> class.
    /// </summary>
    /// <param name="numerator">The numerator.</param>
    /// <param name="denominator">The denominator.</param>
    /// <param name="canonicalize">True if the new instance should use canonical numerator and denominator.</param>
    public mpq_t(ulong numerator, ulong denominator, bool canonicalize = false)
    {
        mpq_init(ref Value);
        mpq_set_ui(ref Value, (mpir_ui)numerator, (mpir_ui)denominator);

        if (canonicalize)
            mpq_canonicalize(ref Value);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpq_t"/> class.
    /// </summary>
    /// <param name="numerator">The numerator.</param>
    /// <param name="denominator">The denominator.</param>
    /// <param name="canonicalize">True if the new instance should use canonical numerator and denominator.</param>
    public mpq_t(long numerator, ulong denominator, bool canonicalize = false)
    {
        mpq_init(ref Value);
        mpq_set_si(ref Value, (mpir_si)numerator, (mpir_ui)denominator);

        if (canonicalize)
            mpq_canonicalize(ref Value);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpq_t"/> class.
    /// </summary>
    /// <param name="op">The value.</param>
    public mpq_t(double op)
    {
        mpq_init(ref Value);
        mpq_set_d(ref Value, op);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpq_t"/> class.
    /// </summary>
    /// <param name="numerator">The numerator.</param>
    /// <param name="denominator">The denominator.</param>
    /// <param name="canonicalize">True if the new instance should use canonical numerator and denominator.</param>
    public mpq_t(mpz_t numerator, mpz_t denominator, bool canonicalize = false)
    {
        mpq_init(ref Value);
        mpq_set_num(ref Value, ref numerator.Value);
        mpq_set_den(ref Value, ref denominator.Value);

        if (canonicalize)
            mpq_canonicalize(ref Value);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpq_t"/> class.
    /// </summary>
    /// <param name="text">The value text.</param>
    /// <param name="canonicalize">True if the new instance should use canonical numerator and denominator.</param>
    public mpq_t(string text, bool canonicalize = false)
        : this(text, mpz_t.DefaultBase, canonicalize)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpq_t"/> class.
    /// </summary>
    /// <param name="text">The value text.</param>
    /// <param name="strBase">The digit base.</param>
    /// <param name="canonicalize">True if the new instance should use canonical numerator and denominator.</param>
    public mpq_t(string text, int strBase, bool canonicalize = false)
    {
        mpq_init(ref Value);

        int Success = mpq_set_str(ref Value, text, strBase);
        if (Success != 0)
            throw new ArgumentException();

        if (canonicalize)
            mpq_canonicalize(ref Value);
    }

    /// <summary>
    /// Creates an array of new instances of the <see cref="mpq_t"/> class.
    /// </summary>
    /// <param name="length">The array length.</param>
    public static mpq_t[] CreateArray(int length)
    {
        if (length >= MaxArrayLength)
            throw new ArgumentException(nameof(length));

        mpq_t[] Result = new mpq_t[length];
        for (int i = 0; i < Result.Length; i++)
            Result[i] = new mpq_t();

        ProcessArray(Result, (IntPtr[] args) =>
        {
            int Index = 0;
            mpq_inits(args[Index++],
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

    /// <summary>
    /// Clear an array of numbers.
    /// </summary>
    /// <param name="array">The array.</param>
    public static void ClearArray(mpq_t[] array)
    {
        if (array.Length >= MaxArrayLength)
            throw new ArgumentException(nameof(array.Length));

        ProcessArray(array, (IntPtr[] args) =>
        {
            int Index = 0;
            mpq_clears(args[Index++],
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

        foreach (mpq_t Item in array)
            Item.IsDisposed = true;
    }

#pragma warning disable SA1401 // Fields should be private
#pragma warning disable SA1600 // Elements should be documented
    internal __mpq_t Value;
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore SA1600 // Elements should be documented
}
