namespace MpfrDotNet;

using System;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public partial class mpfr_t : IDisposable
{
    /// <summary>
    /// Gets the square root.
    /// </summary>
    public mpfr_t Sqrt()
    {
        mpfr_t z = new();

        LastTernaryResult = mpfr_sqrt(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

        return z;
    }

    /// <summary>
    /// Gets the cubic root.
    /// </summary>
    public mpfr_t Cbrt()
    {
        mpfr_t z = new();

        LastTernaryResult = mpfr_cbrt(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

        return z;
    }

    /// <summary>
    /// Gets the nth root.
    /// </summary>
    /// <param name="n">The nth.</param>
    public mpfr_t NthRoot(ulong n)
    {
        mpfr_t z = new();

        LastTernaryResult = mpfr_rootn_ui(ref z.Value, ref Value, n, (__mpfr_rnd_t)Rounding);

        return z;
    }

    /// <summary>
    /// Gets the absolute value.
    /// </summary>
    public mpfr_t Abs()
    {
        mpfr_t z = new();

        LastTernaryResult = mpfr_abs(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

        return z;
    }

    /// <summary>
    /// Gets the euclidean norm of two numbers.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    public static mpfr_t EuclideanNorm(mpfr_t x, mpfr_t y, mpfr_rnd_t rounding = DefaultRounding)
    {
        mpfr_t z = new();

        mpfr_hypot(ref z.Value, ref x.Value, ref y.Value, (__mpfr_rnd_t)rounding);

        return z;
    }
}
