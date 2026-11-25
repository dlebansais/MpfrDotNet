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
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="state">The state.</param>
    public static void randinit_mt(randstate_t state)
    {
        NativeMethods.mp_randinit_mt(ref state.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="state">The state.</param>
    /// <param name="a">The value of a.</param>
    /// <param name="c">The value of c.</param>
    /// <param name="m2exp">The value of m2exp.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="m2exp"/> is zero.</exception>
    public static void randinit_lc_2exp(randstate_t state, mpz_t a, ulong c, ulong m2exp)
    {
        // GMP and MPIR abort the process when m2exp is zero.
        if (m2exp == 0)
            throw new ArgumentOutOfRangeException(nameof(m2exp), m2exp, "The modulus exponent must be greater than zero.");

        NativeMethods.mp_randinit_lc_2exp(ref state.Value, ref a.Value, (NativeMethods.mpir_ui)c, (NativeMethods.mp_bitcnt_t)m2exp);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="state">The state.</param>
    /// <param name="size">The size.</param>
    /// <returns><see langword="true"/> if the state is initialized; <see langword="false"/> if <paramref name="size"/> is greater than 128, in which case the state is not initialized.</returns>
    public static bool randinit_lc_2exp_size(randstate_t state, ulong size)
    {
        return NativeMethods.mp_randinit_lc_2exp_size(ref state.Value, (NativeMethods.mp_bitcnt_t)size) != 0;
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
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="state">The state.</param>
    public static void randclear(randstate_t state)
    {
        NativeMethods.mp_randclear(ref state.Value);
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

        return (ulong)NativeMethods.mp_urandomm_ui(ref state.Value, (NativeMethods.mpir_ui)n);
    }
    #endregion
}
