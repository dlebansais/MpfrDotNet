namespace Test;

using MpfrDotNet;
using NUnit.Framework;

[TestFixture]
public class OtherTranscendant
{
    [Test]
    public void EInt()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = a.EInt();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1.464469064165395407502804341330312075707E+1"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Li2()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = a.Li2();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.176450415457266325769480830033231166786E+0"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Gamma()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = a.Gamma();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("3.609385794309124452160672524356516719104E+0"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void IncompleteGamma()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = new mpfr_t("1.5");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1.5E+0"));

        using mpfr_t c = a.IncompleteGamma(b);
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("3.226154687610714404094446773369706639153E+0"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void LnGamma()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = a.LnGamma();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1.283537617788749171105919350505757877919E+0"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void LnGammaAbs()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = a.LnGammaAbs(out int Sign);
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1.283537617788749171105919350505757877919E+0"));
        Assert.That(Sign, Is.EqualTo(1));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Digamma()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = a.Digamma();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1.127320994410757002627085419305586130668E+0"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Beta()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = new mpfr_t("1.5");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1.5E+0"));

        using mpfr_t c = mpfr_t.Beta(a, b);
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("1.19146838998127572925798272270474625767E-1"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Erf()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = a.Erf();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("9.999995683464430635301370470879277339738E-1"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Erfc()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = a.Erfc();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("4.316535569364698629529120722660274699669E-7"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void BesselFirst()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = a.BesselFirst0();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("-3.891485474826576070635276292899332116398E-1"));

        using mpfr_t c = a.BesselFirst1();
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("1.063371973686285193597977570893754459861E-1"));

        using mpfr_t d = a.BesselFirst(2);
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("4.486540444590696774487575146630299084673E-1"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void BesselSecond()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = a.BesselSecond0();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1.584859451637762053489146372510555421326E-1"));

        using mpfr_t c = a.BesselSecond1();
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("4.144198182872975437689573818560823779673E-1"));

        using mpfr_t d = a.BesselSecond(2);
        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("7.342027255016991228197991177576719701988E-2"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void ArithmeticGeometricMean()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = new mpfr_t("1.5");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("1.5E+0"));

        using mpfr_t c = mpfr_t.ArithmeticGeometricMean(a, b);
        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.42493769397463790459621501605688333758E+0"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void Airy()
    {
        string AsString;

        Assert.IsTrue(mpfr_t.LiveObjectCount() == 0);

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("3.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("3.574029384572E+0"));

        using mpfr_t b = a.Airy();
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.237425191593261833333554237969850719294E-3"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }
}
