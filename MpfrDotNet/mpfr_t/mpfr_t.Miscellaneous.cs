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
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public static mpfr_t Min(mpfr_t x, mpfr_t y, mpfr_rnd_t rounding = DefaultRounding)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(x, y);

        z.LastTernaryResult = mpfr.min(z, x, y, rounding);

        return z;
    }

    /// <summary>
    /// Gets the max of two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public static mpfr_t Max(mpfr_t x, mpfr_t y, mpfr_rnd_t rounding = DefaultRounding)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(x, y);

        z.LastTernaryResult = mpfr.max(z, x, y, rounding);

        return z;
    }

    /// <summary>
    /// Swaps two numbers.
    /// </summary>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static void Swap(mpfr_t x, mpfr_t y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpfr.swap(x, y);
    }

    /// <summary>
    /// Returns a string that represents the number value.
    /// </summary>
    /// <param name="format">The formatting string.</param>
    /// <returns>The formatted number.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
    /// <exception cref="FormatException"><paramref name="format"/> has more than one conversion, or a conversion that is not for an <see cref="mpfr_t"/> (such as %Rf), or MPFR cannot format the number with it.</exception>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public string ToFormattedString(string format)
    {
        ThrowIfDisposed(this);

        if (format is null)
            throw new ArgumentNullException(nameof(format));

        // The native call passes the number as its only argument: a format that reads any other argument would read invalid memory.
        if (!HasAtMostOneMpfrConversion(format))
            throw new FormatException($"The format '{format}' must have at most one conversion, for an mpfr_t such as %Rf.");

        // A first call with no buffer returns the length of the output.
        int Length = mpfr_snprintf(null, 0, format, ref Value, IntPtr.Zero);
        if (Length < 0)
            throw new FormatException($"The number cannot be formatted with '{format}'.");

        StringBuilder Data = new(Length + 1);
        _ = mpfr_snprintf(Data, (ulong)Length + 1, format, ref Value, IntPtr.Zero);

        return Data.ToString();
    }

    private static bool HasAtMostOneMpfrConversion(string format)
    {
        int ConversionCount = 0;
        int i = 0;

        while (i < format.Length)
        {
            if (format[i] != '%')
                i++;
            else if (i + 1 < format.Length && format[i + 1] == '%')
                i += 2;
            else if (IsMpfrConversion(format, ref i))
                ConversionCount++;
            else
                return false;
        }

        return ConversionCount <= 1;
    }

    private static bool IsMpfrConversion(string format, ref int index)
    {
        // The syntax is % [flags] [width] [.[precision]] R [rounding] conversion. A '*' width, precision or rounding
        // would read an extra argument, so it is not accepted.
        int i = index + 1;

        while (i < format.Length && "-+ #0'".IndexOf(format[i]) >= 0)
            i++;

        while (i < format.Length && IsDigit(format[i]))
            i++;

        if (i < format.Length && format[i] == '.')
        {
            i++;

            while (i < format.Length && IsDigit(format[i]))
                i++;
        }

        if (i >= format.Length || format[i] != 'R')
            return false;

        i++;

        if (i < format.Length && "NZUDY".IndexOf(format[i]) >= 0)
            i++;

        if (i >= format.Length || "aAbeEfFgG".IndexOf(format[i]) < 0)
            return false;

        index = i + 1;
        return true;
    }

    private static bool IsDigit(char c) => c is >= '0' and <= '9';

    /// <summary>
    /// Returns a string that represents the number value.
    /// </summary>
    /// <param name="maxLength">The size of the output buffer, including the terminating null character: at most <paramref name="maxLength"/> - 1 characters are returned.</param>
    /// <param name="format">The formatting string.</param>
    /// <returns>The formatted number.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
    /// <exception cref="FormatException">MPFR cannot format the number with <paramref name="format"/>.</exception>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
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
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public static mpfr_t UniformRandom(randstate_t randomState, mpfr_rnd_t rounding)
    {
        mpfr_t Result = new();

        Result.LastTernaryResult = mpfr.urandom(Result, randomState, rounding);

        return Result;
    }

    /// <summary>
    /// Generates random float according to a standard normal Gaussian distribution.
    /// </summary>
    /// <param name="randomState">The random state.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public static mpfr_t GaussianRandom(randstate_t randomState, mpfr_rnd_t rounding = DefaultRounding)
    {
        mpfr_t Result = new();

        Result.LastTernaryResult = mpfr.nrandom(Result, randomState, rounding);

        return Result;
    }

    /// <summary>
    /// Generates two random floats according to a standard normal Gaussian distribution.
    /// </summary>
    /// <param name="randomState">The random state.</param>
    /// <param name="rand1">The first random number upon return.</param>
    /// <param name="rand2">The second random number upon return.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public static void GaussianRandom(randstate_t randomState, out mpfr_t rand1, out mpfr_t rand2, mpfr_rnd_t rounding = DefaultRounding)
    {
        rand1 = new mpfr_t();
        rand2 = new mpfr_t();

        int Ternary = mpfr.grandom(rand1, rand2, randomState, rounding);
        rand1.LastTernaryResult = DecodeTernary(Ternary);
        rand2.LastTernaryResult = DecodeTernary(Ternary >> 2);
    }

    /// <summary>
    /// Generates random float according to an exponential distribution.
    /// </summary>
    /// <param name="randomState">The random state.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public static mpfr_t ExponentialRandom(randstate_t randomState, mpfr_rnd_t rounding = DefaultRounding)
    {
        mpfr_t Result = new();

        Result.LastTernaryResult = mpfr.erandom(Result, randomState, rounding);

        return Result;
    }

    /// <summary>
    /// Gets or sets the exponent.
    /// </summary>
    /// <exception cref="InvalidOperationException">The number is zero, NaN or an infinity.</exception>
    /// <exception cref="ArgumentOutOfRangeException">The new exponent is outside the current exponent range.</exception>
    /// <exception cref="ObjectDisposedException">The number is disposed.</exception>
    public int Exponent
    {
        get
        {
            ThrowIfDisposed(this);

            return mpfr.get_exp(this);
        }

        set
        {
            if (!IsRegular)
                throw new InvalidOperationException(mpfr.NoExponentMessage);
            if (mpfr.set_exp(this, value) != 0)
                throw new ArgumentOutOfRangeException(nameof(value), value, "The exponent is outside the current exponent range.");
        }
    }

    /// <summary>
    /// Gets the sign bit.
    /// </summary>
    /// <exception cref="ObjectDisposedException">The number is disposed.</exception>
    public int SignBit
    {
        get
        {
            ThrowIfDisposed(this);

            return mpfr.signbit(this);
        }
    }

    /// <summary>
    /// Set the sign from an operand.
    /// </summary>
    /// <param name="source">The source operand.</param>
    /// <param name="signBit">The sign bit.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException">This number or <paramref name="source"/> is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public void SetWithSignBit(mpfr_t source, int signBit, mpfr_rnd_t rounding = DefaultRounding)
    {
        ThrowIfDisposed(this);
        ThrowIfDisposed(source);

        LastTernaryResult = mpfr.setsign(this, source, signBit, rounding);
    }

    /// <summary>
    /// Copy a number with the sign from another.
    /// </summary>
    /// <param name="source">The source operand.</param>
    /// <param name="signBitSource">The sign bit source operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException">This number, <paramref name="source"/> or <paramref name="signBitSource"/> is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public void CopyWithSignBit(mpfr_t source, mpfr_t signBitSource, mpfr_rnd_t rounding = DefaultRounding)
    {
        ThrowIfDisposed(this);
        ThrowIfDisposed(source);
        ThrowIfDisposed(signBitSource);

        LastTernaryResult = mpfr.copysign(this, source, signBitSource, rounding);
    }
}
