namespace MpfrDotNet
{
    using System;
    using MpirDotNet;
    using static NativeMethods;

    public partial class mpfr_t : IDisposable
    {
        public const mpfr_rnd_t DefaultRounding = mpfr_rnd_t.MPFR_RNDN;

        public mpfr_t()
        {
            mpfr_init2(ref Value, DefaultPrecision);
            InitCacheManagement();
        }

        public static mpfr_t Create(ulong precision = ulong.MaxValue)
        {
            mpfr_t Result = new mpfr_t();

            if (precision == ulong.MaxValue)
                mpfr_init2(ref Result.Value, DefaultPrecision);
            else
                mpfr_init2(ref Result.Value, precision);

            return Result;
        }

        public static mpfr_t Infinite(int sign = +1)
        {
            mpfr_t Result = new mpfr_t();
            mpfr_set_inf(ref Result.Value, sign);

            return Result;
        }

        public static mpfr_t Zero(int sign = +1)
        {
            mpfr_t Result = new mpfr_t();
            mpfr_set_zero(ref Result.Value, sign);

            return Result;
        }

        public mpfr_t(mpfr_t other, mpfr_rnd_t rounding = DefaultRounding)
            : this()
        {
            mpfr_set(ref Value, ref other.Value, rounding);
        }

        public mpfr_t(ulong op, mpfr_rnd_t rounding = DefaultRounding)
            : this()
        {
            mpfr_set_ui(ref Value, op, rounding);
        }

        public mpfr_t(long op, mpfr_rnd_t rounding = DefaultRounding)
            : this()
        {
            mpfr_set_si(ref Value, op, rounding);
        }

        public mpfr_t(uint op, mpfr_rnd_t rounding = DefaultRounding)
            : this()
        {
            mpfr_set_uj(ref Value, op, rounding);
        }

        public mpfr_t(int op, mpfr_rnd_t rounding = DefaultRounding)
            : this()
        {
            mpfr_set_sj(ref Value, op, rounding);
        }

        public mpfr_t(float op, mpfr_rnd_t rounding = DefaultRounding)
            : this()
        {
            mpfr_set_flt(ref Value, op, rounding);
        }

        public mpfr_t(double op, mpfr_rnd_t rounding = DefaultRounding)
            : this()
        {
            mpfr_set_d(ref Value, op, rounding);
        }

        public mpfr_t(mpz_t op, mpfr_rnd_t rounding = DefaultRounding)
            : this()
        {
            mpfr_set_z(ref Value, ref op.Value, rounding);
        }

        public mpfr_t(mpq_t op, mpfr_rnd_t rounding = DefaultRounding)
            : this()
        {
            mpfr_set_q(ref Value, ref op.Value, rounding);
        }

        public mpfr_t(mpf_t op, mpfr_rnd_t rounding = DefaultRounding)
            : this()
        {
            mpfr_set_f(ref Value, ref op.Value, rounding);
        }

        public mpfr_t(string str, uint strbase = 10, mpfr_rnd_t rounding = DefaultRounding)
            : this()
        {
            int Success = mpfr_set_str(ref Value, str, strbase, rounding);
            if (Success != 0)
                throw new ArgumentException();
        }

        public mpfr_rnd_t Rounding { get; set; } = DefaultRounding;

        internal __mpfr_t Value;
    }
}
