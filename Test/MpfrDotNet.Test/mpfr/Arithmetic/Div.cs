namespace Test;

using MpfrDotNet;
using MpirDotNet;
using NUnit.Framework;

[TestFixture]
public class Div
{
    [Test]
    public void BasicDiv()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpfr_t b = new mpfr_t("2229874359879827.30594288574029879874539");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("2.229874359879827305942885740298798745393E+15"));

        using mpfr_t c = a / b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("9.978581596652908672326051721084245817085E+9"));

        using mpfr_t d = b / a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("1.002146437661468404543190980751667421245E-10"));

        using mpfr_t e1 = a.Div2(5);

        AsString = e1.ToString();
        Assert.That(AsString, Is.EqualTo("6.953432265732821823282182366884182678746E+23"));

        using mpfr_t e2 = new();
        mpfr.div_2exp(e2, a, 5, a.Rounding);
        Assert.That(e2, Is.EqualTo(e1));

        using mpfr_t f = a.Div2(-5);

        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("7.120314640110409547040954743689403063036E+26"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void DivULong()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        ulong b = 8720124937520142UL;

        using mpfr_t c = a / b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("2.551681702931292876518208885227976678701E+9"));

        using mpfr_t d = b / a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("3.918984091359165153636009401419429413444E-10"));

        using mpfr_t e = a / c;

        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("8.720124937520142E+15"));

        using mpfr_t f = d * a;

        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("8.720124937520142E+15"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void DivLong()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        long b = -8720124937520142L;

        using mpfr_t c = a / b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-2.551681702931292876518208885227976678701E+9"));

        using mpfr_t d = b / a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("-3.918984091359165153636009401419429413444E-10"));

        using mpfr_t e = a / c;

        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("-8.720124937520142E+15"));

        using mpfr_t f = d * a;

        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("-8.720124937520142E+15"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void DivDouble()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        double b = 2229874359879827.30594288574029879874539;

        using mpfr_t c = a / b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("9.978581596652908922667801980899906698118E+9"));

        using mpfr_t d = b / a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("1.002146437661468379401432025254124159987E-10"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void DivInteger()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpz_t b = new mpz_t("-8720124937520142");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("-8720124937520142"));

        using mpfr_t c = a / b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-2.551681702931292876518208885227976678701E+9"));

        using mpfr_t d = b / a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("-3.918984091359165153636009401419429413444E-10"));

        using mpfr_t e = a / c;

        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("-8.720124937520142E+15"));

        using mpfr_t f = d * a;

        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("-8.720124937520142E+15"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }

    [Test]
    public void DivRational()
    {
        string AsString;

        Assert.That(mpfr_t.LiveObjectCount(), Is.EqualTo(0));

        ulong DefaultPrecision = mpfr_t.DefaultPrecision;
        mpfr_t.DefaultPrecision = 128;

        using mpfr_t a = new mpfr_t("22250983250345029834502983.5740293845720");
        AsString = a.ToString();
        Assert.That(AsString, Is.EqualTo("2.225098325034502983450298357402938457199E+25"));

        using mpq_t b = new mpq_t("-222987435987982730594288574029879874539/590872612825179551336102196593");
        AsString = b.ToString();
        Assert.That(AsString, Is.EqualTo("-222987435987982730594288574029879874539/590872612825179551336102196593"));

        using mpfr_t c = a / b;

        AsString = c.ToString();
        Assert.That(AsString, Is.EqualTo("-5.896070580303556089511479770675689024189E+16"));

        using mpfr_t d = b / a;

        AsString = d.ToString();
        Assert.That(AsString, Is.EqualTo("-1.696044825753282496333033121182380714135E-17"));

        using mpfr_t bF = new mpfr_t(b);
        AsString = bF.ToString();
        Assert.That(AsString, Is.EqualTo("-3.773866500967064352396380307396069631533E+8"));

        using mpfr_t e = a / c;

        AsString = e.ToString();
        Assert.That(AsString, Is.EqualTo("-3.773866500967064352396380307396069631533E+8"));

        using mpfr_t f = d * a;

        AsString = f.ToString();
        Assert.That(AsString, Is.EqualTo("-3.773866500967064352396380307396069631533E+8"));

        mpfr_t.DefaultPrecision = DefaultPrecision;
    }
}
