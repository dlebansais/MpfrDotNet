namespace MpirDotNet;

using System;

/// <summary>
/// Checks the digit bases passed to the MPIR string conversion functions.
/// </summary>
internal static class DigitBase
{
    /// <summary>
    /// Checks a base for an output conversion, and returns the base to use when computing the number of digits.
    /// </summary>
    /// <param name="resultbase">The base: 2 to 62, or -36 to -2 for uppercase digits.</param>
    /// <param name="paramName">The name of the parameter that holds the base.</param>
    /// <returns>The absolute value of the base.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="resultbase"/> is not a supported base.</exception>
    public static uint ToDigitCountBase(int resultbase, string paramName)
    {
        bool IsLowercaseBase = resultbase >= 2 && resultbase <= 62;
        bool IsUppercaseBase = resultbase <= -2 && resultbase >= -36;

        if (!IsLowercaseBase && !IsUppercaseBase)
            throw new ArgumentOutOfRangeException(paramName, resultbase, "The base must be between 2 and 62, or between -36 and -2 for uppercase digits.");

        return (uint)Math.Abs(resultbase);
    }
}
