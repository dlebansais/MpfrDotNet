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
    /// Adds two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpz_t operator +(mpz_t x, mpz_t y)
    {
        mpz_t z = new();

        mpz_add(ref z.Value, ref x.Value, ref y.Value);

        return z;
    }

    /// <summary>
    /// Adds two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpz_t operator +(mpz_t x, long y)
    {
        mpz_t z = new();

        if (y >= 0)
            mpz_add_ui(ref z.Value, ref x.Value, (mpir_ui)(ulong)y);
        else
            mpz_sub_ui(ref z.Value, ref x.Value, (mpir_ui)(ulong)-y);

        return z;
    }

    /// <summary>
    /// Adds two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpz_t operator +(long x, mpz_t y)
    {
        mpz_t z = new();

        if (x >= 0)
            mpz_add_ui(ref z.Value, ref y.Value, (mpir_ui)(ulong)x);
        else
            mpz_sub_ui(ref z.Value, ref y.Value, (mpir_ui)(ulong)-x);

        return z;
    }

    /// <summary>
    /// Adds two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpz_t operator +(mpz_t x, ulong y)
    {
        mpz_t z = new mpz_t();

        mpz_add_ui(ref z.Value, ref x.Value, (mpir_ui)y);

        return z;
    }

    /// <summary>
    /// Adds two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpz_t operator +(ulong x, mpz_t y)
    {
        mpz_t z = new mpz_t();

        mpz_add_ui(ref z.Value, ref y.Value, (mpir_ui)x);

        return z;
    }

    /// <summary>
    /// Increments an operand.
    /// </summary>
    /// <param name="x">The operand.</param>
    public static mpz_t operator ++(mpz_t x)
    {
        using mpz_t z = new mpz_t();

        mpz_add_ui(ref z.Value, ref x.Value, (mpir_ui)1UL);
        mpz_set(ref x.Value, ref z.Value);

        return x;
    }

    /// <summary>
    /// Subtracts two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpz_t operator -(mpz_t x, mpz_t y)
    {
        mpz_t z = new mpz_t();

        mpz_sub(ref z.Value, ref x.Value, ref y.Value);

        return z;
    }

    /// <summary>
    /// Subtracts two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpz_t operator -(long x, mpz_t y)
    {
        if (x >= 0)
        {
            mpz_t z = new mpz_t();

            mpz_ui_sub(ref z.Value, (mpir_ui)(ulong)x, ref y.Value);

            return z;
        }
        else
        {
            mpz_t z = new mpz_t();

            mpz_add_ui(ref z.Value, ref y.Value, (mpir_ui)(ulong)-x);
            mpz_neg(ref z.Value, ref z.Value);

            return z;
        }
    }

    /// <summary>
    /// Subtracts two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpz_t operator -(mpz_t x, long y)
    {
        mpz_t z = new mpz_t();

        if (y >= 0)
            mpz_sub_ui(ref z.Value, ref x.Value, (mpir_ui)(ulong)y);
        else
            mpz_add_ui(ref z.Value, ref x.Value, (mpir_ui)(ulong)-y);

        return z;
    }

    /// <summary>
    /// Subtracts two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpz_t operator -(ulong x, mpz_t y)
    {
        mpz_t z = new mpz_t();

        mpz_ui_sub(ref z.Value, (mpir_ui)x, ref y.Value);

        return z;
    }

    /// <summary>
    /// Subtracts two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpz_t operator -(mpz_t x, ulong y)
    {
        mpz_t z = new mpz_t();

        mpz_sub_ui(ref z.Value, ref x.Value, (mpir_ui)y);

        return z;
    }

    /// <summary>
    /// Decrements an operand.
    /// </summary>
    /// <param name="x">The operand.</param>
    public static mpz_t operator --(mpz_t x)
    {
        using mpz_t z = new mpz_t();

        mpz_sub_ui(ref z.Value, ref x.Value, (mpir_ui)1UL);
        mpz_set(ref x.Value, ref z.Value);

        return x;
    }

    /// <summary>
    /// Multiplies two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpz_t operator *(mpz_t x, mpz_t y)
    {
        mpz_t z = new mpz_t();

        mpz_mul(ref z.Value, ref x.Value, ref y.Value);

        return z;
    }

    /// <summary>
    /// Multiplies two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpz_t operator *(long x, mpz_t y)
    {
        mpz_t z = new mpz_t();

        mpz_mul_si(ref z.Value, ref y.Value, (mpir_si)x);

        return z;
    }

    /// <summary>
    /// Multiplies two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpz_t operator *(mpz_t x, long y)
    {
        mpz_t z = new mpz_t();

        mpz_mul_si(ref z.Value, ref x.Value, (mpir_si)y);

        return z;
    }

    /// <summary>
    /// Multiplies two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpz_t operator *(ulong x, mpz_t y)
    {
        mpz_t z = new mpz_t();

        mpz_mul_ui(ref z.Value, ref y.Value, (mpir_ui)x);

        return z;
    }

    /// <summary>
    /// Multiplies two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpz_t operator *(mpz_t x, ulong y)
    {
        mpz_t z = new mpz_t();

        mpz_mul_ui(ref z.Value, ref x.Value, (mpir_ui)y);

        return z;
    }

    /// <summary>
    /// Shifts an operand to the left.
    /// </summary>
    /// <param name="x">The operand.</param>
    /// <param name="count">The number of bits to shift.</param>
    public static mpz_t operator <<(mpz_t x, int count)
    {
        mpz_t z = new mpz_t();

        if (count >= 0)
            mpz_mul_2exp(ref z.Value, ref x.Value, (mp_bitcnt_t)(ulong)count);

        return z;
    }

    /// <summary>
    /// Shifts an operand to the right.
    /// </summary>
    /// <param name="x">The operand.</param>
    /// <param name="count">The number of bits to shift.</param>
    public static mpz_t operator >>(mpz_t x, int count)
    {
        mpz_t z = new mpz_t();

        if (count >= 0)
            mpz_tdiv_q_2exp(ref z.Value, ref x.Value, (mp_bitcnt_t)(ulong)count);

        return z;
    }

    /// <summary>
    /// Negates an operand.
    /// </summary>
    /// <param name="x">The operand.</param>
    public static mpz_t operator -(mpz_t x)
    {
        mpz_t z = new mpz_t();

        mpz_neg(ref z.Value, ref x.Value);

        return z;
    }

    /// <summary>
    /// Divides two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpz_t operator /(mpz_t x, mpz_t y)
    {
        mpz_t quotient = new mpz_t();

        mpz_tdiv_q(ref quotient.Value, ref x.Value, ref y.Value);

        return quotient;
    }

    /// <summary>
    /// Divides two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpz_t operator /(mpz_t x, long y)
    {
        if (y >= 0)
        {
            mpz_t quotient = new mpz_t();

            mpz_tdiv_q_ui(ref quotient.Value, ref x.Value, (mpir_ui)(ulong)y);

            return quotient;
        }
        else
        {
            mpz_t quotient = new mpz_t();

            mpz_tdiv_q_ui(ref quotient.Value, ref x.Value, (mpir_ui)(ulong)-y);
            mpz_neg(ref quotient.Value, ref quotient.Value);

            return quotient;
        }
    }

    /// <summary>
    /// Divides two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpz_t operator /(mpz_t x, ulong y)
    {
        mpz_t quotient = new mpz_t();

        mpz_tdiv_q_ui(ref quotient.Value, ref x.Value, (mpir_ui)y);

        return quotient;
    }

    /// <summary>
    /// Gets the modulo of an operand.
    /// </summary>
    /// <param name="x">The operand.</param>
    /// <param name="mod">The modulo.</param>
    public static mpz_t operator %(mpz_t x, mpz_t mod)
    {
        mpz_t z = new mpz_t();

        mpz_mod(ref z.Value, ref x.Value, ref mod.Value);

        return z;
    }

    /// <summary>
    /// Gets the modulo of an operand.
    /// </summary>
    /// <param name="x">The operand.</param>
    /// <param name="mod">The modulo.</param>
    public static mpz_t operator %(mpz_t x, long mod)
    {
        if (mod < 0)
            throw new ArgumentOutOfRangeException(nameof(mod));

        mpz_t z = new mpz_t();

        mpz_fdiv_r_ui(ref z.Value, ref x.Value, (mpir_ui)(ulong)mod);

        return z;
    }

    /// <summary>
    /// Gets the modulo of an operand.
    /// </summary>
    /// <param name="x">The operand.</param>
    /// <param name="mod">The modulo.</param>
    public static mpz_t operator %(mpz_t x, ulong mod)
    {
        mpz_t z = new mpz_t();

        mpz_fdiv_r_ui(ref z.Value, ref x.Value, (mpir_ui)mod);

        return z;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <(mpz_t x, mpz_t y)
    {
        return x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <(int x, mpz_t y)
    {
        return y.CompareTo(x) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <(mpz_t x, int y)
    {
        return x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <(uint x, mpz_t y)
    {
        return y.CompareTo(x) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <(mpz_t x, uint y)
    {
        return x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <(long x, mpz_t y)
    {
        return y.CompareTo(x) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <(mpz_t x, long y)
    {
        return x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <(ulong x, mpz_t y)
    {
        return y.CompareTo(x) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <(mpz_t x, ulong y)
    {
        return x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <(float x, mpz_t y)
    {
        return y.CompareTo(x) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <(mpz_t x, float y)
    {
        return x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <(double x, mpz_t y)
    {
        return y.CompareTo(x) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <(mpz_t x, double y)
    {
        return x.CompareTo(y) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <=(mpz_t x, mpz_t y)
    {
        return x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <=(int x, mpz_t y)
    {
        return y.CompareTo(x) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <=(mpz_t x, int y)
    {
        return x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <=(uint x, mpz_t y)
    {
        return y.CompareTo(x) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <=(mpz_t x, uint y)
    {
        return x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <=(long x, mpz_t y)
    {
        return y.CompareTo(x) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <=(mpz_t x, long y)
    {
        return x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <=(ulong x, mpz_t y)
    {
        return y.CompareTo(x) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <=(mpz_t x, ulong y)
    {
        return x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <=(float x, mpz_t y)
    {
        return y.CompareTo(x) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <=(mpz_t x, float y)
    {
        return x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <=(double x, mpz_t y)
    {
        return y.CompareTo(x) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator <=(mpz_t x, double y)
    {
        return x.CompareTo(y) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >(mpz_t x, mpz_t y)
    {
        return x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >(int x, mpz_t y)
    {
        return y.CompareTo(x) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >(mpz_t x, int y)
    {
        return x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >(uint x, mpz_t y)
    {
        return y.CompareTo(x) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >(mpz_t x, uint y)
    {
        return x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >(long x, mpz_t y)
    {
        return y.CompareTo(x) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >(mpz_t x, long y)
    {
        return x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >(ulong x, mpz_t y)
    {
        return y.CompareTo(x) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >(mpz_t x, ulong y)
    {
        return x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >(float x, mpz_t y)
    {
        return y.CompareTo(x) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >(mpz_t x, float y)
    {
        return x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >(double x, mpz_t y)
    {
        return y.CompareTo(x) < 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >(mpz_t x, double y)
    {
        return x.CompareTo(y) > 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >=(mpz_t x, mpz_t y)
    {
        return x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >=(int x, mpz_t y)
    {
        return y.CompareTo(x) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >=(mpz_t x, int y)
    {
        return x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >=(uint x, mpz_t y)
    {
        return y.CompareTo(x) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >=(mpz_t x, uint y)
    {
        return x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >=(long x, mpz_t y)
    {
        return y.CompareTo(x) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >=(mpz_t x, long y)
    {
        return x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >=(ulong x, mpz_t y)
    {
        return y.CompareTo(x) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >=(mpz_t x, ulong y)
    {
        return x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >=(float x, mpz_t y)
    {
        return y.CompareTo(x) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >=(mpz_t x, float y)
    {
        return x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >=(double x, mpz_t y)
    {
        return y.CompareTo(x) <= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator >=(mpz_t x, double y)
    {
        return x.CompareTo(y) >= 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator ==(mpz_t x, mpz_t y)
    {
        return x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator ==(int x, mpz_t y)
    {
        return y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator ==(mpz_t x, int y)
    {
        return x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator ==(uint x, mpz_t y)
    {
        return y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator ==(mpz_t x, uint y)
    {
        return x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator ==(long x, mpz_t y)
    {
        return y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator ==(mpz_t x, long y)
    {
        return x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator ==(ulong x, mpz_t y)
    {
        return y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator ==(mpz_t x, ulong y)
    {
        return x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator ==(float x, mpz_t y)
    {
        return y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator ==(mpz_t x, float y)
    {
        return x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator ==(double x, mpz_t y)
    {
        return y.CompareTo(x) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator ==(mpz_t x, double y)
    {
        return x.CompareTo(y) == 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator !=(mpz_t x, mpz_t y)
    {
        return x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator !=(int x, mpz_t y)
    {
        return y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator !=(mpz_t x, int y)
    {
        return x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator !=(uint x, mpz_t y)
    {
        return y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator !=(mpz_t x, uint y)
    {
        return x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator !=(long x, mpz_t y)
    {
        return y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator !=(mpz_t x, long y)
    {
        return x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator !=(ulong x, mpz_t y)
    {
        return y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator !=(mpz_t x, ulong y)
    {
        return x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator !=(float x, mpz_t y)
    {
        return y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator !=(mpz_t x, float y)
    {
        return x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator !=(double x, mpz_t y)
    {
        return y.CompareTo(x) != 0;
    }

    /// <summary>
    /// Compares two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static bool operator !=(mpz_t x, double y)
    {
        return x.CompareTo(y) != 0;
    }

    /// <summary>
    /// Gets the bitwise and of two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpz_t operator &(mpz_t x, mpz_t y)
    {
        mpz_t z = new mpz_t();

        mpz_and(ref z.Value, ref x.Value, ref y.Value);

        return z;
    }

    /// <summary>
    /// Gets the bitwise or of two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpz_t operator |(mpz_t x, mpz_t y)
    {
        mpz_t z = new mpz_t();

        mpz_ior(ref z.Value, ref x.Value, ref y.Value);

        return z;
    }

    /// <summary>
    /// Gets the bitwise xor of two operands.
    /// </summary>
    /// <param name="x">The first operand.</param>
    /// <param name="y">The second operand.</param>
    public static mpz_t operator ^(mpz_t x, mpz_t y)
    {
        mpz_t z = new mpz_t();

        mpz_xor(ref z.Value, ref x.Value, ref y.Value);

        return z;
    }

    /// <summary>
    /// Gets the two's-complement of an operand.
    /// </summary>
    /// <param name="x">The operand.</param>
    public static mpz_t operator ~(mpz_t x)
    {
        mpz_t z = new mpz_t();

        mpz_com(ref z.Value, ref x.Value);

        return z;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object..</param>
    public override bool Equals(object? obj)
    {
        if (obj is mpz_t other)
            return CompareTo(other) != 0;
        else
            return false;
    }

    /// <summary>
    /// Gets the hash of the object.
    /// </summary>
    public override int GetHashCode()
    {
        return Convert.ToBase64String(ToByteArray()).GetHashCode();
    }
}
