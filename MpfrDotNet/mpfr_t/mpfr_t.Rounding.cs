namespace MpfrDotNet;

using System;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public partial class mpfr_t : IDisposable
{
    /// <summary>
    /// Gets or sets the default rounding mode, which new instances take as their <see cref="Rounding"/>.
    /// </summary>
    /// <remarks>MPFR keeps this setting per thread: a value set on one thread does not apply to the other threads, including the thread-pool threads that run the continuations of an await. Optional rounding parameters default to <see cref="DefaultRounding"/>, whatever this setting.</remarks>
    /// <exception cref="ArgumentOutOfRangeException">The value set is <see cref="mpfr_rnd_t.MPFR_RNDNA"/> or not a value of <see cref="mpfr_rnd_t"/>.</exception>
    public static mpfr_rnd_t DefaultRoundingMode
    {
        get { return mpfr.get_default_rounding_mode(); }
        set { mpfr.set_default_rounding_mode(value); }
    }

    /// <summary>
    /// Rounds to an integer.
    /// </summary>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public mpfr_t RoundToInteger(mpfr_rnd_t rounding)
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.rint(z, this, rounding);

        return z;
    }

    /// <summary>
    /// Rounds to ceil.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Ceil()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.ceil(z, this);

        return z;
    }

    /// <summary>
    /// Rounds to ceil.
    /// </summary>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public mpfr_t Ceil(mpfr_rnd_t rounding)
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.rint_ceil(z, this, rounding);

        return z;
    }

    /// <summary>
    /// Rounds to floor.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Floor()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.floor(z, this);

        return z;
    }

    /// <summary>
    /// Rounds to floor.
    /// </summary>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public mpfr_t Floor(mpfr_rnd_t rounding)
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.rint_floor(z, this, rounding);

        return z;
    }

    /// <summary>
    /// Rounds to nearest.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Round()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.round(z, this);

        return z;
    }

    /// <summary>
    /// Rounds to nearest.
    /// </summary>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public mpfr_t Round(mpfr_rnd_t rounding)
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.rint_round(z, this, rounding);

        return z;
    }

    /// <summary>
    /// Rounds to even.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t RoundEven()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.roundeven(z, this);

        return z;
    }

    /// <summary>
    /// Rounds to even.
    /// </summary>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public mpfr_t RoundEven(mpfr_rnd_t rounding)
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.rint_roundeven(z, this, rounding);

        return z;
    }

    /// <summary>
    /// Rounds truncating.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Trunc()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.trunc(z, this);

        return z;
    }

    /// <summary>
    /// Rounds truncating.
    /// </summary>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public mpfr_t Trunc(mpfr_rnd_t rounding)
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.rint_trunc(z, this, rounding);

        return z;
    }

    /// <summary>
    /// Gets the fractional part.
    /// </summary>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public mpfr_t Fractional(mpfr_rnd_t rounding)
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.frac(z, this, rounding);

        return z;
    }

    /// <summary>
    /// Gets the fractional part.
    /// </summary>
    /// <param name="integer">The integer part upon return.</param>
    /// <param name="fractional">The fractional part upon return.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public void IntegerAndFractional(out mpfr_t integer, out mpfr_t fractional, mpfr_rnd_t rounding = DefaultRounding)
    {
        ThrowIfDisposed(this);

        integer = CreateResult(this);
        fractional = CreateResult(this);

        int Ternary = mpfr.modf(integer, fractional, this, rounding);
        integer.LastTernaryResult = DecodeTernary(Ternary);
        fractional.LastTernaryResult = DecodeTernary(Ternary >> 2);
    }

    /// <summary>
    /// Gets the fractional difference.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public static mpfr_t FMod(mpfr_t x, mpfr_t y, mpfr_rnd_t rounding = DefaultRounding)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(x, y);

        z.LastTernaryResult = mpfr.fmod(z, x, y, rounding);

        return z;
    }

    /// <summary>
    /// Gets the fractional difference.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public static mpfr_t FMod(mpfr_t x, ulong y, mpfr_rnd_t rounding = DefaultRounding)
    {
        ThrowIfDisposed(x);

        mpfr_t z = CreateResult(x);

        z.LastTernaryResult = mpfr.fmod_ui(z, x, y, rounding);

        return z;
    }

    /// <summary>
    /// Gets the fractional difference.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <param name="q">The quotient upon return.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public static mpfr_t FMod(mpfr_t x, mpfr_t y, out long q, mpfr_rnd_t rounding = DefaultRounding)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(x, y);

        z.LastTernaryResult = mpfr.fmodquo(z, out q, x, y, rounding);

        return z;
    }

    /// <summary>
    /// Gets the fractional remainder.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public static mpfr_t Remainder(mpfr_t x, mpfr_t y, mpfr_rnd_t rounding = DefaultRounding)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(x, y);

        z.LastTernaryResult = mpfr.remainder(z, x, y, rounding);

        return z;
    }

    /// <summary>
    /// Gets the fractional remainder.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <param name="q">The quotient upon return.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public static mpfr_t Remainder(mpfr_t x, mpfr_t y, out long q, mpfr_rnd_t rounding = DefaultRounding)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(x, y);

        z.LastTernaryResult = mpfr.remquo(z, out q, x, y, rounding);

        return z;
    }

    /// <summary>
    /// Rounds to a new precision, keeping the value.
    /// </summary>
    /// <param name="precision">The precision.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="precision"/> is lesser than <see cref="mpfr.PrecisionMin"/> or greater than <see cref="mpfr.PrecisionMax"/>, or <paramref name="rounding"/> is not a supported rounding mode.</exception>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public void RoundWithPrecision(ulong precision, mpfr_rnd_t rounding)
    {
        ThrowIfDisposed(this);

        LastTernaryResult = mpfr.prec_round(this, precision, rounding);
    }

    /// <summary>
    /// Checks if the number can be rounded correctly.
    /// </summary>
    /// <param name="err">The error exponent.</param>
    /// <param name="rounding1">The number rounding.</param>
    /// <param name="rounding2">The precision rounding.</param>
    /// <param name="precision">The precision.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="precision"/> is lesser than <see cref="mpfr.PrecisionMin"/> or greater than <see cref="mpfr.PrecisionMax"/>, or <paramref name="rounding1"/> is not a supported rounding mode, or <paramref name="rounding2"/> is not a supported rounding mode.</exception>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public bool CanRound(int err, mpfr_rnd_t rounding1, mpfr_rnd_t rounding2, ulong precision)
    {
        ThrowIfDisposed(this);

        return mpfr.can_round(this, err, rounding1, rounding2, precision);
    }
}
