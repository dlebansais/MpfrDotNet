namespace MpirDotNet;

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Interop.Mpir;

/// <summary>
/// See http://mpir.org/mpir-3.0.0.pdf.
/// </summary>
public static class mpz
{
    #region Initialization Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="integer">The value.</param>
    public static void init(mpz_t integer)
    {
        NativeMethods.mpz_init(ref integer.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="integers">The values.</param>
    /// <exception cref="ArgumentNullException"><paramref name="integers"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="integers"/> contains a <see langword="null"/> item.</exception>
    public static void inits(params mpz_t[] integers)
    {
        ArrayArgument.CheckItems(integers, nameof(integers));

        foreach (mpz_t Item in integers)
            NativeMethods.mpz_init(ref Item.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="integer">The value.</param>
    /// <param name="n">The number of bits.</param>
    public static void init2(mpz_t integer, ulong n)
    {
        NativeMethods.mpz_init2(ref integer.Value, (NativeMethods.mp_bitcnt_t)n);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="integer">The value.</param>
    public static void clear(mpz_t integer)
    {
        NativeMethods.mpz_clear(ref integer.Value);

        // The disposal of the integer must not free the memory a second time.
        integer.Value = default;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="x">The values.</param>
    /// <exception cref="ArgumentNullException"><paramref name="x"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="x"/> contains a <see langword="null"/> item.</exception>
    public static void clears(params mpz_t[] x)
    {
        ArrayArgument.CheckItems(x, nameof(x));

        foreach (mpz_t Item in x)
            clear(Item);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="integer">The value.</param>
    /// <param name="n">The number of bits.</param>
    public static void realloc2(mpz_t integer, ulong n)
    {
        NativeMethods.mpz_realloc2(ref integer.Value, (NativeMethods.mp_bitcnt_t)n);
    }
    #endregion

    #region Assignment Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void set(mpz_t rop, mpz_t op)
    {
        NativeMethods.mpz_set(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void set_ui(mpz_t rop, ulong op)
    {
        NativeMethods.mpz_set_ui(ref rop.Value, (NativeMethods.mpir_ui)op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void set_si(mpz_t rop, long op)
    {
        NativeMethods.mpz_set_si(ref rop.Value, (NativeMethods.mpir_si)op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void set_ux(mpz_t rop, ulong op)
    {
        set_ux(rop, op, NativeMethods.IsMpir);
    }

    /// <summary>
    /// Calls mpz_set_ux, or its GMP equivalent.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="isMpir">True to call the MPIR function, false to call its GMP equivalent, which MPIR also exports.</param>
    internal static void set_ux(mpz_t rop, ulong op, bool isMpir)
    {
        // GMP has no _sx and _ux functions, but its long is 64-bit on Linux, like intmax_t.
        if (isMpir)
            NativeMethods.mpz_set_ux(ref rop.Value, (NativeMethods.uintmax_t)op);
        else
            NativeMethods.mpz_set_ui(ref rop.Value, (NativeMethods.mpir_ui)op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void set_sx(mpz_t rop, long op)
    {
        set_sx(rop, op, NativeMethods.IsMpir);
    }

    /// <summary>
    /// Calls mpz_set_sx, or its GMP equivalent.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="isMpir">True to call the MPIR function, false to call its GMP equivalent, which MPIR also exports.</param>
    internal static void set_sx(mpz_t rop, long op, bool isMpir)
    {
        // GMP has no _sx and _ux functions, but its long is 64-bit on Linux, like intmax_t.
        if (isMpir)
            NativeMethods.mpz_set_sx(ref rop.Value, (NativeMethods.intmax_t)op);
        else
            NativeMethods.mpz_set_si(ref rop.Value, (NativeMethods.mpir_si)op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <exception cref="OverflowException"><paramref name="op"/> is NaN or an infinity.</exception>
    public static void set_d(mpz_t rop, double op)
    {
        DoubleArgument.CheckFinite(op);

        NativeMethods.mpz_set_d(ref rop.Value, op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void set_q(mpz_t rop, mpq_t op)
    {
        NativeMethods.mpz_set_q(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void set_f(mpz_t rop, mpf_t op)
    {
        NativeMethods.mpz_set_f(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="str">The string.</param>
    /// <param name="strbase">The base.</param>
    public static int set_str(mpz_t rop, string str, uint strbase)
    {
        return NativeMethods.mpz_set_str(ref rop.Value, str, strbase);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop1">The first result operand.</param>
    /// <param name="rop2">The second result operand.</param>
    public static void swap(mpz_t rop1, mpz_t rop2)
    {
        NativeMethods.mpz_swap(ref rop1.Value, ref rop2.Value);
    }
    #endregion

    #region Combined Initialization and Assignment Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void init_set(mpz_t rop, mpz_t op)
    {
        NativeMethods.mpz_init_set(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void init_set_ui(mpz_t rop, ulong op)
    {
        NativeMethods.mpz_init_set_ui(ref rop.Value, (NativeMethods.mpir_ui)op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void init_set_si(mpz_t rop, long op)
    {
        NativeMethods.mpz_init_set_si(ref rop.Value, (NativeMethods.mpir_si)op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void init_set_ux(mpz_t rop, ulong op)
    {
        init_set_ux(rop, op, NativeMethods.IsMpir);
    }

    /// <summary>
    /// Calls mpz_init_set_ux, or its GMP equivalent.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="isMpir">True to call the MPIR function, false to call its GMP equivalent, which MPIR also exports.</param>
    internal static void init_set_ux(mpz_t rop, ulong op, bool isMpir)
    {
        // GMP has no _sx and _ux functions, but its long is 64-bit on Linux, like intmax_t.
        if (isMpir)
            NativeMethods.mpz_init_set_ux(ref rop.Value, (NativeMethods.uintmax_t)op);
        else
            NativeMethods.mpz_init_set_ui(ref rop.Value, (NativeMethods.mpir_ui)op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void init_set_sx(mpz_t rop, long op)
    {
        init_set_sx(rop, op, NativeMethods.IsMpir);
    }

    /// <summary>
    /// Calls mpz_init_set_sx, or its GMP equivalent.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="isMpir">True to call the MPIR function, false to call its GMP equivalent, which MPIR also exports.</param>
    internal static void init_set_sx(mpz_t rop, long op, bool isMpir)
    {
        // GMP has no _sx and _ux functions, but its long is 64-bit on Linux, like intmax_t.
        if (isMpir)
            NativeMethods.mpz_init_set_sx(ref rop.Value, (NativeMethods.intmax_t)op);
        else
            NativeMethods.mpz_init_set_si(ref rop.Value, (NativeMethods.mpir_si)op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <exception cref="OverflowException"><paramref name="op"/> is NaN or an infinity.</exception>
    public static void init_set_d(mpz_t rop, double op)
    {
        DoubleArgument.CheckFinite(op);

        NativeMethods.mpz_init_set_d(ref rop.Value, op);
    }
    #endregion

    #region Conversion Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static ulong get_ui(mpz_t op)
    {
        return (ulong)NativeMethods.mpz_get_ui(ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static long get_si(mpz_t op)
    {
        return (long)NativeMethods.mpz_get_si(ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static ulong get_ux(mpz_t op)
    {
        return get_ux(op, NativeMethods.IsMpir);
    }

    /// <summary>
    /// Calls mpz_get_ux, or its GMP equivalent.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="isMpir">True to call the MPIR function, false to call its GMP equivalent, which MPIR also exports.</param>
    internal static ulong get_ux(mpz_t op, bool isMpir)
    {
        // GMP has no _sx and _ux functions, but its long is 64-bit on Linux, like intmax_t.
        return isMpir ? (ulong)NativeMethods.mpz_get_ux(ref op.Value) : (ulong)NativeMethods.mpz_get_ui(ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static long get_sx(mpz_t op)
    {
        return get_sx(op, NativeMethods.IsMpir);
    }

    /// <summary>
    /// Calls mpz_get_sx, or its GMP equivalent.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="isMpir">True to call the MPIR function, false to call its GMP equivalent, which MPIR also exports.</param>
    internal static long get_sx(mpz_t op, bool isMpir)
    {
        // GMP has no _sx and _ux functions, but its long is 64-bit on Linux, like intmax_t.
        return isMpir ? (long)NativeMethods.mpz_get_sx(ref op.Value) : (long)NativeMethods.mpz_get_si(ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static double get_d(mpz_t op)
    {
        return NativeMethods.mpz_get_d(ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="d">The double.</param>
    /// <param name="exp">The exponent.</param>
    public static void get_d_2exp(mpz_t op, out double d, out long exp)
    {
        d = NativeMethods.mpz_get_d_2exp(out CLong NativeExponent, ref op.Value);
        exp = NativeExponent.Value;
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
    public static void get_str(StringBuilder str, int strBase, mpz_t op)
    {
        // The native function writes as many characters as the value needs into the buffer allocated for the capacity,
        // and allocates a string that would leak when the buffer is null.
        if (str is null)
            throw new ArgumentNullException(nameof(str));

        uint DigitCountBase = DigitBase.ToDigitCountBase(strBase, nameof(strBase));

        // The digits, a minus sign and the terminating null character.
        _ = str.EnsureCapacity(checked((int)sizeinbase(op, DigitCountBase) + 2));

        NativeMethods.mpz_get_str(str, strBase, ref op.Value);
    }
    #endregion

    #region Arithmetic Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void add(mpz_t rop, mpz_t op1, mpz_t op2)
    {
        NativeMethods.mpz_add(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void add_ui(mpz_t rop, mpz_t op1, ulong op2)
    {
        NativeMethods.mpz_add_ui(ref rop.Value, ref op1.Value, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void sub(mpz_t rop, mpz_t op1, mpz_t op2)
    {
        NativeMethods.mpz_sub(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void sub_ui(mpz_t rop, mpz_t op1, ulong op2)
    {
        NativeMethods.mpz_sub_ui(ref rop.Value, ref op1.Value, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void ui_sub(mpz_t rop, ulong op1, mpz_t op2)
    {
        NativeMethods.mpz_ui_sub(ref rop.Value, (NativeMethods.mpir_ui)op1, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void mul(mpz_t rop, mpz_t op1, mpz_t op2)
    {
        NativeMethods.mpz_mul(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void mul_si(mpz_t rop, mpz_t op1, long op2)
    {
        NativeMethods.mpz_mul_si(ref rop.Value, ref op1.Value, (NativeMethods.mpir_si)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void mul_ui(mpz_t rop, mpz_t op1, ulong op2)
    {
        NativeMethods.mpz_mul_ui(ref rop.Value, ref op1.Value, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void addmul(mpz_t rop, mpz_t op1, mpz_t op2)
    {
        NativeMethods.mpz_addmul(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void addmul_ui(mpz_t rop, mpz_t op1, ulong op2)
    {
        NativeMethods.mpz_addmul_ui(ref rop.Value, ref op1.Value, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void submul(mpz_t rop, mpz_t op1, mpz_t op2)
    {
        NativeMethods.mpz_submul(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void submul_ui(mpz_t rop, mpz_t op1, ulong op2)
    {
        NativeMethods.mpz_submul_ui(ref rop.Value, ref op1.Value, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void mul_2exp(mpz_t rop, mpz_t op1, ulong op2)
    {
        NativeMethods.mpz_mul_2exp(ref rop.Value, ref op1.Value, (NativeMethods.mp_bitcnt_t)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void neg(mpz_t rop, mpz_t op)
    {
        NativeMethods.mpz_neg(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void abs(mpz_t rop, mpz_t op)
    {
        NativeMethods.mpz_abs(ref rop.Value, ref op.Value);
    }
    #endregion

    #region Division Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="DivideByZeroException"><paramref name="d"/> is zero.</exception>
    public static void cdiv_q(mpz_t q, mpz_t n, mpz_t d)
    {
        MpirArgument.CheckDivisor(d);

        NativeMethods.mpz_cdiv_q(ref q.Value, ref n.Value, ref d.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="DivideByZeroException"><paramref name="d"/> is zero.</exception>
    public static void cdiv_r(mpz_t r, mpz_t n, mpz_t d)
    {
        MpirArgument.CheckDivisor(d);

        NativeMethods.mpz_cdiv_r(ref r.Value, ref n.Value, ref d.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="DivideByZeroException"><paramref name="d"/> is zero.</exception>
    public static void cdiv_qr(mpz_t q, mpz_t r, mpz_t n, mpz_t d)
    {
        MpirArgument.CheckDivisor(d);

        NativeMethods.mpz_cdiv_qr(ref q.Value, ref r.Value, ref n.Value, ref d.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="DivideByZeroException"><paramref name="d"/> is zero.</exception>
    public static ulong cdiv_q_ui(mpz_t q, mpz_t n, ulong d)
    {
        MpirArgument.CheckDivisor(d);

        return (ulong)NativeMethods.mpz_cdiv_q_ui(ref q.Value, ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="DivideByZeroException"><paramref name="d"/> is zero.</exception>
    public static ulong cdiv_r_ui(mpz_t r, mpz_t n, ulong d)
    {
        MpirArgument.CheckDivisor(d);

        return (ulong)NativeMethods.mpz_cdiv_r_ui(ref r.Value, ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="DivideByZeroException"><paramref name="d"/> is zero.</exception>
    public static ulong cdiv_qr_ui(mpz_t q, mpz_t r, mpz_t n, ulong d)
    {
        MpirArgument.CheckDivisor(d);

        return (ulong)NativeMethods.mpz_cdiv_qr_ui(ref q.Value, ref r.Value, ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="DivideByZeroException"><paramref name="d"/> is zero.</exception>
    public static ulong cdiv_ui(mpz_t n, ulong d)
    {
        MpirArgument.CheckDivisor(d);

        return (ulong)NativeMethods.mpz_cdiv_ui(ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="n">The n.</param>
    /// <param name="b">The b.</param>
    public static void cdiv_q_2exp(mpz_t q, mpz_t n, ulong b)
    {
        NativeMethods.mpz_cdiv_q_2exp(ref q.Value, ref n.Value, (NativeMethods.mp_bitcnt_t)b);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="b">The b.</param>
    public static void cdiv_r_2exp(mpz_t r, mpz_t n, ulong b)
    {
        NativeMethods.mpz_cdiv_r_2exp(ref r.Value, ref n.Value, (NativeMethods.mp_bitcnt_t)b);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="DivideByZeroException"><paramref name="d"/> is zero.</exception>
    public static void fdiv_q(mpz_t q, mpz_t n, mpz_t d)
    {
        MpirArgument.CheckDivisor(d);

        NativeMethods.mpz_fdiv_q(ref q.Value, ref n.Value, ref d.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="DivideByZeroException"><paramref name="d"/> is zero.</exception>
    public static void fdiv_r(mpz_t r, mpz_t n, mpz_t d)
    {
        MpirArgument.CheckDivisor(d);

        NativeMethods.mpz_fdiv_r(ref r.Value, ref n.Value, ref d.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="DivideByZeroException"><paramref name="d"/> is zero.</exception>
    public static void fdiv_qr(mpz_t q, mpz_t r, mpz_t n, mpz_t d)
    {
        MpirArgument.CheckDivisor(d);

        NativeMethods.mpz_fdiv_qr(ref q.Value, ref r.Value, ref n.Value, ref d.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="DivideByZeroException"><paramref name="d"/> is zero.</exception>
    public static ulong fdiv_q_ui(mpz_t q, mpz_t n, ulong d)
    {
        MpirArgument.CheckDivisor(d);

        return (ulong)NativeMethods.mpz_fdiv_q_ui(ref q.Value, ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="DivideByZeroException"><paramref name="d"/> is zero.</exception>
    public static ulong fdiv_r_ui(mpz_t r, mpz_t n, ulong d)
    {
        MpirArgument.CheckDivisor(d);

        return (ulong)NativeMethods.mpz_fdiv_r_ui(ref r.Value, ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="DivideByZeroException"><paramref name="d"/> is zero.</exception>
    public static ulong fdiv_qr_ui(mpz_t q, mpz_t r, mpz_t n, ulong d)
    {
        MpirArgument.CheckDivisor(d);

        return (ulong)NativeMethods.mpz_fdiv_qr_ui(ref q.Value, ref r.Value, ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="DivideByZeroException"><paramref name="d"/> is zero.</exception>
    public static ulong fdiv_ui(mpz_t n, ulong d)
    {
        MpirArgument.CheckDivisor(d);

        return (ulong)NativeMethods.mpz_fdiv_ui(ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="n">The n.</param>
    /// <param name="b">The b.</param>
    public static void fdiv_q_2exp(mpz_t q, mpz_t n, ulong b)
    {
        NativeMethods.mpz_fdiv_q_2exp(ref q.Value, ref n.Value, (NativeMethods.mp_bitcnt_t)b);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="b">The b.</param>
    public static void fdiv_r_2exp(mpz_t r, mpz_t n, ulong b)
    {
        NativeMethods.mpz_fdiv_r_2exp(ref r.Value, ref n.Value, (NativeMethods.mp_bitcnt_t)b);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="DivideByZeroException"><paramref name="d"/> is zero.</exception>
    public static void tdiv_q(mpz_t q, mpz_t n, mpz_t d)
    {
        MpirArgument.CheckDivisor(d);

        NativeMethods.mpz_tdiv_q(ref q.Value, ref n.Value, ref d.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="DivideByZeroException"><paramref name="d"/> is zero.</exception>
    public static void tdiv_r(mpz_t r, mpz_t n, mpz_t d)
    {
        MpirArgument.CheckDivisor(d);

        NativeMethods.mpz_tdiv_r(ref r.Value, ref n.Value, ref d.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="DivideByZeroException"><paramref name="d"/> is zero.</exception>
    public static void tdiv_qr(mpz_t q, mpz_t r, mpz_t n, mpz_t d)
    {
        MpirArgument.CheckDivisor(d);

        NativeMethods.mpz_tdiv_qr(ref q.Value, ref r.Value, ref n.Value, ref d.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="DivideByZeroException"><paramref name="d"/> is zero.</exception>
    public static ulong tdiv_q_ui(mpz_t q, mpz_t n, ulong d)
    {
        MpirArgument.CheckDivisor(d);

        return (ulong)NativeMethods.mpz_tdiv_q_ui(ref q.Value, ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="DivideByZeroException"><paramref name="d"/> is zero.</exception>
    public static ulong tdiv_r_ui(mpz_t r, mpz_t n, ulong d)
    {
        MpirArgument.CheckDivisor(d);

        return (ulong)NativeMethods.mpz_tdiv_r_ui(ref r.Value, ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="DivideByZeroException"><paramref name="d"/> is zero.</exception>
    public static ulong tdiv_qr_ui(mpz_t q, mpz_t r, mpz_t n, ulong d)
    {
        MpirArgument.CheckDivisor(d);

        return (ulong)NativeMethods.mpz_tdiv_qr_ui(ref q.Value, ref r.Value, ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="DivideByZeroException"><paramref name="d"/> is zero.</exception>
    public static ulong tdiv_ui(mpz_t n, ulong d)
    {
        MpirArgument.CheckDivisor(d);

        return (ulong)NativeMethods.mpz_tdiv_ui(ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="n">The n.</param>
    /// <param name="b">The b.</param>
    public static void tdiv_q_2exp(mpz_t q, mpz_t n, ulong b)
    {
        NativeMethods.mpz_tdiv_q_2exp(ref q.Value, ref n.Value, (NativeMethods.mp_bitcnt_t)b);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="b">The b.</param>
    public static void tdiv_r_2exp(mpz_t r, mpz_t n, ulong b)
    {
        NativeMethods.mpz_tdiv_r_2exp(ref r.Value, ref n.Value, (NativeMethods.mp_bitcnt_t)b);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="DivideByZeroException"><paramref name="d"/> is zero.</exception>
    public static void mod(mpz_t r, mpz_t n, mpz_t d)
    {
        MpirArgument.CheckDivisor(d);

        NativeMethods.mpz_mod(ref r.Value, ref n.Value, ref d.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="DivideByZeroException"><paramref name="d"/> is zero.</exception>
    public static void divexact(mpz_t q, mpz_t n, mpz_t d)
    {
        MpirArgument.CheckDivisor(d);

        NativeMethods.mpz_divexact(ref q.Value, ref n.Value, ref d.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="q">The q.</param>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    /// <exception cref="DivideByZeroException"><paramref name="d"/> is zero.</exception>
    public static void divexact_ui(mpz_t q, mpz_t n, ulong d)
    {
        MpirArgument.CheckDivisor(d);

        NativeMethods.mpz_divexact_ui(ref q.Value, ref n.Value, (NativeMethods.mpir_ui)d);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static bool divisible_p(mpz_t n, mpz_t d)
    {
        return NativeMethods.mpz_divisible_p(ref n.Value, ref d.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The n.</param>
    /// <param name="d">The d.</param>
    public static bool divisible_ui_p(mpz_t n, ulong d)
    {
        return NativeMethods.mpz_divisible_ui_p(ref n.Value, (NativeMethods.mpir_ui)d) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The n.</param>
    /// <param name="b">The b.</param>
    public static bool divisible_2exp_p(mpz_t n, ulong b)
    {
        return NativeMethods.mpz_divisible_2exp_p(ref n.Value, (NativeMethods.mp_bitcnt_t)b) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The n.</param>
    /// <param name="c">The c.</param>
    /// <param name="d">The d.</param>
    public static bool congruent_p(mpz_t n, mpz_t c, mpz_t d)
    {
        return NativeMethods.mpz_congruent_p(ref n.Value, ref c.Value, ref d.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The n.</param>
    /// <param name="c">The c.</param>
    /// <param name="d">The d.</param>
    public static bool congruent_ui_p(mpz_t n, ulong c, ulong d)
    {
        return NativeMethods.mpz_congruent_ui_p(ref n.Value, (NativeMethods.mpir_ui)c, (NativeMethods.mpir_ui)d) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The n.</param>
    /// <param name="c">The c.</param>
    /// <param name="b">The b.</param>
    public static bool congruent_2exp_p(mpz_t n, mpz_t c, ulong b)
    {
        return NativeMethods.mpz_congruent_2exp_p(ref n.Value, ref c.Value, (NativeMethods.mp_bitcnt_t)b) != 0;
    }
    #endregion

    #region Exponentiation Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="opBase">The operand base.</param>
    /// <param name="exp">The exponent.</param>
    /// <param name="mod">The mod.</param>
    /// <exception cref="DivideByZeroException"><paramref name="mod"/> is zero.</exception>
    /// <exception cref="ArithmeticException"><paramref name="exp"/> is negative and <paramref name="opBase"/> has no inverse modulo <paramref name="mod"/>.</exception>
    public static void powm(mpz_t rop, mpz_t opBase, mpz_t exp, mpz_t mod)
    {
        MpirArgument.CheckModularPower(opBase, exp, mod);

        NativeMethods.mpz_powm(ref rop.Value, ref opBase.Value, ref exp.Value, ref mod.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="opBase">The operand base.</param>
    /// <param name="exp">The exponent.</param>
    /// <param name="mod">The mod.</param>
    /// <exception cref="DivideByZeroException"><paramref name="mod"/> is zero.</exception>
    public static void powm_ui(mpz_t rop, mpz_t opBase, ulong exp, mpz_t mod)
    {
        MpirArgument.CheckDivisor(mod);

        NativeMethods.mpz_powm_ui(ref rop.Value, ref opBase.Value, (NativeMethods.mpir_ui)exp, ref mod.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="opBase">The operand base.</param>
    /// <param name="exp">The exponent.</param>
    public static void pow_ui(mpz_t rop, mpz_t opBase, ulong exp)
    {
        NativeMethods.mpz_pow_ui(ref rop.Value, ref opBase.Value, (NativeMethods.mpir_ui)exp);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="opBase">The operand base.</param>
    /// <param name="exp">The exponent.</param>
    public static void ui_pow_ui(mpz_t rop, ulong opBase, ulong exp)
    {
        NativeMethods.mpz_ui_pow_ui(ref rop.Value, (NativeMethods.mpir_ui)opBase, (NativeMethods.mpir_ui)exp);
    }
    #endregion

    #region Root Extraction Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="n">The n.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="n"/> is zero, or <paramref name="n"/> is even and <paramref name="op"/> is negative.</exception>
    public static bool root(mpz_t rop, mpz_t op, ulong n)
    {
        MpirArgument.CheckRoot(op, n, nameof(op), nameof(n));

        return NativeMethods.mpz_root(ref rop.Value, ref op.Value, (NativeMethods.mpir_ui)n) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="n">The n.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="n"/> is zero, or <paramref name="n"/> is even and <paramref name="op"/> is negative.</exception>
    public static void nthroot(mpz_t rop, mpz_t op, ulong n)
    {
        MpirArgument.CheckRoot(op, n, nameof(op), nameof(n));

        nthroot(rop, op, n, NativeMethods.IsMpir);
    }

    /// <summary>
    /// Calls mpz_nthroot, or its GMP equivalent.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="n">The n.</param>
    /// <param name="isMpir">True to call the MPIR function, false to call its GMP equivalent, which MPIR also exports.</param>
    internal static void nthroot(mpz_t rop, mpz_t op, ulong n, bool isMpir)
    {
        // GMP has no mpz_nthroot: mpz_root computes the same truncated root.
        if (isMpir)
            NativeMethods.mpz_nthroot(ref rop.Value, ref op.Value, (NativeMethods.mpir_ui)n);
        else
            _ = NativeMethods.mpz_root(ref rop.Value, ref op.Value, (NativeMethods.mpir_ui)n);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="root">The root.</param>
    /// <param name="rem">The remainder.</param>
    /// <param name="u">The u.</param>
    /// <param name="n">The n.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="n"/> is zero, or <paramref name="n"/> is even and <paramref name="u"/> is negative.</exception>
    public static void rootrem(mpz_t root, mpz_t rem, mpz_t u, ulong n)
    {
        MpirArgument.CheckRoot(u, n, nameof(u), nameof(n));

        NativeMethods.mpz_rootrem(ref root.Value, ref rem.Value, ref u.Value, (NativeMethods.mpir_ui)n);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="op"/> is negative.</exception>
    public static void sqrt(mpz_t rop, mpz_t op)
    {
        MpirArgument.CheckNotNegative(op, nameof(op));

        NativeMethods.mpz_sqrt(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop1">The first result operand.</param>
    /// <param name="rop2">The second result operand.</param>
    /// <param name="op">The operand.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="op"/> is negative.</exception>
    public static void sqrtrem(mpz_t rop1, mpz_t rop2, mpz_t op)
    {
        MpirArgument.CheckNotNegative(op, nameof(op));

        NativeMethods.mpz_sqrtrem(ref rop1.Value, ref rop2.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool perfect_power_p(mpz_t op)
    {
        return NativeMethods.mpz_perfect_power_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool perfect_square_p(mpz_t op)
    {
        return NativeMethods.mpz_perfect_square_p(ref op.Value) != 0;
    }
    #endregion

    #region Number Theoretic Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The value.</param>
    /// <param name="state">The state.</param>
    /// <param name="prob">The probability.</param>
    /// <param name="div">The divider.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="state"/> is disposed.</exception>
    public static bool probable_prime_p(mpz_t n, randstate_t state, int prob, ulong div)
    {
        state.ThrowIfDisposed();

        return probable_prime_p(n, state, prob, div, NativeMethods.IsMpir);
    }

    /// <summary>
    /// Calls mpz_probable_prime_p, or its GMP equivalent.
    /// </summary>
    /// <param name="n">The value.</param>
    /// <param name="state">The state.</param>
    /// <param name="prob">The probability.</param>
    /// <param name="div">The divider.</param>
    /// <param name="isMpir">True to call the MPIR function, false to call its GMP equivalent, which MPIR also exports.</param>
    internal static bool probable_prime_p(mpz_t n, randstate_t state, int prob, ulong div, bool isMpir)
    {
        // GMP has no mpz_probable_prime_p. Each Miller-Rabin round of mpz_probab_prime_p errs with a probability of at most 1/4,
        // so prob / 2 rounds bound the error by 2^-prob.
        if (isMpir)
            return NativeMethods.mpz_probable_prime_p(ref n.Value, ref state.Value, prob, (NativeMethods.mpir_ui)div) != 0;
        else
            return NativeMethods.mpz_probab_prime_p(ref n.Value, Math.Max(1, ProbabilityToRounds(prob))) != 0;
    }

    /// <summary>
    /// Gets the count of Miller-Rabin rounds that MPIR runs for a probability: one per 2 units, rounded up.
    /// </summary>
    /// <param name="prob">The probability exponent.</param>
    /// <returns>The count of rounds, computed without overflow for <see cref="int.MaxValue"/>.</returns>
    internal static int ProbabilityToRounds(int prob) => (prob / 2) + (prob % 2);

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="n">The value.</param>
    /// <param name="state">The state.</param>
    /// <param name="div">The divider.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="state"/> is disposed.</exception>
    public static bool likely_prime_p(mpz_t n, randstate_t state, ulong div)
    {
        state.ThrowIfDisposed();

        return likely_prime_p(n, state, div, NativeMethods.IsMpir);
    }

    /// <summary>
    /// Calls mpz_likely_prime_p, or its GMP equivalent.
    /// </summary>
    /// <param name="n">The value.</param>
    /// <param name="state">The state.</param>
    /// <param name="div">The divider.</param>
    /// <param name="isMpir">True to call the MPIR function, false to call its GMP equivalent, which MPIR also exports.</param>
    internal static bool likely_prime_p(mpz_t n, randstate_t state, ulong div, bool isMpir)
    {
        // GMP has no mpz_likely_prime_p: 25 rounds is the usual choice for mpz_probab_prime_p.
        if (isMpir)
            return NativeMethods.mpz_likely_prime_p(ref n.Value, ref state.Value, (NativeMethods.mpir_ui)div) != 0;
        else
            return NativeMethods.mpz_probab_prime_p(ref n.Value, 25) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="state">The state.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="state"/> is disposed.</exception>
    public static void next_prime_candidate(mpz_t rop, mpz_t op, randstate_t state)
    {
        state.ThrowIfDisposed();

        next_prime_candidate(rop, op, state, NativeMethods.IsMpir);
    }

    /// <summary>
    /// Calls mpz_next_prime_candidate, or its GMP equivalent.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="state">The state.</param>
    /// <param name="isMpir">True to call the MPIR function, false to call its GMP equivalent, which MPIR also exports.</param>
    internal static void next_prime_candidate(mpz_t rop, mpz_t op, randstate_t state, bool isMpir)
    {
        // GMP has no mpz_next_prime_candidate: mpz_nextprime returns the next probable prime, which is also a candidate.
        if (isMpir)
            NativeMethods.mpz_next_prime_candidate(ref rop.Value, ref op.Value, ref state.Value);
        else
            NativeMethods.mpz_nextprime(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void gcd(mpz_t rop, mpz_t op1, mpz_t op2)
    {
        NativeMethods.mpz_gcd(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static ulong gcd_ui(mpz_t rop, mpz_t op1, ulong op2)
    {
        return (ulong)NativeMethods.mpz_gcd_ui(ref rop.Value, ref op1.Value, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="g">The g.</param>
    /// <param name="s">The s.</param>
    /// <param name="t">The t.</param>
    /// <param name="a">The a.</param>
    /// <param name="b">The b.</param>
    public static void gcdext(mpz_t g, mpz_t s, mpz_t t, mpz_t a, mpz_t b)
    {
        NativeMethods.mpz_gcdext(ref g.Value, ref s.Value, ref t.Value, ref a.Value, ref b.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void lcm(mpz_t rop, mpz_t op1, mpz_t op2)
    {
        NativeMethods.mpz_lcm(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void lcm_ui(mpz_t rop, mpz_t op1, ulong op2)
    {
        NativeMethods.mpz_lcm_ui(ref rop.Value, ref op1.Value, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <exception cref="DivideByZeroException"><paramref name="op2"/> is zero.</exception>
    public static bool invert(mpz_t rop, mpz_t op1, mpz_t op2)
    {
        MpirArgument.CheckDivisor(op2);

        return NativeMethods.mpz_invert(ref rop.Value, ref op1.Value, ref op2.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="a">The a.</param>
    /// <param name="b">The b.</param>
    public static int jacobi(mpz_t a, mpz_t b)
    {
        return NativeMethods.mpz_jacobi(ref a.Value, ref b.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="a">The a.</param>
    /// <param name="b">The b.</param>
    public static int legendre(mpz_t a, mpz_t b)
    {
        return NativeMethods.mpz_jacobi(ref a.Value, ref b.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="a">The a.</param>
    /// <param name="b">The b.</param>
    public static int kronecker(mpz_t a, mpz_t b)
    {
        return NativeMethods.mpz_jacobi(ref a.Value, ref b.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="a">The a.</param>
    /// <param name="b">The b.</param>
    public static int kronecker_si(mpz_t a, long b)
    {
        return NativeMethods.mpz_kronecker_si(ref a.Value, (NativeMethods.mpir_si)b);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="a">The a.</param>
    /// <param name="b">The b.</param>
    public static int kronecker_ui(mpz_t a, ulong b)
    {
        return NativeMethods.mpz_kronecker_ui(ref a.Value, (NativeMethods.mpir_ui)b);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="a">The a.</param>
    /// <param name="b">The b.</param>
    public static int si_kronecker(long a, mpz_t b)
    {
        return NativeMethods.mpz_si_kronecker((NativeMethods.mpir_si)a, ref b.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="a">The a.</param>
    /// <param name="b">The b.</param>
    public static int ui_kronecker(ulong a, mpz_t b)
    {
        return NativeMethods.mpz_ui_kronecker((NativeMethods.mpir_ui)a, ref b.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <param name="f">The f.</param>
    /// <exception cref="DivideByZeroException"><paramref name="f"/> is zero.</exception>
    public static ulong remove(mpz_t rop, mpz_t op, mpz_t f)
    {
        MpirArgument.CheckDivisor(f);

        // MPIR accepts only a factor greater than 1, while GMP also accepts -1, 1 and negative factors: these cases
        // are computed here, with the results of GMP.
        if (cmpabs_ui(f, 1UL) == 0)
        {
            set(rop, op);
            return 0;
        }

        if (sgn(f) > 0)
            return (ulong)NativeMethods.mpz_remove(ref rop.Value, ref op.Value, ref f.Value);

        // op = f^k * rop = |f|^k * (-1)^k * rop.
        using mpz_t AbsoluteFactor = new();
        abs(AbsoluteFactor, f);

        ulong Count = (ulong)NativeMethods.mpz_remove(ref rop.Value, ref op.Value, ref AbsoluteFactor.Value);
        if (Count % 2 == 1)
            neg(rop, rop);

        return Count;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="n">The n.</param>
    public static void fac_ui(mpz_t rop, ulong n)
    {
        NativeMethods.mpz_fac_ui(ref rop.Value, (NativeMethods.unsignedlongint)n);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="n">The n.</param>
    public static void fac_ui2(mpz_t rop, ulong n)
    {
        NativeMethods.mpz_2fac_ui(ref rop.Value, (NativeMethods.unsignedlongint)n);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="n">The n.</param>
    /// <param name="m">The m.</param>
    public static void mfac_uiui(mpz_t rop, ulong n, ulong m)
    {
        NativeMethods.mpz_mfac_uiui(ref rop.Value, (NativeMethods.unsignedlongint)n, (NativeMethods.unsignedlongint)m);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="n">The n.</param>
    public static void primorial_ui(mpz_t rop, ulong n)
    {
        NativeMethods.mpz_primorial_ui(ref rop.Value, (NativeMethods.unsignedlongint)n);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="n">The n.</param>
    /// <param name="k">The k.</param>
    public static void bin_ui(mpz_t rop, mpz_t n, ulong k)
    {
        NativeMethods.mpz_bin_ui(ref rop.Value, ref n.Value, (NativeMethods.mpir_ui)k);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="n">The n.</param>
    /// <param name="k">The k.</param>
    public static void bin_uiui(mpz_t rop, ulong n, ulong k)
    {
        NativeMethods.mpz_bin_uiui(ref rop.Value, (NativeMethods.mpir_ui)n, (NativeMethods.mpir_ui)k);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="fn">The fn.</param>
    /// <param name="n">The n.</param>
    public static void fib_ui(mpz_t fn, ulong n)
    {
        NativeMethods.mpz_fib_ui(ref fn.Value, (NativeMethods.mpir_ui)n);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="fn">The fn.</param>
    /// <param name="fnsub1">The fnsub1.</param>
    /// <param name="n">The n.</param>
    public static void fib2_ui(mpz_t fn, mpz_t fnsub1, ulong n)
    {
        NativeMethods.mpz_fib2_ui(ref fn.Value, ref fnsub1.Value, (NativeMethods.mpir_ui)n);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="ln">The ln.</param>
    /// <param name="n">The n.</param>
    public static void lucnum_ui(mpz_t ln, ulong n)
    {
        NativeMethods.mpz_lucnum_ui(ref ln.Value, (NativeMethods.mpir_ui)n);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="ln">The ln.</param>
    /// <param name="lnsub1">The lnsub1.</param>
    /// <param name="n">The n.</param>
    public static void lucnum2_ui(mpz_t ln, mpz_t lnsub1, ulong n)
    {
        NativeMethods.mpz_lucnum2_ui(ref ln.Value, ref lnsub1.Value, (NativeMethods.mpir_ui)n);
    }
    #endregion

    #region Comparison Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static int cmp(mpz_t op1, mpz_t op2)
    {
        return NativeMethods.mpz_cmp(ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <exception cref="ArgumentException"><paramref name="op2"/> is NaN.</exception>
    public static int cmp_d(mpz_t op1, double op2)
    {
        DoubleArgument.CheckNotNaN(op2, nameof(op2));

        return NativeMethods.mpz_cmp_d(ref op1.Value, op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static int cmp_si(mpz_t op1, long op2)
    {
        return NativeMethods.mpz_cmp_si(ref op1.Value, (NativeMethods.mpir_si)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static int cmp_ui(mpz_t op1, ulong op2)
    {
        return NativeMethods.mpz_cmp_ui(ref op1.Value, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static int cmpabs(mpz_t op1, mpz_t op2)
    {
        return NativeMethods.mpz_cmpabs(ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    /// <exception cref="ArgumentException"><paramref name="op2"/> is NaN.</exception>
    public static int cmpabs_d(mpz_t op1, double op2)
    {
        DoubleArgument.CheckNotNaN(op2, nameof(op2));

        return NativeMethods.mpz_cmpabs_d(ref op1.Value, op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static int cmpabs_ui(mpz_t op1, ulong op2)
    {
        return NativeMethods.mpz_cmpabs_ui(ref op1.Value, (NativeMethods.mpir_ui)op2);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static int sgn(mpz_t op)
    {
        return NativeMethods.mpz_sgn(ref op.Value);
    }
    #endregion

    #region Logical and Bit Manipulation Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void and(mpz_t rop, mpz_t op1, mpz_t op2)
    {
        NativeMethods.mpz_and(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void ior(mpz_t rop, mpz_t op1, mpz_t op2)
    {
        NativeMethods.mpz_ior(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static void xor(mpz_t rop, mpz_t op1, mpz_t op2)
    {
        NativeMethods.mpz_xor(ref rop.Value, ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void com(mpz_t rop, mpz_t op)
    {
        NativeMethods.mpz_com(ref rop.Value, ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static ulong popcount(mpz_t op)
    {
        return (ulong)NativeMethods.mpz_popcount(ref op.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op1">The first operand.</param>
    /// <param name="op2">The second operand.</param>
    public static ulong hamdist(mpz_t op1, mpz_t op2)
    {
        return (ulong)NativeMethods.mpz_hamdist(ref op1.Value, ref op2.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="startingBit">The start bit.</param>
    public static ulong scan0(mpz_t op, ulong startingBit)
    {
        return (ulong)NativeMethods.mpz_scan0(ref op.Value, (NativeMethods.mp_bitcnt_t)startingBit);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="startingBit">The start bit.</param>
    public static ulong scan1(mpz_t op, ulong startingBit)
    {
        return (ulong)NativeMethods.mpz_scan1(ref op.Value, (NativeMethods.mp_bitcnt_t)startingBit);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="bitIndex">The bit index.</param>
    public static void setbit(mpz_t rop, ulong bitIndex)
    {
        NativeMethods.mpz_setbit(ref rop.Value, (NativeMethods.mp_bitcnt_t)bitIndex);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="bitIndex">The bit index.</param>
    public static void clrbit(mpz_t rop, ulong bitIndex)
    {
        NativeMethods.mpz_clrbit(ref rop.Value, (NativeMethods.mp_bitcnt_t)bitIndex);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="bitIndex">The bit index.</param>
    public static void combit(mpz_t rop, ulong bitIndex)
    {
        NativeMethods.mpz_combit(ref rop.Value, (NativeMethods.mp_bitcnt_t)bitIndex);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="bitIndex">The bit index.</param>
    public static bool tstbit(mpz_t op, ulong bitIndex)
    {
        return NativeMethods.mpz_tstbit(ref op.Value, (NativeMethods.mp_bitcnt_t)bitIndex) != 0;
    }
    #endregion

    #region  Input and Output Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="writer">The output stream.</param>
    /// <param name="strBase">The digit base.</param>
    /// <param name="op">The operand.</param>
    public static long out_str(StreamWriter writer, int strBase, mpz_t op)
    {
        if (strBase < 2 || strBase > 62)
            throw new ArgumentOutOfRangeException(nameof(strBase));

        StringBuilder Data = new();
        get_str(Data, strBase, op);

        string Content = Data.ToString();
        writer.Write(Content);

        return Content.Length;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="reader">The input stream.</param>
    /// <param name="strBase">The digit base.</param>
    public static long inp_str(mpz_t rop, StreamReader reader, int strBase)
    {
        string Content = reader.ReadToEnd();

        // rop is already initialized: mpz_init_set_str would leak its memory. As in MPIR, 0 means that the input is invalid.
        int Result = MpirArgument.IsParsableText(Content) ? NativeMethods.mpz_set_str(ref rop.Value, Content, (uint)strBase) : -1;

        return Result == 0 ? Content.Length : 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="content">The input string.</param>
    /// <param name="strBase">The digit base.</param>
    public static bool init_set_str(mpz_t rop, string content, uint strBase)
    {
        return NativeMethods.mpz_init_set_str(ref rop.Value, content, strBase) == 0;
    }

    /// <summary>
    /// Writes an integer in the raw format of mpz_out_raw: its size in bytes, as a 4-byte big-endian signed number that
    /// is negative for a negative integer, then its absolute value in big-endian order.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="writer">The output stream.</param>
    /// <param name="op">The operand.</param>
    /// <returns>The count of bytes written.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="writer"/> is <see langword="null"/>.</exception>
    public static long out_raw(BinaryWriter writer, mpz_t op)
    {
        if (writer is null)
            throw new ArgumentNullException(nameof(writer));

        int Sign = sgn(op);
        byte[] Magnitude = Sign == 0 ? Array.Empty<byte>() : new byte[((ulong)NativeMethods.mpz_sizeinbase(ref op.Value, 2) + 7) / 8];

        if (Magnitude.Length > 0)
            NativeMethods.mpz_export(Magnitude, out _, 1, (NativeMethods.size_t)sizeof(byte), 1, (NativeMethods.size_t)0UL, ref op.Value);

        int Size = Sign < 0 ? -Magnitude.Length : Magnitude.Length;
        byte[] Header = new byte[] { (byte)(Size >> 24), (byte)(Size >> 16), (byte)(Size >> 8), (byte)Size };

        writer.Write(Header);
        writer.Write(Magnitude);

        return Header.Length + Magnitude.Length;
    }

    /// <summary>
    /// Reads an integer in the raw format of mpz_out_raw, from the current position of the stream.
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="reader">The input stream.</param>
    /// <returns>The count of bytes read, or 0 if the stream ends before the integer does.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="reader"/> is <see langword="null"/>.</exception>
    public static long inp_raw(mpz_t rop, BinaryReader reader)
    {
        if (reader is null)
            throw new ArgumentNullException(nameof(reader));

        const int HeaderLength = 4;

        byte[] Header = reader.ReadBytes(HeaderLength);
        if (Header.Length < HeaderLength)
            return 0;

        int Size = (Header[0] << 24) | (Header[1] << 16) | (Header[2] << 8) | Header[3];
        if (Size == int.MinValue)
            return 0;

        int ByteCount = Math.Abs(Size);

        if (!TryReadBytes(reader, ByteCount, out byte[] Magnitude))
            return 0;

        NativeMethods.mpz_import(ref rop.Value, (NativeMethods.size_t)(ulong)Magnitude.Length, 1, (NativeMethods.size_t)sizeof(byte), 1, (NativeMethods.size_t)0UL, Magnitude);

        if (Size < 0)
            neg(rop, rop);

        return HeaderLength + ByteCount;
    }

    private static bool TryReadBytes(BinaryReader reader, int count, out byte[] bytes)
    {
        // The size comes from the stream: reading in chunks avoids allocating a large buffer for a stream that ends early.
        const int ChunkLength = 0x10000;

        using MemoryStream Buffer = new();

        while (Buffer.Length < count)
        {
            int Remaining = count - (int)Buffer.Length;
            byte[] Chunk = reader.ReadBytes(Math.Min(Remaining, ChunkLength));
            Buffer.Write(Chunk, 0, Chunk.Length);

            if (Chunk.Length == 0)
            {
                bytes = Array.Empty<byte>();
                return false;
            }
        }

        bytes = Buffer.ToArray();
        return true;
    }
    #endregion

    #region Integer Import and Export
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="count">The count.</param>
    /// <param name="order">The order.</param>
    /// <param name="size">The size.</param>
    /// <param name="endian">The endianess.</param>
    /// <param name="nails">The nails count.</param>
    /// <param name="op">The operand.</param>
    /// <exception cref="ArgumentNullException"><paramref name="op"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="size"/> is zero, <paramref name="nails"/> is not less than the bits of a word, or <paramref name="count"/> words of <paramref name="size"/> bytes do not fit in <paramref name="op"/>.</exception>
    public static void import(mpz_t rop, ulong count, int order, ulong size, int endian, ulong nails, byte[] op)
    {
        // The native function reads count * size bytes from op, whatever its length.
        if (op is null)
            throw new ArgumentNullException(nameof(op));

        CheckWordFormat(size, nails);

        if (count > (ulong)op.LongLength / size)
            throw new ArgumentOutOfRangeException(nameof(count), count, "The words do not fit in the array.");

        NativeMethods.mpz_import(ref rop.Value, (NativeMethods.size_t)count, order, (NativeMethods.size_t)size, endian, (NativeMethods.size_t)nails, op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="countp">The result count.</param>
    /// <param name="order">The order.</param>
    /// <param name="size">The size.</param>
    /// <param name="endian">The endianess.</param>
    /// <param name="nails">The nails count.</param>
    /// <param name="op">The operand.</param>
    /// <exception cref="ArgumentNullException"><paramref name="rop"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="size"/> is zero, or <paramref name="nails"/> is not less than the bits of a word.</exception>
    /// <exception cref="ArgumentException"><paramref name="rop"/> is too small for the words of <paramref name="op"/>.</exception>
    public static void export(byte[] rop, out ulong countp, int order, ulong size, int endian, ulong nails, mpz_t op)
    {
        // The native function writes as many words as the value needs, whatever the length of rop, and allocates
        // an array that would leak when rop is null.
        if (rop is null)
            throw new ArgumentNullException(nameof(rop));

        CheckWordFormat(size, nails);

        if (sgn(op) != 0 && (size > (ulong)rop.LongLength || ExportWordCount(op, size, nails) > (ulong)rop.LongLength / size))
            throw new ArgumentException("The array is too small for the value.", nameof(rop));

        NativeMethods.mpz_export(rop, out NativeMethods.size_t countpStruct, order, (NativeMethods.size_t)size, endian, (NativeMethods.size_t)nails, ref op.Value);
        countp = (ulong)countpStruct;
    }

    private static void CheckWordFormat(ulong size, ulong nails)
    {
        if (size == 0)
            throw new ArgumentOutOfRangeException(nameof(size), size, "The size of a word cannot be zero.");

        // nails >= 8 * size, computed without overflow.
        if (nails / 8 >= size)
            throw new ArgumentOutOfRangeException(nameof(nails), nails, "The nails must be fewer than the bits of a word.");
    }

    private static ulong ExportWordCount(mpz_t op, ulong size, ulong nails)
    {
        // size is at most the length of an array here, so 8 * size does not overflow.
        ulong WordBits = (8 * size) - nails;

        return (sizeinbase(op, 2) + WordBits - 1) / WordBits;
    }
    #endregion

    #region Random Number Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="state">The state.</param>
    /// <param name="n">The n.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="state"/> is disposed.</exception>
    public static void urandomb(mpz_t rop, randstate_t state, ulong n)
    {
        state.ThrowIfDisposed();

        NativeMethods.mpz_urandomb(ref rop.Value, ref state.Value, (NativeMethods.mp_bitcnt_t)n);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="state">The state.</param>
    /// <param name="n">The n.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="state"/> is disposed.</exception>
    /// <exception cref="DivideByZeroException"><paramref name="n"/> is zero.</exception>
    public static void urandomm(mpz_t rop, randstate_t state, mpz_t n)
    {
        state.ThrowIfDisposed();
        MpirArgument.CheckDivisor(n);

        NativeMethods.mpz_urandomm(ref rop.Value, ref state.Value, ref n.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="state">The state.</param>
    /// <param name="n">The n.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="state"/> is disposed.</exception>
    public static void rrandomb(mpz_t rop, randstate_t state, ulong n)
    {
        state.ThrowIfDisposed();

        NativeMethods.mpz_rrandomb(ref rop.Value, ref state.Value, (NativeMethods.mp_bitcnt_t)n);
    }
    #endregion

    #region Miscellaneous Functions
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool fits_ulong_p(mpz_t op)
    {
        return NativeMethods.mpz_fits_ulong_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool fits_slong_p(mpz_t op)
    {
        return NativeMethods.mpz_fits_slong_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool fits_uint_p(mpz_t op)
    {
        return NativeMethods.mpz_fits_uint_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool fits_sint_p(mpz_t op)
    {
        return NativeMethods.mpz_fits_sint_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool fits_ushort_p(mpz_t op)
    {
        return NativeMethods.mpz_fits_ushort_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool fits_sshort_p(mpz_t op)
    {
        return NativeMethods.mpz_fits_sshort_p(ref op.Value) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool odd_p(mpz_t op)
    {
        bool HasValidLimb = (op.Value.LimbCount != 0) & (op.Value.Limbs != System.IntPtr.Zero);
        if (!HasValidLimb)
            return false;

        return (System.Runtime.InteropServices.Marshal.ReadByte(op.Value.Limbs, 0) & 1) != 0;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    public static bool even_p(mpz_t op)
    {
        return !odd_p(op);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="resultbase">The result base.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="resultbase"/> is not between 2 and 62.</exception>
    public static ulong sizeinbase(mpz_t op, uint resultbase)
    {
        // GMP divides by zero for a base of 0 or 1, and reads past its table of bases beyond 256.
        if (resultbase is < 2 or > 62)
            throw new ArgumentOutOfRangeException(nameof(resultbase), resultbase, "The base must be between 2 and 62.");

        return (ulong)NativeMethods.mpz_sizeinbase(ref op.Value, resultbase);
    }
    #endregion
}
