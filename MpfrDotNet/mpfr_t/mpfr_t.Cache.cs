namespace MpfrDotNet;

using System;
using System.Runtime.CompilerServices;
using System.Threading;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public partial class mpfr_t : IDisposable
{
    private void InitCacheManagement()
    {
        _ = Interlocked.Increment(ref OwnerObjectCount.Value);

        IsCacheInitialized = true;
    }

    private void DisposeCache()
    {
        // An object can be disposed on another thread, including the finalizer thread: it always
        // decrements the counter of the thread that created it. MPFR caches are per thread, so they
        // are freed only when that thread disposes its last object.
        long Remaining = Interlocked.Decrement(ref OwnerObjectCount.Value);

        if (Remaining == 0 && Environment.CurrentManagedThreadId == OwnerThreadId)
        {
            mpfr.free_cache();
            mpfr.free_cache2(0);
            mpfr.free_pool();
            mpfr.mp_memory_cleanup();
        }
    }

    private static StrongBox<long> GetCurrentThreadObjectCount()
    {
        StrongBox<long>? Count = ObjectCount.Value;

        if (Count is null)
        {
            Count = new StrongBox<long>();
            ObjectCount.Value = Count;
        }

        return Count;
    }

    private static readonly ThreadLocal<StrongBox<long>?> ObjectCount = new();
    private readonly StrongBox<long> OwnerObjectCount = GetCurrentThreadObjectCount();
    private readonly int OwnerThreadId = Environment.CurrentManagedThreadId;

    /// <summary>
    /// Returns the number of living items created by the current thread.
    /// </summary>
    public static ulong LiveObjectCount()
    {
        return (ulong)Interlocked.Read(ref GetCurrentThreadObjectCount().Value);
    }

    /// <summary>
    /// Gets a value indicating whether the cache is initialized.
    /// </summary>
    public bool IsCacheInitialized { get; private set; }
}
