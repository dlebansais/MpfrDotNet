namespace Test;

using System;
using System.IO;
using System.Text;
using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

// Arguments that made MPIR, GMP or MPFR crash or abort, and results that were wrong, found by the fourth review.
[TestFixture]
internal class NativeCallChecks
{
    [Test]
    public void TestNullStringsInParsingFunctions()
    {
        string NullText = Sample.CreateNull<string>();

        using mpz_t Integer = new();
        using mpq_t Rational = new();
        using mpf_t Float = new();
        using mpfr_t Mpfr = new();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => mpz.set_str(Integer, NullText, 10U), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("str"));
        Assert.That(() => mpz.init_set_str(Integer, NullText, 10U), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("content"));
        Assert.That(() => mpq.set_str(Rational, NullText, 10), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("str"));
        Assert.That(() => mpf.set_str(Float, NullText, 10U), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("str"));
        Assert.That(() => mpf.init_set_str(Float, NullText, 10U), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("str"));
        Assert.That(() => mpfr.set_str(Mpfr, NullText, 10U, mpfr_rnd_t.MPFR_RNDN), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("str"));
    }

    [Test]
    public void TestEndianness()
    {
        const string Expected = "The endianness must be -1, 0 or 1.";

        using mpz_t Value = new(0x010203040506L);
        using mpz_t Imported = new();
        byte[] Native = new byte[6];

        mpz.export(Native, out _, 1, 2UL, 0, 0UL, Value);
        mpz.import(Imported, 3UL, 1, 2UL, 0, 0UL, Native);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Imported.ToString(16), Is.EqualTo("10203040506"));
        Assert.That(() => mpz.export(new byte[8], out _, 1, 1UL, 2, 0UL, Value), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith(Expected).And.Property(nameof(ArgumentOutOfRangeException.ParamName)).EqualTo("endian"));
        Assert.That(() => mpz.import(Imported, 1UL, 1, 1UL, -2, 0UL, Native), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith(Expected).And.Property(nameof(ArgumentOutOfRangeException.ParamName)).EqualTo("endian"));
    }

    [Test]
    public void TestSameResultForSineAndCosine()
    {
        const string Expected = "The two results must be different numbers.";

        using mpfr_t x = new(0.5);
        using mpfr_t Result = new();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => mpfr.sin_cos(Result, Result, x, mpfr_rnd_t.MPFR_RNDN), Throws.ArgumentException.With.Message.StartsWith(Expected).And.Property(nameof(ArgumentException.ParamName)).EqualTo("cop"));
        Assert.That(() => mpfr.sinh_cosh(Result, Result, x, mpfr_rnd_t.MPFR_RNDN), Throws.ArgumentException.With.Message.StartsWith(Expected).And.Property(nameof(ArgumentException.ParamName)).EqualTo("cop"));
    }

    [Test]
    public void TestIncompleteGammaOfHugeArgument()
    {
        // Gamma(1e18) overflows the widest exponent range on all platforms; Gamma(2e6) does not, even on Windows.
        using mpfr_t Huge = new(1e18);
        using mpfr_t Large = new(2e6);
        using mpfr_t Small = new(5.0);
        using mpfr_t One = new(1.0);
        using mpfr_t LargeResult = Large.IncompleteGamma(One);
        using mpfr_t SmallResult = Small.IncompleteGamma(One);
        uint Flags = mpfr_t.GetAllFlags();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => Huge.IncompleteGamma(One), Throws.TypeOf<OverflowException>().With.Message.EqualTo("Gamma of the operand is beyond the exponent range of MPFR."));
        Assert.That(LargeResult.IsNumber, Is.True);
        Assert.That((double)SmallResult, Is.EqualTo(23.912163676143752).Within(1e-12));

        // The check computes Gamma, but leaves no flag behind.
        Assert.That(mpfr_t.GetAllFlags(), Is.EqualTo(Flags));
    }

    [Test]
    public void TestRationalOperandsNearTheLimit()
    {
        // Only the 32-bit exponents of Windows have a range that a number in memory can reach: 2^30 bits, 128 MiB.
        if (mpfr_t.MaxMaxExponent == int.MaxValue)
            return;

        const string Expected = "The operand has too many bits for the exponent range of MPFR.";

        using mpz_t One = new(1);
        using mpz_t Huge = new mpz_t(1) << mpfr_t.MaxMaxExponent;
        using mpz_t Large = new mpz_t(1) << (mpfr_t.MaxMaxExponent - 100);
        using mpq_t Tiny = new(One, Huge);
        using mpq_t Big = new(Large, One);
        using mpfr_t x = new(1);
        using mpfr_t Result = new();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => mpfr.cmp_q(x, Tiny), Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));
        Assert.That(() => x > Tiny, Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));

        // A sum keeps a margin below the range for the working precision.
        Assert.That(() => mpfr.add_q(Result, x, Big, mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));
        Assert.That(() => mpfr.sub_q(Result, x, Big, mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));
    }

    [Test]
    public void TestRationalSumNearTheLargestNumber()
    {
        int MaxExponent = mpfr_t.MaxExponent;

        try
        {
            mpfr_t.MaxExponent = mpfr_t.MaxMaxExponent;

            // MPFR rounds x +/- 1/3 to the precision of the result plus 10 bits before rounding it to the result. That
            // gives 2^emax when x is the largest number with 200 bits, which overflowed inside MPFR on Windows.
            using mpq_t Third = new(1UL, 3UL);
            using mpq_t Zero = new(0L, 1UL);
            using mpfr_t x = mpfr_t.Create(200UL);
            mpfr.set_inf(x, +1);
            mpfr.nextbelow(x);
            using mpfr_t MinusX = -x;
            using mpfr_t Result = mpfr_t.Create(53UL);
            using mpfr_t Largest = mpfr_t.Create(53UL);
            mpfr.set_inf(Largest, +1);
            mpfr.nextbelow(Largest);
            using mpfr_t Exact = mpfr_t.Create(200UL);

            mpfr.clear_flags();
            int NearestSum = mpfr.add_q(Result, x, Third, mpfr_rnd_t.MPFR_RNDN);
            bool IsSumInfinite = Result.IsInf && mpfr.signbit(Result) == 0;
            bool IsOverflow = mpfr.overflow_p();
            int NearestDifference = mpfr.sub_q(Result, MinusX, Third, mpfr_rnd_t.MPFR_RNDN);
            bool IsDifferenceInfinite = Result.IsInf && mpfr.signbit(Result) != 0;
            int TowardZeroSum = mpfr.add_q(Result, x, Third, mpfr_rnd_t.MPFR_RNDZ);
            bool IsSumLargest = Result == Largest;
            int ExactSum = mpfr.add_q(Exact, x, Zero, mpfr_rnd_t.MPFR_RNDN);

            using IDisposable Scope = Assert.EnterMultipleScope();
            Assert.That(NearestSum, Is.Positive);
            Assert.That(IsSumInfinite, Is.True);
            Assert.That(IsOverflow, Is.True);
            Assert.That(NearestDifference, Is.Negative);
            Assert.That(IsDifferenceInfinite, Is.True);
            Assert.That(TowardZeroSum, Is.Negative);
            Assert.That(IsSumLargest, Is.True);
            Assert.That(ExactSum, Is.Zero);
            Assert.That(Exact, Is.EqualTo(x));
        }
        finally
        {
            mpfr_t.MaxExponent = MaxExponent;
        }
    }

    [Test]
    public void TestExactRationalFromLong()
    {
        using mpq_t FromLong = new(long.MaxValue);
        using mpq_t FromULong = new(ulong.MaxValue);
        using mpq_t FromOdd = new(9007199254740993L);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(FromLong.ToString(), Is.EqualTo("9223372036854775807"));
        Assert.That(FromULong.ToString(), Is.EqualTo("18446744073709551615"));
        Assert.That(FromOdd.ToString(), Is.EqualTo("9007199254740993"));
    }

    [Test]
    public void TestFloatToDoubleBeyondRange()
    {
        using mpf_t One = new(1.0);
        using mpf_t MinusOne = new(-1.0);
        using mpf_t HugeStep = One << int.MaxValue;
        using mpf_t Huge = HugeStep << int.MaxValue;
        using mpf_t TinyStep = One >> int.MaxValue;
        using mpf_t Tiny = TinyStep >> int.MaxValue;
        using mpf_t NegativeHuge = MinusOne << int.MaxValue;
        using mpf_t NegativeTiny = MinusOne >> int.MaxValue;
        using mpf_t Large = One << 1000;
        using mpf_t Smallest = One >> 1074;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(mpf.get_d(Huge), Is.EqualTo(double.PositiveInfinity));
        Assert.That(mpf.get_d(NegativeHuge), Is.EqualTo(double.NegativeInfinity));
        Assert.That(mpf.get_d(Tiny), Is.Zero);
        Assert.That(1.0 / mpf.get_d(NegativeTiny), Is.EqualTo(double.NegativeInfinity));
        Assert.That(mpf.get_d(Large), Is.EqualTo(Math.Pow(2, 1000)));
        Assert.That(mpf.get_d(Smallest), Is.EqualTo(double.Epsilon));
    }

    [TestCase(mpfr_rnd_t.MPFR_RNDN)]
    [TestCase(mpfr_rnd_t.MPFR_RNDZ)]
    [TestCase(mpfr_rnd_t.MPFR_RNDU)]
    [TestCase(mpfr_rnd_t.MPFR_RNDD)]
    [TestCase(mpfr_rnd_t.MPFR_RNDA)]
    public void TestRationalZeroMinusZero(mpfr_rnd_t rounding)
    {
        using mpq_t RationalZero = new(0L, 1UL);
        using mpq_t Half = new(1UL, 2UL);
        using mpfr_t PositiveZero = mpfr_t.Zero();
        using mpfr_t NegativeZero = mpfr_t.Zero(-1);
        using mpfr_t PointFive = new(0.5);
        PositiveZero.Rounding = rounding;
        NegativeZero.Rounding = rounding;
        PointFive.Rounding = rounding;

        // As for the integer operands of mpfr_z_sub: 0 - (+0) = -0 and 0 - (-0) = +0, in all rounding modes. A cancellation
        // gives +0, or -0 when rounding toward -infinity.
        using mpfr_t FromPositive = RationalZero - PositiveZero;
        using mpfr_t FromNegative = RationalZero - NegativeZero;
        using mpfr_t Cancellation = Half - PointFive;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(FromPositive.SignBit, Is.Not.Zero);
        Assert.That(FromNegative.SignBit, Is.Zero);
        Assert.That(Cancellation.IsZero, Is.True);
        Assert.That(Cancellation.SignBit != 0, Is.EqualTo(rounding == mpfr_rnd_t.MPFR_RNDD));
    }

    [Test]
    public void TestNumeratorAndDenominatorOfTemporary()
    {
        using mpq_t a = new(3UL, 4UL);
        using mpq_t b = new(5UL, 7UL);
        using mpq_t Quotient = a / b;
        using mpz_t Numerator = Quotient.GetNumerator();
        using mpz_t Denominator = Quotient.GetDenominator();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Numerator.ToString(), Is.EqualTo("21"));
        Assert.That(Denominator.ToString(), Is.EqualTo("20"));
    }

    [Test]
    public void TestReadIntegersFromPartialReads()
    {
        using mpz_t Value = new();
        using OneByteStream Stream = new(Encoding.ASCII.GetBytes("  12345 678"));
        using StreamReader Reader = new(Stream, Encoding.ASCII, detectEncodingFromByteOrderMarks: false, bufferSize: 1);

        long First = mpz.inp_str(Value, Reader, 10);
        string FirstValue = Value.ToString();
        long Second = mpz.inp_str(Value, Reader, 10);
        string SecondValue = Value.ToString();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(First, Is.EqualTo(7L));
        Assert.That(FirstValue, Is.EqualTo("12345"));
        Assert.That(Second, Is.EqualTo(4L));
        Assert.That(SecondValue, Is.EqualTo("678"));
    }

    [Test]
    public void TestRandomFactoryArguments()
    {
        randstate_t NullState = Sample.CreateNull<randstate_t>();
        randstate_t Disposed = new();
        Disposed.Dispose();

        using randstate_t State = new();
        ulong LiveObjectCount = mpfr_t.LiveObjectCount();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => mpfr_t.UniformRandom(NullState), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("randomState"));
        Assert.That(() => mpfr_t.UniformRandom(NullState, mpfr_rnd_t.MPFR_RNDN), Throws.ArgumentNullException);
        Assert.That(() => mpfr_t.GaussianRandom(NullState), Throws.ArgumentNullException);
        Assert.That(() => mpfr_t.GaussianRandom(NullState, out _, out _), Throws.ArgumentNullException);
        Assert.That(() => mpfr_t.ExponentialRandom(NullState), Throws.ArgumentNullException);
        Assert.That(() => mpfr_t.UniformRandom(Disposed), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => mpfr_t.UniformRandom(Disposed, mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => mpfr_t.GaussianRandom(Disposed), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => mpfr_t.GaussianRandom(Disposed, out _, out _), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => mpfr_t.ExponentialRandom(Disposed), Throws.TypeOf<ObjectDisposedException>());
        Assert.That(() => mpfr_t.UniformRandom(State, mpfr_rnd_t.MPFR_RNDNA), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => mpfr_t.GaussianRandom(State, mpfr_rnd_t.MPFR_RNDNA), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => mpfr_t.GaussianRandom(State, out _, out _, mpfr_rnd_t.MPFR_RNDNA), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => mpfr_t.ExponentialRandom(State, mpfr_rnd_t.MPFR_RNDNA), Throws.TypeOf<ArgumentOutOfRangeException>());

        // The arguments are checked before any result is created.
        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(LiveObjectCount));
    }

    [Test]
    public void TestSignificandAndExponent()
    {
        using mpfr_t Value = new(3.75);
        using mpfr_t Significand = mpfr_t.ToIntegralFractional(Value, out int Exponent);

        // 3.75 = 0.9375 * 2^2.
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That((double)Significand, Is.EqualTo(0.9375));
        Assert.That(Exponent, Is.EqualTo(2));
    }
}
