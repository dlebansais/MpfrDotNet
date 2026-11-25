namespace MpirDotNet;

using System;
using Interop.Mpir;

/// <summary>
/// See http://mpir.org/mpir-3.0.0.pdf.
/// </summary>
public static class gmp
{
    #region Initialization
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="state">The state.</param>
    public static void randinit_default(randstate_t state)
    {
        NativeMethods.mp_randinit_default(ref state.Value);
        state.IsNativeStateInitialized = true;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="state">The state.</param>
    public static void randinit_mt(randstate_t state)
    {
        NativeMethods.mp_randinit_mt(ref state.Value);
        state.IsNativeStateInitialized = true;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="state">The state.</param>
    /// <param name="a">The value of a.</param>
    /// <param name="c">The value of c.</param>
    /// <param name="m2exp">The value of m2exp.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="m2exp"/> is less than 2, or greater than <see cref="mpf.MaxPrecision"/>.</exception>
    public static void randinit_lc_2exp(randstate_t state, mpz_t a, ulong c, ulong m2exp)
    {
        // GMP and MPIR abort the process when m2exp is zero. With 1, each step yields m2exp / 2 = 0 bits, and every
        // draw loops forever.
        if (m2exp < 2)
            throw new ArgumentOutOfRangeException(nameof(m2exp), m2exp, "The modulus exponent must be at least 2.");

        // The native code allocates m2exp bits for the seed, which wraps or overflows the size of an integer beyond that.
        if (m2exp > mpf.MaxPrecision)
            throw new ArgumentOutOfRangeException(nameof(m2exp), m2exp, $"The modulus exponent must be at most {mpf.MaxPrecision}.");

        NativeMethods.mp_randinit_lc_2exp(ref state.Value, ref a.Value, (NativeMethods.mpir_ui)c, (NativeMethods.mp_bitcnt_t)m2exp);
        state.IsNativeStateInitialized = true;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="state">The state.</param>
    /// <param name="size">The size.</param>
    /// <returns><see langword="true"/> if the state is initialized; <see langword="false"/> if <paramref name="size"/> is greater than 128, in which case the state is not initialized.</returns>
    public static bool randinit_lc_2exp_size(randstate_t state, ulong size)
    {
        bool IsInitialized = NativeMethods.mp_randinit_lc_2exp_size(ref state.Value, (NativeMethods.mp_bitcnt_t)size) != 0;
        state.IsNativeStateInitialized |= IsInitialized;

        return IsInitialized;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="op"/> is disposed.</exception>
    public static void randinit_set(randstate_t rop, randstate_t op)
    {
        op.ThrowIfDisposed();

        NativeMethods.mp_randinit_set(ref rop.Value, ref op.Value);
        rop.IsNativeStateInitialized = true;
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="state">The state.</param>
    /// <remarks>Clearing a state that is not initialized, or already cleared, does nothing.</remarks>
    public static void randclear(randstate_t state)
    {
        // The disposal of the state must not free the memory a second time, and gmp_randclear would crash on a
        // state that is not initialized.
        if (!state.IsNativeStateInitialized)
            return;

        NativeMethods.mp_randclear(ref state.Value);
        state.IsNativeStateInitialized = false;
    }
    #endregion

    #region Seeding
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="state">The state.</param>
    /// <param name="seed">The seed.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="state"/> is disposed.</exception>
    public static void randseed(randstate_t state, mpz_t seed)
    {
        state.ThrowIfDisposed();

        NativeMethods.mp_randseed(ref state.Value, ref seed.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="state">The state.</param>
    /// <param name="seed">The seed.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="state"/> is disposed.</exception>
    public static void randseed_ui(randstate_t state, ulong seed)
    {
        state.ThrowIfDisposed();

        NativeMethods.mp_randseed_ui(ref state.Value, (NativeMethods.mpir_ui)seed);
    }
    #endregion

    #region Miscellaneous
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="state">The state.</param>
    /// <param name="m2exp">The m2exp.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="state"/> is disposed.</exception>
    public static ulong urandomb_ui(randstate_t state, ulong m2exp)
    {
        state.ThrowIfDisposed();

        return (ulong)NativeMethods.mp_urandomb_ui(ref state.Value, (NativeMethods.mpir_ui)m2exp);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="state">The state.</param>
    /// <param name="n">The n.</param>
    /// <exception cref="ObjectDisposedException"><paramref name="state"/> is disposed.</exception>
    /// <exception cref="DivideByZeroException"><paramref name="n"/> is zero.</exception>
    public static ulong urandomm_ui(randstate_t state, ulong n)
    {
        state.ThrowIfDisposed();
        MpirArgument.CheckDivisor(n);

        return urandomm_ui(state, n, NativeMethods.IsMpir);
    }

    /// <summary>
    /// Calls gmp_urandomm_ui, or mpz_urandomm when MPIR would truncate the result.
    /// </summary>
    /// <param name="state">The state.</param>
    /// <param name="n">The n.</param>
    /// <param name="isMpir">True if the library is MPIR.</param>
    internal static ulong urandomm_ui(randstate_t state, ulong n, bool isMpir)
    {
        // MPIR's gmp_urandomm_ui keeps the random limb in an unsigned long, which is 32-bit on Windows: for a bound
        // above that range, the result would never reach 2^32.
        if (isMpir && n > uint.MaxValue)
        {
            using mpz_t Bound = new(n);
            using mpz_t Result = new();
            NativeMethods.mpz_urandomm(ref Result.Value, ref state.Value, ref Bound.Value);

            return (ulong)Result;
        }

        return (ulong)NativeMethods.mp_urandomm_ui(ref state.Value, (NativeMethods.mpir_ui)n);
    }
    #endregion
}
