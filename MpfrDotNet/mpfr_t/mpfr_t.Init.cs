﻿namespace MpfrDotNet
{
    using System;
    using Interop.Mpfr;
    using MpirDotNet;
    using static Interop.Mpfr.NativeMethods;

    /// <summary>
    /// Represents an arbitrary precision floating-point number.
    /// </summary>
    public partial class mpfr_t : IDisposable
    {
        /// <summary>
        /// The default rounding mode.
        /// </summary>
        public const mpfr_rnd_t DefaultRounding = mpfr_rnd_t.MPFR_RNDN;

        /// <summary>
        /// Initializes a new instance of the <see cref="mpfr_t"/> class.
        /// </summary>
        public mpfr_t()
        {
            mpfr_init2(ref Value, DefaultPrecision);
            InitCacheManagement();
        }

        /// <summary>
        /// Creates a new instance of the <see cref="mpfr_t"/> class.
        /// </summary>
        /// <param name="precision">The precision.</param>
        public static mpfr_t Create(ulong precision = ulong.MaxValue)
        {
            mpfr_t Result = new mpfr_t();

            if (precision == ulong.MaxValue)
                mpfr_init2(ref Result.Value, DefaultPrecision);
            else
                mpfr_init2(ref Result.Value, precision);

            return Result;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="mpfr_t"/> class representing infinite.
        /// </summary>
        /// <param name="sign">The sign.</param>
        public static mpfr_t Infinite(int sign = +1)
        {
            mpfr_t Result = new mpfr_t();
            mpfr_set_inf(ref Result.Value, sign);

            return Result;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="mpfr_t"/> class representing zero.
        /// </summary>
        /// <param name="sign">The sign.</param>
        public static mpfr_t Zero(int sign = +1)
        {
            mpfr_t Result = new mpfr_t();
            mpfr_set_zero(ref Result.Value, sign);

            return Result;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpfr_t"/> class.
        /// </summary>
        /// <param name="other">The other instance.</param>
        /// <param name="rounding">The rounding mode.</param>
        public mpfr_t(mpfr_t other, mpfr_rnd_t rounding = DefaultRounding)
            : this()
        {
            mpfr_set(ref Value, ref other.Value, (__mpfr_rnd_t)rounding);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpfr_t"/> class.
        /// </summary>
        /// <param name="op">The operand.</param>
        /// <param name="rounding">The rounding mode.</param>
        public mpfr_t(ulong op, mpfr_rnd_t rounding = DefaultRounding)
            : this()
        {
            mpfr_set_ui(ref Value, op, (__mpfr_rnd_t)rounding);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpfr_t"/> class.
        /// </summary>
        /// <param name="op">The operand.</param>
        /// <param name="rounding">The rounding mode.</param>
        public mpfr_t(long op, mpfr_rnd_t rounding = DefaultRounding)
            : this()
        {
            mpfr_set_si(ref Value, op, (__mpfr_rnd_t)rounding);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpfr_t"/> class.
        /// </summary>
        /// <param name="op">The operand.</param>
        /// <param name="rounding">The rounding mode.</param>
        public mpfr_t(uint op, mpfr_rnd_t rounding = DefaultRounding)
            : this()
        {
            mpfr_set_uj(ref Value, op, (__mpfr_rnd_t)rounding);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpfr_t"/> class.
        /// </summary>
        /// <param name="op">The operand.</param>
        /// <param name="rounding">The rounding mode.</param>
        public mpfr_t(int op, mpfr_rnd_t rounding = DefaultRounding)
            : this()
        {
            mpfr_set_sj(ref Value, op, (__mpfr_rnd_t)rounding);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpfr_t"/> class.
        /// </summary>
        /// <param name="op">The operand.</param>
        /// <param name="rounding">The rounding mode.</param>
        public mpfr_t(float op, mpfr_rnd_t rounding = DefaultRounding)
            : this()
        {
            mpfr_set_flt(ref Value, op, (__mpfr_rnd_t)rounding);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpfr_t"/> class.
        /// </summary>
        /// <param name="op">The operand.</param>
        /// <param name="rounding">The rounding mode.</param>
        public mpfr_t(double op, mpfr_rnd_t rounding = DefaultRounding)
            : this()
        {
            mpfr_set_d(ref Value, op, (__mpfr_rnd_t)rounding);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpfr_t"/> class.
        /// </summary>
        /// <param name="op">The operand.</param>
        /// <param name="rounding">The rounding mode.</param>
        public mpfr_t(mpz_t op, mpfr_rnd_t rounding = DefaultRounding)
            : this()
        {
            mpfr_set_z(ref Value, ref op.Value, (__mpfr_rnd_t)rounding);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpfr_t"/> class.
        /// </summary>
        /// <param name="op">The operand.</param>
        /// <param name="rounding">The rounding mode.</param>
        public mpfr_t(mpq_t op, mpfr_rnd_t rounding = DefaultRounding)
            : this()
        {
            mpfr_set_q(ref Value, ref op.Value, (__mpfr_rnd_t)rounding);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpfr_t"/> class.
        /// </summary>
        /// <param name="op">The operand.</param>
        /// <param name="rounding">The rounding mode.</param>
        public mpfr_t(mpf_t op, mpfr_rnd_t rounding = DefaultRounding)
            : this()
        {
            mpfr_set_f(ref Value, ref op.Value, (__mpfr_rnd_t)rounding);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mpfr_t"/> class.
        /// </summary>
        /// <param name="str">The string text.</param>
        /// <param name="strbase">The digit base.</param>
        /// <param name="rounding">The rounding mode.</param>
        public mpfr_t(string str, uint strbase = 10, mpfr_rnd_t rounding = DefaultRounding)
            : this()
        {
            int Success = mpfr_set_str(ref Value, str, strbase, (__mpfr_rnd_t)rounding);
            if (Success != 0)
                throw new ArgumentException();
        }

        /// <summary>
        /// Gets or sets the rounding mode.
        /// </summary>
        public mpfr_rnd_t Rounding { get; set; } = DefaultRounding;

#pragma warning disable SA1401 // Fields should be private
#pragma warning disable SA1600 // Elements should be documented
        internal __mpfr_t Value;
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore SA1600 // Elements should be documented
    }
}
