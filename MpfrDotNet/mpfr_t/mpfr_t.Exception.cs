namespace MpfrDotNet;

using System;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public partial class mpfr_t : IDisposable
{
    /// <summary>
    /// Gets or sets the minimum value for the exponent.
    /// </summary>
    public static int MinExponent
    {
        get { return mpfr_get_emin(); }
        set { mpfr_set_emin(value); }
    }

    /// <summary>
    /// Gets the minimum value for <see cref="MinExponent"/>.
    /// </summary>
    public static int MinMinExponent
    {
        get { return mpfr_get_emin_min(); }
    }

    /// <summary>
    /// Gets the maximum value for <see cref="MinExponent"/>.
    /// </summary>
    public static int MaxMinExponent
    {
        get { return mpfr_get_emin_max(); }
    }

    /// <summary>
    /// Gets or sets the maximum value for the exponent.
    /// </summary>
    public static int MaxExponent
    {
        get { return mpfr_get_emax(); }
        set { mpfr_set_emax(value); }
    }

    /// <summary>
    /// Gets the minimum value for <see cref="MaxExponent"/>.
    /// </summary>
    public static int MinMaxExponent
    {
        get { return mpfr_get_emax_min(); }
    }

    /// <summary>
    /// Gets the maximum value for <see cref="MaxExponent"/>.
    /// </summary>
    public static int MaxMaxExponent
    {
        get { return mpfr_get_emax_max(); }
    }

    /// <summary>
    /// Checks the relative range of the exactly result of the previous operation.
    /// </summary>
    public int CheckRange()
    {
        return mpfr_check_range(ref Value, LastTernaryResult, (__mpfr_rnd_t)Rounding);
    }

    /// <summary>
    /// Rounds with subnormal number arithmetic.
    /// </summary>
    public int Subnormalize()
    {
        return mpfr_subnormalize(ref Value, LastTernaryResult, (__mpfr_rnd_t)Rounding);
    }

#pragma warning disable SA1623 // Property summary documentation should match accessors

    /// <summary>
    /// Gets or sets the underflow flag.
    /// </summary>
    public static bool Underflow
    {
        get { return mpfr_underflow_p() != 0; }
        set
        {
            if (value)
                mpfr_set_underflow();
            else
                mpfr_clear_underflow();
        }
    }

    /// <summary>
    /// Gets or sets the overflow flag.
    /// </summary>
    public static bool Overflow
    {
        get { return mpfr_overflow_p() != 0; }
        set
        {
            if (value)
                mpfr_set_overflow();
            else
                mpfr_clear_overflow();
        }
    }

    /// <summary>
    /// Gets or sets the divide-by-zero flag.
    /// </summary>
    public static bool DivideByZero
    {
        get { return mpfr_divby0_p() != 0; }
        set
        {
            if (value)
                mpfr_set_divby0();
            else
                mpfr_clear_divby0();
        }
    }

    /// <summary>
    /// Gets or sets the nan flag.
    /// </summary>
    public static bool NaNFlag
    {
        get { return mpfr_nanflag_p() != 0; }
        set
        {
            if (value)
                mpfr_set_nanflag();
            else
                mpfr_clear_nanflag();
        }
    }

    /// <summary>
    /// Gets or sets the inexact flag.
    /// </summary>
    public static bool Inexact
    {
        get { return mpfr_inexflag_p() != 0; }
        set
        {
            if (value)
                mpfr_set_inexflag();
            else
                mpfr_clear_inexflag();
        }
    }

    /// <summary>
    /// Gets or sets the erange flag.
    /// </summary>
    public static bool ERange
    {
        get { return mpfr_erangeflag_p() != 0; }
        set
        {
            if (value)
                mpfr_set_erangeflag();
            else
                mpfr_clear_erangeflag();
        }
    }

#pragma warning restore SA1623 // Property summary documentation should match accessors

    /// <summary>
    /// Clears all global flags.
    /// </summary>
    public static void ClearAllFlags()
    {
        mpfr_clear_flags();
    }

    /// <summary>
    /// Clears some global flags.
    /// </summary>
    /// <param name="mask">The flag mask.</param>
    public static void ClearFlags(uint mask)
    {
        mpfr_flags_clear(mask);
    }

    /// <summary>
    /// Sets some global flags.
    /// </summary>
    /// <param name="mask">The flag mask.</param>
    public static void SetFlags(uint mask)
    {
        mpfr_flags_set(mask);
    }

    /// <summary>
    /// Sets some global flags if present in a mask.
    /// </summary>
    /// <param name="mask">The flag mask.</param>
    /// <param name="value">The flags value.</param>
    public static void SetFlags(uint mask, uint value)
    {
        mpfr_flags_restore(mask, value);
    }

    /// <summary>
    /// Sets some global flags.
    /// </summary>
    /// <param name="mask">The flag mask.</param>
    public static uint TestFlags(uint mask)
    {
        return mpfr_flags_test(mask);
    }

    /// <summary>
    /// Gets all global flags.
    /// </summary>
    public static uint GetAllFlags()
    {
        return mpfr_flags_save();
    }

    private int LastTernaryResult;
}
