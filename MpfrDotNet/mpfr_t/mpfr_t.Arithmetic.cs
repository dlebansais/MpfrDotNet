namespace MpfrDotNet
{
    using System;
    using static NativeMethods;

    public partial class mpfr_t : IDisposable
    {
        public mpfr_t Sqrt()
        {
            mpfr_t z = new();

            mpfr_sqrt(ref z.Value, ref Value, Rounding);

            return z;
        }

        public mpfr_t Cbrt()
        {
            mpfr_t z = new();

            mpfr_cbrt(ref z.Value, ref Value, Rounding);

            return z;
        }

        public mpfr_t NthRoot(ulong n)
        {
            mpfr_t z = new();

            mpfr_rootn_ui(ref z.Value, ref Value, n, Rounding);

            return z;
        }

        public mpfr_t Abs()
        {
            mpfr_t z = new();

            mpfr_abs(ref z.Value, ref Value, Rounding);

            return z;
        }

        public static mpfr_t EuclideanNorm(mpfr_t x, mpfr_t y, mpfr_rnd_t rounding = DefaultRounding)
        {
            mpfr_t z = new();

            mpfr_hypot(ref z.Value, ref x.Value, ref y.Value, rounding);

            return z;
        }
    }
}
