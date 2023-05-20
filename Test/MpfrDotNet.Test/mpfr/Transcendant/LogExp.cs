namespace Test;

using MpfrDotNet;
using NUnit.Framework;

[TestFixture]
public class LogExp
{
    [Test]
    public void BasicLog()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpfr_t b = a.Log();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("5.836442843051969389267793554191892433256E+1"));

        using mpfr_t c = b.Exp();

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457085E+25"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Log2()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpfr_t b = a.Log2();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("8.420207146102958816749399807191077915785E+1"));

        using mpfr_t c = b.Exp2();

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457255E+25"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Log10()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpfr_t b = a.Log10();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.534734920681197166907985697152107837455E+1"));

        using mpfr_t c = b.Exp10();
        
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457028E+25"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Log2p1()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpfr_t b = a.Log2p1();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("8.42020714610295881674939981367481404851E+1"));

        using mpfr_t c = b.Exp2m1();

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457267E+25"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Log10p1()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpfr_t b = a.Log10p1();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.534734920681197166907985699103906897381E+1"));

        using mpfr_t c = b.Exp10m1();

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457301E+25"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void LogULong()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 2048;

        uint a = 3466500406U;

        using mpfr_t b = mpfr_t.Log(a);
        using mpfr_t c = b * 10000000;
        using mpfr_t d = c.Round();

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("2.19664114E+8"));

        using mpfr_t e = b.Exp();
        using mpfr_t f = e.Round();

        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("3.466500406E+9"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Log1p()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpfr_t b = a.Log1p();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("5.836442843051969389267793558686075853157E+1"));

        using mpfr_t c = b.Expm1();

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.22509832503450298345029835740293845729E+25"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }
}
