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
    public static void free_cache()
    {
        mpfr_free_cache();
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    /// <param name="way">The way.</param>
    public static void free_cache2(int way)
    {
        mpfr_free_cache2(way);
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static void free_pool()
    {
        mpfr_free_pool();
    }

    /// <summary>
    /// See https://www.mpfr.org/mpfr-current/mpfr.pdf.
    /// </summary>
    public static int mp_memory_cleanup()
    {
        return mpfr_mp_memory_cleanup();
    }
}
