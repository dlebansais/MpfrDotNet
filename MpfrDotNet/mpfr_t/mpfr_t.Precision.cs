namespace MpfrDotNet
{
    using System;
    using static Interop.Mpfr.NativeMethods;

    public partial class mpfr_t : IDisposable
    {
        public ulong MinPrecision { get { return NativeMinPrecision; } }
        public ulong MaxPrecision { get { return NativeMaxPrecision; } }

        public ulong Precision
        {
            get { return mpfr_get_prec(ref Value); }
            set { mpfr_set_prec(ref Value, value); }
        }

        public static ulong DefaultPrecision
        {
            get { return mpfr_get_default_prec(); }
            set { mpfr_set_default_prec(value); }
        }

        public static ulong DefaultPrecisionInit
        {
            get { return NativeDefaultPrecision; }
        }
    }
}
