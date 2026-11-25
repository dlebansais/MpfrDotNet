namespace MpfrDotNet;

using System;
using System.Runtime.InteropServices;
using MpirDotNet;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public partial class mpfr_t : IDisposable
{
    #region Add
    /// <summary>
    /// Adds two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static mpfr_t operator +(mpfr_t x, mpfr_t y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(x, y);

        z.LastTernaryResult = mpfr.add(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Adds two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpfr_t operator +(mpfr_t x, ulong y)
    {
        ThrowIfDisposed(x);

        mpfr_t z = CreateResult(x);

        z.LastTernaryResult = mpfr.add_ui(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Adds two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static mpfr_t operator +(ulong x, mpfr_t y)
    {
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(y);

        z.LastTernaryResult = mpfr.add_ui(z, y, x, y.Rounding);

        return z;
    }

    /// <summary>
    /// Adds two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpfr_t operator +(mpfr_t x, long y)
    {
        ThrowIfDisposed(x);

        mpfr_t z = CreateResult(x);

        z.LastTernaryResult = mpfr.add_si(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Adds two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static mpfr_t operator +(long x, mpfr_t y)
    {
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(y);

        z.LastTernaryResult = mpfr.add_si(z, y, x, y.Rounding);

        return z;
    }

    /// <summary>
    /// Adds two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpfr_t operator +(mpfr_t x, double y)
    {
        ThrowIfDisposed(x);

        mpfr_t z = CreateResult(x);

        z.LastTernaryResult = mpfr.add_d(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Adds two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static mpfr_t operator +(double x, mpfr_t y)
    {
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(y);

        z.LastTernaryResult = mpfr.add_d(z, y, x, y.Rounding);

        return z;
    }

    /// <summary>
    /// Adds two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    /// <exception cref="OverflowException">An integer or rational operand has more bits than the widest exponent range of MPFR, which only happens on Windows.</exception>
    public static mpfr_t operator +(mpfr_t x, mpz_t y)
    {
        ThrowIfDisposed(x);
        mpz_t.ThrowIfDisposed(y);

        mpfr_t z = CreateResult(x);

        z.LastTernaryResult = mpfr.add_z(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Adds two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    /// <exception cref="OverflowException">An integer or rational operand has more bits than the widest exponent range of MPFR, which only happens on Windows.</exception>
    public static mpfr_t operator +(mpz_t x, mpfr_t y)
    {
        mpz_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(y);

        z.LastTernaryResult = mpfr.add_z(z, y, x, y.Rounding);

        return z;
    }

    /// <summary>
    /// Adds two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    /// <exception cref="OverflowException">An integer or rational operand has more bits than the widest exponent range of MPFR, which only happens on Windows.</exception>
    public static mpfr_t operator +(mpfr_t x, mpq_t y)
    {
        ThrowIfDisposed(x);
        mpq_t.ThrowIfDisposed(y);

        mpfr_t z = CreateResult(x);

        z.LastTernaryResult = mpfr.add_q(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Adds two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    /// <exception cref="OverflowException">An integer or rational operand has more bits than the widest exponent range of MPFR, which only happens on Windows.</exception>
    public static mpfr_t operator +(mpq_t x, mpfr_t y)
    {
        mpq_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(y);

        z.LastTernaryResult = mpfr.add_q(z, y, x, y.Rounding);

        return z;
    }
    #endregion

    #region Sub
    /// <summary>
    /// Subtracts two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static mpfr_t operator -(mpfr_t x, mpfr_t y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(x, y);

        z.LastTernaryResult = mpfr.sub(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Subtracts two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpfr_t operator -(mpfr_t x, ulong y)
    {
        ThrowIfDisposed(x);

        mpfr_t z = CreateResult(x);

        z.LastTernaryResult = mpfr.sub_ui(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Subtracts two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static mpfr_t operator -(ulong x, mpfr_t y)
    {
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(y);

        z.LastTernaryResult = mpfr.ui_sub(z, x, y, y.Rounding);

        return z;
    }

    /// <summary>
    /// Subtracts two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpfr_t operator -(mpfr_t x, long y)
    {
        ThrowIfDisposed(x);

        mpfr_t z = CreateResult(x);

        z.LastTernaryResult = mpfr.sub_si(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Subtracts two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static mpfr_t operator -(long x, mpfr_t y)
    {
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(y);

        z.LastTernaryResult = mpfr.si_sub(z, x, y, y.Rounding);

        return z;
    }

    /// <summary>
    /// Subtracts two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpfr_t operator -(mpfr_t x, double y)
    {
        ThrowIfDisposed(x);

        mpfr_t z = CreateResult(x);

        z.LastTernaryResult = mpfr.sub_d(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Subtracts two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static mpfr_t operator -(double x, mpfr_t y)
    {
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(y);

        z.LastTernaryResult = mpfr.d_sub(z, x, y, y.Rounding);

        return z;
    }

    /// <summary>
    /// Subtracts two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    /// <exception cref="OverflowException">An integer or rational operand has more bits than the widest exponent range of MPFR, which only happens on Windows.</exception>
    public static mpfr_t operator -(mpfr_t x, mpz_t y)
    {
        ThrowIfDisposed(x);
        mpz_t.ThrowIfDisposed(y);

        mpfr_t z = CreateResult(x);

        z.LastTernaryResult = mpfr.sub_z(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Subtracts two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    /// <exception cref="OverflowException">An integer or rational operand has more bits than the widest exponent range of MPFR, which only happens on Windows.</exception>
    public static mpfr_t operator -(mpz_t x, mpfr_t y)
    {
        mpz_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(y);

        z.LastTernaryResult = mpfr.z_sub(z, x, y, y.Rounding);

        return z;
    }

    /// <summary>
    /// Subtracts two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    /// <exception cref="OverflowException">An integer or rational operand has more bits than the widest exponent range of MPFR, which only happens on Windows.</exception>
    public static mpfr_t operator -(mpfr_t x, mpq_t y)
    {
        ThrowIfDisposed(x);
        mpq_t.ThrowIfDisposed(y);

        mpfr_t z = CreateResult(x);

        z.LastTernaryResult = mpfr.sub_q(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Subtracts two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    /// <exception cref="OverflowException">An integer or rational operand has more bits than the widest exponent range of MPFR, which only happens on Windows.</exception>
    public static mpfr_t operator -(mpq_t x, mpfr_t y)
    {
        mpq_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(y);

        // x - y is computed as -(y - x). Negation is exact but reverses the direction of rounding,
        // so y - x is rounded in the opposite direction.
        z.LastTernaryResult = -mpfr.sub_q(z, y, x, OppositeRounding(y.Rounding));
        _ = mpfr.neg(z, z, y.Rounding);

        // An exact zero gets the sign that MPFR gives to x - y. For x = 0 and y a zero, as for the integers of
        // mpfr_z_sub: 0 - (+0) = -0 and 0 - (-0) = +0. Otherwise the zero comes from a cancellation: +0, or -0 when
        // rounding toward -infinity. A zero from an underflow is not exact and already has the sign of x - y.
        if (z.IsZero && z.LastTernaryResult == 0)
        {
            int Sign = mpq.sgn(x) == 0 && y.IsZero
                ? (mpfr.signbit(y) != 0 ? +1 : -1)
                : (y.Rounding == mpfr_rnd_t.MPFR_RNDD ? -1 : +1);
            mpfr.set_zero(z, Sign);
        }

        return z;
    }
    #endregion

    #region Mul
    /// <summary>
    /// Multiplies two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static mpfr_t operator *(mpfr_t x, mpfr_t y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(x, y);

        z.LastTernaryResult = mpfr.mul(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Multiplies two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpfr_t operator *(mpfr_t x, ulong y)
    {
        ThrowIfDisposed(x);

        mpfr_t z = CreateResult(x);

        z.LastTernaryResult = mpfr.mul_ui(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Multiplies two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static mpfr_t operator *(ulong x, mpfr_t y)
    {
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(y);

        z.LastTernaryResult = mpfr.mul_ui(z, y, x, y.Rounding);

        return z;
    }

    /// <summary>
    /// Multiplies two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpfr_t operator *(mpfr_t x, long y)
    {
        ThrowIfDisposed(x);

        mpfr_t z = CreateResult(x);

        z.LastTernaryResult = mpfr.mul_si(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Multiplies two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static mpfr_t operator *(long x, mpfr_t y)
    {
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(y);

        z.LastTernaryResult = mpfr.mul_si(z, y, x, y.Rounding);

        return z;
    }

    /// <summary>
    /// Multiplies two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpfr_t operator *(mpfr_t x, double y)
    {
        ThrowIfDisposed(x);

        mpfr_t z = CreateResult(x);

        z.LastTernaryResult = mpfr.mul_d(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Multiplies two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static mpfr_t operator *(double x, mpfr_t y)
    {
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(y);

        z.LastTernaryResult = mpfr.mul_d(z, y, x, y.Rounding);

        return z;
    }

    /// <summary>
    /// Multiplies two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    /// <exception cref="OverflowException">An integer or rational operand has more bits than the widest exponent range of MPFR, which only happens on Windows.</exception>
    public static mpfr_t operator *(mpfr_t x, mpz_t y)
    {
        ThrowIfDisposed(x);
        mpz_t.ThrowIfDisposed(y);

        mpfr_t z = CreateResult(x);

        z.LastTernaryResult = mpfr.mul_z(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Multiplies two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    /// <exception cref="OverflowException">An integer or rational operand has more bits than the widest exponent range of MPFR, which only happens on Windows.</exception>
    public static mpfr_t operator *(mpz_t x, mpfr_t y)
    {
        mpz_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(y);

        z.LastTernaryResult = mpfr.mul_z(z, y, x, y.Rounding);

        return z;
    }

    /// <summary>
    /// Multiplies two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    /// <exception cref="OverflowException">An integer or rational operand has more bits than the widest exponent range of MPFR, which only happens on Windows.</exception>
    public static mpfr_t operator *(mpfr_t x, mpq_t y)
    {
        ThrowIfDisposed(x);
        mpq_t.ThrowIfDisposed(y);

        mpfr_t z = CreateResult(x);

        z.LastTernaryResult = mpfr.mul_q(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Multiplies two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    /// <exception cref="OverflowException">An integer or rational operand has more bits than the widest exponent range of MPFR, which only happens on Windows.</exception>
    public static mpfr_t operator *(mpq_t x, mpfr_t y)
    {
        mpq_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(y);

        z.LastTernaryResult = mpfr.mul_q(z, y, x, y.Rounding);

        return z;
    }
    #endregion

    #region Div
    /// <summary>
    /// Divides two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static mpfr_t operator /(mpfr_t x, mpfr_t y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(x, y);

        z.LastTernaryResult = mpfr.div(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Divides two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpfr_t operator /(mpfr_t x, ulong y)
    {
        ThrowIfDisposed(x);

        mpfr_t z = CreateResult(x);

        z.LastTernaryResult = mpfr.div_ui(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Divides two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static mpfr_t operator /(ulong x, mpfr_t y)
    {
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(y);

        z.LastTernaryResult = mpfr.ui_div(z, x, y, y.Rounding);

        return z;
    }

    /// <summary>
    /// Divides two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpfr_t operator /(mpfr_t x, long y)
    {
        ThrowIfDisposed(x);

        mpfr_t z = CreateResult(x);

        z.LastTernaryResult = mpfr.div_si(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Divides two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static mpfr_t operator /(long x, mpfr_t y)
    {
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(y);

        z.LastTernaryResult = mpfr.si_div(z, x, y, y.Rounding);

        return z;
    }

    /// <summary>
    /// Divides two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpfr_t operator /(mpfr_t x, double y)
    {
        ThrowIfDisposed(x);

        mpfr_t z = CreateResult(x);

        z.LastTernaryResult = mpfr.div_d(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Divides two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static mpfr_t operator /(double x, mpfr_t y)
    {
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(y);

        z.LastTernaryResult = mpfr.d_div(z, x, y, y.Rounding);

        return z;
    }

    /// <summary>
    /// Divides two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    /// <exception cref="OverflowException">An integer or rational operand has more bits than the widest exponent range of MPFR, which only happens on Windows.</exception>
    public static mpfr_t operator /(mpfr_t x, mpz_t y)
    {
        ThrowIfDisposed(x);
        mpz_t.ThrowIfDisposed(y);

        mpfr_t z = CreateResult(x);

        z.LastTernaryResult = mpfr.div_z(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Divides two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static mpfr_t operator /(mpz_t x, mpfr_t y)
    {
        mpz_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(y);

        z.LastTernaryResult = InWidestExponentRange(z, y.Rounding, () =>
        {
            using mpz_t One = new(1);
            return DivideScaled(z, x, One, y);
        });

        return z;
    }

    /// <summary>
    /// Divides two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    /// <exception cref="OverflowException">An integer or rational operand has more bits than the widest exponent range of MPFR, which only happens on Windows.</exception>
    public static mpfr_t operator /(mpfr_t x, mpq_t y)
    {
        ThrowIfDisposed(x);
        mpq_t.ThrowIfDisposed(y);

        mpfr_t z = CreateResult(x);

        z.LastTernaryResult = mpfr.div_q(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Divides two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    /// <exception cref="OverflowException">An integer or rational operand has more bits than the widest exponent range of MPFR, which only happens on Windows.</exception>
    public static mpfr_t operator /(mpq_t x, mpfr_t y)
    {
        mpq_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        mpfr_t z = CreateResult(y);

        z.LastTernaryResult = InWidestExponentRange(z, y.Rounding, () => DivideRational(z, x, y));

        return z;
    }

    private static int DivideRational(mpfr_t z, mpq_t x, mpfr_t y)
    {
        using mpz_t Numerator = new();
        mpq.get_num(Numerator, x);
        using mpz_t Denominator = new();
        mpq.get_den(Denominator, x);

        return DivideScaled(z, Numerator, Denominator, y);
    }

    private static int DivideScaled(mpfr_t z, mpz_t numerator, mpz_t denominator, mpfr_t y)
    {
        // x / y = n / (d * y), with n and d * y computed exactly, so that the result is rounded once. Either can overflow
        // the widest exponent range, which is only about 2^±2^30 when exponents are 32-bit, even if the result does not.
        // So n is written n' * 2^k and a regular y is written y' * 2^e, with n' and y' in [0.5, 1): n' / (d * y') cannot
        // overflow, and the scaling by 2^(k - e) is exact in the widest range unless the result is beyond it.
        long NumeratorExponent = (long)mpz.sizeinbase(numerator, 2);
        using mpfr_t ScaledNumerator = CreateWithPrecision(Math.Max((ulong)NumeratorExponent, mpfr.PrecisionMin), nameof(numerator));
        _ = mpfr.set_z_2exp(ScaledNumerator, numerator, -NumeratorExponent, mpfr_rnd_t.MPFR_RNDN);

        using mpfr_t ScaledY = CreateResult(y);
        _ = mpfr.set(ScaledY, y, mpfr_rnd_t.MPFR_RNDN);
        long Exponent = 0;

        if (mpfr.regular_p(y))
        {
            Exponent = (long)mpfr_get_exp(ref y.Value).Value;
            _ = mpfr.set_exp(ScaledY, 0);
        }

        using mpfr_t ExactProduct = CreateWithPrecision(mpz.sizeinbase(denominator, 2) + mpfr.get_prec(y), nameof(y));
        _ = mpfr.mul_z(ExactProduct, ScaledY, denominator, mpfr_rnd_t.MPFR_RNDN);

        int Ternary = mpfr.div(z, ScaledNumerator, ExactProduct, y.Rounding);
        long Scaling = NumeratorExponent - Exponent;
        int Sign = mpfr.sgn(z);
        bool IsAboveUnderflowMidpoint = IsRoundedDownToUnderflowMidpoint(z, Ternary, Scaling, y.Rounding);

        // When the scaling overflows or underflows, it gives the ternary.
        int ScalingTernary = mpfr.mul_2si(z, z, Scaling, y.Rounding);

        // mpfr_mul_2si decides an underflow from the rounded quotient only, and rounds the midpoint to zero.
        if (IsAboveUnderflowMidpoint)
        {
            _ = mpfr.set_si_2exp(z, Sign, (long)mpfr_get_emin().Value - 1, mpfr_rnd_t.MPFR_RNDN);
            return Sign;
        }

        return ScalingTernary != 0 ? ScalingTernary : Ternary;
    }

    private static bool IsRoundedDownToUnderflowMidpoint(mpfr_t z, int ternary, long scaling, mpfr_rnd_t rounding)
    {
        // With round to nearest, a quotient rounded down in magnitude to a power of two that scales to half the smallest
        // number is an exact value above that midpoint, which rounds up to the smallest number.
        return rounding == mpfr_rnd_t.MPFR_RNDN &&
               mpfr.regular_p(z) &&
               ternary * mpfr.sgn(z) < 0 &&
               mpfr.min_prec(z) == 1 &&
               (long)mpfr_get_exp(ref z.Value).Value + scaling == (long)mpfr_get_emin().Value - 1;
    }

    private static int InWidestExponentRange(mpfr_t z, mpfr_rnd_t rounding, Func<int> operation)
    {
        // As MPFR does internally (MPFR_SAVE_EXPO), the intermediate results are computed in the widest exponent range,
        // so that only the final result can overflow or underflow, with a single rounding. The range is per thread.
        CLong MinExponent = mpfr_get_emin();
        CLong MaxExponent = mpfr_get_emax();
        int Ternary;

        _ = mpfr_set_emin(mpfr_get_emin_min());
        _ = mpfr_set_emax(mpfr_get_emax_max());

        try
        {
            Ternary = operation();
        }
        finally
        {
            _ = mpfr_set_emin(MinExponent);
            _ = mpfr_set_emax(MaxExponent);
        }

        return mpfr.check_range(z, Ternary, rounding);
    }
    #endregion

    #region Misc
    /// <summary>
    /// Negates a value.
    /// </summary>
    /// <param name="x">The value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static mpfr_t operator -(mpfr_t x)
    {
        ThrowIfDisposed(x);

        mpfr_t z = CreateResult(x);

        z.LastTernaryResult = mpfr.neg(z, x, x.Rounding);

        return z;
    }
    #endregion

    #region Comparison
    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator >(mpfr_t? x, mpfr_t? y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return x is not null && (y is null || mpfr.greater_p(x, y));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator >(mpfr_t? x, ulong y)
    {
        return x is not null && (!x.IsNan && x.CompareTo(y) > 0);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator >(ulong x, mpfr_t? y)
    {
        return y is null || (!y.IsNan && y.CompareTo(x) < 0);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator >(mpfr_t? x, long y)
    {
        return x is not null && (!x.IsNan && x.CompareTo(y) > 0);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator >(long x, mpfr_t? y)
    {
        return y is null || (!y.IsNan && y.CompareTo(x) < 0);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator >(mpfr_t? x, double y)
    {
        return x is not null && (!x.IsNan && !double.IsNaN(y) && x.CompareTo(y) > 0);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator >(double x, mpfr_t? y)
    {
        return y is null || (!y.IsNan && !double.IsNaN(x) && y.CompareTo(x) < 0);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator >(mpfr_t? x, mpz_t? y)
    {
        ThrowIfDisposed(x);
        mpz_t.ThrowIfDisposed(y);

        return x is not null && (y is null || (!x.IsNan && x.CompareTo(y) > 0));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator >(mpz_t? x, mpfr_t? y)
    {
        mpz_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return x is not null && (y is null || (!y.IsNan && y.CompareTo(x) < 0));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator >(mpfr_t? x, mpq_t? y)
    {
        ThrowIfDisposed(x);
        mpq_t.ThrowIfDisposed(y);

        return x is not null && (y is null || (!x.IsNan && x.CompareTo(y) > 0));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator >(mpq_t? x, mpfr_t? y)
    {
        mpq_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return x is not null && (y is null || (!y.IsNan && y.CompareTo(x) < 0));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator >(mpfr_t? x, mpf_t? y)
    {
        ThrowIfDisposed(x);
        mpf_t.ThrowIfDisposed(y);

        return x is not null && (y is null || (!x.IsNan && x.CompareTo(y) > 0));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator >(mpf_t? x, mpfr_t? y)
    {
        mpf_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return x is not null && (y is null || (!y.IsNan && y.CompareTo(x) < 0));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator >=(mpfr_t? x, mpfr_t? y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return y is null || (x is not null && mpfr.greaterequal_p(x, y));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator >=(mpfr_t? x, ulong y)
    {
        return x is not null && (!x.IsNan && x.CompareTo(y) >= 0);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator >=(ulong x, mpfr_t? y)
    {
        return y is null || (!y.IsNan && y.CompareTo(x) <= 0);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator >=(mpfr_t? x, long y)
    {
        return x is not null && (!x.IsNan && x.CompareTo(y) >= 0);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator >=(long x, mpfr_t? y)
    {
        return y is null || (!y.IsNan && y.CompareTo(x) <= 0);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator >=(mpfr_t? x, double y)
    {
        return x is not null && (!x.IsNan && !double.IsNaN(y) && x.CompareTo(y) >= 0);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator >=(double x, mpfr_t? y)
    {
        return y is null || (!y.IsNan && !double.IsNaN(x) && y.CompareTo(x) <= 0);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator >=(mpfr_t? x, mpz_t? y)
    {
        ThrowIfDisposed(x);
        mpz_t.ThrowIfDisposed(y);

        return y is null || (x is not null && (!x.IsNan && x.CompareTo(y) >= 0));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator >=(mpz_t? x, mpfr_t? y)
    {
        mpz_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return y is null || (x is not null && (!y.IsNan && y.CompareTo(x) <= 0));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator >=(mpfr_t? x, mpq_t? y)
    {
        ThrowIfDisposed(x);
        mpq_t.ThrowIfDisposed(y);

        return y is null || (x is not null && (!x.IsNan && x.CompareTo(y) >= 0));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator >=(mpq_t? x, mpfr_t? y)
    {
        mpq_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return y is null || (x is not null && (!y.IsNan && y.CompareTo(x) <= 0));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator >=(mpfr_t? x, mpf_t? y)
    {
        ThrowIfDisposed(x);
        mpf_t.ThrowIfDisposed(y);

        return y is null || (x is not null && (!x.IsNan && x.CompareTo(y) >= 0));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator >=(mpf_t? x, mpfr_t? y)
    {
        mpf_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return y is null || (x is not null && (!y.IsNan && y.CompareTo(x) <= 0));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator <(mpfr_t? x, mpfr_t? y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return y is not null && (x is null || mpfr.less_p(x, y));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator <(mpfr_t? x, ulong y)
    {
        return x is null || (!x.IsNan && x.CompareTo(y) < 0);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator <(ulong x, mpfr_t? y)
    {
        return y is not null && (!y.IsNan && y.CompareTo(x) > 0);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator <(mpfr_t? x, long y)
    {
        return x is null || (!x.IsNan && x.CompareTo(y) < 0);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator <(long x, mpfr_t? y)
    {
        return y is not null && (!y.IsNan && y.CompareTo(x) > 0);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator <(mpfr_t? x, double y)
    {
        return x is null || (!x.IsNan && !double.IsNaN(y) && x.CompareTo(y) < 0);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator <(double x, mpfr_t? y)
    {
        return y is not null && (!y.IsNan && !double.IsNaN(x) && y.CompareTo(x) > 0);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator <(mpfr_t? x, mpz_t? y)
    {
        ThrowIfDisposed(x);
        mpz_t.ThrowIfDisposed(y);

        return y is not null && (x is null || (!x.IsNan && x.CompareTo(y) < 0));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator <(mpz_t? x, mpfr_t? y)
    {
        mpz_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return y is not null && (x is null || (!y.IsNan && y.CompareTo(x) > 0));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator <(mpfr_t? x, mpq_t? y)
    {
        ThrowIfDisposed(x);
        mpq_t.ThrowIfDisposed(y);

        return y is not null && (x is null || (!x.IsNan && x.CompareTo(y) < 0));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator <(mpq_t? x, mpfr_t? y)
    {
        mpq_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return y is not null && (x is null || (!y.IsNan && y.CompareTo(x) > 0));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator <(mpfr_t? x, mpf_t? y)
    {
        ThrowIfDisposed(x);
        mpf_t.ThrowIfDisposed(y);

        return y is not null && (x is null || (!x.IsNan && x.CompareTo(y) < 0));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator <(mpf_t? x, mpfr_t? y)
    {
        mpf_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return y is not null && (x is null || (!y.IsNan && y.CompareTo(x) > 0));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator <=(mpfr_t? x, mpfr_t? y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return x is null || (y is not null && mpfr.lessequal_p(x, y));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator <=(mpfr_t? x, ulong y)
    {
        return x is null || (!x.IsNan && x.CompareTo(y) <= 0);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator <=(ulong x, mpfr_t? y)
    {
        return y is not null && (!y.IsNan && y.CompareTo(x) >= 0);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator <=(mpfr_t? x, long y)
    {
        return x is null || (!x.IsNan && x.CompareTo(y) <= 0);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator <=(long x, mpfr_t? y)
    {
        return y is not null && (!y.IsNan && y.CompareTo(x) >= 0);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator <=(mpfr_t? x, double y)
    {
        return x is null || (!x.IsNan && !double.IsNaN(y) && x.CompareTo(y) <= 0);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator <=(double x, mpfr_t? y)
    {
        return y is not null && (!y.IsNan && !double.IsNaN(x) && y.CompareTo(x) >= 0);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator <=(mpfr_t? x, mpz_t? y)
    {
        ThrowIfDisposed(x);
        mpz_t.ThrowIfDisposed(y);

        return x is null || (y is not null && (!x.IsNan && x.CompareTo(y) <= 0));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator <=(mpz_t? x, mpfr_t? y)
    {
        mpz_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return x is null || (y is not null && (!y.IsNan && y.CompareTo(x) >= 0));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator <=(mpfr_t? x, mpq_t? y)
    {
        ThrowIfDisposed(x);
        mpq_t.ThrowIfDisposed(y);

        return x is null || (y is not null && (!x.IsNan && x.CompareTo(y) <= 0));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator <=(mpq_t? x, mpfr_t? y)
    {
        mpq_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return x is null || (y is not null && (!y.IsNan && y.CompareTo(x) >= 0));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator <=(mpfr_t? x, mpf_t? y)
    {
        ThrowIfDisposed(x);
        mpf_t.ThrowIfDisposed(y);

        return x is null || (y is not null && (!x.IsNan && x.CompareTo(y) <= 0));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator <=(mpf_t? x, mpfr_t? y)
    {
        mpf_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return x is null || (y is not null && (!y.IsNan && y.CompareTo(x) >= 0));
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator ==(mpfr_t? x, mpfr_t? y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return x is null ? y is null : y is not null && mpfr.equal_p(x, y);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator ==(mpfr_t? x, ulong y)
    {
        return x is not null && !x.IsNan && x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator ==(ulong x, mpfr_t? y)
    {
        return y is not null && !y.IsNan && y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator ==(mpfr_t? x, long y)
    {
        return x is not null && !x.IsNan && x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator ==(long x, mpfr_t? y)
    {
        return y is not null && !y.IsNan && y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator ==(mpfr_t? x, double y)
    {
        return x is not null && !x.IsNan && !double.IsNaN(y) && x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator ==(double x, mpfr_t? y)
    {
        return y is not null && !y.IsNan && !double.IsNaN(x) && y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator ==(mpfr_t? x, mpz_t? y)
    {
        ThrowIfDisposed(x);
        mpz_t.ThrowIfDisposed(y);

        return x is null ? y is null : y is not null && !x.IsNan && x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator ==(mpz_t? x, mpfr_t? y)
    {
        mpz_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return y is null ? x is null : x is not null && !y.IsNan && y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator ==(mpfr_t? x, mpq_t? y)
    {
        ThrowIfDisposed(x);
        mpq_t.ThrowIfDisposed(y);

        return x is null ? y is null : y is not null && !x.IsNan && x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator ==(mpq_t? x, mpfr_t? y)
    {
        mpq_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return y is null ? x is null : x is not null && !y.IsNan && y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator ==(mpfr_t? x, mpf_t? y)
    {
        ThrowIfDisposed(x);
        mpf_t.ThrowIfDisposed(y);

        return x is null ? y is null : y is not null && !x.IsNan && x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator ==(mpf_t? x, mpfr_t? y)
    {
        mpf_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return y is null ? x is null : x is not null && !y.IsNan && y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator !=(mpfr_t? x, mpfr_t? y)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return !(x == y);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator !=(mpfr_t? x, ulong y)
    {
        return x is null || x.IsNan || x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator !=(ulong x, mpfr_t? y)
    {
        return y is null || y.IsNan || y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator !=(mpfr_t? x, long y)
    {
        return x is null || x.IsNan || x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator !=(long x, mpfr_t? y)
    {
        return y is null || y.IsNan || y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static bool operator !=(mpfr_t? x, double y)
    {
        return x is null || x.IsNan || double.IsNaN(y) || x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="y"/> is disposed.</exception>
    public static bool operator !=(double x, mpfr_t? y)
    {
        return y is null || y.IsNan || double.IsNaN(x) || y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator !=(mpfr_t? x, mpz_t? y)
    {
        ThrowIfDisposed(x);
        mpz_t.ThrowIfDisposed(y);

        return !(x == y);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator !=(mpz_t? x, mpfr_t? y)
    {
        mpz_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return !(x == y);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator !=(mpfr_t? x, mpq_t? y)
    {
        ThrowIfDisposed(x);
        mpq_t.ThrowIfDisposed(y);

        return !(x == y);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator !=(mpq_t? x, mpfr_t? y)
    {
        mpq_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return !(x == y);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator !=(mpfr_t? x, mpf_t? y)
    {
        ThrowIfDisposed(x);
        mpf_t.ThrowIfDisposed(y);

        return !(x == y);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static bool operator !=(mpf_t? x, mpfr_t? y)
    {
        mpf_t.ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        return !(x == y);
    }
    #endregion

    private static mpfr_t CreateResult(mpfr_t x)
        => CreateWithPrecision(mpfr.get_prec(x), nameof(x));

    private static mpfr_t CreateResult(mpfr_t x, mpfr_t y)
        => CreateWithPrecision(Math.Max(mpfr.get_prec(x), mpfr.get_prec(y)), nameof(x));

    private static mpfr_t CreateResult(params mpfr_t[] operands)
    {
        ulong Precision = mpfr.PrecisionMin;
        foreach (mpfr_t Operand in operands)
            Precision = Math.Max(Precision, mpfr.get_prec(Operand));

        return CreateWithPrecision(Precision, nameof(operands));
    }

    private static mpfr_rnd_t OppositeRounding(mpfr_rnd_t rounding)
        => rounding switch
        {
            mpfr_rnd_t.MPFR_RNDU => mpfr_rnd_t.MPFR_RNDD,
            mpfr_rnd_t.MPFR_RNDD => mpfr_rnd_t.MPFR_RNDU,
            _ => rounding,
        };
}
