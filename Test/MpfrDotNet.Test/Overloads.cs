namespace Test;

using System;
using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

[TestFixture]
internal class Overloads
{
    [Test]
    public void TestRationalZeroUnsignedDenominator()
    {
        Assert.That(() => new mpq_t(1UL, 0UL), Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo("The denominator cannot be zero."));
    }

#pragma warning disable CS0618 // Type or member is obsolete: the obsolete overloads must keep working.
    [Test]
    public void TestRationalObsoleteConstructors()
    {
        using mpz_t Numerator = new(2);
        using mpz_t Denominator = new(4);
        using mpq_t FromUnsigned = new(2UL, 4UL, canonicalize: false);
        using mpq_t FromSigned = new(-2L, 4UL, canonicalize: false);
        using mpq_t FromIntegers = new(Numerator, Denominator, canonicalize: false);
        using mpq_t FromText = new("2/4", canonicalize: false);
        using mpq_t FromTextWithBase = new("10/100", 2, canonicalize: false);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(FromUnsigned.ToString(), Is.EqualTo("1/2"));
        Assert.That(FromSigned.ToString(), Is.EqualTo("-1/2"));
        Assert.That(FromIntegers.ToString(), Is.EqualTo("1/2"));
        Assert.That(FromText.ToString(), Is.EqualTo("1/2"));
        Assert.That(FromTextWithBase.ToString(), Is.EqualTo("1/2"));
    }
#pragma warning restore CS0618 // Type or member is obsolete

    [Test]
    public void TestRationalIsEqualTo()
    {
        using mpq_t Half = new(1UL, 2UL);
        using mpq_t OtherHalf = new(2UL, 4UL);
        using mpq_t Third = new(1UL, 3UL);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Half.IsEqualTo(OtherHalf), Is.True);
        Assert.That(Half.IsEqualTo(Third), Is.False);
    }

    [Test]
    public void TestCompareToObjectOfDifferentType()
    {
        const string Expected = "Invalid comparison with an object of a different type.";
        const string Text = "text";

        using mpz_t Integer = new(1);
        using mpq_t Rational = new(1UL, 2UL);
        using mpf_t Floating = new(1.0);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => Integer.CompareTo(Text), Throws.ArgumentException.With.Message.StartsWith(Expected));
        Assert.That(() => Rational.CompareTo(Text), Throws.ArgumentException.With.Message.StartsWith(Expected));
        Assert.That(() => Floating.CompareTo(Text), Throws.ArgumentException.With.Message.StartsWith(Expected));
    }

    [Test]
    public void TestIntegerByteConversions()
    {
        using mpz_t Positive = new(200);
        using mpz_t Negative = new(-100);
        IConvertible ConvertiblePositive = Positive;
        IConvertible ConvertibleNegative = Negative;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Positive.ToByte(null), Is.EqualTo((byte)200));
        Assert.That(ConvertiblePositive.ToByte(null), Is.EqualTo((byte)200));
        Assert.That(Negative.ToSByte(null), Is.EqualTo((sbyte)-100));
        Assert.That(ConvertibleNegative.ToSByte(null), Is.EqualTo((sbyte)-100));
    }

    [Test]
    public void TestFloatingByteConversions()
    {
        using mpf_t Positive = new(200.7);
        using mpf_t Negative = new(-100.7);
        IConvertible ConvertiblePositive = Positive;
        IConvertible ConvertibleNegative = Negative;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Positive.ToByte(null), Is.EqualTo((byte)200));
        Assert.That(ConvertiblePositive.ToByte(null), Is.EqualTo((byte)200));
        Assert.That(Negative.ToSByte(null), Is.EqualTo((sbyte)-100));
        Assert.That(ConvertibleNegative.ToSByte(null), Is.EqualTo((sbyte)-100));
    }

    [Test]
    public void TestIntegerSetAndMod()
    {
        using mpz_t Source = new(-7);
        using mpz_t Divisor = new(3);
        using mpz_t Copy = new();
        using mpz_t Remainder = new();

        mpz.set(Copy, Source);
        mpz.mod(Remainder, Source, Divisor);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Copy.ToString(), Is.EqualTo("-7"));
        Assert.That(Remainder.ToString(), Is.EqualTo("2"));
    }

    [Test]
    public void TestFloatingGetIntegers()
    {
        using mpf_t Positive = new(3.7);
        using mpf_t Negative = new(-3.7);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(mpf.get_ui(Positive), Is.EqualTo(3UL));
        Assert.That(mpf.get_si(Negative), Is.EqualTo(-3L));
    }

    [Test]
    public void TestMpfrGetIntegers()
    {
        using mpfr_t Positive = new(3.7);
        using mpfr_t Negative = new(-3.7);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(mpfr.get_ui(Positive, mpfr_rnd_t.MPFR_RNDN), Is.EqualTo(4UL));
        Assert.That(mpfr.get_si(Negative, mpfr_rnd_t.MPFR_RNDZ), Is.EqualTo(-3L));
    }

    [Test]
    public void TestRationalDividedByTinyMpfrOverflows()
    {
        // y = 2^(emin - 1), so x / y = 2^(2 - emin), which is above the largest exponent.
        using mpq_t x = new(2UL, 1UL);
        using mpfr_t y = new(1.0);
        _ = mpfr.set_exp(y, mpfr.get_emin());

        using mpfr_t z = x / y;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(mpfr.inf_p(z), Is.True);
        Assert.That(z.LastTernaryResult, Is.Positive);
    }
}
