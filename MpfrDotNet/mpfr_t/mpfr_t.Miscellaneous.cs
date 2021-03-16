namespace MpfrDotNet
{
    using System;
    using static NativeMethods;

    public partial class mpfr_t : IDisposable
    {
        public static mpfr_t Min(mpfr_t x, mpfr_t y, mpfr_rnd_t rounding = DefaultRounding)
        {
            mpfr_t z = new();

            mpfr_min(ref z.Value, ref x.Value, ref y.Value, rounding);

            return z;
        }

        public static mpfr_t Max(mpfr_t x, mpfr_t y, mpfr_rnd_t rounding = DefaultRounding)
        {
            mpfr_t z = new();

            mpfr_max(ref z.Value, ref x.Value, ref y.Value, rounding);

            return z;
        }
    }
}
