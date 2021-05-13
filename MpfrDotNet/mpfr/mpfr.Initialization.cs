namespace MpfrDotNet
{
    using System;
    using static Interop.Mpfr.NativeMethods;

    /// <summary>
    /// Represents an arbitrary precision floating-point number.
    /// </summary>
    public static partial class mpfr
    {
        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="x">The value.</param>
        /// <param name="prec">The precision.</param>
        public static void init2(mpfr_t x, ulong prec)
        {
            mpfr_init2(ref x.Value, prec);
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="prec">The precision.</param>
        /// <param name="x">The values.</param>
        public static void inits2(ulong prec, params mpfr_t[] x)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="x">The value.</param>
        public static void clear(mpfr_t x)
        {
            mpfr_clear(ref x.Value);
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="x">The values.</param>
        public static void clears(params mpfr_t[] x)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="x">The value.</param>
        public static void init(mpfr_t x)
        {
            mpfr_init(ref x.Value);
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="x">The values.</param>
        public static void inits(params mpfr_t[] x)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="prec">The precision.</param>
        public static void set_default_prec(ulong prec)
        {
            mpfr_set_default_prec(prec);
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        public static ulong get_default_prec()
        {
            return mpfr_get_default_prec();
        }

        /// <summary>
        /// Gets the minimum precision.
        /// </summary>
        public static ulong PrecisionMin { get { return NativeMinPrecision; } }

        /// <summary>
        /// Gets the maximum precision.
        /// </summary>
        public static ulong PrecisionMax { get { return NativeMaxPrecision; } }

        /// <summary>
        /// Gets the default precision.
        /// </summary>
        public static ulong PrecisionDefault { get { return NativeDefaultPrecision; } }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="x">The value.</param>
        /// <param name="prec">The precision.</param>
        public static void set_prec(mpfr_t x, ulong prec)
        {
            mpfr_set_prec(ref x.Value, prec);
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="x">The value.</param>
        public static ulong get_prec(mpfr_t x)
        {
            return mpfr_get_prec(ref x.Value);
        }

        /// <summary>
        /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
        /// </summary>
        /// <param name="x">The value.</param>
        /// <param name="prec">The precision.</param>
        public static void set_prec_raw(mpfr_t x, ulong prec)
        {
            mpfr_set_prec_raw(ref x.Value, prec);
        }
    }
}
