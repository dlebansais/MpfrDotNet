namespace Interop.Mpfr
{
    using System;
    using System.Runtime.InteropServices;

    internal static partial class NativeMethods
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_rint(ref __mpfr_t rop, ref __mpfr_t op, mpfr_rnd_t rnd);
        public static __mpfr_rint mpfr_rint = Marshal.GetDelegateForFunctionPointer<__mpfr_rint>(GetMpfrPointer(nameof(mpfr_rint)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_ceil(ref __mpfr_t rop, ref __mpfr_t op);
        public static __mpfr_ceil mpfr_ceil = Marshal.GetDelegateForFunctionPointer<__mpfr_ceil>(GetMpfrPointer(nameof(mpfr_ceil)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_floor(ref __mpfr_t rop, ref __mpfr_t op);
        public static __mpfr_floor mpfr_floor = Marshal.GetDelegateForFunctionPointer<__mpfr_floor>(GetMpfrPointer(nameof(mpfr_floor)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_round(ref __mpfr_t rop, ref __mpfr_t op);
        public static __mpfr_round mpfr_round = Marshal.GetDelegateForFunctionPointer<__mpfr_round>(GetMpfrPointer(nameof(mpfr_round)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_roundeven(ref __mpfr_t rop, ref __mpfr_t op);
        public static __mpfr_roundeven mpfr_roundeven = Marshal.GetDelegateForFunctionPointer<__mpfr_roundeven>(GetMpfrPointer(nameof(mpfr_roundeven)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_trunc(ref __mpfr_t rop, ref __mpfr_t op);
        public static __mpfr_trunc mpfr_trunc = Marshal.GetDelegateForFunctionPointer<__mpfr_trunc>(GetMpfrPointer(nameof(mpfr_trunc)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_rint_ceil(ref __mpfr_t rop, ref __mpfr_t op, mpfr_rnd_t rnd);
        public static __mpfr_rint_ceil mpfr_rint_ceil = Marshal.GetDelegateForFunctionPointer<__mpfr_rint_ceil>(GetMpfrPointer(nameof(mpfr_rint_ceil)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_rint_floor(ref __mpfr_t rop, ref __mpfr_t op, mpfr_rnd_t rnd);
        public static __mpfr_rint_floor mpfr_rint_floor = Marshal.GetDelegateForFunctionPointer<__mpfr_rint_floor>(GetMpfrPointer(nameof(mpfr_rint_floor)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_rint_round(ref __mpfr_t rop, ref __mpfr_t op, mpfr_rnd_t rnd);
        public static __mpfr_rint_round mpfr_rint_round = Marshal.GetDelegateForFunctionPointer<__mpfr_rint_round>(GetMpfrPointer(nameof(mpfr_rint_round)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_rint_roundeven(ref __mpfr_t rop, ref __mpfr_t op, mpfr_rnd_t rnd);
        public static __mpfr_rint_roundeven mpfr_rint_roundeven = Marshal.GetDelegateForFunctionPointer<__mpfr_rint_roundeven>(GetMpfrPointer(nameof(mpfr_rint_roundeven)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_rint_trunc(ref __mpfr_t rop, ref __mpfr_t op, mpfr_rnd_t rnd);
        public static __mpfr_rint_trunc mpfr_rint_trunc = Marshal.GetDelegateForFunctionPointer<__mpfr_rint_trunc>(GetMpfrPointer(nameof(mpfr_rint_trunc)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_frac(ref __mpfr_t rop, ref __mpfr_t op, mpfr_rnd_t rnd);
        public static __mpfr_frac mpfr_frac = Marshal.GetDelegateForFunctionPointer<__mpfr_frac>(GetMpfrPointer(nameof(mpfr_frac)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_modf(ref __mpfr_t iop, ref __mpfr_t fop, ref __mpfr_t op, mpfr_rnd_t rnd);
        public static __mpfr_modf mpfr_modf = Marshal.GetDelegateForFunctionPointer<__mpfr_modf>(GetMpfrPointer(nameof(mpfr_modf)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_fmod(ref __mpfr_t r, ref __mpfr_t x, ref __mpfr_t y, mpfr_rnd_t rnd);
        public static __mpfr_fmod mpfr_fmod = Marshal.GetDelegateForFunctionPointer<__mpfr_fmod>(GetMpfrPointer(nameof(mpfr_fmod)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_fmodquo(ref __mpfr_t r, out long q, ref __mpfr_t x, ref __mpfr_t y, mpfr_rnd_t rnd);
        public static __mpfr_fmodquo mpfr_fmodquo = Marshal.GetDelegateForFunctionPointer<__mpfr_fmodquo>(GetMpfrPointer(nameof(mpfr_fmodquo)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_remainder(ref __mpfr_t r, ref __mpfr_t x, ref __mpfr_t y, mpfr_rnd_t rnd);
        public static __mpfr_remainder mpfr_remainder = Marshal.GetDelegateForFunctionPointer<__mpfr_remainder>(GetMpfrPointer(nameof(mpfr_remainder)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_remquo(ref __mpfr_t r, out long q, ref __mpfr_t x, ref __mpfr_t y, mpfr_rnd_t rnd);
        public static __mpfr_remquo mpfr_remquo = Marshal.GetDelegateForFunctionPointer<__mpfr_remquo>(GetMpfrPointer(nameof(mpfr_remquo)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_integer_p(ref __mpfr_t op);
        public static __mpfr_integer_p mpfr_integer_p = Marshal.GetDelegateForFunctionPointer<__mpfr_integer_p>(GetMpfrPointer(nameof(mpfr_integer_p)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpfr_set_default_rounding_mode(mpfr_rnd_t rnd);
        public static __mpfr_set_default_rounding_mode mpfr_set_default_rounding_mode = Marshal.GetDelegateForFunctionPointer<__mpfr_set_default_rounding_mode>(GetMpfrPointer(nameof(mpfr_set_default_rounding_mode)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate mpfr_rnd_t __mpfr_get_default_rounding_mode();
        public static __mpfr_get_default_rounding_mode mpfr_get_default_rounding_mode = Marshal.GetDelegateForFunctionPointer<__mpfr_get_default_rounding_mode>(GetMpfrPointer(nameof(mpfr_get_default_rounding_mode)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_prec_round(ref __mpfr_t x, ulong prec, mpfr_rnd_t rnd);
        public static __mpfr_prec_round mpfr_prec_round = Marshal.GetDelegateForFunctionPointer<__mpfr_prec_round>(GetMpfrPointer(nameof(mpfr_prec_round)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_can_round(ref __mpfr_t b, int err, mpfr_rnd_t rnd1, mpfr_rnd_t rnd2, ulong prec);
        public static __mpfr_can_round mpfr_can_round = Marshal.GetDelegateForFunctionPointer<__mpfr_can_round>(GetMpfrPointer(nameof(mpfr_can_round)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_min_prec(ref __mpfr_t x);
        public static __mpfr_min_prec mpfr_min_prec = Marshal.GetDelegateForFunctionPointer<__mpfr_min_prec>(GetMpfrPointer(nameof(mpfr_min_prec)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr __mpfr_print_rnd_mode(mpfr_rnd_t rnd);
        public static __mpfr_print_rnd_mode mpfr_print_rnd_mode = Marshal.GetDelegateForFunctionPointer<__mpfr_print_rnd_mode>(GetMpfrPointer(nameof(mpfr_print_rnd_mode)));
    }
}
