namespace MpfrDotNet
{
    using System;
    using static NativeMethods;

    public partial class mpfr_t : IDisposable
    {
        public mpfr_t RoundToInteger(mpfr_rnd_t rounding)
        {
            mpfr_t z = new();

            mpfr_rint(ref z.Value, ref Value, rounding);

            return z;
        }

        public mpfr_t Ceil()
        {
            mpfr_t z = new();

            mpfr_ceil(ref z.Value, ref Value);

            return z;
        }

        public mpfr_t Floor()
        {
            mpfr_t z = new();

            mpfr_floor(ref z.Value, ref Value);

            return z;
        }

        public mpfr_t Round()
        {
            mpfr_t z = new();

            mpfr_round(ref z.Value, ref Value);

            return z;
        }

        public mpfr_t RoundEven()
        {
            mpfr_t z = new();

            mpfr_roundeven(ref z.Value, ref Value);

            return z;
        }

        public mpfr_t Trunc()
        {
            mpfr_t z = new();

            mpfr_trunc(ref z.Value, ref Value);

            return z;
        }
    }
}
