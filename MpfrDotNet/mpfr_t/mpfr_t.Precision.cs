namespace MpfrDotNet;

using System;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public partial class mpfr_t : IDisposable
{
    /// <summary>
    /// Gets the minimum precision.
    /// </summary>
    /// <exception cref="ObjectDisposedException">The number is disposed.</exception>
#pragma warning disable CA1822
    public ulong MinPrecision
    {
        get
        {
            ThrowIfDisposed(this);

            return mpfr.PrecisionMin;
        }
    }
#pragma warning restore CA1822

    /// <summary>
    /// Gets the maximum precision.
    /// </summary>
    /// <exception cref="ObjectDisposedException">The number is disposed.</exception>
#pragma warning disable CA1822
    public ulong MaxPrecision
    {
        get
        {
            ThrowIfDisposed(this);

            return mpfr.PrecisionMax;
        }
    }
#pragma warning restore CA1822

    /// <summary>
    /// Gets or sets the precision.
    /// </summary>
    /// <remarks>Setting the precision keeps the value, rounded to the new precision with <see cref="Rounding"/>, and updates <see cref="LastTernaryResult"/>.</remarks>
    /// <exception cref="ArgumentOutOfRangeException">The value set is lesser than <see cref="mpfr.PrecisionMin"/> or greater than <see cref="mpfr.PrecisionMax"/>.</exception>
    /// <exception cref="ObjectDisposedException">The number is disposed.</exception>
    public ulong Precision
    {
        get
        {
            ThrowIfDisposed(this);

            return mpfr.get_prec(this);
        }

        set
        {
            ThrowIfDisposed(this);

            LastTernaryResult = mpfr.prec_round(this, value, Rounding);
        }
    }

    /// <summary>
    /// Gets the minimum significand precision.
    /// </summary>
    /// <exception cref="ObjectDisposedException">The number is disposed.</exception>
    public int MinSignificandPrecision
    {
        get
        {
            ThrowIfDisposed(this);

            return mpfr.min_prec(this);
        }
    }

    /// <summary>
    /// Sets the exact precision.
    /// </summary>
    /// <param name="value">The precision.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is lesser than <see cref="mpfr.PrecisionMin"/> or greater than <see cref="mpfr.PrecisionMax"/>, or greater than the precision allocated for the number, which is the largest precision it has had.</exception>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public void SetPrecisionRaw(ulong value)
    {
        ThrowIfDisposed(this);

        mpfr.set_prec_raw(this, value);
    }

    /// <summary>
    /// Gets or sets the default precision.
    /// </summary>
    /// <remarks>MPFR keeps this setting per thread: a value set on one thread does not apply to the other threads, including the thread-pool threads that run the continuations of an await.</remarks>
    /// <exception cref="ArgumentOutOfRangeException">The value set is lesser than <see cref="mpfr.PrecisionMin"/> or greater than <see cref="mpfr.PrecisionMax"/>.</exception>
    public static ulong DefaultPrecision
    {
        get { return mpfr.get_default_prec(); }
        set { mpfr.set_default_prec(value); }
    }

    /// <summary>
    /// Gets the first value of the default precision.
    /// </summary>
    public static ulong DefaultPrecisionInit
    {
        get { return mpfr.PrecisionDefault; }
    }
}
