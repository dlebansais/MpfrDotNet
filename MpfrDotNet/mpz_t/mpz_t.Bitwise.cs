namespace MpirDotNet;

using System;
using System.Numerics;
using System.Text;
using static Interop.Mpir.NativeMethods;

/// <summary>
/// Arbitrary precision integer.
/// </summary>
public partial class mpz_t : IDisposable, IEquatable<mpz_t>, ICloneable, IConvertible, IComparable, IComparable<mpz_t>
{
    /// <summary>
    /// Gets a specific bit.
    /// </summary>
    /// <param name="index">The bit index.</param>
    public bool GetBit(ulong index)
    {
        return mpz_tstbit(ref Value, (mp_bitcnt_t)index) != 0;
    }

    /// <summary>
    /// Sets a specific bit.
    /// </summary>
    /// <param name="index">The bit index.</param>
    public void SetBit(ulong index)
    {
        mpz_setbit(ref Value, (mp_bitcnt_t)index);
    }

    /// <summary>
    /// Clears a specific bit.
    /// </summary>
    /// <param name="index">The bit index.</param>
    public void ClearBit(ulong index)
    {
        mpz_clrbit(ref Value, (mp_bitcnt_t)index);
    }

    /// <summary>
    /// Toggles a specific bit.
    /// </summary>
    /// <param name="index">The bit index.</param>
    public void ComplementBit(ulong index)
    {
        mpz_combit(ref Value, (mp_bitcnt_t)index);
    }

    /// <summary>
    /// Changes a specific bit.
    /// </summary>
    /// <param name="index">The bit index.</param>
    /// <param name="isSet">The bit value.</param>
    public void ChangeBit(ulong index, bool isSet)
    {
        if (isSet)
            mpz_setbit(ref Value, (mp_bitcnt_t)index);
        else
            mpz_clrbit(ref Value, (mp_bitcnt_t)index);
    }
}
