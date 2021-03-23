namespace MpfrDotNet
{
    using Interop.Mpfr;

    public static partial class mpfr
    {
        public static void free_cache()
        {
            NativeMethods.mpfr_free_cache();
        }

        public static void free_cache2(int way)
        {
            NativeMethods.mpfr_free_cache2(way);
        }

        public static void free_pool()
        {
            NativeMethods.mpfr_free_pool();
        }

        public static int mp_memory_cleanup()
        {
            return NativeMethods.mpfr_mp_memory_cleanup();
        }
    }
}
