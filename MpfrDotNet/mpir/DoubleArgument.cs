namespace MpirDotNet;

using System;

/// <summary>
/// Checks <see cref="double"/> arguments before they reach MPIR, which aborts the process on values it does not support.
/// </summary>
internal static class DoubleArgument
{
    /// <summary>
    /// Checks that a value can be converted to an MPIR number.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="OverflowException"><paramref name="value"/> is NaN or an infinity.</exception>
    public static void CheckFinite(double value)
    {
        if (double.IsNaN(value) || double.IsInfinity(value))
            throw new OverflowException("NaN and infinities cannot be converted to an MPIR number.");
    }

    /// <summary>
    /// Checks that a value can be compared with an MPIR number.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="paramName">The name of the parameter that holds the value.</param>
    /// <exception cref="ArgumentException"><paramref name="value"/> is NaN.</exception>
    public static void CheckNotNaN(double value, string paramName)
    {
        if (double.IsNaN(value))
            throw new ArgumentException("NaN cannot be compared with an MPIR number.", paramName);
    }
}
