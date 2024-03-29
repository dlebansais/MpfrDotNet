﻿namespace Test;

using Interop.Mpfr;
using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class MiscArithmetic
{
    [Test]
    public void Abs()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("-22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("-2.225098325034502983450298357402938457199E+25"));

        using mpfr_t b = a.Abs();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpfr_t c = -b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-2.225098325034502983450298357402938457199E+25"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void EuclideanNorm()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("8650279350142877.30794528793012596741");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("8.650279350142877307945287930125967410004E+15"));

        using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.229874359879827305942885740298798745393E+15"));

        using mpfr_t c = mpfr_t.EuclideanNorm(a, b);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("8.933066242693924484281160416619878271456E+15"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Dim()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("8650279350142877.30794528793012596741");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("8.650279350142877307945287930125967410004E+15"));

        using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.229874359879827305942885740298798745393E+15"));

        using mpfr_t c = mpfr_t.Dim(a, b);

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("6.420404990263050002002402189827168664612E+15"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Fma()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("8650279350142877.30794528793012596741");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("8.650279350142877307945287930125967410004E+15"));

        using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.229874359879827305942885740298798745393E+15"));

        using mpfr_t c = new mpfr_t("87645");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("8.7645E+4"));

        using mpfr_t d = mpfr_t.Fma(a, b, c);

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("1.928903612868153707175972877355111472797E+31"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Fms()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("8650279350142877.30794528793012596741");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("8.650279350142877307945287930125967410004E+15"));

        using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.229874359879827305942885740298798745393E+15"));

        using mpfr_t c = new mpfr_t("87645");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("8.7645E+4"));

        using mpfr_t d = mpfr_t.Fms(a, b, c);

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("1.928903612868153707175972859826111472797E+31"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Fmma()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("8650279350142877.30794528793012596741");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("8.650279350142877307945287930125967410004E+15"));

        using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.229874359879827305942885740298798745393E+15"));

        using mpfr_t c = new mpfr_t("87645");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("8.7645E+4"));

        using mpfr_t d = new mpfr_t("32");
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("3.2E+1"));

        using mpfr_t e = mpfr_t.Fmma(a, b, c, d);

        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("1.928903612868153707175973149054611472797E+31"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Fmms()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("8650279350142877.30794528793012596741");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("8.650279350142877307945287930125967410004E+15"));

        using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.229874359879827305942885740298798745393E+15"));

        using mpfr_t c = new mpfr_t("87645");
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("8.7645E+4"));

        using mpfr_t d = new mpfr_t("32");
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("3.2E+1"));

        using mpfr_t e = mpfr_t.Fmms(a, b, c, d);

        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("1.928903612868153707175972588126611472797E+31"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Factorial()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        ulong a = 222501UL;

        using mpfr_t b = new();
        mpfr.fac_ui(b, a, mpfr_rnd_t.MPFR_RNDN);

        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("6.703037045797151110693847022162476597163E+1093158"));

        using mpz_t c = new();
        mpz.fac_ui(c, a);

        AsString = c.ToString().Substring(0, 15);
        Assert.That(AsString, Is.EqualTo("670303704579715"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }
}
