namespace MpirDotNet;

using System;
using static Interop.Mpir.NativeMethods;

/// <summary>
/// Arbitrary precision integer.
/// </summary>
public partial class mpz_t : IDisposable, IEquatable<mpz_t>, ICloneable, IConvertible, IComparable, IComparable<mpz_t>
{
    /// <summary>
    /// Gets the absolute value of the number.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpz_t Abs()
    {
        ThrowIfDisposed(this);

        mpz_t z = new();

        mpz.abs(z, this);

        return z;
    }

    /// <summary>
    /// Gets the sign.
    /// </summary>
    /// <exception cref="ObjectDisposedException">The number is disposed.</exception>
    public int Sign
    {
        get
        {
            ThrowIfDisposed(this);

            return mpz.sgn(this);
        }
    }

    /// <summary>
    /// Divides the number by another with rounding.
    /// </summary>
    /// <param name="y">The other number.</param>
    /// <param name="rounding">The rounding.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a value of <see cref="Rounding"/>.</exception>
    /// <exception cref="ObjectDisposedException">This number or <paramref name="y"/> is disposed.</exception>
    public mpz_t Quotient(mpz_t y, Rounding rounding = Rounding.TowardZero)
    {
        ThrowIfDisposed(this);
        ThrowIfDisposed(y);

        RoundingArgument.Check(rounding, nameof(rounding));

        mpz_t quotient = new();

        switch (rounding)
        {
            case Rounding.TowardPositiveInfinity:
                mpz.cdiv_q(quotient, this, y);
                break;

            case Rounding.TowardNegativeInfinity:
                mpz.fdiv_q(quotient, this, y);
                break;

            default:
                // The check leaves only Rounding.TowardZero.
                mpz.tdiv_q(quotient, this, y);
                break;
        }

        return quotient;
    }

    /// <summary>
    /// Gets the remainder of the division of the number by another with rounding.
    /// </summary>
    /// <param name="y">The other number.</param>
    /// <param name="rounding">The rounding.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a value of <see cref="Rounding"/>.</exception>
    /// <exception cref="ObjectDisposedException">This number or <paramref name="y"/> is disposed.</exception>
    public mpz_t Remainder(mpz_t y, Rounding rounding = Rounding.TowardZero)
    {
        ThrowIfDisposed(this);
        ThrowIfDisposed(y);

        RoundingArgument.Check(rounding, nameof(rounding));

        mpz_t remainder = new();

        switch (rounding)
        {
            case Rounding.TowardPositiveInfinity:
                mpz.cdiv_r(remainder, this, y);
                break;

            case Rounding.TowardNegativeInfinity:
                mpz.fdiv_r(remainder, this, y);
                break;

            default:
                // The check leaves only Rounding.TowardZero.
                mpz.tdiv_r(remainder, this, y);
                break;
        }

        return remainder;
    }

    /// <summary>
    /// Divides two operands with rounding.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <param name="quotient">The quotient.</param>
    /// <param name="remainder">The remainder.</param>
    /// <param name="rounding">The rounding.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a value of <see cref="Rounding"/>.</exception>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> or <paramref name="y"/> is disposed.</exception>
    public static void Divide(mpz_t x, mpz_t y, out mpz_t quotient, out mpz_t remainder, Rounding rounding = Rounding.TowardZero)
    {
        ThrowIfDisposed(x);
        ThrowIfDisposed(y);

        RoundingArgument.Check(rounding, nameof(rounding));

        quotient = new mpz_t();
        remainder = new mpz_t();

        switch (rounding)
        {
            case Rounding.TowardPositiveInfinity:
                mpz.cdiv_qr(quotient, remainder, x, y);
                break;

            case Rounding.TowardNegativeInfinity:
                mpz.fdiv_qr(quotient, remainder, x, y);
                break;

            default:
                // The check leaves only Rounding.TowardZero.
                mpz.tdiv_qr(quotient, remainder, x, y);
                break;
        }
    }

    /// <summary>
    /// Divides the number by another with rounding.
    /// </summary>
    /// <param name="y">The other number.</param>
    /// <param name="rounding">The rounding.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a value of <see cref="Rounding"/>.</exception>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpz_t Quotient(ulong y, Rounding rounding = Rounding.TowardZero)
    {
        ThrowIfDisposed(this);

        RoundingArgument.Check(rounding, nameof(rounding));

        mpz_t quotient = new();

        switch (rounding)
        {
            case Rounding.TowardPositiveInfinity:
                mpz.cdiv_q_ui(quotient, this, y);
                break;

            case Rounding.TowardNegativeInfinity:
                mpz.fdiv_q_ui(quotient, this, y);
                break;

            default:
                // The check leaves only Rounding.TowardZero.
                mpz.tdiv_q_ui(quotient, this, y);
                break;
        }

        return quotient;
    }

    /// <summary>
    /// Gets the remainder of the division of the number by another with rounding.
    /// </summary>
    /// <param name="y">The other number.</param>
    /// <param name="rounding">The rounding.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a value of <see cref="Rounding"/>.</exception>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpz_t Remainder(ulong y, Rounding rounding = Rounding.TowardZero)
    {
        ThrowIfDisposed(this);

        RoundingArgument.Check(rounding, nameof(rounding));

        mpz_t remainder = new();

        switch (rounding)
        {
            case Rounding.TowardPositiveInfinity:
                mpz.cdiv_r_ui(remainder, this, y);
                break;

            case Rounding.TowardNegativeInfinity:
                mpz.fdiv_r_ui(remainder, this, y);
                break;

            default:
                // The check leaves only Rounding.TowardZero.
                mpz.tdiv_r_ui(remainder, this, y);
                break;
        }

        return remainder;
    }

    /// <summary>
    /// Divides two operands with rounding.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <param name="quotient">The quotient.</param>
    /// <param name="remainder">The remainder.</param>
    /// <param name="rounding">The rounding.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a value of <see cref="Rounding"/>.</exception>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static void Divide(mpz_t x, ulong y, out mpz_t quotient, out mpz_t remainder, Rounding rounding = Rounding.TowardZero)
    {
        ThrowIfDisposed(x);

        RoundingArgument.Check(rounding, nameof(rounding));

        quotient = new mpz_t();
        remainder = new mpz_t();

        switch (rounding)
        {
            case Rounding.TowardPositiveInfinity:
                mpz.cdiv_qr_ui(quotient, remainder, x, y);
                break;

            case Rounding.TowardNegativeInfinity:
                mpz.fdiv_qr_ui(quotient, remainder, x, y);
                break;

            default:
                // The check leaves only Rounding.TowardZero.
                mpz.tdiv_qr_ui(quotient, remainder, x, y);
                break;
        }
    }

    /// <summary>
    /// Gets the absolute remainder of the division of the number by another with rounding.
    /// </summary>
    /// <param name="y">The other number.</param>
    /// <param name="rounding">The rounding.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a value of <see cref="Rounding"/>.</exception>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public ulong AbsRemainder(ulong y, Rounding rounding = Rounding.TowardZero)
    {
        ThrowIfDisposed(this);

        RoundingArgument.Check(rounding, nameof(rounding));

        return rounding switch
        {
            Rounding.TowardPositiveInfinity => mpz.cdiv_ui(this, y),
            Rounding.TowardNegativeInfinity => mpz.fdiv_ui(this, y),
            _ => mpz.tdiv_ui(this, y),
        };
    }

    /// <summary>
    /// Gets the right shift of the number by another with rounding.
    /// </summary>
    /// <param name="y">The other number.</param>
    /// <param name="rounding">The rounding.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a value of <see cref="Rounding"/>.</exception>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpz_t RightShift(ulong y, Rounding rounding = Rounding.TowardZero)
    {
        ThrowIfDisposed(this);

        RoundingArgument.Check(rounding, nameof(rounding));

        mpz_t quotient = new();

        switch (rounding)
        {
            case Rounding.TowardPositiveInfinity:
                mpz.cdiv_q_2exp(quotient, this, y);
                break;

            case Rounding.TowardNegativeInfinity:
                mpz.fdiv_q_2exp(quotient, this, y);
                break;

            default:
                // The check leaves only Rounding.TowardZero.
                mpz.tdiv_q_2exp(quotient, this, y);
                break;
        }

        return quotient;
    }

    /// <summary>
    /// Gets the remainder of the right shift of the number by another with rounding.
    /// </summary>
    /// <param name="y">The other number.</param>
    /// <param name="rounding">The rounding.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rounding"/> is not a value of <see cref="Rounding"/>.</exception>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpz_t RightShiftRemainder(ulong y, Rounding rounding = Rounding.TowardZero)
    {
        ThrowIfDisposed(this);

        RoundingArgument.Check(rounding, nameof(rounding));

        mpz_t remainder = new();

        switch (rounding)
        {
            case Rounding.TowardPositiveInfinity:
                mpz.cdiv_r_2exp(remainder, this, y);
                break;

            case Rounding.TowardNegativeInfinity:
                mpz.fdiv_r_2exp(remainder, this, y);
                break;

            default:
                // The check leaves only Rounding.TowardZero.
                mpz.tdiv_r_2exp(remainder, this, y);
                break;
        }

        return remainder;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="y">The divider.</param>
    /// <exception cref="ObjectDisposedException">This number or <paramref name="y"/> is disposed.</exception>
    public mpz_t DivExact(mpz_t y)
    {
        ThrowIfDisposed(this);
        ThrowIfDisposed(y);

        mpz_t quotient = new();

        mpz.divexact(quotient, this, y);

        return quotient;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="y">The divider.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpz_t DivExact(ulong y)
    {
        ThrowIfDisposed(this);

        mpz_t quotient = new();

        mpz.divexact_ui(quotient, this, y);

        return quotient;
    }

    /// <summary>
    /// Gets a value indicating whether the number can be exactly divided by another.
    /// </summary>
    /// <param name="y">The divider.</param>
    /// <exception cref="ObjectDisposedException">This number or <paramref name="y"/> is disposed.</exception>
    public bool IsDivisible(mpz_t y)
    {
        ThrowIfDisposed(this);
        ThrowIfDisposed(y);

        return mpz.divisible_p(this, y);
    }

    /// <summary>
    /// Gets a value indicating whether the number can be exactly divided by another.
    /// </summary>
    /// <param name="y">The divider.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public bool IsDivisible(ulong y)
    {
        ThrowIfDisposed(this);

        return mpz.divisible_ui_p(this, y);
    }

    /// <summary>
    /// Gets a value indicating whether the number can be exactly divided by the power of two of another.
    /// </summary>
    /// <param name="y">The power.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public bool IsDivisibleByPowerOfTwo(ulong y)
    {
        ThrowIfDisposed(this);

        return mpz.divisible_2exp_p(this, y);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="c">The c.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="ObjectDisposedException">This number, <paramref name="c"/> or <paramref name="d"/> is disposed.</exception>
    public bool IsCongruent(mpz_t c, mpz_t d)
    {
        ThrowIfDisposed(this);
        ThrowIfDisposed(c);
        ThrowIfDisposed(d);

        return mpz.congruent_p(this, c, d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="c">The c.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public bool IsCongruent(ulong c, ulong d)
    {
        ThrowIfDisposed(this);

        return mpz.congruent_ui_p(this, c, d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="c">The c.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="d"/> is negative.</exception>
    /// <exception cref="ObjectDisposedException">This number or <paramref name="c"/> is disposed.</exception>
    public bool IsCongruentPowerOfTwo(mpz_t c, long d)
    {
        ThrowIfDisposed(this);
        ThrowIfDisposed(c);

        if (d < 0)
            throw new ArgumentOutOfRangeException(nameof(d), d, "The exponent cannot be negative.");

        return mpz.congruent_2exp_p(this, c, (ulong)d);
    }

    /// <summary>
    /// Gets the number raised to a power, modulo another number.
    /// </summary>
    /// <param name="exp">The power.</param>
    /// <param name="mod">The modulo.</param>
    /// <exception cref="ObjectDisposedException">This number, <paramref name="exp"/> or <paramref name="mod"/> is disposed.</exception>
    /// <exception cref="DivideByZeroException"><paramref name="mod"/> is zero.</exception>
    /// <exception cref="ArithmeticException"><paramref name="exp"/> is negative and the number has no inverse modulo <paramref name="mod"/>.</exception>
    public mpz_t PowerMod(mpz_t exp, mpz_t mod)
    {
        ThrowIfDisposed(this);
        ThrowIfDisposed(exp);
        ThrowIfDisposed(mod);

        mpz_t Result = new();

        mpz.powm(Result, this, exp, mod);

        return Result;
    }

    /// <summary>
    /// Gets the number raised to a power, modulo another number.
    /// </summary>
    /// <param name="exp">The power.</param>
    /// <param name="mod">The modulo.</param>
    /// <exception cref="ObjectDisposedException">This number or <paramref name="mod"/> is disposed.</exception>
    /// <exception cref="DivideByZeroException"><paramref name="mod"/> is zero.</exception>
    public mpz_t PowerMod(ulong exp, mpz_t mod)
    {
        ThrowIfDisposed(this);
        ThrowIfDisposed(mod);

        mpz_t Result = new();

        mpz.powm_ui(Result, this, exp, mod);

        return Result;
    }

    /// <summary>
    /// Gets the value of the number to a power.
    /// </summary>
    /// <param name="exp">The power.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpz_t Pow(ulong exp)
    {
        ThrowIfDisposed(this);

        mpz_t Result = new();

        mpz.pow_ui(Result, this, exp);

        return Result;
    }

    /// <summary>
    /// Gets a value indicating whether the number is an exact root.
    /// </summary>
    /// <param name="n">The root number.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public bool IsRootExact(ulong n)
    {
        ThrowIfDisposed(this);

        using mpz_t Result = new();

        return mpz.root(Result, this, n);
    }

    /// <summary>
    /// Gets the root of the number.
    /// </summary>
    /// <param name="n">The root.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpz_t NthRoot(ulong n)
    {
        ThrowIfDisposed(this);

        mpz_t Result = new();

        mpz.nthroot(Result, this, n);

        return Result;
    }

    /// <summary>
    /// Gets the nth root of a number.
    /// </summary>
    /// <param name="x">The number.</param>
    /// <param name="n">The nth.</param>
    /// <param name="root">The root.</param>
    /// <param name="remainder">The remainder.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static void NthRoot(mpz_t x, ulong n, out mpz_t root, out mpz_t remainder)
    {
        ThrowIfDisposed(x);

        root = new mpz_t();
        remainder = new mpz_t();

        mpz.rootrem(root, remainder, x, n);
    }

    /// <summary>
    /// Gets the square root.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public mpz_t Sqrt()
    {
        ThrowIfDisposed(this);

        mpz_t Result = new();

        mpz.sqrt(Result, this);

        return Result;
    }

    /// <summary>
    /// Gets the square root of a number.
    /// </summary>
    /// <param name="x">The number.</param>
    /// <param name="root">The root.</param>
    /// <param name="remainder">The remainder.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="x"/> is disposed.</exception>
    public static void SqrtRemainder(mpz_t x, out mpz_t root, out mpz_t remainder)
    {
        ThrowIfDisposed(x);

        root = new mpz_t();
        remainder = new mpz_t();

        mpz.sqrtrem(root, remainder, x);
    }

    /// <summary>
    /// Gets a value indicating whether the number is an exact power.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public bool IsPerfectPower()
    {
        ThrowIfDisposed(this);

        return mpz.perfect_power_p(this);
    }

    /// <summary>
    /// Gets a value indicating whether the number is an exact square.
    /// </summary>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public bool IsPerfectSquare()
    {
        ThrowIfDisposed(this);

        return mpz.perfect_square_p(this);
    }
}
