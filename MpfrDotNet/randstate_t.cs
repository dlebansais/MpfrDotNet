namespace MpirDotNet;

using System;
using static Interop.Mpir.NativeMethods;

/// <summary>
/// Represents a random state.
/// </summary>
public class randstate_t : IDisposable
{
    #region Init
    /// <summary>
    /// Creates a random state.
    /// </summary>
    /// <param name="algorithm">The algorithm.</param>
    /// <param name="parameters">The algorithm parameters.</param>
    /// <exception cref="ArgumentNullException"><paramref name="parameters"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="parameters"/> is not a valid combination of parameters for <paramref name="algorithm"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="algorithm"/> is not a value of <see cref="RngAlgorithm"/>, or the size of a linear congruential generator is greater than 128, or its m2exp is zero.</exception>
    public static randstate_t Create(RngAlgorithm algorithm = RngAlgorithm.Default, params object[] parameters)
    {
        if (algorithm is not (RngAlgorithm.Default or RngAlgorithm.MersenneTwister or RngAlgorithm.LinearCongruential))
            throw new ArgumentOutOfRangeException(nameof(algorithm), algorithm, "The algorithm is not a valid value.");

        if (parameters is null)
            throw new ArgumentNullException(nameof(parameters));

        return new randstate_t(algorithm, parameters);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="randstate_t"/> class.
    /// </summary>
    public randstate_t()
    {
        gmp.randinit_default(this);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="randstate_t"/> class.
    /// </summary>
    /// <param name="other">The other object.</param>
    /// <exception cref="ArgumentNullException"><paramref name="other"/> is <see langword="null"/>.</exception>
    /// <exception cref="ObjectDisposedException"><paramref name="other"/> is disposed.</exception>
    public randstate_t(randstate_t other)
    {
        if (other is null)
            throw new ArgumentNullException(nameof(other));

        gmp.randinit_set(this, other);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="randstate_t"/> class.
    /// </summary>
    /// <param name="algorithm">The algorithm.</param>
    /// <param name="parameters">The algorithm parameters.</param>
    private randstate_t(RngAlgorithm algorithm, object[] parameters)
    {
        switch (algorithm)
        {
            case RngAlgorithm.MersenneTwister:
                gmp.randinit_mt(this);
                break;

            case RngAlgorithm.LinearCongruential:
                if (parameters.Length == 3 && parameters[0] is mpz_t a && parameters[1] is ulong c && parameters[2] is ulong m2exp)
                    gmp.randinit_lc_2exp(this, a, c, m2exp);
                else if (parameters.Length == 1 && parameters[0] is ulong size)
                {
                    if (!gmp.randinit_lc_2exp_size(this, size))
                        throw new ArgumentOutOfRangeException(nameof(parameters), size, "The size must be 128 or less.");
                }
                else
                {
                    throw new ArgumentException("Invalid combination of parameters for this algorithm.", nameof(algorithm));
                }

                break;

            default:
                // Create leaves only RngAlgorithm.Default.
                gmp.randinit_default(this);
                break;
        }
    }

    /// <summary>
    /// Set by the gmp.randinit_* functions after a successful initialization, and cleared by gmp.randclear: a constructor
    /// that throws leaves no native state, and gmp_randclear would crash on a state that is not initialized.
    /// </summary>
#pragma warning disable SA1401 // Fields should be private
    internal bool IsNativeStateInitialized;
#pragma warning restore SA1401 // Fields should be private

    /// <summary>
    /// Throws if the state has been disposed, since its native memory is then released.
    /// </summary>
    /// <exception cref="ObjectDisposedException">The state is disposed.</exception>
    internal void ThrowIfDisposed()
    {
        if (IsDisposed)
            throw new ObjectDisposedException(nameof(randstate_t));
    }

#pragma warning disable SA1401 // Fields should be private
#pragma warning disable SA1600 // Elements should be documented
    internal __gmp_randstate_t Value;
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore SA1600 // Elements should be documented
    #endregion

    #region Implementation of IDisposable
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
    /// Finalizes an instance of the <see cref="randstate_t"/> class.
    /// </summary>
    ~randstate_t()
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
    /// Disposes of every reference that must be cleaned up.
    /// </summary>
    private void DisposeNow()
    {
        // gmp.randclear does nothing for a state that is not initialized, or already cleared.
        gmp.randclear(this);
    }
    #endregion
}
