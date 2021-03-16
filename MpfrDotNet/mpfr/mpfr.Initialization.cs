﻿namespace MpfrDotNet.mpfr
{
    using System;

    public static partial class mpfr
    {
        public static void init2(mpfr_t x, ulong prec)
        {
            NativeMethods.mpfr_init2(ref x.Value, prec);
        }

        public static void inits2(ulong prec, params mpfr_t[] x)
        {
            throw new NotImplementedException();
        }

        public static void clear(mpfr_t x)
        {
            NativeMethods.mpfr_clear(ref x.Value);
        }

        public static void clears(params mpfr_t[] x)
        {
            throw new NotImplementedException();
        }

        public static void init(mpfr_t x)
        {
            NativeMethods.mpfr_init(ref x.Value);
        }

        public static void inits(params mpfr_t[] x)
        {
            throw new NotImplementedException();
        }

        public static void set_default_prec(ulong prec)
        {
            NativeMethods.mpfr_set_default_prec(prec);
        }

        public static ulong get_default_prec()
        {
            return NativeMethods.mpfr_get_default_prec();
        }

        public static ulong PrecisionMin { get { return NativeMethods.PrecisionMin; } }
        public static ulong PrecisionMax { get { return NativeMethods.PrecisionMax; } }
        public static ulong tPrecisionDefaul { get { return NativeMethods.PrecisionDefault; } }

        public static void set_prec(mpfr_t x, ulong prec)
        {
            NativeMethods.mpfr_set_prec(ref x.Value, prec);
        }

        public static ulong get_prec(mpfr_t x)
        {
            return NativeMethods.mpfr_get_prec(ref x.Value);
        }

        public static void set_prec_raw(mpfr_t x, ulong prec)
        {
            NativeMethods.mpfr_set_prec_raw(ref x.Value, prec);
        }
    }
}
