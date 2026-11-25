namespace Test;

using System;
using System.Numerics;
using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

[TestFixture]
internal class Semantics
{
    [Test]
    public void TestMpzIncrementLeavesOperandUnchanged()
    {
        using mpz_t a = new(5);
        mpz_t b = a;

        b++;
        string AsStringA = a.ToString();
        string AsStringB = b.ToString();
        b.Dispose();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(AsStringA, Is.EqualTo("5"));
        Assert.That(AsStringB, Is.EqualTo("6"));
    }

    [Test]
    public void TestMpzRemainderHasSignOfDividend()
    {
        using mpz_t x = new(-7);
        using mpz_t y = new(2);

        using mpz_t Remainder = x % y;
        using mpz_t RemainderLong = x % -2L;
        using mpz_t RemainderULong = x % 2UL;
        using mpz_t Quotient = x / y;
        using mpz_t Product = Quotient * y;
        using mpz_t Sum = Product + Remainder;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Remainder.ToString(), Is.EqualTo("-1"));
        Assert.That(RemainderLong.ToString(), Is.EqualTo("-1"));
        Assert.That(RemainderULong.ToString(), Is.EqualTo("-1"));
        Assert.That(Sum.ToString(), Is.EqualTo("-7"));
    }

    [Test]
    public void TestMpzShifts()
    {
        using mpz_t Negative = new(-5);
        using mpz_t Eight = new(8);

        using mpz_t FloorShift = Negative >> 1;
        using mpz_t LeftNegativeCount = Eight << -1;
        using mpz_t RightNegativeCount = Eight >> -1;
        using mpz_t MinValueCount = Eight << int.MinValue;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(FloorShift.ToString(), Is.EqualTo("-3"));
        Assert.That(LeftNegativeCount.ToString(), Is.EqualTo("4"));
        Assert.That(RightNegativeCount.ToString(), Is.EqualTo("16"));
        Assert.That(MinValueCount.ToString(), Is.EqualTo("0"));
    }

    [TestCase("0")]
    [TestCase("-5")]
    [TestCase("128")]
    [TestCase("255")]
    [TestCase("-1267650600228229401496703205377")]
    [TestCase("1267650600228229401496703205376")]
    public void TestMpzBigIntegerConversions(string text)
    {
        BigInteger Value = BigInteger.Parse(text, System.Globalization.CultureInfo.InvariantCulture);

        using mpz_t FromBigInteger = new(Value);
        using mpz_t FromText = new(text);
        BigInteger ToBigInteger = (BigInteger)FromText;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(FromBigInteger.ToString(), Is.EqualTo(text));
        Assert.That(ToBigInteger, Is.EqualTo(Value));
    }

    [Test]
    public void TestNaNAndInfinityConversions()
    {
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => new mpz_t(double.NaN), Throws.TypeOf<OverflowException>().With.Message.EqualTo("NaN and infinities cannot be converted to an MPIR number."));
        Assert.That(() => new mpz_t(double.PositiveInfinity), Throws.TypeOf<OverflowException>().With.Message.EqualTo("NaN and infinities cannot be converted to an MPIR number."));
        Assert.That(() => new mpq_t(double.NaN), Throws.TypeOf<OverflowException>().With.Message.EqualTo("NaN and infinities cannot be converted to an MPIR number."));
        Assert.That(() => new mpf_t(double.NegativeInfinity), Throws.TypeOf<OverflowException>().With.Message.EqualTo("NaN and infinities cannot be converted to an MPIR number."));
        Assert.That(() => mpz.cmp_d(new mpz_t(1), double.NaN), Throws.ArgumentException.With.Message.StartsWith("NaN cannot be compared with an MPIR number."));
        Assert.That(() => mpz.cmpabs_d(new mpz_t(1), double.NaN), Throws.ArgumentException.With.Message.StartsWith("NaN cannot be compared with an MPIR number."));
        Assert.That(() => mpz.set_d(new mpz_t(1), double.NaN), Throws.TypeOf<OverflowException>().With.Message.EqualTo("NaN and infinities cannot be converted to an MPIR number."));
    }

    [Test]
    public void TestMpirComparisonsWithNaN()
    {
        using mpz_t Integer = new(1);
        using mpf_t Float = new(1.0);
        double NaN = double.NaN;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Integer < NaN, Is.False);
        Assert.That(Integer > NaN, Is.False);
        Assert.That(Integer == NaN, Is.False);
        Assert.That(Integer != NaN, Is.True);
        Assert.That(Integer.CompareTo(NaN), Is.Positive);
        Assert.That(Float >= NaN, Is.False);
        Assert.That(Float == NaN, Is.False);
        Assert.That(Float != NaN, Is.True);
        Assert.That(Float.CompareTo(NaN), Is.Positive);
    }

    [Test]
    public void TestMpzEvenZero()
    {
        using mpz_t Zero = new(0);

        Assert.That(mpz.even_p(Zero), Is.True);
    }

    [Test]
    public void TestNarrowingConversionsOverflow()
    {
        using mpz_t Large = new(3000000000L);
        using mpz_t Huge = new("1180591620717411303424");
        using mpf_t LargeFloat = new(3e9);
        using mpq_t LargeRational = new(3000000000L, 1UL);
        using mpfr_t LargeMpfr = new(3e9);
        using mpfr_t NaN = mpfr_t.NaN();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => (int)Large, Throws.TypeOf<OverflowException>());
        Assert.That(() => (byte)Large, Throws.TypeOf<OverflowException>());
        Assert.That(() => (long)Huge, Throws.TypeOf<OverflowException>().With.Message.EqualTo("The value is outside the range of the target type."));
        Assert.That(() => (int)LargeFloat, Throws.TypeOf<OverflowException>());
        Assert.That(() => LargeRational.ToInt32(null), Throws.TypeOf<OverflowException>());
        Assert.That(() => (int)LargeMpfr, Throws.TypeOf<OverflowException>());
        Assert.That(() => (long)NaN, Throws.TypeOf<OverflowException>().With.Message.EqualTo("NaN and infinities cannot be converted to an integer."));
        Assert.That((uint)LargeMpfr, Is.EqualTo(3000000000U));
    }

    [Test]
    public void TestNullEqualityAndOrdering()
    {
        using mpz_t Integer = new(1);
        using mpq_t Rational = new(1L, 2UL);
        using mpf_t Float = new(1.0);
        using mpfr_t Mpfr = new(1);
        mpz_t? NullInteger = null;
        mpq_t? NullRational = null;
        mpf_t? NullFloat = null;
        mpfr_t? NullMpfr = null;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Integer == NullInteger, Is.False);
        Assert.That(NullInteger == Integer, Is.False);
        Assert.That(Integer != NullInteger, Is.True);
        Assert.That(NullInteger == null, Is.True);
        Assert.That(Integer.Equals(NullInteger), Is.False);
        Assert.That(Integer.CompareTo(NullInteger), Is.Positive);
        Assert.That(Rational == NullRational, Is.False);
        Assert.That(Rational.Equals(NullRational), Is.False);
        Assert.That(Rational.CompareTo(NullRational), Is.Positive);
        Assert.That(Float == NullFloat, Is.False);
        Assert.That(Float.Equals(NullFloat), Is.False);
        Assert.That(Float.CompareTo(NullFloat), Is.Positive);
        Assert.That(Mpfr == NullMpfr, Is.False);
        Assert.That(NullMpfr == Mpfr, Is.False);
        Assert.That(Mpfr != NullMpfr, Is.True);
        Assert.That(Mpfr == 1UL, Is.True);
        Assert.That(NullMpfr == 1UL, Is.False);
        Assert.That(Mpfr.CompareTo(NullMpfr), Is.Positive);
    }

    [Test]
    public void TestToStringWithUppercaseBase()
    {
        using mpz_t Integer = new(255);
        using mpq_t Rational = new(255L, 16UL);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Integer.ToString(-16), Is.EqualTo("FF"));
        Assert.That(Rational.ToString(-16), Is.EqualTo("FF/10"));
        Assert.That(() => Integer.ToString(1), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith("The base must be between 2 and 62, or between -36 and -2 for uppercase digits."));
        Assert.That(() => Rational.ToString(-37), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith("The base must be between 2 and 62, or between -36 and -2 for uppercase digits."));
    }

    [Test]
    public void TestMpqAlwaysCanonical()
    {
        using mpq_t Half = new(1L, 2UL);
        using mpq_t TwoQuarters = new(2L, 4UL);
        using mpz_t One = new(1);
        using mpz_t MinusTwo = new(-2);
        using mpq_t MinusHalf = new(One, MinusTwo);
        using mpz_t Zero = new(0);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(TwoQuarters.ToString(), Is.EqualTo("1/2"));
        Assert.That(TwoQuarters == Half, Is.True);
        Assert.That(TwoQuarters, Is.EqualTo(Half));
        Assert.That(TwoQuarters.GetHashCode(), Is.EqualTo(Half.GetHashCode()));
        Assert.That(MinusHalf.Sign, Is.EqualTo(-1));
        Assert.That(MinusHalf.ToString(), Is.EqualTo("-1/2"));
        Assert.That(() => new mpq_t(1L, 0UL), Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo("The denominator cannot be zero."));
        Assert.That(() => Half.SetDenominator(Zero), Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo("The denominator cannot be zero."));
    }

    [Test]
    public void TestMpqAndMpfShiftWithNegativeCount()
    {
        using mpq_t Three = new(3L, 1UL);
        using mpf_t Eight = new(8.0);

        using mpq_t ThreeHalves = Three << -1;
        using mpf_t ThirtyTwo = Eight >> -2;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(ThreeHalves.ToString(), Is.EqualTo("3/2"));
        Assert.That((double)ThirtyTwo, Is.EqualTo(32.0));
    }

    [Test]
    public void TestMpfEqualsObject()
    {
        using mpf_t a = new(2.5);
        using mpf_t b = new(2.5);
        using mpf_t c = new(3.5);
        object BoxedB = b;
        object BoxedC = c;

        bool IsEqualToB = a.Equals(BoxedB);
        bool IsEqualToC = a.Equals(BoxedC);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(IsEqualToB, Is.True);
        Assert.That(IsEqualToC, Is.False);
    }

    [Test]
    public void TestMpfResultPrecision()
    {
        const ulong Precision = 256;

        using mpf_t a = new("1.0000000000000000000000000000000000001", 10, Precision);
        using mpf_t Negated = -a;
        using mpf_t NegatedTwice = -Negated;
        using mpf_t Sum = a + 0UL;
        using mpf_t Absolute = a.Abs();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Negated.Precision, Is.EqualTo(a.Precision));
        Assert.That(NegatedTwice, Is.EqualTo(a));
        Assert.That(Sum, Is.EqualTo(a));
        Assert.That(Absolute, Is.EqualTo(a));
    }

    [Test]
    public void TestExponentMarkerAboveBase10()
    {
        using mpf_t Float = new(4096.0);
        using mpfr_t Mpfr = new(4096);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Float.ToString(16), Is.EqualTo("1@+3"));
        Assert.That(Mpfr.ToString(16, mpfr_rnd_t.MPFR_RNDN), Is.EqualTo("1@+3"));
        Assert.That(Mpfr.ToString(), Is.EqualTo("4.096E+3"));
    }

    [Test]
    public void TestMpfrComparisonsWithNaN()
    {
        using mpfr_t NaN = mpfr_t.NaN();
        using mpfr_t OtherNaN = mpfr_t.NaN();
        using mpfr_t One = new(1);
        using mpz_t IntegerOne = new(1);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(NaN > 0UL, Is.False);
        Assert.That(NaN < 0L, Is.False);
        Assert.That(NaN == 0.0, Is.False);
        Assert.That(NaN != 0.0, Is.True);
        Assert.That(One <= double.NaN, Is.False);
        Assert.That(One != double.NaN, Is.True);
        Assert.That(NaN >= IntegerOne, Is.False);
        Assert.That(IntegerOne == NaN, Is.False);
        Assert.That(NaN == OtherNaN, Is.False);
    }

    [Test]
    public void TestMpfrEqualsAndCompareToFollowDouble()
    {
        using mpfr_t NaN = mpfr_t.NaN();
        using mpfr_t OtherNaN = mpfr_t.NaN();
        using mpfr_t One = new(1);
        object BoxedOtherNaN = OtherNaN;

        bool IsNaNEqual = NaN.Equals(BoxedOtherNaN);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(IsNaNEqual, Is.True);
        Assert.That(NaN.GetHashCode(), Is.EqualTo(OtherNaN.GetHashCode()));
        Assert.That(NaN.CompareTo(OtherNaN), Is.Zero);
        Assert.That(NaN.CompareTo(One), Is.Negative);
        Assert.That(One.CompareTo(NaN), Is.Positive);
        Assert.That(NaN.CompareTo(1UL), Is.Negative);
        Assert.That(One.CompareTo(double.NaN), Is.Positive);
        Assert.That(mpfr_t.Compare(NaN, One), Is.Negative);
    }

    [Test]
    public void TestMpfrSetFlagsUsesMask()
    {
        const uint NaNFlag = 4;
        const uint InexactFlag = 8;

        mpfr_t.ClearAllFlags();
        mpfr_t.SetFlags(InexactFlag);

        // The mask selects NaN and inexact: NaN is set and inexact is cleared.
        mpfr_t.SetFlags(NaNFlag | InexactFlag, NaNFlag);
        uint Flags = mpfr_t.GetAllFlags();
        mpfr_t.ClearAllFlags();

        Assert.That(Flags, Is.EqualTo(NaNFlag));
    }

    [Test]
    public void TestMpfrToStringDigitsInBase()
    {
        using mpfr_t Third = mpfr_t.Create(100);
        using mpq_t OneThird = new(1L, 3UL);
        _ = mpfr.set_q(Third, OneThird, mpfr_rnd_t.MPFR_RNDN);

        string Binary = Third.ToString(2, mpfr_rnd_t.MPFR_RNDN);

        // 100 significant bits, with trailing zeros removed.
        Assert.That(Binary.Length, Is.GreaterThan(95));
    }

    [Test]
    public void TestMpqMinusMpfrRoundsInTheRightDirection()
    {
        using mpq_t OneThird = new(1L, 3UL);
        using mpfr_t Zero = new(0);
        Zero.Rounding = mpfr_rnd_t.MPFR_RNDU;
        using mpfr_t Expected = mpfr_t.Create();
        _ = mpfr.set_q(Expected, OneThird, mpfr_rnd_t.MPFR_RNDU);

        using mpfr_t Difference = OneThird - Zero;

        Assert.That(Difference, Is.EqualTo(Expected));
    }

    [Test]
    public void TestMpqMinusMpfrSignOfZero()
    {
        using mpq_t Two = new(2L, 1UL);
        using mpfr_t MpfrTwo = new(2);
        MpfrTwo.Rounding = mpfr_rnd_t.MPFR_RNDD;
        using mpfr_t MpfrMinusTwo = new(-2);
        using mpq_t MinusTwo = new(-2L, 1UL);

        using mpq_t Zero = new(0L, 1UL);
        using mpfr_t PositiveZero = mpfr_t.Zero(+1);
        PositiveZero.Rounding = mpfr_rnd_t.MPFR_RNDD;
        using mpfr_t NegativeZero = mpfr_t.Zero(-1);
        NegativeZero.Rounding = mpfr_rnd_t.MPFR_RNDD;

        using mpfr_t RoundedDown = Two - MpfrTwo;
        using mpfr_t RoundedToNearest = MinusTwo - MpfrMinusTwo;
        using mpfr_t ZeroMinusPositiveZero = Zero - PositiveZero;
        using mpfr_t ZeroMinusNegativeZero = Zero - NegativeZero;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(RoundedDown.IsZero, Is.True);
        Assert.That(mpfr.signbit(RoundedDown), Is.Not.Zero);
        Assert.That(RoundedToNearest.IsZero, Is.True);
        Assert.That(mpfr.signbit(RoundedToNearest), Is.Zero);

        // Rounding toward -infinity, 0 - (+0) is -0, but 0 - (-0) is +0.
        Assert.That(ZeroMinusPositiveZero.IsZero, Is.True);
        Assert.That(mpfr.signbit(ZeroMinusPositiveZero), Is.Not.Zero);
        Assert.That(ZeroMinusNegativeZero.IsZero, Is.True);
        Assert.That(mpfr.signbit(ZeroMinusNegativeZero), Is.Zero);
    }

    [Test]
    public void TestDivisionByMpfrIsRoundedOnce()
    {
        const ulong Precision = 10;

        int Mismatches = 0;

        for (int i = 1; i <= 60; i++)
        {
            for (int j = 3; j <= 40; j++)
            {
                using mpz_t Dividend = new(i * 1000003);
                using mpq_t RationalDividend = new(i * 1000003L, 7UL);
                using mpfr_t Divisor = mpfr_t.Create(Precision);
                _ = mpfr.set_si(Divisor, j * 37, mpfr_rnd_t.MPFR_RNDN);

                using mpfr_t Quotient = Dividend / Divisor;
                using mpfr_t RationalQuotient = RationalDividend / Divisor;
                using mpfr_t Expected = ReferenceQuotient(Dividend, 1, Divisor, Precision);
                using mpfr_t RationalExpected = ReferenceQuotient(Dividend, 7, Divisor, Precision);

                if (!Quotient.Equals(Expected) || !RationalQuotient.Equals(RationalExpected))
                    Mismatches++;
            }
        }

        Assert.That(Mismatches, Is.Zero);
    }

    [Test]
    public void TestMpfrResultPrecision()
    {
        const ulong Precision = 256;

        using mpfr_t a = mpfr_t.Create(Precision);
        _ = mpfr.set_ui_2exp(a, 1UL, -200, mpfr_rnd_t.MPFR_RNDN);
        _ = mpfr.add_ui(a, a, 1UL, mpfr_rnd_t.MPFR_RNDN);

        using mpfr_t Negated = -a;
        using mpfr_t NegatedTwice = -Negated;
        using mpfr_t Sum = a + 0UL;
        using mpfr_t Root = a.Sqrt();
        using mpfr_t Copy = new(a);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Negated.Precision, Is.EqualTo(Precision));
        Assert.That(NegatedTwice, Is.EqualTo(a));
        Assert.That(Sum, Is.EqualTo(a));
        Assert.That(Root.Precision, Is.EqualTo(Precision));
        Assert.That(Copy.Precision, Is.EqualTo(Precision));
        Assert.That(Copy, Is.EqualTo(a));
    }

    [Test]
    public void TestAtan2ParameterOrder()
    {
        using mpfr_t One = new(1);
        using mpfr_t Zero = new(0);
        using mpfr_t HalfPi = mpfr_t.Pi();
        _ = mpfr.div_2ui(HalfPi, HalfPi, 1UL, mpfr_rnd_t.MPFR_RNDN);

        using mpfr_t Angle = mpfr_t.Atan2(y: One, x: Zero);

        Assert.That(Angle, Is.EqualTo(HalfPi));
    }

    [Test]
    public void TestSpecialFunctionsUseRounding()
    {
        using mpfr_t Up = new(2);
        Up.Rounding = mpfr_rnd_t.MPFR_RNDU;
        using mpfr_t Down = new(2);
        Down.Rounding = mpfr_rnd_t.MPFR_RNDD;

        using mpfr_t ErfUp = Up.Erf();
        using mpfr_t ErfDown = Down.Erf();

        Assert.That(ErfUp > ErfDown, Is.True);
    }

    [Test]
    public void TestFunctionResultPrecision()
    {
        const ulong LowPrecision = 100;
        const ulong HighPrecision = 256;

        using mpfr_t Low = mpfr_t.Create(LowPrecision);
        _ = mpfr.set_ui(Low, 2UL, mpfr_rnd_t.MPFR_RNDN);
        using mpfr_t High = mpfr_t.Create(HighPrecision);
        _ = mpfr.set_ui(High, 3UL, mpfr_rnd_t.MPFR_RNDN);

        using mpfr_t Sin = High.Sin();
        using mpfr_t Gamma = Low.Gamma();
        using mpfr_t Beta = mpfr_t.Beta(Low, High);
        using mpfr_t Fma = mpfr_t.Fma(Low, Low, High);
        using mpfr_t Power = mpfr_t.Pow(2UL, High);
        using mpfr_t Floor = High.Floor();
        mpfr_t.SinCos(High, out mpfr_t SinFromSinCos, out mpfr_t CosFromSinCos);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Sin.Precision, Is.EqualTo(HighPrecision));
        Assert.That(Gamma.Precision, Is.EqualTo(LowPrecision));
        Assert.That(Beta.Precision, Is.EqualTo(HighPrecision));
        Assert.That(Fma.Precision, Is.EqualTo(HighPrecision));
        Assert.That(Power.Precision, Is.EqualTo(HighPrecision));
        Assert.That(Floor.Precision, Is.EqualTo(HighPrecision));
        Assert.That(SinFromSinCos.Precision, Is.EqualTo(HighPrecision));
        Assert.That(CosFromSinCos.Precision, Is.EqualTo(HighPrecision));

        SinFromSinCos.Dispose();
        CosFromSinCos.Dispose();
    }

    [Test]
    public void TestRandStateNullArguments()
    {
        randstate_t NullState = Sample.CreateNull<randstate_t>();
        object[] NullParameters = Sample.CreateNull<object[]>();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => new randstate_t(NullState), Throws.ArgumentNullException);
        Assert.That(() => randstate_t.Create(RngAlgorithm.LinearCongruential, NullParameters), Throws.ArgumentNullException);

        // The objects whose construction failed must not release a state that was never created.
        Assert.That(() =>
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }, Throws.Nothing);
    }

    [Test]
    public void TestLastTernaryResultOfOtherProducers()
    {
        using mpq_t OneThird = new(1L, 3UL);
        using mpfr_t FromRational = new(OneThird);
        using mpfr_t Exact = new(3);
        using mpfr_t TwoAndAHalf = new(2.5);

        using mpfr_t Fma = mpfr_t.Fma(FromRational, FromRational, Exact);
        using mpfr_t Floor = TwoAndAHalf.Floor();
        using mpfr_t Minimum = mpfr_t.Min(Exact, TwoAndAHalf);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(FromRational.LastTernaryResult, Is.Not.Zero);
        Assert.That(Exact.LastTernaryResult, Is.Zero);
        Assert.That(Fma.LastTernaryResult, Is.Not.Zero);
        Assert.That(Floor.LastTernaryResult, Is.Negative);
        Assert.That(Minimum.LastTernaryResult, Is.Zero);
    }

    [Test]
    public void TestMpqDividedByLargeMpfr()
    {
        using mpq_t Rational = new(1000000L, 3UL);
        using mpfr_t Large = mpfr_t.Create();
        _ = mpfr.set_ui_2exp(Large, 1UL, mpfr_t.MaxExponent - 1, mpfr_rnd_t.MPFR_RNDN);

        // The rational is rounded once, then scaled exactly by a power of 2.
        using mpfr_t Expected = mpfr_t.Create();
        _ = mpfr.set_q(Expected, Rational, mpfr_rnd_t.MPFR_RNDN);
        _ = mpfr.mul_2si(Expected, Expected, -(mpfr_t.MaxExponent - 1), mpfr_rnd_t.MPFR_RNDN);

        using mpfr_t Quotient = Rational / Large;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Quotient.IsZero, Is.False);
        Assert.That(Quotient, Is.EqualTo(Expected));
    }

    [Test]
    public void TestZeroDenominatorLeavesValueUnchanged()
    {
        using mpq_t Half = new(1L, 2UL);
        using mpz_t Zero = new(0);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => Half.SetDenominator(Zero), Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo("The denominator cannot be zero."));
        Assert.That(Half.ToString(), Is.EqualTo("1/2"));
        Assert.That(() => new mpq_t(new mpz_t(1), Zero), Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo("The denominator cannot be zero."));
    }

    [Test]
    public void TestMpfrCompareTo2ExpWithNaN()
    {
        using mpfr_t NaN = mpfr_t.NaN();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(NaN.CompareTo(1UL, 0), Is.Negative);
        Assert.That(NaN.CompareTo(1L, 0), Is.Negative);
    }

    [Test]
    public void TestMpfToStringInvalidBase()
    {
        using mpf_t Float = new(1.0);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => Float.ToString(1), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith("The base must be between 2 and 62, or between -36 and -2 for uppercase digits."));
        Assert.That(() => Float.ToString(int.MinValue), Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void TestFitsLongUsesSixtyFourBits()
    {
        // 3e9 does not fit in 32 bits, which is the size of a C long on Windows, but fits in a C# long.
        const double ThreeBillion = 3e9;
        const double TwoToThe63 = 9223372036854775808.0;
        const double TwoToThe64 = 18446744073709551616.0;

        using mpfr_t MpfrThreeBillion = new(ThreeBillion);
        using mpfr_t MpfrTwoToThe63 = new(TwoToThe63);
        using mpfr_t MpfrTwoToThe64 = new(TwoToThe64);
        using mpf_t MpfThreeBillion = new(ThreeBillion);
        using mpf_t MpfTwoToThe63 = new(TwoToThe63);
        using mpf_t MpfTwoToThe64 = new(TwoToThe64);
        using mpf_t MpfMinusOne = new(-1.0);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(MpfrThreeBillion.FitsSignedLong, Is.True);
        Assert.That(MpfrThreeBillion.FitsUnsignedLong, Is.True);
        Assert.That(MpfrTwoToThe63.FitsSignedLong, Is.False);
        Assert.That(MpfrTwoToThe63.FitsUnsignedLong, Is.True);
        Assert.That(MpfrTwoToThe64.FitsUnsignedLong, Is.False);
        Assert.That(MpfThreeBillion.FitsSignedLong, Is.True);
        Assert.That(MpfThreeBillion.FitsUnsignedLong, Is.True);
        Assert.That(MpfTwoToThe63.FitsSignedLong, Is.False);
        Assert.That(MpfTwoToThe63.FitsUnsignedLong, Is.True);
        Assert.That(MpfTwoToThe64.FitsUnsignedLong, Is.False);
        Assert.That(MpfMinusOne.FitsSignedLong, Is.True);
        Assert.That(MpfMinusOne.FitsUnsignedLong, Is.False);
    }

    [Test]
    public void TestOrderingWithNull()
    {
        using mpz_t Integer = new(1);
        using mpq_t Rational = new(1L, 2UL);
        using mpf_t Float = new(1.0);
        using mpfr_t Mpfr = new(1);
        mpz_t? NullInteger = null;
        mpz_t? OtherNullInteger = null;
        mpq_t? NullRational = null;
        mpf_t? NullFloat = null;
        mpfr_t? NullMpfr = null;

        // As with System.Version, null sorts before any number.
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Integer > NullInteger, Is.True);
        Assert.That(NullInteger < Integer, Is.True);
        Assert.That(Integer < NullInteger, Is.False);
        Assert.That(NullInteger <= OtherNullInteger, Is.True);
        Assert.That(NullInteger >= Integer, Is.False);
        Assert.That(5 > NullInteger, Is.True);
        Assert.That(NullInteger < 5.0, Is.True);
        Assert.That(Rational >= NullRational, Is.True);
        Assert.That(NullRational > Rational, Is.False);
        Assert.That(Float > NullFloat, Is.True);
        Assert.That(NullFloat <= Float, Is.True);
        Assert.That(Mpfr > NullMpfr, Is.True);
        Assert.That(NullMpfr < Mpfr, Is.True);
        Assert.That(1UL < NullMpfr, Is.False);
        Assert.That(NullMpfr <= Integer, Is.True);
    }

    [Test]
    public void TestLastTernaryResult()
    {
        using mpfr_t Two = new(2);
        using mpfr_t Four = new(4);
        using mpfr_t One = new(1);
        using mpq_t OneThird = new(1L, 3UL);
        using mpfr_t Zero = new(0);
        Zero.Rounding = mpfr_rnd_t.MPFR_RNDU;

        using mpfr_t InexactRoot = Two.Sqrt();
        using mpfr_t ExactRoot = Four.Sqrt();
        using mpfr_t Sin = One.Sin();
        using mpfr_t Cos = One.Cos();
        mpfr_t.SinCos(One, out mpfr_t SinFromSinCos, out mpfr_t CosFromSinCos);
        using mpfr_t RoundedUp = OneThird - Zero;
        using mpfr_t Copy = new(Two);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(InexactRoot.LastTernaryResult, Is.Not.Zero);
        Assert.That(Two.LastTernaryResult, Is.Zero);
        Assert.That(ExactRoot.LastTernaryResult, Is.Zero);
        Assert.That(SinFromSinCos.LastTernaryResult, Is.Not.Zero);
        Assert.That(SinFromSinCos.LastTernaryResult, Is.EqualTo(Math.Sign(Sin.LastTernaryResult)));
        Assert.That(CosFromSinCos.LastTernaryResult, Is.Not.Zero);
        Assert.That(CosFromSinCos.LastTernaryResult, Is.EqualTo(Math.Sign(Cos.LastTernaryResult)));
        Assert.That(RoundedUp.LastTernaryResult, Is.Positive);
        Assert.That(Copy.LastTernaryResult, Is.Zero);

        SinFromSinCos.Dispose();
        CosFromSinCos.Dispose();
    }

    [Test]
    public void TestRandStateUseAfterDispose()
    {
        using mpz_t Integer = new(7);
        using mpf_t Float = new();
        using mpfr_t Mpfr = new();
        randstate_t State = randstate_t.Create(RngAlgorithm.MersenneTwister);
        State.Dispose();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => gmp.urandomb_ui(State, 10UL), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => mpfr_t.UniformRandom(State), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => new randstate_t(State), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => mpz.probable_prime_p(Integer, State, 10, 0UL), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => mpz.likely_prime_p(Integer, State, 0UL), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => mpz.next_prime_candidate(Integer, Integer, State), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => mpz.urandomb(Integer, State, 10UL), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => mpz.urandomm(Integer, State, Integer), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => mpz.rrandomb(Integer, State, 10UL), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => mpf.urandomb(Float, State, 10UL), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => mpf.rrandomb(Float, State, 1UL, 1), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => mpfr.urandom(Mpfr, State, mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => mpfr.nrandom(Mpfr, State, mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => mpfr.grandom(Mpfr, Mpfr, State, mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => mpfr.erandom(Mpfr, State, mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => gmp.randseed(State, Integer), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => gmp.randseed_ui(State, 10UL), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => gmp.urandomm_ui(State, 10UL), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(State.Dispose, Throws.Nothing);

        // The copy that failed must not release a state it never created.
        Assert.That(() =>
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }, Throws.Nothing);
    }

    private static mpfr_t ReferenceQuotient(mpz_t numerator, ulong denominator, mpfr_t divisor, ulong precision)
    {
        // numerator / (denominator * divisor), with every intermediate value exact and a single rounding.
        using mpfr_t ExactNumerator = mpfr_t.Create(128);
        _ = mpfr.set_z(ExactNumerator, numerator, mpfr_rnd_t.MPFR_RNDN);
        using mpfr_t ExactDenominator = mpfr_t.Create(128);
        _ = mpfr.mul_ui(ExactDenominator, divisor, denominator, mpfr_rnd_t.MPFR_RNDN);

        mpfr_t Result = mpfr_t.Create(precision);
        _ = mpfr.div(Result, ExactNumerator, ExactDenominator, mpfr_rnd_t.MPFR_RNDN);

        return Result;
    }
}
