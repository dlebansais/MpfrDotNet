namespace MpfrDotNet;

using System;
using System.Diagnostics;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public partial class mpfr_t : IDisposable
{
    /// <summary>
    /// Called when an object should release its resources.
    /// </summary>
    /// <param name="isDisposing">Indicates if resources must be disposed now.</param>
    protected virtual void Dispose(bool isDisposing)
    {
        if (!IsDisposed)
        {
            IsDisposed = true;

            // Native memory is not managed by the garbage collector, so the finalizer releases it as well.
            DisposeNow();
        }
    }

    /// <summary>
    /// Called when an object should release its resources.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Finalizes an instance of the <see cref="mpfr_t"/> class.
    /// </summary>
    ~mpfr_t()
    {
        Dispose(false);
    }

    /// <summary>
    /// True after <see cref="Dispose(bool)"/> has been invoked.
    /// </summary>
#pragma warning disable SA1401 // Fields should be private
    internal bool IsDisposed;
#pragma warning restore SA1401 // Fields should be private

    /// <summary>
    /// Throws if a number has been disposed, since its native memory is then released.
    /// </summary>
    /// <param name="value">The number, or <see langword="null"/>, which is left to the caller to check.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="value"/> is disposed.</exception>
    internal static void ThrowIfDisposed(mpfr_t? value)
    {
        if (value is not null && value.IsDisposed)
            throw new ObjectDisposedException(nameof(mpfr_t));
    }

    /// <summary>
    /// Disposes of every reference that must be cleaned up.
    /// </summary>
    private void DisposeNow()
    {
        // mpfr.clear may already have released the native memory.
        if (Value.Limbs != IntPtr.Zero)
            mpfr.clear(this);

        DisposeCache();
    }
}
