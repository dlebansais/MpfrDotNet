namespace MpfrDotNet;

using System;
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
    public static int mul(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_rnd_t rnd)
    {
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
    /// <exception cref="OverflowException"><paramref name="op2"/> has more bits than the widest exponent range of MPFR, which only happens on Windows.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int mul_z(mpfr_t rop, mpfr_t op1, mpz_t op2, mpfr_rnd_t rnd)
    {
        CheckIntegerOperand(op2);

        return mpfr_mul_z(ref rop.Value, ref op1.Value, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
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
    public static int mul_q(mpfr_t rop, mpfr_t op1, mpq_t op2, mpfr_rnd_t rnd)
    {
        CheckRationalOperand(op2);

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
    /// <exception cref="OverflowException"><paramref name="op2"/> has more bits than the widest exponent range of MPFR, which only happens on Windows.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int div_q(mpfr_t rop, mpfr_t op1, mpq_t op2, mpfr_rnd_t rnd)
    {
        CheckRationalOperand(op2);

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
    public static int sqr(mpfr_t rop, mpfr_t op, mpfr_rnd_t rnd)
    {
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
    public static int fma(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_t op3, mpfr_rnd_t rnd)
    {
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
    public static int fms(mpfr_t rop, mpfr_t op1, mpfr_t op2, mpfr_t op3, mpfr_rnd_t rnd)
    {
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
    public static int dot(mpfr_t rop, mpfr_t[] tab, mpfr_t[] b, mpfr_rnd_t rnd)
    {
        if (tab is null)
            throw new ArgumentNullException(nameof(tab));

        if (b is null)
            throw new ArgumentNullException(nameof(b));

        if (tab.Length != b.Length)
            throw new ArgumentException("The two arrays must have the same length.", nameof(b));

        __mpfr_rnd_t NativeRounding = ToNativeRounding(rnd, nameof(rnd));
        ulong Count = (ulong)tab.Length;

        using NativeNumberArray First = new(tab);
        using NativeNumberArray Second = new(b);
        int Result = ComputeInDistinctResult(rop, tab, b, x => mpfr_dot(ref x.Value, First.Pointer, Second.Pointer, Count, NativeRounding));

        // The copies share the significands of the numbers, which must stay alive until the end of the call.
        GC.KeepAlive(tab);
        GC.KeepAlive(b);

        return Result;
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
        // both operands is exact, and the final doubling overflows like any other operation, with its flag and ternary.
        using mpfr_t HalfNumber = mpfr_t.CreateWithPrecision(get_prec(op1), nameof(op1));
        using mpq_t HalfRational = new();
        _ = mpfr_div_2ui(ref HalfNumber.Value, ref op1.Value, 1UL, __mpfr_rnd_t.MPFR_RNDN);
        mpq.div_2exp(HalfRational, op2, 1UL);

        int Ternary = isSubtraction
            ? mpfr_sub_q(ref rop.Value, ref HalfNumber.Value, ref HalfRational.Value, rnd)
            : mpfr_add_q(ref rop.Value, ref HalfNumber.Value, ref HalfRational.Value, rnd);
        int OverflowTernary = mpfr_mul_2ui(ref rop.Value, ref rop.Value, new CULong(1U), rnd);

        return OverflowTernary != 0 ? OverflowTernary : Ternary;
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
