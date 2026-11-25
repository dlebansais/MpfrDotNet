namespace Test;

using System;
using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

// Arguments that would make MPIR, GMP or MPFR abort, crash or corrupt memory must throw before the native call.
[TestFixture]
internal class NativeErrorChecks
{
    [Test]
    public void TestExponentOfSingularValues()
    {
        const string Expected = "Zero, NaN and infinities have no exponent.";

        using mpfr_t Zero = mpfr_t.Zero();
        using mpfr_t NaN = mpfr_t.NaN();
        using mpfr_t Infinity = mpfr_t.Infinite();
        using mpfr_t One = new(1);
        using mpfr_t Four = new(4);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => Zero.Exponent, Throws.InvalidOperationException.With.Message.EqualTo(Expected));
        Assert.That(() => NaN.Exponent, Throws.InvalidOperationException.With.Message.EqualTo(Expected));
        Assert.That(() => Infinity.Exponent, Throws.InvalidOperationException.With.Message.EqualTo(Expected));
        Assert.That(() => Zero.Exponent = 5, Throws.InvalidOperationException.With.Message.EqualTo(Expected));
        Assert.That(() => One.Exponent = int.MaxValue, Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith("The exponent is outside the current exponent range."));
        Assert.That(One.Exponent, Is.EqualTo(1));

        One.Exponent = 3;
        Assert.That(One.ToString(), Is.EqualTo(Four.ToString()));
    }

    [Test]
    public void TestMpfrSetPrecisionRawAboveAllocation()
    {
        using mpfr_t x = mpfr_t.Create(53);
        ulong AllocatedPrecision = mpfr.GetAllocatedPrecision(x);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(AllocatedPrecision, Is.EqualTo(64UL));
        Assert.That(() => x.SetPrecisionRaw(AllocatedPrecision + 1), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith("The precision cannot be greater than the allocated precision."));
        Assert.That(x.Precision, Is.EqualTo(53UL));

        x.SetPrecisionRaw(AllocatedPrecision);
        Assert.That(x.Precision, Is.EqualTo(AllocatedPrecision));
        x.SetPrecisionRaw(53);
    }

    [Test]
    public void TestMpfSetPrecisionRawAboveAllocation()
    {
        const string Expected = "The precision cannot be greater than the allocated precision.";

        using mpf_t Small = new(1.5, 64UL);
        using mpf_t Large = new(2.5, 4096UL);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => Small.SetPrecisionRaw(4096UL), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith(Expected));
        Assert.That(Small.Precision, Is.EqualTo(64UL));

        // A swap exchanges the allocations too.
        mpf.swap(Small, Large);
        Assert.That(() => Small.SetPrecisionRaw(4096UL), Throws.Nothing);
        Assert.That(() => Large.SetPrecisionRaw(4096UL), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith(Expected));

        // Changing the precision changes the allocation.
        Large.Precision = 4096UL;
        Assert.That(() => Large.SetPrecisionRaw(4096UL), Throws.Nothing);
    }

    [Test]
    public void TestNullStrings()
    {
        string NullText = Sample.CreateNull<string>();

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => new mpz_t(NullText), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("text"));
        Assert.That(() => new mpq_t(NullText), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("text"));
        Assert.That(() => new mpf_t(NullText), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("s"));
        Assert.That(() => new mpfr_t(NullText), Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("str"));
    }

    [Test]
    public void TestMpfrStringBase()
    {
        const string Expected = "The base must be 0 or between 2 and 62.";

        using mpfr_t AutomaticBase = new("0x10", 0);
        using mpfr_t Base62 = new("z", 62);
        using mpfr_t Sixteen = new(16);
        using mpfr_t SixtyOne = new(61);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => new mpfr_t("1", 1), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith(Expected));
        Assert.That(() => new mpfr_t("1", 63), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith(Expected));
        Assert.That(AutomaticBase.ToString(), Is.EqualTo(Sixteen.ToString()));
        Assert.That(Base62.ToString(), Is.EqualTo(SixtyOne.ToString()));
    }

    [TestCase("%Rf %Rf")]
    [TestCase("%n%Rg")]
    [TestCase("%s")]
    [TestCase("%d")]
    [TestCase("%.*Rf")]
    [TestCase("%*Rf")]
    [TestCase("%R*f")]
    [TestCase("%Rn")]
    [TestCase("%")]
    [TestCase("%R")]
    [TestCase("%1.")]
    public void TestInvalidFormat(string format)
    {
        using mpfr_t x = new(1.5);

        Assert.That(() => x.ToFormattedString(format), Throws.TypeOf<FormatException>().With.Message.EqualTo($"The format '{format}' must have at most one conversion, for an mpfr_t such as %Rf."));
    }

    [TestCase("%Rf", "1.500000")]
    [TestCase("x = %+.2RNe %%", "x = +1.50e+00 %")]
    [TestCase("%-6.1RDf|", "1.5   |")]
    [TestCase("100%%", "100%")]
    public void TestValidFormat(string format, string expected)
    {
        using mpfr_t x = new(1.5);

        Assert.That(x.ToFormattedString(format), Is.EqualTo(expected));
    }

    [Test]
    public void TestLinearCongruentialZeroExponent()
    {
        using mpz_t a = new(10);

        Assert.That(() => randstate_t.Create(RngAlgorithm.LinearCongruential, a, 1UL, 0UL), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.StartsWith("The modulus exponent must be greater than zero.").And.Property(nameof(ArgumentOutOfRangeException.ParamName)).EqualTo("m2exp"));
    }

    [TestCase(12, 1, 0UL, "12")]
    [TestCase(12, -1, 0UL, "12")]
    [TestCase(12, -2, 2UL, "3")]
    [TestCase(-8, -2, 3UL, "1")]
    [TestCase(24, -2, 3UL, "-3")]
    [TestCase(0, -3, 0UL, "0")]
    [TestCase(24, 2, 3UL, "3")]
    public void TestRemoveFactor(long op, long f, ulong expectedCount, string expectedResult)
    {
        using mpz_t Result = new();
        using mpz_t Op = new(op);
        using mpz_t Factor = new(f);

        ulong Count = mpz.remove(Result, Op, Factor);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Count, Is.EqualTo(expectedCount));
        Assert.That(Result.ToString(), Is.EqualTo(expectedResult));
    }

    [Test]
    public void TestZeroBoundsAndDenominators()
    {
        using randstate_t State = new();
        using mpz_t Result = new();
        using mpz_t Zero = new(0);
        using mpq_t Half = new(1UL, 2UL);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => mpz.urandomm(Result, State, Zero), Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo("The divisor cannot be zero."));
        Assert.That(() => gmp.urandomm_ui(State, 0UL), Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo("The divisor cannot be zero."));
        Assert.That(() => mpq.cmp_ui(Half, 1UL, 0UL), Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo("The denominator cannot be zero."));
        Assert.That(() => mpq.cmp_si(Half, 1L, 0UL), Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo("The denominator cannot be zero."));
        Assert.That(mpq.cmp_ui(Half, 1UL, 3UL), Is.Positive);
        Assert.That(mpq.cmp_si(Half, -1L, 3UL), Is.Positive);
    }

    [Test]
    public void TestClearThenDispose()
    {
        mpz_t Integer = new(5);
        mpq_t Rational = new(1UL, 2UL);
        mpf_t Float = new(1.5);
        mpfr_t Mpfr = new(1.5);
        mpz_t ReusedInteger = new(5);

        mpz.clear(Integer);
        mpq.clear(Rational);
        mpf.clear(Float);
        mpfr.clear(Mpfr);

        // A cleared number can be initialized again, as in C.
        mpz.clear(ReusedInteger);
        mpz.init(ReusedInteger);
        mpz.set_si(ReusedInteger, 7);
        string Reused = ReusedInteger.ToString();

        using (IDisposable Scope = Assert.EnterMultipleScope())
        {
            Assert.That(Reused, Is.EqualTo("7"));
            Assert.That(Integer.Dispose, Throws.Nothing);
            Assert.That(Rational.Dispose, Throws.Nothing);
            Assert.That(Float.Dispose, Throws.Nothing);
            Assert.That(Mpfr.Dispose, Throws.Nothing);
            Assert.That(ReusedInteger.Dispose, Throws.Nothing);
        }

        // Cleared numbers that are not disposed must not be freed again by their finalizer.
        ClearWithoutDispose();

        Assert.That(() =>
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }, Throws.Nothing);
    }

    private static void ClearWithoutDispose()
    {
        mpz_t Integer = new(5);
        mpq_t Rational = new(1UL, 2UL);
        mpf_t Float = new(1.5);
        mpfr_t Mpfr = new(1.5);

        mpz.clear(Integer);
        mpq.clear(Rational);
        mpf.clear(Float);
        mpfr.clear(Mpfr);
    }

    [TestCase(1UL, 1)]
    [TestCase(1UL, -1)]
    [TestCase(2UL, -1)]
    public void TestSingularValuesAtLowPrecision(ulong precision, int sign)
    {
        using mpfr_t Infinity = mpfr_t.Create(precision);
        using mpfr_t NaN = mpfr_t.Create(precision);
        mpfr.set_inf(Infinity, sign);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Infinity.ToString(), Is.EqualTo(sign > 0 ? "@Inf@" : "-@Inf@"));
        Assert.That(Infinity.ToString(2, mpfr_rnd_t.MPFR_RNDN), Is.EqualTo(sign > 0 ? "@Inf@" : "-@Inf@"));
        Assert.That(NaN.ToString(), Is.EqualTo("@NaN@"));
    }
}
