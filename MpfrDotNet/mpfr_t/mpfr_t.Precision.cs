namespace MpfrDotNet.mpfr
{
    using System;
    using static NativeMethods;

    public partial class mpfr_t : IDisposable
    {
        public ulong PrecisionMin { get { return NativeMethods.PrecisionMin; } }
        public ulong PrecisionMax { get { return NativeMethods.PrecisionMax; } }

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
            get { return NativeMethods.PrecisionDefault; }
        }
    }
}
