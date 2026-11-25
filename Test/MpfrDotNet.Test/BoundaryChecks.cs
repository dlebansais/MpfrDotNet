namespace Test;

using System;
using System.IO;
using System.Linq;
using System.Text;
using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

// Paths and limits that the other tests did not reach, found with mutation testing.
[TestFixture]
internal class BoundaryChecks
{
    [Test]
    public void TestSetNan()
    {
        using mpfr_t Value = new(1.5);
        mpfr.set_nan(Value);

        Assert.That(Value.IsNan, Is.True);
    }

    [Test]
    public void TestTruncatingConversions()
    {
        // 1 + 3 * 2^-54 truncates to 1, and rounds to nearest to 1 + 2^-52.
        using mpz_t Numerator = (new mpz_t(1) << 54) + 3;
        using mpz_t Denominator = new mpz_t(1) << 54;
        using mpq_t Rational = new(Numerator, Denominator);
        using mpf_t Float = new(256UL);
        mpf.set_q(Float, Rational);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(mpq.get_d(Rational), Is.EqualTo(1.0));
        Assert.That(mpf.get_d(Float), Is.EqualTo(1.0));
        Assert.That((double)Rational, Is.EqualTo(1.0000000000000002));
    }

    [Test]
    public void TestLargeRationalToDouble()
    {
        // 2^200 is a double, but not a float: the range of double must be used.
        using mpz_t Power = new mpz_t(1) << 200;
        using mpz_t One = new(1);
        using mpq_t Rational = new(Power, One);
        using mpf_t Float = new(256UL);
        mpf.set_q(Float, Rational);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That((double)Rational, Is.EqualTo(Math.Pow(2, 200)));
        Assert.That((double)Float, Is.EqualTo(Math.Pow(2, 200)));
    }

    [Test]
    public void TestConstructorsRejectRoundingAndReleaseTheNumber()
    {
        const mpfr_rnd_t Unsupported = mpfr_rnd_t.MPFR_RNDNA;
        const ulong ULongValue = 1UL;
        const long LongValue = 1L;
        const uint UIntValue = 1U;
        const int IntValue = 1;
        const float FloatValue = 1.5f;
        const double DoubleValue = 1.5;
        const long Exponent = 3L;

        using mpfr_t Other = new(1.5);
        using mpz_t Integer = new(1);
        using mpq_t Rational = new(1UL, 2UL);
        using mpf_t Float = new(1.5);
        ulong LiveObjectCount = mpfr_t.LiveObjectCount();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => new mpfr_t(Other, Unsupported), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => new mpfr_t(ULongValue, Unsupported), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => new mpfr_t(LongValue, Unsupported), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => new mpfr_t(UIntValue, Unsupported), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => new mpfr_t(IntValue, Unsupported), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => new mpfr_t(FloatValue, Unsupported), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => new mpfr_t(DoubleValue, Unsupported), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => new mpfr_t(Integer, Unsupported), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => new mpfr_t(Rational, Unsupported), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => new mpfr_t(Float, Unsupported), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => new mpfr_t("1", 10U, Unsupported), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => new mpfr_t("1", 63U), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => new mpfr_t(ULongValue, Exponent, Unsupported), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => new mpfr_t(LongValue, Exponent, Unsupported), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => new mpfr_t(UIntValue, Exponent, Unsupported), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => new mpfr_t(IntValue, Exponent, Unsupported), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => new mpfr_t(Integer, Exponent, Unsupported), Throws.TypeOf<ArgumentOutOfRangeException>());

        // Each constructor releases the number that its chained constructor allocated.
        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(LiveObjectCount));
    }

    [Test]
    public void TestStringConstructorBaseTwo()
    {
        using mpfr_t Value = new("101", 2U);

        Assert.That((double)Value, Is.EqualTo(5.0));
    }

    [TestCase("%Ra", "0x1.8p+0")]
    [TestCase("%9.1Rf", "      1.5")]
    public void TestFormatConversions(string format, string expected)
    {
        using mpfr_t Value = new(1.5);

        Assert.That(Value.ToFormattedString(format), Is.EqualTo(expected));
    }

    [Test]
    public void TestFormatStartingWithNull()
    {
        using mpfr_t Value = new(1.5);

        Assert.That(() => Value.ToFormattedString("\u0000%Rf"), Throws.TypeOf<FormatException>().With.Message.EqualTo("The format cannot contain a null character."));
    }

    [Test]
    public void TestRationalDivisionAtWidestUnderflowMidpointTowardZero()
    {
        // Only the 32-bit exponents of Windows have a widest range small enough for this case.
        if (mpfr_t.MaxMaxExponent == int.MaxValue)
            return;

        int MinExponent = mpfr_t.MinExponent;
        int MaxExponent = mpfr_t.MaxExponent;

        try
        {
            mpfr_t.MinExponent = mpfr_t.MinMinExponent;
            mpfr_t.MaxExponent = mpfr_t.MaxMaxExponent;

            // Toward zero, a value below the smallest number gives zero, even just above half of it.
            using mpz_t Numerator = (new mpz_t(1) << 60) + 1;
            using mpz_t Denominator = new mpz_t(1) << 63;
            using mpq_t x = new(Numerator, Denominator);
            using mpfr_t y = new(1, (long)mpfr_t.MaxMaxExponent - 1L);
            y.Rounding = mpfr_rnd_t.MPFR_RNDZ;

            using mpfr_t Quotient = x / y;

            using IDisposable Scope = Assert.EnterMultipleScope();
            Assert.That(Quotient.IsZero, Is.True);
            Assert.That(Quotient.LastTernaryResult, Is.Negative);
        }
        finally
        {
            mpfr_t.MinExponent = MinExponent;
            mpfr_t.MaxExponent = MaxExponent;
        }
    }

    [Test]
    public void TestInitsAfterClears()
    {
        using mpz_t Integer = new(1);
        using mpq_t Rational = new(1UL, 2UL);
        using mpf_t Float = new(1.5);

        mpz.clears(Integer);
        mpz.inits(Integer);
        mpz.set_si(Integer, 5L);
        mpq.clears(Rational);
        mpq.inits(Rational);
        mpq.set_si(Rational, 3L, 4UL);
        mpf.clears(Float);
        mpf.inits(Float);
        mpf.set_d(Float, 2.5);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Integer.ToString(), Is.EqualTo("5"));
        Assert.That(Rational.ToString(), Is.EqualTo("3/4"));
        Assert.That((double)Float, Is.EqualTo(2.5));
    }

    [Test]
    public void TestFloatPrecisionAtLimit()
    {
        Assert.That(() => mpf.CheckPrecision(mpf.MaxPrecision, "prec"), Throws.Nothing);
    }

    [Test]
    public void TestRawZero()
    {
        using mpz_t Zero = new(0);
        using MemoryStream Stream = new();
        long Length;

        using (BinaryWriter Writer = new(Stream, Encoding.ASCII, leaveOpen: true))
        {
            Length = mpz.out_raw(Writer, Zero);
        }

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Length, Is.EqualTo(4L));
        Assert.That(Stream.ToArray(), Is.EqualTo(new byte[] { 0, 0, 0, 0 }));
    }

    [Test]
    public void TestRawLargerThanReadChunk()
    {
        // The magnitude takes more than one chunk of 64 KiB: reading it must stop at its end, before the next number.
        using mpz_t Large = (new mpz_t(1) << (8 * 70000)) - 1;
        using mpz_t Next = new(12345);
        using MemoryStream Stream = new();

        using (BinaryWriter Writer = new(Stream, Encoding.ASCII, leaveOpen: true))
        {
            _ = mpz.out_raw(Writer, Large);
            _ = mpz.out_raw(Writer, Next);
        }

        Stream.Seek(0, SeekOrigin.Begin);

        using BinaryReader Reader = new(Stream);
        using mpz_t ReadLarge = new();
        using mpz_t ReadNext = new();
        long LargeLength = mpz.inp_raw(ReadLarge, Reader);
        _ = mpz.inp_raw(ReadNext, Reader);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(LargeLength, Is.EqualTo(70004L));
        Assert.That(ReadLarge, Is.EqualTo(Large));
        Assert.That(ReadNext.ToString(), Is.EqualTo("12345"));
    }

    [Test]
    public void TestExportWordSizes()
    {
        using mpz_t Value = new(ulong.MaxValue);
        byte[] ExactTwoByteWords = new byte[8];

        mpz.export(ExactTwoByteWords, out ulong WordCount, 1, 2UL, 1, 0UL, Value);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(WordCount, Is.EqualTo(4UL));
        Assert.That(ExactTwoByteWords.All(b => b == 0xFF), Is.True);
        Assert.That(() => mpz.export(new byte[6], out _, 1, 2UL, 1, 0UL, Value), Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("rop"));

        // With 7 nails in each byte, each word holds 1 bit: 64 words do not fit in 63 bytes.
        Assert.That(() => mpz.export(new byte[63], out _, 1, 1UL, 1, 7UL, Value), Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("rop"));
    }

    [Test]
    public void TestCongruentPowerOfTwoZero()
    {
        using mpz_t Five = new(5);
        using mpz_t Three = new(3);

        // Every integer is congruent to every other modulo 2^0 = 1.
        Assert.That(Five.IsCongruentPowerOfTwo(Three, 0), Is.True);
    }

    [Test]
    public void TestDefaultRandomStateCanDraw()
    {
        using randstate_t State = randstate_t.Create(RngAlgorithm.Default);
        using mpz_t Value = new();

        mpz.urandomb(Value, State, 64UL);

        Assert.That(mpz.sizeinbase(Value, 2U), Is.LessThanOrEqualTo(64UL));
    }
}
