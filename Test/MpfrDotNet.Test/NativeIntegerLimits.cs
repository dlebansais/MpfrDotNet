namespace Test;

using System;
using MpfrDotNet;
using NUnit.Framework;

// MPFR takes 64-bit integers on both platforms. The Windows build of MPFR used to abort for integers beyond 2^32 - 1
// in functions that compute their logarithm, and the vendored sources are patched for this (MpfrDotNet comments in
// mpfr\src\mpfr-impl.h, int_ceil_log2.c, set_ui_2exp.c and jn.c).
[TestFixture]
internal class NativeIntegerLimits
{
    private const ulong PowerOf32 = 1UL << 32;
    private const ulong PowerOf40 = 1UL << 40;

    [Test]
    public void TestMultiplyAndDivideByLargePowersOfTwo()
    {
        using mpfr_t x = new(1.5);
        using mpfr_t Product = x * PowerOf32;
        using mpfr_t NegativeProduct = x * -(long)PowerOf40;
        using mpfr_t Quotient = x / PowerOf40;
        using mpfr_t NegativeQuotient = x / -(long)PowerOf32;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That((double)Product, Is.EqualTo(1.5 * Math.Pow(2, 32)));
        Assert.That((double)NegativeProduct, Is.EqualTo(-1.5 * Math.Pow(2, 40)));
        Assert.That((double)Quotient, Is.EqualTo(1.5 * Math.Pow(2, -40)));
        Assert.That((double)NegativeQuotient, Is.EqualTo(-1.5 * Math.Pow(2, -32)));
    }

    [Test]
    public void TestTrigonometryWithLargePeriods()
    {
        using mpfr_t x = new(0.25);
        using mpfr_t y = new(0.7);
        using mpfr_t Cosine = x.Cos(PowerOf32);
        using mpfr_t Sine = x.Sin(PowerOf40);
        using mpfr_t Angle = mpfr_t.Atan2(x, y, PowerOf32 + 1UL);

        // cos(2 pi x / u) and sin(2 pi x / u) for a tiny angle, and atan2(x, y) * u / (2 pi).
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That((double)Cosine, Is.EqualTo(1.0).Within(1e-15));
        Assert.That((double)Sine, Is.EqualTo(2 * Math.PI * 0.25 / Math.Pow(2, 40)).Within(1e-25));
        Assert.That((double)Angle, Is.EqualTo(Math.Atan2(0.25, 0.7) * (Math.Pow(2, 32) + 1) / (2 * Math.PI)).Within(1e-3));
    }

    [Test]
    public void TestCompoundWithLargeExponent()
    {
        const long Exponent = (long)PowerOf32 + 1L;

        using mpfr_t x = new(1e-12);
        using mpfr_t Result = x.Compound(Exponent);

        // exp(n * log(1 + x)) for the double nearest to 1e-12, computed with 50 digits.
        Assert.That((double)Result, Is.EqualTo(1.0043042038879233));
    }

    [Test]
    public void TestRootAndPowerWithLargePowersOfTwo()
    {
        using mpfr_t x = new(1.5);
        using mpfr_t Root = x.NthRoot(PowerOf32);
        using mpfr_t NegativeRoot = x.NthRoot(-(long)PowerOf32);
        using mpfr_t Power = mpfr_t.Pow(PowerOf32, 3UL);
        using mpfr_t Expected = new(1, 96L);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That((double)Root, Is.EqualTo(Math.Exp(Math.Log(1.5) / Math.Pow(2, 32))));
        Assert.That((double)NegativeRoot, Is.EqualTo(Math.Exp(-Math.Log(1.5) / Math.Pow(2, 32))));
        Assert.That(Power.ToString(), Is.EqualTo(Expected.ToString()));
    }

    [Test]
    public void TestBesselWithLargeOrder()
    {
        using mpfr_t z = new(1.5);
        using mpfr_t Result = new();

        // J_n(1.5) is far below the smallest number for such an order.
        _ = mpfr.jn(Result, (long)PowerOf32, z, mpfr_rnd_t.MPFR_RNDN);

        Assert.That(Result.IsZero, Is.True);
    }

    [Test]
    public void TestSetWideIntegerNearMinimumExponent()
    {
        // 2^63 * 2^(emin - 40) = 2^(emin + 23), a normal number although the exponent is below emin.
        long Exponent = (long)mpfr_t.MinExponent - 40L;

        using mpfr_t Value = new(1UL << 63, Exponent);
        using mpfr_t Expected = new(1, (long)mpfr_t.MinExponent + 23L);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Value.IsZero, Is.False);
        Assert.That(Value.ToString(), Is.EqualTo(Expected.ToString()));
    }
}
