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
    public ulong MinPrecision { get { return NativeMinPrecision; } }

    /// <summary>
    /// Gets the maximum precision.
    /// </summary>
    public ulong MaxPrecision { get { return NativeMaxPrecision; } }

    /// <summary>
    /// Gets or sets the precision.
    /// </summary>
    public ulong Precision
    {
        get { return mpfr_get_prec(ref Value); }
        set { mpfr_set_prec(ref Value, value); }
    }

    /// <summary>
    /// Gets or sets the default precision.
    /// </summary>
    public static ulong DefaultPrecision
    {
        get { return mpfr_get_default_prec(); }
        set { mpfr_set_default_prec(value); }
    }

    /// <summary>
    /// Gets the first value of the default precision.
    /// </summary>
    public static ulong DefaultPrecisionInit
    {
        get { return NativeDefaultPrecision; }
    }
}
