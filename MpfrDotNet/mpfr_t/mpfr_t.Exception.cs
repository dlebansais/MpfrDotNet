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
        get { return mpfr.get_emin(); }
        set { mpfr.set_emin(value); }
    }

    /// <summary>
    /// Gets the minimum value for <see cref="MinExponent"/>.
    /// </summary>
    public static int MinMinExponent
    {
        get { return mpfr.get_emin_min(); }
    }

    /// <summary>
    /// Gets the maximum value for <see cref="MinExponent"/>.
    /// </summary>
    public static int MaxMinExponent
    {
        get { return mpfr.get_emin_max(); }
    }

    /// <summary>
    /// Gets or sets the maximum value for the exponent.
    /// </summary>
    public static int MaxExponent
    {
        get { return mpfr.get_emax(); }
        set { mpfr.set_emax(value); }
    }

    /// <summary>
    /// Gets the minimum value for <see cref="MaxExponent"/>.
    /// </summary>
    public static int MinMaxExponent
    {
        get { return mpfr.get_emax_min(); }
    }

    /// <summary>
    /// Gets the maximum value for <see cref="MaxExponent"/>.
    /// </summary>
    public static int MaxMaxExponent
    {
        get { return mpfr.get_emax_max(); }
    }

    /// <summary>
    /// Checks the relative range of the exactly result of the previous operation.
    /// </summary>
    public int CheckRange()
    {
        return mpfr.check_range(this, LastTernaryResult, Rounding);
    }

    /// <summary>
    /// Rounds with subnormal number arithmetic.
    /// </summary>
    public int Subnormalize()
    {
        return mpfr.subnormalize(this, LastTernaryResult, Rounding);
    }

#pragma warning disable SA1623 // Property summary documentation should match accessors

    /// <summary>
    /// Gets or sets the underflow flag.
    /// </summary>
    public static bool Underflow
    {
        get { return mpfr.underflow_p(); }
        set
        {
            if (value)
                mpfr.set_underflow();
            else
                mpfr.clear_underflow();
        }
    }

    /// <summary>
    /// Gets or sets the overflow flag.
    /// </summary>
    public static bool Overflow
    {
        get { return mpfr.overflow_p(); }
        set
        {
            if (value)
                mpfr.set_overflow();
            else
                mpfr.clear_overflow();
        }
    }

    /// <summary>
    /// Gets or sets the divide-by-zero flag.
    /// </summary>
    public static bool DivideByZero
    {
        get { return mpfr.divby0_p(); }
        set
        {
            if (value)
                mpfr.set_divby0();
            else
                mpfr.clear_divby0();
        }
    }

    /// <summary>
    /// Gets or sets the nan flag.
    /// </summary>
    public static bool NaNFlag
    {
        get { return mpfr.nanflag_p(); }
        set
        {
            if (value)
                mpfr.set_nanflag();
            else
                mpfr.clear_nanflag();
        }
    }

    /// <summary>
    /// Gets or sets the inexact flag.
    /// </summary>
    public static bool Inexact
    {
        get { return mpfr.inexflag_p(); }
        set
        {
            if (value)
                mpfr.set_inexflag();
            else
                mpfr.clear_inexflag();
        }
    }

    /// <summary>
    /// Gets or sets the erange flag.
    /// </summary>
    public static bool ERange
    {
        get { return mpfr.erangeflag_p(); }
        set
        {
            if (value)
                mpfr.set_erangeflag();
            else
                mpfr.clear_erangeflag();
        }
    }

#pragma warning restore SA1623 // Property summary documentation should match accessors

    /// <summary>
    /// Clears all global flags.
    /// </summary>
    public static void ClearAllFlags()
    {
        mpfr.clear_flags();
    }

    /// <summary>
    /// Clears some global flags.
    /// </summary>
    /// <param name="mask">The flag mask.</param>
    public static void ClearFlags(uint mask)
    {
        mpfr.flags_clear(mask);
    }

    /// <summary>
    /// Sets some global flags.
    /// </summary>
    /// <param name="mask">The flag mask.</param>
    public static void SetFlags(uint mask)
    {
        mpfr.flags_set(mask);
    }

    /// <summary>
    /// Sets some global flags if present in a mask.
    /// </summary>
    /// <param name="mask">The flag mask.</param>
    /// <param name="value">The flags value.</param>
    public static void SetFlags(uint mask, uint value)
    {
        mpfr.flags_restore(mask, value);
    }

    /// <summary>
    /// Sets some global flags.
    /// </summary>
    /// <param name="mask">The flag mask.</param>
    public static uint TestFlags(uint mask)
    {
        return mpfr.flags_test(mask);
    }

    /// <summary>
    /// Gets all global flags.
    /// </summary>
    public static uint GetAllFlags()
    {
        return mpfr.flags_save();
    }

    private int LastTernaryResult;
}
