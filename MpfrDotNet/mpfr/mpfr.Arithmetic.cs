namespace MpfrDotNet;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using MpirDotNet;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public static partial class mpfr
{
    #region Add
    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int add(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
    {
        return mpfr_add(ref rop.Value, ref op1.Value, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int add_ui(mpfr_t rop, mpfr_t op1, ulong op2, mpfr_rnd_t rnd)
    {
        return mpfr_add_ui(ref rop.Value, ref op1.Value, op2, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int add_si(mpfr_t rop, mpfr_t op1, long op2, mpfr_rnd_t rnd)
    {
        return mpfr_add_si(ref rop.Value, ref op1.Value, op2, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int add_d(mpfr_t rop, mpfr_t op1, double op2, mpfr_rnd_t rnd)
    {
        return mpfr_add_d(ref rop.Value, ref op1.Value, op2, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="OverflowException"><paramref name="op2"/> has more bits than the widest exponent range of MPFR, which only happens on Windows.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int add_z(mpfr_t rop, mpfr_t op1, mpz_t op2, mpfr_rnd_t rnd)
    {
        CheckIntegerOperand(op2);

        return mpfr_add_z(ref rop.Value, ref op1.Value, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="OverflowException">The numerator or the denominator of <paramref name="op2"/>, plus the precisions of <paramref name="rop"/> and <paramref name="op1"/>, has more bits than half the widest exponent range of MPFR, which only happens on Windows.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int add_q(mpfr_t rop, mpfr_t op1, mpq_t op2, mpfr_rnd_t rnd)
    {
        CheckRationalSumOperand(rop, op1, op2);
        __mpfr_rnd_t NativeRounding = ToNativeRounding(rnd, nameof(rnd));

        if (IsInTopBinade(op1))
            return HalvedRationalSum(rop, op1, op2, NativeRounding, isSubtraction: false);

        return mpfr_add_q(ref rop.Value, ref op1.Value, ref op2.Value, NativeRounding);
    }
    #endregion

    #region Sub
    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int sub(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
    {
        return mpfr_sub(ref rop.Value, ref op1.Value, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int ui_sub(mpfr_t rop, ulong op1, mpfr_t op2, mpfr_rnd_t rnd)
    {
        return mpfr_ui_sub(ref rop.Value, op1, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int sub_ui(mpfr_t rop, mpfr_t op1, ulong op2, mpfr_rnd_t rnd)
    {
        return mpfr_sub_ui(ref rop.Value, ref op1.Value, op2, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int si_sub(mpfr_t rop, long op1, mpfr_t op2, mpfr_rnd_t rnd)
    {
        return mpfr_si_sub(ref rop.Value, op1, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int sub_si(mpfr_t rop, mpfr_t op1, long op2, mpfr_rnd_t rnd)
    {
        return mpfr_sub_si(ref rop.Value, ref op1.Value, op2, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int d_sub(mpfr_t rop, double op1, mpfr_t op2, mpfr_rnd_t rnd)
    {
        return mpfr_d_sub(ref rop.Value, op1, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int sub_d(mpfr_t rop, mpfr_t op1, double op2, mpfr_rnd_t rnd)
    {
        return mpfr_sub_d(ref rop.Value, ref op1.Value, op2, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="OverflowException"><paramref name="op1"/> has more bits than the widest exponent range of MPFR, which only happens on Windows.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int z_sub(mpfr_t rop, mpz_t op1, mpfr_t op2, mpfr_rnd_t rnd)
    {
        CheckIntegerOperand(op1);

        return mpfr_z_sub(ref rop.Value, ref op1.Value, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="OverflowException"><paramref name="op2"/> has more bits than the widest exponent range of MPFR, which only happens on Windows.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int sub_z(mpfr_t rop, mpfr_t op1, mpz_t op2, mpfr_rnd_t rnd)
    {
        CheckIntegerOperand(op2);

        return mpfr_sub_z(ref rop.Value, ref op1.Value, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="OverflowException">The numerator or the denominator of <paramref name="op2"/>, plus the precisions of <paramref name="rop"/> and <paramref name="op1"/>, has more bits than half the widest exponent range of MPFR, which only happens on Windows.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int sub_q(mpfr_t rop, mpfr_t op1, mpq_t op2, mpfr_rnd_t rnd)
    {
        CheckRationalSumOperand(rop, op1, op2);
        __mpfr_rnd_t NativeRounding = ToNativeRounding(rnd, nameof(rnd));

        if (IsInTopBinade(op1))
            return HalvedRationalSum(rop, op1, op2, NativeRounding, isSubtraction: true);

        return mpfr_sub_q(ref rop.Value, ref op1.Value, ref op2.Value, NativeRounding);
    }
    #endregion

    #region Mul
    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    /// <exception cref="OverflowException"><paramref name="op1"/> and <paramref name="op2"/> are regular, and their precisions add up to more than the maximum precision of MPFR, which only happens on Windows.</exception>
    public static int mul(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
    {
        CheckProduct(op1, op2);

        return mpfr_mul(ref rop.Value, ref op1.Value, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int mul_ui(mpfr_t rop, mpfr_t op1, ulong op2, mpfr_rnd_t rnd)
    {
        return mpfr_mul_ui(ref rop.Value, ref op1.Value, op2, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int mul_2ui(mpfr_t rop, mpfr_t op1, ulong op2, mpfr_rnd_t rnd)
    {
        return mpfr_mul_2ui(ref rop.Value, ref op1.Value, ToCULong(ClampToNativeShift(op2)), ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int mul_2si(mpfr_t rop, mpfr_t op1, long op2, mpfr_rnd_t rnd)
    {
        return mpfr_mul_2si(ref rop.Value, ref op1.Value, ToNativeExponent(op2), ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int mul_si(mpfr_t rop, mpfr_t op1, long op2, mpfr_rnd_t rnd)
    {
        return mpfr_mul_si(ref rop.Value, ref op1.Value, op2, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int mul_d(mpfr_t rop, mpfr_t op1, double op2, mpfr_rnd_t rnd)
    {
        return mpfr_mul_d(ref rop.Value, ref op1.Value, op2, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="OverflowException"><paramref name="op2"/> has more bits than the widest exponent range of MPFR, or <paramref name="op1"/> is regular, <paramref name="op2"/> is not zero, and the precision of <paramref name="op1"/> and the bits of <paramref name="op2"/> (at least 64) add up to more than the maximum precision, which only happens on Windows.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int mul_z(mpfr_t rop, mpfr_t op1, mpz_t op2, mpfr_rnd_t rnd)
    {
        CheckIntegerOperand(op2);
        CheckIntegerProduct(op1, op2);

        return mpfr_mul_z(ref rop.Value, ref op1.Value, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="OverflowException"><paramref name="op2"/> has more bits than the widest exponent range of MPFR, or the precision of <paramref name="op1"/> plus the bits of the numerator of <paramref name="op2"/> exceeds the maximum precision, which only happens on Windows.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int mul_q(mpfr_t rop, mpfr_t op1, mpq_t op2, mpfr_rnd_t rnd)
    {
        CheckRationalOperand(op2);
        CheckRationalScaling(op1, op2, isDivision: false);

        return mpfr_mul_q(ref rop.Value, ref op1.Value, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
    }
    #endregion

    #region Div
    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int div(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
    {
        return mpfr_div(ref rop.Value, ref op1.Value, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int ui_div(mpfr_t rop, ulong op1, mpfr_t op2, mpfr_rnd_t rnd)
    {
        return mpfr_ui_div(ref rop.Value, op1, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int div_ui(mpfr_t rop, mpfr_t op1, ulong op2, mpfr_rnd_t rnd)
    {
        return mpfr_div_ui(ref rop.Value, ref op1.Value, op2, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int div_2ui(mpfr_t rop, mpfr_t op1, ulong op2, mpfr_rnd_t rnd)
    {
        return mpfr_div_2ui(ref rop.Value, ref op1.Value, op2, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int div_2si(mpfr_t rop, mpfr_t op1, long op2, mpfr_rnd_t rnd)
    {
        return mpfr_div_2si(ref rop.Value, ref op1.Value, op2, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int si_div(mpfr_t rop, long op1, mpfr_t op2, mpfr_rnd_t rnd)
    {
        return mpfr_si_div(ref rop.Value, op1, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int div_si(mpfr_t rop, mpfr_t op1, long op2, mpfr_rnd_t rnd)
    {
        return mpfr_div_si(ref rop.Value, ref op1.Value, op2, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int d_div(mpfr_t rop, double op1, mpfr_t op2, mpfr_rnd_t rnd)
    {
        return mpfr_d_div(ref rop.Value, op1, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int div_d(mpfr_t rop, mpfr_t op1, double op2, mpfr_rnd_t rnd)
    {
        return mpfr_div_d(ref rop.Value, ref op1.Value, op2, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="OverflowException"><paramref name="op2"/> has more bits than the widest exponent range of MPFR, which only happens on Windows.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int div_z(mpfr_t rop, mpfr_t op1, mpz_t op2, mpfr_rnd_t rnd)
    {
        CheckIntegerOperand(op2);

        return mpfr_div_z(ref rop.Value, ref op1.Value, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="OverflowException"><paramref name="op2"/> has more bits than the widest exponent range of MPFR, or the precision of <paramref name="op1"/> plus the bits of the denominator of <paramref name="op2"/> exceeds the maximum precision, which only happens on Windows.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int div_q(mpfr_t rop, mpfr_t op1, mpq_t op2, mpfr_rnd_t rnd)
    {
        CheckRationalOperand(op2);
        CheckRationalScaling(op1, op2, isDivision: true);

        return mpfr_div_q(ref rop.Value, ref op1.Value, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
    }
    #endregion

    #region Pow
    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    /// <exception cref="OverflowException"><paramref name="op"/> is regular, and twice its precision add up to more than the maximum precision of MPFR, which only happens on Windows.</exception>
    public static int sqr(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        CheckProduct(op, op);

        return mpfr_sqr(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int sqrt(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_sqrt(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int sqrt_ui(mpfr_t rop, ulong op, mpfr_rnd_t rnd)
    {
        return mpfr_sqrt_ui(ref rop.Value, op, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int rec_sqrt(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_rec_sqrt(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int cbrt(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_cbrt(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="n">The n.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int rootn_ui(mpfr_t rop, mpfr_t op, ulong n, mpfr_rnd_t rnd)
    {
        return mpfr_rootn_ui(ref rop.Value, ref op.Value, n, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="n">The n.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int rootn_si(mpfr_t rop, mpfr_t op, long n, mpfr_rnd_t rnd)
    {
        return mpfr_rootn_si(ref rop.Value, ref op.Value, n, ToNativeRounding(rnd, nameof(rnd)));
    }
    #endregion

    #region Misc
    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int neg(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_neg(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int abs(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
        return mpfr_abs(ref rop.Value, ref op.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int dim(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
    {
        return mpfr_dim(ref rop.Value, ref op1.Value, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int fac_ui(mpfr_t rop, ulong op, mpfr_rnd_t rnd)
    {
        return mpfr_fac_ui(ref rop.Value, op, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="op3">The third operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    /// <exception cref="OverflowException">The factors are regular, the term is a number, and the precisions of <paramref name="op1"/> and <paramref name="op2"/> add up to more than the maximum precision, which only happens on Windows.</exception>
    public static int fma(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_t op3, mpfr_rnd_t rnd)
    {
        CheckExactProduct(op1, op2, op3);

        return mpfr_fma(ref rop.Value, ref op1.Value, ref op2.Value, ref op3.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="op3">The third operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    /// <exception cref="OverflowException">The factors are regular, the term is a number, and the precisions of <paramref name="op1"/> and <paramref name="op2"/> add up to more than the maximum precision, which only happens on Windows.</exception>
    public static int fms(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_t op3, mpfr_rnd_t rnd)
    {
        CheckExactProduct(op1, op2, op3);

        return mpfr_fms(ref rop.Value, ref op1.Value, ref op2.Value, ref op3.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="op3">The third operand.</param>
    /// <param name="op4">The fourth operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int fmma(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_t op3, mpfr_t op4, mpfr_rnd_t rnd)
    {
        return mpfr_fmma(ref rop.Value, ref op1.Value, ref op2.Value, ref op3.Value, ref op4.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="op3">The third operand.</param>
    /// <param name="op4">The fourth operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int fmms(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_t op3, mpfr_t op4, mpfr_rnd_t rnd)
    {
        return mpfr_fmms(ref rop.Value, ref op1.Value, ref op2.Value, ref op3.Value, ref op4.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int hypot(mpfr_t rop, mpfr_t x, mpfr_t y, mpfr_rnd_t rnd)
    {
        return mpfr_hypot(ref rop.Value, ref x.Value, ref y.Value, ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="tab">The values.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentNullException"><paramref name="tab"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int sum(mpfr_t rop, mpfr_t[] tab, mpfr_rnd_t rnd)
    {
        if (tab is null)
            throw new ArgumentNullException(nameof(tab));

        __mpfr_rnd_t NativeRounding = ToNativeRounding(rnd, nameof(rnd));
        CULong Count = new((uint)tab.Length);

        using NativeNumberArray Values = new(tab);
        int Result = ComputeInDistinctResult(rop, tab, tab, x => mpfr_sum(ref x.Value, Values.Pointer, Count, NativeRounding));

        // The copies share the significands of the numbers, which must stay alive until the end of the call.
        GC.KeepAlive(tab);

        return Result;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="tab">The tab values.</param>
    /// <param name="b">The b values.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentNullException"><paramref name="tab"/> or <paramref name="b"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="tab"/> and <paramref name="b"/> do not have the same length.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    /// <exception cref="OverflowException">The precisions of two factors add up to more than the maximum precision of MPFR, or a product is beyond the widest exponent range of MPFR.</exception>
    /// <remarks>The products are computed in the widest exponent range, so that only the result is checked against the current range.</remarks>
    public static int dot(mpfr_t rop, mpfr_t[] tab, mpfr_t[] b, mpfr_rnd_t rnd)
    {
        if (tab is null)
            throw new ArgumentNullException(nameof(tab));

        if (b is null)
            throw new ArgumentNullException(nameof(b));

        if (tab.Length != b.Length)
            throw new ArgumentException("The two arrays must have the same length.", nameof(b));

        __mpfr_rnd_t NativeRounding = ToNativeRounding(rnd, nameof(rnd));

        // mpfr_dot computes each product exactly, with the sum of the precisions of its factors, then sums the products
        // with a single rounding. It aborts when a precision is too large, or when a product overflows or underflows,
        // which happens in the current exponent range even for a result within it. The same computation is done here,
        // with the products in the widest exponent range: the result is then checked against the current range.
        for (int i = 0; i < tab.Length; i++)
            if (get_prec(tab[i]) + get_prec(b[i]) > PrecisionMax)
                throw new OverflowException("The precisions of two factors add up to more than the maximum precision of MPFR.");

        List<mpfr_t> Products = new(tab.Length);

        try
        {
            for (int i = 0; i < tab.Length; i++)
                Products.Add(mpfr_t.CreateWithPrecision(get_prec(tab[i]) + get_prec(b[i]), nameof(b)));

            return InWidestExponentRange(rop, NativeRounding, () =>
            {
                for (int i = 0; i < tab.Length; i++)
                    MultiplyExactly(Products[i], tab[i], b[i]);

                return sum(rop, Products.ToArray(), rnd);
            });
        }
        finally
        {
            foreach (mpfr_t Product in Products)
                Product.Dispose();
        }
    }

    private static void MultiplyExactly(mpfr_t product, mpfr_t op1, mpfr_t op2)
    {
        // With the sum of the precisions, the product is inexact only when it overflows or underflows.
        if (mpfr_mul(ref product.Value, ref op1.Value, ref op2.Value, __mpfr_rnd_t.MPFR_RNDZ) != 0)
            throw new OverflowException("A product is beyond the widest exponent range of MPFR.");
    }

    /// <summary>
    /// Runs a computation in the widest exponent range, as MPFR does internally, then checks the result against the
    /// current range, so that only the result can overflow or underflow, with a single rounding.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <param name="compute">The computation, which returns the ternary value.</param>
    /// <returns>The ternary value.</returns>
    internal static int InWidestExponentRange(mpfr_t rop, __mpfr_rnd_t rnd, Func<int> compute)
    {
        // The exponent range is per thread.
        CLong MinExponent = mpfr_get_emin();
        CLong MaxExponent = mpfr_get_emax();
        int Ternary;

        _ = mpfr_set_emin(mpfr_get_emin_min());
        _ = mpfr_set_emax(mpfr_get_emax_max());

        try
        {
            Ternary = compute();
        }
        finally
        {
            _ = mpfr_set_emin(MinExponent);
            _ = mpfr_set_emax(MaxExponent);
        }

        return mpfr_check_range(ref rop.Value, Ternary, rnd);
    }

    /// <summary>
    /// Computes a result in a number distinct from the inputs.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="tab">The first inputs.</param>
    /// <param name="b">The second inputs.</param>
    /// <param name="compute">The computation, which returns the ternary value.</param>
    /// <returns>The ternary value.</returns>
    internal static int ComputeInDistinctResult(mpfr_t rop, mpfr_t[] tab, mpfr_t[] b, Func<mpfr_t, int> compute)
    {
        if (!IsAmong(rop, tab) && !IsAmong(rop, b))
            return compute(rop);

        // MPFR recognizes a result that is also an input by its address, which the copies of the inputs hide: the
        // result is computed separately, with the same precision, and copied exactly.
        using mpfr_t Result = mpfr_t.CreateWithPrecision(get_prec(rop), nameof(rop));
        int Ternary = compute(Result);
        _ = mpfr_set(ref rop.Value, ref Result.Value, __mpfr_rnd_t.MPFR_RNDN);

        return Ternary;
    }

    private static bool IsAmong(mpfr_t number, mpfr_t[] numbers)
    {
        foreach (mpfr_t Item in numbers)
            if (ReferenceEquals(Item, number))
                return true;

        return false;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int mul_2exp(mpfr_t rop, mpfr_t op1, ulong op2, mpfr_rnd_t rnd)
    {
        return mpfr_mul_2exp(ref rop.Value, ref op1.Value, ClampToNativeShift(op2), ToNativeRounding(rnd, nameof(rnd)));
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int div_2exp(mpfr_t rop, mpfr_t op1, ulong op2, mpfr_rnd_t rnd)
    {
        return mpfr_div_2exp(ref rop.Value, ref op1.Value, op2, ToNativeRounding(rnd, nameof(rnd)));
    }
    #endregion

    /// <summary>
    /// Checks that mpfr_mul_q or mpfr_div_q can multiply a number exactly by the numerator or the denominator of a rational operand.
    /// </summary>
    /// <param name="op1">The number.</param>
    /// <param name="op2">The rational operand.</param>
    /// <param name="isDivision"><see langword="true"/> for mpfr_div_q, which multiplies by the denominator; <see langword="false"/> for mpfr_mul_q, which multiplies by the numerator.</param>
    /// <exception cref="OverflowException">The precision of <paramref name="op1"/> plus the bits of the factor exceeds the maximum precision.</exception>
    internal static void CheckRationalScaling(mpfr_t op1, mpq_t op2, bool isDivision)
    {
        // Unless the numerator or the denominator is zero, MPFR multiplies op1 by the factor in a number with the
        // precision of op1 plus the bits of the factor, whatever the value of op1, then with mpfr_mul_z, and aborts
        // when either exceeds the maximum precision.
        ulong FactorPrecision = IntegerPrecision(ref isDivision ? ref op2.Value.Denominator : ref op2.Value.Numerator);
        if (get_prec(op1) + FactorPrecision > PrecisionMax &&
            op2.Value.Numerator.LimbCount != 0 &&
            op2.Value.Denominator.LimbCount != 0)
        {
            throw new OverflowException("The precision of the number plus the bits of the rational operand exceed the maximum precision of MPFR.");
        }
    }

    /// <summary>
    /// Checks that mpfr_mul or mpfr_sqr can multiply two numbers, which they do exactly before rounding.
    /// </summary>
    /// <param name="op1">The first factor.</param>
    /// <param name="op2">The second factor.</param>
    /// <exception cref="OverflowException">The factors are regular, and their precisions add up to more than the maximum precision.</exception>
    internal static void CheckProduct(mpfr_t op1, mpfr_t op2)
    {
        // MPFR aborts when the precisions of regular factors add up to more than the maximum precision.
        if (get_prec(op1) + get_prec(op2) > PrecisionMax &&
            mpfr_regular_p(ref op1.Value) != 0 &&
            mpfr_regular_p(ref op2.Value) != 0)
        {
            throw new OverflowException("The sum of the precisions of the factors exceeds the maximum precision of MPFR.");
        }
    }

    /// <summary>
    /// Checks that mpfr_mul_z can multiply a number by an integer, which it converts to a number first.
    /// </summary>
    /// <param name="op1">The number.</param>
    /// <param name="op2">The integer.</param>
    /// <exception cref="OverflowException">The number is regular, the integer is not zero, and the precision of the number and the precision of the integer add up to more than the maximum precision.</exception>
    internal static void CheckIntegerProduct(mpfr_t op1, mpz_t op2)
    {
        if (get_prec(op1) + IntegerPrecision(ref op2.Value) > PrecisionMax &&
            mpfr_regular_p(ref op1.Value) != 0 &&
            op2.Value.LimbCount != 0)
        {
            throw new OverflowException("The sum of the precisions of the factors exceeds the maximum precision of MPFR.");
        }
    }

    /// <summary>
    /// Gets the precision of the number that MPFR creates from an integer for an operation: its bits, and at least 64.
    /// </summary>
    /// <param name="op">The integer.</param>
    /// <returns>The precision.</returns>
    internal static ulong IntegerPrecision(ref Interop.Mpir.NativeMethods.__mpz_t op)
        => Math.Max((ulong)Interop.Mpir.NativeMethods.mpz_sizeinbase(ref op, 2), 64UL);

    /// <summary>
    /// Checks that mpfr_fma or mpfr_fms can compute the product of two operands exactly.
    /// </summary>
    /// <param name="op1">The first factor.</param>
    /// <param name="op2">The second factor.</param>
    /// <param name="op3">The term.</param>
    /// <exception cref="OverflowException">The factors are regular, the term is a number, and the precisions of the factors add up to more than the maximum precision.</exception>
    internal static void CheckExactProduct(mpfr_t op1, mpfr_t op2, mpfr_t op3)
    {
        // When the factors are regular and the term is a number, even zero, MPFR multiplies the factors (mpfr_mul, or
        // exactly in a number with the sum of their precisions), and aborts when this sum exceeds the maximum precision.
        if (get_prec(op1) + get_prec(op2) > PrecisionMax &&
            mpfr_regular_p(ref op1.Value) != 0 &&
            mpfr_regular_p(ref op2.Value) != 0 &&
            mpfr_number_p(ref op3.Value) != 0)
        {
            throw new OverflowException("The sum of the precisions of the factors exceeds the maximum precision of MPFR.");
        }
    }

    /// <summary>
    /// Checks that an integer operand can be converted by MPFR in its widest exponent range.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <exception cref="OverflowException"><paramref name="op"/> has too many bits.</exception>
    internal static void CheckIntegerOperand(mpz_t op)
        => CheckOperandBitCount((ulong)Interop.Mpir.NativeMethods.mpz_sizeinbase(ref op.Value, 2));

    /// <summary>
    /// Checks that the numerator and the denominator of a rational operand can be converted by MPFR in its widest exponent range.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <exception cref="OverflowException">The numerator or the denominator of <paramref name="op"/> has too many bits.</exception>
    internal static void CheckRationalOperand(mpq_t op)
    {
        CheckOperandBitCount((ulong)Interop.Mpir.NativeMethods.mpz_sizeinbase(ref op.Value.Numerator, 2));
        CheckOperandBitCount((ulong)Interop.Mpir.NativeMethods.mpz_sizeinbase(ref op.Value.Denominator, 2));
    }

    /// <summary>
    /// Checks that the sum of a number and a rational cannot overflow or underflow inside mpfr_add_q and mpfr_sub_q.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The number.</param>
    /// <param name="op2">The rational.</param>
    /// <exception cref="OverflowException">The numerator or the denominator of <paramref name="op2"/>, plus the precisions, has more bits than half the range.</exception>
    internal static void CheckRationalSumOperand(mpfr_t rop, mpfr_t op1, mpq_t op2)
    {
        // These functions also abort when their intermediate sum overflows or underflows in the widest range. Apart
        // from an op1 in the top binade, which HalvedRationalSum handles, it takes a rational of nearly the size of the
        // range, or of an ulp of op1 near the limits, once a margin for the working precision is added.
        ulong Precision = (2 * get_prec(rop)) + get_prec(op1) + 64;

        // A cancellation can also leave a sum of about 2^(-2N) for a denominator of N bits, so the bits are counted
        // twice: the numerator and the denominator must fit in half of the range.
        CheckOperandBitCount(2 * ((ulong)Interop.Mpir.NativeMethods.mpz_sizeinbase(ref op2.Value.Numerator, 2) + Precision));
        CheckOperandBitCount(2 * ((ulong)Interop.Mpir.NativeMethods.mpz_sizeinbase(ref op2.Value.Denominator, 2) + Precision));
    }

    /// <summary>
    /// Checks whether a number is in the binade just below the largest exponent of MPFR.
    /// </summary>
    /// <param name="op">The number.</param>
    /// <returns><see langword="true"/> if <paramref name="op"/> is in the top binade; otherwise, <see langword="false"/>.</returns>
    internal static bool IsInTopBinade(mpfr_t op)
        => mpfr_regular_p(ref op.Value) != 0 && mpfr_get_exp(ref op.Value).Value >= mpfr_get_emax_max().Value;

    /// <summary>
    /// Adds or subtracts a rational to a number in the top binade, as 2 * (op1 / 2 +/- op2 / 2).
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The number, in the top binade.</param>
    /// <param name="op2">The rational.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <param name="isSubtraction"><see langword="true"/> to subtract the rational; <see langword="false"/> to add it.</param>
    /// <returns>The ternary value.</returns>
    internal static int HalvedRationalSum(mpfr_t rop, mpfr_t op1, mpq_t op2, __mpfr_rnd_t rnd, bool isSubtraction)
    {
        // mpfr_add_q and mpfr_sub_q round the sum to a working precision before rounding it to rop, and abort when
        // that sum overflows, which a number this close to the largest one does with almost any rational. Halving
        // both operands is exact in the widest exponent range, whatever the range of the caller, and so is the final
        // doubling unless it overflows. The result is then checked against the range of the caller, as MPFR does.
        using mpfr_t HalfNumber = mpfr_t.CreateWithPrecision(get_prec(op1), nameof(op1));
        using mpq_t HalfRational = new();
        mpq.div_2exp(HalfRational, op2, 1UL);

        return InWidestExponentRange(rop, rnd, () =>
        {
            _ = mpfr_div_2ui(ref HalfNumber.Value, ref op1.Value, 1UL, __mpfr_rnd_t.MPFR_RNDN);

            int SumTernary = isSubtraction
                ? mpfr_sub_q(ref rop.Value, ref HalfNumber.Value, ref HalfRational.Value, rnd)
                : mpfr_add_q(ref rop.Value, ref HalfNumber.Value, ref HalfRational.Value, rnd);
            int OverflowTernary = mpfr_mul_2ui(ref rop.Value, ref rop.Value, new CULong(1U), rnd);

            return OverflowTernary != 0 ? OverflowTernary : SumTernary;
        });
    }

    /// <summary>
    /// Checks that an integer with a number of bits can be converted by MPFR in its widest exponent range.
    /// </summary>
    /// <param name="bitCount">The number of bits.</param>
    /// <exception cref="OverflowException"><paramref name="bitCount"/> reaches the largest exponent of MPFR.</exception>
    internal static void CheckOperandBitCount(ulong bitCount)
    {
        // MPFR aborts the process when such an operand overflows (gmp_op.c). Its largest exponent is 2^30 - 1 with the
        // 32-bit exponents of Windows, so this happens for integers of 128 MiB.
        if (bitCount >= (ulong)(long)mpfr_get_emax_max().Value)
            throw new OverflowException("The operand has too many bits for the exponent range of MPFR.");
    }
}
