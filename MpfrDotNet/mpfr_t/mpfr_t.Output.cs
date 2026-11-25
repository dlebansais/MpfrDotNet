namespace MpfrDotNet;

using System;
using System.Diagnostics;
using System.Globalization;
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
    /// <exception cref="ObjectDisposedException">The number is disposed.</exception>
    public ulong DigitCount
    {
        get { return mpfr.get_str_ndigits(mpz_t.DefaultBase, Precision); }
    }

    /// <summary>
    /// Returns a string that represents the number value.
    /// </summary>
    /// <returns>The number value.</returns>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
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
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="resultbase"/> is not between 2 and 62, or between -36 and -2.</exception>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public string ToString(int resultbase, mpfr_rnd_t rounding)
    {
        Debug.Assert(IsCacheInitialized);

        ulong SizeInDigits = mpfr.get_str_ndigits((int)DigitBase.ToDigitCountBase(resultbase, nameof(resultbase)), Precision);

        // MPFR requires max(n + 2, 7) characters, since "-@Inf@" and its terminator take 7 whatever the precision.
        StringBuilder Data = new((int)Math.Max(SizeInDigits + 2, 7));

        mpfr.get_str(Data, out int Exponent, resultbase, SizeInDigits, this, rounding);

        string Result = Data.ToString();
        Debug.Assert(Result.Length > 0);

        if (Result == "@NaN@" || Result == "@Inf@" || Result == "-@Inf@")
            return Result;

        bool IsNegative = Result[0] == '-';

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
        Debug.Assert(FractionalIndex <= Result.Length);

        string IntegerPart = Result[..FractionalIndex];
        string FractionalPart = Result[FractionalIndex..];

        int LastNonZero = FractionalPart.Length;
        while (LastNonZero > 0 && FractionalPart[LastNonZero - 1] == '0')
            LastNonZero--;

        FractionalPart = FractionalPart[..LastNonZero];

        if (FractionalPart.Length > 0)
            FractionalPart = "." + FractionalPart;

        string ExponentPart = (Exponent - 1).ToString(CultureInfo.InvariantCulture);
        if (Exponent > 0)
            ExponentPart = "+" + ExponentPart;

        // MPFR reads '@' as the exponent marker in bases above 10, where 'E' can be a digit. The exponent is written in decimal.
        char ExponentMarker = Math.Abs(resultbase) > 10 ? '@' : 'E';
        Result = $"{IntegerPart}{FractionalPart}{ExponentMarker}{ExponentPart}";

        return Result;
    }
}
