namespace MpfrDotNet
{
    using static Interop.Mpfr.NativeMethods;

    public static partial class mpfr
    {
        public static void free_cache()
        {
            mpfr_free_cache();
        }

        public static void free_cache2(int way)
        {
            mpfr_free_cache2(way);
        }

        public static void free_pool()
        {
            mpfr_free_pool();
        }

        public static int mp_memory_cleanup()
        {
            return mpfr_mp_memory_cleanup();
        }
    }
}
