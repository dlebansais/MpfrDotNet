namespace Test;

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
        Assert.That(MinMinExponent, Is.EqualTo(-1073741823));

        int MaxMinExponent = mpfr_t.MaxMinExponent;
        Assert.That(MaxMinExponent, Is.EqualTo(1073741823));

        int MaxExponentOld = mpfr_t.MaxExponent;
        Assert.That(MaxExponentOld, Is.EqualTo(1073741823));

        mpfr_t.MaxExponent = MaxExponentOld - 1;

        int MaxExponentNew = mpfr_t.MaxExponent;
        Assert.That(MaxExponentNew, Is.EqualTo(MaxExponentOld - 1));

        int MinMaxExponent = mpfr_t.MinMaxExponent;
        Assert.That(MinMaxExponent, Is.EqualTo(-1073741823));

        int MaxMaxExponent = mpfr_t.MaxMaxExponent;
        Assert.That(MaxMaxExponent, Is.EqualTo(1073741823));
    }

    [Test]
    public void CheckRange()
    {
        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        string AsString;
        int RangeCheckResult;

        using mpfr_t a = new mpfr_t("11");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("1.1E+1"));

        using mpfr_t b = a.Log10();
        RangeCheckResult = b.CheckRange();

        Assert.That(RangeCheckResult, Is.EqualTo(1));

        using mpfr_t c = new mpfr_t("10");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("1E+1"));

        using mpfr_t d = c.Log10();
        RangeCheckResult = d.CheckRange();

        Assert.That(RangeCheckResult, Is.EqualTo(0));

        using mpfr_t e = new mpfr_t("9");
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

        using mpfr_t a = new mpfr_t("10");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("1E+1"));

        using mpfr_t b = a.Log10();
        SubnormalizeResult = b.Subnormalize();

        Assert.That(SubnormalizeResult, Is.EqualTo(0));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Flags()
    {
        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        mpfr_t.ClearAllFlags();

        using mpfr_t x = new mpfr_t("1");
        using mpfr_t y = x + x;

        bool Underflow = mpfr_t.Underflow;
        bool Overflow = mpfr_t.Overflow;
        bool DivideByZero = mpfr_t.DivideByZero;
        bool NaNFlag = mpfr_t.NaNFlag;
        bool Inexact = mpfr_t.Inexact;
        bool ERange = mpfr_t.ERange;

        Assert.That(Underflow, Is.EqualTo(false));
        Assert.That(Overflow, Is.EqualTo(false));
        Assert.That(DivideByZero, Is.EqualTo(false));
        Assert.That(NaNFlag, Is.EqualTo(false));
        Assert.That(Inexact, Is.EqualTo(false));
        Assert.That(ERange, Is.EqualTo(false));

        mpfr_t.Underflow = !Underflow;
        mpfr_t.Overflow = !Overflow;
        mpfr_t.DivideByZero = !DivideByZero;
        mpfr_t.NaNFlag = !NaNFlag;
        mpfr_t.Inexact = !Inexact;
        mpfr_t.ERange = !ERange;

        Assert.That(mpfr_t.Underflow, Is.EqualTo(true));
        Assert.That(mpfr_t.Overflow, Is.EqualTo(true));
        Assert.That(mpfr_t.DivideByZero, Is.EqualTo(true));
        Assert.That(mpfr_t.NaNFlag, Is.EqualTo(true));
        Assert.That(mpfr_t.Inexact, Is.EqualTo(true));
        Assert.That(mpfr_t.ERange, Is.EqualTo(true));

        mpfr_t.ClearFlags(0);

        Assert.That(mpfr_t.Underflow, Is.EqualTo(true));
        Assert.That(mpfr_t.Overflow, Is.EqualTo(true));
        Assert.That(mpfr_t.DivideByZero, Is.EqualTo(true));
        Assert.That(mpfr_t.NaNFlag, Is.EqualTo(true));
        Assert.That(mpfr_t.Inexact, Is.EqualTo(true));
        Assert.That(mpfr_t.ERange, Is.EqualTo(true));

        uint Flags = mpfr_t.GetAllFlags();
        mpfr_t.SetFlags(Flags);

        Assert.That(mpfr_t.GetAllFlags(), Is.EqualTo(Flags));
        Assert.That(mpfr_t.TestFlags(Flags), Is.EqualTo(Flags));

        mpfr_t.SetFlags(0xFFFF, Flags);

        Assert.That(mpfr_t.Underflow, Is.EqualTo(true));
        Assert.That(mpfr_t.Overflow, Is.EqualTo(true));
        Assert.That(mpfr_t.DivideByZero, Is.EqualTo(true));
        Assert.That(mpfr_t.NaNFlag, Is.EqualTo(true));
        Assert.That(mpfr_t.Inexact, Is.EqualTo(true));
        Assert.That(mpfr_t.ERange, Is.EqualTo(true));

        mpfr_t.Underflow = false;
        mpfr_t.Overflow = false;
        mpfr_t.DivideByZero = false;
        mpfr_t.NaNFlag = false;
        mpfr_t.Inexact = false;
        mpfr_t.ERange = false;

        Assert.That(mpfr_t.Underflow, Is.EqualTo(false));
        Assert.That(mpfr_t.Overflow, Is.EqualTo(false));
        Assert.That(mpfr_t.DivideByZero, Is.EqualTo(false));
        Assert.That(mpfr_t.NaNFlag, Is.EqualTo(false));
        Assert.That(mpfr_t.Inexact, Is.EqualTo(false));
        Assert.That(mpfr_t.ERange, Is.EqualTo(false));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }
}
