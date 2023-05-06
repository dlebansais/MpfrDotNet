namespace MpirDotNet;

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
    public static void randinit_lc_2exp(randstate_t state, mpz_t a, ulong c, ulong m2exp)
    {
        NativeMethods.mp_randinit_lc_2exp(ref state.Value, ref a.Value, (NativeMethods.mpir_ui)c, (NativeMethods.mp_bitcnt_t)m2exp);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="state">The state.</param>
    /// <param name="size">The size.</param>
    public static void randinit_lc_2exp_size(randstate_t state, ulong size)
    {
        NativeMethods.mp_randinit_lc_2exp_size(ref state.Value, (NativeMethods.mp_bitcnt_t)size);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="rop">The result operand.</param>
    /// <param name="op">The operand.</param>
    public static void randinit_set(randstate_t rop, randstate_t op)
    {
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
    public static void randseed(randstate_t state, mpz_t seed)
    {
        NativeMethods.mp_randseed(ref state.Value, ref seed.Value);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="state">The state.</param>
    /// <param name="seed">The seed.</param>
    public static void randseed_ui(randstate_t state, ulong seed)
    {
        NativeMethods.mp_randseed_ui(ref state.Value, (NativeMethods.mpir_ui)seed);
    }
    #endregion

    #region Miscellaneous
    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="state">The state.</param>
    /// <param name="m2exp">The m2exp.</param>
    public static ulong urandomb_ui(randstate_t state, ulong m2exp)
    {
        return (ulong)NativeMethods.mp_urandomb_ui(ref state.Value, (NativeMethods.mpir_ui)m2exp);
    }

    /// <summary>
    /// See http://mpir.org/mpir-3.0.0.pdf.
    /// </summary>
    /// <param name="state">The state.</param>
    /// <param name="n">The n.</param>
    public static ulong urandomm_ui(randstate_t state, ulong n)
    {
        return (ulong)NativeMethods.mp_urandomm_ui(ref state.Value, (NativeMethods.mpir_ui)n);
    }
    #endregion
}
