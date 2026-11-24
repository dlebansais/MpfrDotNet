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

        mpfr.min(z, x, y, rounding);

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

        mpfr.max(z, x, y, rounding);

        return z;
    }

    /// <summary>
    /// Swaps two numbers.
    /// </summary>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    public static void Swap(mpfr_t x, mpfr_t y)
    {
        mpfr.swap(x, y);
    }

    /// <summary>
    /// Returns a string that represents the number value.
    /// </summary>
    /// <param name="format">The formatting string.</param>
    /// <returns>The formatted number.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
    /// <exception cref="FormatException">MPFR cannot format the number with <paramref name="format"/>.</exception>
    public string ToFormattedString(string format)
    {
        if (format is null)
            throw new ArgumentNullException(nameof(format));

        // A first call with no buffer returns the length of the output.
        int Length = mpfr_snprintf(null, 0, format, ref Value, IntPtr.Zero);
        if (Length < 0)
            throw new FormatException($"The number cannot be formatted with '{format}'.");

        StringBuilder Data = new(Length + 1);
        _ = mpfr_snprintf(Data, (ulong)Length + 1, format, ref Value, IntPtr.Zero);

        return Data.ToString();
    }

    /// <summary>
    /// Returns a string that represents the number value.
    /// </summary>
    /// <param name="maxLength">The size of the output buffer, including the terminating null character: at most <paramref name="maxLength"/> - 1 characters are returned.</param>
    /// <param name="format">The formatting string.</param>
    /// <returns>The formatted number.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
    /// <exception cref="FormatException">MPFR cannot format the number with <paramref name="format"/>.</exception>
    public string ToFormattedString(ulong maxLength, string format)
    {
        string Result = ToFormattedString(format);

        if (maxLength == 0)
            return string.Empty;

        ulong MaxCharacters = maxLength - 1;
        return (ulong)Result.Length <= MaxCharacters ? Result : Result[..(int)MaxCharacters];
    }

    /// <summary>
    /// Generates a uniformly distributed random float in the interval 0 ≤ rop &lt; 1.
    /// </summary>
    /// <param name="randomState">The random state.</param>
    public static mpfr_t UniformRandom(randstate_t randomState)
    {
        mpfr_t Result = new();

        mpfr.urandomb(Result, randomState);

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

        mpfr.urandom(Result, randomState, rounding);

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

        mpfr.nrandom(Result, randomState, rounding);

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

        mpfr.grandom(rand1, rand2, randomState, rounding);
    }

    /// <summary>
    /// Generates random float according to an exponential distribution.
    /// </summary>
    /// <param name="randomState">The random state.</param>
    /// <param name="rounding">The rounding mode.</param>
    public static mpfr_t ExponentialRandom(randstate_t randomState, mpfr_rnd_t rounding = DefaultRounding)
    {
        mpfr_t Result = new();

        mpfr.erandom(Result, randomState, rounding);

        return Result;
    }

    /// <summary>
    /// Gets or sets the exponent.
    /// </summary>
    public int Exponent
    {
        get { return mpfr.get_exp(this); }
        set { mpfr.set_exp(this, value); }
    }

    /// <summary>
    /// Gets the sign bit.
    /// </summary>
    public int SignBit
    {
        get { return mpfr.signbit(this); }
    }

    /// <summary>
    /// Set the sign from an operand.
    /// </summary>
    /// <param name="source">The source operand.</param>
    /// <param name="signBit">The sign bit.</param>
    /// <param name="rounding">The rounding mode.</param>
    public void SetWithSignBit(mpfr_t source, int signBit, mpfr_rnd_t rounding = DefaultRounding)
    {
        mpfr.setsign(this, source, signBit, rounding);
    }

    /// <summary>
    /// Copy a number with the sign from another.
    /// </summary>
    /// <param name="source">The source operand.</param>
    /// <param name="signBitSource">The sign bit source operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    public void CopyWithSignBit(mpfr_t source, mpfr_t signBitSource, mpfr_rnd_t rounding = DefaultRounding)
    {
        mpfr.copysign(this, source, signBitSource, rounding);
    }
}
