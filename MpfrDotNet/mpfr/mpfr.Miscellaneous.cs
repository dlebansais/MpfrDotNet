namespace MpfrDotNet
{
    using System;
    using System.Runtime.InteropServices;
    using MpirDotNet;

    public static partial class mpfr
    {
        public static void nexttoward(mpfr_t x, mpfr_t y)
        {
            NativeMethods.mpfr_nexttoward(ref x.Value, ref y.Value);
        }

        public static void nextabove(mpfr_t x)
        {
            NativeMethods.mpfr_nextabove(ref x.Value);
        }

        public static void nextbelow(mpfr_t x)
        {
            NativeMethods.mpfr_nextbelow(ref x.Value);
        }

        public static int min(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_min(ref rop.Value, ref op1.Value, ref op2.Value, rnd);
        }

        public static int max(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_max(ref rop.Value, ref op1.Value, ref op2.Value, rnd);
        }

        public static int urandomb(mpfr_t rop, randstate_t state)
        {
            return NativeMethods.mpfr_urandomb(ref rop.Value, ref state.Value);
        }

        public static int urandom(mpfr_t rop, randstate_t state, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_urandom(ref rop.Value, ref state.Value, rnd);
        }

        public static int nrandom(mpfr_t rop1, randstate_t state, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_nrandom(ref rop1.Value, ref state.Value, rnd);
        }

        public static int grandom(mpfr_t rop1, mpfr_t rop2, randstate_t state, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_grandom(ref rop1.Value, ref rop2.Value, ref state.Value, rnd);
        }

        public static int erandom(mpfr_t rop1, randstate_t state, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_erandom(ref rop1.Value, ref state.Value, rnd);
        }

        public static int get_exp(mpfr_t x)
        {
            return NativeMethods.mpfr_get_exp(ref x.Value);
        }

        public static int set_exp(mpfr_t x, int e)
        {
            return NativeMethods.mpfr_set_exp(ref x.Value, e);
        }

        public static int signbit(mpfr_t op)
        {
            return NativeMethods.mpfr_signbit(ref op.Value);
        }

        public static int setsign(mpfr_t rop, mpfr_t op, int s, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_setsign(ref rop.Value, ref op.Value, s, rnd);
        }

        public static int copysign(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_copysign(ref rop.Value, ref op1.Value, ref op2.Value, rnd);
        }

        public static string get_version()
        {
            IntPtr Str = NativeMethods.mpfr_get_version();
            string Result = Marshal.PtrToStringAnsi(Str)!;

            return Result;
        }

        public static string get_patches()
        {
            IntPtr Str = NativeMethods.mpfr_get_patches();
            string Result = Marshal.PtrToStringAnsi(Str)!;

            return Result;
        }

        public static bool buildopt_tls_p()
        {
            return NativeMethods.mpfr_buildopt_tls_p() != 0;
        }

        public static bool buildopt_float128_p()
        {
            return NativeMethods.mpfr_buildopt_float128_p() != 0;
        }

        public static bool buildopt_decimal_p()
        {
            return NativeMethods.mpfr_buildopt_decimal_p() != 0;
        }

        public static bool buildopt_gmpinternals_p()
        {
            return NativeMethods.mpfr_buildopt_gmpinternals_p() != 0;
        }

        public static bool buildopt_sharedcache_p()
        {
            return NativeMethods.mpfr_buildopt_sharedcache_p() != 0;
        }

        public static string buildopt_tune_case()
        {
            IntPtr Str = NativeMethods.mpfr_buildopt_tune_case();
            string Result = Marshal.PtrToStringAnsi(Str)!;

            return Result;
        }
    }
}
