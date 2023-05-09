namespace MpfrDotNet;

using System;
using System.Text;
using Interop.Mpfr;
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
}
