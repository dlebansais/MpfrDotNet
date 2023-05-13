namespace MpfrDotNet;

using System;
using Interop.Mpfr;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public partial class mpfr_t : IDisposable
{
    /// <summary>
    /// Rounds to an integer.
    /// </summary>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t RoundToInteger(mpfr_rnd_t rounding)
    {
        mpfr_t z = new();

        mpfr_rint(ref z.Value, ref Value, (__mpfr_rnd_t)rounding);

        return z;
    }

    /// <summary>
    /// Rounds to ceil.
    /// </summary>
    public mpfr_t Ceil()
    {
        mpfr_t z = new();

        mpfr_ceil(ref z.Value, ref Value);

        return z;
    }

    /// <summary>
    /// Rounds to ceil.
    /// </summary>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t Ceil(mpfr_rnd_t rounding)
    {
        mpfr_t z = new();

        mpfr_rint_ceil(ref z.Value, ref Value, (__mpfr_rnd_t)rounding);

        return z;
    }

    /// <summary>
    /// Rounds to floor.
    /// </summary>
    public mpfr_t Floor()
    {
        mpfr_t z = new();

        mpfr_floor(ref z.Value, ref Value);

        return z;
    }

    /// <summary>
    /// Rounds to floor.
    /// </summary>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t Floor(mpfr_rnd_t rounding)
    {
        mpfr_t z = new();

        mpfr_rint_floor(ref z.Value, ref Value, (__mpfr_rnd_t)rounding);

        return z;
    }

    /// <summary>
    /// Rounds to nearest.
    /// </summary>
    public mpfr_t Round()
    {
        mpfr_t z = new();

        mpfr_round(ref z.Value, ref Value);

        return z;
    }

    /// <summary>
    /// Rounds to nearest.
    /// </summary>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t Round(mpfr_rnd_t rounding)
    {
        mpfr_t z = new();

        mpfr_rint_round(ref z.Value, ref Value, (__mpfr_rnd_t)rounding);

        return z;
    }

    /// <summary>
    /// Rounds to even.
    /// </summary>
    public mpfr_t RoundEven()
    {
        mpfr_t z = new();

        mpfr_roundeven(ref z.Value, ref Value);

        return z;
    }

    /// <summary>
    /// Rounds to even.
    /// </summary>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t RoundEven(mpfr_rnd_t rounding)
    {
        mpfr_t z = new();

        mpfr_rint_roundeven(ref z.Value, ref Value, (__mpfr_rnd_t)rounding);

        return z;
    }

    /// <summary>
    /// Rounds truncating.
    /// </summary>
    public mpfr_t Trunc()
    {
        mpfr_t z = new();

        mpfr_trunc(ref z.Value, ref Value);

        return z;
    }

    /// <summary>
    /// Rounds truncating.
    /// </summary>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t Trunc(mpfr_rnd_t rounding)
    {
        mpfr_t z = new();

        mpfr_rint_trunc(ref z.Value, ref Value, (__mpfr_rnd_t)rounding);

        return z;
    }
}
