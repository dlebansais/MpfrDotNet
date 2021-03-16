namespace MpfrDotNet.mpfr
{
    public static partial class mpfr
    {
        public static int get_emin()
        {
            return NativeMethods.mpfr_get_emin();
        }

        public static int get_emax()
        {
            return NativeMethods.mpfr_get_emax();
        }

        public static int set_emin(int exp)
        {
            return NativeMethods.mpfr_set_emin(exp);
        }

        public static int set_emax(int exp)
        {
            return NativeMethods.mpfr_set_emax(exp);
        }

        public static int get_emin_min()
        {
            return NativeMethods.mpfr_get_emin_min();
        }

        public static int get_emin_max()
        {
            return NativeMethods.mpfr_get_emin_max();
        }

        public static int get_emax_min()
        {
            return NativeMethods.mpfr_get_emax_min();
        }

        public static int get_emax_max()
        {
            return NativeMethods.mpfr_get_emax_max();
        }

        public static int check_range(mpfr_t x, int t, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_check_range(ref x.Value, t, rnd);
        }

        public static int subnormalize(mpfr_t x, int t, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_subnormalize(ref x.Value, t, rnd);
        }

        public static void clear_underflow()
        {
            NativeMethods.mpfr_clear_underflow();
        }

        public static void clear_overflow()
        {
            NativeMethods.mpfr_clear_overflow();
        }

        public static void clear_divby0()
        {
            NativeMethods.mpfr_clear_divby0();
        }

        public static void clear_nanflag()
        {
            NativeMethods.mpfr_clear_nanflag();
        }

        public static void clear_inexflag()
        {
            NativeMethods.mpfr_clear_inexflag();
        }

        public static void clear_erangeflag()
        {
            NativeMethods.mpfr_clear_erangeflag();
        }

        public static void clear_flags()
        {
            NativeMethods.mpfr_clear_flags();
        }

        public static void set_underflow()
        {
            NativeMethods.mpfr_set_underflow();
        }

        public static void set_overflow()
        {
            NativeMethods.mpfr_set_overflow();
        }

        public static void set_divby0()
        {
            NativeMethods.mpfr_set_divby0();
        }

        public static void set_nanflag()
        {
            NativeMethods.mpfr_set_nanflag();
        }

        public static void set_inexflag()
        {
            NativeMethods.mpfr_set_inexflag();
        }

        public static void set_erangeflag()
        {
            NativeMethods.mpfr_set_erangeflag();
        }

        public static bool underflow_p()
        {
            return NativeMethods.mpfr_underflow_p() != 0;
        }

        public static bool overflow_p()
        {
            return NativeMethods.mpfr_overflow_p() != 0;
        }

        public static bool divby0_p()
        {
            return NativeMethods.mpfr_divby0_p() != 0;
        }

        public static bool nanflag_p()
        {
            return NativeMethods.mpfr_nanflag_p() != 0;
        }

        public static bool inexflag_p()
        {
            return NativeMethods.mpfr_inexflag_p() != 0;
        }

        public static bool erangeflag_p()
        {
            return NativeMethods.mpfr_erangeflag_p() != 0;
        }

        public static void flags_clear(uint mask)
        {
            NativeMethods.mpfr_flags_clear(mask);
        }

        public static void flags_set(uint mask)
        {
            NativeMethods.mpfr_flags_set(mask);
        }

        public static uint flags_test(uint mask)
        {
            return NativeMethods.mpfr_flags_test(mask);
        }

        public static uint flags_save()
        {
            return NativeMethods.mpfr_flags_save();
        }

        public static void flags_restore(uint flags, uint mask)
        {
            NativeMethods.mpfr_flags_restore(flags, mask);
        }
    }
}
