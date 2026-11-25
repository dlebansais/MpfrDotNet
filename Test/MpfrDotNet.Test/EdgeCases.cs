namespace Test;

using System;
using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

// Values at the limits of each check: zero, the largest accepted value, the first rejected one.
[TestFixture]
internal class EdgeCases
{
    [Test]
    public void TestArgumentChecksOnFunctions()
    {
        using mpf_t Float = new();
        using mpf_t FloatZero = new(0.0);
        using mpq_t Rational = new();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => mpf.set_d(Float, double.NaN), Throws.TypeOf<OverflowException>().With.Message.EqualTo("NaN and infinities cannot be converted to an MPIR number."));
        Assert.That(() => mpq.set_d(Rational, double.NaN), Throws.TypeOf<OverflowException>().With.Message.EqualTo("NaN and infinities cannot be converted to an MPIR number."));
        Assert.That(() => mpf.ui_div(Float, 1UL, FloatZero), Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo("The divisor cannot be zero."));
        Assert.That(() => mpf.cmp_d(Float, double.NaN), Throws.ArgumentException.With.Message.StartsWith("NaN cannot be compared with an MPIR number."));
    }

    [Test]
    public void TestZeroIsNotNegative()
    {
        using mpz_t Result = new();
        using mpz_t Zero = new(0);
        using mpz_t Two = new(2);
        using mpz_t Four = new(4);
        using mpf_t FloatResult = new();
        using mpf_t FloatZero = new(0.0);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => mpz.sqrt(Result, Zero), Throws.Nothing);
        Assert.That(() => mpf.sqrt(FloatResult, FloatZero), Throws.Nothing);
        Assert.That(mpz.root(Result, Zero, 2UL), Is.True);

        // 2 has no inverse modulo 4, so a zero exponent must not be treated as negative.
        mpz.powm(Result, Two, Zero, Four);
        Assert.That(Result.ToString(), Is.EqualTo("1"));
    }

    [Test]
    public void TestLimitBases()
    {
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => DigitBase.ToDigitCountBase(62, "resultbase"), Throws.Nothing);
        Assert.That(() => DigitBase.ToDigitCountBase(-2, "resultbase"), Throws.Nothing);
        Assert.That(() => DigitBase.ToDigitCountBase(-36, "resultbase"), Throws.Nothing);
    }

    [Test]
    public void TestLimitPrecisions()
    {
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => mpfr.ToNativePrecision(mpfr.PrecisionMin, "precision"), Throws.Nothing);
        Assert.That(() => mpfr.ToNativePrecision(mpfr.PrecisionMax, "precision"), Throws.Nothing);
    }

    [Test]
    public void TestMissingNativeFunction()
    {
        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => Interop.Mpfr.NativeMethods.GetMpfrPointer("missing"), Throws.ArgumentException.With.Message.StartsWith("Method 'missing' not found"));
        Assert.That(() => Interop.Mpir.NativeMethods.GetMpirPointer("missing"), Throws.ArgumentException.With.Message.StartsWith("Method '__gmissing' not found"));
    }

    [Test]
    public void TestArrayLengthLimit()
    {
        const string Expected = "The length must be lesser than 32.";

        mpq_t[] Rationals = new mpq_t[32];
        mpfr_t[] Mpfrs = new mpfr_t[32];

        for (int i = 0; i < 32; i++)
        {
            Rationals[i] = new mpq_t();
            Mpfrs[i] = new mpfr_t();
        }

        using (IDisposable Scope = Assert.EnterMultipleScope())
        {
            Assert.That(() => mpz_t.CreateArray(32), Throws.ArgumentException.With.Message.StartsWith(Expected));
            Assert.That(() => mpq_t.CreateArray(32), Throws.ArgumentException.With.Message.StartsWith(Expected));
            Assert.That(() => mpfr_t.CreateArray(32), Throws.ArgumentException.With.Message.StartsWith(Expected));
            Assert.That(() => mpq_t.ClearArray(Rationals), Throws.ArgumentException);
            Assert.That(() => mpfr_t.ClearArray(Mpfrs), Throws.ArgumentException);
        }

        for (int i = 0; i < 32; i++)
        {
            Rationals[i].Dispose();
            Mpfrs[i].Dispose();
        }
    }

    [Test]
    public void TestIntegerConversionLimits()
    {
        const string Expected = "The value is outside the range of the target type.";

        using mpz_t TwoPower16 = new(65536);
        using mpz_t TwoPower32 = new(4294967296L);
        using mpz_t ShortOverflow = new(40000);
        using mpz_t LongMin = new(long.MinValue);
        using mpz_t LongMax = new(long.MaxValue);
        using mpz_t ULongMax = new(ulong.MaxValue);
        using mpz_t MinusOne = new(-1);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => (uint)TwoPower32, Throws.TypeOf<OverflowException>());
        Assert.That(() => (ushort)TwoPower16, Throws.TypeOf<OverflowException>());
        Assert.That(() => (short)ShortOverflow, Throws.TypeOf<OverflowException>());
        Assert.That((long)LongMin, Is.EqualTo(long.MinValue));
        Assert.That((long)LongMax, Is.EqualTo(long.MaxValue));
        Assert.That((ulong)ULongMax, Is.EqualTo(ulong.MaxValue));
        Assert.That(() => (ulong)MinusOne, Throws.TypeOf<OverflowException>().With.Message.EqualTo(Expected));
    }

    [Test]
    public void TestIntegerMembers()
    {
        using mpz_t Bits = new(0);
        using mpz_t One = new(1);
        using mpz_t Two = new(2);
        using mpz_t Byte = new(255);
        using mpz_t NegativeTen = mpz_t.NegativeTen;
        using mpz_t NegativeThree = mpz_t.NegativeThree;
        using mpz_t NegativeTwo = mpz_t.NegativeTwo;
        using mpz_t NegativeOne = mpz_t.NegativeOne;

        Bits.ChangeBit(3, isSet: true);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Bits.ToString(), Is.EqualTo("8"));
        Assert.That(One.GetHashCode(), Is.Not.EqualTo(Two.GetHashCode()));
        Assert.That(Byte.ToByteArray(), Has.Length.EqualTo(1));
        Assert.That(NegativeTen.ToString(), Is.EqualTo("-10"));
        Assert.That(NegativeThree.ToString(), Is.EqualTo("-3"));
        Assert.That(NegativeTwo.ToString(), Is.EqualTo("-2"));
        Assert.That(NegativeOne.ToString(), Is.EqualTo("-1"));
    }

    [Test]
    public void TestRationalMembers()
    {
        using mpq_t Half = new(1UL, 2UL);
        using mpq_t Third = new(1UL, 3UL);
        using mpq_t ThreeHalves = new(3UL, 2UL);
        using mpq_t Reduced = new();
        using mpq_t Changed = new(1UL, 2UL);
        using mpz_t Two = new(2);
        using mpq_t TwoHundred = new(200UL, 1UL);

        mpq.set_ui(Reduced, 2UL, 4UL);
        Reduced.Canonicalize();
        Changed.SetNumerator(Two);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Reduced.ToString(), Is.EqualTo("1/2"));
        Assert.That(Changed.ToString(), Is.EqualTo("1"));
        Assert.That(Half.GetHashCode(), Is.Not.EqualTo(Third.GetHashCode()));
        Assert.That(Half.GetHashCode(), Is.Not.EqualTo(ThreeHalves.GetHashCode()));

        // 200 fits in a short but not in an sbyte.
        Assert.That(() => TwoHundred.ToSByte(null), Throws.TypeOf<OverflowException>());
    }

    [Test]
    public void TestFloatMembers()
    {
        using mpf_t Three = new(3.0);
        using mpf_t MinusSevenAndHalf = new(-7.5);
        using mpf_t SevenAndHalf = new(7.5);
        using mpf_t SignedPrecise = new(5L, 256UL);
        using mpf_t UnsignedPrecise = new(5UL, 256UL);
        using mpf_t Raw = new(1.5, 256UL);
        using mpf_t LeftShifted = Three << 2;
        using mpf_t NegativeLeftShift = Three << -1;
        using mpf_t RightShifted = Three >> 1;
        using mpf_t NegativeRightShift = Three >> -2;
        using mpf_t Sum = Raw + Three;

        Raw.SetPrecisionRaw(64UL);
        ulong RawPrecision = Raw.Precision;
        Raw.SetPrecisionRaw(256UL);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That((double)LeftShifted, Is.EqualTo(12.0));
        Assert.That((double)NegativeLeftShift, Is.EqualTo(1.5));
        Assert.That((double)RightShifted, Is.EqualTo(1.5));
        Assert.That((double)NegativeRightShift, Is.EqualTo(12.0));
        Assert.That(MinusSevenAndHalf.Sign, Is.EqualTo(-1));
        Assert.That((ushort)SevenAndHalf, Is.EqualTo(7));
        Assert.That((short)MinusSevenAndHalf, Is.EqualTo(-7));
        Assert.That((long)MinusSevenAndHalf, Is.EqualTo(-7L));
        Assert.That(SignedPrecise.Precision, Is.EqualTo(256UL));
        Assert.That(UnsignedPrecise.Precision, Is.EqualTo(256UL));
        Assert.That(RawPrecision, Is.EqualTo(64UL));
        Assert.That(Sum.Precision, Is.EqualTo(256UL));
    }

    [Test]
    public void TestMpfrMembers()
    {
        using mpfr_t One = new(1);
        using mpfr_t Two = new(2);
        using mpfr_t Three = new(3);
        using mpfr_t MinusOne = new(-1);
        using mpfr_t MinusTwo = new(-2);
        using mpfr_t Copy = new();
        using mpfr_t Next = new(1);
        using mpfr_t PositiveNaN = mpfr_t.NaN(0);
        using mpfr_t Cosh = One.Cosh();
        mpfr_t.SinhCosh(One, out mpfr_t SinhFromSinhCosh, out mpfr_t CoshFromSinhCosh);

        Copy.CopyWithSignBit(Two, MinusOne);
        mpfr.nextabove(Next);
        bool IsAboveOne = Next > One;
        mpfr.nextbelow(Next);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Copy.ToString(), Is.EqualTo(MinusTwo.ToString()));
        Assert.That(IsAboveOne, Is.True);
        Assert.That(Next.ToString(), Is.EqualTo(One.ToString()));
        Assert.That(PositiveNaN.SignBit, Is.Zero);
        Assert.That(Three.IsInteger, Is.True);
        Assert.That(One.GetHashCode(), Is.Not.EqualTo(Two.GetHashCode()));
        Assert.That(One.CanRound(50, mpfr_rnd_t.MPFR_RNDN, mpfr_rnd_t.MPFR_RNDN, 20UL), Is.True);
        Assert.That(CoshFromSinhCosh.LastTernaryResult, Is.Not.Zero);
        Assert.That(CoshFromSinhCosh.LastTernaryResult, Is.EqualTo(Math.Sign(Cosh.LastTernaryResult)));

        SinhFromSinhCosh.Dispose();
        CoshFromSinhCosh.Dispose();
    }

    [Test]
    public void TestMpfrFormatting()
    {
        using mpfr_t OneAndHalf = new(1.5);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(OneAndHalf.ToFormattedString(string.Empty), Is.Empty);
        Assert.That(OneAndHalf.ToFormattedString(100UL, "%.1Rf"), Is.EqualTo("1.5"));
    }

    [Test]
    public void TestMpfrFlags()
    {
        // MPFR_FLAGS_INEXACT.
        const uint Inexact = 8;

        mpfr_t.ClearAllFlags();
        mpfr_t.SetFlags(Inexact);
        uint FlagsAfterSet = mpfr_t.TestFlags(Inexact);
        mpfr_t.ClearFlags(Inexact);
        uint FlagsAfterClear = mpfr_t.TestFlags(Inexact);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(FlagsAfterSet, Is.EqualTo(Inexact));
        Assert.That(FlagsAfterClear, Is.Zero);
    }

    [Test]
    public void TestRandomSeeds()
    {
        using randstate_t Unseeded = randstate_t.Create(RngAlgorithm.MersenneTwister);
        using randstate_t SeededUI = randstate_t.Create(RngAlgorithm.MersenneTwister);
        using randstate_t Seeded = randstate_t.Create(RngAlgorithm.MersenneTwister);
        using mpz_t Seed = new(12345);

        gmp.randseed_ui(SeededUI, 12345UL);
        gmp.randseed(Seeded, Seed);

        ulong FromUnseeded = gmp.urandomb_ui(Unseeded, 32UL);
        ulong FromSeededUI = gmp.urandomb_ui(SeededUI, 32UL);
        ulong FromSeeded = gmp.urandomb_ui(Seeded, 32UL);

        mpfr_t.GaussianRandom(Unseeded, out mpfr_t Gaussian1, out mpfr_t Gaussian2);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(FromSeededUI, Is.Not.EqualTo(FromUnseeded));
        Assert.That(FromSeeded, Is.EqualTo(FromSeededUI));
        Assert.That(Gaussian2.LastTernaryResult, Is.Not.Zero);

        Gaussian1.Dispose();
        Gaussian2.Dispose();
    }
}
