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
    /// <remarks>MPFR keeps this setting per thread: a value set on one thread does not apply to the other threads, including the thread-pool threads that run the continuations of an await.</remarks>
    /// <exception cref="ArgumentOutOfRangeException">The value set is lesser than <see cref="MinMinExponent"/> or greater than <see cref="MaxMinExponent"/>.</exception>
    public static int MinExponent
    {
        get { return mpfr.get_emin(); }
        set
        {
            if (mpfr.set_emin(value) != 0)
                throw new ArgumentOutOfRangeException(nameof(value), value, $"The exponent must be between {MinMinExponent} and {MaxMinExponent}.");
        }
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
    /// <remarks>MPFR keeps this setting per thread: a value set on one thread does not apply to the other threads, including the thread-pool threads that run the continuations of an await.</remarks>
    /// <exception cref="ArgumentOutOfRangeException">The value set is lesser than <see cref="MinMaxExponent"/> or greater than <see cref="MaxMaxExponent"/>.</exception>
    public static int MaxExponent
    {
        get { return mpfr.get_emax(); }
        set
        {
            if (mpfr.set_emax(value) != 0)
                throw new ArgumentOutOfRangeException(nameof(value), value, $"The exponent must be between {MinMaxExponent} and {MaxMaxExponent}.");
        }
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
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public int CheckRange()
    {
        ThrowIfDisposed(this);

        return mpfr.check_range(this, LastTernaryResult, Rounding);
    }

    /// <summary>
    /// Rounds with subnormal number arithmetic.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public int Subnormalize()
    {
        ThrowIfDisposed(this);

        return mpfr.subnormalize(this, LastTernaryResult, Rounding);
    }

#pragma warning disable SA1623 // Property summary documentation should match accessors

    /// <summary>
    /// Gets or sets the underflow flag.
    /// </summary>
    /// <remarks>MPFR keeps the flags per thread: each thread sees only the flags raised by its own operations.</remarks>
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
    /// <remarks>MPFR keeps the flags per thread: each thread sees only the flags raised by its own operations.</remarks>
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
    /// <remarks>MPFR keeps the flags per thread: each thread sees only the flags raised by its own operations.</remarks>
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
    /// <remarks>MPFR keeps the flags per thread: each thread sees only the flags raised by its own operations.</remarks>
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
    /// <remarks>MPFR keeps the flags per thread: each thread sees only the flags raised by its own operations.</remarks>
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
    /// <remarks>MPFR keeps the flags per thread: each thread sees only the flags raised by its own operations.</remarks>
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
    /// Clears all the flags.
    /// </summary>
    /// <remarks>MPFR keeps the flags per thread: each thread sees only the flags raised by its own operations.</remarks>
    public static void ClearAllFlags()
    {
        mpfr.clear_flags();
    }

    /// <summary>
    /// Clears some flags.
    /// </summary>
    /// <remarks>MPFR keeps the flags per thread: each thread sees only the flags raised by its own operations.</remarks>
    /// <param name="mask">The flag mask.</param>
    public static void ClearFlags(uint mask)
    {
        mpfr.flags_clear(mask);
    }

    /// <summary>
    /// Sets some flags.
    /// </summary>
    /// <remarks>MPFR keeps the flags per thread: each thread sees only the flags raised by its own operations.</remarks>
    /// <param name="mask">The flag mask.</param>
    public static void SetFlags(uint mask)
    {
        mpfr.flags_set(mask);
    }

    /// <summary>
    /// Sets the flags of a mask to the corresponding flags of a value.
    /// </summary>
    /// <remarks>MPFR keeps the flags per thread: each thread sees only the flags raised by its own operations.</remarks>
    /// <param name="mask">The flag mask.</param>
    /// <param name="value">The flags value.</param>
    public static void SetFlags(uint mask, uint value)
    {
        mpfr.flags_restore(value, mask);
    }

    /// <summary>
    /// Gets the flags of a mask that are set.
    /// </summary>
    /// <remarks>MPFR keeps the flags per thread: each thread sees only the flags raised by its own operations.</remarks>
    /// <param name="mask">The flag mask.</param>
    public static uint TestFlags(uint mask)
    {
        return mpfr.flags_test(mask);
    }

    /// <summary>
    /// Gets all the flags.
    /// </summary>
    /// <remarks>MPFR keeps the flags per thread: each thread sees only the flags raised by its own operations.</remarks>
    public static uint GetAllFlags()
    {
        return mpfr.flags_save();
    }

    /// <summary>
    /// Gets the ternary value of the operation that computed this number: zero if the result is exact, a positive value if it is greater than the exact result, and a negative value if it is lower.
    /// </summary>
    public int LastTernaryResult { get; private set; }
}
