namespace MpfrDotNet;

using System;
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
    /// <exception cref="OverflowException"><paramref name="op2"/> has more bits than the widest exponent range of MPFR, which only happens on Windows.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int add_q(mpfr_t rop, mpfr_t op1, mpq_t op2, mpfr_rnd_t rnd)
    {
        CheckRationalOperand(op2);

        return mpfr_add_q(ref rop.Value, ref op1.Value, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
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
    /// <exception cref="OverflowException"><paramref name="op2"/> has more bits than the widest exponent range of MPFR, which only happens on Windows.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int sub_q(mpfr_t rop, mpfr_t op1, mpq_t op2, mpfr_rnd_t rnd)
    {
        CheckRationalOperand(op2);

        return mpfr_sub_q(ref rop.Value, ref op1.Value, ref op2.Value, ToNativeRounding(rnd, nameof(rnd)));
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
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int sum(mpfr_t rop, mpfr_t[] tab, mpfr_rnd_t rnd)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="tab">The tab values.</param>
    /// <param name="b">The b values.</param>
    /// <param name="rnd">The rounding mode.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="rnd"/> is not a supported rounding mode.</exception>
    public static int dot(mpfr_t rop, mpfr_t[] tab, mpfr_t[] b, mpfr_rnd_t rnd)
    {
        throw new NotImplementedException();
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
