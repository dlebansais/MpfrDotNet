namespace Test;

using System;
using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

// Findings of the fifth review that are fixed in C#.
[TestFixture]
internal class FifthReviewChecks
{
    private const string TooManyBits = "The operand has too many bits for the exponent range of MPFR.";

    [Test]
    public void TestCorrectlyRoundedSum()
    {
        using mpfr_t Large = new(1e100);
        using mpfr_t One = new(1.0);
        using mpfr_t MinusLarge = new(-1e100);
        using mpfr_t Tiny = new(1, -100L);
        mpfr_t[] Values = [Large, One, MinusLarge];

        // A loop of additions loses the 1: the sum is rounded once.
        using mpfr_t Sum = mpfr_t.Sum(Values);
        using mpfr_t Up = mpfr_t.Sum([One, Tiny], mpfr_rnd_t.MPFR_RNDU);
        using mpfr_t Empty = mpfr_t.Sum([]);
        using mpfr_t Next = new(1.0);
        mpfr.nextabove(Next);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That((double)Sum, Is.EqualTo(1.0));
        Assert.That(Sum.LastTernaryResult, Is.Zero);
        Assert.That(Up, Is.EqualTo(Next));
        Assert.That(Up.LastTernaryResult, Is.Positive);
        Assert.That(Empty.IsZero, Is.True);
    }

    [Test]
    public void TestCorrectlyRoundedDotProduct()
    {
        using mpfr_t Large = new(1e100);
        using mpfr_t One = new(1.0);
        using mpfr_t MinusOne = new(-1.0);
        using mpfr_t Three = new(3.0);

        // 1e100 * 1 + 1 * 3 + 1e100 * -1 = 3.
        using mpfr_t Dot = mpfr_t.Dot([Large, One, Large], [One, Three, MinusOne]);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That((double)Dot, Is.EqualTo(3.0));
        Assert.That(Dot.LastTernaryResult, Is.Zero);
    }

    [Test]
    public void TestSumAndDotIntoAnInput()
    {
        using mpfr_t a = new(1.5);
        using mpfr_t b = new(2.25);
        using mpfr_t c = new(2.0);

        // The result is also an input: MPFR must not see it through a copy.
        int SumTernary = mpfr.sum(a, [a, b], mpfr_rnd_t.MPFR_RNDN);
        double SumValue = (double)a;
        int DotTernary = mpfr.dot(b, [c], [b], mpfr_rnd_t.MPFR_RNDN);
        double DotValue = (double)b;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(SumValue, Is.EqualTo(3.75));
        Assert.That(SumTernary, Is.Zero);
        Assert.That(DotValue, Is.EqualTo(4.5));
        Assert.That(DotTernary, Is.Zero);
    }

    [Test]
    public void TestSumAndDotArguments()
    {
        const string LengthMessage = "The two arrays must have the same length.";

        mpfr_t[] NullArray = Sample.CreateNull<mpfr_t[]>();
        mpfr_t NullNumber = Sample.CreateNull<mpfr_t>();
        using mpfr_t One = new(1.0);
        mpfr_t Disposed = new(2.0);
        Disposed.Dispose();
        ulong LiveObjectCount = mpfr_t.LiveObjectCount();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => mpfr.sum(One, NullArray, mpfr_rnd_t.MPFR_RNDN), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("tab"));
        Assert.That(() => mpfr.sum(One, [One], mpfr_rnd_t.MPFR_RNDNA), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => mpfr.dot(One, NullArray, [One], mpfr_rnd_t.MPFR_RNDN), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("tab"));
        Assert.That(() => mpfr.dot(One, [One], NullArray, mpfr_rnd_t.MPFR_RNDN), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("b"));
        Assert.That(() => mpfr.dot(One, [One], [One, One], mpfr_rnd_t.MPFR_RNDN), Throws.ArgumentException.With.Message.StartsWith(LengthMessage));
        Assert.That(() => mpfr.dot(One, [One], [One], mpfr_rnd_t.MPFR_RNDNA), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => mpfr_t.Sum(NullArray), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("values"));
        Assert.That(() => mpfr_t.Sum([One, NullNumber]), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("values"));
        Assert.That(() => mpfr_t.Sum([One, Disposed]), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => mpfr_t.Sum([One], mpfr_rnd_t.MPFR_RNDNA), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => mpfr_t.Dot(NullArray, [One]), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("x"));
        Assert.That(() => mpfr_t.Dot([One], NullArray), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("y"));
        Assert.That(() => mpfr_t.Dot([One], [One, One]), Throws.ArgumentException.With.Message.StartsWith(LengthMessage));
        Assert.That(() => mpfr_t.Dot([One], [One], mpfr_rnd_t.MPFR_RNDNA), Throws.TypeOf<ArgumentOutOfRangeException>());

        // The arguments are checked before the result is created.
        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(LiveObjectCount));
    }

    [Test]
    public void TestAliasedOutputs()
    {
        using mpz_t u = new(1000);
        using mpz_t Root = new();
        using mpfr_t x = new(2.5);
        using mpfr_t Part = new();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => mpz.rootrem(Root, Root, u, 3UL), Throws.ArgumentException.With.Message.StartsWith("The root and the remainder must be different numbers.").And.Property(nameof(ArgumentException.ParamName)).EqualTo("rem"));
        Assert.That(() => mpfr.modf(Part, Part, x, mpfr_rnd_t.MPFR_RNDN), Throws.ArgumentException.With.Message.StartsWith("The integer and fractional parts must be different numbers.").And.Property(nameof(ArgumentException.ParamName)).EqualTo("fop"));
    }

    [Test]
    public void TestNullArguments()
    {
        byte[] NullBytes = Sample.CreateNull<byte[]>();
        mpz_t? NullInteger = null;
        mpq_t? NullRational = null;
        mpf_t? NullFloat = null;
        using mpq_t Half = new(1UL, 2UL);
        using mpfr_t One = new(1.0);
        using mpfr_t NotANumber = new(double.NaN);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => new mpz_t(NullBytes), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("bytes"));

        // As with CompareTo(null) for the same type, null is smaller than any number.
        Assert.That(Half.CompareTo(NullInteger), Is.Positive);
        Assert.That(One.CompareTo(NullInteger), Is.Positive);
        Assert.That(One.CompareTo(NullRational), Is.Positive);
        Assert.That(One.CompareTo(NullFloat), Is.Positive);
        Assert.That(NotANumber.CompareTo(NullInteger), Is.Positive);
    }

    [Test]
    public void TestSpecialOperands()
    {
        using mpfr_t Zero = mpfr_t.Zero();
        using mpq_t Third = new(1UL, 3UL);
        using mpz_t IntegerZero = new(0);

        mpz.get_d_2exp(IntegerZero, out double d, out long Exponent);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(mpfr.cmp_q(Zero, Third), Is.Negative);
        Assert.That(d, Is.Zero);
        Assert.That(Exponent, Is.Zero);
    }

    [Test]
    public void TestLinearCongruentialModulus()
    {
        using mpz_t a = new(5);

        // With m2exp = 1, every draw looped forever.
        Assert.That(() => randstate_t.Create(RngAlgorithm.LinearCongruential, a, 1UL, 1UL), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith("The modulus exponent must be at least 2.").And.Property(nameof(ArgumentOutOfRangeException.ParamName)).EqualTo("m2exp"));
    }

    [Test]
    public void TestIncompleteGammaOfNaN()
    {
        using mpfr_t NotANumber = new(double.NaN);
        using mpfr_t One = new(1.0);
        using mpfr_t Result = new();

        mpfr.clear_flags();
        _ = mpfr.gamma_inc(Result, NotANumber, One, mpfr_rnd_t.MPFR_RNDN);
        bool IsErange = mpfr.erangeflag_p();

        // MPFR raises only the NaN flag: the check of the operand must not raise the erange flag.
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Result.IsNan, Is.True);
        Assert.That(IsErange, Is.False);
    }

    [Test]
    public void TestIncompleteGammaNearZero()
    {
        // Gamma(2^-2000) is about 2^2000, far from overflowing: only Windows can reach an overflow near 0, below.
        using mpfr_t Small = new(1, -2000L);
        using mpfr_t One = new(1.0);
        using mpfr_t Result = Small.IncompleteGamma(One);

        Assert.That(Result.IsNumber, Is.True);
    }

    [Test]
    public void TestWindowsOnlyLimits()
    {
        // Only the 32-bit exponents and precisions of Windows have limits that a number in memory can reach.
        if (mpfr_t.MaxMaxExponent == int.MaxValue)
            return;

        using mpz_t IntegerOne = new(1);
        using mpz_t Huge = new mpz_t(1) << mpfr_t.MaxMaxExponent;
        using mpz_t HalfRange = new mpz_t(1) << ((mpfr_t.MaxMaxExponent / 2) + 10);
        using mpq_t HugeRational = new(Huge, IntegerOne);
        using mpq_t Cancelling = new(IntegerOne, HalfRange);
        using mpq_t Third = new(1UL, 3UL);
        using mpfr_t One = new(1.0);
        using mpfr_t Result = new();
        ulong LiveObjectCount = mpfr_t.LiveObjectCount();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => mpfr.cmp_z(One, Huge), Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBits));
        Assert.That(() => One < Huge, Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBits));
        Assert.That(() => mpfr.set_q(Result, HugeRational, mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBits));
        Assert.That(() => new mpfr_t(HugeRational), Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBits));
        Assert.That(() => (double)HugeRational, Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBits));
        Assert.That(() => (float)HugeRational, Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBits));
        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(LiveObjectCount));

        // A sum can cancel down to about 2^(-2N) for a denominator of N bits: N must fit in half of the range.
        Assert.That(() => mpfr.add_q(Result, One, Cancelling, mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBits));
        Assert.That(() => mpfr.sub_q(Result, One, Cancelling, mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBits));

        // The precision of the number plus the bits of the denominator must fit in a precision.
        using mpfr_t Precise = mpfr_t.Create(mpfr.PrecisionMax);
        mpfr.set_ui(Precise, 1UL, mpfr_rnd_t.MPFR_RNDN);
        Assert.That(() => mpfr.cmp_q(Precise, Third), Throws.TypeOf<OverflowException>().With.Message.EqualTo("The precision of the number plus the bits of the denominator exceed the maximum precision of MPFR."));
    }

    [Test]
    public void TestIncompleteGammaAtSmallestNumber()
    {
        // Only the 32-bit exponents of Windows make the widest range the default one.
        if (mpfr_t.MaxMaxExponent == int.MaxValue)
            return;

        int MinExponent = mpfr_t.MinExponent;

        try
        {
            mpfr_t.MinExponent = mpfr_t.MinMinExponent;

            // Gamma near the pole at 0 overflows the widest range, where MPFR looped forever.
            using mpfr_t Smallest = new(1, (long)mpfr_t.MinMinExponent - 1L);
            using mpfr_t One = new(1.0);

            Assert.That(() => Smallest.IncompleteGamma(One), Throws.TypeOf<OverflowException>().With.Message.EqualTo("Gamma of the operand is beyond the exponent range of MPFR."));
        }
        finally
        {
            mpfr_t.MinExponent = MinExponent;
        }
    }

    [Test]
    public void TestFloatWithManyLimbs()
    {
        // 1.5 + 2^-(2^31 - 1), with 2^25 + 2 limbs: the precision of such a float overflowed the 32-bit precisions of
        // Windows in mpfr_set_f, and an int in mpfr_cmp_f on every platform. The lowest bit must still count for rounding.
        using mpf_t SmallOne = new(1.0);
        using mpf_t Tiny = SmallOne >> int.MaxValue;
        using mpf_t Value = new(1.5, ((1UL << 25) + 2UL) * 64UL);
        mpf.add(Value, Value, Tiny);

        using mpfr_t Down = new(Value, mpfr_rnd_t.MPFR_RNDD);
        using mpfr_t Up = new(Value, mpfr_rnd_t.MPFR_RNDU);
        using mpfr_t Nearest = new(Value, mpfr_rnd_t.MPFR_RNDN);
        using mpfr_t AboveValue = new(1.5);
        mpfr.nextabove(AboveValue);
        using mpfr_t OneAndHalf = new(1.5);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That((double)Down, Is.EqualTo(1.5));
        Assert.That(Down.LastTernaryResult, Is.Negative);
        Assert.That(Up, Is.EqualTo(AboveValue));
        Assert.That(Up.LastTernaryResult, Is.Positive);
        Assert.That((double)Nearest, Is.EqualTo(1.5));
        Assert.That(mpfr.cmp_f(OneAndHalf, Value), Is.Negative);
        Assert.That(mpfr.cmp_f(AboveValue, Value), Is.Positive);
    }

    [Test]
    public void TestFloatWithManyZeroLimbs()
    {
        // 1 with 2^25 + 2 limbs, all zero but the top one: the value is exact.
        ulong Shift = ((1UL << 25) + 1UL) * 64UL;
        using mpf_t Value = new(((1UL << 25) + 2UL) * 64UL);
        using (mpz_t Power = new())
        {
            using mpz_t IntegerOne = new(1);
            mpz.mul_2exp(Power, IntegerOne, Shift);
            mpf.set_z(Value, Power);
        }

        mpf.div_2exp(Value, Value, Shift);

        using mpfr_t Converted = new(Value, mpfr_rnd_t.MPFR_RNDU);
        using mpfr_t One = new(1.0);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That((double)Converted, Is.EqualTo(1.0));
        Assert.That(Converted.LastTernaryResult, Is.Zero);
        Assert.That(mpfr.cmp_f(One, Value), Is.Zero);
    }
}
