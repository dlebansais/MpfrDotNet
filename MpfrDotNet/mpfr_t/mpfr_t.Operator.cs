namespace MpfrDotNet;

using System;
using MpirDotNet;

/// <summary>
/// Represents an arbitrary precision floating-point number.
/// </summary>
public partial class mpfr_t : IDisposable
{
    #region Add
    /// <summary>
    /// Adds two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator +(mpfr_t x, mpfr_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.add(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Adds two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator +(mpfr_t x, ulong y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.add_ui(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Adds two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator +(ulong x, mpfr_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.add_ui(z, y, x, y.Rounding);

        return z;
    }

    /// <summary>
    /// Adds two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator +(mpfr_t x, long y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.add_si(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Adds two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator +(long x, mpfr_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.add_si(z, y, x, y.Rounding);

        return z;
    }

    /// <summary>
    /// Adds two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator +(mpfr_t x, double y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.add_d(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Adds two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator +(double x, mpfr_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.add_d(z, y, x, y.Rounding);

        return z;
    }

    /// <summary>
    /// Adds two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator +(mpfr_t x, mpz_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.add_z(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Adds two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator +(mpz_t x, mpfr_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.add_z(z, y, x, y.Rounding);

        return z;
    }

    /// <summary>
    /// Adds two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator +(mpfr_t x, mpq_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.add_q(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Adds two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator +(mpq_t x, mpfr_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.add_q(z, y, x, y.Rounding);

        return z;
    }
    #endregion

    #region Sub
    /// <summary>
    /// Subtracts two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator -(mpfr_t x, mpfr_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.sub(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Subtracts two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator -(mpfr_t x, ulong y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.sub_ui(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Subtracts two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator -(ulong x, mpfr_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.ui_sub(z, x, y, y.Rounding);

        return z;
    }

    /// <summary>
    /// Subtracts two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator -(mpfr_t x, long y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.sub_si(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Subtracts two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator -(long x, mpfr_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.si_sub(z, x, y, y.Rounding);

        return z;
    }

    /// <summary>
    /// Subtracts two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator -(mpfr_t x, double y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.sub_d(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Subtracts two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator -(double x, mpfr_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.d_sub(z, x, y, y.Rounding);

        return z;
    }

    /// <summary>
    /// Subtracts two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator -(mpfr_t x, mpz_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.sub_z(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Subtracts two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator -(mpz_t x, mpfr_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.z_sub(z, x, y, y.Rounding);

        return z;
    }

    /// <summary>
    /// Subtracts two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator -(mpfr_t x, mpq_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.sub_q(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Subtracts two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator -(mpq_t x, mpfr_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.sub_q(z, y, x, y.Rounding);

        mpfr.neg(z, z, y.Rounding);
        z.LastTernaryResult = -z.LastTernaryResult;

        return z;
    }
    #endregion

    #region Mul
    /// <summary>
    /// Multiplies two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator *(mpfr_t x, mpfr_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.mul(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Multiplies two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator *(mpfr_t x, ulong y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.mul_ui(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Multiplies two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator *(ulong x, mpfr_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.mul_ui(z, y, x, y.Rounding);

        return z;
    }

    /// <summary>
    /// Multiplies two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator *(mpfr_t x, long y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.mul_si(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Multiplies two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator *(long x, mpfr_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.mul_si(z, y, x, y.Rounding);

        return z;
    }

    /// <summary>
    /// Multiplies two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator *(mpfr_t x, double y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.mul_d(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Multiplies two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator *(double x, mpfr_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.mul_d(z, y, x, y.Rounding);

        return z;
    }

    /// <summary>
    /// Multiplies two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator *(mpfr_t x, mpz_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.mul_z(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Multiplies two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator *(mpz_t x, mpfr_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.mul_z(z, y, x, y.Rounding);

        return z;
    }

    /// <summary>
    /// Multiplies two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator *(mpfr_t x, mpq_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.mul_q(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Multiplies two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator *(mpq_t x, mpfr_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.mul_q(z, y, x, y.Rounding);

        return z;
    }
    #endregion

    #region Div
    /// <summary>
    /// Divides two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator /(mpfr_t x, mpfr_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.div(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Divides two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator /(mpfr_t x, ulong y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.div_ui(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Divides two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator /(ulong x, mpfr_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.ui_div(z, x, y, y.Rounding);

        return z;
    }

    /// <summary>
    /// Divides two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator /(mpfr_t x, long y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.div_si(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Divides two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator /(long x, mpfr_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.si_div(z, x, y, y.Rounding);

        return z;
    }

    /// <summary>
    /// Divides two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator /(mpfr_t x, double y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.div_d(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Divides two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator /(double x, mpfr_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.d_div(z, x, y, y.Rounding);

        return z;
    }

    /// <summary>
    /// Divides two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator /(mpfr_t x, mpz_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.div_z(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Divides two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator /(mpz_t x, mpfr_t y)
    {
        mpfr_t z = new();

        mpfr.div_z(z, y, x, y.Rounding);
        z.LastTernaryResult = mpfr.ui_div(z, 1, z, y.Rounding);

        return z;
    }

    /// <summary>
    /// Divides two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator /(mpfr_t x, mpq_t y)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.div_q(z, x, y, x.Rounding);

        return z;
    }

    /// <summary>
    /// Divides two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static mpfr_t operator /(mpq_t x, mpfr_t y)
    {
        mpfr_t z = new();

        mpfr.div_q(z, y, x, y.Rounding);
        z.LastTernaryResult = mpfr.ui_div(z, 1, z, y.Rounding);

        return z;
    }
    #endregion

    #region Misc
    /// <summary>
    /// Negates a value.
    /// </summary>
    /// <param name="x">The value.</param>
    public static mpfr_t operator -(mpfr_t x)
    {
        mpfr_t z = new();

        z.LastTernaryResult = mpfr.neg(z, x, x.Rounding);

        return z;
    }
    #endregion

    #region Comparison
    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >(mpfr_t x, mpfr_t y)
    {
        return mpfr.greater_p(x, y);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >(mpfr_t x, ulong y)
    {
        return x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >(ulong x, mpfr_t y)
    {
        return y.CompareTo(x) < 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >(mpfr_t x, long y)
    {
        return x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >(long x, mpfr_t y)
    {
        return y.CompareTo(x) < 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >(mpfr_t x, double y)
    {
        return x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >(double x, mpfr_t y)
    {
        return y.CompareTo(x) < 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >(mpfr_t x, mpz_t y)
    {
        return x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >(mpz_t x, mpfr_t y)
    {
        return y.CompareTo(x) < 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >(mpfr_t x, mpq_t y)
    {
        return x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >(mpq_t x, mpfr_t y)
    {
        return y.CompareTo(x) < 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >(mpfr_t x, mpf_t y)
    {
        return x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >(mpf_t x, mpfr_t y)
    {
        return y.CompareTo(x) < 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >=(mpfr_t x, mpfr_t y)
    {
        return mpfr.greaterequal_p(x, y);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >=(mpfr_t x, ulong y)
    {
        return x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >=(ulong x, mpfr_t y)
    {
        return y.CompareTo(x) <= 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >=(mpfr_t x, long y)
    {
        return x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >=(long x, mpfr_t y)
    {
        return y.CompareTo(x) <= 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >=(mpfr_t x, double y)
    {
        return x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >=(double x, mpfr_t y)
    {
        return y.CompareTo(x) <= 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >=(mpfr_t x, mpz_t y)
    {
        return x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >=(mpz_t x, mpfr_t y)
    {
        return y.CompareTo(x) <= 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >=(mpfr_t x, mpq_t y)
    {
        return x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >=(mpq_t x, mpfr_t y)
    {
        return y.CompareTo(x) <= 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >=(mpfr_t x, mpf_t y)
    {
        return x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator >=(mpf_t x, mpfr_t y)
    {
        return y.CompareTo(x) <= 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <(mpfr_t x, mpfr_t y)
    {
        return mpfr.less_p(x, y);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <(mpfr_t x, ulong y)
    {
        return x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <(ulong x, mpfr_t y)
    {
        return y.CompareTo(x) > 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <(mpfr_t x, long y)
    {
        return x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <(long x, mpfr_t y)
    {
        return y.CompareTo(x) > 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <(mpfr_t x, double y)
    {
        return x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <(double x, mpfr_t y)
    {
        return y.CompareTo(x) > 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <(mpfr_t x, mpz_t y)
    {
        return x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <(mpz_t x, mpfr_t y)
    {
        return y.CompareTo(x) > 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <(mpfr_t x, mpq_t y)
    {
        return x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <(mpq_t x, mpfr_t y)
    {
        return y.CompareTo(x) > 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <(mpfr_t x, mpf_t y)
    {
        return x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <(mpf_t x, mpfr_t y)
    {
        return y.CompareTo(x) > 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <=(mpfr_t x, mpfr_t y)
    {
        return mpfr.lessequal_p(x, y);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <=(mpfr_t x, ulong y)
    {
        return x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <=(ulong x, mpfr_t y)
    {
        return y.CompareTo(x) >= 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <=(mpfr_t x, long y)
    {
        return x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <=(long x, mpfr_t y)
    {
        return y.CompareTo(x) >= 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <=(mpfr_t x, double y)
    {
        return x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <=(double x, mpfr_t y)
    {
        return y.CompareTo(x) >= 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <=(mpfr_t x, mpz_t y)
    {
        return x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <=(mpz_t x, mpfr_t y)
    {
        return y.CompareTo(x) >= 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <=(mpfr_t x, mpq_t y)
    {
        return x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <=(mpq_t x, mpfr_t y)
    {
        return y.CompareTo(x) >= 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <=(mpfr_t x, mpf_t y)
    {
        return x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator <=(mpf_t x, mpfr_t y)
    {
        return y.CompareTo(x) >= 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator ==(mpfr_t x, mpfr_t y)
    {
        return mpfr.equal_p(x, y);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator ==(mpfr_t x, ulong y)
    {
        return x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator ==(ulong x, mpfr_t y)
    {
        return y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator ==(mpfr_t x, long y)
    {
        return x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator ==(long x, mpfr_t y)
    {
        return y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator ==(mpfr_t x, double y)
    {
        return x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator ==(double x, mpfr_t y)
    {
        return y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator ==(mpfr_t x, mpz_t y)
    {
        return x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator ==(mpz_t x, mpfr_t y)
    {
        return y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator ==(mpfr_t x, mpq_t y)
    {
        return x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator ==(mpq_t x, mpfr_t y)
    {
        return y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator ==(mpfr_t x, mpf_t y)
    {
        return x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator ==(mpf_t x, mpfr_t y)
    {
        return y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator !=(mpfr_t x, mpfr_t y)
    {
        return !mpfr.equal_p(x, y);
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator !=(mpfr_t x, ulong y)
    {
        return x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator !=(ulong x, mpfr_t y)
    {
        return y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator !=(mpfr_t x, long y)
    {
        return x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator !=(long x, mpfr_t y)
    {
        return y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator !=(mpfr_t x, double y)
    {
        return x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator !=(double x, mpfr_t y)
    {
        return y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator !=(mpfr_t x, mpz_t y)
    {
        return x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator !=(mpz_t x, mpfr_t y)
    {
        return y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator !=(mpfr_t x, mpq_t y)
    {
        return x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator !=(mpq_t x, mpfr_t y)
    {
        return y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator !=(mpfr_t x, mpf_t y)
    {
        return x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two values.
    /// </summary>
    /// <param name="x">The first value.</param>
    /// <param name="y">The second value.</param>
    public static bool operator !=(mpf_t x, mpfr_t y)
    {
        return y.CompareTo(x) != 0;
    }
    #endregion
}
