namespace Test;

using System;
using MpirDotNet;
using NUnit.Framework;

// GMP raises SIGFPE for these errors, which ends the process on Linux: the library must detect them first.
[TestFixture]
internal class DivisionChecks
{
    [Test]
    public void TestIntegerDivisionByZero()
    {
        const string Expected = "The divisor cannot be zero.";

        using mpz_t a = new(7);
        using mpz_t Zero = new(0);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => a / Zero, Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo(Expected));
        Assert.That(() => a / 0L, Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo(Expected));
        Assert.That(() => a % Zero, Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo(Expected));
        Assert.That(() => mpz.fdiv_ui(a, 0UL), Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo(Expected));
        Assert.That(() => mpz.divexact(a, a, Zero), Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo(Expected));
        Assert.That(() => mpz.powm(a, a, a, Zero), Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo(Expected));
        Assert.That(() => mpz.remove(a, a, Zero), Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo(Expected));
    }

    [Test]
    public void TestRationalAndFloatDivisionByZero()
    {
        const string Expected = "The divisor cannot be zero.";

        using mpq_t Half = new(1L, 2UL);
        using mpq_t RationalZero = new(0L, 1UL);
        using mpf_t One = new(1.0);
        using mpf_t FloatZero = new(0.0);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => Half / RationalZero, Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo(Expected));
        Assert.That(() => mpq.inv(Half, RationalZero), Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo(Expected));
        Assert.That(() => One / FloatZero, Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo(Expected));
        Assert.That(() => One / 0UL, Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo(Expected));
        Assert.That(() => new mpq_t("1/0"), Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo("The denominator cannot be zero."));
    }

    [Test]
    public void TestRootsOfNegativeNumbers()
    {
        using mpz_t Result = new();
        using mpz_t MinusEight = new(-8);
        using mpf_t FloatResult = new();
        using mpf_t MinusOne = new(-1.0);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => mpz.sqrt(Result, MinusEight), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith("The operand cannot be negative."));
        Assert.That(() => mpz.root(Result, MinusEight, 2UL), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith("An even root of a negative number cannot be computed."));
        Assert.That(() => mpz.root(Result, MinusEight, 0UL), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith("The root index cannot be zero."));
        Assert.That(() => mpf.sqrt(FloatResult, MinusOne), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith("The operand cannot be negative."));

        // An odd root of a negative number is defined.
        Assert.That(mpz.root(Result, MinusEight, 3UL), Is.True);
        Assert.That(Result.ToString(), Is.EqualTo("-2"));
    }

    [Test]
    public void TestModularPowerWithNegativeExponent()
    {
        using mpz_t Result = new();
        using mpz_t Two = new(2);
        using mpz_t Three = new(3);
        using mpz_t MinusOne = new(-1);
        using mpz_t Four = new(4);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => mpz.powm(Result, Two, MinusOne, Four), Throws.TypeOf<ArithmeticException>().With.Message.EqualTo("The base has no inverse modulo the modulus, so it cannot be raised to a negative power."));

        // 3^-1 mod 4 is 3, since 3 * 3 = 9 = 1 mod 4.
        mpz.powm(Result, Three, MinusOne, Four);
        Assert.That(Result.ToString(), Is.EqualTo("3"));
    }
}
