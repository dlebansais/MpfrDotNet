namespace MpfrDotNet;

using System;
using MpirDotNet;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public static partial class mpfr
{
    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static int cmp(mpfr_t op1, mpfr_t op2)
    {
        return mpfr_cmp(ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static int cmp_ui(mpfr_t op1, ulong op2)
    {
        return mpfr_cmp_ui(ref op1.Value, op2);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static int cmp_si(mpfr_t op1, long op2)
    {
        return mpfr_cmp_si(ref op1.Value, op2);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static int cmp_d(mpfr_t op1, double op2)
    {
        return mpfr_cmp_d(ref op1.Value, op2);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <exception cref="OverflowException"><paramref name="op2"/> has more bits than the widest exponent range of MPFR, which only happens on Windows.</exception>
    public static int cmp_z(mpfr_t op1, mpz_t op2)
    {
        CheckIntegerOperand(op2);

        return mpfr_cmp_z(ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <exception cref="OverflowException">The numerator or the denominator of <paramref name="op2"/> has more bits than the widest exponent range of MPFR, or the precision of <paramref name="op1"/> plus the bits of the denominator exceeds the maximum precision, which only happens on Windows.</exception>
    public static int cmp_q(mpfr_t op1, mpq_t op2)
    {
        CheckRationalOperand(op2);

        // mpfr_cmp_q multiplies op1 by the denominator exactly, in a number with the precision of op1 plus the bits of
        // the denominator, and aborts when this exceeds the maximum precision.
        ulong DenominatorBits = (ulong)Interop.Mpir.NativeMethods.mpz_sizeinbase(ref op2.Value.Denominator, 2);
        if (mpfr_regular_p(ref op1.Value) != 0 && get_prec(op1) + DenominatorBits > PrecisionMax)
            throw new OverflowException("The precision of the number plus the bits of the denominator exceed the maximum precision of MPFR.");

        return mpfr_cmp_q(ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static int cmp_f(mpfr_t op1, mpf_t op2)
    {
        // mpfr_cmp_f converts op2 with mpfr_set_f, which gets a wrong exponent for a number far below the exponent range
        // (see set_f). A regular op1 is farther from zero than such a number.
        if (mpfr_regular_p(ref op1.Value) != 0 && IsFarBelowExponentRange(op2))
            return mpfr_sgn(ref op1.Value);

        // See set_f.
        using mpf_t? Reduced = ReduceFloatOperand(op2, get_prec(op1));

        return mpfr_cmp_f(ref op1.Value, ref (Reduced ?? op2).Value);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="e">The exponent.</param>
    public static int cmp_ui_2exp(mpfr_t op1, ulong op2, int e)
    {
        return mpfr_cmp_ui_2exp(ref op1.Value, op2, ToCLong(e));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="e">The exponent.</param>
    public static int cmp_si_2exp(mpfr_t op1, long op2, int e)
    {
        return mpfr_cmp_si_2exp(ref op1.Value, op2, ToCLong(e));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static int cmpabs(mpfr_t op1, mpfr_t op2)
    {
        return mpfr_cmpabs(ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool nan_p(mpfr_t op)
    {
        return mpfr_nan_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool inf_p(mpfr_t op)
    {
        return mpfr_inf_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool number_p(mpfr_t op)
    {
        return mpfr_number_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool zero_p(mpfr_t op)
    {
        return mpfr_zero_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool regular_p(mpfr_t op)
    {
        return mpfr_regular_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static int sgn(mpfr_t op)
    {
        return mpfr_sgn(ref op.Value);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static bool greater_p(mpfr_t op1, mpfr_t op2)
    {
        return mpfr_greater_p(ref op1.Value, ref op2.Value) != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static bool greaterequal_p(mpfr_t op1, mpfr_t op2)
    {
        return mpfr_greaterequal_p(ref op1.Value, ref op2.Value) != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static bool less_p(mpfr_t op1, mpfr_t op2)
    {
        return mpfr_less_p(ref op1.Value, ref op2.Value) != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static bool lessequal_p(mpfr_t op1, mpfr_t op2)
    {
        return mpfr_lessequal_p(ref op1.Value, ref op2.Value) != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static bool equal_p(mpfr_t op1, mpfr_t op2)
    {
        return mpfr_equal_p(ref op1.Value, ref op2.Value) != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static bool lessgreater_p(mpfr_t op1, mpfr_t op2)
    {
        return mpfr_lessgreater_p(ref op1.Value, ref op2.Value) != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static bool unordered_p(mpfr_t op1, mpfr_t op2)
    {
        return mpfr_unordered_p(ref op1.Value, ref op2.Value) != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool total_order_p(mpfr_t x, mpfr_t y)
    {
        return mpfr_total_order_p(ref x.Value, ref y.Value) != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="op3">The third operand.</param>
    public static bool eq(mpfr_t op1, mpfr_t op2, uint op3)
    {
        return mpfr_eq(ref op1.Value, ref op2.Value, ToCULong(op3)) != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static void reldiff(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
    {
        mpfr_reldiff(ref rop.Value, ref op1.Value, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
    }
}
