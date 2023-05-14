namespace MpirDotNet;

using System;
using System.Numerics;
using System.Text;
using static Interop.Mpir.NativeMethods;

/// <summary>
/// Arbitrary precision integer.
/// </summary>
public partial class mpz_t : IDisposable, IEquatable<mpz_t>, ICloneable, IConvertible, IComparable, IComparable<mpz_t>
{
    /// <summary>
    /// Gets the absolute value of the number.
    /// </summary>
    public mpz_t Abs()
    {
        mpz_t z = new mpz_t();

        mpz_abs(ref z.Value, ref Value);

        return z;
    }

    /// <summary>
    /// Gets the sign.
    /// </summary>
    public int Sign
    {
        get { return mpz_sgn(ref Value); }
    }

    /// <summary>
    /// Divides the number by another with rounding.
    /// </summary>
    /// <param name="y">The other number.</param>
    /// <param name="rounding">The rounding.</param>
    public mpz_t Quotient(mpz_t y, Rounding rounding = Rounding.TowardZero)
    {
        mpz_t quotient = new mpz_t();

        switch (rounding)
        {
            default:
            case Rounding.TowardZero:
                mpz_tdiv_q(ref quotient.Value, ref Value, ref y.Value);
                break;

            case Rounding.TowardPositiveInfinity:
                mpz_cdiv_q(ref quotient.Value, ref Value, ref y.Value);
                break;

            case Rounding.TowardNegativeInfinity:
                mpz_fdiv_q(ref quotient.Value, ref Value, ref y.Value);
                break;
        }

        return quotient;
    }

    /// <summary>
    /// Gets the remainder of the division of the number by another with rounding.
    /// </summary>
    /// <param name="y">The other number.</param>
    /// <param name="rounding">The rounding.</param>
    public mpz_t Remainder(mpz_t y, Rounding rounding = Rounding.TowardZero)
    {
        mpz_t remainder = new mpz_t();

        switch (rounding)
        {
            default:
            case Rounding.TowardZero:
                mpz_tdiv_r(ref remainder.Value, ref Value, ref y.Value);
                break;

            case Rounding.TowardPositiveInfinity:
                mpz_cdiv_r(ref remainder.Value, ref Value, ref y.Value);
                break;

            case Rounding.TowardNegativeInfinity:
                mpz_fdiv_r(ref remainder.Value, ref Value, ref y.Value);
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
    public static void Divide(mpz_t x, mpz_t y, out mpz_t quotient, out mpz_t remainder, Rounding rounding = Rounding.TowardZero)
    {
        quotient = new mpz_t();
        remainder = new mpz_t();

        switch (rounding)
        {
            default:
            case Rounding.TowardZero:
                mpz_tdiv_qr(ref quotient.Value, ref remainder.Value, ref x.Value, ref y.Value);
                break;

            case Rounding.TowardPositiveInfinity:
                mpz_cdiv_qr(ref quotient.Value, ref remainder.Value, ref x.Value, ref y.Value);
                break;

            case Rounding.TowardNegativeInfinity:
                mpz_fdiv_qr(ref quotient.Value, ref remainder.Value, ref x.Value, ref y.Value);
                break;
        }
    }

    /// <summary>
    /// Divides the number by another with rounding.
    /// </summary>
    /// <param name="y">The other number.</param>
    /// <param name="rounding">The rounding.</param>
    public mpz_t Quotient(ulong y, Rounding rounding = Rounding.TowardZero)
    {
        mpz_t quotient = new mpz_t();

        switch (rounding)
        {
            default:
            case Rounding.TowardZero:
                mpz_tdiv_q_ui(ref quotient.Value, ref Value, (mpir_ui)y);
                break;

            case Rounding.TowardPositiveInfinity:
                mpz_cdiv_q_ui(ref quotient.Value, ref Value, (mpir_ui)y);
                break;

            case Rounding.TowardNegativeInfinity:
                mpz_fdiv_q_ui(ref quotient.Value, ref Value, (mpir_ui)y);
                break;
        }

        return quotient;
    }

    /// <summary>
    /// Gets the remainder of the division of the number by another with rounding.
    /// </summary>
    /// <param name="y">The other number.</param>
    /// <param name="rounding">The rounding.</param>
    public mpz_t Remainder(ulong y, Rounding rounding = Rounding.TowardZero)
    {
        mpz_t remainder = new mpz_t();

        switch (rounding)
        {
            default:
            case Rounding.TowardZero:
                mpz_tdiv_r_ui(ref remainder.Value, ref Value, (mpir_ui)y);
                break;

            case Rounding.TowardPositiveInfinity:
                mpz_cdiv_r_ui(ref remainder.Value, ref Value, (mpir_ui)y);
                break;

            case Rounding.TowardNegativeInfinity:
                mpz_fdiv_r_ui(ref remainder.Value, ref Value, (mpir_ui)y);
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
    public static void Divide(mpz_t x, ulong y, out mpz_t quotient, out mpz_t remainder, Rounding rounding = Rounding.TowardZero)
    {
        quotient = new mpz_t();
        remainder = new mpz_t();

        switch (rounding)
        {
            default:
            case Rounding.TowardZero:
                mpz_tdiv_qr_ui(ref quotient.Value, ref remainder.Value, ref x.Value, (mpir_ui)y);
                break;

            case Rounding.TowardPositiveInfinity:
                mpz_cdiv_qr_ui(ref quotient.Value, ref remainder.Value, ref x.Value, (mpir_ui)y);
                break;

            case Rounding.TowardNegativeInfinity:
                mpz_fdiv_qr_ui(ref quotient.Value, ref remainder.Value, ref x.Value, (mpir_ui)y);
                break;
        }
    }

    /// <summary>
    /// Gets the absolute remainder of the division of the number by another with rounding.
    /// </summary>
    /// <param name="y">The other number.</param>
    /// <param name="rounding">The rounding.</param>
    public ulong AbsRemainder(ulong y, Rounding rounding = Rounding.TowardZero)
    {
        ulong remainder;

        switch (rounding)
        {
            default:
            case Rounding.TowardZero:
                remainder = (ulong)mpz_tdiv_ui(ref Value, (mpir_ui)y);
                break;

            case Rounding.TowardPositiveInfinity:
                remainder = (ulong)mpz_cdiv_ui(ref Value, (mpir_ui)y);
                break;

            case Rounding.TowardNegativeInfinity:
                remainder = (ulong)mpz_fdiv_ui(ref Value, (mpir_ui)y);
                break;
        }

        return remainder;
    }

    /// <summary>
    /// Gets the right shift of the number by another with rounding.
    /// </summary>
    /// <param name="y">The other number.</param>
    /// <param name="rounding">The rounding.</param>
    public mpz_t RightShift(ulong y, Rounding rounding = Rounding.TowardZero)
    {
        mpz_t quotient = new mpz_t();

        switch (rounding)
        {
            default:
            case Rounding.TowardZero:
                mpz_tdiv_q_2exp(ref quotient.Value, ref Value, (mp_bitcnt_t)y);
                break;

            case Rounding.TowardPositiveInfinity:
                mpz_cdiv_q_2exp(ref quotient.Value, ref Value, (mp_bitcnt_t)y);
                break;

            case Rounding.TowardNegativeInfinity:
                mpz_fdiv_q_2exp(ref quotient.Value, ref Value, (mp_bitcnt_t)y);
                break;
        }

        return quotient;
    }

    /// <summary>
    /// Gets the remainder of the right shift of the number by another with rounding.
    /// </summary>
    /// <param name="y">The other number.</param>
    /// <param name="rounding">The rounding.</param>
    public mpz_t RightShiftRemainder(ulong y, Rounding rounding = Rounding.TowardZero)
    {
        mpz_t remainder = new mpz_t();

        switch (rounding)
        {
            default:
            case Rounding.TowardZero:
                mpz_tdiv_r_2exp(ref remainder.Value, ref Value, (mp_bitcnt_t)y);
                break;

            case Rounding.TowardPositiveInfinity:
                mpz_cdiv_r_2exp(ref remainder.Value, ref Value, (mp_bitcnt_t)y);
                break;

            case Rounding.TowardNegativeInfinity:
                mpz_fdiv_r_2exp(ref remainder.Value, ref Value, (mp_bitcnt_t)y);
                break;
        }

        return remainder;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="y">The divider.</param>
    public mpz_t DivExact(mpz_t y)
    {
        mpz_t quotient = new mpz_t();

        mpz_divexact(ref quotient.Value, ref Value, ref y.Value);

        return quotient;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="y">The divider.</param>
    public mpz_t DivExact(ulong y)
    {
        mpz_t quotient = new mpz_t();

        mpz_divexact_ui(ref quotient.Value, ref Value, (mpir_ui)y);

        return quotient;
    }

    /// <summary>
    /// Gets a value indicating whether the number can be exactly divided by another.
    /// </summary>
    /// <param name="y">The divider.</param>
    public bool IsDivisible(mpz_t y)
    {
        return mpz_divisible_p(ref Value, ref y.Value) != 0;
    }

    /// <summary>
    /// Gets a value indicating whether the number can be exactly divided by another.
    /// </summary>
    /// <param name="y">The divider.</param>
    public bool IsDivisible(ulong y)
    {
        return mpz_divisible_ui_p(ref Value, (mpir_ui)y) != 0;
    }

    /// <summary>
    /// Gets a value indicating whether the number can be exactly divided by the power of two of another.
    /// </summary>
    /// <param name="y">The power.</param>
    public bool IsDivisibleByPowerOfTwo(ulong y)
    {
        return mpz_divisible_2exp_p(ref Value, (mp_bitcnt_t)y) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="c">The c.</param>
    /// <param name="d">The d.</param>
    public bool IsCongruent(mpz_t c, mpz_t d)
    {
        return mpz_congruent_p(ref Value, ref c.Value, ref d.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="c">The c.</param>
    /// <param name="d">The d.</param>
    public bool IsCongruent(ulong c, ulong d)
    {
        return mpz_congruent_ui_p(ref Value, (mpir_ui)c, (mpir_ui)d) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="c">The c.</param>
    /// <param name="d">The d.</param>
    public bool IsCongruentPowerOfTwo(mpz_t c, long d)
    {
        return mpz_congruent_2exp_p(ref Value, ref c.Value, (mp_bitcnt_t)(ulong)d) != 0;
    }

    /// <summary>
    /// Gets the modulo of the number with a power of two.
    /// </summary>
    /// <param name="exp">The power.</param>
    /// <param name="mod">The modulo.</param>
    public mpz_t PowerMod(mpz_t exp, mpz_t mod)
    {
        mpz_t Result = new mpz_t();

        mpz_powm(ref Result.Value, ref Value, ref exp.Value, ref mod.Value);

        return Result;
    }

    /// <summary>
    /// Gets the modulo of the number with a power of two.
    /// </summary>
    /// <param name="exp">The power.</param>
    /// <param name="mod">The modulo.</param>
    public mpz_t PowerMod(ulong exp, mpz_t mod)
    {
        mpz_t Result = new mpz_t();

        mpz_powm_ui(ref Result.Value, ref Value, (mpir_ui)exp, ref mod.Value);

        return Result;
    }

    /// <summary>
    /// Gets the value of the number to a power.
    /// </summary>
    /// <param name="exp">The power.</param>
    public mpz_t Pow(ulong exp)
    {
        mpz_t Result = new mpz_t();

        mpz_pow_ui(ref Result.Value, ref Value, (mpir_ui)exp);

        return Result;
    }

    /// <summary>
    /// Gets a value indicating whether the number is an exact root.
    /// </summary>
    /// <param name="n">The root number.</param>
    public bool IsRootExact(ulong n)
    {
        using mpz_t Result = new mpz_t();

        return mpz_root(ref Result.Value, ref Value, (mpir_ui)n) != 0;
    }

    /// <summary>
    /// Gets the root of the number.
    /// </summary>
    /// <param name="n">The root.</param>
    public mpz_t NthRoot(ulong n)
    {
        mpz_t Result = new mpz_t();

        mpz_nthroot(ref Result.Value, ref Value, (mpir_ui)n);

        return Result;
    }

    /// <summary>
    /// Gets the nth root of a number.
    /// </summary>
    /// <param name="x">The number.</param>
    /// <param name="n">The nth.</param>
    /// <param name="root">The root.</param>
    /// <param name="remainder">The remainder.</param>
    public static void NthRoot(mpz_t x, ulong n, out mpz_t root, out mpz_t remainder)
    {
        root = new mpz_t();
        remainder = new mpz_t();

        mpz_rootrem(ref root.Value, ref remainder.Value, ref x.Value, (mpir_ui)n);
    }

    /// <summary>
    /// Gets the square root.
    /// </summary>
    public mpz_t Sqrt()
    {
        mpz_t Result = new mpz_t();

        mpz_sqrt(ref Result.Value, ref Value);

        return Result;
    }

    /// <summary>
    /// Gets the square root of a number.
    /// </summary>
    /// <param name="x">The number.</param>
    /// <param name="root">The root.</param>
    /// <param name="remainder">The remainder.</param>
    public static void SqrtRemainder(mpz_t x, out mpz_t root, out mpz_t remainder)
    {
        root = new mpz_t();
        remainder = new mpz_t();

        mpz_sqrtrem(ref root.Value, ref remainder.Value, ref x.Value);
    }

    /// <summary>
    /// Gets a value indicating whether the number is an exact power.
    /// </summary>
    public bool IsPerfectPower()
    {
        return mpz_perfect_power_p(ref Value) != 0;
    }

    /// <summary>
    /// Gets a value indicating whether the number is an exact square.
    /// </summary>
    public bool IsPerfectSquare()
    {
        return mpz_perfect_square_p(ref Value) != 0;
    }
}
