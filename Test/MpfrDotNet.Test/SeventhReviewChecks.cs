namespace Test;

using System;
using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

// Findings of the seventh review, in the C# code.
[TestFixture]
internal class SeventhReviewChecks
{
    private const string TooManyBits = "The operand has too many bits for the exponent range of MPFR.";
    private const string ZeroDenominator = "The denominator cannot be zero.";
    private const string RationalScaling = "The precision of the number plus the bits of the rational operand exceed the maximum precision of MPFR.";
    private const string ExactProduct = "The sum of the precisions of the factors exceeds the maximum precision of MPFR.";
    private const string DotPrecision = "The precisions of two factors add up to more than the maximum precision of MPFR.";
    private const string DotRange = "A product is beyond the widest exponent range of MPFR.";
    private const string FloatLimbs = "The float operand has too many limbs for the precision of the number.";

    [Test]
    public void TestClearTwice()
    {
        mpfr_t First = new(1.0);
        mpfr_t Second = new(1.0);
        mpfr_t Third = new(1.0);

        // A cleared number has no significand: clearing it again used to read before it and crash the process.
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(
            () =>
            {
                mpfr.clear(First);
                mpfr.clear(First);
                First.Dispose();
            },
            Throws.Nothing);
        Assert.That(
            () =>
            {
                mpfr.clears(Second, Second);
                Second.Dispose();
            },
            Throws.Nothing);
        Assert.That(
            () =>
            {
                Third.Dispose();
                mpfr.clear(Third);
            },
            Throws.Nothing);
    }

    [TestCase("１２")]
    [TestCase("1\u00002")]
    public void TestParsingTextOutsideAscii(string text)
    {
        using mpz_t Integer = new(5);
        using mpz_t InitializedInteger = new(5);
        using mpq_t Rational = new(1UL, 2UL);
        using mpf_t Float = new(1.5);
        using mpf_t InitializedFloat = new(1.5);
        using mpfr_t Number = new(1.5);
        mpz.clear(InitializedInteger);
        mpf.clear(InitializedFloat);

        // Such a text is not a number: the result is the same on every platform, and no exception is thrown.
        int IntegerResult = mpz.set_str(Integer, text, 10U);
        bool IsInitializedIntegerSet = mpz.init_set_str(InitializedInteger, text, 10U);
        bool IsRationalSet = mpq.set_str(Rational, text, 10);
        int FloatResult = mpf.set_str(Float, text, 10U);
        int InitializedFloatResult = mpf.init_set_str(InitializedFloat, text, 10U);
        bool IsNumberSet = mpfr.set_str(Number, text, 10U, mpfr_rnd_t.MPFR_RNDN);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(IntegerResult, Is.EqualTo(-1));
        Assert.That(IsInitializedIntegerSet, Is.False);
        Assert.That(InitializedInteger.ToString(), Is.EqualTo("0"));
        Assert.That(IsRationalSet, Is.False);
        Assert.That(FloatResult, Is.EqualTo(-1));
        Assert.That(InitializedFloatResult, Is.EqualTo(-1));
        Assert.That(mpf.sgn(InitializedFloat), Is.Zero);
        Assert.That(IsNumberSet, Is.False);
    }

    [Test]
    public void TestRationalWithZeroDenominator()
    {
        using mpq_t Infinite = new();
        mpq.set_ui(Infinite, 1UL, 0UL);
        using mpz_t Integer = new();
        using mpf_t Float = new();

        // The native functions divide by the denominator, which raised a native division by zero.
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => mpz.set_q(Integer, Infinite), Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo(ZeroDenominator));
        Assert.That(() => mpf.set_q(Float, Infinite), Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo(ZeroDenominator));
        Assert.That(() => mpq.get_d(Infinite), Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo(ZeroDenominator));
    }

    [TestCase((long.MaxValue / 64) + 1, 0, long.MaxValue)]
    [TestCase(long.MaxValue / 64, 0, long.MaxValue - 63)]
    [TestCase(long.MinValue / 64, 0, long.MinValue)]
    [TestCase((long.MinValue / 64) + 1, 3, long.MinValue + 61)]
    [TestCase(2L, 1, 127L)]
    public void TestBitExponentSaturation(long limbExponent, int leadingZeroCount, long expected)
    {
        // On Linux, the exponent in limbs is a 64-bit C long, and the exponent in bits wrapped beyond 2^63.
        Assert.That(mpf.ToBitExponent(limbExponent, leadingZeroCount), Is.EqualTo(expected));
    }

    [Test]
    public void TestIntegerScaledBeyondNativeLong()
    {
        using mpz_t One = new(1);
        using mpfr_t Tiny = new();
        using mpfr_t Huge = new();

        // On Windows, the exponent is clamped to a 32-bit C long, which gives the same underflow or overflow.
        int TinyTernary = mpfr.set_z_2exp(Tiny, One, -(1L << 40), mpfr_rnd_t.MPFR_RNDN);
        int HugeTernary = mpfr.set_z_2exp(Huge, One, 1L << 40, mpfr_rnd_t.MPFR_RNDN);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Tiny.IsZero, Is.True);
        Assert.That(TinyTernary, Is.Negative);
        Assert.That(Huge.IsInf, Is.True);
        Assert.That(HugeTernary, Is.Positive);
    }

    [Test]
    public void TestWideIntegerScaledBeyondNativeLong()
    {
        // Only the 32-bit exponents of Windows have a native range that an integer in memory can make insufficient.
        if (mpfr_t.MaxMaxExponent == int.MaxValue)
            return;

        using mpz_t Wide = new mpz_t(1) << mpfr_t.MaxMaxExponent;
        using mpfr_t Result = new();
        ulong LiveObjectCount = mpfr_t.LiveObjectCount();

        // With an integer this wide, the clamped exponent would give a regular number instead of zero.
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => mpfr.set_z_2exp(Result, Wide, -(1L << 40), mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBits));
        Assert.That(() => new mpfr_t(Wide, -(1L << 40)), Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBits));
        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(LiveObjectCount));
    }

    [Test]
    public void TestFloatConstructorReleasesNumber()
    {
        using mpf_t SmallOne = new(1.0);
        using mpf_t Tiny = SmallOne >> int.MaxValue;
        using mpf_t Value = new(1.5, ((1UL << 25) + 2UL) * 64UL);
        mpf.add(Value, Value, Tiny);
        ulong DefaultPrecision = mpfr_t.DefaultPrecision;

        try
        {
            mpfr_t.DefaultPrecision = (1UL << 31) - 257UL;
            ulong LiveObjectCount = mpfr_t.LiveObjectCount();

            using IDisposable Scope = Assert.EnterMultipleScope();
            Assert.That(() => new mpfr_t(Value), Throws.TypeOf<OverflowException>().With.Message.EqualTo(FloatLimbs));
            Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(LiveObjectCount));
        }
        finally
        {
            mpfr_t.DefaultPrecision = DefaultPrecision;
        }
    }

    [Test]
    public void TestDotProductOutsideCurrentRange()
    {
        int MaxExponent = mpfr_t.MaxExponent;

        try
        {
            using mpfr_t Large = new(1, 60L);
            using mpfr_t NegativeLarge = new(-1, 60L);
            mpfr_t.MaxExponent = 100;

            // Each product overflows the current range, which made mpfr_dot abort: they are computed in the widest range.
            using mpfr_t Overflow = mpfr_t.Dot([Large], [Large]);
            using mpfr_t Cancellation = mpfr_t.Dot([Large, Large], [Large, NegativeLarge]);

            using IDisposable Scope = Assert.EnterMultipleScope();
            Assert.That(Overflow.IsInf, Is.True);
            Assert.That(Overflow.LastTernaryResult, Is.Positive);
            Assert.That(Cancellation.IsZero, Is.True);
            Assert.That(Cancellation.LastTernaryResult, Is.Zero);
        }
        finally
        {
            mpfr_t.MaxExponent = MaxExponent;
        }
    }

    [Test]
    public void TestDotProductOutsideWidestRange()
    {
        using mpfr_t Tiny = new(1, -600000000L);
        using mpfr_t Result = new();

        // On Windows, the product is below the widest exponent range. Elsewhere, it is in it, and the result underflows.
        if (mpfr_t.MaxMaxExponent == int.MaxValue)
        {
            using mpfr_t Product = mpfr_t.Dot([Tiny], [Tiny]);

            using IDisposable Scope = Assert.EnterMultipleScope();
            Assert.That(Product.IsZero, Is.True);
            Assert.That(Product.LastTernaryResult, Is.Negative);
        }
        else
        {
            ulong LiveObjectCount = mpfr_t.LiveObjectCount();

            using IDisposable Scope = Assert.EnterMultipleScope();
            Assert.That(() => mpfr_t.Dot([Tiny], [Tiny]), Throws.TypeOf<OverflowException>().With.Message.EqualTo(DotRange));
            Assert.That(() => mpfr.dot(Result, [Tiny], [Tiny], mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<OverflowException>().With.Message.EqualTo(DotRange));
            Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(LiveObjectCount));
        }
    }

    [Test]
    public void TestProductsBeyondMaximumPrecision()
    {
        // Only the 32-bit precisions of Windows have a maximum that numbers in memory can reach.
        if (mpfr_t.MaxMaxExponent == int.MaxValue)
            return;

        using mpfr_t First = mpfr_t.Create(1UL << 30);
        using mpfr_t Second = mpfr_t.Create(1UL << 30);
        using mpfr_t One = new(1.0);
        using mpfr_t Zero = new(0.0);
        using mpfr_t Infinity = new(double.PositiveInfinity);
        using mpfr_t Result = new();
        mpfr.set_ui(First, 1UL, mpfr_rnd_t.MPFR_RNDN);
        mpfr.set_ui(Second, 1UL, mpfr_rnd_t.MPFR_RNDN);
        ulong LiveObjectCount = mpfr_t.LiveObjectCount();

        // The products are computed exactly, with the sum of the precisions.
        using (IDisposable Scope = Assert.EnterMultipleScope())
        {
            Assert.That(() => mpfr.dot(Result, [First], [Second], mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<OverflowException>().With.Message.EqualTo(DotPrecision));
            Assert.That(() => mpfr_t.Dot([First], [Second]), Throws.TypeOf<OverflowException>().With.Message.EqualTo(DotPrecision));
            Assert.That(() => mpfr.fma(Result, First, Second, One, mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<OverflowException>().With.Message.EqualTo(ExactProduct));
            Assert.That(() => mpfr.fms(Result, First, Second, One, mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<OverflowException>().With.Message.EqualTo(ExactProduct));
            Assert.That(() => mpfr.fma(Result, First, Second, Zero, mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<OverflowException>().With.Message.EqualTo(ExactProduct));
            Assert.That(() => mpfr_t.Fma(First, Second, One), Throws.TypeOf<OverflowException>().With.Message.EqualTo(ExactProduct));
            Assert.That(() => mpfr_t.Fms(First, Second, One), Throws.TypeOf<OverflowException>().With.Message.EqualTo(ExactProduct));
            Assert.That(() => mpfr.mul(Result, First, Second, mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<OverflowException>().With.Message.EqualTo(ExactProduct));
            Assert.That(() => First * Second, Throws.TypeOf<OverflowException>().With.Message.EqualTo(ExactProduct));
            Assert.That(() => mpfr.sqr(Result, First, mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<OverflowException>().With.Message.EqualTo(ExactProduct));
            Assert.That(() => First.Sqr(), Throws.TypeOf<OverflowException>().With.Message.EqualTo(ExactProduct));
            Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(LiveObjectCount));
        }

        // MPFR handles a zero factor, or an infinite term, without multiplying the factors.
        int TermTernary = mpfr.fma(Result, First, Second, Infinity, mpfr_rnd_t.MPFR_RNDN);
        double TermResult = (double)Result;
        mpfr.set_zero(Second, 1);
        int SecondTernary = mpfr.fma(Result, First, Second, One, mpfr_rnd_t.MPFR_RNDN);
        double SecondResult = (double)Result;
        int SecondProductTernary = mpfr.mul(Result, First, Second, mpfr_rnd_t.MPFR_RNDN);
        mpfr.set_zero(First, 1);
        int FirstTernary = mpfr.fms(Result, First, Second, One, mpfr_rnd_t.MPFR_RNDN);
        double FirstResult = (double)Result;
        int SquareTernary = mpfr.sqr(Result, First, mpfr_rnd_t.MPFR_RNDN);
        bool IsSquareZero = Result.IsZero;

        using IDisposable ZeroScope = Assert.EnterMultipleScope();
        Assert.That((TermTernary, TermResult), Is.EqualTo((0, double.PositiveInfinity)));
        Assert.That((SecondTernary, SecondResult), Is.EqualTo((0, 1.0)));
        Assert.That(SecondProductTernary, Is.Zero);
        Assert.That((FirstTernary, FirstResult), Is.EqualTo((0, -1.0)));
        Assert.That((SquareTernary, IsSquareZero), Is.EqualTo((0, true)));
    }

    [Test]
    public void TestRationalProductAtMaximumPrecision()
    {
        // Only the 32-bit precisions of Windows have a maximum that a number in memory can reach.
        if (mpfr_t.MaxMaxExponent == int.MaxValue)
            return;

        using mpfr_t Precise = mpfr_t.Create(mpfr.PrecisionMax);
        mpfr.set_ui(Precise, 1UL, mpfr_rnd_t.MPFR_RNDN);
        using mpq_t Third = new(1UL, 3UL);
        using mpq_t Zero = new(0UL, 1UL);
        using mpq_t Infinite = new();
        mpq.set_ui(Infinite, 1UL, 0UL);
        using mpz_t Three = new(3);
        using mpz_t IntegerZero = new(0);
        using mpfr_t Result = new();
        ulong LiveObjectCount = mpfr_t.LiveObjectCount();

        // MPFR multiplies the number by the numerator, or by the denominator for a division, in a larger precision.
        // It converts an integer to a number of at least 64 bits.
        using (IDisposable Scope = Assert.EnterMultipleScope())
        {
            Assert.That(() => mpfr.mul_q(Result, Precise, Third, mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<OverflowException>().With.Message.EqualTo(RationalScaling));
            Assert.That(() => mpfr.div_q(Result, Precise, Third, mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<OverflowException>().With.Message.EqualTo(RationalScaling));
            Assert.That(() => Precise * Third, Throws.TypeOf<OverflowException>().With.Message.EqualTo(RationalScaling));
            Assert.That(() => Third * Precise, Throws.TypeOf<OverflowException>().With.Message.EqualTo(RationalScaling));
            Assert.That(() => Precise / Third, Throws.TypeOf<OverflowException>().With.Message.EqualTo(RationalScaling));
            Assert.That(() => mpfr.mul_z(Result, Precise, Three, mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<OverflowException>().With.Message.EqualTo(ExactProduct));
            Assert.That(() => Precise * Three, Throws.TypeOf<OverflowException>().With.Message.EqualTo(ExactProduct));
            Assert.That(() => Three * Precise, Throws.TypeOf<OverflowException>().With.Message.EqualTo(ExactProduct));
            Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(LiveObjectCount));
        }

        // A zero numerator or denominator is handled before the product.
        _ = mpfr.mul_q(Result, Precise, Zero, mpfr_rnd_t.MPFR_RNDN);
        bool IsZeroProduct = Result.IsZero;
        _ = mpfr.mul_q(Result, Precise, Infinite, mpfr_rnd_t.MPFR_RNDN);
        bool IsInfiniteProduct = Result.IsInf;
        _ = mpfr.mul_z(Result, Precise, IntegerZero, mpfr_rnd_t.MPFR_RNDN);
        bool IsZeroIntegerProduct = Result.IsZero;
        mpfr.set_zero(Precise, 1);
        _ = mpfr.mul_z(Result, Precise, Three, mpfr_rnd_t.MPFR_RNDN);
        bool IsZeroNumberProduct = Result.IsZero;

        using IDisposable ZeroScope = Assert.EnterMultipleScope();
        Assert.That(IsZeroProduct, Is.True);
        Assert.That(IsInfiniteProduct, Is.True);
        Assert.That(IsZeroIntegerProduct, Is.True);
        Assert.That(IsZeroNumberProduct, Is.True);
    }

    [Test]
    public void TestDivisionByWideDenominator()
    {
        // Only the 32-bit exponents of Windows have a widest range that an integer in memory can exceed.
        if (mpfr_t.MaxMaxExponent == int.MaxValue)
            return;

        using mpz_t IntegerOne = new(1);
        using mpz_t Denominator = new mpz_t(1) << (1 << 30);
        using mpq_t x = new(IntegerOne, Denominator);
        using mpfr_t y = new(3.0);
        ulong LiveObjectCount = mpfr_t.LiveObjectCount();

        // The product of the denominator by y is computed in the exponent range, after the result was created.
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => x / y, Throws.TypeOf<OverflowException>().With.Message.EqualTo(TooManyBits));
        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(LiveObjectCount));
    }

    [Test]
    public void TestRationalSumInTopBinadeWithRaisedMinimum()
    {
        // Only the 32-bit exponents of Windows have a largest exponent that the public range properties can set.
        if (mpfr_t.MaxMaxExponent == int.MaxValue)
            return;

        int MinExponent = mpfr_t.MinExponent;
        int MaxExponent = mpfr_t.MaxExponent;

        try
        {
            mpfr_t.MaxExponent = mpfr_t.MaxMaxExponent;

            // (0.75 + 2^-57) * 2^emax_max, with 64 bits. With a significand of only 0.75, MPFR could not decide the
            // rounding of the sum with a negligible rational before raising its working precision to about 2^30 bits.
            using mpz_t Significand = (new mpz_t(3) << 55) + 1;
            using mpfr_t Large = mpfr_t.Create(64UL);
            _ = mpfr.set_z_2exp(Large, Significand, (long)mpfr_t.MaxMaxExponent - 57L, mpfr_rnd_t.MPFR_RNDN);
            using mpfr_t Expected = new(3, (long)mpfr_t.MaxMaxExponent - 2L);
            using mpq_t Third = new(1UL, 3UL);
            using mpfr_t Sum = new();
            using mpfr_t Difference = new();
            mpfr_t.MinExponent = mpfr_t.MaxMaxExponent;

            // The halving of the number underflowed in this range, and the sum became an infinity.
            int SumTernary = mpfr.add_q(Sum, Large, Third, mpfr_rnd_t.MPFR_RNDN);
            int DifferenceTernary = mpfr.sub_q(Difference, Large, Third, mpfr_rnd_t.MPFR_RNDN);

            // The numbers are compared directly: their decimal text, in a failure message, would take very long to write.
            bool IsSumExpected = mpfr.cmp(Sum, Expected) == 0;
            bool IsDifferenceExpected = mpfr.cmp(Difference, Expected) == 0;

            using IDisposable Scope = Assert.EnterMultipleScope();
            Assert.That(IsSumExpected, Is.True);
            Assert.That(SumTernary, Is.Negative);
            Assert.That(IsDifferenceExpected, Is.True);
            Assert.That(DifferenceTernary, Is.Negative);
        }
        finally
        {
            mpfr_t.MinExponent = MinExponent;
            mpfr_t.MaxExponent = MaxExponent;
        }
    }

    [Test]
    public void TestLinearCongruentialModulusChunk()
    {
        using mpz_t a = new(5);

        // Each draw produces m2exp / 2 bits, a count kept in an int: 2^32 made the first draw crash.
        Assert.That(() => randstate_t.Create(RngAlgorithm.LinearCongruential, a, 1UL, 4294967296UL), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith("The modulus exponent must be at most 4294967295.").And.Property(nameof(ArgumentOutOfRangeException.ParamName)).EqualTo("m2exp"));
    }
}
