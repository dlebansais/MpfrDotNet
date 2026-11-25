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
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public bool GetBit(ulong index)
    {
        ThrowIfDisposed(this);

        return mpz.tstbit(this, index);
    }

    /// <summary>
    /// Sets a specific bit.
    /// </summary>
    /// <param name="index">The bit index.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public void SetBit(ulong index)
    {
        ThrowIfDisposed(this);

        mpz.setbit(this, index);
    }

    /// <summary>
    /// Clears a specific bit.
    /// </summary>
    /// <param name="index">The bit index.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public void ClearBit(ulong index)
    {
        ThrowIfDisposed(this);

        mpz.clrbit(this, index);
    }

    /// <summary>
    /// Toggles a specific bit.
    /// </summary>
    /// <param name="index">The bit index.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public void ComplementBit(ulong index)
    {
        ThrowIfDisposed(this);

        mpz.combit(this, index);
    }

    /// <summary>
    /// Changes a specific bit.
    /// </summary>
    /// <param name="index">The bit index.</param>
    /// <param name="isSet">The bit value.</param>
    /// <exception cref="ObjectDisposedException">This number is disposed.</exception>
    public void ChangeBit(ulong index, bool isSet)
    {
        ThrowIfDisposed(this);

        if (isSet)
            mpz.setbit(this, index);
        else
            mpz.clrbit(this, index);
    }
}
