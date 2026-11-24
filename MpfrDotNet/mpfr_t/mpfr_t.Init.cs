namespace MpfrDotNet;

using System;
using System.Runtime.InteropServices;
using Interop.Mpfr;
using MpirDotNet;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public partial class mpfr_t : IDisposable
{
    /// <summary>
    /// The default rounding mode.
    /// </summary>
    public const mpfr_rnd_t DefaultRounding = mpfr_rnd_t.MPFR_RNDN;

    private const int MaxArrayLength = 32;

    /// <summary>
    /// Initializes a new instance of the <see cref="mpfr_t"/> class.
    /// </summary>
    public mpfr_t()
    {
        mpfr.init2(this, DefaultPrecision);
        InitCacheManagement();
    }

    /// <summary>
    /// Creates a new instance of the <see cref="mpfr_t"/> class.
    /// </summary>
    /// <param name="precision">The precision, or <see cref="ulong.MaxValue"/> for <see cref="DefaultPrecision"/>.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="precision"/> is not a precision supported by MPFR.</exception>
    public static mpfr_t Create(ulong precision = ulong.MaxValue)
        => CreateWithPrecision(precision, nameof(precision));

    /// <summary>
    /// Creates an array of new instances of the <see cref="mpfr_t"/> class.
    /// </summary>
    /// <param name="length">The array length.</param>
    /// <param name="precision">The precision, or <see cref="ulong.MaxValue"/> for <see cref="DefaultPrecision"/>.</param>
    /// <exception cref="ArgumentException"><paramref name="length"/> is 32 or more.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="precision"/> is not a precision supported by MPFR.</exception>
    public static mpfr_t[] CreateArray(int length, ulong precision = ulong.MaxValue)
    {
        if (length >= MaxArrayLength)
            throw new ArgumentException($"The length must be lesser than {MaxArrayLength}.", nameof(length));

        mpfr_t[] Result = new mpfr_t[length];
        for (int i = 0; i < Result.Length; i++)
            Result[i] = CreateWithPrecision(precision, nameof(precision));

        return Result;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="mpfr_t"/> class with the specified precision.
    /// </summary>
    /// <param name="precision">The precision, or <see cref="ulong.MaxValue"/> for <see cref="DefaultPrecision"/>.</param>
    /// <param name="paramName">The name of the parameter that holds the precision.</param>
    /// <returns>The new instance.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="precision"/> is not a precision supported by MPFR.</exception>
    internal static mpfr_t CreateWithPrecision(ulong precision, string paramName)
    {
        ulong EffectivePrecision = precision == ulong.MaxValue ? DefaultPrecision : precision;

        // The precision is checked before the instance is created, so that an invalid precision leaves nothing to release.
        _ = mpfr.ToNativePrecision(EffectivePrecision, paramName);

        mpfr_t Result = new();
        mpfr.set_prec(Result, EffectivePrecision);

        return Result;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="mpfr_t"/> class representing NaN.
    /// </summary>
    /// <param name="sign">The sign.</param>
    public static mpfr_t NaN(int sign = +1)
    {
        mpfr_t Result = new();
        mpfr.set_nan(Result);

        if (sign < 0)
            mpfr.neg(Result, Result, mpfr_rnd_t.MPFR_RNDF);

        return Result;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="mpfr_t"/> class representing infinite.
    /// </summary>
    /// <param name="sign">The sign.</param>
    public static mpfr_t Infinite(int sign = +1)
    {
        mpfr_t Result = new();
        mpfr.set_inf(Result, sign);

        return Result;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="mpfr_t"/> class representing zero.
    /// </summary>
    /// <param name="sign">The sign.</param>
    public static mpfr_t Zero(int sign = +1)
    {
        mpfr_t Result = new();
        mpfr.set_zero(Result, sign);

        return Result;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpfr_t"/> class.
    /// </summary>
    /// <param name="other">The other instance.</param>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t(mpfr_t other, mpfr_rnd_t rounding = DefaultRounding)
        : this()
    {
        // The copy has the precision of the original, so that it is exact.
        mpfr.set_prec(this, mpfr.get_prec(other));
        LastTernaryResult = mpfr.set(this, other, rounding);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpfr_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t(ulong op, mpfr_rnd_t rounding = DefaultRounding)
        : this()
    {
        mpfr.set_ui(this, op, rounding);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpfr_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t(long op, mpfr_rnd_t rounding = DefaultRounding)
        : this()
    {
        mpfr.set_si(this, op, rounding);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpfr_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t(uint op, mpfr_rnd_t rounding = DefaultRounding)
        : this()
    {
        mpfr.set_uj(this, op, rounding);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpfr_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t(int op, mpfr_rnd_t rounding = DefaultRounding)
        : this()
    {
        mpfr.set_sj(this, op, rounding);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpfr_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t(float op, mpfr_rnd_t rounding = DefaultRounding)
        : this()
    {
        mpfr.set_flt(this, op, rounding);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpfr_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t(double op, mpfr_rnd_t rounding = DefaultRounding)
        : this()
    {
        mpfr.set_d(this, op, rounding);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpfr_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t(mpz_t op, mpfr_rnd_t rounding = DefaultRounding)
        : this()
    {
        mpfr.set_z(this, op, rounding);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpfr_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t(mpq_t op, mpfr_rnd_t rounding = DefaultRounding)
        : this()
    {
        mpfr.set_q(this, op, rounding);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpfr_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t(mpf_t op, mpfr_rnd_t rounding = DefaultRounding)
        : this()
    {
        mpfr.set_f(this, op, rounding);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpfr_t"/> class.
    /// </summary>
    /// <param name="str">The string text.</param>
    /// <param name="strbase">The digit base.</param>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t(string str, uint strbase = 10, mpfr_rnd_t rounding = DefaultRounding)
        : this()
    {
        bool Success = mpfr.set_str(this, str, strbase, rounding);
        if (!Success)
        {
            Dispose();
            throw new ArgumentException($"The combination of '{nameof(str)}' and '{nameof(strbase)}' is invalid.");
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpfr_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="e">The shift.</param>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t(ulong op, long e, mpfr_rnd_t rounding = DefaultRounding)
        : this()
    {
        mpfr.set_ui_2exp(this, op, e, rounding);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpfr_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="e">The shift.</param>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t(long op, long e, mpfr_rnd_t rounding = DefaultRounding)
        : this()
    {
        mpfr.set_si_2exp(this, op, e, rounding);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpfr_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="e">The shift.</param>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t(uint op, long e, mpfr_rnd_t rounding = DefaultRounding)
        : this()
    {
        mpfr.set_uj_2exp(this, op, e, rounding);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpfr_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="e">The shift.</param>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t(int op, long e, mpfr_rnd_t rounding = DefaultRounding)
        : this()
    {
        mpfr.set_sj_2exp(this, op, e, rounding);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="mpfr_t"/> class.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="e">The exponent.</param>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t(mpz_t op, long e, mpfr_rnd_t rounding = DefaultRounding)
        : this()
    {
        mpfr.set_z_2exp(this, op, e, rounding);
    }

    /// <summary>
    /// Clear an array of numbers.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <exception cref="ArgumentNullException"><paramref name="array"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="array"/> has 32 elements or more.</exception>
    public static void ClearArray(mpfr_t[] array)
    {
        if (array is null)
            throw new ArgumentNullException(nameof(array));

        if (array.Length >= MaxArrayLength)
            throw new ArgumentException(nameof(array.Length));

        // Dispose does nothing for an element that is already disposed or listed twice.
        foreach (mpfr_t Item in array)
            Item.Dispose();
    }

    /// <summary>
    /// Gets or sets the rounding mode.
    /// </summary>
    public mpfr_rnd_t Rounding { get; set; } = DefaultRounding;

#pragma warning disable SA1401 // Fields should be private
#pragma warning disable SA1600 // Elements should be documented
    internal __mpfr_t Value;
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore SA1600 // Elements should be documented
}
