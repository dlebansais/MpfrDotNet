namespace MpfrDotNet.mpfr
{
    using System.Runtime.InteropServices;

    internal static partial class NativeMethods
    {
        private static void InitializePrecision()
        {
            mpfr_get_prec_min = Marshal.GetDelegateForFunctionPointer<__mpfr_get_prec_min>(GetMpfrPointer(nameof(mpfr_get_prec_min)));
            PrecisionMin = mpfr_get_prec_min();

            mpfr_get_prec_max = Marshal.GetDelegateForFunctionPointer<__mpfr_get_prec_max>(GetMpfrPointer(nameof(mpfr_get_prec_max)));
            PrecisionMax = mpfr_get_prec_max();

            mpfr_get_default_prec = Marshal.GetDelegateForFunctionPointer<__mpfr_get_default_prec>(GetMpfrPointer(nameof(mpfr_get_default_prec)));
            PrecisionDefault = mpfr_get_default_prec();
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate ulong __mpfr_get_prec_min();
        public static __mpfr_get_prec_min mpfr_get_prec_min = Marshal.GetDelegateForFunctionPointer<__mpfr_get_prec_min>(GetMpfrPointer(nameof(mpfr_get_prec_min)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate ulong __mpfr_get_prec_max();
        public static __mpfr_get_prec_max mpfr_get_prec_max = Marshal.GetDelegateForFunctionPointer<__mpfr_get_prec_max>(GetMpfrPointer(nameof(mpfr_get_prec_max)));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate ulong __mpfr_get_default_prec();
        public static __mpfr_get_default_prec mpfr_get_default_prec = Marshal.GetDelegateForFunctionPointer<__mpfr_get_default_prec>(GetMpfrPointer(nameof(mpfr_get_default_prec)));

        public static ulong PrecisionMin { get; private set; }
        public static ulong PrecisionMax { get; private set; }
        public static ulong PrecisionDefault { get; private set; }
    }
}
