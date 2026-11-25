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
    /// Gets a new instance with the value -10.
    /// </summary>
    /// <remarks>Each call returns a new instance, which the caller owns and should dispose.</remarks>
    public static mpz_t NegativeTen => new(-10);

    /// <summary>
    /// Gets a new instance with the value -3.
    /// </summary>
    /// <remarks>Each call returns a new instance, which the caller owns and should dispose.</remarks>
    public static mpz_t NegativeThree => new(-3);

    /// <summary>
    /// Gets a new instance with the value -2.
    /// </summary>
    /// <remarks>Each call returns a new instance, which the caller owns and should dispose.</remarks>
    public static mpz_t NegativeTwo => new(-2);

    /// <summary>
    /// Gets a new instance with the value -1.
    /// </summary>
    /// <remarks>Each call returns a new instance, which the caller owns and should dispose.</remarks>
    public static mpz_t NegativeOne => new(-1);

    /// <summary>
    /// Gets a new instance with the value 0.
    /// </summary>
    /// <remarks>Each call returns a new instance, which the caller owns and should dispose.</remarks>
    public static mpz_t Zero => new(0);

    /// <summary>
    /// Gets a new instance with the value 1.
    /// </summary>
    /// <remarks>Each call returns a new instance, which the caller owns and should dispose.</remarks>
    public static mpz_t One => new(1);

    /// <summary>
    /// Gets a new instance with the value 2.
    /// </summary>
    /// <remarks>Each call returns a new instance, which the caller owns and should dispose.</remarks>
    public static mpz_t Two => new(2);

    /// <summary>
    /// Gets a new instance with the value 3.
    /// </summary>
    /// <remarks>Each call returns a new instance, which the caller owns and should dispose.</remarks>
    public static mpz_t Three => new(3);

    /// <summary>
    /// Gets a new instance with the value 10.
    /// </summary>
    /// <remarks>Each call returns a new instance, which the caller owns and should dispose.</remarks>
    public static mpz_t Ten => new(10);
}
