namespace Interop.Mpfr;

using System;
using System.Runtime.InteropServices;
using System.Text;
using static Interop.Mpir.NativeMethods;

#pragma warning disable SA1601 // Partial elements should be documented
#pragma warning disable SA1600 // Elements should be documented
internal static partial class NativeMethods
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate float __mpfr_get_flt(ref __mpfr_t op, __mpfr_rnd_t rnd);
    public static __mpfr_get_flt mpfr_get_flt => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_get_flt>(GetMpfrPointer(nameof(mpfr_get_flt)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate double __mpfr_get_d(ref __mpfr_t op, __mpfr_rnd_t rnd);
    public static __mpfr_get_d mpfr_get_d => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_get_d>(GetMpfrPointer(nameof(mpfr_get_d)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long __mpfr_get_si(ref __mpfr_t op, __mpfr_rnd_t rnd);
    public static __mpfr_get_si mpfr_get_si => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_get_si>(GetMpfrPointer(nameof(mpfr_get_si)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ulong __mpfr_get_ui(ref __mpfr_t op, __mpfr_rnd_t rnd);
    public static __mpfr_get_ui mpfr_get_ui => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_get_ui>(GetMpfrPointer(nameof(mpfr_get_ui)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long __mpfr_get_sj(ref __mpfr_t op, __mpfr_rnd_t rnd);
    public static __mpfr_get_sj mpfr_get_sj => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_get_sj>(GetMpfrPointer($"__gmpfr_{nameof(mpfr_get_sj)}"));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ulong __mpfr_get_uj(ref __mpfr_t op, __mpfr_rnd_t rnd);
    public static __mpfr_get_uj mpfr_get_uj => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_get_uj>(GetMpfrPointer($"__gmpfr_{nameof(mpfr_get_uj)}"));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate double __mpfr_get_d_2exp(out CLong exp, ref __mpfr_t op, __mpfr_rnd_t rnd);
    public static __mpfr_get_d_2exp mpfr_get_d_2exp => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_get_d_2exp>(GetMpfrPointer(nameof(mpfr_get_d_2exp)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_frexp(out CLong exp, ref __mpfr_t x, ref __mpfr_t y, __mpfr_rnd_t rnd);
    public static __mpfr_frexp mpfr_frexp => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_frexp>(GetMpfrPointer(nameof(mpfr_frexp)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CLong __mpfr_get_z_2exp(ref __mpz_t rop, ref __mpfr_t op);
    public static __mpfr_get_z_2exp mpfr_get_z_2exp => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_get_z_2exp>(GetMpfrPointer(nameof(mpfr_get_z_2exp)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_get_z(ref __mpz_t rop, ref __mpfr_t op, __mpfr_rnd_t rnd);
    public static __mpfr_get_z mpfr_get_z => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_get_z>(GetMpfrPointer(nameof(mpfr_get_z)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void __mpfr_get_q(ref __mpq_t rop, ref __mpfr_t op);
    public static __mpfr_get_q mpfr_get_q => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_get_q>(GetMpfrPointer(nameof(mpfr_get_q)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_get_f(ref __mpf_t rop, ref __mpfr_t op, __mpfr_rnd_t rnd);
    public static __mpfr_get_f mpfr_get_f => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_get_f>(GetMpfrPointer(nameof(mpfr_get_f)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ulong __mpfr_get_str_ndigits(int b, CLong p);
    public static __mpfr_get_str_ndigits mpfr_get_str_ndigits => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_get_str_ndigits>(GetMpfrPointer(nameof(mpfr_get_str_ndigits)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void __mpfr_get_str(StringBuilder str, out CLong expptr, int _base, ulong n, ref __mpfr_t op, __mpfr_rnd_t rnd);
    public static __mpfr_get_str mpfr_get_str => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_get_str>(GetMpfrPointer(nameof(mpfr_get_str)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_fits_ulong_p(ref __mpfr_t op, __mpfr_rnd_t rnd);
    public static __mpfr_fits_ulong_p mpfr_fits_ulong_p => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_fits_ulong_p>(GetMpfrPointer(nameof(mpfr_fits_ulong_p)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_fits_slong_p(ref __mpfr_t op, __mpfr_rnd_t rnd);
    public static __mpfr_fits_slong_p mpfr_fits_slong_p => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_fits_slong_p>(GetMpfrPointer(nameof(mpfr_fits_slong_p)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_fits_uint_p(ref __mpfr_t op, __mpfr_rnd_t rnd);
    public static __mpfr_fits_uint_p mpfr_fits_uint_p => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_fits_uint_p>(GetMpfrPointer(nameof(mpfr_fits_uint_p)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_fits_sint_p(ref __mpfr_t op, __mpfr_rnd_t rnd);
    public static __mpfr_fits_sint_p mpfr_fits_sint_p => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_fits_sint_p>(GetMpfrPointer(nameof(mpfr_fits_sint_p)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_fits_ushort_p(ref __mpfr_t op, __mpfr_rnd_t rnd);
    public static __mpfr_fits_ushort_p mpfr_fits_ushort_p => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_fits_ushort_p>(GetMpfrPointer(nameof(mpfr_fits_ushort_p)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_fits_sshort_p(ref __mpfr_t op, __mpfr_rnd_t rnd);
    public static __mpfr_fits_sshort_p mpfr_fits_sshort_p => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_fits_sshort_p>(GetMpfrPointer(nameof(mpfr_fits_sshort_p)));

    // The format and the output are passed as null-terminated UTF-8 bytes, so that any text gives the same result on all platforms.
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_snprintf(byte[]? buf, ulong n, byte[] format, ref __mpfr_t op, IntPtr end);
    public static __mpfr_snprintf mpfr_snprintf => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_snprintf>(GetMpfrPointer(nameof(mpfr_snprintf)));
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented

