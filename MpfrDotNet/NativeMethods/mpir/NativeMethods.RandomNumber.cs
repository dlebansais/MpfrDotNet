﻿namespace MpirDotNet
{
    using System.Runtime.InteropServices;

    internal static partial class NativeMethods
    {
        #region Random State Initialization
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mp_randinit_default(ref __gmp_randstate_t state);
        public static __mp_randinit_default mp_randinit_default = Marshal.GetDelegateForFunctionPointer<__mp_randinit_default>(GetMpirPointer(nameof(mp_randinit_default)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mp_randinit_mt(ref __gmp_randstate_t state);
        public static __mp_randinit_mt mp_randinit_mt = Marshal.GetDelegateForFunctionPointer<__mp_randinit_mt>(GetMpirPointer(nameof(mp_randinit_mt)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mp_randinit_lc_2exp(ref __gmp_randstate_t state, ref __mpz_t a, uint c, ulong m2exp);
        public static __mp_randinit_lc_2exp mp_randinit_lc_2exp = Marshal.GetDelegateForFunctionPointer<__mp_randinit_lc_2exp>(GetMpirPointer(nameof(mp_randinit_lc_2exp)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mp_randinit_lc_2exp_size(ref __gmp_randstate_t state, ulong size);
        public static __mp_randinit_lc_2exp_size mp_randinit_lc_2exp_size = Marshal.GetDelegateForFunctionPointer<__mp_randinit_lc_2exp_size>(GetMpirPointer(nameof(mp_randinit_lc_2exp_size)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mp_randinit_set(ref __gmp_randstate_t rop, ref __gmp_randstate_t op);
        public static __mp_randinit_set mp_randinit_set = Marshal.GetDelegateForFunctionPointer<__mp_randinit_set>(GetMpirPointer(nameof(mp_randinit_set)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mp_randclear(ref __gmp_randstate_t state);
        public static __mp_randclear mp_randclear = Marshal.GetDelegateForFunctionPointer<__mp_randclear>(GetMpirPointer(nameof(mp_randclear)));
        #endregion

        #region Random State Seeding
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mp_randseed(ref __gmp_randstate_t state, ref __mpz_t seed);
        public static __mp_randseed mp_randseed = Marshal.GetDelegateForFunctionPointer<__mp_randseed>(GetMpirPointer(nameof(mp_randseed)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mp_randseed_ui(ref __gmp_randstate_t state, uint seed);
        public static __mp_randseed_ui mp_randseed_ui = Marshal.GetDelegateForFunctionPointer<__mp_randseed_ui>(GetMpirPointer(nameof(mp_randseed_ui)));
        #endregion

        #region Random State Miscellaneous
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint __mp_urandomb_ui(ref __gmp_randstate_t state, uint m2exp);
        public static __mp_urandomb_ui mp_urandomb_ui = Marshal.GetDelegateForFunctionPointer<__mp_urandomb_ui>(GetMpirPointer(nameof(mp_urandomb_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint __mp_urandomm_ui(ref __gmp_randstate_t state, uint n);
        public static __mp_urandomm_ui mp_urandomm_ui = Marshal.GetDelegateForFunctionPointer<__mp_urandomm_ui>(GetMpirPointer(nameof(mp_urandomm_ui)));
        #endregion
    }
}
