namespace MpfrDotNet;

using System;
using MpirDotNet;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public partial class mpfr_t : IDisposable
{
    #region Log
    /// <summary>
    /// Gets the log.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Log()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.log(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the log of the operand.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public static mpfr_t Log(uint op, mpfr_rnd_t rounding = DefaultRounding)
    {
        _ = mpfr.CheckRounding(rounding, nameof(rounding));

        mpfr_t z = new();

        z.LastTernaryResult = mpfr.log_ui(z, op, rounding);

        return z;
    }

    /// <summary>
    /// Gets the log2.
    /// </summary>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public mpfr_t Log2(mpfr_rnd_t rounding = DefaultRounding)
    {
        ThrowIfDisposed(this);

        _ = mpfr.CheckRounding(rounding, nameof(rounding));

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.log2(z, this, rounding);

        return z;
    }

    /// <summary>
    /// Gets the log10.
    /// </summary>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public mpfr_t Log10(mpfr_rnd_t rounding = DefaultRounding)
    {
        ThrowIfDisposed(this);

        _ = mpfr.CheckRounding(rounding, nameof(rounding));

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.log10(z, this, rounding);

        return z;
    }

    /// <summary>
    /// Gets log(1 + x).
    /// </summary>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public mpfr_t Log1p(mpfr_rnd_t rounding = DefaultRounding)
    {
        ThrowIfDisposed(this);

        _ = mpfr.CheckRounding(rounding, nameof(rounding));

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.log1p(z, this, rounding);

        return z;
    }

    /// <summary>
    /// Gets log2(1 + x).
    /// </summary>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public mpfr_t Log2p1(mpfr_rnd_t rounding = DefaultRounding)
    {
        ThrowIfDisposed(this);

        _ = mpfr.CheckRounding(rounding, nameof(rounding));

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.log2p1(z, this, rounding);

        return z;
    }

    /// <summary>
    /// Gets log10(1 + x).
    /// </summary>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public mpfr_t Log10p1(mpfr_rnd_t rounding = DefaultRounding)
    {
        ThrowIfDisposed(this);

        _ = mpfr.CheckRounding(rounding, nameof(rounding));

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.log10p1(z, this, rounding);

        return z;
    }
    #endregion

    #region Exp
    /// <summary>
    /// Gets the exponential.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Exp()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.exp(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the exp2.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Exp2()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.exp2(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the exp10.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Exp10()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.exp10(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets exp(x) - 1.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Expm1()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.expm1(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets 2^x - 1.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Exp2m1()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.exp2m1(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets 10^x - 1.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Exp10m1()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.exp10m1(z, this, Rounding);

        return z;
    }
    #endregion

    #region Pow
    /// <summary>
    /// Gets the power by a number.
    /// </summary>
    /// <param name="op">The power operand.</param>
    /// <exception cref="ObjectDisposedException">This number or <paramref name="op"/> is disposed.</exception>
    public mpfr_t Pow(mpfr_t op)
    {
        ThrowIfDisposed(this);
        ThrowIfDisposed(op);

        mpfr_t z = CreateResult(this, op);

        z.LastTernaryResult = mpfr.pow(z, this, op, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the power by a number.
    /// </summary>
    /// <param name="op">The power operand.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Pow(ulong op)
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.pow_ui(z, this, op, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the power by a number.
    /// </summary>
    /// <param name="op">The power operand.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Pow(long op)
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.pow_si(z, this, op, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the power by a number.
    /// </summary>
    /// <param name="op">The power operand.</param>
    /// <exception cref="ObjectDisposedException">This number or <paramref name="op"/> is disposed.</exception>
    public mpfr_t Pow(mpz_t op)
    {
        ThrowIfDisposed(this);
        mpz_t.ThrowIfDisposed(op);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.pow_z(z, this, op, Rounding);

        return z;
    }

    /// <summary>
    /// Gets a number at the power of another number.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public static mpfr_t Pow(ulong op1, ulong op2, mpfr_rnd_t rounding = DefaultRounding)
    {
        _ = mpfr.CheckRounding(rounding, nameof(rounding));

        mpfr_t z = new();

        z.LastTernaryResult = mpfr.ui_pow_ui(z, op1, op2, rounding);

        return z;
    }

    /// <summary>
    /// Gets a number at the power of another number.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="op2"/> is disposed.</exception>
    public static mpfr_t Pow(ulong op1, mpfr_t op2)
    {
        ThrowIfDisposed(op2);

        mpfr_t z = CreateResult(op2);

        z.LastTernaryResult = mpfr.ui_pow(z, op1, op2, op2.Rounding);

        return z;
    }

    /// <summary>
    /// Gets exp(y*log(x)).
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public static mpfr_t Powr(mpfr_t x, mpfr_t y, mpfr_rnd_t rounding = DefaultRounding)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        _ = mpfr.CheckRounding(rounding, nameof(rounding));

        mpfr_t z = CreateResult(x, y);

        z.LastTernaryResult = mpfr.powr(z, x, y, rounding);

        return z;
    }
    #endregion

    #region Trigonometric
    /// <summary>
    /// Gets the cosine.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Cos()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.cos(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the sine.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Sin()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.sin(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the tangent.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Tan()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.tan(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the sine and cosine of an operand.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="sin">The sine.</param>
    /// <param name="cos">The cosine.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="op"/> is disposed.</exception>
    public static void SinCos(mpfr_t op, out mpfr_t sin, out mpfr_t cos)
    {
        ThrowIfDisposed(op);

        sin = CreateResult(op);
        cos = CreateResult(op);

        int Ternary = mpfr.sin_cos(sin, cos, op, op.Rounding);
        sin.LastTernaryResult = DecodeTernary(Ternary);
        cos.LastTernaryResult = DecodeTernary(Ternary >> 2);
    }

    /// <summary>
    /// Gets the secant.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Sec()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.sec(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the cosecant.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Csc()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.csc(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the cotangent.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Cot()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.cot(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the arccosine.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Acos()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.acos(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the arcsine.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Asin()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.asin(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the arctangent.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Atan()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.atan(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the arc-tangent of y / x, using the signs of both operands to find the quadrant, like <see cref="Math.Atan2(double, double)"/>.
    /// </summary>
    /// <param name="y">The numerator, the y coordinate.</param>
    /// <param name="x">The denominator, the x coordinate.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> or <paramref name="x"/> is disposed.</exception>
    public static mpfr_t Atan2(mpfr_t y, mpfr_t x)
    {
        ThrowIfDisposed(y);
        ThrowIfDisposed(x);

        mpfr_t z = CreateResult(y, x);

        z.LastTernaryResult = mpfr.atan2(z, y, x, y.Rounding);

        return z;
    }

    /// <summary>
    /// Gets the hyperbolic cosine.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Cosh()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.cosh(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the hyperbolic sine.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Sinh()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.sinh(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the hyperbolic tangent.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Tanh()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.tanh(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the hyperbolic sine and cosine of an operand.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="sinh">The hyperbolic sine.</param>
    /// <param name="cosh">The hyperbolic cosine.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="op"/> is disposed.</exception>
    public static void SinhCosh(mpfr_t op, out mpfr_t sinh, out mpfr_t cosh)
    {
        ThrowIfDisposed(op);

        sinh = CreateResult(op);
        cosh = CreateResult(op);

        int Ternary = mpfr.sinh_cosh(sinh, cosh, op, op.Rounding);
        sinh.LastTernaryResult = DecodeTernary(Ternary);
        cosh.LastTernaryResult = DecodeTernary(Ternary >> 2);
    }

    /// <summary>
    /// Gets the hyperbolic secant.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Sech()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.sech(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the hyperbolic cosecant.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Csch()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.csch(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the hyperbolic tangent.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Coth()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.coth(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the hyperbolic arccosine.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Acosh()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.acosh(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the hyperbolic arcsine.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Asinh()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.asinh(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the hyperbolic arctangent.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Atanh()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.atanh(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets cos(2*pi*x/u).
    /// </summary>
    /// <param name="u">The operand.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Cos(ulong u)
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.cosu(z, this, u, Rounding);

        return z;
    }

    /// <summary>
    /// Gets sin(2*pi*x/u).
    /// </summary>
    /// <param name="u">The operand.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Sin(ulong u)
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.sinu(z, this, u, Rounding);

        return z;
    }

    /// <summary>
    /// Gets tan(2*pi*x/u).
    /// </summary>
    /// <param name="u">The operand.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Tan(ulong u)
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.tanu(z, this, u, Rounding);

        return z;
    }

    /// <summary>
    /// Gets acos(x)*u/(2*pi).
    /// </summary>
    /// <param name="u">The operand.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Acos(ulong u)
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.acosu(z, this, u, Rounding);

        return z;
    }

    /// <summary>
    /// Gets asin(x)*u/(2*pi).
    /// </summary>
    /// <param name="u">The operand.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Asin(ulong u)
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.asinu(z, this, u, Rounding);

        return z;
    }

    /// <summary>
    /// Gets atan(x)*u/(2*pi).
    /// </summary>
    /// <param name="u">The operand.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Atan(ulong u)
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.atanu(z, this, u, Rounding);

        return z;
    }

    /// <summary>
    /// Gets atan2(y, x)*u/(2*pi).
    /// </summary>
    /// <param name="y">The numerator, the y coordinate.</param>
    /// <param name="x">The denominator, the x coordinate.</param>
    /// <param name="u">The third operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> or <paramref name="x"/> is disposed.</exception>
    public static mpfr_t Atan2(mpfr_t y, mpfr_t x, ulong u)
    {
        ThrowIfDisposed(y);
        ThrowIfDisposed(x);

        mpfr_t z = CreateResult(y, x);

        z.LastTernaryResult = mpfr.atan2u(z, y, x, u, y.Rounding);

        return z;
    }

    /// <summary>
    /// Gets cos(pi*x).
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t CosPi()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.cospi(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets sin(pi*x).
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t SinPi()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.sinpi(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets tan(pi*x).
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t TanPi()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.tanpi(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets acos(x)/pi.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t AcosPi()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.acospi(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets asin(x)/pi.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t AsinPi()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.asinpi(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets atan(x)/pi.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t AtanPi()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.atanpi(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets atan2(y, x)/pi.
    /// </summary>
    /// <param name="y">The numerator, the y coordinate.</param>
    /// <param name="x">The denominator, the x coordinate.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> or <paramref name="x"/> is disposed.</exception>
    public static mpfr_t Atan2Pi(mpfr_t y, mpfr_t x)
    {
        ThrowIfDisposed(y);
        ThrowIfDisposed(x);

        mpfr_t z = CreateResult(y, x);

        z.LastTernaryResult = mpfr.atan2pi(z, y, x, y.Rounding);

        return z;
    }
    #endregion

    #region Other
    /// <summary>
    /// Gets the exponential integral.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t EInt()
    {
        ThrowIfDisposed(this);

        mpfr_t Result = CreateResult(this);

        Result.LastTernaryResult = mpfr.eint(Result, this, Rounding);

        return Result;
    }

    /// <summary>
    /// Gets the real part of the dilogarithm.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Li2()
    {
        ThrowIfDisposed(this);

        mpfr_t Result = CreateResult(this);

        Result.LastTernaryResult = mpfr.li2(Result, this, Rounding);

        return Result;
    }

    /// <summary>
    /// Gets the result of the Gamma function.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Gamma()
    {
        ThrowIfDisposed(this);

        mpfr_t Result = CreateResult(this);

        Result.LastTernaryResult = mpfr.gamma(Result, this, Rounding);

        return Result;
    }

    /// <summary>
    /// Gets the result of the incomplete Gamma function.
    /// </summary>
    /// <param name="operand">The operand.</param>
    /// <exception cref="ObjectDisposedException">This number or <paramref name="operand"/> is disposed.</exception>
    public mpfr_t IncompleteGamma(mpfr_t operand)
    {
        ThrowIfDisposed(this);
        ThrowIfDisposed(operand);

        mpfr_t Result = CreateResult(this, operand);

        Result.LastTernaryResult = mpfr.gamma_inc(Result, this, operand, Rounding);

        return Result;
    }

    /// <summary>
    /// Gets the logarithm of the result of the Gamma function.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t LnGamma()
    {
        ThrowIfDisposed(this);

        mpfr_t Result = CreateResult(this);

        Result.LastTernaryResult = mpfr.lngamma(Result, this, Rounding);

        return Result;
    }

    /// <summary>
    /// Gets the logarithm of the absolute value of the result of the Gamma function.
    /// </summary>
    /// <param name="sign">The sign of the result upon return.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t LnGammaAbs(out int sign)
    {
        ThrowIfDisposed(this);

        mpfr_t Result = CreateResult(this);

        Result.LastTernaryResult = mpfr.lgamma(Result, out sign, this, Rounding);

        return Result;
    }

    /// <summary>
    /// Gets the result of the Digamma function.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Digamma()
    {
        ThrowIfDisposed(this);

        mpfr_t Result = CreateResult(this);

        Result.LastTernaryResult = mpfr.digamma(Result, this, Rounding);

        return Result;
    }

    /// <summary>
    /// Gets the result of the Beta function.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static mpfr_t Beta(mpfr_t x, mpfr_t y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpfr_t Result = CreateResult(x, y);

        Result.LastTernaryResult = mpfr.beta(Result, x, y, x.Rounding);

        return Result;
    }

    /// <summary>
    /// Gets the result of the error function.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Erf()
    {
        ThrowIfDisposed(this);

        mpfr_t Result = CreateResult(this);

        Result.LastTernaryResult = mpfr.erf(Result, this, Rounding);

        return Result;
    }

    /// <summary>
    /// Gets the result of the complementary error function.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Erfc()
    {
        ThrowIfDisposed(this);

        mpfr_t Result = CreateResult(this);

        Result.LastTernaryResult = mpfr.erfc(Result, this, Rounding);

        return Result;
    }

    /// <summary>
    /// Gets the order 0 of the first kind Bessel function.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t BesselFirst0()
    {
        ThrowIfDisposed(this);

        mpfr_t Result = CreateResult(this);

        Result.LastTernaryResult = mpfr.j0(Result, this, Rounding);

        return Result;
    }

    /// <summary>
    /// Gets the order 1 of the first kind Bessel function.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t BesselFirst1()
    {
        ThrowIfDisposed(this);

        mpfr_t Result = CreateResult(this);

        Result.LastTernaryResult = mpfr.j1(Result, this, Rounding);

        return Result;
    }

    /// <summary>
    /// Gets the order N of the first kind Bessel function.
    /// </summary>
    /// <param name="n">The order.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t BesselFirst(int n)
    {
        ThrowIfDisposed(this);

        mpfr_t Result = CreateResult(this);

        Result.LastTernaryResult = mpfr.jn(Result, n, this, Rounding);

        return Result;
    }

    /// <summary>
    /// Gets the order 0 of the second kind Bessel function.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t BesselSecond0()
    {
        ThrowIfDisposed(this);

        mpfr_t Result = CreateResult(this);

        Result.LastTernaryResult = mpfr.y0(Result, this, Rounding);

        return Result;
    }

    /// <summary>
    /// Gets the order 1 of the second kind Bessel function.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t BesselSecond1()
    {
        ThrowIfDisposed(this);

        mpfr_t Result = CreateResult(this);

        Result.LastTernaryResult = mpfr.y1(Result, this, Rounding);

        return Result;
    }

    /// <summary>
    /// Gets the order N of the second kind Bessel function.
    /// </summary>
    /// <param name="n">The order.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t BesselSecond(int n)
    {
        ThrowIfDisposed(this);

        mpfr_t Result = CreateResult(this);

        Result.LastTernaryResult = mpfr.yn(Result, n, this, Rounding);

        return Result;
    }

    /// <summary>
    /// Gets the arithmetic(geometric mean of <paramref name="x"/> and <paramref name="y"/>.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static mpfr_t ArithmeticGeometricMean(mpfr_t x, mpfr_t y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpfr_t Result = CreateResult(x, y);

        Result.LastTernaryResult = mpfr.agm(Result, x, y, x.Rounding);

        return Result;
    }

    /// <summary>
    /// Gets the result of the Airy function.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    /// <exception cref="OverflowException">The working precision that MPFR needs for this number exceeds its maximum precision: for a negative number below about -1.7e6, or a positive number just below the underflow threshold of about 1.08e6, at usual precisions on Windows, where MPFR would abort.</exception>
    public mpfr_t Airy()
    {
        ThrowIfDisposed(this);

        mpfr_t Result = CreateResult(this);

        Result.LastTernaryResult = mpfr.ai(Result, this, Rounding);

        return Result;
    }

    /// <summary>
    /// Gets the log2.
    /// </summary>
    /// <param name="precision">The precision, or <see cref="ulong.MaxValue"/> for <see cref="DefaultPrecision"/>.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="precision"/> is not a precision supported by MPFR.</exception>
    public static mpfr_t Log2(ulong precision = ulong.MaxValue)
    {
        mpfr_t Result = CreateWithPrecision(precision, nameof(precision));

        Result.LastTernaryResult = mpfr.const_log2(Result, DefaultRounding);

        return Result;
    }

    /// <summary>
    /// Gets π.
    /// </summary>
    /// <param name="precision">The precision, or <see cref="ulong.MaxValue"/> for <see cref="DefaultPrecision"/>.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="precision"/> is not a precision supported by MPFR.</exception>
    public static mpfr_t Pi(ulong precision = ulong.MaxValue)
    {
        mpfr_t Result = CreateWithPrecision(precision, nameof(precision));

        Result.LastTernaryResult = mpfr.const_pi(Result, DefaultRounding);

        return Result;
    }

    /// <summary>
    /// Gets the Euler-Mascheroni constant, 0.5772... (not e).
    /// </summary>
    /// <param name="precision">The precision, or <see cref="ulong.MaxValue"/> for <see cref="DefaultPrecision"/>.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="precision"/> is not a precision supported by MPFR.</exception>
    public static mpfr_t Euler(ulong precision = ulong.MaxValue)
    {
        mpfr_t Result = CreateWithPrecision(precision, nameof(precision));

        Result.LastTernaryResult = mpfr.const_euler(Result, DefaultRounding);

        return Result;
    }

    /// <summary>
    /// Gets the Catalan constant.
    /// </summary>
    /// <param name="precision">The precision, or <see cref="ulong.MaxValue"/> for <see cref="DefaultPrecision"/>.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="precision"/> is not a precision supported by MPFR.</exception>
    public static mpfr_t Catalan(ulong precision = ulong.MaxValue)
    {
        mpfr_t Result = CreateWithPrecision(precision, nameof(precision));

        Result.LastTernaryResult = mpfr.const_catalan(Result, DefaultRounding);

        return Result;
    }

    /// <summary>
    /// Gets (1+x)^n.
    /// </summary>
    /// <param name="n">The operand.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Compound(long n)
    {
        ThrowIfDisposed(this);

        mpfr_t Result = CreateResult(this);

        Result.LastTernaryResult = mpfr.compound_si(Result, this, n, Rounding);

        return Result;
    }
    #endregion

    private static int DecodeTernary(int encoded)
    {
        // MPFR returns the ternary values of two results as s + 4 * c, each encoded as 0 (exact), 1 (rounded up) or 2 (rounded down).
        return (encoded & 3) switch
        {
            1 => 1,
            2 => -1,
            _ => 0,
        };
    }
}
