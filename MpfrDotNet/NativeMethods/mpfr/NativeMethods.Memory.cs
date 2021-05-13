﻿namespace Interop.Mpfr
{
    using System.Runtime.InteropServices;

#pragma warning disable SA1601 // Partial elements should be documented
#pragma warning disable SA1600 // Elements should be documented
    internal static partial class NativeMethods
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpfr_free_cache();
        public static __mpfr_free_cache mpfr_free_cache { get; } = Marshal.GetDelegateForFunctionPointer<__mpfr_free_cache>(GetMpfrPointer(nameof(mpfr_free_cache)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpfr_free_cache2(int way);
        public static __mpfr_free_cache2 mpfr_free_cache2 { get; } = Marshal.GetDelegateForFunctionPointer<__mpfr_free_cache2>(GetMpfrPointer(nameof(mpfr_free_cache2)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpfr_free_pool();
        public static __mpfr_free_pool mpfr_free_pool { get; } = Marshal.GetDelegateForFunctionPointer<__mpfr_free_pool>(GetMpfrPointer(nameof(mpfr_free_pool)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_mp_memory_cleanup();
        public static __mpfr_mp_memory_cleanup mpfr_mp_memory_cleanup { get; } = Marshal.GetDelegateForFunctionPointer<__mpfr_mp_memory_cleanup>(GetMpfrPointer(nameof(mpfr_mp_memory_cleanup)));
    }
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented
}
