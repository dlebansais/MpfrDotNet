namespace MpfrDotNet
{
    using System;
    using System.Runtime.InteropServices;

    internal static partial class NativeMethods
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpfr_init2(ref __mpfr_t x, ulong prec);
        public static __mpfr_init2 mpfr_init2 = Marshal.GetDelegateForFunctionPointer<__mpfr_init2>(GetMpfrPointer(nameof(mpfr_init2)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpfr_inits2(ulong prec, IntPtr[] x);
        public static __mpfr_inits2 mpfr_inits2 = Marshal.GetDelegateForFunctionPointer<__mpfr_inits2>(GetMpfrPointer(nameof(mpfr_inits2)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpfr_clear(ref __mpfr_t x);
        public static __mpfr_clear mpfr_clear = Marshal.GetDelegateForFunctionPointer<__mpfr_clear>(GetMpfrPointer(nameof(mpfr_clear)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpfr_clears(IntPtr[] x);
        public static __mpfr_clears mpfr_clears = Marshal.GetDelegateForFunctionPointer<__mpfr_clears>(GetMpfrPointer(nameof(mpfr_clears)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpfr_init(ref __mpfr_t x);
        public static __mpfr_init mpfr_init = Marshal.GetDelegateForFunctionPointer<__mpfr_init>(GetMpfrPointer(nameof(mpfr_init)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpfr_inits(IntPtr[] x);
        public static __mpfr_inits mpfr_inits = Marshal.GetDelegateForFunctionPointer<__mpfr_inits>(GetMpfrPointer(nameof(mpfr_inits)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpfr_set_default_prec(ulong prec);
        public static __mpfr_set_default_prec mpfr_set_default_prec = Marshal.GetDelegateForFunctionPointer<__mpfr_set_default_prec>(GetMpfrPointer(nameof(mpfr_set_default_prec)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpfr_set_prec(ref __mpfr_t x, ulong prec);
        public static __mpfr_set_prec mpfr_set_prec = Marshal.GetDelegateForFunctionPointer<__mpfr_set_prec>(GetMpfrPointer(nameof(mpfr_set_prec)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate ulong __mpfr_get_prec(ref __mpfr_t x);
        public static __mpfr_get_prec mpfr_get_prec = Marshal.GetDelegateForFunctionPointer<__mpfr_get_prec>(GetMpfrPointer(nameof(mpfr_get_prec)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpfr_set_prec_raw(ref __mpfr_t x, ulong prec);
        public static __mpfr_set_prec_raw mpfr_set_prec_raw = Marshal.GetDelegateForFunctionPointer<__mpfr_set_prec_raw>(GetMpfrPointer(nameof(mpfr_set_prec_raw)));
    }
}
