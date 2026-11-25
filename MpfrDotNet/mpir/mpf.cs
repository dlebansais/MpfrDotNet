namespace MpirDotNet;

using System;
using System.Runtime.InteropServices;
using System.Text;
using Interop.Mpir;

/// <summary>
/// See http://mpir.org/mpir-3.0.0.pdf.
/// </summary>
public static class mpf
{
    #region Initialization Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="prec">The default precision.</param>
    public static void set_default_prec(ulong prec)
    {
        NativeMethods.mpf_set_default_prec((NativeMethods.mp_bitcnt_t)prec);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    public static ulong get_default_prec()
    {
        return (ulong)NativeMethods.mpf_get_default_prec();
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="x">The value.</param>
    public static void init(mpf_t x)
    {
        NativeMethods.mpf_init(ref x.Value);
        x.AllocatedPrecision = x.Value.Precision;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="x">The value.</param>
    /// <param name="prec">The precision.</param>
    public static void init2(mpf_t x, ulong prec)
    {
        NativeMethods.mpf_init2(ref x.Value, (NativeMethods.mp_bitcnt_t)prec);
        x.AllocatedPrecision = x.Value.Precision;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="floatings">Values.</param>
    /// <exception cref="ArgumentNullException"><paramref name="floatings"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="floatings"/> contains a <see langword="null"/> item.</exception>
    public static void inits(params mpf_t[] floatings)
    {
        ArrayArgument.CheckItems(floatings, nameof(floatings));

        foreach (mpf_t Item in floatings)
            init(Item);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="x">The value.</param>
    public static void clear(mpf_t x)
    {
        NativeMethods.mpf_clear(ref x.Value);

        // The disposal of x must not free the memory a second time.
        x.Value = default;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="floatings">Values.</param>
    /// <exception cref="ArgumentNullException"><paramref name="floatings"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="floatings"/> contains a <see langword="null"/> item.</exception>
    public static void clears(params mpf_t[] floatings)
    {
        ArrayArgument.CheckItems(floatings, nameof(floatings));

        foreach (mpf_t Item in floatings)
            clear(Item);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static ulong get_prec(mpf_t op)
    {
        return (ulong)NativeMethods.mpf_get_prec(ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="prec">The precision.</param>
    public static void set_prec(mpf_t op, ulong prec)
    {
        NativeMethods.mpf_set_prec(ref op.Value, (NativeMethods.mp_bitcnt_t)prec);
        op.AllocatedPrecision = op.Value.Precision;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="prec">The precision.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="prec"/> is greater than the precision allocated for <paramref name="op"/> by its initialization or by the last call to <see cref="set_prec"/>.</exception>
    public static void set_prec_raw(mpf_t op, ulong prec)
    {
        int PreviousPrecision = op.Value.Precision;
        NativeMethods.mpf_set_prec_raw(ref op.Value, (NativeMethods.mp_bitcnt_t)prec);

        // mpf_set_prec_raw only stores the precision, in limbs: a value above the allocated precision would make
        // the next operations write past the limbs.
        if (op.Value.Precision > op.AllocatedPrecision)
        {
            op.Value.Precision = PreviousPrecision;
            throw new ArgumentOutOfRangeException(nameof(prec), prec, "The precision cannot be greater than the allocated precision.");
        }
    }
    #endregion

    #region Assignment Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void set(mpf_t rop, mpf_t op)
    {
        NativeMethods.mpf_set(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void set_ui(mpf_t rop, ulong op)
    {
        NativeMethods.mpf_set_ui(ref rop.Value, (NativeMethods.mpir_ui)op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void set_si(mpf_t rop, long op)
    {
        NativeMethods.mpf_set_si(ref rop.Value, (NativeMethods.mpir_si)op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <exception cref="OverflowException"><paramref name="op"/> is NaN or an infinity.</exception>
    public static void set_d(mpf_t rop, double op)
    {
        DoubleArgument.CheckFinite(op);

        NativeMethods.mpf_set_d(ref rop.Value, op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void set_z(mpf_t rop, mpz_t op)
    {
        NativeMethods.mpf_set_z(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void set_q(mpf_t rop, mpq_t op)
    {
        NativeMethods.mpf_set_q(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="str">The string.</param>
    /// <param name="strbase">The base.</param>
    public static int set_str(mpf_t rop, string str, uint strbase)
    {
        return NativeMethods.mpf_set_str(ref rop.Value, str, strbase);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop1">The first result operand.</param>
    /// <param name="rop2">The second result operand.</param>
    public static void swap(mpf_t rop1, mpf_t rop2)
    {
        NativeMethods.mpf_swap(ref rop1.Value, ref rop2.Value);

        int AllocatedPrecision = rop1.AllocatedPrecision;
        rop1.AllocatedPrecision = rop2.AllocatedPrecision;
        rop2.AllocatedPrecision = AllocatedPrecision;
    }
    #endregion

    #region Combined Initialization and Assignment Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void init_set(mpf_t rop, mpf_t op)
    {
        NativeMethods.mpf_init_set(ref rop.Value, ref op.Value);
        rop.AllocatedPrecision = rop.Value.Precision;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void init_set_ui(mpf_t rop, ulong op)
    {
        NativeMethods.mpf_init_set_ui(ref rop.Value, (NativeMethods.mpir_ui)op);
        rop.AllocatedPrecision = rop.Value.Precision;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void init_set_si(mpf_t rop, long op)
    {
        NativeMethods.mpf_init_set_si(ref rop.Value, (NativeMethods.mpir_si)op);
        rop.AllocatedPrecision = rop.Value.Precision;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <exception cref="OverflowException"><paramref name="op"/> is NaN or an infinity.</exception>
    public static void init_set_d(mpf_t rop, double op)
    {
        DoubleArgument.CheckFinite(op);

        NativeMethods.mpf_init_set_d(ref rop.Value, op);
        rop.AllocatedPrecision = rop.Value.Precision;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="str">The string.</param>
    /// <param name="strbase">The base.</param>
    public static int init_set_str(mpf_t rop, string str, uint strbase)
    {
        int Result = NativeMethods.mpf_init_set_str(ref rop.Value, str, strbase);
        rop.AllocatedPrecision = rop.Value.Precision;

        return Result;
    }
    #endregion

    #region Conversion Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static double get_d(mpf_t op)
    {
        return NativeMethods.mpf_get_d(ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="d">The double value.</param>
    /// <param name="exp">The exponent.</param>
    public static void get_d_2exp(mpf_t op, out double d, out long exp)
    {
        d = NativeMethods.mpf_get_d_2exp(out CLong NativeExponent, ref op.Value);
        exp = NativeExponent.Value;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static ulong get_ui(mpf_t op)
    {
        return (ulong)NativeMethods.mpf_get_ui(ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static long get_si(mpf_t op)
    {
        return (long)NativeMethods.mpf_get_si(ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="str">The string.</param>
    /// <param name="expptr">The exponent.</param>
    /// <param name="strBase">The base.</param>
    /// <param name="n_digits">The count of digits.</param>
    /// <param name="op">The operand.</param>
    public static void get_str(StringBuilder str, out int expptr, int strBase, ulong n_digits, mpf_t op)
    {
        NativeMethods.mpf_get_str(str, out CLong NativeExponent, strBase, (NativeMethods.size_t)n_digits, ref op.Value);
        expptr = (int)NativeExponent.Value;
    }
    #endregion

    #region Arithmetic Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void add(mpf_t rop, mpf_t op1, mpf_t op2)
    {
        NativeMethods.mpf_add(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void add_ui(mpf_t rop, mpf_t op1, ulong op2)
    {
        NativeMethods.mpf_add_ui(ref rop.Value, ref op1.Value, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void sub(mpf_t rop, mpf_t op1, mpf_t op2)
    {
        NativeMethods.mpf_sub(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void ui_sub(mpf_t rop, ulong op1, mpf_t op2)
    {
        NativeMethods.mpf_ui_sub(ref rop.Value, (NativeMethods.mpir_ui)op1, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void sub_ui(mpf_t rop, mpf_t op1, ulong op2)
    {
        NativeMethods.mpf_sub_ui(ref rop.Value, ref op1.Value, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void mul(mpf_t rop, mpf_t op1, mpf_t op2)
    {
        NativeMethods.mpf_mul(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void mul_ui(mpf_t rop, mpf_t op1, ulong op2)
    {
        NativeMethods.mpf_mul_ui(ref rop.Value, ref op1.Value, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <exception cref="DivideByZeroException"><paramref name="op2"/> is zero.</exception>
    public static void div(mpf_t rop, mpf_t op1, mpf_t op2)
    {
        MpirArgument.CheckDivisor(op2);

        NativeMethods.mpf_div(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <exception cref="DivideByZeroException"><paramref name="op2"/> is zero.</exception>
    public static void ui_div(mpf_t rop, ulong op1, mpf_t op2)
    {
        MpirArgument.CheckDivisor(op2);

        NativeMethods.mpf_ui_div(ref rop.Value, (NativeMethods.mpir_ui)op1, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <exception cref="DivideByZeroException"><paramref name="op2"/> is zero.</exception>
    public static void div_ui(mpf_t rop, mpf_t op1, ulong op2)
    {
        MpirArgument.CheckDivisor(op2);

        NativeMethods.mpf_div_ui(ref rop.Value, ref op1.Value, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="op"/> is negative.</exception>
    public static void sqrt(mpf_t rop, mpf_t op)
    {
        MpirArgument.CheckNotNegative(op, nameof(op));

        NativeMethods.mpf_sqrt(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void sqrt_ui(mpf_t rop, ulong op)
    {
        NativeMethods.mpf_sqrt_ui(ref rop.Value, (NativeMethods.mpir_ui)op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void pow_ui(mpf_t rop, mpf_t op1, ulong op2)
    {
        NativeMethods.mpf_pow_ui(ref rop.Value, ref op1.Value, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void neg(mpf_t rop, mpf_t op)
    {
        NativeMethods.mpf_neg(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void abs(mpf_t rop, mpf_t op)
    {
        NativeMethods.mpf_abs(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void mul_2exp(mpf_t rop, mpf_t op1, ulong op2)
    {
        NativeMethods.mpf_mul_2exp(ref rop.Value, ref op1.Value, (NativeMethods.mp_bitcnt_t)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void div_2exp(mpf_t rop, mpf_t op1, ulong op2)
    {
        NativeMethods.mpf_div_2exp(ref rop.Value, ref op1.Value, (NativeMethods.mp_bitcnt_t)op2);
    }
    #endregion

    #region Conversion Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static int cmp(mpf_t op1, mpf_t op2)
    {
        return NativeMethods.mpf_cmp(ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <exception cref="ArgumentException"><paramref name="op2"/> is NaN.</exception>
    public static int cmp_d(mpf_t op1, double op2)
    {
        DoubleArgument.CheckNotNaN(op2, nameof(op2));

        return NativeMethods.mpf_cmp_d(ref op1.Value, op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static int cmp_si(mpf_t op1, long op2)
    {
        return NativeMethods.mpf_cmp_si(ref op1.Value, (NativeMethods.mpir_si)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static int cmp_ui(mpf_t op1, ulong op2)
    {
        return NativeMethods.mpf_cmp_ui(ref op1.Value, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <param name="op3">The third operand.</param>
    public static int eq(mpf_t op1, mpf_t op2, ulong op3)
    {
        return NativeMethods.mpf_eq(ref op1.Value, ref op2.Value, (NativeMethods.mp_bitcnt_t)op3);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void reldiff(mpf_t rop, mpf_t op1, mpf_t op2)
    {
        NativeMethods.mpf_reldiff(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static int sgn(mpf_t op)
    {
        return NativeMethods.mpf_sgn(ref op.Value);
    }
    #endregion

    #region Miscellaneous Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void ceil(mpf_t rop, mpf_t op)
    {
        NativeMethods.mpf_ceil(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void floor(mpf_t rop, mpf_t op)
    {
        NativeMethods.mpf_floor(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void trunc(mpf_t rop, mpf_t op)
    {
        NativeMethods.mpf_trunc(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool integer_p(mpf_t op)
    {
        return NativeMethods.mpf_integer_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool fits_ulong_p(mpf_t op)
    {
        return NativeMethods.mpf_fits_ulong_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool fits_slong_p(mpf_t op)
    {
        return NativeMethods.mpf_fits_slong_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool fits_uint_p(mpf_t op)
    {
        return NativeMethods.mpf_fits_uint_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool fits_sint_p(mpf_t op)
    {
        return NativeMethods.mpf_fits_sint_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool fits_ushort_p(mpf_t op)
    {
        return NativeMethods.mpf_fits_ushort_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool fits_sshort_p(mpf_t op)
    {
        return NativeMethods.mpf_fits_sshort_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="state">The state.</param>
    /// <param name="nbits">The count of bits.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="state"/> is disposed.</exception>
    public static void urandomb(mpf_t rop, randstate_t state, ulong nbits)
    {
        state.ThrowIfDisposed();

        NativeMethods.mpf_urandomb(ref rop.Value, ref state.Value, (NativeMethods.mp_bitcnt_t)nbits);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="state">The state.</param>
    /// <param name="max_size">The max size.</param>
    /// <param name="exp">The exponent.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="state"/> is disposed.</exception>
    /// <exception cref="PlatformNotSupportedException">The process does not run on Windows: this function exists in MPIR but not in GMP.</exception>
    public static void rrandomb(mpf_t rop, randstate_t state, ulong max_size, int exp)
    {
        state.ThrowIfDisposed();

        ThrowIfNotMpir(NativeMethods.IsMpir, nameof(NativeMethods.mpf_rrandomb));

        NativeMethods.mpf_rrandomb(ref rop.Value, ref state.Value, (NativeMethods.size_t)max_size, new CLong(exp));
    }

    /// <summary>
    /// Checks that a function that exists in MPIR but not in GMP can be called.
    /// </summary>
    /// <param name="isMpir">True if the native library is MPIR, false if it is GMP.</param>
    /// <param name="functionName">The name of the native function.</param>
    /// <exception cref="PlatformNotSupportedException"><paramref name="isMpir"/> is <see langword="false"/>.</exception>
    internal static void ThrowIfNotMpir(bool isMpir, string functionName)
    {
        if (!isMpir)
            throw new PlatformNotSupportedException($"{functionName} is only available with MPIR, on Windows.");
    }
    #endregion
}
