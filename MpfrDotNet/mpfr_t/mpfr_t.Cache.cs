namespace MpfrDotNet;

using System;
using System.Threading;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public partial class mpfr_t : IDisposable
{
    private void InitCacheManagement()
    {
        if (!ObjectCount.IsValueCreated)
            ObjectCount.Value = 1;
        else
            ObjectCount.Value++;

        if (!ObjectCountTest.IsValueCreated)
        {
            ObjectCountTest.Value = string.Empty;
            ObjectCount.Value = 1;
        }
        else
        {
            ObjectCountTest.Value = ObjectCount.ToString() ?? string.Empty;
        }

        IsCacheInitialized = true;
    }

    private void DisposeCache()
    {
        ObjectCount.Value--;

        if (ObjectCount.Value == 0)
        {
            mpfr_free_cache();
            mpfr_free_cache2(0);
            mpfr_free_pool();
            mpfr_mp_memory_cleanup();
        }
    }

    private static ThreadLocal<ulong> ObjectCount = new ThreadLocal<ulong>();
    private static ThreadLocal<string> ObjectCountTest = new ThreadLocal<string>();

    /// <summary>
    /// Returns the number of living items in cache.
    /// </summary>
    public static ulong LiveObjectCount()
    {
        return ObjectCount.Value;
    }

    /// <summary>
    /// Gets a value indicating whether the cache is initialized.
    /// </summary>
    public bool IsCacheInitialized { get; private set; }
}
