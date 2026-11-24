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
        IntPtr MinAddress = NativeLibraryLoader.GetExport(hMpfrLib, "mpfr_get_prec_min");
        NativeMinPrecision = MinAddress != IntPtr.Zero
            ? (ulong)Marshal.GetDelegateForFunctionPointer<__mpfr_get_prec_min>(MinAddress)().Value
            : 1UL;

        IntPtr MaxAddress = NativeLibraryLoader.GetExport(hMpfrLib, "mpfr_get_prec_max");
        NativeMaxPrecision = MaxAddress != IntPtr.Zero
            ? (ulong)Marshal.GetDelegateForFunctionPointer<__mpfr_get_prec_max>(MaxAddress)().Value
            : (ulong)((Marshal.SizeOf<CLong>() == 4 ? int.MaxValue : long.MaxValue) - 256L);

        mpfr_get_default_prec = Marshal.GetDelegateForFunctionPointer<__mpfr_get_default_prec>(GetMpfrPointer(nameof(mpfr_get_default_prec)));
        NativeDefaultPrecision = (ulong)mpfr_get_default_prec().Value;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CLong __mpfr_get_prec_min();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CLong __mpfr_get_prec_max();

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
