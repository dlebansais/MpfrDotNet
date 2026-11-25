namespace Test;

using System;
using System.Threading;
using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

[TestFixture]
internal class SettingChecks
{
    [Test]
    public void TestPredefinedIntegersAreNewInstances()
    {
        using mpz_t First = mpz_t.Zero;
        First.SetBit(3);
        using mpz_t Second = mpz_t.Zero;
        using mpz_t One = mpz_t.One;
        using mpz_t Two = mpz_t.Two;
        using mpz_t Three = mpz_t.Three;
        using mpz_t Ten = mpz_t.Ten;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Second, Is.Not.SameAs(First));
        Assert.That(First.ToString(), Is.EqualTo("8"));
        Assert.That(Second.ToString(), Is.EqualTo("0"));
        Assert.That(One.ToString(), Is.EqualTo("1"));
        Assert.That(Two.ToString(), Is.EqualTo("2"));
        Assert.That(Three.ToString(), Is.EqualTo("3"));
        Assert.That(Ten.ToString(), Is.EqualTo("10"));
    }

    [Test]
    public void TestPrecisionSetterKeepsValue()
    {
        using mpfr_t Wider = new(1.5);
        using mpfr_t Narrower = new(1.75);

        Wider.Precision = 200UL;
        Narrower.Precision = 2UL;

        // 1.75 is halfway between 1.5 and 2 at 2 bits, and rounds to the even significand, 2.
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Wider.Precision, Is.EqualTo(200UL));
        Assert.That((double)Wider, Is.EqualTo(1.5));
        Assert.That(Wider.LastTernaryResult, Is.Zero);
        Assert.That(Narrower.Precision, Is.EqualTo(2UL));
        Assert.That((double)Narrower, Is.EqualTo(2.0));
        Assert.That(Narrower.LastTernaryResult, Is.Positive);
    }

    [Test]
    public void TestExponentRangeOutOfBounds()
    {
        int MinExponent = mpfr_t.MinExponent;
        int MaxExponent = mpfr_t.MaxExponent;

        try
        {
            mpfr_t.MinExponent = -100;
            mpfr_t.MaxExponent = 100;

            Assert.That((mpfr_t.MinExponent, mpfr_t.MaxExponent), Is.EqualTo((-100, 100)));

            // On Linux, exponents are 64-bit and every int is in the allowed range.
            if (mpfr_t.MinMinExponent > int.MinValue)
            {
                int TooSmall = mpfr_t.MinMinExponent - 1;
                int TooLarge = mpfr_t.MaxMaxExponent + 1;

                using IDisposable Scope = Assert.EnterMultipleScope();
                Assert.That(() => mpfr_t.MinExponent = TooSmall, Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith($"The exponent must be between {mpfr_t.MinMinExponent} and {mpfr_t.MaxMinExponent}."));
                Assert.That(() => mpfr_t.MaxExponent = TooLarge, Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith($"The exponent must be between {mpfr_t.MinMaxExponent} and {mpfr_t.MaxMaxExponent}."));
                Assert.That(mpfr_t.MinExponent, Is.EqualTo(-100));
                Assert.That(mpfr_t.MaxExponent, Is.EqualTo(100));
            }
        }
        finally
        {
            mpfr_t.MinExponent = MinExponent;
            mpfr_t.MaxExponent = MaxExponent;
        }
    }

    [Test]
    public void TestDefaultRoundingModeAppliesToNewInstances()
    {
        mpfr_rnd_t DefaultRoundingMode = mpfr_t.DefaultRoundingMode;
        mpfr_rnd_t OtherThreadRounding = DefaultRoundingMode;

        try
        {
            mpfr_t.DefaultRoundingMode = mpfr_rnd_t.MPFR_RNDU;

            using mpfr_t Number = new();
            using mpfr_t One = new(1);
            using mpfr_t Third = One / 3UL;

            // The setting belongs to the thread that made it.
            Thread Other = new(() =>
            {
                using mpfr_t OtherNumber = new();
                OtherThreadRounding = OtherNumber.Rounding;
            });

            Other.Start();
            Other.Join();

            using IDisposable Scope = Assert.EnterMultipleScope();
            Assert.That(Number.Rounding, Is.EqualTo(mpfr_rnd_t.MPFR_RNDU));
            Assert.That(One.Rounding, Is.EqualTo(mpfr_rnd_t.MPFR_RNDU));
            Assert.That(Third.LastTernaryResult, Is.Positive);
            Assert.That(OtherThreadRounding, Is.EqualTo(mpfr_rnd_t.MPFR_RNDN));
        }
        finally
        {
            mpfr_t.DefaultRoundingMode = DefaultRoundingMode;
        }
    }
}
