namespace MpfrDotNet;

using System;
using MpirDotNet;
using static Interop.Mpfr.NativeMethods;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public partial class mpfr_t : IDisposable
{
    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    public int CompareTo(mpfr_t other)
    {
        return mpfr_cmp(ref Value, ref other.Value);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    public int CompareTo(ulong other)
    {
        return mpfr_cmp_ui(ref Value, other);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    public int CompareTo(long other)
    {
        return mpfr_cmp_si(ref Value, other);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    public int CompareTo(double other)
    {
        return mpfr_cmp_d(ref Value, other);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    public int CompareTo(mpz_t other)
    {
        return mpfr_cmp_z(ref Value, ref other.Value);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    public int CompareTo(mpq_t other)
    {
        return mpfr_cmp_q(ref Value, ref other.Value);
    }

    /// <summary>
    /// Compares with another number.
    /// </summary>
    /// <param name="other">The other number.</param>
    public int CompareTo(mpf_t other)
    {
        return mpfr_cmp_f(ref Value, ref other.Value);
    }

    /// <summary>
    /// Gets a value indicating whether the number is NAN.
    /// </summary>
    public bool IsNan { get { return mpfr_nan_p(ref Value) != 0; } }

    /// <summary>
    /// Gets a value indicating whether the number is infinity.
    /// </summary>
    public bool IsInf { get { return mpfr_inf_p(ref Value) != 0; } }

    /// <summary>
    /// Gets a value indicating whether the instance is a number.
    /// </summary>
    public bool IsNumber { get { return mpfr_number_p(ref Value) != 0; } }

    /// <summary>
    /// Gets a value indicating whether the number is zero.
    /// </summary>
    public bool IsZero { get { return mpfr_zero_p(ref Value) != 0; } }

    /// <summary>
    /// Gets a value indicating whether the number is regular.
    /// </summary>
    public bool IsRegular { get { return mpfr_regular_p(ref Value) != 0; } }

    /// <summary>
    /// Gets the sign.
    /// </summary>
    public int Sign { get { return mpfr_sgn(ref Value); } }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object..</param>
    public override bool Equals(object? obj)
    {
        if (obj is mpfr_t other)
            return mpfr_equal_p(ref Value, ref other.Value) == 0;
        else
            return false;
    }

    /// <summary>
    /// Gets a hash of the value.
    /// </summary>
    public override int GetHashCode()
    {
        double d = mpfr_get_d(ref Value, (__mpfr_rnd_t)DefaultRounding);
        return d.GetHashCode();
    }
}
