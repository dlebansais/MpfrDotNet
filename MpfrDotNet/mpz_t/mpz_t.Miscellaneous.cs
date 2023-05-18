namespace MpirDotNet;

using System;
using static Interop.Mpir.NativeMethods;

/// <summary>
/// Arbitrary precision integer.
/// </summary>
public partial class mpz_t : IDisposable, IEquatable<mpz_t>, ICloneable, IConvertible, IComparable, IComparable<mpz_t>
{
    /// <summary>
    /// Complement bit <paramref name="n"/>.
    /// </summary>
    /// <param name="n">The bit index.</param>
    public mpz_t Complement(ulong n)
    {
        mpz_t z = new mpz_t();

        mpz.combit(z, n);

        return z;
    }
}
