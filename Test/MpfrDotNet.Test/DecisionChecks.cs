namespace Test;

using System;
using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

// The fourth review's findings that needed a decision: comparisons of mpq_t with numbers, mpf_t string exponents
// beyond a native long, and the Airy function for large operands.
[TestFixture]
internal class DecisionChecks
{
    [Test]
    public void TestRationalComparisonsWithIntegers()
    {
        using mpq_t Third = new(1UL, 3UL);
        using mpq_t Large = new(ulong.MaxValue);
        using mpq_t Negative = new(-5L);

        // Integer literals pick the long operators, which used to be ambiguous between mpq_t and mpz_t.
        // ulong.MaxValue is compared exactly.
        bool[] Actual =
        [
            Third < 1,
            Third <= 0,
            Third > 0,
            Third >= 1,
            Negative == -5,
            Negative != -5,
            1 > Third,
            0 >= Third,
            0 < Third,
            1 <= Third,
            -5 == Negative,
            -5 != Negative,
            Large == ulong.MaxValue,
            Large != ulong.MaxValue,
            Large < ulong.MaxValue,
            Large <= ulong.MaxValue,
            Large > ulong.MaxValue - 1UL,
            Large >= ulong.MaxValue,
            ulong.MaxValue == Large,
            ulong.MaxValue != Large,
            ulong.MaxValue - 1UL < Large,
            ulong.MaxValue <= Large,
            ulong.MaxValue > Large,
            ulong.MaxValue >= Large,
        ];
        bool[] Expected =
        [
            true,
            false,
            true,
            false,
            true,
            false,
            true,
            false,
            true,
            false,
            true,
            false,
            true,
            false,
            false,
            true,
            true,
            true,
            true,
            false,
            true,
            true,
            false,
            true,
        ];

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Actual, Is.EqualTo(Expected));
        Assert.That(Third.CompareTo(0), Is.Positive);
        Assert.That(Third.CompareTo(1UL), Is.Negative);
    }

    [Test]
    public void TestRationalComparisonsWithDoubles()
    {
        using mpq_t Third = new(1UL, 3UL);
        using mpq_t Odd = new(9007199254740993L);
        double NotANumber = double.NaN;

        // 1.0 / 3.0 is a little below 1/3, and 2^53 + 1 is above 2^53: the comparison is exact.
        // As for mpz_t, NaN compares false, except with !=.
        bool[] Actual =
        [
            Third > 1.0 / 3.0,
            Third >= 1.0 / 3.0,
            Third < 0.5,
            Third <= 1.0 / 3.0,
            Third == 1.0 / 3.0,
            Third != 1.0 / 3.0,
            Odd > 9007199254740992.0,
            9007199254740992.0 < Odd,
            9007199254740992.0 <= Odd,
            9007199254740992.0 > Odd,
            9007199254740992.0 >= Odd,
            0.25 == Third,
            0.25 != Third,
            Third < double.PositiveInfinity,
            Third > double.NegativeInfinity,
            Third < NotANumber,
            Third <= NotANumber,
            Third > NotANumber,
            Third >= NotANumber,
            Third == NotANumber,
            Third != NotANumber,
            NotANumber < Third,
            NotANumber <= Third,
            NotANumber > Third,
            NotANumber >= Third,
            NotANumber == Third,
            NotANumber != Third,
        ];
        bool[] Expected =
        [
            true,
            true,
            true,
            false,
            false,
            true,
            true,
            true,
            true,
            false,
            false,
            false,
            true,
            true,
            true,
            false,
            false,
            false,
            false,
            false,
            true,
            false,
            false,
            false,
            false,
            false,
            true,
        ];

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Actual, Is.EqualTo(Expected));
        Assert.That(Third.CompareTo(double.PositiveInfinity), Is.Negative);
        Assert.That(Third.CompareTo(double.NegativeInfinity), Is.Positive);
        Assert.That(Third.CompareTo(double.NaN), Is.Positive);
    }

    [Test]
    public void TestRationalComparisonsWithNull()
    {
        mpq_t? Null = null;

        // As for mpz_t, null is below every number.
        bool[] Actual =
        [
            Null < 0L,
            Null <= 0L,
            Null > 0L,
            Null >= 0L,
            Null == 0L,
            Null != 0L,
            0L < Null,
            0L <= Null,
            0L > Null,
            0L >= Null,
            0L == Null,
            0L != Null,
            Null < 0UL,
            Null <= 0UL,
            Null > 0UL,
            Null >= 0UL,
            Null == 0UL,
            Null != 0UL,
            0UL < Null,
            0UL <= Null,
            0UL > Null,
            0UL >= Null,
            0UL == Null,
            0UL != Null,
            Null < 0.0,
            Null <= 0.0,
            Null > 0.0,
            Null >= 0.0,
            Null == 0.0,
            Null != 0.0,
            0.0 < Null,
            0.0 <= Null,
            0.0 > Null,
            0.0 >= Null,
            0.0 == Null,
            0.0 != Null,
        ];
        bool[] Expected =
        [
            true,
            true,
            false,
            false,
            false,
            true,
            false,
            false,
            true,
            true,
            false,
            true,
            true,
            true,
            false,
            false,
            false,
            true,
            false,
            false,
            true,
            true,
            false,
            true,
            true,
            true,
            false,
            false,
            false,
            true,
            false,
            false,
            true,
            true,
            false,
            true,
        ];

        Assert.That(Actual, Is.EqualTo(Expected));
    }

    [Test]
    public void TestFloatStringExponentBeyondNativeLong()
    {
        const string Expected = "The exponent of the text is beyond the range of MPIR on this platform.";

        using mpf_t Value = new();

        using IDisposable Scope = Assert.EnterMultipleScope();

        // Beyond 2^63 on every platform.
        Assert.That(() => new mpf_t("1e99999999999999999999"), Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));
        Assert.That(() => new mpf_t("1.5E-99999999999999999999", 10U), Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));
        Assert.That(() => new mpf_t("1@zzzzzzzzzzzz", 36U), Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));
        Assert.That(() => new mpf_t("1@ZZZZZZZZZZZZ", 62U), Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));
        Assert.That(() => mpf.set_str(Value, "1e+99999999999999999999", 10U), Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));
        Assert.That(() => mpf.init_set_str(Value, "1e99999999999999999999", 10U), Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));

        // A large exponent that fits, and texts where MPIR sees no exponent.
        Assert.That(() => new mpf_t("1e100000000"), Throws.Nothing);
        Assert.That(() => mpf.set_str(Value, "1e99999999999999999999", 16U), Throws.Nothing);
        Assert.That(() => mpf.set_str(Value, "1\0e99999999999999999999", 10U), Throws.Nothing);
        Assert.That(() => mpf.set_str(Value, "e99999999999999999999", 10U), Throws.Nothing);
        Assert.That(() => mpf.set_str(Value, "1e99999999999999999999", 63U), Throws.Nothing);
        Assert.That(() => mpf.set_str(Value, "1e+", 10U), Throws.Nothing);

        // The exponent ends at the first character that is not a digit in its base.
        Assert.That(() => mpf.set_str(Value, "1e12x99999999999999999999", 10U), Throws.Nothing);
        Assert.That(() => mpf.set_str(Value, "1e12:99999999999999999999", 10U), Throws.Nothing);
        Assert.That(() => mpf.set_str(Value, "1e12 99999999999999999999", 10U), Throws.Nothing);
        Assert.That(() => mpf.set_str(Value, "1e12_99999999999999999999", 10U), Throws.Nothing);
        Assert.That(() => mpf.set_str(Value, "1e12~99999999999999999999", 10U), Throws.Nothing);
        Assert.That(() => mpf.set_str(Value, "1e", 10U), Throws.Nothing);

        // Above base 36, lowercase letters are the digits 36 to 61.
        Assert.That(() => new mpf_t("1@zzzzzzzzzzz", 62U), Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));

        // MPIR receives the base as an int: a negative base gives a decimal exponent, and a base below -62 is invalid.
        Assert.That(() => mpf.set_str(Value, "1@99999999999999999999", unchecked((uint)-16)), Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));
        Assert.That(() => mpf.set_str(Value, "1e99999999999999999999", unchecked((uint)-10)), Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));
        Assert.That(() => mpf.set_str(Value, "1e99999999999999999999", unchecked((uint)-63)), Throws.Nothing);
        Assert.That(() => mpf.set_str(Value, "1e99999999999999999999", 1U), Throws.Nothing);
        Assert.That(() => new mpf_t("1e99999999999999999999", 0U), Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));
    }

    [Test]
    public void TestAiryOfSpecialValues()
    {
        using mpfr_t Zero = mpfr_t.Zero();
        using mpfr_t Infinity = new(double.PositiveInfinity);
        using mpfr_t NegativeInfinity = new(double.NegativeInfinity);
        using mpfr_t NotANumber = new(double.NaN);
        using mpfr_t AtZero = Zero.Airy();
        using mpfr_t AtInfinity = Infinity.Airy();
        using mpfr_t AtNegativeInfinity = NegativeInfinity.Airy();
        using mpfr_t AtNotANumber = NotANumber.Airy();

        // Ai(0) = 3^(-2/3) / Gamma(2/3).
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That((double)AtZero, Is.EqualTo(0.35502805388781723).Within(1e-16));
        Assert.That(AtInfinity.IsZero, Is.True);
        Assert.That(AtNegativeInfinity.IsZero, Is.True);
        Assert.That(AtNotANumber.IsNan, Is.True);
    }

    [Test]
    public void TestFloatStringExponentBeyondWindowsLong()
    {
        // A C long is 32-bit only on Windows, where the widest exponent range of MPFR is also smaller.
        if (mpfr_t.MaxMaxExponent == int.MaxValue)
            return;

        const string Expected = "The exponent of the text is beyond the range of MPIR on this platform.";

        // These exponents were wrapped by MPIR: 1e4294967296 gave 1.
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => new mpf_t("1e4294967296"), Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));
        Assert.That(() => new mpf_t("1e2147483648"), Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));
        Assert.That(() => new mpf_t("1@80000000", 16U), Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));
        Assert.That(() => new mpf_t("0.5e-2147483647"), Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));
    }

    [TestCase(mpfr_rnd_t.MPFR_RNDN, false)]
    [TestCase(mpfr_rnd_t.MPFR_RNDZ, false)]
    [TestCase(mpfr_rnd_t.MPFR_RNDD, false)]
    [TestCase(mpfr_rnd_t.MPFR_RNDU, true)]
    [TestCase(mpfr_rnd_t.MPFR_RNDA, true)]
    public void TestAiryUnderflow(mpfr_rnd_t rounding, bool isSmallest)
    {
        // Ai(2e6) is about 2^(-2.7e9), and Ai(1e100) is even smaller: MPFR would try to compute them.
        using mpfr_t Moderate = new(2e6);
        using mpfr_t Huge = new(1e100);
        using mpfr_t Result = new();
        using mpfr_t Smallest = new(1, (long)mpfr_t.MinExponent - 1L);

        mpfr.clear_flags();
        int Ternary = mpfr.ai(Result, Moderate, rounding);
        bool IsUnderflow = mpfr.underflow_p();
        bool IsResultSmallest = isSmallest ? Result == Smallest : Result.IsZero && Result.SignBit == 0;
        int HugeTernary = mpfr.ai(Result, Huge, rounding);
        bool IsHugeResultSmallest = isSmallest ? Result == Smallest : Result.IsZero && Result.SignBit == 0;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(IsUnderflow, Is.True);
        Assert.That(IsResultSmallest, Is.True);
        Assert.That(IsHugeResultSmallest, Is.True);
        Assert.That(Ternary, isSmallest ? Is.Positive : Is.Negative);
        Assert.That(HugeTernary, isSmallest ? Is.Positive : Is.Negative);
    }

    [Test]
    public void TestAiryUnderflowWithSmallerRange()
    {
        int MinExponent = mpfr_t.MinExponent;

        try
        {
            mpfr_t.MinExponent = -1000;

            // Ai(150) is about 2^(-1767), below 2^(emin - 2) for this range, while Ai(50) is about 2^(-342).
            using mpfr_t Large = new(150.0);
            using mpfr_t Moderate = new(50.0);
            using mpfr_t Small = new(0.5);
            using mpfr_t Tiny = Large.Airy();
            using mpfr_t Representable = Moderate.Airy();
            using mpfr_t Ordinary = Small.Airy();

            using IDisposable Scope = Assert.EnterMultipleScope();
            Assert.That(Tiny.IsZero, Is.True);
            Assert.That(Representable.IsZero, Is.False);
            Assert.That((double)Ordinary, Is.EqualTo(0.23169360648083349).Within(1e-16));
        }
        finally
        {
            mpfr_t.MinExponent = MinExponent;
        }
    }

    [Test]
    public void TestAiryOfLargeNegativeNumber()
    {
        const string Expected = "The operand is beyond the range where MPFR can compute the Airy function.";

        using mpfr_t Huge = new(-1e30);
        using mpfr_t Result = new();

        using IDisposable Scope = Assert.EnterMultipleScope();

        // The working precision would be about 1e45 bits on every platform.
        Assert.That(() => Huge.Airy(), Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));
        Assert.That(() => mpfr.ai(Result, Huge, mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));

        // On Windows, the maximum precision is 2^31 - 257, which -2e6 exceeds. Elsewhere, MPFR would take a very long time.
        if (mpfr_t.MaxMaxExponent != int.MaxValue)
        {
            using mpfr_t Large = new(-2e6);
            Assert.That(() => Large.Airy(), Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));
        }
    }
}
