namespace Test;

using System;
using System.Runtime.InteropServices;
using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

[TestFixture]
internal class Overloads
{
    [Test]
    public void TestRationalZeroUnsignedDenominator()
    {
        Assert.That(() => new mpq_t(1UL, 0UL), Throws.TypeOf<DivideByZeroException>().With.Message.EqualTo("The denominator cannot be zero."));
    }

#pragma warning disable CS0618 // Type or member is obsolete: the obsolete overloads must keep working.
    [Test]
    public void TestRationalObsoleteConstructors()
    {
        using mpz_t Numerator = new(2);
        using mpz_t Denominator = new(4);
        using mpq_t FromUnsigned = new(2UL, 4UL, canonicalize: false);
        using mpq_t FromSigned = new(-2L, 4UL, canonicalize: false);
        using mpq_t FromIntegers = new(Numerator, Denominator, canonicalize: false);
        using mpq_t FromText = new("2/4", canonicalize: false);
        using mpq_t FromTextWithBase = new("10/100", 2, canonicalize: false);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(FromUnsigned.ToString(), Is.EqualTo("1/2"));
        Assert.That(FromSigned.ToString(), Is.EqualTo("-1/2"));
        Assert.That(FromIntegers.ToString(), Is.EqualTo("1/2"));
        Assert.That(FromText.ToString(), Is.EqualTo("1/2"));
        Assert.That(FromTextWithBase.ToString(), Is.EqualTo("1/2"));
    }
#pragma warning restore CS0618 // Type or member is obsolete

    [Test]
    public void TestRationalIsEqualTo()
    {
        using mpq_t Half = new(1UL, 2UL);
        using mpq_t OtherHalf = new(2UL, 4UL);
        using mpq_t Third = new(1UL, 3UL);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Half.IsEqualTo(OtherHalf), Is.True);
        Assert.That(Half.IsEqualTo(Third), Is.False);
    }

    [Test]
    public void TestCompareToObjectOfDifferentType()
    {
        const string Expected = "Invalid comparison with an object of a different type.";
        const string Text = "text";

        using mpz_t Integer = new(1);
        using mpq_t Rational = new(1UL, 2UL);
        using mpf_t Floating = new(1.0);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => Integer.CompareTo(Text), Throws.ArgumentException.With.Message.StartsWith(Expected));
        Assert.That(() => Rational.CompareTo(Text), Throws.ArgumentException.With.Message.StartsWith(Expected));
        Assert.That(() => Floating.CompareTo(Text), Throws.ArgumentException.With.Message.StartsWith(Expected));
    }

    [Test]
    public void TestIntegerByteConversions()
    {
        using mpz_t Positive = new(200);
        using mpz_t Negative = new(-100);
        IConvertible ConvertiblePositive = Positive;
        IConvertible ConvertibleNegative = Negative;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Positive.ToByte(null), Is.EqualTo((byte)200));
        Assert.That(ConvertiblePositive.ToByte(null), Is.EqualTo((byte)200));
        Assert.That(Negative.ToSByte(null), Is.EqualTo((sbyte)-100));
        Assert.That(ConvertibleNegative.ToSByte(null), Is.EqualTo((sbyte)-100));
    }

    [Test]
    public void TestFloatingByteConversions()
    {
        using mpf_t Positive = new(200.7);
        using mpf_t Negative = new(-100.7);
        IConvertible ConvertiblePositive = Positive;
        IConvertible ConvertibleNegative = Negative;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Positive.ToByte(null), Is.EqualTo((byte)200));
        Assert.That(ConvertiblePositive.ToByte(null), Is.EqualTo((byte)200));
        Assert.That(Negative.ToSByte(null), Is.EqualTo((sbyte)-100));
        Assert.That(ConvertibleNegative.ToSByte(null), Is.EqualTo((sbyte)-100));
    }

    [Test]
    public void TestIntegerSetAndMod()
    {
        using mpz_t Source = new(-7);
        using mpz_t Divisor = new(3);
        using mpz_t Copy = new();
        using mpz_t Remainder = new();

        mpz.set(Copy, Source);
        mpz.mod(Remainder, Source, Divisor);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Copy.ToString(), Is.EqualTo("-7"));
        Assert.That(Remainder.ToString(), Is.EqualTo("2"));
    }

    [Test]
    public void TestFloatingGetIntegers()
    {
        using mpf_t Positive = new(3.7);
        using mpf_t Negative = new(-3.7);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(mpf.get_ui(Positive), Is.EqualTo(3UL));
        Assert.That(mpf.get_si(Negative), Is.EqualTo(-3L));
    }

    [Test]
    public void TestMpfrGetIntegers()
    {
        using mpfr_t Positive = new(3.7);
        using mpfr_t Negative = new(-3.7);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(mpfr.get_ui(Positive, mpfr_rnd_t.MPFR_RNDN), Is.EqualTo(4UL));
        Assert.That(mpfr.get_si(Negative, mpfr_rnd_t.MPFR_RNDZ), Is.EqualTo(-3L));
    }

    [Test]
    public void TestRationalDividedByTinyMpfrOverflows()
    {
        // y = 2^(emin - 1), so x / y = 2^(2 - emin), which is above the largest exponent.
        using mpq_t x = new(2UL, 1UL);
        using mpfr_t y = new(1.0);
        _ = mpfr.set_exp(y, mpfr.get_emin());

        using mpfr_t z = x / y;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(mpfr.inf_p(z), Is.True);
        Assert.That(z.LastTernaryResult, Is.Positive);
    }

    [Test]
    public void TestMpfrGetIntmax()
    {
        // 2^62 does not fit in 32 bits, the size of a C long on Windows.
        const double TwoToThe62 = 4611686018427387904.0;

        using mpfr_t Positive = new(3.7);
        using mpfr_t Negative = new(-3.7);
        using mpfr_t Large = new(TwoToThe62);
        using mpfr_t LargeNegative = new(-TwoToThe62);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(mpfr.get_sj(Negative, mpfr_rnd_t.MPFR_RNDZ), Is.EqualTo(-3L));
        Assert.That(mpfr.get_uj(Positive, mpfr_rnd_t.MPFR_RNDN), Is.EqualTo(4UL));
        Assert.That(mpfr.get_sj(LargeNegative, mpfr_rnd_t.MPFR_RNDN), Is.EqualTo(-4611686018427387904L));
        Assert.That(mpfr.get_uj(Large, mpfr_rnd_t.MPFR_RNDN), Is.EqualTo(4611686018427387904UL));
    }

    [Test]
    public void TestCULongValue()
    {
        // On net481, this is the library's polyfill; on .NET 6 and later, the runtime type.
        CULong Value = new(5U);

        Assert.That((ulong)Value.Value, Is.EqualTo(5UL));
    }

    [Test]
    public void TestFormattedStringTooLong()
    {
        // The output would be longer than int.MaxValue characters, so MPFR returns an error instead of a length.
        const string Format = "x%2147483647Rf";

        using mpfr_t Number = new(1.0);

        Assert.That(() => Number.ToFormattedString(Format), Throws.TypeOf<FormatException>().With.Message.EqualTo($"The number cannot be formatted with '{Format}'."));
    }

    [Test]
    public void TestMpfrInitsAndClears()
    {
        ulong CustomPrecision = mpfr.get_default_prec() + 64;

        using mpfr_t a = new(1.0);
        using mpfr_t b = new(2.0);

        // Each value is cleared before it is initialized again, so that no memory is leaked and Dispose stays valid.
        mpfr.clears(a, b);
        mpfr.inits2(CustomPrecision, a, b);
        ulong PrecisionA = mpfr.get_prec(a);
        ulong PrecisionB = mpfr.get_prec(b);
        mpfr.clears(a, b);
        mpfr.inits(a, b);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(PrecisionA, Is.EqualTo(CustomPrecision));
        Assert.That(PrecisionB, Is.EqualTo(CustomPrecision));
        Assert.That(mpfr.get_prec(a), Is.EqualTo(mpfr.get_default_prec()));
        Assert.That(mpfr.nan_p(b), Is.True);
    }

    [Test]
    public void TestMpfrInitsArguments()
    {
        const string NullItemMessage = "The array cannot contain a null item.";

        using mpfr_t a = new(1.0);
        mpfr_t[] NullArray = Sample.CreateNull<mpfr_t[]>();
        mpfr_t[] WithNullItem = [a, Sample.CreateNull<mpfr_t>()];

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => mpfr.inits(NullArray), Throws.ArgumentNullException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("x"));
        Assert.That(() => mpfr.inits2(mpfr.get_default_prec(), NullArray), Throws.ArgumentNullException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("x"));
        Assert.That(() => mpfr.clears(NullArray), Throws.ArgumentNullException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("x"));
        Assert.That(() => mpfr.inits(WithNullItem), Throws.ArgumentException.With.Message.StartsWith(NullItemMessage));
        Assert.That(() => mpfr.inits2(mpfr.get_default_prec(), WithNullItem), Throws.ArgumentException.With.Message.StartsWith(NullItemMessage));
        Assert.That(() => mpfr.clears(WithNullItem), Throws.ArgumentException.With.Message.StartsWith(NullItemMessage));
        Assert.That(() => mpfr.inits2(0, a), Throws.TypeOf<ArgumentOutOfRangeException>());

        // The arrays are checked before any item is changed.
        Assert.That(mpfr.get_d(a, mpfr_rnd_t.MPFR_RNDN), Is.EqualTo(1.0));
    }

    [Test]
    public void TestMpirInitsAndClears()
    {
        using mpz_t IntegerA = new(5);
        using mpz_t IntegerB = new(6);
        using mpq_t RationalA = new(1UL, 2UL);
        using mpq_t RationalB = new(1UL, 3UL);
        using mpf_t FloatingA = new(1.5);
        using mpf_t FloatingB = new(2.5);

        // Each value is cleared before it is initialized again, so that no memory is leaked and Dispose stays valid.
        mpz.clears(IntegerA, IntegerB);
        mpz.inits(IntegerA, IntegerB);
        mpq.clears(RationalA, RationalB);
        mpq.inits(RationalA, RationalB);
        mpf.clears(FloatingA, FloatingB);
        mpf.inits(FloatingA, FloatingB);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(IntegerA.ToString(), Is.EqualTo("0"));
        Assert.That(IntegerB.ToString(), Is.EqualTo("0"));
        Assert.That(RationalA.ToString(), Is.EqualTo("0"));
        Assert.That(RationalB.ToString(), Is.EqualTo("0"));
        Assert.That(mpf.sgn(FloatingA), Is.Zero);
        Assert.That(mpf.sgn(FloatingB), Is.Zero);
        Assert.That(mpf.get_prec(FloatingA), Is.GreaterThanOrEqualTo(mpf.get_default_prec()));
    }

    [Test]
    public void TestMpirInitsArguments()
    {
        const string NullItemMessage = "The array cannot contain a null item.";

        mpz_t[] NullIntegers = Sample.CreateNull<mpz_t[]>();
        mpq_t[] NullRationals = Sample.CreateNull<mpq_t[]>();
        mpf_t[] NullFloatings = Sample.CreateNull<mpf_t[]>();
        mpz_t[] IntegersWithNull = [Sample.CreateNull<mpz_t>()];
        mpq_t[] RationalsWithNull = [Sample.CreateNull<mpq_t>()];
        mpf_t[] FloatingsWithNull = [Sample.CreateNull<mpf_t>()];

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => mpz.inits(NullIntegers), Throws.ArgumentNullException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("integers"));
        Assert.That(() => mpz.clears(NullIntegers), Throws.ArgumentNullException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("x"));
        Assert.That(() => mpq.inits(NullRationals), Throws.ArgumentNullException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("rationals"));
        Assert.That(() => mpq.clears(NullRationals), Throws.ArgumentNullException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("rationals"));
        Assert.That(() => mpf.inits(NullFloatings), Throws.ArgumentNullException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("floatings"));
        Assert.That(() => mpf.clears(NullFloatings), Throws.ArgumentNullException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("floatings"));
        Assert.That(() => mpz.inits(IntegersWithNull), Throws.ArgumentException.With.Message.StartsWith(NullItemMessage));
        Assert.That(() => mpz.clears(IntegersWithNull), Throws.ArgumentException.With.Message.StartsWith(NullItemMessage));
        Assert.That(() => mpq.inits(RationalsWithNull), Throws.ArgumentException.With.Message.StartsWith(NullItemMessage));
        Assert.That(() => mpq.clears(RationalsWithNull), Throws.ArgumentException.With.Message.StartsWith(NullItemMessage));
        Assert.That(() => mpf.inits(FloatingsWithNull), Throws.ArgumentException.With.Message.StartsWith(NullItemMessage));
        Assert.That(() => mpf.clears(FloatingsWithNull), Throws.ArgumentException.With.Message.StartsWith(NullItemMessage));
    }

    [Test]
    public void TestReadPrecisionLimit()
    {
        const ulong Fallback = 42UL;

        // mpfr_get_default_prec has the same signature as mpfr_get_prec_min and mpfr_get_prec_max, and exists on every platform.
        IntPtr DefaultPrecisionAddress = Interop.Mpfr.NativeMethods.GetMpfrPointer("mpfr_get_default_prec");

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Interop.Mpfr.NativeMethods.ReadPrecisionLimit(IntPtr.Zero, Fallback), Is.EqualTo(Fallback));
        Assert.That(Interop.Mpfr.NativeMethods.ReadPrecisionLimit(DefaultPrecisionAddress, Fallback), Is.EqualTo(mpfr.get_default_prec()));
    }

#if NETFRAMEWORK
    [Test]
    public void TestOldFrameworkRequiresWindows()
    {
        // A separate application domain has its own copy of the library, so this domain is not affected.
        AppDomain Domain = AppDomain.CreateDomain(nameof(NonWindowsLoader), null, AppDomain.CurrentDomain.SetupInformation);

        try
        {
            NonWindowsLoader Loader = (NonWindowsLoader)Domain.CreateInstanceAndUnwrap(typeof(NonWindowsLoader).Assembly.FullName, typeof(NonWindowsLoader).FullName);
            string Message = Loader.LoadAsNonWindows();

            Assert.That(Message, Is.EqualTo("Platforms other than Windows require .NET 6 or later."));
        }
        finally
        {
            AppDomain.Unload(Domain);
        }
    }
#endif
}
