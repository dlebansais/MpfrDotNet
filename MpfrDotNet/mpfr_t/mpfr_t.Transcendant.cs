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
        #region Log
        /// <summary>
        /// Gets the log.
        /// </summary>
        public mpfr_t Log()
        {
            mpfr_t z = new();

            mpfr_log(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

            return z;
        }

        /// <summary>
        /// Gets the log of the operand.
        /// </summary>
        /// <param name="op">The operand.</param>
        /// <param name="rounding">The rounding mode.</param>
        public static mpfr_t Log(uint op, mpfr_rnd_t rounding = DefaultRounding)
        {
            mpfr_t z = new();

            mpfr_log_ui(ref z.Value, op, (__mpfr_rnd_t)rounding);

            return z;
        }

        /// <summary>
        /// Gets the log2.
        /// </summary>
        /// <param name="rounding">The rounding mode.</param>
        public mpfr_t Log2(mpfr_rnd_t rounding = DefaultRounding)
        {
            mpfr_t z = new();

            mpfr_log2(ref z.Value, ref Value, (__mpfr_rnd_t)rounding);

            return z;
        }

        /// <summary>
        /// Gets the log10.
        /// </summary>
        /// <param name="rounding">The rounding mode.</param>
        public mpfr_t Log10(mpfr_rnd_t rounding = DefaultRounding)
        {
            mpfr_t z = new();

            mpfr_log10(ref z.Value, ref Value, (__mpfr_rnd_t)rounding);

            return z;
        }

        /// <summary>
        /// Gets the log1p.
        /// </summary>
        /// <param name="rounding">The rounding mode.</param>
        public mpfr_t Log1p(mpfr_rnd_t rounding = DefaultRounding)
        {
            mpfr_t z = new();

            mpfr_log1p(ref z.Value, ref Value, (__mpfr_rnd_t)rounding);

            return z;
        }
        #endregion

        #region Exp
        /// <summary>
        /// Gets the exponential.
        /// </summary>
        public mpfr_t Exp()
        {
            mpfr_t z = new();

            mpfr_exp(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

            return z;
        }

        /// <summary>
        /// Gets the exp2.
        /// </summary>
        public mpfr_t Exp2()
        {
            mpfr_t z = new();

            mpfr_exp2(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

            return z;
        }

        /// <summary>
        /// Gets the exp10.
        /// </summary>
        public mpfr_t Exp10()
        {
            mpfr_t z = new();

            mpfr_exp10(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

            return z;
        }

        /// <summary>
        /// Gets the expm1.
        /// </summary>
        public mpfr_t Expm1()
        {
            mpfr_t z = new();

            mpfr_expm1(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

            return z;
        }
        #endregion

        #region Pow
        /// <summary>
        /// Gets the power by a number.
        /// </summary>
        /// <param name="op">The power operand.</param>
        public mpfr_t Pow(mpfr_t op)
        {
            mpfr_t z = new();

            mpfr_pow(ref z.Value, ref Value, ref op.Value, (__mpfr_rnd_t)Rounding);

            return z;
        }

        /// <summary>
        /// Gets the power by a number.
        /// </summary>
        /// <param name="op">The power operand.</param>
        public mpfr_t Pow(ulong op)
        {
            mpfr_t z = new();

            mpfr_pow_ui(ref z.Value, ref Value, op, (__mpfr_rnd_t)Rounding);

            return z;
        }

        /// <summary>
        /// Gets the power by a number.
        /// </summary>
        /// <param name="op">The power operand.</param>
        public mpfr_t Pow(long op)
        {
            mpfr_t z = new();

            mpfr_pow_si(ref z.Value, ref Value, op, (__mpfr_rnd_t)Rounding);

            return z;
        }

        /// <summary>
        /// Gets the power by a number.
        /// </summary>
        /// <param name="op">The power operand.</param>
        public mpfr_t Pow(mpz_t op)
        {
            mpfr_t z = new();

            mpfr_pow_z(ref z.Value, ref Value, ref op.Value, (__mpfr_rnd_t)Rounding);

            return z;
        }

        /// <summary>
        /// Gets a number at the power of another number.
        /// </summary>
        /// <param name="op1">The first operand.</param>
        /// <param name="op2">The second operand.</param>
        /// <param name="rounding">The rounding mode.</param>
        public static mpfr_t Pow(ulong op1, ulong op2, mpfr_rnd_t rounding = DefaultRounding)
        {
            mpfr_t z = new();

            mpfr_ui_pow_ui(ref z.Value, op1, op2, (__mpfr_rnd_t)rounding);

            return z;
        }

        /// <summary>
        /// Gets a number at the power of another number.
        /// </summary>
        /// <param name="op1">The first operand.</param>
        /// <param name="op2">The second operand.</param>
        public static mpfr_t Pow(ulong op1, mpfr_t op2)
        {
            mpfr_t z = new();

            mpfr_ui_pow(ref z.Value, op1, ref op2.Value, (__mpfr_rnd_t)op2.Rounding);

            return z;
        }
        #endregion

        #region Trigonometric
        /// <summary>
        /// Gets the cosine.
        /// </summary>
        public mpfr_t Cos()
        {
            mpfr_t z = new();

            mpfr_cos(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

            return z;
        }

        /// <summary>
        /// Gets the sine.
        /// </summary>
        public mpfr_t Sin()
        {
            mpfr_t z = new();

            mpfr_sin(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

            return z;
        }

        /// <summary>
        /// Gets the tangent.
        /// </summary>
        public mpfr_t Tan()
        {
            mpfr_t z = new();

            mpfr_tan(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

            return z;
        }

        /// <summary>
        /// Gets the sine and cosine of an operand.
        /// </summary>
        /// <param name="op">The operand.</param>
        /// <param name="sin">The sine.</param>
        /// <param name="cos">The cosine.</param>
        public static void SinCos(mpfr_t op, out mpfr_t sin, out mpfr_t cos)
        {
            sin = new();
            cos = new();

            mpfr_sin_cos(ref sin.Value, ref cos.Value, ref op.Value, (__mpfr_rnd_t)op.Rounding);
        }

        /// <summary>
        /// Gets the secant.
        /// </summary>
        public mpfr_t Sec()
        {
            mpfr_t z = new();

            mpfr_sec(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

            return z;
        }

        /// <summary>
        /// Gets the cosecant.
        /// </summary>
        public mpfr_t Csc()
        {
            mpfr_t z = new();

            mpfr_csc(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

            return z;
        }

        /// <summary>
        /// Gets the cotangent.
        /// </summary>
        public mpfr_t Cot()
        {
            mpfr_t z = new();

            mpfr_cot(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

            return z;
        }

        /// <summary>
        /// Gets the arccosine.
        /// </summary>
        public mpfr_t Acos()
        {
            mpfr_t z = new();

            mpfr_acos(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

            return z;
        }

        /// <summary>
        /// Gets the arcsine.
        /// </summary>
        public mpfr_t Asin()
        {
            mpfr_t z = new();

            mpfr_asin(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

            return z;
        }

        /// <summary>
        /// Gets the arctangent.
        /// </summary>
        public mpfr_t Atan()
        {
            mpfr_t z = new();

            mpfr_atan(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

            return z;
        }

        /// <summary>
        /// Gets the atan2 of two operands.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        public static mpfr_t Atan2(mpfr_t x, mpfr_t y)
        {
            mpfr_t z = new();

            mpfr_atan2(ref z.Value, ref x.Value, ref y.Value, (__mpfr_rnd_t)x.Rounding);

            return z;
        }

        /// <summary>
        /// Gets the hyperbolic cosine.
        /// </summary>
        public mpfr_t Cosh()
        {
            mpfr_t z = new();

            mpfr_cosh(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

            return z;
        }

        /// <summary>
        /// Gets the hyperbolic sine.
        /// </summary>
        public mpfr_t Sinh()
        {
            mpfr_t z = new();

            mpfr_sinh(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

            return z;
        }

        /// <summary>
        /// Gets the hyperbolic tangent.
        /// </summary>
        public mpfr_t Tanh()
        {
            mpfr_t z = new();

            mpfr_tanh(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

            return z;
        }

        /// <summary>
        /// Gets the hyperbolic sine and cosine of an operand.
        /// </summary>
        /// <param name="op">The operand.</param>
        /// <param name="sinh">The hyperbolic sine.</param>
        /// <param name="cosh">The hyperbolic cosine.</param>
        public static void SinhCosh(mpfr_t op, out mpfr_t sinh, out mpfr_t cosh)
        {
            sinh = new();
            cosh = new();

            mpfr_sinh_cosh(ref sinh.Value, ref cosh.Value, ref op.Value, (__mpfr_rnd_t)op.Rounding);
        }

        /// <summary>
        /// Gets the hyperbolic secant.
        /// </summary>
        public mpfr_t Sech()
        {
            mpfr_t z = new();

            mpfr_sech(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

            return z;
        }

        /// <summary>
        /// Gets the hyperbolic cosecant.
        /// </summary>
        public mpfr_t Csch()
        {
            mpfr_t z = new();

            mpfr_csch(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

            return z;
        }

        /// <summary>
        /// Gets the hyperbolic tangent.
        /// </summary>
        public mpfr_t Coth()
        {
            mpfr_t z = new();

            mpfr_coth(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

            return z;
        }

        /// <summary>
        /// Gets the hyperbolic arccosine.
        /// </summary>
        public mpfr_t Acosh()
        {
            mpfr_t z = new();

            mpfr_acosh(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

            return z;
        }

        /// <summary>
        /// Gets the hyperbolic arcsine.
        /// </summary>
        public mpfr_t Asinh()
        {
            mpfr_t z = new();

            mpfr_asinh(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

            return z;
        }

        /// <summary>
        /// Gets the hyperbolic arctangent.
        /// </summary>
        public mpfr_t Atanh()
        {
            mpfr_t z = new();

            mpfr_atanh(ref z.Value, ref Value, (__mpfr_rnd_t)Rounding);

            return z;
        }
        #endregion

        #region other
        /// <summary>
        /// Gets the log2.
        /// </summary>
        /// <param name="precision">The precision.</param>
        public static mpfr_t Log2(ulong precision = ulong.MaxValue)
        {
            mpfr_t Result = new mpfr_t();

            if (precision == ulong.MaxValue)
                mpfr_init2(ref Result.Value, DefaultPrecision);
            else
                mpfr_init2(ref Result.Value, precision);

            mpfr_const_log2(ref Result.Value, (__mpfr_rnd_t)DefaultRounding);

            return Result;
        }

        /// <summary>
        /// Gets π.
        /// </summary>
        /// <param name="precision">The precision.</param>
        public static mpfr_t Pi(ulong precision = ulong.MaxValue)
        {
            mpfr_t Result = new mpfr_t();

            if (precision == ulong.MaxValue)
                mpfr_init2(ref Result.Value, DefaultPrecision);
            else
                mpfr_init2(ref Result.Value, precision);

            mpfr_const_pi(ref Result.Value, (__mpfr_rnd_t)DefaultRounding);

            return Result;
        }

        /// <summary>
        /// Gets e.
        /// </summary>
        /// <param name="precision">The precision.</param>
        public static mpfr_t Euler(ulong precision = ulong.MaxValue)
        {
            mpfr_t Result = new mpfr_t();

            if (precision == ulong.MaxValue)
                mpfr_init2(ref Result.Value, DefaultPrecision);
            else
                mpfr_init2(ref Result.Value, precision);

            mpfr_const_euler(ref Result.Value, (__mpfr_rnd_t)DefaultRounding);

            return Result;
        }

        /// <summary>
        /// Gets the Catalan constant.
        /// </summary>
        /// <param name="precision">The precision.</param>
        public static mpfr_t Catalan(ulong precision = ulong.MaxValue)
        {
            mpfr_t Result = new mpfr_t();

            if (precision == ulong.MaxValue)
                mpfr_init2(ref Result.Value, DefaultPrecision);
            else
                mpfr_init2(ref Result.Value, precision);

            mpfr_const_catalan(ref Result.Value, (__mpfr_rnd_t)DefaultRounding);

            return Result;
        }
        #endregion
    }
}
