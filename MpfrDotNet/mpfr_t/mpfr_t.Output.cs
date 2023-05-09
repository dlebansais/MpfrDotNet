namespace MpfrDotNet;

using System;
using System.Text;
using MpirDotNet;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public partial class mpfr_t : IDisposable
{
    /// <summary>
    /// Gets the number of digits necessary to store a string with the current precision.
    /// </summary>
    public ulong DigitCount
    {
        get { return mpfr_get_str_ndigits(mpz_t.DefaultBase, Precision); }
    }

    /// <summary>
    /// Returns a string that represents the number value.
    /// </summary>
    /// <returns>The number value.</returns>
    public override string ToString()
    {
        return ToString(mpz_t.DefaultBase, DefaultRounding);
    }

    /// <summary>
    /// Returns a string that represents the number value.
    /// </summary>
    /// <param name="resultbase">The digit base.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <returns>The number value.</returns>
    public string ToString(int resultbase, mpfr_rnd_t rounding)
    {
        if (!IsCacheInitialized)
            return string.Empty;

        ulong SizeInDigits = DigitCount;
        StringBuilder Data = new StringBuilder((int)(SizeInDigits + 2));

        int Exponent;
        mpfr_get_str(Data, out Exponent, resultbase, SizeInDigits, ref Value, (__mpfr_rnd_t)rounding);

        string Result = Data.ToString();

        if (Result == "@NaN@" || Result == "@Inf@" || Result == "-@Inf@")
            return Result;

        bool IsNegative = Result.Length > 0 && Result[0] == '-';

        bool IsZero = true;
        for (int i = IsNegative ? 1 : 0; i < Result.Length; i++)
            if (Result[i] != '0')
            {
                IsZero = false;
                break;
            }

        if (IsZero)
            return IsNegative ? "-0" : "0";

        int FractionalIndex = IsNegative ? 2 : 1;

        if (FractionalIndex > Result.Length)
            return Result;

        string IntegerPart = Result.Substring(0, FractionalIndex);
        string FractionalPart = Result.Substring(FractionalIndex);

        int LastNonZero = FractionalPart.Length;
        while (LastNonZero > 0 && FractionalPart[LastNonZero - 1] == '0')
            LastNonZero--;

        FractionalPart = FractionalPart.Substring(0, LastNonZero);

        if (FractionalPart.Length > 0)
            FractionalPart = "." + FractionalPart;

        string ExponentPart = (Exponent - 1).ToString();
        if (Exponent > 0)
            ExponentPart = "+" + ExponentPart;

        Result = $"{IntegerPart}{FractionalPart}E{ExponentPart}";

        return Result;
    }
}
