namespace MpfrDotNet;

using System;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public partial class mpfr_t : IDisposable
{
    /// <summary>
    /// Gets the square.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    /// <exception cref="OverflowException">This number is regular, and twice its precision exceeds the maximum precision of MPFR, which only happens on Windows.</exception>
    public mpfr_t Sqr()
    {
        ThrowIfDisposed(this);

        // The operand is checked before the result is created, so that nothing is left to the finalizer.
        mpfr.CheckProduct(this, this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.sqr(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the square root.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Sqrt()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.sqrt(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the cubic root.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Cbrt()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.cbrt(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the nth root.
    /// </summary>
    /// <param name="n">The nth.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t NthRoot(ulong n)
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.rootn_ui(z, this, n, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the nth root.
    /// </summary>
    /// <param name="n">The nth.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t NthRoot(long n)
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.rootn_si(z, this, n, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the absolute value.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Abs()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.abs(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the euclidean norm of two numbers.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public static mpfr_t EuclideanNorm(mpfr_t x, mpfr_t y, mpfr_rnd_t rounding = DefaultRounding)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        _ = mpfr.CheckRounding(rounding, nameof(rounding));

        mpfr_t z = CreateResult(x, y);

        z.LastTernaryResult = mpfr.hypot(z, x, y, rounding);

        return z;
    }

    /// <summary>
    /// Gets the positive difference of <paramref name="x"/> and <paramref name="y"/>.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public static mpfr_t Dim(mpfr_t x, mpfr_t y, mpfr_rnd_t rounding = DefaultRounding)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        _ = mpfr.CheckRounding(rounding, nameof(rounding));

        mpfr_t z = CreateResult(x, y);

        z.LastTernaryResult = mpfr.dim(z, x, y, rounding);

        return z;
    }

    /// <summary>
    /// Gets (<paramref name="a"/> * <paramref name="b"/>) + <paramref name="c"/>.
    /// </summary>
    /// <param name="a">The first operand.</param>
    /// <param name="b">The second operand.</param>
    /// <param name="c">The third operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="a"/>, <paramref name="b"/> or <paramref name="c"/> is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    /// <exception cref="OverflowException">The factors are regular, the term is a number, and the precisions of <paramref name="a"/> and <paramref name="b"/> add up to more than the maximum precision, which only happens on Windows.</exception>
    public static mpfr_t Fma(mpfr_t a, mpfr_t b, mpfr_t c, mpfr_rnd_t rounding = DefaultRounding)
    {
        ThrowIfDisposed(a);
        ThrowIfDisposed(b);
        ThrowIfDisposed(c);

        _ = mpfr.CheckRounding(rounding, nameof(rounding));

        // The operands are checked before the result is created, so that nothing is left to the finalizer.
        mpfr.CheckExactProduct(a, b, c);

        mpfr_t Result = CreateResult(a, b, c);

        Result.LastTernaryResult = mpfr.fma(Result, a, b, c, rounding);

        return Result;
    }

    /// <summary>
    /// Gets (<paramref name="a"/> * <paramref name="b"/>) - <paramref name="c"/>.
    /// </summary>
    /// <param name="a">The first operand.</param>
    /// <param name="b">The second operand.</param>
    /// <param name="c">The third operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="a"/>, <paramref name="b"/> or <paramref name="c"/> is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    /// <exception cref="OverflowException">The factors are regular, the term is a number, and the precisions of <paramref name="a"/> and <paramref name="b"/> add up to more than the maximum precision, which only happens on Windows.</exception>
    public static mpfr_t Fms(mpfr_t a, mpfr_t b, mpfr_t c, mpfr_rnd_t rounding = DefaultRounding)
    {
        ThrowIfDisposed(a);
        ThrowIfDisposed(b);
        ThrowIfDisposed(c);

        _ = mpfr.CheckRounding(rounding, nameof(rounding));

        // The operands are checked before the result is created, so that nothing is left to the finalizer.
        mpfr.CheckExactProduct(a, b, c);

        mpfr_t Result = CreateResult(a, b, c);

        Result.LastTernaryResult = mpfr.fms(Result, a, b, c, rounding);

        return Result;
    }

    /// <summary>
    /// Gets (<paramref name="a"/> * <paramref name="b"/>) + (<paramref name="c"/> * <paramref name="d"/>).
    /// </summary>
    /// <param name="a">The first operand.</param>
    /// <param name="b">The second operand.</param>
    /// <param name="c">The third operand.</param>
    /// <param name="d">The fourth operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="a"/>, <paramref name="b"/>, <paramref name="c"/> or <paramref name="d"/> is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public static mpfr_t Fmma(mpfr_t a, mpfr_t b, mpfr_t c, mpfr_t d, mpfr_rnd_t rounding = DefaultRounding)
    {
        ThrowIfDisposed(a);
        ThrowIfDisposed(b);
        ThrowIfDisposed(c);
        ThrowIfDisposed(d);

        _ = mpfr.CheckRounding(rounding, nameof(rounding));

        mpfr_t Result = CreateResult(a, b, c, d);

        Result.LastTernaryResult = mpfr.fmma(Result, a, b, c, d, rounding);

        return Result;
    }

    /// <summary>
    /// Gets (<paramref name="a"/> * <paramref name="b"/>) - (<paramref name="c"/> * <paramref name="d"/>).
    /// </summary>
    /// <param name="a">The first operand.</param>
    /// <param name="b">The second operand.</param>
    /// <param name="c">The third operand.</param>
    /// <param name="d">The fourth operand.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="a"/>, <paramref name="b"/>, <paramref name="c"/> or <paramref name="d"/> is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public static mpfr_t Fmms(mpfr_t a, mpfr_t b, mpfr_t c, mpfr_t d, mpfr_rnd_t rounding = DefaultRounding)
    {
        ThrowIfDisposed(a);
        ThrowIfDisposed(b);
        ThrowIfDisposed(c);
        ThrowIfDisposed(d);

        _ = mpfr.CheckRounding(rounding, nameof(rounding));

        mpfr_t Result = CreateResult(a, b, c, d);

        Result.LastTernaryResult = mpfr.fmms(Result, a, b, c, d, rounding);

        return Result;
    }

    /// <summary>
    /// Gets the value multiplied by 2^<paramref name="n"/>.
    /// </summary>
    /// <param name="n">The power.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Mul2(ulong n)
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.mul_2ui(z, this, n, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the value multiplied by 2^<paramref name="n"/>.
    /// </summary>
    /// <param name="n">The power.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Mul2(long n)
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.mul_2si(z, this, n, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the value divided by 2^<paramref name="n"/>.
    /// </summary>
    /// <param name="n">The power.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Div2(ulong n)
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.div_2ui(z, this, n, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the value divided by 2^<paramref name="n"/>.
    /// </summary>
    /// <param name="n">The power.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t Div2(long n)
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.div_2si(z, this, n, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the reciprocal square root.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpfr_t RecSqrt()
    {
        ThrowIfDisposed(this);

        mpfr_t z = CreateResult(this);

        z.LastTernaryResult = mpfr.rec_sqrt(z, this, Rounding);

        return z;
    }

    /// <summary>
    /// Gets the sum of numbers, rounded once (mpfr_sum).
    /// </summary>
    /// <param name="values">The numbers.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <returns>The sum, with the largest precision of <paramref name="values"/>, or zero for no number.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="values"/> or one of its numbers is <see langword="null"/>.</exception>
    /// <exception cref="ObjectDisposedException">One of the numbers is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    public static mpfr_t Sum(mpfr_t[] values, mpfr_rnd_t rounding = DefaultRounding)
    {
        CheckOperandArray(values, nameof(values));
        _ = mpfr.CheckRounding(rounding, nameof(rounding));

        mpfr_t z = CreateResult(values);

        z.LastTernaryResult = mpfr.sum(z, values, rounding);

        return z;
    }

    /// <summary>
    /// Gets the dot product of two vectors of numbers, rounded once (mpfr_dot).
    /// </summary>
    /// <param name="x">The first vector.</param>
    /// <param name="y">The second vector, with the same length.</param>
    /// <param name="rounding">The rounding mode.</param>
    /// <returns>The dot product, with the largest precision of the numbers, or zero for empty vectors.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="x"/>, <paramref name="y"/> or one of their numbers is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="x"/> and <paramref name="y"/> do not have the same length.</exception>
    /// <exception cref="ObjectDisposedException">One of the numbers is disposed.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a supported rounding mode.</exception>
    /// <exception cref="OverflowException">The precisions of two factors add up to more than the maximum precision of MPFR, or a product is beyond the widest exponent range of MPFR.</exception>
    public static mpfr_t Dot(mpfr_t[] x, mpfr_t[] y, mpfr_rnd_t rounding = DefaultRounding)
    {
        CheckOperandArray(x, nameof(x));
        CheckOperandArray(y, nameof(y));

        if (x.Length != y.Length)
            throw new ArgumentException("The two arrays must have the same length.", nameof(y));

        _ = mpfr.CheckRounding(rounding, nameof(rounding));

        mpfr_t z = CreateResult([.. x, .. y]);

        try
        {
            z.LastTernaryResult = mpfr.dot(z, x, y, rounding);
        }
        catch
        {
            // The products can only be checked by computing them: the result is released rather than left to the finalizer.
            z.Dispose();
            throw;
        }

        return z;
    }

    private static void CheckOperandArray(mpfr_t[] values, string paramName)
    {
        if (values is null)
            throw new ArgumentNullException(paramName);

        foreach (mpfr_t Value in values)
        {
            if (Value is null)
                throw new ArgumentNullException(paramName);

            ThrowIfDisposed(Value);
        }
    }
}
