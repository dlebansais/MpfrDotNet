namespace MpirDotNet;

using System;

/// <summary>
/// Checks the rounding passed to integer division functions.
/// </summary>
internal static class RoundingArgument
{
    /// <summary>
    /// Checks that a rounding is one of the values of <see cref="Rounding"/>.
    /// </summary>
    /// <param name="rounding">The rounding.</param>
    /// <param name="paramName">The name of the parameter that holds the rounding.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a value of <see cref="Rounding"/>.</exception>
    public static void Check(Rounding rounding, string paramName)
    {
        if (rounding is not (Rounding.TowardZero or Rounding.TowardPositiveInfinity or Rounding.TowardNegativeInfinity))
            throw new ArgumentOutOfRangeException(paramName, rounding, "The rounding is not a valid value.");
    }
}
