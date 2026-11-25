namespace Test;

using System;
using System.Text;
using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

// Arguments of the C-named functions that would make MPIR, GMP or MPFR abort, crash or corrupt memory.
[TestFixture]
internal class WrapperChecks
{
    [Test]
    public void TestSizeInBaseLimits()
    {
        const string Expected = "The base must be between 2 and 62.";

        using mpz_t Value = new(255);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => mpz.sizeinbase(Value, 0U), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith(Expected));
        Assert.That(() => mpz.sizeinbase(Value, 1U), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith(Expected));
        Assert.That(() => mpz.sizeinbase(Value, 63U), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith(Expected));
        Assert.That(mpz.sizeinbase(Value, 2U), Is.EqualTo(8UL));
        Assert.That(mpz.sizeinbase(Value, 62U), Is.EqualTo(2UL));
    }

    [Test]
    public void TestMpfrBaseLimits()
    {
        using mpfr_t Value = new();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => mpfr.get_str_ndigits(1, 53UL), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith("The base must be between 2 and 62."));
        Assert.That(() => mpfr.get_str_ndigits(63, 53UL), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith("The base must be between 2 and 62."));
        Assert.That(mpfr.get_str_ndigits(2, 53UL), Is.EqualTo(53UL));
        Assert.That(mpfr.get_str_ndigits(62, 53UL), Is.Positive);
        Assert.That(() => mpfr.set_str(Value, "1", 1U, mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith("The base must be 0 or between 2 and 62."));
        Assert.That(() => mpfr.set_str(Value, "1", 63U, mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith("The base must be 0 or between 2 and 62."));
        Assert.That(mpfr.set_str(Value, "0x10", 0U, mpfr_rnd_t.MPFR_RNDN), Is.True);
        Assert.That((double)Value, Is.EqualTo(16.0));
        Assert.That(mpfr.set_str(Value, "z", 62U, mpfr_rnd_t.MPFR_RNDN), Is.True);
        Assert.That((double)Value, Is.EqualTo(61.0));
    }

    [Test]
    public void TestIntegerGetStrGrowsTheBuffer()
    {
        string Digits = "1" + new string('0', 200);
        StringBuilder NullBuilder = Sample.CreateNull<StringBuilder>();

        using mpz_t Value = new(Digits);
        using mpz_t Negative = -Value;
        using mpz_t TwoHundredFiftyFive = new(255);
        StringBuilder Small = new();
        StringBuilder Hexadecimal = new(1);
        StringBuilder WithNegative = new(1);

        mpz.get_str(Small, 10, Value);
        mpz.get_str(Hexadecimal, -16, TwoHundredFiftyFive);
        mpz.get_str(WithNegative, 10, Negative);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Small.ToString(), Is.EqualTo(Digits));
        Assert.That(Hexadecimal.ToString(), Is.EqualTo("FF"));
        Assert.That(WithNegative.ToString(), Is.EqualTo("-" + Digits));
        Assert.That(() => mpz.get_str(NullBuilder, 10, Value), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("str"));
        Assert.That(() => mpz.get_str(new StringBuilder(), 63, Value), Throws.TypeOf<ArgumentOutOfRangeException>().With.Property(nameof(ArgumentOutOfRangeException.ParamName)).EqualTo("strBase"));
    }

    [Test]
    public void TestRationalGetStrGrowsTheBuffer()
    {
        string Numerator = "-1" + new string('0', 100) + "1";
        string Denominator = "3" + new string('0', 100);
        StringBuilder NullBuilder = Sample.CreateNull<StringBuilder>();

        using mpq_t Value = new($"{Numerator}/{Denominator}");
        StringBuilder Small = new(1);

        mpq.get_str(Small, 10, Value);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Small.ToString(), Is.EqualTo($"{Numerator}/{Denominator}"));
        Assert.That(() => mpq.get_str(NullBuilder, 10, Value), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("str"));
        Assert.That(() => mpq.get_str(new StringBuilder(), 1, Value), Throws.TypeOf<ArgumentOutOfRangeException>().With.Property(nameof(ArgumentOutOfRangeException.ParamName)).EqualTo("strBase"));
    }

    [TestCase(2, 0UL)]
    [TestCase(10, 0UL)]
    [TestCase(62, 0UL)]
    [TestCase(-36, 0UL)]
    [TestCase(10, 5UL)]
    [TestCase(10, 100000UL)]
    public void TestFloatGetStrGrowsTheBuffer(int strBase, ulong digits)
    {
        StringBuilder NullBuilder = Sample.CreateNull<StringBuilder>();

        using mpf_t Value = new(-1.0, 1024UL);
        using mpf_t Seven = new(7.0, 1024UL);
        mpf.div(Value, Value, Seven);

        StringBuilder Small = new(1);
        mpf.get_str(Small, out int Exponent, strBase, digits, Value);

        // 1/7 has infinitely many digits in these bases, so the output fills the precision.
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Small.ToString(), Does.StartWith("-"));
        Assert.That(Small.Length, Is.GreaterThan(digits == 5UL ? 5 : 100));
        Assert.That(Exponent, Is.LessThanOrEqualTo(0));
        Assert.That(() => mpf.get_str(NullBuilder, out _, strBase, digits, Value), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("str"));
        Assert.That(() => mpf.get_str(new StringBuilder(), out _, -37, digits, Value), Throws.TypeOf<ArgumentOutOfRangeException>().With.Property(nameof(ArgumentOutOfRangeException.ParamName)).EqualTo("strBase"));
    }

    [TestCase(2U, 1UL)]
    [TestCase(3U, 1UL)]
    [TestCase(4U, 2UL)]
    [TestCase(62U, 5UL)]
    public void TestFloorLog2(uint value, ulong expected)
    {
        Assert.That(mpf.FloorLog2(value), Is.EqualTo(expected));
    }

    [Test]
    public void TestMpfrGetStrGrowsTheBuffer()
    {
        StringBuilder NullBuilder = Sample.CreateNull<StringBuilder>();

        using mpfr_t Third = mpfr_t.Create(512UL);
        using mpfr_t Infinity = mpfr_t.Create(1UL);
        _ = mpfr.set_ui(Third, 1UL, mpfr_rnd_t.MPFR_RNDN);
        _ = mpfr.div_ui(Third, Third, 3UL, mpfr_rnd_t.MPFR_RNDN);
        mpfr.set_inf(Infinity, -1);

        StringBuilder AllDigits = new(1);
        StringBuilder FewDigits = new(1);
        StringBuilder Singular = new(1);
        mpfr.get_str(AllDigits, out _, 10, 0UL, Third, mpfr_rnd_t.MPFR_RNDN);
        mpfr.get_str(FewDigits, out _, 10, 3UL, Third, mpfr_rnd_t.MPFR_RNDN);
        mpfr.get_str(Singular, out _, 10, 1UL, Infinity, mpfr_rnd_t.MPFR_RNDN);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(AllDigits.ToString(), Has.Length.EqualTo((int)mpfr.get_str_ndigits(10, 512UL)));
        Assert.That(FewDigits.ToString(), Is.EqualTo("333"));
        Assert.That(Singular.ToString(), Is.EqualTo("-@Inf@"));
        Assert.That(() => mpfr.get_str(NullBuilder, out _, 10, 0UL, Third, mpfr_rnd_t.MPFR_RNDN), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("str"));
        Assert.That(() => mpfr.get_str(new StringBuilder(), out _, 63, 0UL, Third, mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<ArgumentOutOfRangeException>().With.Property(nameof(ArgumentOutOfRangeException.ParamName)).EqualTo("strbase"));
    }

    [Test]
    public void TestExportArraySize()
    {
        byte[] NullArray = Sample.CreateNull<byte[]>();

        using mpz_t Value = new(ulong.MaxValue);
        using mpz_t Zero = new(0);
        byte[] Exact = new byte[8];
        byte[] Bits = new byte[64];

        mpz.export(Exact, out ulong ExactCount, 1, 1UL, 1, 0UL, Value);
        mpz.export(Array.Empty<byte>(), out ulong ZeroCount, 1, 1UL, 1, 0UL, Zero);

        // With 7 nails in each byte, each word holds 1 bit.
        mpz.export(Bits, out ulong BitCount, 1, 1UL, 1, 7UL, Value);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(ExactCount, Is.EqualTo(8UL));
        Assert.That(Exact, Is.All.EqualTo((byte)0xFF));
        Assert.That(ZeroCount, Is.Zero);
        Assert.That(BitCount, Is.EqualTo(64UL));
        Assert.That(() => mpz.export(new byte[7], out _, 1, 1UL, 1, 0UL, Value), Throws.ArgumentException.With.Message.StartsWith("The array is too small for the value.").And.Property(nameof(ArgumentException.ParamName)).EqualTo("rop"));
        Assert.That(() => mpz.export(new byte[8], out _, 1, 16UL, 1, 0UL, Value), Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("rop"));
        Assert.That(() => mpz.export(NullArray, out _, 1, 1UL, 1, 0UL, Value), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("rop"));
        Assert.That(() => mpz.export(Exact, out _, 1, 0UL, 1, 0UL, Value), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith("The size of a word cannot be zero.").And.Property(nameof(ArgumentOutOfRangeException.ParamName)).EqualTo("size"));
        Assert.That(() => mpz.export(Exact, out _, 1, 1UL, 1, 8UL, Value), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith("The nails must be fewer than the bits of a word.").And.Property(nameof(ArgumentOutOfRangeException.ParamName)).EqualTo("nails"));
    }

    [Test]
    public void TestImportArraySize()
    {
        byte[] NullArray = Sample.CreateNull<byte[]>();

        using mpz_t Value = new();
        byte[] Bytes = [1, 2, 3, 4];

        mpz.import(Value, 2UL, 1, 2UL, 1, 0UL, Bytes);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Value.ToString(16), Is.EqualTo("1020304"));
        Assert.That(() => mpz.import(Value, 1000UL, 1, 1UL, 1, 0UL, Bytes), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith("The words do not fit in the array.").And.Property(nameof(ArgumentOutOfRangeException.ParamName)).EqualTo("count"));
        Assert.That(() => mpz.import(Value, 3UL, 1, 2UL, 1, 0UL, Bytes), Throws.TypeOf<ArgumentOutOfRangeException>().With.Property(nameof(ArgumentOutOfRangeException.ParamName)).EqualTo("count"));
        Assert.That(() => mpz.import(Value, 1UL, 1, 1UL, 1, 0UL, NullArray), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("op"));
        Assert.That(() => mpz.import(Value, 1UL, 1, 0UL, 1, 0UL, Bytes), Throws.TypeOf<ArgumentOutOfRangeException>().With.Property(nameof(ArgumentOutOfRangeException.ParamName)).EqualTo("size"));
    }

    [Test]
    public void TestFloatPrecisionLimits()
    {
        const string AllocatedExpected = "The precision cannot be greater than the allocated precision.";
        string LimitExpected = $"The precision must be {mpf.MaxPrecision} or less.";

        using mpf_t Value = new(1.0);
        using mpf_t Other = new(1.0);
        ulong DefaultPrecision = mpf.get_default_prec();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(mpf.MaxPrecision, Is.EqualTo(((ulong)int.MaxValue * 64UL) - 64UL));
        Assert.That(() => Value.SetPrecisionRaw(1UL << 37), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith(AllocatedExpected));
        Assert.That(() => Value.SetPrecisionRaw(1UL << 38), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith(AllocatedExpected));
        Assert.That(() => Value.SetPrecisionRaw(ulong.MaxValue), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith(AllocatedExpected));
        Assert.That(Value.Precision, Is.EqualTo(DefaultPrecision));
        Assert.That(() => mpf.init2(Other, mpf.MaxPrecision + 1UL), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith(LimitExpected));
        Assert.That(() => mpf.set_prec(Other, mpf.MaxPrecision + 1UL), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith(LimitExpected));
        Assert.That(() => mpf.set_default_prec(mpf.MaxPrecision + 1UL), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith(LimitExpected));
        Assert.That(mpf.get_default_prec(), Is.EqualTo(DefaultPrecision));
    }

    [TestCase(0UL, 2UL)]
    [TestCase(64UL, 2UL)]
    [TestCase(65UL, 3UL)]
    [TestCase(ulong.MaxValue - 127UL, (ulong.MaxValue - 1UL) / 64UL)]
    [TestCase(ulong.MaxValue - 126UL, ulong.MaxValue / 64UL)]
    [TestCase(ulong.MaxValue, ulong.MaxValue / 64UL)]
    public void TestPrecisionToLimbs(ulong prec, ulong expected)
    {
        Assert.That(mpf.PrecisionToLimbs(prec), Is.EqualTo(expected));
    }

    [Test]
    public void TestUnsupportedRoundingModes()
    {
        const string Expected = "The rounding mode must be MPFR_RNDN, MPFR_RNDZ, MPFR_RNDU, MPFR_RNDD, MPFR_RNDA or MPFR_RNDF.";
        const mpfr_rnd_t OutOfRange = (mpfr_rnd_t)42;
        const mpfr_rnd_t BelowRange = (mpfr_rnd_t)(-2);

        using mpfr_t x = new(2.5);
        using mpfr_t y = mpfr_t.Create(64UL);
        using mpfr_t Result = new();
        using mpfr_t Rounded = new();
        ulong LiveObjectCount = mpfr_t.LiveObjectCount();

        // MPFR_RNDNA rounds ties away from zero in mpfr_rint, the only function that supports it with mpfr_subnormalize.
        _ = mpfr.rint(Rounded, x, mpfr_rnd_t.MPFR_RNDNA);
        int Ternary = mpfr.subnormalize(Rounded, 0, mpfr_rnd_t.MPFR_RNDNA);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That((double)Rounded, Is.EqualTo(3.0));
        Assert.That(Ternary, Is.Zero);
        Assert.That(() => x.Rounding = mpfr_rnd_t.MPFR_RNDNA, Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith(Expected).And.Property(nameof(ArgumentOutOfRangeException.ParamName)).EqualTo("value"));
        Assert.That(() => x.Rounding = OutOfRange, Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith(Expected));
        Assert.That(x.Rounding, Is.EqualTo(mpfr_rnd_t.MPFR_RNDN));
        Assert.That(() => mpfr.add(Result, x, y, mpfr_rnd_t.MPFR_RNDNA), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith(Expected).And.Property(nameof(ArgumentOutOfRangeException.ParamName)).EqualTo("rnd"));
        Assert.That(() => mpfr.add(Result, x, y, BelowRange), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith(Expected));
        Assert.That(() => mpfr.can_round(x, 10, mpfr_rnd_t.MPFR_RNDNA, mpfr_rnd_t.MPFR_RNDN, 2UL), Throws.TypeOf<ArgumentOutOfRangeException>().With.Property(nameof(ArgumentOutOfRangeException.ParamName)).EqualTo("rnd1"));
        Assert.That(() => mpfr.rint(Rounded, x, OutOfRange), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith(Expected));
        Assert.That(() => mpfr_t.DefaultRoundingMode = mpfr_rnd_t.MPFR_RNDNA, Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith(Expected));
        Assert.That(mpfr_t.DefaultRoundingMode, Is.EqualTo(mpfr_rnd_t.MPFR_RNDN));
        Assert.That(() => new mpfr_t(1.5, mpfr_rnd_t.MPFR_RNDNA), Throws.TypeOf<ArgumentOutOfRangeException>().With.Property(nameof(ArgumentOutOfRangeException.ParamName)).EqualTo("rounding"));
        Assert.That(() => new mpfr_t("1.5", 10U, mpfr_rnd_t.MPFR_RNDNA), Throws.TypeOf<ArgumentOutOfRangeException>().With.Property(nameof(ArgumentOutOfRangeException.ParamName)).EqualTo("rounding"));

        // A constructor that rejects its rounding mode releases the number it allocated.
        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(LiveObjectCount));
    }

    [Test]
    public void TestClearedRandomState()
    {
        randstate_t Cleared = new();
        randstate_t Reused = new();

        gmp.randclear(Cleared);
        gmp.randclear(Reused);
        gmp.randinit_mt(Reused);
        ulong Random = gmp.urandomb_ui(Reused, 8UL);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => gmp.randclear(Cleared), Throws.Nothing);
        Assert.That(Cleared.Dispose, Throws.Nothing);
        Assert.That(Random, Is.LessThan(256UL));
        Assert.That(Reused.Dispose, Throws.Nothing);
        Assert.That(() =>
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }, Throws.Nothing);
    }

    [Test]
    public void TestRandomStateParameters()
    {
        const string NoParameters = "This algorithm takes no parameters.";

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => randstate_t.Create(RngAlgorithm.MersenneTwister, 12345UL), Throws.ArgumentException.With.Message.StartsWith(NoParameters).And.Property(nameof(ArgumentException.ParamName)).EqualTo("parameters"));
        Assert.That(() => randstate_t.Create(RngAlgorithm.Default, 1), Throws.ArgumentException.With.Message.StartsWith(NoParameters).And.Property(nameof(ArgumentException.ParamName)).EqualTo("parameters"));
        Assert.That(() => randstate_t.Create(RngAlgorithm.LinearCongruential, 1, 2), Throws.ArgumentException.With.Message.StartsWith("Invalid combination of parameters for this algorithm.").And.Property(nameof(ArgumentException.ParamName)).EqualTo("parameters"));
    }

    [Test]
    public void TestPowerMod()
    {
        using mpz_t Three = new(3);
        using mpz_t Four = new(4);
        using mpz_t Five = new(5);
        using mpz_t Zero = new(0);
        using mpz_t Power = Three.PowerMod(Four, Five);
        using mpz_t PowerUI = Three.PowerMod(4UL, Five);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Power.ToString(), Is.EqualTo("1"));
        Assert.That(PowerUI.ToString(), Is.EqualTo("1"));
        Assert.That(() => Three.PowerMod(Four, Zero), Throws.TypeOf<DivideByZeroException>());
        Assert.That(() => Three.PowerMod(4UL, Zero), Throws.TypeOf<DivideByZeroException>());
    }

    [Test]
    public void TestFloatRandomArgumentLimits()
    {
        const int MaxExponent = (1 << 30) - 1;

        using randstate_t State = new();
        using mpf_t Value = new();

        if (!Interop.Mpir.NativeMethods.IsMpir)
        {
            Assert.That(() => mpf.rrandomb(Value, State, 1UL, 1), Throws.TypeOf<PlatformNotSupportedException>());
            return;
        }

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => mpf.rrandomb(Value, State, (ulong)long.MaxValue + 1UL, 1), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith($"The size must be {long.MaxValue} or less."));
        Assert.That(() => mpf.rrandomb(Value, State, 1UL, MaxExponent + 1), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith($"The exponent must be between {-MaxExponent} and {MaxExponent}."));
        Assert.That(() => mpf.rrandomb(Value, State, 1UL, -MaxExponent - 1), Throws.TypeOf<ArgumentOutOfRangeException>().With.Property(nameof(ArgumentOutOfRangeException.ParamName)).EqualTo("exp"));
        Assert.That(() => mpf.rrandomb(Value, State, (ulong)long.MaxValue, MaxExponent), Throws.Nothing);
        Assert.That(() => mpf.rrandomb(Value, State, 1UL, -MaxExponent), Throws.Nothing);
    }

    [Test]
    public void TestFloatFarBelowExponentRange()
    {
        using mpf_t One = new(1.0);
        using mpf_t Tiny = One >> int.MaxValue;
        using mpf_t NegativeTiny = -Tiny;
        using mpf_t Zero = new(0.0);
        using mpfr_t RoundedUp = new();
        using mpfr_t RoundedDown = new();
        using mpfr_t Nearest = new();
        using mpfr_t Smallest = new();
        using mpfr_t MpfrOne = new(1);
        using mpfr_t MinusOne = new(-1);
        using mpfr_t MpfrZero = mpfr_t.Zero();
        using mpfr_t NegativeSmallest = new();
        mpfr.set_zero(Smallest, 1);
        mpfr.nextabove(Smallest);
        _ = mpfr.neg(NegativeSmallest, Smallest, mpfr_rnd_t.MPFR_RNDN);

        int UpTernary = mpfr.set_f(RoundedUp, Tiny, mpfr_rnd_t.MPFR_RNDU);
        int DownTernary = mpfr.set_f(RoundedDown, NegativeTiny, mpfr_rnd_t.MPFR_RNDD);
        int NearestTernary = mpfr.set_f(Nearest, Tiny, mpfr_rnd_t.MPFR_RNDN);

        // The number is below the smallest positive number: it rounds to it, or to zero.
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That((double)Tiny, Is.Zero);
        Assert.That((float)Tiny, Is.Zero);
        Assert.That(RoundedUp.ToString(), Is.EqualTo(Smallest.ToString()));
        Assert.That(UpTernary, Is.Positive);
        Assert.That(RoundedDown.ToString(), Is.EqualTo(NegativeSmallest.ToString()));
        Assert.That(DownTernary, Is.Negative);
        Assert.That(Nearest.IsZero, Is.True);
        Assert.That(NearestTernary, Is.Negative);
        Assert.That(mpfr.cmp_f(MpfrOne, Tiny), Is.Positive);
        Assert.That(mpfr.cmp_f(MinusOne, Tiny), Is.Negative);
        Assert.That(mpfr.cmp_f(MpfrZero, Tiny), Is.Negative);
        Assert.That(mpfr.cmp_f(MpfrOne, One), Is.Zero);
        Assert.That(mpfr.IsFarBelowExponentRange(Zero), Is.False);
        Assert.That(mpfr.IsFarBelowExponentRange(One), Is.False);
    }

    [TestCase(long.MinValue, -1000L, true)]
    [TestCase((long.MinValue / 64L) - 1L, long.MinValue, true)]
    [TestCase(long.MinValue / 64L, long.MinValue, false)]
    [TestCase(-16L, -1023L, true)]
    [TestCase(-15L, -1023L, false)]
    public void TestFarBelowExponentRange(long limbExponent, long minExponent, bool expected)
    {
        Assert.That(mpfr.IsFarBelowExponentRange(limbExponent, minExponent), Is.EqualTo(expected));
    }

    [Test]
    public void TestOperandBitCountLimit()
    {
        // The native limit: mpfr_t.MaxMaxExponent is clamped to int, and the limit is 2^62 - 1 on Linux.
        ulong MaxExponent = (ulong)(long)Interop.Mpfr.NativeMethods.mpfr_get_emax_max().Value;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => mpfr.CheckOperandBitCount(MaxExponent - 1UL), Throws.Nothing);
        Assert.That(() => mpfr.CheckOperandBitCount(MaxExponent), Throws.TypeOf<OverflowException>().With.Message.EqualTo("The operand has too many bits for the exponent range of MPFR."));
    }

    [Test]
    public void TestHugeIntegerOperand()
    {
        // Only the 32-bit exponents of Windows have a range that an integer in memory can reach: 2^30 bits, 128 MiB.
        if (mpfr_t.MaxMaxExponent == int.MaxValue)
            return;

        const string Expected = "The operand has too many bits for the exponent range of MPFR.";

        using mpfr_t x = new(1);
        using mpfr_t Result = new();
        using mpz_t Huge = new(1);
        using mpz_t One = new(1);
        mpz.mul_2exp(Huge, Huge, (ulong)mpfr_t.MaxMaxExponent);
        using mpq_t HugeDenominator = new(One, Huge);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => mpfr.add_z(Result, x, Huge, mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));
        Assert.That(() => mpfr.z_sub(Result, Huge, x, mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));
        Assert.That(() => mpfr.mul_q(Result, x, HugeDenominator, mpfr_rnd_t.MPFR_RNDN), Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));
        Assert.That(() => x + Huge, Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));
    }
}
