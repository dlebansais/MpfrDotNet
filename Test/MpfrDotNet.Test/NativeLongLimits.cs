namespace Test;

using System;
using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

// MPIR and MPFR take 64-bit integers on both platforms, but the Windows build kept some of them in a C long, which is
// 32-bit with MSVC. The vendored sources are patched (comments MpfrDotNet in the mpir and mpfr folders). GMP and MPFR on
// Linux give the same results.
[TestFixture]
internal class NativeLongLimits
{
    private const ulong PowerOf32 = 1UL << 32;

    [Test]
    public void TestKroneckerWithWideInteger()
    {
        // (2^32 + 3 / 6) = (a / 2)(a / 3) = -1 * 1: a mod 2^32 = 3 gave 0.
        const long a = (long)PowerOf32 + 3L;

        using mpz_t Six = new(6);
        using mpz_t Wide = new(a);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(mpz.si_kronecker(a, Six), Is.EqualTo(-1));
        Assert.That(mpz.kronecker(Wide, Six), Is.EqualTo(-1));
    }

    [Test]
    public void TestBinomialWithWideK()
    {
        using mpz_t n = new(PowerOf32 + 1UL);
        using mpz_t MinusTwo = new(-2);
        using mpz_t Result = new();
        using mpz_t NegativeResult = new();

        // binomial(2^32 + 1, 2^32) = 2^32 + 1, and binomial(-2, k) = (-1)^k (k + 1).
        mpz.bin_ui(Result, n, PowerOf32);
        mpz.bin_ui(NegativeResult, MinusTwo, PowerOf32 + 1UL);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Result.ToString(), Is.EqualTo("4294967297"));
        Assert.That(NegativeResult.ToString(), Is.EqualTo("-4294967298"));
    }

    [Test]
    public void TestGreatestCommonDivisorWithZero()
    {
        // gcd(u, 0) = |u| is returned when it fits in 64 bits: anything above 2^32 - 1 gave 0.
        using mpz_t Wide = new(-(1L << 40));
        using mpz_t Result = new();

        ulong Gcd = mpz.gcd_ui(Result, Wide, 0UL);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Gcd, Is.EqualTo(1UL << 40));
        Assert.That(Result.ToString(), Is.EqualTo("1099511627776"));
    }

    [Test]
    public void TestGammaOfWideInteger()
    {
        // Gamma(2^32 + 5) overflows; the integer shortcut took it for Gamma(5) = 24.
        using mpfr_t x = new(PowerOf32 + 5UL);

        mpfr.clear_flags();
        using mpfr_t Result = x.Gamma();
        bool IsOverflow = mpfr.overflow_p();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Result.IsInf, Is.True);
        Assert.That(IsOverflow, Is.True);
    }

    [Test]
    public void TestPowerWithWideTrailingZeros()
    {
        // 2^(2^32 + 3) has 2^32 + 4 bits, 512 MiB: the trailing zero bits were counted in 32 bits, which gave 8.
        using mpz_t Two = new(2);
        using mpz_t Power = Two.Pow(PowerOf32 + 3UL);
        ulong PowerBits = mpz.sizeinbase(Power, 2U);
        ulong PowerZeros = mpz.scan1(Power, 0UL);
        Power.Dispose();

        using mpz_t Result = new();
        mpz.ui_pow_ui(Result, 4UL, (PowerOf32 / 2UL) + 5UL);
        ulong ResultBits = mpz.sizeinbase(Result, 2U);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(PowerBits, Is.EqualTo(PowerOf32 + 4UL));
        Assert.That(PowerZeros, Is.EqualTo(PowerOf32 + 3UL));
        Assert.That(ResultBits, Is.EqualTo(PowerOf32 + 11UL));
    }

    [Test]
    public void TestRemoveWideFactorOfTwo()
    {
        // 3 * 2^(2^32): the count of removed factors 2 was truncated to 32 bits.
        using mpz_t Three = new(3);
        using mpz_t Two = new(2);
        using mpz_t Value = new();
        using mpz_t Result = new();
        mpz.mul_2exp(Value, Three, PowerOf32);

        ulong Count = mpz.remove(Result, Value, Two);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Count, Is.EqualTo(PowerOf32));
        Assert.That(Result.ToString(), Is.EqualTo("3"));
    }

    [Test]
    public void TestDoubleWithExponentOfHugeInteger()
    {
        // 3 * 2^(2^31) = 0.75 * 2^(2^31 + 2): the exponent did not fit a 32-bit long.
        using mpz_t Three = new(3);
        using mpz_t Value = new();
        mpz.mul_2exp(Value, Three, PowerOf32 / 2UL);

        mpz.get_d_2exp(Value, out double d, out long Exponent);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(d, Is.EqualTo(0.75));
        Assert.That(Exponent, Is.EqualTo((long)(PowerOf32 / 2UL) + 2L));
    }

    [Test]
    public void TestDoubleOfHugeOperands()
    {
        // A float of 2^25 + 1 limbs with a value of 1.5, and the rational 1 / 2^(2^31): with a 32-bit long,
        // mpn_get_d took the first for an overflow and wrapped the exponent of the second.
        using mpf_t SmallOne = new(1.0);
        using mpf_t Tiny = SmallOne >> int.MaxValue;
        using mpf_t Sum = new(1.5, ((1UL << 25) + 2UL) * 64UL);
        mpf.add(Sum, Sum, Tiny);
        using mpz_t IntegerOne = new(1);
        using mpz_t Denominator = new();
        mpz.mul_2exp(Denominator, IntegerOne, PowerOf32 / 2UL);
        using mpq_t Rational = new(IntegerOne, Denominator);

        double FloatValue = mpf.get_d(Sum);
        mpf.get_d_2exp(Sum, out double Significand, out long Exponent);
        double RationalValue = mpq.get_d(Rational);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(FloatValue, Is.EqualTo(1.5));
        Assert.That(Significand, Is.EqualTo(0.75));
        Assert.That(Exponent, Is.EqualTo(1L));
        Assert.That(RationalValue, Is.Zero);
    }
}
