namespace MpfrDotNet;

using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public static partial class mpfr
{
    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static int get_emin()
    {
        return mpfr_get_emin();
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static int get_emax()
    {
        return mpfr_get_emax();
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="exp">The exponent.</param>
    public static int set_emin(int exp)
    {
        return mpfr_set_emin(exp);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="exp">The exponent.</param>
    public static int set_emax(int exp)
    {
        return mpfr_set_emax(exp);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static int get_emin_min()
    {
        return mpfr_get_emin_min();
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static int get_emin_max()
    {
        return mpfr_get_emin_max();
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static int get_emax_min()
    {
        return mpfr_get_emax_min();
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static int get_emax_max()
    {
        return mpfr_get_emax_max();
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="t">The t.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int check_range(mpfr_t x, int t, mpfr_rnd_t rnd)
    {
        return mpfr_check_range(ref x.Value, t, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="t">The t.</param>
    /// <param name="rnd">The rounding mode.</param>
    public static int subnormalize(mpfr_t x, int t, mpfr_rnd_t rnd)
    {
        return mpfr_subnormalize(ref x.Value, t, (__mpfr_rnd_t)rnd);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static void clear_underflow()
    {
        mpfr_clear_underflow();
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static void clear_overflow()
    {
        mpfr_clear_overflow();
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static void clear_divby0()
    {
        mpfr_clear_divby0();
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static void clear_nanflag()
    {
        mpfr_clear_nanflag();
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static void clear_inexflag()
    {
        mpfr_clear_inexflag();
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static void clear_erangeflag()
    {
        mpfr_clear_erangeflag();
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static void clear_flags()
    {
        mpfr_clear_flags();
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static void set_underflow()
    {
        mpfr_set_underflow();
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static void set_overflow()
    {
        mpfr_set_overflow();
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static void set_divby0()
    {
        mpfr_set_divby0();
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static void set_nanflag()
    {
        mpfr_set_nanflag();
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static void set_inexflag()
    {
        mpfr_set_inexflag();
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static void set_erangeflag()
    {
        mpfr_set_erangeflag();
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static bool underflow_p()
    {
        return mpfr_underflow_p() != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static bool overflow_p()
    {
        return mpfr_overflow_p() != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static bool divby0_p()
    {
        return mpfr_divby0_p() != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static bool nanflag_p()
    {
        return mpfr_nanflag_p() != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static bool inexflag_p()
    {
        return mpfr_inexflag_p() != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static bool erangeflag_p()
    {
        return mpfr_erangeflag_p() != 0;
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="mask">The bit mask.</param>
    public static void flags_clear(uint mask)
    {
        mpfr_flags_clear(mask);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="mask">The bit mask.</param>
    public static void flags_set(uint mask)
    {
        mpfr_flags_set(mask);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="mask">The bit mask.</param>
    public static uint flags_test(uint mask)
    {
        return mpfr_flags_test(mask);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static uint flags_save()
    {
        return mpfr_flags_save();
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="flags">The flags.</param>
    /// <param name="mask">The bit mask.</param>
    public static void flags_restore(uint flags, uint mask)
    {
        mpfr_flags_restore(flags, mask);
    }
}
