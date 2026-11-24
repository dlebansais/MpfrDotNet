namespace Interop.Mpir;

using System;
using System.Runtime.InteropServices;

#pragma warning disable SA1601 // Partial elements should be documented
#pragma warning disable SA1600 // Elements should be documented
internal static partial class NativeMethods
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void __mpz_init(ref __mpz_t integer);
    public static __mpz_init mpz_init => field ??= Marshal.GetDelegateForFunctionPointer<__mpz_init>(GetMpirPointer(nameof(mpz_init)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void __mpz_init2(ref __mpz_t integer, mp_bitcnt_t n);
    public static __mpz_init2 mpz_init2 => field ??= Marshal.GetDelegateForFunctionPointer<__mpz_init2>(GetMpirPointer(nameof(mpz_init2)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void __mpz_clear(ref __mpz_t integer);
    public static __mpz_clear mpz_clear => field ??= Marshal.GetDelegateForFunctionPointer<__mpz_clear>(GetMpirPointer(nameof(mpz_clear)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void __mpz_realloc2(ref __mpz_t integer, mp_bitcnt_t n);
    public static __mpz_realloc2 mpz_realloc2 => field ??= Marshal.GetDelegateForFunctionPointer<__mpz_realloc2>(GetMpirPointer(nameof(mpz_realloc2)));
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented

