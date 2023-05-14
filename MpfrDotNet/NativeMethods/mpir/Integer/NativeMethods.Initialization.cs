namespace Interop.Mpir;

using System;
using System.Runtime.InteropServices;

#pragma warning disable SA1601 // Partial elements should be documented
#pragma warning disable SA1600 // Elements should be documented
internal static partial class NativeMethods
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void __mpz_init(ref __mpz_t integer);
    public static __mpz_init mpz_init { get; } = Marshal.GetDelegateForFunctionPointer<__mpz_init>(GetMpirPointer(nameof(mpz_init)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void __mpz_inits(IntPtr arg000,
                                     IntPtr arg001,
                                     IntPtr arg002,
                                     IntPtr arg003,
                                     IntPtr arg004,
                                     IntPtr arg005,
                                     IntPtr arg006,
                                     IntPtr arg007,
                                     IntPtr arg078,
                                     IntPtr arg009,
                                     IntPtr arg00A,
                                     IntPtr arg00B,
                                     IntPtr arg00C,
                                     IntPtr arg00D,
                                     IntPtr arg00E,
                                     IntPtr arg00F,
                                     IntPtr arg010,
                                     IntPtr arg011,
                                     IntPtr arg012,
                                     IntPtr arg013,
                                     IntPtr arg014,
                                     IntPtr arg015,
                                     IntPtr arg016,
                                     IntPtr arg017,
                                     IntPtr arg018,
                                     IntPtr arg019,
                                     IntPtr arg01A,
                                     IntPtr arg01B,
                                     IntPtr arg01C,
                                     IntPtr arg01D,
                                     IntPtr arg01E,
                                     IntPtr arg01F);
    public static __mpz_inits mpz_inits { get; } = Marshal.GetDelegateForFunctionPointer<__mpz_inits>(GetMpirPointer(nameof(mpz_inits)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void __mpz_init2(ref __mpz_t integer, mp_bitcnt_t n);
    public static __mpz_init2 mpz_init2 { get; } = Marshal.GetDelegateForFunctionPointer<__mpz_init2>(GetMpirPointer(nameof(mpz_init2)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void __mpz_clear(ref __mpz_t integer);
    public static __mpz_clear mpz_clear { get; } = Marshal.GetDelegateForFunctionPointer<__mpz_clear>(GetMpirPointer(nameof(mpz_clear)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void __mpz_realloc2(ref __mpz_t integer, mp_bitcnt_t n);
    public static __mpz_realloc2 mpz_realloc2 { get; } = Marshal.GetDelegateForFunctionPointer<__mpz_realloc2>(GetMpirPointer(nameof(mpz_realloc2)));
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented

