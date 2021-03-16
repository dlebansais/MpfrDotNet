namespace MpfrDotNet
{
    using System.Runtime.InteropServices;
    using static MpirDotNet.NativeMethods;

    internal static partial class NativeMethods
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_set(ref __mpfr_t rop, ref __mpfr_t op, mpfr_rnd_t rnd);
        public static __mpfr_set mpfr_set = Marshal.GetDelegateForFunctionPointer<__mpfr_set>(GetMpfrPointer(nameof(mpfr_set)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_set_ui(ref __mpfr_t rop, ulong op, mpfr_rnd_t rnd);
        public static __mpfr_set_ui mpfr_set_ui = Marshal.GetDelegateForFunctionPointer<__mpfr_set_ui>(GetMpfrPointer(nameof(mpfr_set_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_set_si(ref __mpfr_t rop, long op, mpfr_rnd_t rnd);
        public static __mpfr_set_si mpfr_set_si = Marshal.GetDelegateForFunctionPointer<__mpfr_set_si>(GetMpfrPointer(nameof(mpfr_set_si)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_set_uj(ref __mpfr_t rop, uint op, mpfr_rnd_t rnd);
        public static __mpfr_set_uj mpfr_set_uj = Marshal.GetDelegateForFunctionPointer<__mpfr_set_uj>(GetMpfrPointer($"__g{nameof(mpfr_set_uj)}"));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_set_sj(ref __mpfr_t rop, int op, mpfr_rnd_t rnd);
        public static __mpfr_set_sj mpfr_set_sj = Marshal.GetDelegateForFunctionPointer<__mpfr_set_sj>(GetMpfrPointer($"__g{nameof(mpfr_set_sj)}"));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_set_flt(ref __mpfr_t rop, float op, mpfr_rnd_t rnd);
        public static __mpfr_set_flt mpfr_set_flt = Marshal.GetDelegateForFunctionPointer<__mpfr_set_flt>(GetMpfrPointer(nameof(mpfr_set_flt)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_set_d(ref __mpfr_t rop, double op, mpfr_rnd_t rnd);
        public static __mpfr_set_d mpfr_set_d = Marshal.GetDelegateForFunctionPointer<__mpfr_set_d>(GetMpfrPointer(nameof(mpfr_set_d)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_set_z(ref __mpfr_t rop, ref __mpz_t op, mpfr_rnd_t rnd);
        public static __mpfr_set_z mpfr_set_z = Marshal.GetDelegateForFunctionPointer<__mpfr_set_z>(GetMpfrPointer(nameof(mpfr_set_z)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_set_q(ref __mpfr_t rop, ref __mpq_t op, mpfr_rnd_t rnd);
        public static __mpfr_set_q mpfr_set_q = Marshal.GetDelegateForFunctionPointer<__mpfr_set_q>(GetMpfrPointer(nameof(mpfr_set_q)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_set_f(ref __mpfr_t rop, ref __mpf_t op, mpfr_rnd_t rnd);
        public static __mpfr_set_f mpfr_set_f = Marshal.GetDelegateForFunctionPointer<__mpfr_set_f>(GetMpfrPointer(nameof(mpfr_set_f)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_set_ui_2exp(ref __mpfr_t rop, ulong op, long e, mpfr_rnd_t rnd);
        public static __mpfr_set_ui_2exp mpfr_set_ui_2exp = Marshal.GetDelegateForFunctionPointer<__mpfr_set_ui_2exp>(GetMpfrPointer(nameof(mpfr_set_ui_2exp)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_set_si_2exp(ref __mpfr_t rop, long op, long e, mpfr_rnd_t rnd);
        public static __mpfr_set_si_2exp mpfr_set_si_2exp = Marshal.GetDelegateForFunctionPointer<__mpfr_set_si_2exp>(GetMpfrPointer(nameof(mpfr_set_si_2exp)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_set_uj_2exp(ref __mpfr_t rop, uint op, long e, mpfr_rnd_t rnd);
        public static __mpfr_set_uj_2exp mpfr_set_uj_2exp = Marshal.GetDelegateForFunctionPointer<__mpfr_set_uj_2exp>(GetMpfrPointer($"__g{nameof(mpfr_set_uj_2exp)}"));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_set_sj_2exp(ref __mpfr_t rop, int op, long e, mpfr_rnd_t rnd);
        public static __mpfr_set_sj_2exp mpfr_set_sj_2exp = Marshal.GetDelegateForFunctionPointer<__mpfr_set_sj_2exp>(GetMpfrPointer($"__g{nameof(mpfr_set_sj_2exp)}"));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_set_z_2exp(ref __mpfr_t rop, ref __mpz_t op, long e, mpfr_rnd_t rnd);
        public static __mpfr_set_z_2exp mpfr_set_z_2exp = Marshal.GetDelegateForFunctionPointer<__mpfr_set_z_2exp>(GetMpfrPointer(nameof(mpfr_set_z_2exp)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate int __mpfr_set_str(ref __mpfr_t rop, string str, uint strbase, mpfr_rnd_t rnd);
        public static __mpfr_set_str mpfr_set_str = Marshal.GetDelegateForFunctionPointer<__mpfr_set_str>(GetMpfrPointer(nameof(mpfr_set_str)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate int __mpfr_set_nan(ref __mpfr_t x);
        public static __mpfr_set_nan mpfr_set_nan = Marshal.GetDelegateForFunctionPointer<__mpfr_set_nan>(GetMpfrPointer(nameof(mpfr_set_nan)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate int __mpfr_set_inf(ref __mpfr_t x, int sign);
        public static __mpfr_set_inf mpfr_set_inf = Marshal.GetDelegateForFunctionPointer<__mpfr_set_inf>(GetMpfrPointer(nameof(mpfr_set_inf)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate int __mpfr_set_zero(ref __mpfr_t x, int sign);
        public static __mpfr_set_zero mpfr_set_zero = Marshal.GetDelegateForFunctionPointer<__mpfr_set_zero>(GetMpfrPointer(nameof(mpfr_set_zero)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpfr_swap(ref __mpfr_t x, ref __mpfr_t y);
        public static __mpfr_swap mpfr_swap = Marshal.GetDelegateForFunctionPointer<__mpfr_swap>(GetMpfrPointer(nameof(mpfr_swap)));
    }
}
