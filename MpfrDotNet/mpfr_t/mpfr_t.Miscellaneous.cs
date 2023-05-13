namespace MpfrDotNet;

using System;
using System.Text;
using Interop.Mpfr;
using MpirDotNet;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public partial class mpfr_t : IDisposable
{
    /// <summary>
    /// Gets the min of two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    public static mpfr_t Min(mpfr_t x, mpfr_t y, mpfr_rnd_t rounding = DefaultRounding)
    {
        mpfr_t z = new();

        mpfr_min(ref z.Value, ref x.Value, ref y.Value, (__mpfr_rnd_t)rounding);

        return z;
    }

    /// <summary>
    /// Gets the max of two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    public static mpfr_t Max(mpfr_t x, mpfr_t y, mpfr_rnd_t rounding = DefaultRounding)
    {
        mpfr_t z = new();

        mpfr_max(ref z.Value, ref x.Value, ref y.Value, (__mpfr_rnd_t)rounding);

        return z;
    }

    /// <summary>
    /// Swaps two numbers.
    /// </summary>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    public static void Swap(mpfr_t x, mpfr_t y)
    {
        mpfr_swap(ref x.Value, ref y.Value);
    }

    /// <summary>
    /// Returns a string that represents the number value.
    /// </summary>
    /// <param name="format">The formatting string.</param>
    /// <returns>The formatted number.</returns>
    public string ToFormattedString(string format)
    {
        ulong SizeInDigits = DigitCount;
        StringBuilder Data = new StringBuilder((int)(SizeInDigits + 2));

        mpfr_sprintf(Data, format, ref Value, IntPtr.Zero);

        string Result = Data.ToString();

        return Result;
    }

    /// <summary>
    /// Returns a string that represents the number value.
    /// </summary>
    /// <param name="maxLength">The maximum number of characters to return.</param>
    /// <param name="format">The formatting string.</param>
    /// <returns>The formatted number.</returns>
    public string ToFormattedString(ulong maxLength, string format)
    {
        ulong SizeInDigits = DigitCount;
        StringBuilder Data = new StringBuilder((int)(SizeInDigits + 2));

        mpfr_snprintf(Data, maxLength, format, ref Value, IntPtr.Zero);

        string Result = Data.ToString();

        return Result;
    }

    /// <summary>
    /// Generates a uniformly distributed random float in the interval 0 ≤ rop &lt; 1.
    /// </summary>
    /// <param name="randomState">The random state.</param>
    public static mpfr_t UniformRandom(randstate_t randomState)
    {
        mpfr_t Result = new();

        mpfr_urandomb(ref Result.Value, ref randomState.Value);

        return Result;
    }

    /// <summary>
    /// Generates a uniformly distributed random float in the interval 0 ≤ rop ≤ 1.
    /// </summary>
    /// <param name="randomState">The random state.</param>
    /// <param name="rounding">The rounding mode.</param>
    public static mpfr_t UniformRandom(randstate_t randomState, mpfr_rnd_t rounding)
    {
        mpfr_t Result = new();

        mpfr_urandom(ref Result.Value, ref randomState.Value, (__mpfr_rnd_t)rounding);

        return Result;
    }

    /// <summary>
    /// Generates random float according to a standard normal Gaussian distribution.
    /// </summary>
    /// <param name="randomState">The random state.</param>
    /// <param name="rounding">The rounding mode.</param>
    public static mpfr_t GaussianRandom(randstate_t randomState, mpfr_rnd_t rounding = DefaultRounding)
    {
        mpfr_t Result = new();

        mpfr_nrandom(ref Result.Value, ref randomState.Value, (__mpfr_rnd_t)rounding);

        return Result;
    }

    /// <summary>
    /// Generates two random floats according to a standard normal Gaussian distribution.
    /// </summary>
    /// <param name="randomState">The random state.</param>
    /// <param name="rand1">The first random number upon return.</param>
    /// <param name="rand2">The second random number upon return.</param>
    /// <param name="rounding">The rounding mode.</param>
    public static void GaussianRandom(randstate_t randomState, out mpfr_t rand1, out mpfr_t rand2, mpfr_rnd_t rounding = DefaultRounding)
    {
        rand1 = new mpfr_t();
        rand2 = new mpfr_t();

        mpfr_grandom(ref rand1.Value, ref rand2.Value, ref randomState.Value, (__mpfr_rnd_t)rounding);
    }

    /// <summary>
    /// Generates random float according to an exponential distribution.
    /// </summary>
    /// <param name="randomState">The random state.</param>
    /// <param name="rounding">The rounding mode.</param>
    public static mpfr_t ExponentialRandom(randstate_t randomState, mpfr_rnd_t rounding = DefaultRounding)
    {
        mpfr_t Result = new();

        mpfr_erandom(ref Result.Value, ref randomState.Value, (__mpfr_rnd_t)rounding);

        return Result;
    }

    /// <summary>
    /// Gets or sets the exponent.
    /// </summary>
    public int Exponent
    {
        get { return mpfr_get_exp(ref Value); }
        set { mpfr_set_exp(ref Value, value); }
    }

    /// <summary>
    /// Gets the sign bit.
    /// </summary>
    public int SignBit
    {
        get { return mpfr_signbit(ref Value); }
    }

    /// <summary>
    /// Set the sign from an operand.
    /// </summary>
    /// <param name="source">The source operand.</param>
    /// <param name="signBit">The sign bit.</param>
    /// <param name="rounding">The rounding mode.</param>
    public void SetWithSignBit(mpfr_t source, int signBit, mpfr_rnd_t rounding = DefaultRounding)
    {
        mpfr_setsign(ref Value, ref source.Value, signBit, (__mpfr_rnd_t)rounding);
    }

    /// <summary>
    /// Copy a number with the sign from another.
    /// </summary>
    /// <param name="source">The source operand.</param>
    /// <param name="signBitSource">The sign bit source operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    public void CopyWithSignBit(mpfr_t source, mpfr_t signBitSource, mpfr_rnd_t rounding = DefaultRounding)
    {
        mpfr_copysign(ref Value, ref source.Value, ref signBitSource.Value, (__mpfr_rnd_t)rounding);
    }
}
