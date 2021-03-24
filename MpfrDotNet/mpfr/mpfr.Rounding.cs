namespace MpfrDotNet
{
    using System;
    using System.Runtime.InteropServices;
    using static Interop.Mpfr.NativeMethods;

    public static partial class mpfr
    {
        public static int rint(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return mpfr_rint(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
        }

        public static int ceil(mpfr_t rop, mpfr_t op)
        {
            return mpfr_ceil(ref rop.Value, ref op.Value);
        }

        public static int floor(mpfr_t rop, mpfr_t op)
        {
            return mpfr_floor(ref rop.Value, ref op.Value);
        }

        public static int round(mpfr_t rop, mpfr_t op)
        {
            return mpfr_round(ref rop.Value, ref op.Value);
        }

        public static int roundeven(mpfr_t rop, mpfr_t op)
        {
            return mpfr_roundeven(ref rop.Value, ref op.Value);
        }

        public static int trunc(mpfr_t rop, mpfr_t op)
        {
            return mpfr_trunc(ref rop.Value, ref op.Value);
        }

        public static int rint_ceil(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return mpfr_rint_ceil(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
        }

        public static int rint_floor(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return mpfr_rint_floor(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
        }

        public static int rint_round(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return mpfr_rint_round(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
        }

        public static int rint_roundeven(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return mpfr_rint_roundeven(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
        }

        public static int rint_trunc(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return mpfr_rint_trunc(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
        }

        public static int frac(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return mpfr_frac(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
        }

        public static int modf(mpfr_t iop, mpfr_t fop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return mpfr_modf(ref iop.Value, ref fop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
        }

        public static int fmod(mpfr_t r, mpfr_t x, mpfr_t y, mpfr_rnd_t rnd)
        {
            return mpfr_fmod(ref r.Value, ref x.Value, ref y.Value, (__mpfr_rnd_t)rnd);
        }

        public static int fmodquo(mpfr_t r, out long q, mpfr_t x, mpfr_t y, mpfr_rnd_t rnd)
        {
            return mpfr_fmodquo(ref r.Value, out q, ref x.Value, ref y.Value, (__mpfr_rnd_t)rnd);
        }

        public static int remainder(mpfr_t r, mpfr_t x, mpfr_t y, mpfr_rnd_t rnd)
        {
            return mpfr_remainder(ref r.Value, ref x.Value, ref y.Value, (__mpfr_rnd_t)rnd);
        }

        public static int remquo(mpfr_t r, out long q, mpfr_t x, mpfr_t y, mpfr_rnd_t rnd)
        {
            return mpfr_remquo(ref r.Value, out q, ref x.Value, ref y.Value, (__mpfr_rnd_t)rnd);
        }

        public static void set_default_rounding_mode(mpfr_rnd_t rnd)
        {
            mpfr_set_default_rounding_mode((__mpfr_rnd_t)rnd);
        }

        public static mpfr_rnd_t get_default_rounding_mode()
        {
            return (mpfr_rnd_t)mpfr_get_default_rounding_mode();
        }

        public static int prec_round(mpfr_t x, ulong prec, mpfr_rnd_t rnd)
        {
            return mpfr_prec_round(ref x.Value, prec, (__mpfr_rnd_t)rnd);
        }

        public static bool can_round(mpfr_t b, int err, mpfr_rnd_t rnd1, mpfr_rnd_t rnd2, ulong prec)
        {
            return mpfr_can_round(ref b.Value, err, (__mpfr_rnd_t)rnd1, (__mpfr_rnd_t)rnd2, prec) != 0;
        }

        public static int min_prec(mpfr_t x)
        {
            return mpfr_min_prec(ref x.Value);
        }

        public static string print_rnd_mode(mpfr_rnd_t rnd)
        {
            IntPtr Str = mpfr_print_rnd_mode((__mpfr_rnd_t)rnd);
            string Result = Marshal.PtrToStringAnsi(Str)!;

            return Result;
        }
    }
}
