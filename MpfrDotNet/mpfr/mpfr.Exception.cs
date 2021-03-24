namespace MpfrDotNet
{
    using static Interop.Mpfr.NativeMethods;

    public static partial class mpfr
    {
        public static int get_emin()
        {
            return mpfr_get_emin();
        }

        public static int get_emax()
        {
            return mpfr_get_emax();
        }

        public static int set_emin(int exp)
        {
            return mpfr_set_emin(exp);
        }

        public static int set_emax(int exp)
        {
            return mpfr_set_emax(exp);
        }

        public static int get_emin_min()
        {
            return mpfr_get_emin_min();
        }

        public static int get_emin_max()
        {
            return mpfr_get_emin_max();
        }

        public static int get_emax_min()
        {
            return mpfr_get_emax_min();
        }

        public static int get_emax_max()
        {
            return mpfr_get_emax_max();
        }

        public static int check_range(mpfr_t x, int t, mpfr_rnd_t rnd)
        {
            return mpfr_check_range(ref x.Value, t, (__mpfr_rnd_t)rnd);
        }

        public static int subnormalize(mpfr_t x, int t, mpfr_rnd_t rnd)
        {
            return mpfr_subnormalize(ref x.Value, t, (__mpfr_rnd_t)rnd);
        }

        public static void clear_underflow()
        {
            mpfr_clear_underflow();
        }

        public static void clear_overflow()
        {
            mpfr_clear_overflow();
        }

        public static void clear_divby0()
        {
            mpfr_clear_divby0();
        }

        public static void clear_nanflag()
        {
            mpfr_clear_nanflag();
        }

        public static void clear_inexflag()
        {
            mpfr_clear_inexflag();
        }

        public static void clear_erangeflag()
        {
            mpfr_clear_erangeflag();
        }

        public static void clear_flags()
        {
            mpfr_clear_flags();
        }

        public static void set_underflow()
        {
            mpfr_set_underflow();
        }

        public static void set_overflow()
        {
            mpfr_set_overflow();
        }

        public static void set_divby0()
        {
            mpfr_set_divby0();
        }

        public static void set_nanflag()
        {
            mpfr_set_nanflag();
        }

        public static void set_inexflag()
        {
            mpfr_set_inexflag();
        }

        public static void set_erangeflag()
        {
            mpfr_set_erangeflag();
        }

        public static bool underflow_p()
        {
            return mpfr_underflow_p() != 0;
        }

        public static bool overflow_p()
        {
            return mpfr_overflow_p() != 0;
        }

        public static bool divby0_p()
        {
            return mpfr_divby0_p() != 0;
        }

        public static bool nanflag_p()
        {
            return mpfr_nanflag_p() != 0;
        }

        public static bool inexflag_p()
        {
            return mpfr_inexflag_p() != 0;
        }

        public static bool erangeflag_p()
        {
            return mpfr_erangeflag_p() != 0;
        }

        public static void flags_clear(uint mask)
        {
            mpfr_flags_clear(mask);
        }

        public static void flags_set(uint mask)
        {
            mpfr_flags_set(mask);
        }

        public static uint flags_test(uint mask)
        {
            return mpfr_flags_test(mask);
        }

        public static uint flags_save()
        {
            return mpfr_flags_save();
        }

        public static void flags_restore(uint flags, uint mask)
        {
            mpfr_flags_restore(flags, mask);
        }
    }
}
