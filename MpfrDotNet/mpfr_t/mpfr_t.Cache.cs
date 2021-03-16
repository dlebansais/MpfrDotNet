namespace MpfrDotNet.mpfr
{
    using System;
    using System.Threading;
    using static NativeMethods;

    public partial class mpfr_t : IDisposable
    {
        private void InitCacheManagement()
        {
            if (!ObjectCount.IsValueCreated)
                ObjectCount.Value = 0;
            else
                ObjectCount.Value++;

            IsCacheInitialized = true;
        }

        private void DisposeCache()
        {
            ObjectCount.Value--;

            if (ObjectCount.Value == 0)
                mpfr_free_cache();
        }

        private static ThreadLocal<ulong> ObjectCount = new ThreadLocal<ulong>();

        public static ulong LiveObjectCount()
        { 
            return ObjectCount.Value; 
        }

        public bool IsCacheInitialized { get; private set; }
    }
}
