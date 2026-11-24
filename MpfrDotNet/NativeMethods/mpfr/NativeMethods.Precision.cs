namespace Interop.Mpfr;

using System;
using System.Runtime.InteropServices;

#pragma warning disable SA1601 // Partial elements should be documented
#pragma warning disable SA1600 // Elements should be documented
internal static partial class NativeMethods
{
    private static void InitializePrecision()
    {
        // mpfr_get_prec_min and mpfr_get_prec_max exist only in the Windows build of MPFR. Elsewhere, the limits are
        // the MPFR_PREC_MIN and MPFR_PREC_MAX macros: 1, and the largest C long minus 256.
        NativeMinPrecision = ReadPrecisionLimit(NativeLibraryLoader.GetExport(hMpfrLib, "mpfr_get_prec_min"), 1UL);

        ulong MaxPrecisionMacro = (ulong)((Marshal.SizeOf<CLong>() == 4 ? int.MaxValue : long.MaxValue) - 256L);
        NativeMaxPrecision = ReadPrecisionLimit(NativeLibraryLoader.GetExport(hMpfrLib, "mpfr_get_prec_max"), MaxPrecisionMacro);

        mpfr_get_default_prec = Marshal.GetDelegateForFunctionPointer<__mpfr_get_default_prec>(GetMpfrPointer(nameof(mpfr_get_default_prec)));
        NativeDefaultPrecision = (ulong)mpfr_get_default_prec().Value;
    }

    /// <summary>
    /// Reads a precision limit with a native function that takes no argument and returns a C long.
    /// </summary>
    /// <param name="address">The address of the function, or <see cref="IntPtr.Zero"/> if the library does not export it.</param>
    /// <param name="fallback">The value returned when <paramref name="address"/> is <see cref="IntPtr.Zero"/>.</param>
    /// <returns>The value returned by the function, or <paramref name="fallback"/>.</returns>
    internal static ulong ReadPrecisionLimit(IntPtr address, ulong fallback)
    {
        if (address == IntPtr.Zero)
            return fallback;

        return (ulong)Marshal.GetDelegateForFunctionPointer<__mpfr_get_prec_limit>(address)().Value;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CLong __mpfr_get_prec_limit();

    // Bound when the type is initialized, which loads the library and records the precision limits.
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CLong __mpfr_get_default_prec();
    public static __mpfr_get_default_prec mpfr_get_default_prec { get; private set; } = Marshal.GetDelegateForFunctionPointer<__mpfr_get_default_prec>(GetMpfrPointer(nameof(mpfr_get_default_prec)));

    public static ulong NativeMinPrecision { get; private set; }
    public static ulong NativeMaxPrecision { get; private set; }
    public static ulong NativeDefaultPrecision { get; private set; }
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented
