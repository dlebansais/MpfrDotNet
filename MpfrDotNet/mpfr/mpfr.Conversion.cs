namespace MpfrDotNet
{
    using System.Text;
    using Interop.Mpfr;
    using MpirDotNet;

    public static partial class mpfr
    {
        public static float get_flt(mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_get_flt(ref op.Value, rnd);
        }

        public static double get_d(mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_get_d(ref op.Value, rnd);
        }

        public static long get_si(mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_get_si(ref op.Value, rnd);
        }

        public static ulong get_ui(mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_get_ui(ref op.Value, rnd);
        }

        public static double get_d_2exp(out long exp, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_get_d_2exp(out exp, ref op.Value, rnd);
        }

        public static int frexp(out long exp, mpfr_t x, mpfr_t y, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_frexp(out exp, ref x.Value, ref y.Value, rnd);
        }

        public static int get_z_2exp(mpz_t rop, mpfr_t op)
        {
            return NativeMethods.mpfr_get_z_2exp(ref rop.Value, ref op.Value);
        }

        public static int get_z(mpz_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_get_z(ref rop.Value, ref op.Value, rnd);
        }

        public static void get_q(mpq_t rop, mpfr_t op)
        {
            NativeMethods.mpfr_get_q(ref rop.Value, ref op.Value);
        }

        public static int get_f(mpf_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_get_f(ref rop.Value, ref op.Value, rnd);
        }

        public static ulong get_str_ndigits(int b, ulong p)
        {
            return NativeMethods.mpfr_get_str_ndigits(b, p);
        }

        public static void get_str(StringBuilder str, out int expptr, int strbase, ulong n, mpfr_t op, mpfr_rnd_t rnd)
        {
            NativeMethods.mpfr_get_str(str, out expptr, strbase, n, ref op.Value, rnd);
        }

        public static bool fits_ulong_p(mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_fits_ulong_p(ref op.Value, rnd) != 0;
        }

        public static bool fits_slong_p(mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_fits_slong_p(ref op.Value, rnd) != 0;
        }

        public static bool fits_uint_p(mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_fits_uint_p(ref op.Value, rnd) != 0;
        }

        public static bool fits_sint_p(mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_fits_sint_p(ref op.Value, rnd) != 0;
        }

        public static bool fits_ushort_p(mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_fits_ushort_p(ref op.Value, rnd) != 0;
        }

        public static bool fits_sshort_p(mpfr_t op, mpfr_rnd_t rnd)
        {
            return NativeMethods.mpfr_fits_sshort_p(ref op.Value, rnd) != 0;
        }
    }
}
