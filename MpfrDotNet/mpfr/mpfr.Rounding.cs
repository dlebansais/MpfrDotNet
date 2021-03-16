namespace MpfrDotNet.mpfr
{
    using System;
    using System.Runtime.InteropServices;

    public static partial class mpfr
    {
        public static int rint(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_rint(ref rop.Value, ref op.Value, rnd);
        }

        public static int ceil(mpfr_t rop, mpfr_t op)
        {
            return NativeMethods.mpfr_ceil(ref rop.Value, ref op.Value);
        }

        public static int floor(mpfr_t rop, mpfr_t op)
        {
            return NativeMethods.mpfr_floor(ref rop.Value, ref op.Value);
        }

        public static int round(mpfr_t rop, mpfr_t op)
        {
            return NativeMethods.mpfr_round(ref rop.Value, ref op.Value);
        }

        public static int roundeven(mpfr_t rop, mpfr_t op)
        {
            return NativeMethods.mpfr_roundeven(ref rop.Value, ref op.Value);
        }

        public static int trunc(mpfr_t rop, mpfr_t op)
        {
            return NativeMethods.mpfr_trunc(ref rop.Value, ref op.Value);
        }

        public static int rint_ceil(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_rint_ceil(ref rop.Value, ref op.Value, rnd);
        }

        public static int rint_floor(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_rint_floor(ref rop.Value, ref op.Value, rnd);
        }

        public static int rint_round(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_rint_round(ref rop.Value, ref op.Value, rnd);
        }

        public static int rint_roundeven(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_rint_roundeven(ref rop.Value, ref op.Value, rnd);
        }

        public static int rint_trunc(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_rint_trunc(ref rop.Value, ref op.Value, rnd);
        }

        public static int frac(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_frac(ref rop.Value, ref op.Value, rnd);
        }

        public static int modf(mpfr_t iop, mpfr_t fop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_modf(ref iop.Value, ref fop.Value, ref op.Value, rnd);
        }

        public static int fmod(mpfr_t r, mpfr_t x, mpfr_t y, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_fmod(ref r.Value, ref x.Value, ref y.Value, rnd);
        }

        public static int fmodquo(mpfr_t r, out long q, mpfr_t x, mpfr_t y, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_fmodquo(ref r.Value, out q, ref x.Value, ref y.Value, rnd);
        }

        public static int remainder(mpfr_t r, mpfr_t x, mpfr_t y, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_remainder(ref r.Value, ref x.Value, ref y.Value, rnd);
        }

        public static int remquo(mpfr_t r, out long q, mpfr_t x, mpfr_t y, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_remquo(ref r.Value, out q, ref x.Value, ref y.Value, rnd);
        }

        public static void set_default_rounding_mode(mpfr_rnd_t rnd)
        {
            NativeMethods.mpfr_set_default_rounding_mode(rnd);
        }

        public static mpfr_rnd_t get_default_rounding_mode()
        {
            return NativeMethods.mpfr_get_default_rounding_mode();
        }

        public static int prec_round(mpfr_t x, ulong prec, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_prec_round(ref x.Value, prec, rnd);
        }

        public static bool can_round(mpfr_t b, int err, mpfr_rnd_t rnd1, mpfr_rnd_t rnd2, ulong prec)
        {
            return NativeMethods.mpfr_can_round(ref b.Value, err, rnd1, rnd2, prec) != 0;
        }

        public static int min_prec(mpfr_t x)
        {
            return NativeMethods.mpfr_min_prec(ref x.Value);
        }

        public static string print_rnd_mode(mpfr_rnd_t rnd)
        {
            IntPtr Str = NativeMethods.mpfr_print_rnd_mode(rnd);
            string Result = Marshal.PtrToStringAnsi(Str);

            return Result;
        }
    }
}
