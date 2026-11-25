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
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="prec"/> is greater than <see cref="MaxPrecision"/>.</exception>
    public static void set_default_prec(ulong prec)
    {
        CheckPrecision(prec, nameof(prec));

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
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="prec"/> is greater than <see cref="MaxPrecision"/>.</exception>
    public static void init2(mpf_t x, ulong prec)
    {
        CheckPrecision(prec, nameof(prec));

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
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="prec"/> is greater than <see cref="MaxPrecision"/>.</exception>
    public static void set_prec(mpf_t op, ulong prec)
    {
        CheckPrecision(prec, nameof(prec));

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
        // mpf_set_prec_raw only stores the precision, in limbs, in an int: a value above the allocated precision would
        // make the next operations write past the limbs. The count is computed here, before it can be truncated.
        if (PrecisionToLimbs(prec) > (ulong)op.AllocatedPrecision)
            throw new ArgumentOutOfRangeException(nameof(prec), prec, "The precision cannot be greater than the allocated precision.");

        NativeMethods.mpf_set_prec_raw(ref op.Value, (NativeMethods.mp_bitcnt_t)prec);
    }

    /// <summary>
    /// Gets the largest precision, in bits, whose count of limbs fits in the precision field of MPIR and GMP, which is an int.
    /// </summary>
    public static ulong MaxPrecision { get; } = ((ulong)int.MaxValue * LimbBits) - LimbBits;

    // The size of a limb, in bits, with MPIR on Windows and with GMP on 64-bit Linux.
    private const ulong LimbBits = 64;

    // The largest exponent that mpf_rrandomb accepts on Windows.
    private const int MaxRandomExponent = (1 << 30) - 1;

    /// <summary>
    /// Gets the count of limbs that MPIR and GMP use for a precision (__GMPF_BITS_TO_PREC).
    /// </summary>
    /// <param name="prec">The precision, in bits.</param>
    /// <returns>The count of limbs, which saturates instead of overflowing.</returns>
    internal static ulong PrecisionToLimbs(ulong prec)
    {
        ulong Bits = Math.Max(53UL, prec);

        return Bits > ulong.MaxValue - ((2 * LimbBits) - 1) ? ulong.MaxValue / LimbBits : (Bits + (2 * LimbBits) - 1) / LimbBits;
    }

    /// <summary>
    /// Checks that a precision can be stored by MPIR and GMP.
    /// </summary>
    /// <param name="prec">The precision, in bits.</param>
    /// <param name="paramName">The name of the parameter that holds the precision.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="prec"/> is greater than <see cref="MaxPrecision"/>.</exception>
    internal static void CheckPrecision(ulong prec, string paramName)
    {
        if (prec > MaxPrecision)
            throw new ArgumentOutOfRangeException(paramName, prec, $"The precision must be {MaxPrecision} or less.");
    }

    /// <summary>
    /// Gets the integer part of the logarithm in base 2 of a number.
    /// </summary>
    /// <param name="value">The number, greater than 0.</param>
    /// <returns>The logarithm.</returns>
    internal static ulong FloorLog2(uint value)
    {
        ulong Result = 0;

        while (value > 1)
        {
            value >>= 1;
            Result++;
        }

        return Result;
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
    /// <exception cref="ArgumentNullException"><paramref name="str"/> is <see langword="null"/>.</exception>
    /// <exception cref="OverflowException">The exponent in <paramref name="str"/> is beyond the range of a native long, which MPIR does not check: 2^31 - 1 on Windows.</exception>
    public static int set_str(mpf_t rop, string str, uint strbase)
    {
        // The native function would dereference a null string.
        if (str is null)
            throw new ArgumentNullException(nameof(str));

        CheckStringExponent(str, strbase);

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
    /// <exception cref="ArgumentNullException"><paramref name="str"/> is <see langword="null"/>.</exception>
    /// <exception cref="OverflowException">The exponent in <paramref name="str"/> is beyond the range of a native long, which MPIR does not check: 2^31 - 1 on Windows.</exception>
    public static int init_set_str(mpf_t rop, string str, uint strbase)
    {
        // The native function would dereference a null string.
        if (str is null)
            throw new ArgumentNullException(nameof(str));

        CheckStringExponent(str, strbase);

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
    /// <remarks>As in MPIR, the value is truncated, and a number beyond the range of double gives an infinity or zero.</remarks>
    public static double get_d(mpf_t op)
    {
        // MPIR computes the exponent in a C long, which is 32-bit on Windows and wraps for numbers beyond 2^(2^31).
        long Exponent = BitExponent(op);
        if (Exponent > DoubleMaxExponent)
            return sgn(op) > 0 ? double.PositiveInfinity : double.NegativeInfinity;

        if (Exponent < DoubleMinExponent)
            return sgn(op) > 0 ? 0.0 : -0.0;

        return NativeMethods.mpf_get_d(ref op.Value);
    }

    /// <summary>
    /// Checks that mpf_set_str can read the exponent of a text without overflowing a native long.
    /// </summary>
    /// <param name="str">The text.</param>
    /// <param name="strbase">The base, as passed to mpf_set_str.</param>
    /// <exception cref="OverflowException">The exponent is beyond the range of a native long.</exception>
    internal static void CheckStringExponent(string str, uint strbase)
    {
        // MPIR reads the exponent digit by digit in a C long without checking for overflow, then subtracts the number
        // of fractional digits. This follows its parsing: the text ends at the first NUL, the exponent marker is
        // searched from the right, and the exponent is in the base of the number, or in decimal for a base of 0 or less.
        int Base = unchecked((int)strbase);
        int MantissaBase = Base switch
        {
            0 => 10,
            > 0 => Base,
            >= -62 => -Base,
            _ => 0,
        };

        if (MantissaBase < 2 || MantissaBase > 62)
            return;

        int ExponentBase = Base > 0 ? Base : 10;
        int Length = str.IndexOf('\0');
        if (Length < 0)
            Length = str.Length;

        int MarkerIndex = FindExponentMarker(str, Length, MantissaBase);
        if (MarkerIndex < 0)
            return;

        // The fractional digits are fewer than the characters before the marker.
        ulong Limit = (ulong)MpfrDotNet.mpfr.NativeLongMax - (ulong)MarkerIndex;
        ulong Exponent = 0;
        int Index = MarkerIndex + 1;

        if (Index < Length && str[Index] is '+' or '-')
            Index++;

        for (; Index < Length; Index++)
        {
            int Digit = ExponentDigitValue(str[Index], MantissaBase);
            if (Digit >= ExponentBase)
                break;

            if (Exponent > (Limit - (ulong)Digit) / (ulong)ExponentBase)
                throw new OverflowException("The exponent of the text is beyond the range of MPIR on this platform.");

            Exponent = (Exponent * (ulong)ExponentBase) + (ulong)Digit;
        }
    }

    private static int FindExponentMarker(string str, int length, int mantissaBase)
    {
        for (int i = length - 1; i > 0; i--)
            if (str[i] == '@' || (mantissaBase <= 10 && str[i] is 'e' or 'E'))
                return i;

        return -1;
    }

    // The digit table of MPIR: letters are case-insensitive up to base 36, and lowercase letters follow uppercase ones above.
    private static int ExponentDigitValue(char c, int mantissaBase)
    {
        if (c is >= '0' and <= '9')
            return c - '0';

        if (c is >= 'A' and <= 'Z')
            return c - 'A' + 10;

        if (c is >= 'a' and <= 'z')
            return c - 'a' + (mantissaBase > 36 ? 36 : 10);

        return int.MaxValue;
    }

    // The exponents of the largest double, in [2^1023, 2^1024), and of the smallest, 2^-1074.
    private const long DoubleMaxExponent = 1024;
    private const long DoubleMinExponent = -1073;

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="op">The operand.</param>
    /// <param name="d">The double value.</param>
    /// <param name="exp">The exponent.</param>
    public static void get_d_2exp(mpf_t op, out double d, out long exp)
    {
        d = NativeMethods.mpf_get_d_2exp(out _, ref op.Value);

        // MPIR returns the exponent in a C long, which is 32-bit on Windows and wraps for numbers beyond 2^(2^31): it is
        // computed here the way MPIR does, from the exponent in limbs.
        exp = BitExponent(op);
    }

    /// <summary>
    /// Gets the exponent in base 2 of a number: the number is in [2^(e - 1), 2^e) in absolute value, or 0 for zero.
    /// </summary>
    /// <param name="op">The number.</param>
    /// <returns>The exponent.</returns>
    internal static long BitExponent(mpf_t op)
    {
        int LimbCount = Math.Abs(op.Value.Size);
        if (LimbCount == 0)
            return 0;

        // The offset is computed in 64 bits: a number can have more than 2^28 limbs.
        ulong TopLimb = (ulong)Marshal.ReadInt64(MpfrDotNet.NativeNumberArray.Offset(op.Value.Limbs, (long)(LimbCount - 1) * sizeof(ulong)));

        return ((long)op.Value.Exponent.Value * (long)LimbBits) - LeadingZeroCount(TopLimb);
    }

    /// <summary>
    /// Gets the number of leading zero bits of a limb.
    /// </summary>
    /// <param name="value">The limb, which is not zero.</param>
    /// <returns>The number of leading zero bits.</returns>
    internal static int LeadingZeroCount(ulong value)
    {
        int Result = 0;

        while ((value & (1UL << 63)) == 0)
        {
            value <<= 1;
            Result++;
        }

        return Result;
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
    /// <remarks>The capacity of <paramref name="str"/> is increased to the size of the result, if needed.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="str"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="strBase"/> is not between 2 and 62, or between -36 and -2.</exception>
    public static void get_str(StringBuilder str, out int expptr, int strBase, ulong n_digits, mpf_t op)
    {
        GetString(str, out long Exponent, strBase, n_digits, op);

        // Exponents are clamped to int in the API.
        expptr = MpfrDotNet.mpfr.ClampToInt(Exponent);
    }

    /// <summary>
    /// Calls mpf_get_str, with the exponent not clamped.
    /// </summary>
    /// <param name="str">The string.</param>
    /// <param name="expptr">The exponent.</param>
    /// <param name="strBase">The base.</param>
    /// <param name="n_digits">The count of digits.</param>
    /// <param name="op">The operand.</param>
    /// <exception cref="ArgumentNullException"><paramref name="str"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="strBase"/> is not between 2 and 62, or between -36 and -2.</exception>
    internal static void GetString(StringBuilder str, out long expptr, int strBase, ulong n_digits, mpf_t op)
    {
        // The native function writes as many characters as the value needs into the buffer allocated for the capacity,
        // and allocates a string that would leak when the buffer is null.
        if (str is null)
            throw new ArgumentNullException(nameof(str));

        uint DigitCountBase = DigitBase.ToDigitCountBase(strBase, nameof(strBase));

        // MPIR writes at most the significant digits of the precision (MPF_SIGNIFICANT_DIGITS), a minus sign and the
        // terminating null character. Each digit holds at least floor(log2(base)) bits.
        ulong MaxDigits = 2 + (((ulong)op.Value.Precision * LimbBits) / FloorLog2(DigitCountBase));
        ulong Digits = n_digits == 0 ? MaxDigits : Math.Min(n_digits, MaxDigits);

        // MPIR converts in its own buffer, and copies only the digits left once the trailing zeros are removed: none
        // for zero, and in a base that is a power of two, no more than the bits of the value.
        int LimbCount = Math.Abs(op.Value.Size);
        if (LimbCount == 0)
            Digits = 0;
        else if ((DigitCountBase & (DigitCountBase - 1)) == 0)
            Digits = Math.Min(Digits, 2 + ((((ulong)LimbCount + 1UL) * LimbBits) / FloorLog2(DigitCountBase)));

        Digits = LimitToStringLength(Digits, n_digits, out ulong NativeDigits);
        _ = str.EnsureCapacity((int)Digits + 2);

        NativeMethods.mpf_get_str(str, out CLong NativeExponent, strBase, (NativeMethods.size_t)NativeDigits, ref op.Value);
        expptr = UnwrapExponent((long)NativeExponent.Value, BitExponent(op), DigitCountBase);
    }

    /// <summary>
    /// Limits a count of digits to what a string can hold.
    /// </summary>
    /// <param name="digits">The count of digits that the native function can write.</param>
    /// <param name="requestedDigits">The count of digits requested, or zero for all the significant digits.</param>
    /// <param name="nativeDigits">The count of digits to request from the native function upon return.</param>
    /// <returns>The count of digits the buffer must hold.</returns>
    internal static ulong LimitToStringLength(ulong digits, ulong requestedDigits, out ulong nativeDigits)
    {
        // A string cannot hold more characters: the digits are then limited, and the native function is told so, which
        // only happens for a precision of billions of bits.
        if (digits > MaxStringDigits)
        {
            nativeDigits = MaxStringDigits;
            return MaxStringDigits;
        }

        nativeDigits = requestedDigits;
        return digits;
    }

    // Leaves room for the sign and the terminating null character in the largest string.
    private const ulong MaxStringDigits = int.MaxValue - 64;

    /// <summary>
    /// Restores an exponent in a base that MPIR computed in a 32-bit C long on Windows, where it wraps for huge numbers.
    /// </summary>
    /// <param name="nativeExponent">The exponent returned by MPIR, possibly wrapped modulo 2^32.</param>
    /// <param name="bitExponent">The exponent of the number in base 2, which is not wrapped.</param>
    /// <param name="digitBase">The base of the exponent.</param>
    /// <returns>The exponent.</returns>
    internal static long UnwrapExponent(long nativeExponent, long bitExponent, uint digitBase)
    {
        // The exponent in the base is within 2 of the exponent in base 2 divided by log2(base), so the number of wraps is
        // the nearest integer.
        const double WrapSize = 4294967296.0;

        double Estimate = bitExponent / Math.Log(digitBase, 2);
        long Wraps = (long)Math.Round((Estimate - nativeExponent) / WrapSize);

        return nativeExponent + (Wraps << 32);
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
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="max_size"/> is greater than <see cref="long.MaxValue"/>, or <paramref name="exp"/> is not between -(2^30 - 1) and 2^30 - 1.</exception>
    public static void rrandomb(mpf_t rop, randstate_t state, ulong max_size, int exp)
    {
        state.ThrowIfDisposed();

        ThrowIfNotMpir(NativeMethods.IsMpir, nameof(NativeMethods.mpf_rrandomb));

        // MPIR reads the size as a signed number, and uses its sign as the sign of the result.
        if (max_size > long.MaxValue)
            throw new ArgumentOutOfRangeException(nameof(max_size), max_size, $"The size must be {long.MaxValue} or less.");

        // MPIR computes 2 * exp + 1 with the 32-bit exponents of Windows, which overflows beyond 2^30 - 1.
        if (exp is < -MaxRandomExponent or > MaxRandomExponent)
            throw new ArgumentOutOfRangeException(nameof(exp), exp, $"The exponent must be between {-MaxRandomExponent} and {MaxRandomExponent}.");

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
