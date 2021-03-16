namespace MpfrDotNet.mpfr
{
    using System;
    using System.Runtime.InteropServices;
    using static MpirDotNet.NativeMethods;

    internal static partial class NativeMethods
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpfr_nexttoward(ref __mpfr_t x, ref __mpfr_t y);
        public static __mpfr_nexttoward mpfr_nexttoward = Marshal.GetDelegateForFunctionPointer<__mpfr_nexttoward>(GetMpfrPointer(nameof(mpfr_nexttoward)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpfr_nextabove(ref __mpfr_t x);
        public static __mpfr_nextabove mpfr_nextabove = Marshal.GetDelegateForFunctionPointer<__mpfr_nextabove>(GetMpfrPointer(nameof(mpfr_nextabove)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpfr_nextbelow(ref __mpfr_t x);
        public static __mpfr_nextbelow mpfr_nextbelow = Marshal.GetDelegateForFunctionPointer<__mpfr_nextbelow>(GetMpfrPointer(nameof(mpfr_nextbelow)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_min(ref __mpfr_t rop, ref __mpfr_t op1, ref __mpfr_t op2, mpfr_rnd_t rnd);
        public static __mpfr_min mpfr_min = Marshal.GetDelegateForFunctionPointer<__mpfr_min>(GetMpfrPointer(nameof(mpfr_min)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_max(ref __mpfr_t rop, ref __mpfr_t op1, ref __mpfr_t op2, mpfr_rnd_t rnd);
        public static __mpfr_max mpfr_max = Marshal.GetDelegateForFunctionPointer<__mpfr_max>(GetMpfrPointer(nameof(mpfr_max)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_urandomb(ref __mpfr_t rop, ref __gmp_randstate_t state);
        public static __mpfr_urandomb mpfr_urandomb = Marshal.GetDelegateForFunctionPointer<__mpfr_urandomb>(GetMpfrPointer(nameof(mpfr_urandomb)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_urandom(ref __mpfr_t rop, ref __gmp_randstate_t state, mpfr_rnd_t rnd);
        public static __mpfr_urandom mpfr_urandom = Marshal.GetDelegateForFunctionPointer<__mpfr_urandom>(GetMpfrPointer(nameof(mpfr_urandom)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_nrandom(ref __mpfr_t rop1, ref __gmp_randstate_t state, mpfr_rnd_t rnd);
        public static __mpfr_nrandom mpfr_nrandom = Marshal.GetDelegateForFunctionPointer<__mpfr_nrandom>(GetMpfrPointer(nameof(mpfr_nrandom)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_grandom(ref __mpfr_t rop1, ref __mpfr_t rop2, ref __gmp_randstate_t state, mpfr_rnd_t rnd);
        public static __mpfr_grandom mpfr_grandom = Marshal.GetDelegateForFunctionPointer<__mpfr_grandom>(GetMpfrPointer(nameof(mpfr_grandom)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_erandom(ref __mpfr_t rop1, ref __gmp_randstate_t state, mpfr_rnd_t rnd);
        public static __mpfr_erandom mpfr_erandom = Marshal.GetDelegateForFunctionPointer<__mpfr_erandom>(GetMpfrPointer(nameof(mpfr_erandom)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_get_exp(ref __mpfr_t x);
        public static __mpfr_get_exp mpfr_get_exp = Marshal.GetDelegateForFunctionPointer<__mpfr_get_exp>(GetMpfrPointer(nameof(mpfr_get_exp)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_set_exp(ref __mpfr_t x, int e);
        public static __mpfr_set_exp mpfr_set_exp = Marshal.GetDelegateForFunctionPointer<__mpfr_set_exp>(GetMpfrPointer(nameof(mpfr_set_exp)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_signbit(ref __mpfr_t op);
        public static __mpfr_signbit mpfr_signbit = Marshal.GetDelegateForFunctionPointer<__mpfr_signbit>(GetMpfrPointer(nameof(mpfr_signbit)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_setsign(ref __mpfr_t rop, ref __mpfr_t op, int s, mpfr_rnd_t rnd);
        public static __mpfr_setsign mpfr_setsign = Marshal.GetDelegateForFunctionPointer<__mpfr_setsign>(GetMpfrPointer(nameof(mpfr_setsign)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_copysign(ref __mpfr_t rop, ref __mpfr_t op1, ref __mpfr_t op2, mpfr_rnd_t rnd);
        public static __mpfr_copysign mpfr_copysign = Marshal.GetDelegateForFunctionPointer<__mpfr_copysign>(GetMpfrPointer(nameof(mpfr_copysign)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr __mpfr_get_version();
        public static __mpfr_get_version mpfr_get_version = Marshal.GetDelegateForFunctionPointer<__mpfr_get_version>(GetMpfrPointer(nameof(mpfr_get_version)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr __mpfr_get_patches();
        public static __mpfr_get_patches mpfr_get_patches = Marshal.GetDelegateForFunctionPointer<__mpfr_get_patches>(GetMpfrPointer(nameof(mpfr_get_patches)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_buildopt_tls_p();
        public static __mpfr_buildopt_tls_p mpfr_buildopt_tls_p = Marshal.GetDelegateForFunctionPointer<__mpfr_buildopt_tls_p>(GetMpfrPointer(nameof(mpfr_buildopt_tls_p)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_buildopt_float128_p();
        public static __mpfr_buildopt_float128_p mpfr_buildopt_float128_p = Marshal.GetDelegateForFunctionPointer<__mpfr_buildopt_float128_p>(GetMpfrPointer(nameof(mpfr_buildopt_float128_p)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_buildopt_decimal_p();
        public static __mpfr_buildopt_decimal_p mpfr_buildopt_decimal_p = Marshal.GetDelegateForFunctionPointer<__mpfr_buildopt_decimal_p>(GetMpfrPointer(nameof(mpfr_buildopt_decimal_p)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_buildopt_gmpinternals_p();
        public static __mpfr_buildopt_gmpinternals_p mpfr_buildopt_gmpinternals_p = Marshal.GetDelegateForFunctionPointer<__mpfr_buildopt_gmpinternals_p>(GetMpfrPointer(nameof(mpfr_buildopt_gmpinternals_p)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_buildopt_sharedcache_p();
        public static __mpfr_buildopt_sharedcache_p mpfr_buildopt_sharedcache_p = Marshal.GetDelegateForFunctionPointer<__mpfr_buildopt_sharedcache_p>(GetMpfrPointer(nameof(mpfr_buildopt_sharedcache_p)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr __mpfr_buildopt_tune_case();
        public static __mpfr_buildopt_tune_case mpfr_buildopt_tune_case = Marshal.GetDelegateForFunctionPointer<__mpfr_buildopt_tune_case>(GetMpfrPointer(nameof(mpfr_buildopt_tune_case)));
    }
}
