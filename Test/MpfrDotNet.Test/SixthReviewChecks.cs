namespace Test;

using System;
using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

// Findings of the sixth review, in the C# code.
[TestFixture]
internal class SixthReviewChecks
{
    private const string TooManyBits = "The operand has too many bits for the exponent range of MPFR.";
    private const string TooManyBitsForPrecision = "The operands have more bits than the maximum precision of MPFR.";

    [Test]
    public void TestSumWithNullNumber()
    {
        using mpfr_t One = new(1.0);
        mpfr_t NullNumber = Sample.CreateNull<mpfr_t>();

        // By design, the C-named wrappers do not check the numbers, but the native memory is released.
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => mpfr.sum(One, [One, NullNumber], mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<NullReferenceException>());
        Assert.That(() => mpfr.dot(One, [One], [NullNumber], mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<NullReferenceException>());
    }

    [Test]
    public void TestArrayArguments()
    {
        const string NegativeLength = "The length must not be negative.";
        const string NullNumber = "The array must not contain null numbers.";

        using mpfr_t First = new(1.0);
        using mpq_t FirstRational = new(1UL, 2UL);
        mpfr_t[] Numbers = [First, Sample.CreateNull<mpfr_t>()];
        mpq_t[] Rationals = [FirstRational, Sample.CreateNull<mpq_t>()];

        Assert.That(() => mpz_t.CreateArray(-1), Throws.ArgumentException.With.Message.StartsWith(NegativeLength).And.Property(nameof(ArgumentException.ParamName)).EqualTo("length"));
        Assert.That(() => mpq_t.CreateArray(-1), Throws.ArgumentException.With.Message.StartsWith(NegativeLength).And.Property(nameof(ArgumentException.ParamName)).EqualTo("length"));
        Assert.That(() => mpfr_t.CreateArray(-1), Throws.ArgumentException.With.Message.StartsWith(NegativeLength).And.Property(nameof(ArgumentException.ParamName)).EqualTo("length"));
        Assert.That(() => mpfr_t.ClearArray(Numbers), Throws.ArgumentException.With.Message.StartsWith(NullNumber).And.Property(nameof(ArgumentException.ParamName)).EqualTo("array"));
        Assert.That(() => mpq_t.ClearArray(Rationals), Throws.ArgumentException.With.Message.StartsWith(NullNumber).And.Property(nameof(ArgumentException.ParamName)).EqualTo("array"));

        // The first numbers were not disposed.
        double FirstValue = (double)First;
        string FirstRationalValue = FirstRational.ToString();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(FirstValue, Is.EqualTo(1.0));
        Assert.That(FirstRationalValue, Is.EqualTo("1/2"));
    }

    [Test]
    public void TestDisposedOperandComparedWithNaN()
    {
        mpz_t Integer = new(1);
        Integer.Dispose();
        mpq_t Rational = new(1UL, 2UL);
        Rational.Dispose();
        mpf_t Float = new(1.0);
        Float.Dispose();
        double DoubleNaN = double.NaN;
        float SingleNaN = float.NaN;

        // The disposal is checked even when NaN decides the result.
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => Integer < DoubleNaN, Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => SingleNaN != Integer, Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => Rational == DoubleNaN, Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => DoubleNaN >= Rational, Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => Float > SingleNaN, Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => DoubleNaN <= Float, Throws.TypeOf<ObjectDisposedException>());
    }

    [Test]
    public void TestFloatStringAtHighPrecision()
    {
        // The buffer was sized from a precision of 2^31 bits, too large for a string, even for zero.
        using mpf_t Zero = new(1UL << 31);
        using mpf_t One = new(1.0, 1UL << 31);
        using mpf_t SmallOne = new(1.0);
        string ZeroText = Zero.ToString(2);
        string OneText = One.ToString(16);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(ZeroText, Is.EqualTo("0"));
        Assert.That(OneText, Is.EqualTo(SmallOne.ToString(16)));
    }

    [Test]
    public void TestStringLengthLimit()
    {
        const ulong Limit = int.MaxValue - 64;

        ulong Small = mpf.LimitToStringLength(100UL, 0UL, out ulong SmallNative);
        ulong Large = mpf.LimitToStringLength(ulong.MaxValue, 5000000000UL, out ulong LargeNative);

        // Beyond what a string can hold, the native function is told to write fewer digits.
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That((Small, SmallNative), Is.EqualTo((100UL, 0UL)));
        Assert.That((Large, LargeNative), Is.EqualTo((Limit, Limit)));
    }

    [Test]
    public void TestLinearCongruentialModulusUpperBound()
    {
        using mpz_t a = new(5);

        // The native size of the seed wrapped for a modulus of 2^64 - 1 bits.
        Assert.That(() => randstate_t.Create(RngAlgorithm.LinearCongruential, a, 1UL, ulong.MaxValue), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith("The modulus exponent must be at most 4294967295.").And.Property(nameof(ArgumentOutOfRangeException.ParamName)).EqualTo("m2exp"));
    }

    [Test]
    public void TestGuardedFunctionsLeaveNoResult()
    {
        using mpfr_t Huge = new(1e18);
        using mpfr_t NegativeHuge = new(-1e30);
        using mpfr_t One = new(1.0);
        ulong LiveObjectCount = mpfr_t.LiveObjectCount();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => Huge.IncompleteGamma(One), Throws.TypeOf<OverflowException>());
        Assert.That(() => NegativeHuge.Airy(), Throws.TypeOf<OverflowException>());
        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(LiveObjectCount));
    }

    [Test]
    public void TestFloatJustBelowSmallestNumber()
    {
        // Only the 32-bit exponents of Windows make 2^-(2^30) a multiple of the limb size near the widest range.
        if (mpfr_t.MaxMaxExponent == int.MaxValue)
            return;

        int MinExponent = mpfr_t.MinExponent;

        try
        {
            mpfr_t.MinExponent = mpfr_t.MinMinExponent;

            // 0.75 * 2^(emin - 1), above half the smallest number 2^(emin - 1): it rounds up to the nearest, and down
            // toward zero.
            using mpf_t ThreeQuarters = new(0.75);
            using mpf_t Value = ThreeQuarters >> (1 << 30);
            using mpfr_t Nearest = new(Value, mpfr_rnd_t.MPFR_RNDN);
            using mpfr_t TowardZero = new(Value, mpfr_rnd_t.MPFR_RNDZ);
            using mpfr_t Smallest = new(1, (long)mpfr_t.MinMinExponent - 1L);

            using IDisposable Scope = Assert.EnterMultipleScope();
            Assert.That(Nearest, Is.EqualTo(Smallest));
            Assert.That(Nearest.LastTernaryResult, Is.Positive);
            Assert.That(TowardZero.IsZero, Is.True);
            Assert.That(TowardZero.LastTernaryResult, Is.Negative);
        }
        finally
        {
            mpfr_t.MinExponent = MinExponent;
        }
    }

    [Test]
    public void TestFloatWithManyLimbsAndPreciseNumber()
    {
        // A float of 2^25 + 2 limbs is reduced to the precision of the number it is compared with, plus a few limbs:
        // with 2^31 - 257 bits, the reduced copy would still be too large.
        using mpf_t SmallOne = new(1.0);
        using mpf_t Tiny = SmallOne >> int.MaxValue;
        using mpf_t Value = new(1.5, ((1UL << 25) + 2UL) * 64UL);
        mpf.add(Value, Value, Tiny);
        using mpfr_t Precise = mpfr_t.Create((1UL << 31) - 257UL);
        mpfr.set_ui(Precise, 1UL, mpfr_rnd_t.MPFR_RNDN);

        Assert.That(() => mpfr.cmp_f(Precise, Value), Throws.TypeOf<OverflowException>().With.Message.EqualTo("The float operand has too many limbs for the precision of the number."));
    }

    [Test]
    public void TestOperatorsCheckBeforeCreatingResult()
    {
        // Only the 32-bit exponents and precisions of Windows have limits that a number in memory can reach.
        if (mpfr_t.MaxMaxExponent == int.MaxValue)
            return;

        using mpz_t Huge = new mpz_t(1) << mpfr_t.MaxMaxExponent;
        using mpz_t IntegerOne = new(1);
        using mpq_t HugeRational = new(Huge, IntegerOne);
        using mpq_t Third = new(1UL, 3UL);
        using mpfr_t One = new(1.0);
        using mpfr_t Precise = mpfr_t.Create(1UL << 28);
        ulong LiveObjectCount = mpfr_t.LiveObjectCount();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => One + Huge, Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBits));
        Assert.That(() => Huge + One, Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBits));
        Assert.That(() => One - Huge, Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBits));
        Assert.That(() => Huge - One, Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBits));
        Assert.That(() => One * Huge, Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBits));
        Assert.That(() => Huge * One, Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBits));
        Assert.That(() => One / Huge, Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBits));
        Assert.That(() => One * HugeRational, Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBits));
        Assert.That(() => HugeRational * One, Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBits));
        Assert.That(() => One / HugeRational, Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBits));

        // With a precision of 2^28 bits, a sum with a rational keeps a margin larger than half the range.
        Assert.That(() => Precise + Third, Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBits));
        Assert.That(() => Third + Precise, Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBits));
        Assert.That(() => Precise - Third, Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBits));
        Assert.That(() => Third - Precise, Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBits));
        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(LiveObjectCount));
    }

    [Test]
    public void TestDivisionOfIntegerByNumberAtMaximumPrecision()
    {
        // Only the 32-bit precisions of Windows have a maximum that a number in memory can reach.
        if (mpfr_t.MaxMaxExponent == int.MaxValue)
            return;

        using mpz_t Wide = new mpz_t(1) << (int)(mpfr.PrecisionMax + 1UL);
        using mpq_t Third = new(1UL, 3UL);
        using mpfr_t One = new(1.0);
        using mpfr_t Precise = mpfr_t.Create(mpfr.PrecisionMax);
        mpfr.set_ui(Precise, 1UL, mpfr_rnd_t.MPFR_RNDN);
        ulong LiveObjectCount = mpfr_t.LiveObjectCount();

        // The numerator, and the denominator times the divisor, are computed exactly.
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => Wide / One, Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBitsForPrecision));
        Assert.That(() => Third / Precise, Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBitsForPrecision));
        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(LiveObjectCount));
    }
}
