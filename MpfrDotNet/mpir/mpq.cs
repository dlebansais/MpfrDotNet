namespace MpirDotNet;

using System;
using System.Text;
using Interop.Mpir;

/// <summary>
/// See http://mpir.org/mpir-3.0.0.pdf.
/// </summary>
public static class mpq
{
    #region Initialization Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="dest_rational">The value.</param>
    public static void init(mpq_t dest_rational)
    {
        NativeMethods.mpq_init(ref dest_rational.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rationals">The values.</param>
    /// <exception cref="ArgumentNullException"><paramref name="rationals"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="rationals"/> contains a <see langword="null"/> item.</exception>
    public static void inits(params mpq_t[] rationals)
    {
        ArrayArgument.CheckItems(rationals, nameof(rationals));

        foreach (mpq_t Item in rationals)
            NativeMethods.mpq_init(ref Item.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rational_number">The values.</param>
    public static void clear(mpq_t rational_number)
    {
        NativeMethods.mpq_clear(ref rational_number.Value);

        // The disposal of the number must not free the memory a second time.
        rational_number.Value = default;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rationals">The values.</param>
    /// <exception cref="ArgumentNullException"><paramref name="rationals"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="rationals"/> contains a <see langword="null"/> item.</exception>
    public static void clears(params mpq_t[] rationals)
    {
        ArrayArgument.CheckItems(rationals, nameof(rationals));

        foreach (mpq_t Item in rationals)
            clear(Item);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void set(mpq_t rop, mpq_t op)
    {
        NativeMethods.mpq_set(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void set_z(mpq_t rop, mpz_t op)
    {
        NativeMethods.mpq_set_z(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void set_ui(mpq_t rop, ulong op1, ulong op2)
    {
        NativeMethods.mpq_set_ui(ref rop.Value, (NativeMethods.mpir_ui)op1, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void set_si(mpq_t rop, long op1, ulong op2)
    {
        NativeMethods.mpq_set_si(ref rop.Value, (NativeMethods.mpir_si)op1, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="str">The string.</param>
    /// <param name="strBase">The base.</param>
    /// <exception cref="ArgumentNullException"><paramref name="str"/> is <see langword="null"/>.</exception>
    /// <remarks>The result is <see langword="false"/> for a text with a NUL or a character outside ASCII, which cannot be a number.</remarks>
    public static bool set_str(mpq_t rop, string str, int strBase)
    {
        // The native function would dereference a null string.
        if (str is null)
            throw new ArgumentNullException(nameof(str));

        if (!MpirArgument.IsParsableText(str))
            return false;

        return NativeMethods.mpq_set_str(ref rop.Value, str, strBase) == 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop1">The first result operand.</param>
    /// <param name="rop2">The second result operand.</param>
    public static void swap(mpq_t rop1, mpq_t rop2)
    {
        NativeMethods.mpq_swap(ref rop1.Value, ref rop2.Value);
    }
    #endregion

    #region Conversion Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <exception cref="DivideByZeroException">The denominator of <paramref name="op"/> is zero.</exception>
    public static double get_d(mpq_t op)
    {
        // The native function divides by the denominator.
        MpirArgument.CheckDenominator(op);

        return NativeMethods.mpq_get_d(ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <exception cref="OverflowException"><paramref name="op"/> is NaN or an infinity.</exception>
    public static void set_d(mpq_t rop, double op)
    {
        DoubleArgument.CheckFinite(op);

        NativeMethods.mpq_set_d(ref rop.Value, op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void set_f(mpq_t rop, mpf_t op)
    {
        NativeMethods.mpq_set_f(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="str">The string.</param>
    /// <param name="strBase">The base.</param>
    /// <param name="op">The operand.</param>
    /// <remarks>The capacity of <paramref name="str"/> is increased to the size of the result, if needed.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="str"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="strBase"/> is not between 2 and 62, or between -36 and -2.</exception>
    public static void get_str(StringBuilder str, int strBase, mpq_t op)
    {
        // The native function writes as many characters as the value needs into the buffer allocated for the capacity,
        // and allocates a string that would leak when the buffer is null.
        if (str is null)
            throw new ArgumentNullException(nameof(str));

        uint DigitCountBase = DigitBase.ToDigitCountBase(strBase, nameof(strBase));
        ulong NumeratorDigits = (ulong)NativeMethods.mpz_sizeinbase(ref op.Value.Numerator, DigitCountBase);
        ulong DenominatorDigits = (ulong)NativeMethods.mpz_sizeinbase(ref op.Value.Denominator, DigitCountBase);

        // The digits, a minus sign, the slash and the terminating null character.
        _ = str.EnsureCapacity(checked((int)(NumeratorDigits + DenominatorDigits) + 3));

        NativeMethods.mpq_get_str(str, strBase, ref op.Value);
    }
    #endregion

    #region Arithmetic Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void add(mpq_t rop, mpq_t op1, mpq_t op2)
    {
        NativeMethods.mpq_add(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void sub(mpq_t rop, mpq_t op1, mpq_t op2)
    {
        NativeMethods.mpq_sub(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void mul(mpq_t rop, mpq_t op1, mpq_t op2)
    {
        NativeMethods.mpq_mul(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void mul_2exp(mpq_t rop, mpq_t op1, ulong op2)
    {
        NativeMethods.mpq_mul_2exp(ref rop.Value, ref op1.Value, (NativeMethods.mp_bitcnt_t)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <exception cref="DivideByZeroException"><paramref name="op2"/> is zero.</exception>
    public static void div(mpq_t rop, mpq_t op1, mpq_t op2)
    {
        MpirArgument.CheckDivisor(op2);

        NativeMethods.mpq_div(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void div_2exp(mpq_t rop, mpq_t op1, ulong op2)
    {
        NativeMethods.mpq_div_2exp(ref rop.Value, ref op1.Value, (NativeMethods.mp_bitcnt_t)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void neg(mpq_t rop, mpq_t op)
    {
        NativeMethods.mpq_neg(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void abs(mpq_t rop, mpq_t op)
    {
        NativeMethods.mpq_abs(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <exception cref="DivideByZeroException"><paramref name="op"/> is zero.</exception>
    public static void inv(mpq_t rop, mpq_t op)
    {
        MpirArgument.CheckDivisor(op);

        NativeMethods.mpq_inv(ref rop.Value, ref op.Value);
    }
    #endregion

    #region Comparison Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static int cmp(mpq_t op1, mpq_t op2)
    {
        return NativeMethods.mpq_cmp(ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static int cmp_z(mpq_t op1, mpz_t op2)
    {
        return NativeMethods.mpq_cmp_z(ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="num2">The numerator.</param>
    /// <param name="den2">The denominator.</param>
    /// <exception cref="DivideByZeroException"><paramref name="den2"/> is zero.</exception>
    public static int cmp_ui(mpq_t op1, ulong num2, ulong den2)
    {
        MpirArgument.CheckDenominator(den2);

        return NativeMethods.mpq_cmp_ui(ref op1.Value, (NativeMethods.mpir_ui)num2, (NativeMethods.mpir_ui)den2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="num2">The numerator.</param>
    /// <param name="den2">The denominator.</param>
    /// <exception cref="DivideByZeroException"><paramref name="den2"/> is zero.</exception>
    public static int cmp_si(mpq_t op1, long num2, ulong den2)
    {
        MpirArgument.CheckDenominator(den2);

        return NativeMethods.mpq_cmp_si(ref op1.Value, (NativeMethods.mpir_si)num2, (NativeMethods.mpir_ui)den2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static int sgn(mpq_t op)
    {
        return NativeMethods.mpq_sgn(ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static bool equal(mpq_t op1, mpq_t op2)
    {
        return NativeMethods.mpq_equal(ref op1.Value, ref op2.Value) != 0;
    }
    #endregion

    #region Applying Integer Functions to Rationals
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="numerator">The numerator.</param>
    /// <param name="rational">The value.</param>
    public static void get_num(mpz_t numerator, mpq_t rational)
    {
        NativeMethods.mpq_get_num(ref numerator.Value, ref rational.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="denominator">The denominator.</param>
    /// <param name="rational">The value.</param>
    public static void get_den(mpz_t denominator, mpq_t rational)
    {
        NativeMethods.mpq_get_den(ref denominator.Value, ref rational.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rational">The value.</param>
    /// <param name="numerator">The numerator.</param>
    public static void set_num(mpq_t rational, mpz_t numerator)
    {
        NativeMethods.mpq_set_num(ref rational.Value, ref numerator.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rational">The value.</param>
    /// <param name="denominator">The denominator.</param>
    public static void set_den(mpq_t rational, mpz_t denominator)
    {
        NativeMethods.mpq_set_den(ref rational.Value, ref denominator.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rational">The value.</param>
    /// <exception cref="DivideByZeroException">The denominator of <paramref name="rational"/> is zero.</exception>
    public static void canonicalize(mpq_t rational)
    {
        MpirArgument.CheckDenominator(rational);

        NativeMethods.mpq_canonicalize(ref rational.Value);
    }
    #endregion
}
