namespace MpfrDotNet
{
    using System;
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
    }
}
