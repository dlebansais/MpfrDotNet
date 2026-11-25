namespace Interop.Mpfr;

using System.Runtime.InteropServices;
using static Interop.Mpir.NativeMethods;

#pragma warning disable SA1601 // Partial elements should be documented
#pragma warning disable SA1600 // Elements should be documented
internal static partial class NativeMethods
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_set(ref __mpfr_t rop, ref __mpfr_t op, __mpfr_rnd_t rnd);
    public static __mpfr_set mpfr_set => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_set>(GetMpfrPointer(nameof(mpfr_set)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_set_ui(ref __mpfr_t rop, ulong op, __mpfr_rnd_t rnd);
    public static __mpfr_set_ui mpfr_set_ui => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_set_ui>(GetMpfrPointer(nameof(mpfr_set_ui)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_set_si(ref __mpfr_t rop, long op, __mpfr_rnd_t rnd);
    public static __mpfr_set_si mpfr_set_si => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_set_si>(GetMpfrPointer(nameof(mpfr_set_si)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_set_uj(ref __mpfr_t rop, ulong op, __mpfr_rnd_t rnd);
    public static __mpfr_set_uj mpfr_set_uj => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_set_uj>(GetMpfrPointer($"__g{nameof(mpfr_set_uj)}"));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_set_sj(ref __mpfr_t rop, long op, __mpfr_rnd_t rnd);
    public static __mpfr_set_sj mpfr_set_sj => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_set_sj>(GetMpfrPointer($"__g{nameof(mpfr_set_sj)}"));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_set_flt(ref __mpfr_t rop, float op, __mpfr_rnd_t rnd);
    public static __mpfr_set_flt mpfr_set_flt => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_set_flt>(GetMpfrPointer(nameof(mpfr_set_flt)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_set_d(ref __mpfr_t rop, double op, __mpfr_rnd_t rnd);
    public static __mpfr_set_d mpfr_set_d => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_set_d>(GetMpfrPointer(nameof(mpfr_set_d)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_set_z(ref __mpfr_t rop, ref __mpz_t op, __mpfr_rnd_t rnd);
    public static __mpfr_set_z mpfr_set_z => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_set_z>(GetMpfrPointer(nameof(mpfr_set_z)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_set_q(ref __mpfr_t rop, ref __mpq_t op, __mpfr_rnd_t rnd);
    public static __mpfr_set_q mpfr_set_q => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_set_q>(GetMpfrPointer(nameof(mpfr_set_q)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_set_f(ref __mpfr_t rop, ref __mpf_t op, __mpfr_rnd_t rnd);
    public static __mpfr_set_f mpfr_set_f => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_set_f>(GetMpfrPointer(nameof(mpfr_set_f)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_set_ui_2exp(ref __mpfr_t rop, ulong op, CLong e, __mpfr_rnd_t rnd);
    public static __mpfr_set_ui_2exp mpfr_set_ui_2exp => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_set_ui_2exp>(GetMpfrPointer(nameof(mpfr_set_ui_2exp)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_set_si_2exp(ref __mpfr_t rop, long op, CLong e, __mpfr_rnd_t rnd);
    public static __mpfr_set_si_2exp mpfr_set_si_2exp => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_set_si_2exp>(GetMpfrPointer(nameof(mpfr_set_si_2exp)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_set_uj_2exp(ref __mpfr_t rop, ulong op, long e, __mpfr_rnd_t rnd);
    public static __mpfr_set_uj_2exp mpfr_set_uj_2exp => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_set_uj_2exp>(GetMpfrPointer($"__g{nameof(mpfr_set_uj_2exp)}"));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_set_sj_2exp(ref __mpfr_t rop, long op, long e, __mpfr_rnd_t rnd);
    public static __mpfr_set_sj_2exp mpfr_set_sj_2exp => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_set_sj_2exp>(GetMpfrPointer($"__g{nameof(mpfr_set_sj_2exp)}"));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_set_z_2exp(ref __mpfr_t rop, ref __mpz_t op, CLong e, __mpfr_rnd_t rnd);
    public static __mpfr_set_z_2exp mpfr_set_z_2exp => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_set_z_2exp>(GetMpfrPointer(nameof(mpfr_set_z_2exp)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public delegate int __mpfr_set_str(ref __mpfr_t rop, string str, uint strbase, __mpfr_rnd_t rnd);
    public static __mpfr_set_str mpfr_set_str => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_set_str>(GetMpfrPointer(nameof(mpfr_set_str)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public delegate int __mpfr_set_nan(ref __mpfr_t x);
    public static __mpfr_set_nan mpfr_set_nan => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_set_nan>(GetMpfrPointer(nameof(mpfr_set_nan)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public delegate int __mpfr_set_inf(ref __mpfr_t x, int sign);
    public static __mpfr_set_inf mpfr_set_inf => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_set_inf>(GetMpfrPointer(nameof(mpfr_set_inf)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public delegate int __mpfr_set_zero(ref __mpfr_t x, int sign);
    public static __mpfr_set_zero mpfr_set_zero => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_set_zero>(GetMpfrPointer(nameof(mpfr_set_zero)));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int __mpfr_swap(ref __mpfr_t x, ref __mpfr_t y);
    public static __mpfr_swap mpfr_swap => field ??= Marshal.GetDelegateForFunctionPointer<__mpfr_swap>(GetMpfrPointer(nameof(mpfr_swap)));
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented

