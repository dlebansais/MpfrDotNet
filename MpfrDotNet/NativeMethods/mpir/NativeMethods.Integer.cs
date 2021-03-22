namespace MpirDotNet
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;

    internal static partial class NativeMethods
    {
        #region Initialization Functions
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_init(ref __mpz_t integer);
        public static __mpz_init mpz_init = Marshal.GetDelegateForFunctionPointer<__mpz_init>(GetMpirPointer(nameof(mpz_init)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_inits(IntPtr[] integers);
        public static __mpz_inits mpz_inits = Marshal.GetDelegateForFunctionPointer<__mpz_inits>(GetMpirPointer(nameof(mpz_inits)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_init2(ref __mpz_t integer, mp_bitcnt_t n);
        public static __mpz_init2 mpz_init2 = Marshal.GetDelegateForFunctionPointer<__mpz_init2>(GetMpirPointer(nameof(mpz_init2)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_clear(ref __mpz_t integer);
        public static __mpz_clear mpz_clear = Marshal.GetDelegateForFunctionPointer<__mpz_clear>(GetMpirPointer(nameof(mpz_clear)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_realloc2(ref __mpz_t integer, mp_bitcnt_t n);
        public static __mpz_realloc2 mpz_realloc2 = Marshal.GetDelegateForFunctionPointer<__mpz_realloc2>(GetMpirPointer(nameof(mpz_realloc2)));
        #endregion

        #region Assignment Functions
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_set(ref __mpz_t rop, ref __mpz_t op);
        public static __mpz_set mpz_set = Marshal.GetDelegateForFunctionPointer<__mpz_set>(GetMpirPointer(nameof(mpz_set)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_set_ui(ref __mpz_t rop, uint op);
        public static __mpz_set_ui mpz_set_ui = Marshal.GetDelegateForFunctionPointer<__mpz_set_ui>(GetMpirPointer(nameof(mpz_set_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_set_si(ref __mpz_t rop, int op);
        public static __mpz_set_si mpz_set_si = Marshal.GetDelegateForFunctionPointer<__mpz_set_si>(GetMpirPointer(nameof(mpz_set_si)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_set_ux(ref __mpz_t rop, uintmax_t op);
        public static __mpz_set_ux mpz_set_ux = Marshal.GetDelegateForFunctionPointer<__mpz_set_ux>(GetMpirPointer(nameof(mpz_set_ux)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_set_sx(ref __mpz_t rop, intmax_t op);
        public static __mpz_set_sx mpz_set_sx = Marshal.GetDelegateForFunctionPointer<__mpz_set_sx>(GetMpirPointer(nameof(mpz_set_sx)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_set_d(ref __mpz_t rop, double op);
        public static __mpz_set_d mpz_set_d = Marshal.GetDelegateForFunctionPointer<__mpz_set_d>(GetMpirPointer(nameof(mpz_set_d)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_set_q(ref __mpz_t rop, ref __mpq_t op);
        public static __mpz_set_q mpz_set_q = Marshal.GetDelegateForFunctionPointer<__mpz_set_q>(GetMpirPointer(nameof(mpz_set_q)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_set_f(ref __mpz_t rop, ref __mpf_t op);
        public static __mpz_set_f mpz_set_f = Marshal.GetDelegateForFunctionPointer<__mpz_set_f>(GetMpirPointer(nameof(mpz_set_f)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate int __mpz_set_str(ref __mpz_t rop, string str, uint strbase);
        public static __mpz_set_str mpz_set_str = Marshal.GetDelegateForFunctionPointer<__mpz_set_str>(GetMpirPointer(nameof(mpz_set_str)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_swap(ref __mpz_t rop1, ref __mpz_t rop2);
        public static __mpz_swap mpz_swap = Marshal.GetDelegateForFunctionPointer<__mpz_swap>(GetMpirPointer(nameof(mpz_swap)));
        #endregion

        #region Combined Initialization and Assignment Functions
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_init_set(ref __mpz_t rop, ref __mpz_t op);
        public static __mpz_init_set mpz_init_set = Marshal.GetDelegateForFunctionPointer<__mpz_init_set>(GetMpirPointer(nameof(mpz_init_set)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_init_set_ui(ref __mpz_t rop, uint op);
        public static __mpz_init_set_ui mpz_init_set_ui = Marshal.GetDelegateForFunctionPointer<__mpz_init_set_ui>(GetMpirPointer(nameof(mpz_init_set_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_init_set_si(ref __mpz_t rop, int op);
        public static __mpz_init_set_si mpz_init_set_si = Marshal.GetDelegateForFunctionPointer<__mpz_init_set_si>(GetMpirPointer(nameof(mpz_init_set_si)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_init_set_ux(ref __mpz_t rop, uintmax_t op);
        public static __mpz_init_set_ux mpz_init_set_ux = Marshal.GetDelegateForFunctionPointer<__mpz_init_set_ux>(GetMpirPointer(nameof(mpz_init_set_ux)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_init_set_sx(ref __mpz_t rop, intmax_t op);
        public static __mpz_init_set_sx mpz_init_set_sx = Marshal.GetDelegateForFunctionPointer<__mpz_init_set_sx>(GetMpirPointer(nameof(mpz_init_set_sx)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_init_set_d(ref __mpz_t rop, double op);
        public static __mpz_init_set_d mpz_init_set_d = Marshal.GetDelegateForFunctionPointer<__mpz_init_set_d>(GetMpirPointer(nameof(mpz_init_set_d)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate int __mpz_init_set_str(ref __mpz_t rop, string str, uint strbase);
        public static __mpz_init_set_str mpz_init_set_str = Marshal.GetDelegateForFunctionPointer<__mpz_init_set_str>(GetMpirPointer(nameof(mpz_init_set_str)));
        #endregion

        #region Conversion Functions
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint __mpz_get_ui(ref __mpz_t op);
        public static __mpz_get_ui mpz_get_ui = Marshal.GetDelegateForFunctionPointer<__mpz_get_ui>(GetMpirPointer(nameof(mpz_get_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_get_si(ref __mpz_t op);
        public static __mpz_get_si mpz_get_si = Marshal.GetDelegateForFunctionPointer<__mpz_get_si>(GetMpirPointer(nameof(mpz_get_si)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uintmax_t __mpz_get_ux(ref __mpz_t op);
        public static __mpz_get_ux mpz_get_ux = Marshal.GetDelegateForFunctionPointer<__mpz_get_ux>(GetMpirPointer(nameof(mpz_get_ux)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate intmax_t __mpz_get_sx(ref __mpz_t op);
        public static __mpz_get_sx mpz_get_sx = Marshal.GetDelegateForFunctionPointer<__mpz_get_sx>(GetMpirPointer(nameof(mpz_get_sx)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate double __mpz_get_d(ref __mpz_t op);
        public static __mpz_get_d mpz_get_d = Marshal.GetDelegateForFunctionPointer<__mpz_get_d>(GetMpirPointer(nameof(mpz_get_d)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate double __mpz_get_d_2exp(out int exp, ref __mpz_t op);
        public static __mpz_get_d_2exp mpz_get_d_2exp = Marshal.GetDelegateForFunctionPointer<__mpz_get_d_2exp>(GetMpirPointer(nameof(mpz_get_d_2exp)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate IntPtr __mpz_get_str(StringBuilder str, int _base, ref __mpz_t op);
        public static __mpz_get_str mpz_get_str = Marshal.GetDelegateForFunctionPointer<__mpz_get_str>(GetMpirPointer(nameof(mpz_get_str)));
        #endregion

        #region Arithmetic Functions
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_add(ref __mpz_t rop, ref __mpz_t op1, ref __mpz_t op2);
        public static __mpz_add mpz_add = Marshal.GetDelegateForFunctionPointer<__mpz_add>(GetMpirPointer(nameof(mpz_add)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_add_ui(ref __mpz_t rop, ref __mpz_t op1, uint op2);
        public static __mpz_add_ui mpz_add_ui = Marshal.GetDelegateForFunctionPointer<__mpz_add_ui>(GetMpirPointer(nameof(mpz_add_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_sub(ref __mpz_t rop, ref __mpz_t op1, ref __mpz_t op2);
        public static __mpz_sub mpz_sub = Marshal.GetDelegateForFunctionPointer<__mpz_sub>(GetMpirPointer(nameof(mpz_sub)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_sub_ui(ref __mpz_t rop, ref __mpz_t op1, uint op2);
        public static __mpz_sub_ui mpz_sub_ui = Marshal.GetDelegateForFunctionPointer<__mpz_sub_ui>(GetMpirPointer(nameof(mpz_sub_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_ui_sub(ref __mpz_t rop, uint op1, ref __mpz_t op2);
        public static __mpz_ui_sub mpz_ui_sub = Marshal.GetDelegateForFunctionPointer<__mpz_ui_sub>(GetMpirPointer(nameof(mpz_ui_sub)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_mul(ref __mpz_t rop, ref __mpz_t op1, ref __mpz_t op2);
        public static __mpz_mul mpz_mul = Marshal.GetDelegateForFunctionPointer<__mpz_mul>(GetMpirPointer(nameof(mpz_mul)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_mul_si(ref __mpz_t rop, ref __mpz_t op1, int op2);
        public static __mpz_mul_si mpz_mul_si = Marshal.GetDelegateForFunctionPointer<__mpz_mul_si>(GetMpirPointer(nameof(mpz_mul_si)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_mul_ui(ref __mpz_t rop, ref __mpz_t op1, uint op2);
        public static __mpz_mul_ui mpz_mul_ui = Marshal.GetDelegateForFunctionPointer<__mpz_mul_ui>(GetMpirPointer(nameof(mpz_mul_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_addmul(ref __mpz_t rop, ref __mpz_t op1, ref __mpz_t op2);
        public static __mpz_addmul mpz_addmul = Marshal.GetDelegateForFunctionPointer<__mpz_addmul>(GetMpirPointer(nameof(mpz_addmul)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_addmul_ui(ref __mpz_t rop, ref __mpz_t op1, uint op2);
        public static __mpz_addmul_ui mpz_addmul_ui = Marshal.GetDelegateForFunctionPointer<__mpz_addmul_ui>(GetMpirPointer(nameof(mpz_addmul_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_submul(ref __mpz_t rop, ref __mpz_t op1, ref __mpz_t op2);
        public static __mpz_submul mpz_submul = Marshal.GetDelegateForFunctionPointer<__mpz_submul>(GetMpirPointer(nameof(mpz_submul)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_submul_ui(ref __mpz_t rop, ref __mpz_t op1, uint op2);
        public static __mpz_submul_ui mpz_submul_ui = Marshal.GetDelegateForFunctionPointer<__mpz_submul_ui>(GetMpirPointer(nameof(mpz_submul_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_mul_2exp(ref __mpz_t rop, ref __mpz_t op1, mp_bitcnt_t op2);
        public static __mpz_mul_2exp mpz_mul_2exp = Marshal.GetDelegateForFunctionPointer<__mpz_mul_2exp>(GetMpirPointer(nameof(mpz_mul_2exp)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_neg(ref __mpz_t rop, ref __mpz_t op);
        public static __mpz_neg mpz_neg = Marshal.GetDelegateForFunctionPointer<__mpz_neg>(GetMpirPointer(nameof(mpz_neg)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_abs(ref __mpz_t rop, ref __mpz_t op);
        public static __mpz_abs mpz_abs = Marshal.GetDelegateForFunctionPointer<__mpz_abs>(GetMpirPointer(nameof(mpz_abs)));
        #endregion

        #region Division Functions
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_cdiv_q(ref __mpz_t q, ref __mpz_t n, ref __mpz_t d);
        public static __mpz_cdiv_q mpz_cdiv_q = Marshal.GetDelegateForFunctionPointer<__mpz_cdiv_q>(GetMpirPointer(nameof(mpz_cdiv_q)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_cdiv_r(ref __mpz_t r, ref __mpz_t n, ref __mpz_t d);
        public static __mpz_cdiv_r mpz_cdiv_r = Marshal.GetDelegateForFunctionPointer<__mpz_cdiv_r>(GetMpirPointer(nameof(mpz_cdiv_r)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_cdiv_qr(ref __mpz_t q, ref __mpz_t r, ref __mpz_t n, ref __mpz_t d);
        public static __mpz_cdiv_qr mpz_cdiv_qr = Marshal.GetDelegateForFunctionPointer<__mpz_cdiv_qr>(GetMpirPointer(nameof(mpz_cdiv_qr)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint __mpz_cdiv_q_ui(ref __mpz_t q, ref __mpz_t n, uint d);
        public static __mpz_cdiv_q_ui mpz_cdiv_q_ui = Marshal.GetDelegateForFunctionPointer<__mpz_cdiv_q_ui>(GetMpirPointer(nameof(mpz_cdiv_q_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint __mpz_cdiv_r_ui(ref __mpz_t r, ref __mpz_t n, uint d);
        public static __mpz_cdiv_r_ui mpz_cdiv_r_ui = Marshal.GetDelegateForFunctionPointer<__mpz_cdiv_r_ui>(GetMpirPointer(nameof(mpz_cdiv_r_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint __mpz_cdiv_qr_ui(ref __mpz_t q, ref __mpz_t r, ref __mpz_t n, uint d);
        public static __mpz_cdiv_qr_ui mpz_cdiv_qr_ui = Marshal.GetDelegateForFunctionPointer<__mpz_cdiv_qr_ui>(GetMpirPointer(nameof(mpz_cdiv_qr_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint __mpz_cdiv_ui(ref __mpz_t n, uint d);
        public static __mpz_cdiv_ui mpz_cdiv_ui = Marshal.GetDelegateForFunctionPointer<__mpz_cdiv_ui>(GetMpirPointer(nameof(mpz_cdiv_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_cdiv_q_2exp(ref __mpz_t q, ref __mpz_t n, mp_bitcnt_t b);
        public static __mpz_cdiv_q_2exp mpz_cdiv_q_2exp = Marshal.GetDelegateForFunctionPointer<__mpz_cdiv_q_2exp>(GetMpirPointer(nameof(mpz_cdiv_q_2exp)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_cdiv_r_2exp(ref __mpz_t r, ref __mpz_t n, mp_bitcnt_t b);
        public static __mpz_cdiv_r_2exp mpz_cdiv_r_2exp = Marshal.GetDelegateForFunctionPointer<__mpz_cdiv_r_2exp>(GetMpirPointer(nameof(mpz_cdiv_r_2exp)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_fdiv_q(ref __mpz_t q, ref __mpz_t n, ref __mpz_t d);
        public static __mpz_fdiv_q mpz_fdiv_q = Marshal.GetDelegateForFunctionPointer<__mpz_fdiv_q>(GetMpirPointer(nameof(mpz_fdiv_q)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_fdiv_r(ref __mpz_t r, ref __mpz_t n, ref __mpz_t d);
        public static __mpz_fdiv_r mpz_fdiv_r = Marshal.GetDelegateForFunctionPointer<__mpz_fdiv_r>(GetMpirPointer(nameof(mpz_fdiv_r)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_fdiv_qr(ref __mpz_t q, ref __mpz_t r, ref __mpz_t n, ref __mpz_t d);
        public static __mpz_fdiv_qr mpz_fdiv_qr = Marshal.GetDelegateForFunctionPointer<__mpz_fdiv_qr>(GetMpirPointer(nameof(mpz_fdiv_qr)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint __mpz_fdiv_q_ui(ref __mpz_t q, ref __mpz_t n, uint d);
        public static __mpz_fdiv_q_ui mpz_fdiv_q_ui = Marshal.GetDelegateForFunctionPointer<__mpz_fdiv_q_ui>(GetMpirPointer(nameof(mpz_fdiv_q_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint __mpz_fdiv_r_ui(ref __mpz_t r, ref __mpz_t n, uint d);
        public static __mpz_fdiv_r_ui mpz_fdiv_r_ui = Marshal.GetDelegateForFunctionPointer<__mpz_fdiv_r_ui>(GetMpirPointer(nameof(mpz_fdiv_r_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint __mpz_fdiv_qr_ui(ref __mpz_t q, ref __mpz_t r, ref __mpz_t n, uint d);
        public static __mpz_fdiv_qr_ui mpz_fdiv_qr_ui = Marshal.GetDelegateForFunctionPointer<__mpz_fdiv_qr_ui>(GetMpirPointer(nameof(mpz_fdiv_qr_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint __mpz_fdiv_ui(ref __mpz_t n, uint d);
        public static __mpz_fdiv_ui mpz_fdiv_ui = Marshal.GetDelegateForFunctionPointer<__mpz_fdiv_ui>(GetMpirPointer(nameof(mpz_fdiv_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_fdiv_q_2exp(ref __mpz_t q, ref __mpz_t n, mp_bitcnt_t b);
        public static __mpz_fdiv_q_2exp mpz_fdiv_q_2exp = Marshal.GetDelegateForFunctionPointer<__mpz_fdiv_q_2exp>(GetMpirPointer(nameof(mpz_fdiv_q_2exp)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_fdiv_r_2exp(ref __mpz_t r, ref __mpz_t n, mp_bitcnt_t b);
        public static __mpz_fdiv_r_2exp mpz_fdiv_r_2exp = Marshal.GetDelegateForFunctionPointer<__mpz_fdiv_r_2exp>(GetMpirPointer(nameof(mpz_fdiv_r_2exp)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_tdiv_q(ref __mpz_t q, ref __mpz_t n, ref __mpz_t d);
        public static __mpz_tdiv_q mpz_tdiv_q = Marshal.GetDelegateForFunctionPointer<__mpz_tdiv_q>(GetMpirPointer(nameof(mpz_tdiv_q)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_tdiv_r(ref __mpz_t r, ref __mpz_t n, ref __mpz_t d);
        public static __mpz_tdiv_r mpz_tdiv_r = Marshal.GetDelegateForFunctionPointer<__mpz_tdiv_r>(GetMpirPointer(nameof(mpz_tdiv_r)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_tdiv_qr(ref __mpz_t q, ref __mpz_t r, ref __mpz_t n, ref __mpz_t d);
        public static __mpz_tdiv_qr mpz_tdiv_qr = Marshal.GetDelegateForFunctionPointer<__mpz_tdiv_qr>(GetMpirPointer(nameof(mpz_tdiv_qr)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint __mpz_tdiv_q_ui(ref __mpz_t q, ref __mpz_t n, uint d);
        public static __mpz_tdiv_q_ui mpz_tdiv_q_ui = Marshal.GetDelegateForFunctionPointer<__mpz_tdiv_q_ui>(GetMpirPointer(nameof(mpz_tdiv_q_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint __mpz_tdiv_r_ui(ref __mpz_t r, ref __mpz_t n, uint d);
        public static __mpz_tdiv_r_ui mpz_tdiv_r_ui = Marshal.GetDelegateForFunctionPointer<__mpz_tdiv_r_ui>(GetMpirPointer(nameof(mpz_tdiv_r_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint __mpz_tdiv_qr_ui(ref __mpz_t q, ref __mpz_t r, ref __mpz_t n, uint d);
        public static __mpz_tdiv_qr_ui mpz_tdiv_qr_ui = Marshal.GetDelegateForFunctionPointer<__mpz_tdiv_qr_ui>(GetMpirPointer(nameof(mpz_tdiv_qr_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint __mpz_tdiv_ui(ref __mpz_t n, uint d);
        public static __mpz_tdiv_ui mpz_tdiv_ui = Marshal.GetDelegateForFunctionPointer<__mpz_tdiv_ui>(GetMpirPointer(nameof(mpz_tdiv_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_tdiv_q_2exp(ref __mpz_t q, ref __mpz_t n, mp_bitcnt_t b);
        public static __mpz_tdiv_q_2exp mpz_tdiv_q_2exp = Marshal.GetDelegateForFunctionPointer<__mpz_tdiv_q_2exp>(GetMpirPointer(nameof(mpz_tdiv_q_2exp)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_tdiv_r_2exp(ref __mpz_t r, ref __mpz_t n, mp_bitcnt_t b);
        public static __mpz_tdiv_r_2exp mpz_tdiv_r_2exp = Marshal.GetDelegateForFunctionPointer<__mpz_tdiv_r_2exp>(GetMpirPointer(nameof(mpz_tdiv_r_2exp)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_mod(ref __mpz_t r, ref __mpz_t n, ref __mpz_t d);
        public static __mpz_mod mpz_mod = Marshal.GetDelegateForFunctionPointer<__mpz_mod>(GetMpirPointer(nameof(mpz_mod)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_divexact(ref __mpz_t q, ref __mpz_t n, ref __mpz_t d);
        public static __mpz_divexact mpz_divexact = Marshal.GetDelegateForFunctionPointer<__mpz_divexact>(GetMpirPointer(nameof(mpz_divexact)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_divexact_ui(ref __mpz_t q, ref __mpz_t n, uint d);
        public static __mpz_divexact_ui mpz_divexact_ui = Marshal.GetDelegateForFunctionPointer<__mpz_divexact_ui>(GetMpirPointer(nameof(mpz_divexact_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_divisible_p(ref __mpz_t n, ref __mpz_t d);
        public static __mpz_divisible_p mpz_divisible_p = Marshal.GetDelegateForFunctionPointer<__mpz_divisible_p>(GetMpirPointer(nameof(mpz_divisible_p)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_divisible_ui_p(ref __mpz_t n, uint d);
        public static __mpz_divisible_ui_p mpz_divisible_ui_p = Marshal.GetDelegateForFunctionPointer<__mpz_divisible_ui_p>(GetMpirPointer(nameof(mpz_divisible_ui_p)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_divisible_2exp_p(ref __mpz_t n, mp_bitcnt_t b);
        public static __mpz_divisible_2exp_p mpz_divisible_2exp_p = Marshal.GetDelegateForFunctionPointer<__mpz_divisible_2exp_p>(GetMpirPointer(nameof(mpz_divisible_2exp_p)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_congruent_p(ref __mpz_t n, ref __mpz_t c, ref __mpz_t d);
        public static __mpz_congruent_p mpz_congruent_p = Marshal.GetDelegateForFunctionPointer<__mpz_congruent_p>(GetMpirPointer(nameof(mpz_congruent_p)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_congruent_ui_p(ref __mpz_t n, uint c, uint d);
        public static __mpz_congruent_ui_p mpz_congruent_ui_p = Marshal.GetDelegateForFunctionPointer<__mpz_congruent_ui_p>(GetMpirPointer(nameof(mpz_congruent_ui_p)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_congruent_2exp_p(ref __mpz_t n, ref __mpz_t c, mp_bitcnt_t b);
        public static __mpz_congruent_2exp_p mpz_congruent_2exp_p = Marshal.GetDelegateForFunctionPointer<__mpz_congruent_2exp_p>(GetMpirPointer(nameof(mpz_congruent_2exp_p)));
        #endregion

        #region Exponentiation Functions
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_powm(ref __mpz_t rop, ref __mpz_t _base, ref __mpz_t exp, ref __mpz_t mod);
        public static __mpz_powm mpz_powm = Marshal.GetDelegateForFunctionPointer<__mpz_powm>(GetMpirPointer(nameof(mpz_powm)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_powm_ui(ref __mpz_t rop, ref __mpz_t _base, uint exp, ref __mpz_t mod);
        public static __mpz_powm_ui mpz_powm_ui = Marshal.GetDelegateForFunctionPointer<__mpz_powm_ui>(GetMpirPointer(nameof(mpz_powm_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_pow_ui(ref __mpz_t rop, ref __mpz_t _base, uint exp);
        public static __mpz_pow_ui mpz_pow_ui = Marshal.GetDelegateForFunctionPointer<__mpz_pow_ui>(GetMpirPointer(nameof(mpz_pow_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_ui_pow_ui(ref __mpz_t rop, uint _base, uint exp);
        public static __mpz_ui_pow_ui mpz_ui_pow_ui = Marshal.GetDelegateForFunctionPointer<__mpz_ui_pow_ui>(GetMpirPointer(nameof(mpz_ui_pow_ui)));
        #endregion

        #region Root Extraction Functions
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_root(ref __mpz_t rop, ref __mpz_t op, uint n);
        public static __mpz_root mpz_root = Marshal.GetDelegateForFunctionPointer<__mpz_root>(GetMpirPointer(nameof(mpz_root)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_nthroot(ref __mpz_t rop, ref __mpz_t op, uint n);
        public static __mpz_nthroot mpz_nthroot = Marshal.GetDelegateForFunctionPointer<__mpz_nthroot>(GetMpirPointer(nameof(mpz_nthroot)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_rootrem(ref __mpz_t root, ref __mpz_t rem, ref __mpz_t u, uint n);
        public static __mpz_rootrem mpz_rootrem = Marshal.GetDelegateForFunctionPointer<__mpz_rootrem>(GetMpirPointer(nameof(mpz_rootrem)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_sqrt(ref __mpz_t rop, ref __mpz_t op);
        public static __mpz_sqrt mpz_sqrt = Marshal.GetDelegateForFunctionPointer<__mpz_sqrt>(GetMpirPointer(nameof(mpz_sqrt)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_sqrtrem(ref __mpz_t rop1, ref __mpz_t rop2, ref __mpz_t op);
        public static __mpz_sqrtrem mpz_sqrtrem = Marshal.GetDelegateForFunctionPointer<__mpz_sqrtrem>(GetMpirPointer(nameof(mpz_sqrtrem)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_perfect_power_p(ref __mpz_t rop);
        public static __mpz_perfect_power_p mpz_perfect_power_p = Marshal.GetDelegateForFunctionPointer<__mpz_perfect_power_p>(GetMpirPointer(nameof(mpz_perfect_power_p)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_perfect_square_p(ref __mpz_t rop);
        public static __mpz_perfect_square_p mpz_perfect_square_p = Marshal.GetDelegateForFunctionPointer<__mpz_perfect_square_p>(GetMpirPointer(nameof(mpz_perfect_square_p)));
        #endregion

        #region Number Theoretic Functions
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_probable_prime_p(ref __mpz_t n, ref __gmp_randstate_t state, int prob, uint div);
        public static __mpz_probable_prime_p mpz_probable_prime_p = Marshal.GetDelegateForFunctionPointer<__mpz_probable_prime_p>(GetMpirPointer(nameof(mpz_probable_prime_p)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_likely_prime_p(ref __mpz_t n, ref __gmp_randstate_t state, uint div);
        public static __mpz_likely_prime_p mpz_likely_prime_p = Marshal.GetDelegateForFunctionPointer<__mpz_likely_prime_p>(GetMpirPointer(nameof(mpz_likely_prime_p)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_next_prime_candidate(ref __mpz_t rop, ref __mpz_t op, ref __gmp_randstate_t state);
        public static __mpz_next_prime_candidate mpz_next_prime_candidate = Marshal.GetDelegateForFunctionPointer<__mpz_next_prime_candidate>(GetMpirPointer(nameof(mpz_next_prime_candidate)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_gcd(ref __mpz_t rop, ref __mpz_t op1, ref __mpz_t op2);
        public static __mpz_gcd mpz_gcd = Marshal.GetDelegateForFunctionPointer<__mpz_gcd>(GetMpirPointer(nameof(mpz_gcd)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint __mpz_gcd_ui(ref __mpz_t rop, ref __mpz_t op1, uint op2);
        public static __mpz_gcd_ui mpz_gcd_ui = Marshal.GetDelegateForFunctionPointer<__mpz_gcd_ui>(GetMpirPointer(nameof(mpz_gcd_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_gcdext(ref __mpz_t g, ref __mpz_t s, ref __mpz_t t, ref __mpz_t a, ref __mpz_t b);
        public static __mpz_gcdext mpz_gcdext = Marshal.GetDelegateForFunctionPointer<__mpz_gcdext>(GetMpirPointer(nameof(mpz_gcdext)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_lcm(ref __mpz_t rop, ref __mpz_t op1, ref __mpz_t op2);
        public static __mpz_lcm mpz_lcm = Marshal.GetDelegateForFunctionPointer<__mpz_lcm>(GetMpirPointer(nameof(mpz_lcm)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_lcm_ui(ref __mpz_t rop, ref __mpz_t op1, uint op2);
        public static __mpz_lcm_ui mpz_lcm_ui = Marshal.GetDelegateForFunctionPointer<__mpz_lcm_ui>(GetMpirPointer(nameof(mpz_lcm_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_invert(ref __mpz_t rop, ref __mpz_t op1, ref __mpz_t op2);
        public static __mpz_invert mpz_invert = Marshal.GetDelegateForFunctionPointer<__mpz_invert>(GetMpirPointer(nameof(mpz_invert)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_jacobi(ref __mpz_t a, ref __mpz_t b);
        public static __mpz_jacobi mpz_jacobi = Marshal.GetDelegateForFunctionPointer<__mpz_jacobi>(GetMpirPointer(nameof(mpz_jacobi)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_kronecker_si(ref __mpz_t a, int b);
        public static __mpz_kronecker_si mpz_kronecker_si = Marshal.GetDelegateForFunctionPointer<__mpz_kronecker_si>(GetMpirPointer(nameof(mpz_kronecker_si)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_kronecker_ui(ref __mpz_t a, uint b);
        public static __mpz_kronecker_ui mpz_kronecker_ui = Marshal.GetDelegateForFunctionPointer<__mpz_kronecker_ui>(GetMpirPointer(nameof(mpz_kronecker_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_si_kronecker(int a, ref __mpz_t b);
        public static __mpz_si_kronecker mpz_si_kronecker = Marshal.GetDelegateForFunctionPointer<__mpz_si_kronecker>(GetMpirPointer(nameof(mpz_si_kronecker)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_ui_kronecker(uint a, ref __mpz_t b);
        public static __mpz_ui_kronecker mpz_ui_kronecker = Marshal.GetDelegateForFunctionPointer<__mpz_ui_kronecker>(GetMpirPointer(nameof(mpz_ui_kronecker)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate mp_bitcnt_t __mpz_remove(ref __mpz_t rop, ref __mpz_t op, ref __mpz_t f);
        public static __mpz_remove mpz_remove = Marshal.GetDelegateForFunctionPointer<__mpz_remove>(GetMpirPointer(nameof(mpz_remove)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_fac_ui(ref __mpz_t rop, unsignedlongint n);
        public static __mpz_fac_ui mpz_fac_ui = Marshal.GetDelegateForFunctionPointer<__mpz_fac_ui>(GetMpirPointer(nameof(mpz_fac_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_2fac_ui(ref __mpz_t rop, unsignedlongint n);
        public static __mpz_2fac_ui mpz_2fac_ui = Marshal.GetDelegateForFunctionPointer<__mpz_2fac_ui>(GetMpirPointer(nameof(mpz_2fac_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_mfac_uiui(ref __mpz_t rop, unsignedlongint n, unsignedlongint m);
        public static __mpz_mfac_uiui mpz_mfac_uiui = Marshal.GetDelegateForFunctionPointer<__mpz_mfac_uiui>(GetMpirPointer(nameof(mpz_mfac_uiui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_primorial_ui(ref __mpz_t rop, unsignedlongint n);
        public static __mpz_primorial_ui mpz_primorial_ui = Marshal.GetDelegateForFunctionPointer<__mpz_primorial_ui>(GetMpirPointer(nameof(mpz_primorial_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_bin_ui(ref __mpz_t rop, ref __mpz_t n, uint k);
        public static __mpz_bin_ui mpz_bin_ui = Marshal.GetDelegateForFunctionPointer<__mpz_bin_ui>(GetMpirPointer(nameof(mpz_bin_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_bin_uiui(ref __mpz_t rop, uint n, uint k);
        public static __mpz_bin_uiui mpz_bin_uiui = Marshal.GetDelegateForFunctionPointer<__mpz_bin_uiui>(GetMpirPointer(nameof(mpz_bin_uiui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_fib_ui(ref __mpz_t fn, uint n);
        public static __mpz_fib_ui mpz_fib_ui = Marshal.GetDelegateForFunctionPointer<__mpz_fib_ui>(GetMpirPointer(nameof(mpz_fib_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_fib2_ui(ref __mpz_t fn, ref __mpz_t fnsub1, uint n);
        public static __mpz_fib2_ui mpz_fib2_ui = Marshal.GetDelegateForFunctionPointer<__mpz_fib2_ui>(GetMpirPointer(nameof(mpz_fib2_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_lucnum_ui(ref __mpz_t ln, uint n);
        public static __mpz_lucnum_ui mpz_lucnum_ui = Marshal.GetDelegateForFunctionPointer<__mpz_lucnum_ui>(GetMpirPointer(nameof(mpz_lucnum_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_lucnum2_ui(ref __mpz_t ln, ref __mpz_t lnsub1, uint n);
        public static __mpz_lucnum2_ui mpz_lucnum2_ui = Marshal.GetDelegateForFunctionPointer<__mpz_lucnum2_ui>(GetMpirPointer(nameof(mpz_lucnum2_ui)));
        #endregion

        #region Comparison Functions
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_cmp(ref __mpz_t op1, ref __mpz_t op2);
        public static __mpz_cmp mpz_cmp = Marshal.GetDelegateForFunctionPointer<__mpz_cmp>(GetMpirPointer(nameof(mpz_cmp)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_cmp_d(ref __mpz_t op1, double op2);
        public static __mpz_cmp_d mpz_cmp_d = Marshal.GetDelegateForFunctionPointer<__mpz_cmp_d>(GetMpirPointer(nameof(mpz_cmp_d)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_cmp_si(ref __mpz_t op1, int op2);
        public static __mpz_cmp_si mpz_cmp_si = Marshal.GetDelegateForFunctionPointer<__mpz_cmp_si>(GetMpirPointer(nameof(mpz_cmp_si)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_cmp_ui(ref __mpz_t op1, uint op2);
        public static __mpz_cmp_ui mpz_cmp_ui = Marshal.GetDelegateForFunctionPointer<__mpz_cmp_ui>(GetMpirPointer(nameof(mpz_cmp_ui)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_cmpabs(ref __mpz_t op1, ref __mpz_t op2);
        public static __mpz_cmpabs mpz_cmpabs = Marshal.GetDelegateForFunctionPointer<__mpz_cmpabs>(GetMpirPointer(nameof(mpz_cmpabs)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_cmpabs_d(ref __mpz_t op1, double op2);
        public static __mpz_cmpabs_d mpz_cmpabs_d = Marshal.GetDelegateForFunctionPointer<__mpz_cmpabs_d>(GetMpirPointer(nameof(mpz_cmpabs_d)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_cmpabs_ui(ref __mpz_t op1, uint op2);
        public static __mpz_cmpabs_ui mpz_cmpabs_ui = Marshal.GetDelegateForFunctionPointer<__mpz_cmpabs_ui>(GetMpirPointer(nameof(mpz_cmpabs_ui)));
        #endregion

        #region Logical and Bit Manipulation Functions
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_and(ref __mpz_t rop, ref __mpz_t op1, ref __mpz_t op2);
        public static __mpz_and mpz_and = Marshal.GetDelegateForFunctionPointer<__mpz_and>(GetMpirPointer(nameof(mpz_and)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_ior(ref __mpz_t rop, ref __mpz_t op1, ref __mpz_t op2);
        public static __mpz_ior mpz_ior = Marshal.GetDelegateForFunctionPointer<__mpz_ior>(GetMpirPointer(nameof(mpz_ior)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_xor(ref __mpz_t rop, ref __mpz_t op1, ref __mpz_t op2);
        public static __mpz_xor mpz_xor = Marshal.GetDelegateForFunctionPointer<__mpz_xor>(GetMpirPointer(nameof(mpz_xor)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_com(ref __mpz_t rop, ref __mpz_t op);
        public static __mpz_com mpz_com = Marshal.GetDelegateForFunctionPointer<__mpz_com>(GetMpirPointer(nameof(mpz_com)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate mp_bitcnt_t __mpz_popcount(ref __mpz_t op);
        public static __mpz_popcount mpz_popcount = Marshal.GetDelegateForFunctionPointer<__mpz_popcount>(GetMpirPointer(nameof(mpz_popcount)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate mp_bitcnt_t __mpz_hamdist(ref __mpz_t op1, ref __mpz_t op2);
        public static __mpz_hamdist mpz_hamdist = Marshal.GetDelegateForFunctionPointer<__mpz_hamdist>(GetMpirPointer(nameof(mpz_hamdist)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate mp_bitcnt_t __mpz_scan0(ref __mpz_t op, mp_bitcnt_t starting_bit);
        public static __mpz_scan0 mpz_scan0 = Marshal.GetDelegateForFunctionPointer<__mpz_scan0>(GetMpirPointer(nameof(mpz_scan0)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate mp_bitcnt_t __mpz_scan1(ref __mpz_t op, mp_bitcnt_t starting_bit);
        public static __mpz_scan1 mpz_scan1 = Marshal.GetDelegateForFunctionPointer<__mpz_scan1>(GetMpirPointer(nameof(mpz_scan1)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_setbit(ref __mpz_t rop, mp_bitcnt_t bit_index);
        public static __mpz_setbit mpz_setbit = Marshal.GetDelegateForFunctionPointer<__mpz_setbit>(GetMpirPointer(nameof(mpz_setbit)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_clrbit(ref __mpz_t rop, mp_bitcnt_t bit_index);
        public static __mpz_clrbit mpz_clrbit = Marshal.GetDelegateForFunctionPointer<__mpz_clrbit>(GetMpirPointer(nameof(mpz_clrbit)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_combit(ref __mpz_t rop, mp_bitcnt_t bit_index);
        public static __mpz_combit mpz_combit = Marshal.GetDelegateForFunctionPointer<__mpz_combit>(GetMpirPointer(nameof(mpz_combit)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_tstbit(ref __mpz_t op, mp_bitcnt_t bit_index);
        public static __mpz_tstbit mpz_tstbit = Marshal.GetDelegateForFunctionPointer<__mpz_tstbit>(GetMpirPointer(nameof(mpz_tstbit)));
        #endregion

        #region Random Number Functions
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_urandomb(ref __mpz_t rop, ref __gmp_randstate_t state, mp_bitcnt_t n);
        public static __mpz_urandomb mpz_urandomb = Marshal.GetDelegateForFunctionPointer<__mpz_urandomb>(GetMpirPointer(nameof(mpz_urandomb)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_urandomm(ref __mpz_t rop, ref __gmp_randstate_t state, ref __mpz_t n);
        public static __mpz_urandomm mpz_urandomm = Marshal.GetDelegateForFunctionPointer<__mpz_urandomm>(GetMpirPointer(nameof(mpz_urandomm)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_rrandomb(ref __mpz_t rop, ref __gmp_randstate_t state, mp_bitcnt_t n);
        public static __mpz_rrandomb mpz_rrandomb = Marshal.GetDelegateForFunctionPointer<__mpz_rrandomb>(GetMpirPointer(nameof(mpz_rrandomb)));
        #endregion

        #region Integer Import and Export
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_import(ref __mpz_t rop, size_t count, int order, size_t size, int endian, size_t nails, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] op);
        public static __mpz_import mpz_import = Marshal.GetDelegateForFunctionPointer<__mpz_import>(GetMpirPointer(nameof(mpz_import)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void __mpz_export([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] rop, out size_t countp, int order, size_t size, int endian, size_t nails, ref __mpz_t op);
        public static __mpz_export mpz_export = Marshal.GetDelegateForFunctionPointer<__mpz_export>(GetMpirPointer(nameof(mpz_export)));
        #endregion

        #region Miscellaneous Functions
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_fits_ulong_p(ref __mpz_t op);
        public static __mpz_fits_ulong_p mpz_fits_ulong_p = Marshal.GetDelegateForFunctionPointer<__mpz_fits_ulong_p>(GetMpirPointer(nameof(mpz_fits_ulong_p)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_fits_slong_p(ref __mpz_t op);
        public static __mpz_fits_slong_p mpz_fits_slong_p = Marshal.GetDelegateForFunctionPointer<__mpz_fits_slong_p>(GetMpirPointer(nameof(mpz_fits_slong_p)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_fits_uint_p(ref __mpz_t op);
        public static __mpz_fits_uint_p mpz_fits_uint_p = Marshal.GetDelegateForFunctionPointer<__mpz_fits_uint_p>(GetMpirPointer(nameof(mpz_fits_uint_p)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_fits_sint_p(ref __mpz_t op);
        public static __mpz_fits_sint_p mpz_fits_sint_p = Marshal.GetDelegateForFunctionPointer<__mpz_fits_sint_p>(GetMpirPointer(nameof(mpz_fits_sint_p)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_fits_ushort_p(ref __mpz_t op);
        public static __mpz_fits_ushort_p mpz_fits_ushort_p = Marshal.GetDelegateForFunctionPointer<__mpz_fits_ushort_p>(GetMpirPointer(nameof(mpz_fits_ushort_p)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int __mpz_fits_sshort_p(ref __mpz_t op);
        public static __mpz_fits_sshort_p mpz_fits_sshort_p = Marshal.GetDelegateForFunctionPointer<__mpz_fits_sshort_p>(GetMpirPointer(nameof(mpz_fits_sshort_p)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate size_t __mpz_sizeinbase(ref __mpz_t op, uint resultbase);
        public static __mpz_sizeinbase mpz_sizeinbase = Marshal.GetDelegateForFunctionPointer<__mpz_sizeinbase>(GetMpirPointer(nameof(mpz_sizeinbase)));

        public static int mpz_sgn(ref __mpz_t op)
        {
            return (op.LimbCount < 0) ? -1 : ((op.LimbCount > 0) ? 1 : 0);
        }
        #endregion
    }
}
