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
    public static randstate_t Create(RngAlgorithm algorithm = RngAlgorithm.Default, params object[] parameters)
    {
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
    public randstate_t(randstate_t other)
    {
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
            default:
            case RngAlgorithm.Default:
                gmp.randinit_default(this);
                break;

            case RngAlgorithm.MersenneTwister:
                gmp.randinit_mt(this);
                break;

            case RngAlgorithm.LinearCongruential:
                if (parameters.Length == 3 && parameters[0] is mpz_t a && parameters[1] is ulong c && parameters[2] is ulong m2exp)
                    gmp.randinit_lc_2exp(this, a, c, m2exp);
                else if (parameters.Length == 1 && parameters[0] is ulong size)
                {
                    if (!gmp.randinit_lc_2exp_size(this, size))
                    {
                        MarkNotInitialized();
                        throw new ArgumentOutOfRangeException(nameof(parameters), size, "The size must be 128 or less.");
                    }
                }
                else
                {
                    MarkNotInitialized();
                    throw new ArgumentException("Invalid combination of parameters for this algorithm.", nameof(algorithm));
                }

                break;
        }
    }

    private void MarkNotInitialized()
    {
        // There is no native state to release, and gmp_randclear would crash on a state that is not initialized.
        IsNativeStateMissing = true;
    }

    private bool IsNativeStateMissing;

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
        if (!IsNativeStateMissing)
            gmp.randclear(this);
    }
    #endregion
}
