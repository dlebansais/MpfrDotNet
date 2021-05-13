namespace MpfrDotNet
{
    using System.Text;
    using MpirDotNet;
    using static Interop.Mpfr.NativeMethods;

    /// <summary>
    /// Represents an arbitrary precision floating-point number.
    /// </summary>
    public static partial class mpfr
    {
        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="op">The operand.</param>
        /// <param name="rnd">The rounding mode.</param>
        public static float get_flt(mpfr_t op, mpfr_rnd_t rnd)
        {
            return mpfr_get_flt(ref op.Value, (__mpfr_rnd_t)rnd);
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="op">The operand.</param>
        /// <param name="rnd">The rounding mode.</param>
        public static double get_d(mpfr_t op, mpfr_rnd_t rnd)
        {
            return mpfr_get_d(ref op.Value, (__mpfr_rnd_t)rnd);
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="op">The operand.</param>
        /// <param name="rnd">The rounding mode.</param>
        public static long get_si(mpfr_t op, mpfr_rnd_t rnd)
        {
            return mpfr_get_si(ref op.Value, (__mpfr_rnd_t)rnd);
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="op">The operand.</param>
        /// <param name="rnd">The rounding mode.</param>
        public static ulong get_ui(mpfr_t op, mpfr_rnd_t rnd)
        {
            return mpfr_get_ui(ref op.Value, (__mpfr_rnd_t)rnd);
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="exp">The exponent.</param>
        /// <param name="op">The operand.</param>
        /// <param name="rnd">The rounding mode.</param>
        public static double get_d_2exp(out long exp, mpfr_t op, mpfr_rnd_t rnd)
        {
            return mpfr_get_d_2exp(out exp, ref op.Value, (__mpfr_rnd_t)rnd);
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="exp">The exponent.</param>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        /// <param name="rnd">The rounding mode.</param>
        public static int frexp(out long exp, mpfr_t x, mpfr_t y, mpfr_rnd_t rnd)
        {
            return mpfr_frexp(out exp, ref x.Value, ref y.Value, (__mpfr_rnd_t)rnd);
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="rop">The result operand.</param>
        /// <param name="op">The operand.</param>
        public static int get_z_2exp(mpz_t rop, mpfr_t op)
        {
            return mpfr_get_z_2exp(ref rop.Value, ref op.Value);
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="rop">The result operand.</param>
        /// <param name="op">The operand.</param>
        /// <param name="rnd">The rounding mode.</param>
        public static int get_z(mpz_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return mpfr_get_z(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="rop">The result operand.</param>
        /// <param name="op">The operand.</param>
        public static void get_q(mpq_t rop, mpfr_t op)
        {
            mpfr_get_q(ref rop.Value, ref op.Value);
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="rop">The result operand.</param>
        /// <param name="op">The operand.</param>
        /// <param name="rnd">The rounding mode.</param>
        public static int get_f(mpf_t rop, mpfr_t op, mpfr_rnd_t rnd)
        {
            return mpfr_get_f(ref rop.Value, ref op.Value, (__mpfr_rnd_t)rnd);
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <param name="p">The p.</param>
        public static ulong get_str_ndigits(int b, ulong p)
        {
            return mpfr_get_str_ndigits(b, p);
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="expptr">The exponent.</param>
        /// <param name="strbase">The base.</param>
        /// <param name="n">The n.</param>
        /// <param name="op">The operand.</param>
        /// <param name="rnd">The rounding mode.</param>
        public static void get_str(StringBuilder str, out int expptr, int strbase, ulong n, mpfr_t op, mpfr_rnd_t rnd)
        {
            mpfr_get_str(str, out expptr, strbase, n, ref op.Value, (__mpfr_rnd_t)rnd);
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="op">The operand.</param>
        /// <param name="rnd">The rounding mode.</param>
        public static bool fits_ulong_p(mpfr_t op, mpfr_rnd_t rnd)
        {
            return mpfr_fits_ulong_p(ref op.Value, (__mpfr_rnd_t)rnd) != 0;
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="op">The operand.</param>
        /// <param name="rnd">The rounding mode.</param>
        public static bool fits_slong_p(mpfr_t op, mpfr_rnd_t rnd)
        {
            return mpfr_fits_slong_p(ref op.Value, (__mpfr_rnd_t)rnd) != 0;
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="op">The operand.</param>
        /// <param name="rnd">The rounding mode.</param>
        public static bool fits_uint_p(mpfr_t op, mpfr_rnd_t rnd)
        {
            return mpfr_fits_uint_p(ref op.Value, (__mpfr_rnd_t)rnd) != 0;
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="op">The operand.</param>
        /// <param name="rnd">The rounding mode.</param>
        public static bool fits_sint_p(mpfr_t op, mpfr_rnd_t rnd)
        {
            return mpfr_fits_sint_p(ref op.Value, (__mpfr_rnd_t)rnd) != 0;
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="op">The operand.</param>
        /// <param name="rnd">The rounding mode.</param>
        public static bool fits_ushort_p(mpfr_t op, mpfr_rnd_t rnd)
        {
            return mpfr_fits_ushort_p(ref op.Value, (__mpfr_rnd_t)rnd) != 0;
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="op">The operand.</param>
        /// <param name="rnd">The rounding mode.</param>
        public static bool fits_sshort_p(mpfr_t op, mpfr_rnd_t rnd)
        {
            return mpfr_fits_sshort_p(ref op.Value, (__mpfr_rnd_t)rnd) != 0;
        }
    }
}
