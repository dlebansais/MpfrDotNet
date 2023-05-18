namespace MpfrDotNet;

using System;
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

        z.LastTernaryResult = mpfr.log(z, this, Rounding);

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

        z.LastTernaryResult = mpfr.log_ui(z, op, rounding);

        return z;
    }

    /// <summary>
    /// Gets the log2.
    /// </summary>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t Log2(mpfr_rnd_t rounding = DefaultRounding)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.log2(z, this, rounding);

        return z;
    }

    /// <summary>
    /// Gets the log10.
    /// </summary>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t Log10(mpfr_rnd_t rounding = DefaultRounding)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.log10(z, this, rounding);

        return z;
    }

    /// <summary>
    /// Gets the log1p.
    /// </summary>
    /// <param name="rounding">The rounding mode.</param>
    public mpfr_t Log1p(mpfr_rnd_t rounding = DefaultRounding)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.log1p(z, this, rounding);

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

        z.LastTernaryResult = mpfr.exp(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the exp2.
    /// </summary>
    public mpfr_t Exp2()
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.exp2(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the exp10.
    /// </summary>
    public mpfr_t Exp10()
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.exp10(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the expm1.
    /// </summary>
    public mpfr_t Expm1()
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.expm1(z, this, Rounding);

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

        z.LastTernaryResult = mpfr.pow(z, this, op, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the power by a number.
    /// </summary>
    /// <param name="op">The power operand.</param>
    public mpfr_t Pow(ulong op)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.pow_ui(z, this, op, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the power by a number.
    /// </summary>
    /// <param name="op">The power operand.</param>
    public mpfr_t Pow(long op)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.pow_si(z, this, op, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the power by a number.
    /// </summary>
    /// <param name="op">The power operand.</param>
    public mpfr_t Pow(mpz_t op)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.pow_z(z, this, op, Rounding);

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

        z.LastTernaryResult = mpfr.ui_pow_ui(z, op1, op2, rounding);

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

        z.LastTernaryResult = mpfr.ui_pow(z, op1, op2, op2.Rounding);

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

        z.LastTernaryResult = mpfr.cos(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the sine.
    /// </summary>
    public mpfr_t Sin()
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.sin(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the tangent.
    /// </summary>
    public mpfr_t Tan()
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.tan(z, this, Rounding);

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

        mpfr.sin_cos(sin, cos, op, op.Rounding);
    }

    /// <summary>
    /// Gets the secant.
    /// </summary>
    public mpfr_t Sec()
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.sec(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the cosecant.
    /// </summary>
    public mpfr_t Csc()
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.csc(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the cotangent.
    /// </summary>
    public mpfr_t Cot()
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.cot(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the arccosine.
    /// </summary>
    public mpfr_t Acos()
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.acos(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the arcsine.
    /// </summary>
    public mpfr_t Asin()
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.asin(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the arctangent.
    /// </summary>
    public mpfr_t Atan()
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.atan(z, this, Rounding);

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

        z.LastTernaryResult = mpfr.atan2(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Gets the hyperbolic cosine.
    /// </summary>
    public mpfr_t Cosh()
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.cosh(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the hyperbolic sine.
    /// </summary>
    public mpfr_t Sinh()
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.sinh(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the hyperbolic tangent.
    /// </summary>
    public mpfr_t Tanh()
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.tanh(z, this, Rounding);

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

        mpfr.sinh_cosh(sinh, cosh, op, op.Rounding);
    }

    /// <summary>
    /// Gets the hyperbolic secant.
    /// </summary>
    public mpfr_t Sech()
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.sech(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the hyperbolic cosecant.
    /// </summary>
    public mpfr_t Csch()
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.csch(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the hyperbolic tangent.
    /// </summary>
    public mpfr_t Coth()
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.coth(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the hyperbolic arccosine.
    /// </summary>
    public mpfr_t Acosh()
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.acosh(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the hyperbolic arcsine.
    /// </summary>
    public mpfr_t Asinh()
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.asinh(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the hyperbolic arctangent.
    /// </summary>
    public mpfr_t Atanh()
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.atanh(z, this, Rounding);

        return z;
    }
    #endregion

    #region other
    /// <summary>
    /// Gets the exponential integral.
    /// </summary>
    public mpfr_t EInt()
    {
        mpfr_t Result = new mpfr_t();

        Result.LastTernaryResult = mpfr.eint(Result, this, DefaultRounding);

        return Result;
    }

    /// <summary>
    /// Gets the real part of the dilogarithm.
    /// </summary>
    public mpfr_t Li2()
    {
        mpfr_t Result = new mpfr_t();

        Result.LastTernaryResult = mpfr.li2(Result, this, DefaultRounding);

        return Result;
    }

    /// <summary>
    /// Gets the result of the Gamma function.
    /// </summary>
    public mpfr_t Gamma()
    {
        mpfr_t Result = new mpfr_t();

        Result.LastTernaryResult = mpfr.gamma(Result, this, DefaultRounding);

        return Result;
    }

    /// <summary>
    /// Gets the result of the incomplete Gamma function.
    /// </summary>
    /// <param name="operand">The operand.</param>
    public mpfr_t IncompleteGamma(mpfr_t operand)
    {
        mpfr_t Result = new mpfr_t();

        Result.LastTernaryResult = mpfr.gamma_inc(Result, this, operand, DefaultRounding);

        return Result;
    }

    /// <summary>
    /// Gets the logarithm of the result of the Gamma function.
    /// </summary>
    public mpfr_t LnGamma()
    {
        mpfr_t Result = new mpfr_t();

        Result.LastTernaryResult = mpfr.lngamma(Result, this, DefaultRounding);

        return Result;
    }

    /// <summary>
    /// Gets the logarithm of the absolute value of the result of the Gamma function.
    /// </summary>
    /// <param name="sign">The sign of the result upon return.</param>
    public mpfr_t LnGammaAbs(out int sign)
    {
        mpfr_t Result = new mpfr_t();

        Result.LastTernaryResult = mpfr.lgamma(Result, out sign, this, DefaultRounding);

        return Result;
    }

    /// <summary>
    /// Gets the result of the Digamma function.
    /// </summary>
    public mpfr_t Digamma()
    {
        mpfr_t Result = new mpfr_t();

        Result.LastTernaryResult = mpfr.digamma(Result, this, DefaultRounding);

        return Result;
    }

    /// <summary>
    /// Gets the result of the Beta function.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpfr_t Beta(mpfr_t x, mpfr_t y)
    {
        mpfr_t Result = new mpfr_t();

        Result.LastTernaryResult = mpfr.beta(Result, x, y, DefaultRounding);

        return Result;
    }

    /// <summary>
    /// Gets the result of the error function.
    /// </summary>
    public mpfr_t Erf()
    {
        mpfr_t Result = new mpfr_t();

        Result.LastTernaryResult = mpfr.erf(Result, this, DefaultRounding);

        return Result;
    }

    /// <summary>
    /// Gets the result of the complementary error function.
    /// </summary>
    public mpfr_t Erfc()
    {
        mpfr_t Result = new mpfr_t();

        Result.LastTernaryResult = mpfr.erfc(Result, this, DefaultRounding);

        return Result;
    }

    /// <summary>
    /// Gets the order 0 of the first kind Bessel function.
    /// </summary>
    public mpfr_t BesselFirst0()
    {
        mpfr_t Result = new mpfr_t();

        Result.LastTernaryResult = mpfr.j0(Result, this, DefaultRounding);

        return Result;
    }

    /// <summary>
    /// Gets the order 1 of the first kind Bessel function.
    /// </summary>
    public mpfr_t BesselFirst1()
    {
        mpfr_t Result = new mpfr_t();

        Result.LastTernaryResult = mpfr.j1(Result, this, DefaultRounding);

        return Result;
    }

    /// <summary>
    /// Gets the order N of the first kind Bessel function.
    /// </summary>
    /// <param name="n">The order.</param>
    public mpfr_t BesselFirst(int n)
    {
        mpfr_t Result = new mpfr_t();

        Result.LastTernaryResult = mpfr.jn(Result, n, this, DefaultRounding);

        return Result;
    }

    /// <summary>
    /// Gets the order 0 of the second kind Bessel function.
    /// </summary>
    public mpfr_t BesselSecond0()
    {
        mpfr_t Result = new mpfr_t();

        Result.LastTernaryResult = mpfr.y0(Result, this, DefaultRounding);

        return Result;
    }

    /// <summary>
    /// Gets the order 1 of the second kind Bessel function.
    /// </summary>
    public mpfr_t BesselSecond1()
    {
        mpfr_t Result = new mpfr_t();

        Result.LastTernaryResult = mpfr.y1(Result, this, DefaultRounding);

        return Result;
    }

    /// <summary>
    /// Gets the order N of the second kind Bessel function.
    /// </summary>
    /// <param name="n">The order.</param>
    public mpfr_t BesselSecond(int n)
    {
        mpfr_t Result = new mpfr_t();

        Result.LastTernaryResult = mpfr.yn(Result, n, this, DefaultRounding);

        return Result;
    }

    /// <summary>
    /// Gets the arithmetic(geometric mean of <paramref name="x"/> and <paramref name="y"/>.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpfr_t ArithmeticGeometricMean(mpfr_t x, mpfr_t y)
    {
        mpfr_t Result = new mpfr_t();

        Result.LastTernaryResult = mpfr.agm(Result, x, y, DefaultRounding);

        return Result;
    }

    /// <summary>
    /// Gets the result of the Airy function.
    /// </summary>
    public mpfr_t Airy()
    {
        mpfr_t Result = new mpfr_t();

        Result.LastTernaryResult = mpfr.ai(Result, this, DefaultRounding);

        return Result;
    }

    /// <summary>
    /// Gets the log2.
    /// </summary>
    /// <param name="precision">The precision.</param>
    public static mpfr_t Log2(ulong precision = ulong.MaxValue)
    {
        mpfr_t Result = new mpfr_t();

        if (precision == ulong.MaxValue)
            mpfr.init2(Result, DefaultPrecision);
        else
            mpfr.init2(Result, precision);

        Result.LastTernaryResult = mpfr.const_log2(Result, DefaultRounding);

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
            mpfr.init2(Result, DefaultPrecision);
        else
            mpfr.init2(Result, precision);

        Result.LastTernaryResult = mpfr.const_pi(Result, DefaultRounding);

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
            mpfr.init2(Result, DefaultPrecision);
        else
            mpfr.init2(Result, precision);

        Result.LastTernaryResult = mpfr.const_euler(Result, DefaultRounding);

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
            mpfr.init2(Result, DefaultPrecision);
        else
            mpfr.init2(Result, precision);

        Result.LastTernaryResult = mpfr.const_catalan(Result, DefaultRounding);

        return Result;
    }
    #endregion
}
