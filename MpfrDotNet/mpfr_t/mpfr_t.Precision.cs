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
    public ulong MinPrecision { get { return mpfr.PrecisionMin; } }

    /// <summary>
    /// Gets the maximum precision.
    /// </summary>
    public ulong MaxPrecision { get { return mpfr.PrecisionMax; } }

    /// <summary>
    /// Gets or sets the precision.
    /// </summary>
    public ulong Precision
    {
        get { return mpfr.get_prec(this); }
        set { mpfr.set_prec(this, value); }
    }

    /// <summary>
    /// Gets the minimum significand precision.
    /// </summary>
    public int MinSignificandPrecision
    {
        get { return mpfr.min_prec(this); }
    }

    /// <summary>
    /// Sets the exact precision.
    /// </summary>
    /// <param name="value">The precision.</param>
    public void SetPrecisionRaw(ulong value)
    {
        mpfr.set_prec_raw(this, value);
    }

    /// <summary>
    /// Gets or sets the default precision.
    /// </summary>
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
