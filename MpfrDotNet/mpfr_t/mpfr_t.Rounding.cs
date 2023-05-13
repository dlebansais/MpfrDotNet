namespace MpfrDotNet;

using System;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public partial class mpfr_t : IDisposable
{
    /// <summary>
    /// Gets or sets the default rounding mode.
    /// </summary>
    public static mpfr_rnd_t DefaultRoundingMode
    {
        get { return (mpfr_rnd_t)mpfr_get_default_rounding_mode(); }
        set { mpfr_set_default_rounding_mode((__mpfr_rnd_t)value); }
    }

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

    /// <summary>
    /// Gets the fractional part.
    /// </summary>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t Fractional(mpfr_rnd_t rounding)
    {
        mpfr_t z = new();

        mpfr_frac(ref z.Value, ref Value, (__mpfr_rnd_t)rounding);

        return z;
    }

    /// <summary>
    /// Gets the fractional part.
    /// </summary>
    /// <param name="integer">The integer part upon return.</param>
    /// <param name="fractional">The fractional part upon return.</param>
    /// <param name="rounding">The rounding mode.</param>
    public void IntegerAndFractional(out mpfr_t integer, out mpfr_t fractional, mpfr_rnd_t rounding = DefaultRounding)
    {
        integer = new mpfr_t();
        fractional = new mpfr_t();

        mpfr_modf(ref integer.Value, ref fractional.Value, ref Value, (__mpfr_rnd_t)rounding);
    }

    /// <summary>
    /// Gets the fractional difference.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    public static mpfr_t FMod(mpfr_t x, mpfr_t y, mpfr_rnd_t rounding = DefaultRounding)
    {
        mpfr_t z = new();

        mpfr_fmod(ref z.Value, ref x.Value, ref y.Value, (__mpfr_rnd_t)rounding);

        return z;
    }

    /// <summary>
    /// Gets the fractional difference.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    public static mpfr_t FMod(mpfr_t x, ulong y, mpfr_rnd_t rounding = DefaultRounding)
    {
        mpfr_t z = new();

        mpfr_fmod_ui(ref z.Value, ref x.Value, y, (__mpfr_rnd_t)rounding);

        return z;
    }

    /// <summary>
    /// Gets the fractional difference.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <param name="q">The quotient upon return.</param>
    /// <param name="rounding">The rounding mode.</param>
    public static mpfr_t FMod(mpfr_t x, mpfr_t y, out long q, mpfr_rnd_t rounding = DefaultRounding)
    {
        mpfr_t z = new();

        mpfr_fmodquo(ref z.Value, out q, ref x.Value, ref y.Value, (__mpfr_rnd_t)rounding);

        return z;
    }

    /// <summary>
    /// Gets the fractional remainder.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    public static mpfr_t Remainder(mpfr_t x, mpfr_t y, mpfr_rnd_t rounding = DefaultRounding)
    {
        mpfr_t z = new();

        mpfr_remainder(ref z.Value, ref x.Value, ref y.Value, (__mpfr_rnd_t)rounding);

        return z;
    }

    /// <summary>
    /// Gets the fractional remainder.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <param name="q">The quotient upon return.</param>
    /// <param name="rounding">The rounding mode.</param>
    public static mpfr_t Remainder(mpfr_t x, mpfr_t y, out long q, mpfr_rnd_t rounding = DefaultRounding)
    {
        mpfr_t z = new();

        mpfr_remquo(ref z.Value, out q, ref x.Value, ref y.Value, (__mpfr_rnd_t)rounding);

        return z;
    }

    /// <summary>
    /// Rounds to an integer.
    /// </summary>
    /// <param name="precision">The precision.</param>
    /// <param name="rounding">The rounding mode.</param>
    public void RoundWithPrecision(ulong precision, mpfr_rnd_t rounding)
    {
        mpfr_prec_round(ref Value, precision, (__mpfr_rnd_t)rounding);
    }

    /// <summary>
    /// Checks if the number can be rounded correctly.
    /// </summary>
    /// <param name="err">The error exponent.</param>
    /// <param name="rounding1">The number rounding.</param>
    /// <param name="rounding2">The precision rounding.</param>
    /// <param name="precision">The precision.</param>
    public bool CanRound(int err, mpfr_rnd_t rounding1, mpfr_rnd_t rounding2, ulong precision)
    {
        return mpfr_can_round(ref Value, err, (__mpfr_rnd_t)rounding1, (__mpfr_rnd_t)rounding2, precision) != 0;
    }
}
