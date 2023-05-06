namespace Interop.Mpfr;

using System;
using System.Runtime.InteropServices;

#pragma warning disable SA1601 // Partial elements should be documented
#pragma warning disable SA1600 // Elements should be documented
internal static partial class NativeMethods
{
    [StructLayout(LayoutKind.Sequential)]
    public struct __mpfr_t
    {
        public long Precision;
        public int Sign;
        public long Exponent;
        public IntPtr Limbs;
    }

    public enum __mpfr_rnd_t
    {
        /// <summary>
        /// Round to nearest, with ties away from zero (mpfr_round).
        /// </summary>
        MPFR_RNDNA = -1,

        /// <summary>
        /// Round to nearest, with ties to even.
        /// </summary>
        MPFR_RNDN = 0,

        /// <summary>
        /// Round toward zero.
        /// </summary>
        MPFR_RNDZ,

        /// <summary>
        /// Round toward +Inf.
        /// </summary>
        MPFR_RNDU,

        /// <summary>
        /// Round toward -Inf.
        /// </summary>
        MPFR_RNDD,

        /// <summary>
        /// Round away from zero.
        /// </summary>
        MPFR_RNDA,

        /// <summary>
        /// Faithful rounding.
        /// </summary>
        MPFR_RNDF,
    }
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented

