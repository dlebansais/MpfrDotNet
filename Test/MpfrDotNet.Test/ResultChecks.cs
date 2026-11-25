namespace Test;

using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;
using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

[TestFixture]
internal class ResultChecks
{
    [Test]
    public void TestLargeRandomBound()
    {
        const ulong Bound = 1UL << 62;

        using randstate_t State = new();
        ulong LargestPublic = 0;
        ulong LargestMpz = 0;

        for (int i = 0; i < 64; i++)
        {
            LargestPublic = Math.Max(LargestPublic, gmp.urandomm_ui(State, Bound));
            LargestMpz = Math.Max(LargestMpz, gmp.urandomm_ui(State, Bound, isMpir: true));
        }

        ulong Small = gmp.urandomm_ui(State, 10UL, isMpir: true);
        ulong FromNativeFunction = gmp.urandomm_ui(State, Bound, isMpir: false);

        // 64 draws in [0, 2^62) are all below 2^32 with a probability of 2^-1920.
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(LargestPublic, Is.GreaterThan((ulong)uint.MaxValue).And.LessThan(Bound));
        Assert.That(LargestMpz, Is.GreaterThan((ulong)uint.MaxValue).And.LessThan(Bound));
        Assert.That(Small, Is.LessThan(10UL));
        Assert.That(FromNativeFunction, Is.LessThan(Bound));
    }

    [Test]
    public void TestBigIntegerFromSingularValues()
    {
        const string Expected = "NaN and infinities cannot be converted to an integer.";

        using mpfr_t NaN = mpfr_t.NaN();
        using mpfr_t Infinity = mpfr_t.Infinite();
        using mpfr_t MinusInfinity = mpfr_t.Infinite(-1);
        using mpfr_t Value = new(-2.5);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => (BigInteger)NaN, Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));
        Assert.That(() => (BigInteger)Infinity, Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));
        Assert.That(() => (BigInteger)MinusInfinity, Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));
        Assert.That((BigInteger)Value, Is.EqualTo(new BigInteger(-2)));
    }

    // Above 2^53, odd integers are ties between two doubles, and round to the one with an even significand.
    [TestCase("9007199254740993", 9007199254740992.0)]
    [TestCase("9007199254740995", 9007199254740996.0)]
    [TestCase("-9007199254740995", -9007199254740996.0)]
    [TestCase("9007199254740997", 9007199254740996.0)]
    [TestCase("18014398509481987", 18014398509481988.0)]
    [TestCase("9223372036854775807", 9223372036854775808.0)]
    [TestCase("-9223372036854775807", -9223372036854775808.0)]
    [TestCase("12345", 12345.0)]
    [TestCase("0", 0.0)]
    public void TestIntegerToDouble(string text, double expected)
    {
        using mpz_t Value = new(text);

        Assert.That((double)Value, Is.EqualTo(expected));
    }

    [Test]
    public void TestIntegerToDoubleLimits()
    {
        using mpz_t LargestDouble = new(new BigInteger(double.MaxValue));
        using mpz_t HalfUlpAbove = LargestDouble + (new mpz_t(1) << 970);
        using mpz_t BelowHalfUlpAbove = HalfUlpAbove - 1;
        using mpz_t PowerOf1024 = new mpz_t(1) << 1024;
        using mpz_t MinusPowerOf1024 = -PowerOf1024;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That((double)LargestDouble, Is.EqualTo(double.MaxValue));
        Assert.That((double)BelowHalfUlpAbove, Is.EqualTo(double.MaxValue));
        Assert.That((double)HalfUlpAbove, Is.EqualTo(double.PositiveInfinity));
        Assert.That((double)PowerOf1024, Is.EqualTo(double.PositiveInfinity));
        Assert.That((double)MinusPowerOf1024, Is.EqualTo(double.NegativeInfinity));
    }

    [Test]
    public void TestIntegerToFloat()
    {
        // 2^60 + 2^36 + 1 rounds to 2^60 + 2^37: through a double it would become the tie 2^60 + 2^36, then 2^60.
        using mpz_t AboveTie = (new mpz_t(1) << 60) + (new mpz_t(1) << 36) + 1;
        using mpz_t Tie = (new mpz_t(1) << 24) + 1;
        using mpz_t PowerOf128 = new mpz_t(1) << 128;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That((float)AboveTie, Is.EqualTo((float)((1L << 60) + (1L << 37))));
        Assert.That((float)Tie, Is.EqualTo(16777216f));
        Assert.That((float)PowerOf128, Is.EqualTo(float.PositiveInfinity));
        Assert.That(((IConvertible)AboveTie).ToSingle(null), Is.EqualTo((float)((1L << 60) + (1L << 37))));
    }

    [Test]
    public void TestRationalAndFloatToFloat()
    {
        // 1 + 2^-24 + 2^-60 is just above the tie 1 + 2^-24, so it rounds to 1 + 2^-23.
        const float Expected = 1.00000012f;

        using mpz_t Numerator = (new mpz_t(1) << 60) + (new mpz_t(1) << 36) + 1;
        using mpz_t Denominator = new mpz_t(1) << 60;
        using mpq_t Rational = new(Numerator, Denominator);
        using mpf_t Float = new(128UL);
        mpf.set_q(Float, Rational);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That((float)Rational, Is.EqualTo(Expected));
        Assert.That((float)Float, Is.EqualTo(Expected));
    }

    [TestCase(16, 20, "1@+14")]
    [TestCase(16, -1, "1@-1")]
    [TestCase(2, 5, "1E+101")]
    [TestCase(36, 40, "1@+14")]
    [TestCase(-16, 20, "1@+20")]
    public void TestFloatToStringExponentBase(int resultbase, int exponent, string expected)
    {
        uint AbsoluteBase = (uint)Math.Abs(resultbase);
        using mpf_t Value = new(1.0, 512UL);
        using mpf_t Power = new(1.0, 512UL);

        for (int i = 0; i < Math.Abs(exponent); i++)
            mpf.mul_ui(Power, Power, AbsoluteBase);

        if (exponent < 0)
            mpf.ui_div(Value, 1UL, Power);
        else
            mpf.set(Value, Power);

        string Text = Value.ToString(resultbase);

        Assert.That(Text, Is.EqualTo(expected));

        // The text is read back in the same base, except for a negative base, which mpf_t(string, uint) cannot pass.
        if (resultbase > 0)
        {
            using mpf_t ReadBack = new(Text, (uint)resultbase);
            Assert.That(ReadBack, Is.EqualTo(Value));
        }
    }

    [Test]
    public void TestCompareAbsWithNaN()
    {
        using mpfr_t NaN = mpfr_t.NaN();
        using mpfr_t One = new(1);
        using mpfr_t MinusTwo = new(-2);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(mpfr_t.CompareAbs(NaN, One), Is.EqualTo(-1));
        Assert.That(mpfr_t.CompareAbs(One, NaN), Is.EqualTo(1));
        Assert.That(mpfr_t.CompareAbs(NaN, NaN), Is.Zero);
        Assert.That(mpfr_t.CompareAbs(MinusTwo, One), Is.EqualTo(1));
    }

    [Test]
    public void TestRelativeDifferencePrecision()
    {
        using mpf_t x = new(1.0, 512UL);
        using mpf_t y = new(1.5, 512UL);
        using mpf_t Difference = mpf_t.RelativeDifference(x, y);

        Assert.That(Difference.Precision, Is.EqualTo(x.Precision));
    }

    [Test]
    public void TestCongruentPowerOfTwoNegativeExponent()
    {
        using mpz_t Five = new(5);
        using mpz_t One = new(1);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => Five.IsCongruentPowerOfTwo(One, -1), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith("The exponent cannot be negative."));
        Assert.That(Five.IsCongruentPowerOfTwo(One, 2), Is.True);
        Assert.That(Five.IsCongruentPowerOfTwo(One, 3), Is.False);
    }

    [TestCase(int.MaxValue, 1073741824)]
    [TestCase(11, 6)]
    [TestCase(10, 5)]
    [TestCase(1, 1)]
    [TestCase(0, 0)]
    public void TestProbabilityToRounds(int prob, int expected)
    {
        Assert.That(mpz.ProbabilityToRounds(prob), Is.EqualTo(expected));
    }

    [Test]
    public void TestDivisionsInNarrowExponentRange()
    {
        int MaxExponent = mpfr.get_emax();

        try
        {
            // The double range: the numerators below are beyond it, but the quotients are not.
            _ = mpfr.set_emax(1024);

            using mpz_t PowerOf1100 = new mpz_t(1) << 1100;
            using mpz_t Three = new(3);
            using mpz_t PowerOf1100PlusOne = PowerOf1100 + 1;
            using mpq_t ThirdOfPower = new(PowerOf1100, Three);
            using mpq_t AlmostOne = new(PowerOf1100, PowerOf1100PlusOne);
            using mpfr_t PowerOf1000 = new(1, 1000L);
            using mpfr_t PowerOf10 = new(1, 10L);
            using mpfr_t PowerOf100 = new(1, 100L);
            using mpfr_t PowerOfMinus10 = new(1, -10L);
            using mpfr_t ExpectedThird = new();
            _ = mpfr.div_ui(ExpectedThird, PowerOf100, 3UL, mpfr_rnd_t.MPFR_RNDN);

            using mpfr_t IntegerQuotient = PowerOf1100 / PowerOf1000;
            using mpfr_t RationalQuotient = ThirdOfPower / PowerOf1000;
            using mpfr_t SmallQuotient = AlmostOne / PowerOf10;

            using IDisposable Scope = Assert.EnterMultipleScope();
            Assert.That(IntegerQuotient.ToString(), Is.EqualTo(PowerOf100.ToString()));
            Assert.That(IntegerQuotient.LastTernaryResult, Is.Zero);
            Assert.That(RationalQuotient.ToString(), Is.EqualTo(ExpectedThird.ToString()));
            // The quotient is just below 2^-10, and rounds up to it.
            Assert.That(SmallQuotient.ToString(), Is.EqualTo(PowerOfMinus10.ToString()));
            Assert.That(SmallQuotient.LastTernaryResult, Is.Positive);
        }
        finally
        {
            _ = mpfr.set_emax(MaxExponent);
        }
    }

    [Test]
    public void TestRationalDivisionUnderflowRoundsOnce()
    {
        int MinExponent = mpfr.get_emin();

        try
        {
            _ = mpfr.set_emin(-100);

            // x / y = 2^-102 * (1 + 2^-60): just above the midpoint between 0 and 2^-101, the smallest positive number.
            using mpz_t Numerator = (new mpz_t(1) << 60) + 1;
            using mpz_t Denominator = new mpz_t(1) << 62;
            using mpq_t x = new(Numerator, Denominator);
            using mpfr_t y = new(1, 100L);
            using mpfr_t Smallest = new(1, -101L);

            using mpfr_t Quotient = x / y;

            using IDisposable Scope = Assert.EnterMultipleScope();
            Assert.That(Quotient.ToString(), Is.EqualTo(Smallest.ToString()));
            Assert.That(Quotient.LastTernaryResult, Is.Positive);
        }
        finally
        {
            _ = mpfr.set_emin(MinExponent);
        }
    }

    [Test]
    public void TestRationalSubtractionUnderflowSign()
    {
        int MinExponent = mpfr.get_emin();

        try
        {
            _ = mpfr.set_emin(-100);

            using mpz_t PowerOf110 = new mpz_t(1) << 110;
            using mpz_t PowerOf200 = new mpz_t(1) << 200;
            using mpz_t BelowPowerOf110 = PowerOf110 - 1;
            using mpz_t AbovePowerOf110 = PowerOf110 + 1;
            using mpq_t Below = new(BelowPowerOf110, PowerOf200);
            using mpq_t Above = new(AbovePowerOf110, PowerOf200);
            using mpfr_t y = new(1, -90L);
            using mpfr_t RoundedDown = new(1, -90L);
            RoundedDown.Rounding = mpfr_rnd_t.MPFR_RNDD;

            // The exact differences are -2^-200 and +2^-200, which underflow to zeros of the same sign.
            using mpfr_t NegativeDifference = Below - y;
            using mpfr_t PositiveDifference = Above - RoundedDown;

            using IDisposable Scope = Assert.EnterMultipleScope();
            Assert.That(NegativeDifference.IsZero, Is.True);
            Assert.That(NegativeDifference.SignBit, Is.Not.Zero);
            Assert.That(PositiveDifference.IsZero, Is.True);
            Assert.That(PositiveDifference.SignBit, Is.Zero);
        }
        finally
        {
            _ = mpfr.set_emin(MinExponent);
        }
    }

    [Test]
    public void TestRawAndTextStreamArguments()
    {
        BinaryWriter NullWriter = Sample.CreateNull<BinaryWriter>();
        BinaryReader NullReader = Sample.CreateNull<BinaryReader>();

        using mpz_t Value = new(5);
        using MemoryStream Stream = new(Encoding.ASCII.GetBytes("12 3"));
        using StreamReader Reader = new(Stream);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => mpz.out_raw(NullWriter, Value), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("writer"));
        Assert.That(() => mpz.inp_raw(Value, NullReader), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("reader"));
        Assert.That(mpz.inp_str(Value, Reader, 10), Is.Zero);
        Assert.That(Value.ToString(), Is.EqualTo("5"));
    }

    [TestCase(54, 3L, 1.0000000000000002)]
    [TestCase(54, -3L, -1.0000000000000002)]
    [TestCase(1135, 1L, double.Epsilon)]
    [TestCase(1135, -1L, -double.Epsilon)]
    public void TestRationalAndFloatToDouble(int shift, long low, double expected)
    {
        // The value is +-(2^54 + 3) / 2^54 or +-(2^60 + 1) / 2^1135, built so that only a single rounding to nearest gives the
        // expected double: 1 + 3 * 2^-54 truncates to 1, and 2^-1075 * (1 + 2^-60) is just above a tie between 0 and the
        // smallest subnormal double, so rounding to 53 bits first would give the tie, then 0.
        using mpz_t Numerator = (new mpz_t(1) << (shift == 54 ? 54 : 60)) + Math.Abs(low);
        using mpz_t Denominator = new mpz_t(1) << shift;
        using mpq_t Magnitude = new(Numerator, Denominator);
        using mpq_t Rational = low < 0 ? -Magnitude : new mpq_t(Magnitude);
        using mpf_t Float = new(256UL);
        mpf.set_q(Float, Rational);

        int MinExponent = mpfr_t.MinExponent;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That((double)Rational, Is.EqualTo(expected));
        Assert.That((double)Float, Is.EqualTo(expected));

        // The C-named functions truncate, as in MPIR.
        Assert.That(Math.Abs(mpq.get_d(Rational)), Is.LessThanOrEqualTo(Math.Abs(expected)));
        Assert.That(Math.Abs(mpf.get_d(Float)), Is.LessThanOrEqualTo(Math.Abs(expected)));
        Assert.That(mpfr_t.MinExponent, Is.EqualTo(MinExponent));
    }

    [Test]
    public void TestRationalAndFloatToFloatLimits()
    {
        // 2^-150 * (1 + 2^-60) is just above a tie between 0 and the smallest subnormal float.
        using mpz_t Numerator = (new mpz_t(1) << 60) + 1;
        using mpz_t Denominator = new mpz_t(1) << 210;
        using mpq_t Tiny = new(Numerator, Denominator);
        using mpf_t TinyFloat = new(256UL);
        mpf.set_q(TinyFloat, Tiny);

        using mpz_t PowerOf128 = new mpz_t(1) << 128;
        using mpz_t PowerOf1024 = new mpz_t(1) << 1024;
        using mpz_t One = new(1);
        using mpq_t Huge = new(PowerOf128, One);
        using mpq_t Huger = new(PowerOf1024, One);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That((float)Tiny, Is.EqualTo(float.Epsilon));
        Assert.That((float)TinyFloat, Is.EqualTo(float.Epsilon));
        Assert.That((float)Huge, Is.EqualTo(float.PositiveInfinity));
        Assert.That((double)Huger, Is.EqualTo(double.PositiveInfinity));
    }

    [Test]
    public void TestMpfrOrderingInterfaces()
    {
        using mpfr_t NaN = mpfr_t.NaN();
        using mpfr_t OtherNaN = mpfr_t.NaN();
        using mpfr_t One = new(1);
        using mpfr_t Two = new(2);
        using mpfr_t Zero = mpfr_t.Zero();
        using mpfr_t NegativeZero = mpfr_t.Zero(-1);
        using mpz_t Integer = new(1);
        mpfr_t NullNumber = Sample.CreateNull<mpfr_t>();
        object NullObject = Sample.CreateNull<object>();

        List<mpfr_t> Numbers = [Two, NaN, One];
        Numbers.Sort();

        HashSet<mpfr_t> Zeros = [Zero, NegativeZero];
        HashSet<mpfr_t> NaNs = [NaN, OtherNaN];
        bool IsOneEqualToTwo = EqualityComparer<mpfr_t>.Default.Equals(One, Two);
        bool IsOneEqualToInteger = One.Equals((object)Integer);
        bool IsOneEqualToNull = One.Equals(NullNumber);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Numbers, Is.EqualTo(new[] { NaN, One, Two }).AsCollection);
        Assert.That(Zeros, Has.Count.EqualTo(1));
        Assert.That(NaNs, Has.Count.EqualTo(1));
        Assert.That(IsOneEqualToTwo, Is.False);
        Assert.That(IsOneEqualToInteger, Is.False);
        Assert.That(IsOneEqualToNull, Is.False);
        Assert.That(One.CompareTo(NullObject), Is.EqualTo(1));
        Assert.That(((IComparable)Two).CompareTo(One), Is.Positive);
        Assert.That(() => One.CompareTo((object)Integer), Throws.ArgumentException.With.Message.StartsWith("Invalid comparison with an object of a different type."));
    }

    [Test]
    public void TestTextWithNulOrNonAscii()
    {
        const string WithNul = "12\u00003";
        const string FullWidthDigits = "１２３";

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => new mpz_t(WithNul), Throws.ArgumentException.With.Message.StartsWith("The combination of 'text' and 'strBase' is invalid."));
        Assert.That(() => new mpz_t(FullWidthDigits), Throws.ArgumentException.With.Message.StartsWith("The combination of 'text' and 'strBase' is invalid."));
        Assert.That(() => new mpq_t(WithNul), Throws.ArgumentException.With.Message.StartsWith("The combination of 'text' and 'strBase' is invalid."));
        Assert.That(() => new mpf_t(WithNul), Throws.ArgumentException.With.Message.StartsWith("The combination of 's' and 'strBase' is invalid."));
        Assert.That(() => new mpfr_t("1\u0000junk"), Throws.ArgumentException.With.Message.StartsWith("The combination of 'str' and 'strbase' is invalid."));
        Assert.That(() => new mpfr_t("∞"), Throws.ArgumentException.With.Message.StartsWith("The combination of 'str' and 'strbase' is invalid."));
    }
}
