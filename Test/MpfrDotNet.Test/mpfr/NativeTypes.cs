namespace Test;

using System;
using System.Runtime.InteropServices;
using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;
using static Interop.Mpfr.NativeMethods;

[TestFixture]
internal class NativeTypes
{
    [Test]
    public void TestStructLayout()
    {
        using mpfr_t x = mpfr_t.Create(precision: 100);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Marshal.SizeOf<__mpfr_t>(), Is.EqualTo(24));
        Assert.That(x.Value.Precision, Is.EqualTo(100));
    }

    [Test]
    public void TestRemainderNegativeQuotient()
    {
        using mpfr_t x = new(-7);
        using mpfr_t y = new(2);

        using mpfr_t r = mpfr_t.Remainder(x, y, out long q);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(q, Is.EqualTo(-4L));
        Assert.That((int)r, Is.EqualTo(1));
    }

    [Test]
    public void TestFModNegativeQuotient()
    {
        using mpfr_t x = new(-7);
        using mpfr_t y = new(2);

        using mpfr_t r = mpfr_t.FMod(x, y, out long q);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(q, Is.EqualTo(-3L));
        Assert.That((int)r, Is.EqualTo(-1));
    }

    [Test]
    public void TestMpfNegativeExponent()
    {
        using mpf_t x = new(0.25);

        x.GetDoubleWithExponent(out double d, out long exp);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(d, Is.EqualTo(0.5));
        Assert.That(exp, Is.EqualTo(-1L));
    }

    [Test]
    public void TestMul2BeyondNativeRange()
    {
        using mpfr_t x = new(1.5);

        using mpfr_t UnsignedOverflow = x.Mul2(4294967296UL);
        using mpfr_t SignedOverflow = x.Mul2(4294967296L);
        using mpfr_t Underflow = x.Mul2(-4294967295L);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(UnsignedOverflow.IsInf, Is.True);
        Assert.That(SignedOverflow.IsInf, Is.True);
        Assert.That(Underflow.IsZero, Is.True);
    }

    [Test]
    public void TestExponentBeyondNativeRange()
    {
        using mpfr_t Overflow = new(1L, 1L << 32);
        using mpfr_t Underflow = new(1L, -(1L << 32));

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Overflow.IsInf, Is.True);
        Assert.That(Underflow.IsZero, Is.True);
    }

    [TestCase(0UL)]
    [TestCase((1UL << 32) + 53)]
    public void TestPrecisionOutOfRange(ulong precision)
    {
        using mpfr_t x = new();
        string Expected = $"The precision must be between {mpfr.PrecisionMin} and {mpfr.PrecisionMax}.";

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => x.Precision = precision, Throws.InstanceOf<ArgumentOutOfRangeException>().With.Message.StartsWith(Expected));
        Assert.That(() => mpfr_t.DefaultPrecision = precision, Throws.InstanceOf<ArgumentOutOfRangeException>().With.Message.StartsWith(Expected));
        Assert.That(() => mpfr_t.CreateArray(2, precision), Throws.InstanceOf<ArgumentOutOfRangeException>().With.Message.StartsWith(Expected));
        Assert.That(() => x.RoundWithPrecision(precision, mpfr_rnd_t.MPFR_RNDN), Throws.InstanceOf<ArgumentOutOfRangeException>().With.Message.StartsWith(Expected));
    }

    [Test]
    public void TestFormattedStringLongerThanDigitCount()
    {
        string ExpectedExponent = $"1.{new string('0', 200)}e+00";
        string ExpectedFixed = $"1.{new string('0', 300)}";

        using mpfr_t x = new(1);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(x.ToFormattedString("%.200Re"), Is.EqualTo(ExpectedExponent));
        Assert.That(x.ToFormattedString("%.300Rf"), Is.EqualTo(ExpectedFixed));
        Assert.That(x.ToFormattedString(5, "%.200Re"), Is.EqualTo("1.00"));
        Assert.That(x.ToFormattedString(0, "%.200Re"), Is.Empty);
    }

    [Test]
    public void TestFormattedStringNullFormat()
    {
        string NullFormat = Sample.CreateNull<string>();

        using mpfr_t x = new(1);

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(() => x.ToFormattedString(NullFormat), Throws.ArgumentNullException);
        Assert.That(() => x.ToFormattedString(10, NullFormat), Throws.ArgumentNullException);
    }
}
