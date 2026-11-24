namespace Interop.Mpfr;

using System;
using System.Runtime.InteropServices;

#pragma warning disable SA1601 // Partial elements should be documented
#pragma warning disable SA1600 // Elements should be documented
internal static partial class NativeMethods
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void __mpfr_init2(ref __mpfr_t x, CLong prec);
    public static __mpfr_init2 mpfr_init2 => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_init2>(GetMpfrPointer(nameof(mpfr_init2)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void __mpfr_clear(ref __mpfr_t x);
    public static __mpfr_clear mpfr_clear => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_clear>(GetMpfrPointer(nameof(mpfr_clear)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void __mpfr_init(ref __mpfr_t x);
    public static __mpfr_init mpfr_init => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_init>(GetMpfrPointer(nameof(mpfr_init)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void __mpfr_set_default_prec(CLong prec);
    public static __mpfr_set_default_prec mpfr_set_default_prec => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_set_default_prec>(GetMpfrPointer(nameof(mpfr_set_default_prec)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void __mpfr_set_prec(ref __mpfr_t x, CLong prec);
    public static __mpfr_set_prec mpfr_set_prec => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_set_prec>(GetMpfrPointer(nameof(mpfr_set_prec)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CLong __mpfr_get_prec(ref __mpfr_t x);
    public static __mpfr_get_prec mpfr_get_prec => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_get_prec>(GetMpfrPointer(nameof(mpfr_get_prec)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void __mpfr_set_prec_raw(ref __mpfr_t x, CLong prec);
    public static __mpfr_set_prec_raw mpfr_set_prec_raw => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_set_prec_raw>(GetMpfrPointer(nameof(mpfr_set_prec_raw)));
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented

