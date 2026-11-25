namespace Test;

using System;
using MpfrDotNet;
using NUnit.Framework;

[TestFixture]
public class Exception
{
    [Test]
    public void Exponent()
    {
        int MinExponentOld = mpfr_t.MinExponent;
        Assert.That(MinExponentOld, Is.EqualTo(-1073741823));

        mpfr_t.MinExponent = MinExponentOld + 1;

        int MinExponentNew = mpfr_t.MinExponent;
        Assert.That(MinExponentNew, Is.EqualTo(MinExponentOld + 1));

        int MinMinExponent = mpfr_t.MinMinExponent;
        Assert.That(MinMinExponent, Is.EqualTo(Sample.IsWindows ? -1073741823 : int.MinValue));

        int MaxMinExponent = mpfr_t.MaxMinExponent;
        Assert.That(MaxMinExponent, Is.EqualTo(Sample.IsWindows ? 1073741823 : int.MaxValue));

        int MaxExponentOld = mpfr_t.MaxExponent;
        Assert.That(MaxExponentOld, Is.EqualTo(1073741823));

        mpfr_t.MaxExponent = MaxExponentOld - 1;

        int MaxExponentNew = mpfr_t.MaxExponent;
        Assert.That(MaxExponentNew, Is.EqualTo(MaxExponentOld - 1));

        int MinMaxExponent = mpfr_t.MinMaxExponent;
        Assert.That(MinMaxExponent, Is.EqualTo(Sample.IsWindows ? -1073741823 : int.MinValue));

        int MaxMaxExponent = mpfr_t.MaxMaxExponent;
        Assert.That(MaxMaxExponent, Is.EqualTo(Sample.IsWindows ? 1073741823 : int.MaxValue));

        // The exponent range is per thread: the next tests expect the default one.
        mpfr_t.MinExponent = MinExponentOld;
        mpfr_t.MaxExponent = MaxExponentOld;
    }

    [Test]
    public void CheckRange()
    {
        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        string AsString;
        int RangeCheckResult;

        using mpfr_t a = new("11");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("1.1E+1"));

        using mpfr_t b = a.Log10();
        RangeCheckResult = b.CheckRange();

        Assert.That(RangeCheckResult, Is.EqualTo(1));

        using mpfr_t c = new("10");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("1E+1"));

        using mpfr_t d = c.Log10();
        RangeCheckResult = d.CheckRange();

        Assert.That(RangeCheckResult, Is.Zero);

        using mpfr_t e = new("9");
        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("9E+0"));

        using mpfr_t f = e.Log10();
        RangeCheckResult = f.CheckRange();

        Assert.That(RangeCheckResult, Is.EqualTo(-1));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Subnormalize()
    {
        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        string AsString;
        int SubnormalizeResult;

        using mpfr_t a = new("10");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("1E+1"));

        using mpfr_t b = a.Log10();
        SubnormalizeResult = b.Subnormalize();

        Assert.That(SubnormalizeResult, Is.Zero);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Flags()
    {
        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        mpfr_t.ClearAllFlags();

        using mpfr_t x = new("1");
        using mpfr_t y = x + x;

        bool Underflow = mpfr_t.Underflow;
        bool Overflow = mpfr_t.Overflow;
        bool DivideByZero = mpfr_t.DivideByZero;
        bool NaNFlag = mpfr_t.NaNFlag;
        bool Inexact = mpfr_t.Inexact;
        bool ERange = mpfr_t.ERange;

        using IDisposable Scope = Assert.EnterMultipleScope();
        Assert.That(Underflow, Is.False);
        Assert.That(Overflow, Is.False);
        Assert.That(DivideByZero, Is.False);
        Assert.That(NaNFlag, Is.False);
        Assert.That(Inexact, Is.False);
        Assert.That(ERange, Is.False);

        mpfr_t.Underflow = !Underflow;
        mpfr_t.Overflow = !Overflow;
        mpfr_t.DivideByZero = !DivideByZero;
        mpfr_t.NaNFlag = !NaNFlag;
        mpfr_t.Inexact = !Inexact;
        mpfr_t.ERange = !ERange;

        Assert.That(mpfr_t.Underflow, Is.True);
        Assert.That(mpfr_t.Overflow, Is.True);
        Assert.That(mpfr_t.DivideByZero, Is.True);
        Assert.That(mpfr_t.NaNFlag, Is.True);
        Assert.That(mpfr_t.Inexact, Is.True);
        Assert.That(mpfr_t.ERange, Is.True);

        mpfr_t.ClearFlags(0);

        Assert.That(mpfr_t.Underflow, Is.True);
        Assert.That(mpfr_t.Overflow, Is.True);
        Assert.That(mpfr_t.DivideByZero, Is.True);
        Assert.That(mpfr_t.NaNFlag, Is.True);
        Assert.That(mpfr_t.Inexact, Is.True);
        Assert.That(mpfr_t.ERange, Is.True);

        uint Flags = mpfr_t.GetAllFlags();
        mpfr_t.SetFlags(Flags);

        Assert.That(mpfr_t.GetAllFlags(), Is.EqualTo(Flags));
        Assert.That(mpfr_t.TestFlags(Flags), Is.EqualTo(Flags));

        mpfr_t.SetFlags(0xFFFF, Flags);

        Assert.That(mpfr_t.Underflow, Is.True);
        Assert.That(mpfr_t.Overflow, Is.True);
        Assert.That(mpfr_t.DivideByZero, Is.True);
        Assert.That(mpfr_t.NaNFlag, Is.True);
        Assert.That(mpfr_t.Inexact, Is.True);
        Assert.That(mpfr_t.ERange, Is.True);

        mpfr_t.Underflow = false;
        mpfr_t.Overflow = false;
        mpfr_t.DivideByZero = false;
        mpfr_t.NaNFlag = false;
        mpfr_t.Inexact = false;
        mpfr_t.ERange = false;

        Assert.That(mpfr_t.Underflow, Is.False);
        Assert.That(mpfr_t.Overflow, Is.False);
        Assert.That(mpfr_t.DivideByZero, Is.False);
        Assert.That(mpfr_t.NaNFlag, Is.False);
        Assert.That(mpfr_t.Inexact, Is.False);
        Assert.That(mpfr_t.ERange, Is.False);

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }
}
